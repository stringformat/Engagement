using System.Net;
using System.Net.Http.Json;
using EasyTestServer.Core;
using EasyTestServer.EntityFramework;
using Engagement.Infrastructure.Common;
using FluentAssertions;

namespace Engagement.FeatureTests.Users;

public class CreateTests
{
    [Fact]
    public async Task Should_Return200AndIdOfCreatedUser_When_ValidRequestIsSent()
    {
        // arrange
        var client = new Server()
            .UseDatabase()
                .Build<EngagementContext>()
            .Build<Program>()
            .CreateClient();

        // act
        var response = await client.PostAsJsonAsync("api/users", new { FirstName = "Jean", LastName = "Charles", Email = "jean.charles@email.test" });
        
        // assert
        var content = await response.Content.ReadAsStringAsync();
        
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().NotBeNullOrEmpty();
    }
    
    [Fact]
    public async Task Should_Return404_When_UserNotFound()
    {
        // arrange
        var client = new Server()
            .UseDatabase()
                .Build<EngagementContext>()
            .Build<Program>()
            .CreateClient();

        // act
        var response = await client.GetAsync($"api/users/{Guid.NewGuid()}");
        
        // assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
    
    [Fact]
    public async Task Should_ReturnOk_When_UserIsFound()
    {
        // arrange
        var client = new Server()
            .UseDatabase()
                .Build<EngagementContext>()
            .Build<Program>()
            .CreateClient();

        // act
        await client.PostAsJsonAsync("api/users", new { FirstName = "Jean", LastName = "Charles", Email = "jean.charles@email.test" });
        var response = await client.GetAsync("api/users");
        
        // assert
        var content = await response.Content.ReadAsStringAsync();
        
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().NotBeNullOrEmpty();
    }
}                                           