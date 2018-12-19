using Newtonsoft.Json;

namespace Openpay.Xamarin.Abstractions
{
    /// <summary>
    /// Objeto Token de Openpay
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Identificador del token. Esté es el que deberás usar para posteriormente hacer un cargo.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Datos de la tarjeta asociada al token
        /// </summary>
        public Card Card { get; set; }
    }
}
