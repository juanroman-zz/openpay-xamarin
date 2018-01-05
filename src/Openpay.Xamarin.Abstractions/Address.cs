using Newtonsoft.Json;

namespace Openpay.Xamarin.Abstractions
{
    /// <summary>
    /// Objeto dirección de Openpay
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Primera línea de dirección del tarjeta habiente. Usada comúnmente para indicar la calle y número exterior e interior.
        /// </summary>
        [JsonProperty("line1")]
        public string Line1 { get; set; }

        /// <summary>
        /// Segunda línea de la dirección del tarjeta habiente. Usada comúnmente para indicar condominio, suite o delegación.
        /// </summary>
        [JsonProperty("line2")]
        public string Line2 { get; set; }

        /// <summary>
        /// Tercer línea de la dirección del tarjeta habiente. Usada comúnmente para indicar la colonia.
        /// </summary>
        [JsonProperty("line3")]
        public string Line3 { get; set; }

        /// <summary>
        /// Código postal del tarjeta habiente
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Estado del tarjeta habiente
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Ciudad del tarjeta habiente
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Código del país del tarjeta habiente a dos caracteres en formato ISO_3166-1
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
    }
}
