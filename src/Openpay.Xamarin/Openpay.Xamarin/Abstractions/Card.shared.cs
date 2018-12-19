using Newtonsoft.Json;
using System;

namespace Openpay.Xamarin.Abstractions
{
    /// <summary>
    /// Objeto tarjeta de Openpay.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Identificador único de la tarjeta.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Fecha y hora en que se creó la tarjeta en formato ISO 8601
        /// </summary>
        [JsonProperty("creation_date")]
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Permite conocer si se pueden realizar cargos a la tarjeta.
        /// </summary>
        [JsonProperty("allows_charges")]
        public bool AllowCharges { get; set; }

        /// <summary>
        /// Permite conocer si se pueden realizar envíos de pagos a la tarjeta.
        /// </summary>
        [JsonProperty("allows_payouts")]
        public bool AllowPayouts { get; set; }

        /// <summary>
        /// Nombre del banco emisor.
        /// </summary>
        [JsonProperty("bank_name")]
        public string BankName { get; set; }

        /// <summary>
        /// Nombre del tarjeta habiente.
        /// </summary>
        [JsonProperty("holder_name")]
        public string HolderName { get; set; }

        /// <summary>
        /// Mes de expiración tal como aparece en la tarjeta.
        /// </summary>
        [JsonProperty("expiration_month")]
        public string ExpirationMonth { get; set; }

        /// <summary>
        /// Año de expiración tal como aparece en la tarjeta.
        /// </summary>
        [JsonProperty("expiration_year")]
        public string ExpirationYear { get; set; }

        /// <summary>
        /// Número de tarjeta, puede ser de 16 o 19 dígitos.
        /// </summary>
        [JsonProperty("card_number")]
        public string Number { get; set; }

        /// <summary>
        /// Marca de la tarjeta: visa, mastercard, carnet o american express.
        /// </summary>
        [JsonProperty("brand")]
        public string Brand { get; set; }

        /// <summary>
        /// Tipo de la tarjeta: debit, credit, cash, etc.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Código del banco emisor.
        /// </summary>
        [JsonProperty("bank_code")]
        public string BankCode { get; set; }

        /// <summary>
        /// Código de seguridad como aparece en la parte de atrás de la tarjeta. Generalmente 3 dígitos.
        /// </summary>
        [JsonProperty("cvv2")]
        public int Cvv2 { get; set; }

        /// <summary>
        /// Dirección de facturación del tarjeta habiente.
        /// </summary>
        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}