using Xunit;
using Moq;
using PokeAdvantage.Implementation.ErrorHandler;
using PokeAdvantage.Interfaces;
using System;

namespace PokeAdvantage.Tests
{
    public class ConsoleErrorHandlerTests
    {
        private readonly Mock<ILogger> mockLogger;
        private readonly ConsoleErrorHandler consoleErrorHandler;


        public ConsoleErrorHandlerTests()
        {
            mockLogger = new Mock<ILogger>();
            consoleErrorHandler = new ConsoleErrorHandler(mockLogger.Object);
        }

        [Fact]
        public void HandleError_ShouldLogErrorMessage()
        {
            // Arrange
            var exception = new Exception("Sample Error");

            // Act
            consoleErrorHandler.HandleError(exception);

            // Assert
            mockLogger.Verify(m => m.LogError("An error occurred: Sample Error"), Times.Once);
        }

        [Fact]
        public void HandleError_ShouldLogIfExceptionIsNull()
        {
            // Arrange
            Exception exception = null;

            // Act
            consoleErrorHandler.HandleError(exception);

            // Assert
             mockLogger.Verify(m => m.LogError("The exception is null"), Times.Once);
        }
    }
}