using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace API_Waylan_Origin.DTOs.Wompi
{
    public class WompiWebHookDto
    {
        [JsonPropertyName("event")]
        [JsonProperty("event")]
        public string Event { get; set; } // Nos dirá si es "transaction.updated"

        [JsonPropertyName("data")]
        [JsonProperty("data")]
        public WompiData Data { get; set; }

        [JsonPropertyName("signature")]
        [JsonProperty("signature")]
        public WompiSignature Signature { get; set; }

        [JsonPropertyName("timestamp")]
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
    public class WompiData
    {

        [JsonPropertyName("transaction")]
        [JsonProperty("transaction")]
        public WompiTransaction Transaction { get; set; }
    }

    public class WompiTransaction
    {
        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public string Id { get; set; } // El ID único de Wompi

        [JsonPropertyName("status")]
        [JsonProperty("status")]
        public string Status { get; set; } // APPROVED, DECLINED, VOIDED, ERROR

        [JsonPropertyName("reference")]
        [JsonProperty("reference")]
        public string Reference { get; set; } // Este será el ID de tu Pedido (ej. "105")

        [JsonPropertyName("amount_in_cents")]
        [JsonProperty("amount_in_cents")]
        public long AmountInCents { get; set; } // Wompi maneja todo en centavos
    }

    public class WompiSignature
    {
        [JsonPropertyName("checksum")]
        [JsonProperty("checksum")]
        public string Checksum { get; set; } // El código de seguridad para validar
    }
}
