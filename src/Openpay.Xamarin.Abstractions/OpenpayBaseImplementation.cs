using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Openpay.Xamarin.Abstractions
{
    public abstract class OpenpayBaseImplementation : IOpenpay
    {
        private const string SandboxUrl = "https://sandbox-api.openpay.mx";
        private const string ProductionUrl = "https://api.openpay.mx";

        private string _apiKey;
        private string _baseUrl;
        private string _merchantId;

        public void Initialize(string merchantId, string publicApiKey, bool productionMode)
        {
            _merchantId = merchantId ?? throw new ArgumentNullException(merchantId);
            _apiKey = publicApiKey ?? throw new ArgumentNullException(nameof(publicApiKey));
            _baseUrl = productionMode ? ProductionUrl : SandboxUrl;
        }

        public Task<string> CreateDeviceSessionId()
        {
            if (string.IsNullOrWhiteSpace(_baseUrl))
            {
                throw new InvalidOperationException("Openpay has not been intialized.");
            }

            return CreateDeviceSessionIdInternal(_merchantId, _apiKey, _baseUrl);
        }

        /// <summary>
        /// Para la creación de un token en Openpay es necesario enviar el objeto con la información a registrar. Una vez guardado el token no se puede obtener el número y código de seguridad ya que esta información es encriptada.
        /// </summary>
        /// <param name="card">La tarjeta a utilizar al crear el token</param>
        /// <returns>
        /// Regresa un objeto <see cref="Token"/>.
        /// </returns>
        public Task<Token> CreateTokenFromCard(Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            return Post<Card, Token>($"/v1/{_merchantId}/tokens", card);
        }

        /// <summary>
        /// Obtiene los detalles de un token. Es necesario tener el id.
        /// </summary>
        /// <param name="id">Identificador de token.</param>
        /// <returns>
        /// Regresa un objeto <see cref="Token"/>.
        /// </returns>
        public Task<Token> GetTokenFromId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return Get<Token>($"/v1/{_merchantId}/tokens/{id}");
        }

        protected abstract Task<string> CreateDeviceSessionIdInternal(string merchantId, string apiKey, string baseUrl);

        private async Task<TResponse> Get<TResponse>(string requestUrl)
        {
            if (string.IsNullOrWhiteSpace(_baseUrl))
            {
                throw new InvalidOperationException("Openpay has not been intialized.");
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = GetAuthorizationHeader();

                var response = await httpClient.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TResponse>(json);
                }
                else
                {
                    await EvalResponseError(response);
                }
            }

            return default(TResponse);
        }

        private async Task<TResponse> Post<TRequest, TResponse>(string requestUrl, TRequest request)
        {
            if (string.IsNullOrWhiteSpace(_baseUrl))
            {
                throw new InvalidOperationException("Openpay has not been intialized.");
            }

            var requestContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = GetAuthorizationHeader();

                var response = await httpClient.PostAsync(requestUrl, requestContent);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TResponse>(json);
                }
                else
                {
                    await EvalResponseError(response);
                }
            }

            return default(TResponse);
        }

        private AuthenticationHeaderValue GetAuthorizationHeader()
        {
            var key = Convert.ToBase64String(Encoding.Default.GetBytes($"{_apiKey}:"));
            return new AuthenticationHeaderValue("Basic", key);
        }

        private async Task EvalResponseError(HttpResponseMessage responseMessage)
        {
            var errorDefinition = new
            {
                category = string.Empty,
                error_code = 1,
                description = string.Empty,
                http_code = string.Empty,
                request_id = string.Empty,
            };

            var json = await responseMessage.Content.ReadAsStringAsync();
            var error = JsonConvert.DeserializeAnonymousType(json, errorDefinition);
            if (1000 <= error.error_code && error.error_code <= 4999)
            {
                throw new InvalidOperationException(await responseMessage.Content.ReadAsStringAsync());
            }
        }
    }
}
