namespace ALTC.Tests.Helpers
{
    using Moq;
    using Moq.Contrib.HttpClient;
    using System;
    using System.Net;
    using System.Net.Http;

    internal class HttpClientHelper
    {
        private readonly HttpClient _httpClient;
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;

        private string _baseAddress = "http://localhost:3000/";
        private string _clientName = string.Empty;

        public HttpClientHelper(string clientName)
        {
            _clientName = clientName;

            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClient = _httpMessageHandlerMock.CreateClient();

            _httpClient.BaseAddress = new Uri(_baseAddress);
        }

        public HttpClientHelper SetupGet(string pathUrl, string response, HttpStatusCode httpStatusCode = HttpStatusCode.OK) => SetupGet(HttpMethod.Get, pathUrl, response, httpStatusCode);


        private HttpClientHelper SetupGet(HttpMethod httpMethod, string pathUrl, string response, HttpStatusCode statusCodeResponse)
        {
            _httpMessageHandlerMock.SetupRequest(httpMethod, $"{_httpClient.BaseAddress}{pathUrl}")
                                   .ReturnsResponse(statusCodeResponse, response);

            return this;
        }

        public Mock<IHttpClientFactory> Build()
        {
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();

            httpClientFactoryMock.Setup(x => x.CreateClient(_clientName))
                                 .Returns(_httpClient);

            return httpClientFactoryMock;
        }
    }
}
