using System.Linq;
using FluentAssertions;

namespace CatalogueService.Tests.WebApplicationFixture
{
    public static class ExpectedResponseExtensions
    {
        public static void ShouldBeCompleted(this ExpectedResponse expectedResponse)
        {
            // Arrange
            var logEntries = expectedResponse.Service.LogEntries.ToList();
            var received = logEntries.Any(logEntry =>
                logEntry.RequestMessage.Path == expectedResponse.Path
                && logEntry.ResponseMessage.StatusCode.Equals(expectedResponse.ExpectedStatusCode));
        
            // Assert
            received.Should().BeTrue();
        }
    }
}