using Xunit;

namespace TodoApi.Tests.Integration;

// c.f. https://dotnetthoughts.net/dotnet-minimal-api-integration-testing/

public class BasicTest
{
    // [Fact]
    [Fact(Skip="for now this requires database")]
    public async void TestApp()
    {
        // Given
        await using var application = new TodoApiApp();

        // When
        var client = application.CreateClient();
        var res = await client.GetStringAsync("/Todo/1");

        // Then
        Assert.NotNull(res);
        var expected = @"{""id"":1,""name"":""Foo"",""isComplete"":false}";
        Assert.Equal(expected, res);
    }
}
