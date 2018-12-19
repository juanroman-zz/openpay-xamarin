using System.Threading.Tasks;

namespace Openpay.Xamarin.Abstractions
{
    /// <summary>
    /// Default contract for the API
    /// </summary>
    public interface IOpenpay
    {
        /// <summary>
        /// Inicializa el API de Openpay con la configuración del consumidor
        /// </summary>
        /// <param name="merchantId">El identificador del cliente</param>
        /// <param name="publicApiKey">La llave pública del API del cliente</param>
        /// <param name="productionMode">If set to <c>true</c> production mode; de lo contrario, Sandbox.</param>
        void Initialize(string merchantId, string publicApiKey, bool productionMode);

        /// <summary>
        /// Crea una nueva sesión para tokenizar tarjetas.
        /// </summary>
        /// <returns>El identificador único de la sesión del cliente.</returns>
        Task<string> CreateDeviceSessionId();

        /// <summary>
        /// Para la creación de un token en Openpay es necesario enviar el objeto con la información a registrar. Una vez guardado el token no se puede obtener el número y código de seguridad ya que esta información es encriptada.
        /// </summary>
        /// <param name="card">La tarjeta a utilizar al crear el token</param>
        /// <returns>
        /// Regresa un objeto <see cref="Token"/>.
        /// </returns>
        Task<Token> CreateTokenFromCard(Card card);

        /// <summary>
        /// Obtiene los detalles de un token. Es necesario tener el id.
        /// </summary>
        /// <param name="id">Identificador de token.</param>
        /// <returns>
        /// Regresa un objeto <see cref="Token"/>.
        /// </returns>
        Task<Token> GetTokenFromId(string id);
    }
}
