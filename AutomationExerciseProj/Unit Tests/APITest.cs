using System.Text.Json;
using RestSharp;
using Xunit;


namespace AutomationExerciseProj;

public class APITest
{
[InlineData(true)]
[Theory]
public void TestApi(bool x)
{
    //Arrange
    var restClient = new RestClient("https://reqres.in");
    var restRequest = new RestRequest("/api/users", Method.Get);

    //Act
    // The above line of code won't work because the Execute method in the RestClient class returns a RestResponse object, not an IRestResponse object. 
    // To fix this, we need to change the type of the response variable to RestResponse instead of IRestResponse. 
    RestResponse response = restClient.Execute(restRequest);

    //Assert
    Assert.Equal(x,response.IsSuccessful);
    //Assert
}


[Fact]
public void TestApi2()
{
    //Arrange
    var restClient = new RestClient("https://reqres.in");
        var restRequest = new RestRequest("/api/unknown/2", Method.Get); // Ensure the correct endpoint

        //Act
        RestResponse response = restClient.Execute(restRequest);

        // Assert
        Assert.True(response.IsSuccessful, "API call was not successful");

        // Parse JSON response
        var jsonResponse = JsonDocument.Parse(response.Content);
        var data = jsonResponse.RootElement.GetProperty("data");

        var id = data.GetProperty("id").GetInt32();
        var name = data.GetProperty("name").GetString();

        // Verify the response values
        Assert.Equal(2, id); // Ensure this matches the expected value from the actual response
        Assert.Equal("fuchsia rose", name); 
   
}


}