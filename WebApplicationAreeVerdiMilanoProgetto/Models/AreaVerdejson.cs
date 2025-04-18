using Newtonsoft.Json;

namespace WebApplicationAreeVerdiMilanoProgetto.Models
{
    public class AreaVerde
    {
        public string? Zona { get; set; }
        public string? Tipo { get; set; }
        public string? Area { get; set; }
        public string? Classificazione { get; set; }
        public string? AFFIDATARIO { get; set; }

        [JsonProperty("Superficie totale in mq")]
        public string? Superficietotaleinmq { get; set; }

        public string? Descrizione { get; set; }

        [JsonProperty("ID Località")]
        public string? IDLocalità { get; set; }

        [JsonProperty("Nome località")]
        public string? Nomelocalità { get; set; }

        [JsonProperty("Classificazione ISTAT")]
        public string? ClassificazioneISTAT { get; set; }
    }
}
