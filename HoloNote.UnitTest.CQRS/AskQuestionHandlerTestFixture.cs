using HoloNote.Core.CQRS.AskQuestion;
using HoloNote.Core.Services;
using HoloNote.Core.Services.Contract;
using Moq;
using Moq.Protected;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Json;

namespace HoloNote.UnitTest.CQRS
{
    public class AskQuestionHandlerTestFixture
    {
        private readonly Mock<IAIService> _mockAIService;
        private readonly Mock<HttpClient> _mockHttpClient;
        private readonly Mock<HttpMessageHandler> _mockMessageHandler;
        public AskQuestionHandlerTestFixture()
        {
            _mockAIService = new Mock<IAIService>();
            _mockHttpClient = new Mock<HttpClient>();
            _mockMessageHandler = new Mock<HttpMessageHandler>();
        }

        [Fact]
        public async Task Test1()
        {
            //Arrange
            _mockMessageHandler.Protected()
                       .Setup<Task<HttpResponseMessage>>(
                           "SendAsync",
                           ItExpr.Is<HttpRequestMessage>(req =>
                               req.Method == HttpMethod.Post &&
                               req.RequestUri == new Uri("https://example.com/api/resource")),
                           ItExpr.IsAny<CancellationToken>())
                       .ReturnsAsync(new HttpResponseMessage
                       {
                           StatusCode = HttpStatusCode.OK,
                           Content = new StringContent("{\"result\":\"success\"}"),
                       });

            var httpClient = new HttpClient(_mockMessageHandler.Object);
            httpClient.BaseAddress = new Uri("https://example.com");

            _mockAIService.Setup(x => x.GetHttp()).Returns(httpClient);
            var query = new AskQuestionQuery
            {
                Question = "Test"
            };

            var askQuestionHandler = new AskQuestionQueryHandler(_mockAIService.Object);
            var response = await askQuestionHandler.Handle(query, CancellationToken.None);
            //Act

            Assert.True(response == null);
        }
    }
}