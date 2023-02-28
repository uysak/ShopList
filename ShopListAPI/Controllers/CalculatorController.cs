namespace ShopListAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Xml;

    namespace ShopListAPI.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class CalculatorController : ControllerBase
        {
            private readonly HttpClient _httpClient;

            public CalculatorController(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            [HttpGet]
            public async Task<ActionResult<int>> Multiply(int intA, int intB)
            {
                // SOAP isteğini oluşturma
                var requestEnvelope = new XmlDocument();
                var envelopeElement = requestEnvelope.CreateElement("soap", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
                var bodyElement = requestEnvelope.CreateElement("soap", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
                var multiplyElement = requestEnvelope.CreateElement("tempuri", "Multiply", "http://tempuri.org/");
                var intAElement = requestEnvelope.CreateElement("intA", "http://tempuri.org/");
                intAElement.InnerText = intA.ToString();
                var intBElement = requestEnvelope.CreateElement("intB", "http://tempuri.org/");
                intBElement.InnerText = intB.ToString();

                multiplyElement.AppendChild(intAElement);
                multiplyElement.AppendChild(intBElement);
                bodyElement.AppendChild(multiplyElement);
                envelopeElement.AppendChild(bodyElement);
                requestEnvelope.AppendChild(envelopeElement);

                // SOAP isteği gönderme
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, "http://www.dneonline.com/calculator.asmx");
                httpRequest.Content = new StringContent(requestEnvelope.OuterXml, System.Text.Encoding.UTF8, "text/xml");

                var response = await _httpClient.SendAsync(httpRequest);

                // Yanıtı analiz etme
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseEnvelope = new XmlDocument();
                responseEnvelope.LoadXml(responseContent);
                var namespaceManager = new XmlNamespaceManager(responseEnvelope.NameTable);
                namespaceManager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
                namespaceManager.AddNamespace("m", "http://tempuri.org/");

                var resultNode = responseEnvelope.SelectSingleNode("//m:MultiplyResponse/m:MultiplyResult", namespaceManager);
                var result = int.Parse(resultNode.InnerText);

                return result;
            }
        }
    }

}
