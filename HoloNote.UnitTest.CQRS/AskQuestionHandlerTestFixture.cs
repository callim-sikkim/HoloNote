using HoloNote.Core.CQRS.AskQuestion;
using HoloNote.Core.Services;

using Moq;
using Moq.Protected;

using System.Net;

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
        public async Task Handler_Should_Return_Not_Null_Response()
        {
            //Arrange
            _mockMessageHandler.Protected()
                       .Setup<Task<HttpResponseMessage>>(
                           "SendAsync",
                           ItExpr.Is<HttpRequestMessage>(req =>
                               req.Method == HttpMethod.Post &&
                               req.RequestUri == new Uri("https://api.openai.com/v1/chat/completions")),
                           ItExpr.IsAny<CancellationToken>())
                       .ReturnsAsync(new HttpResponseMessage
                       {
                           StatusCode = HttpStatusCode.OK,
                           Content = new StringContent("{\"result\":\"success\",\"choices\":[{\"message\":{\"role\":\"tester\",\"content\":\"test\"}}]}"),
                       });

            var httpClient = new HttpClient(_mockMessageHandler.Object);
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "PAST_API_KEY_HERE");


            _mockAIService.Setup(x => x.GetHttp()).Returns(httpClient);
            var query = new AskQuestionQuery
            {
                Question = "Test"
            };

            var askQuestionHandler = new AskQuestionQueryHandler(_mockAIService.Object);
            var response = await askQuestionHandler.Handle(query, CancellationToken.None);
            //Act

            Assert.True(response != null);
            Assert.True(response.Answer == "test");
        }
    }
}