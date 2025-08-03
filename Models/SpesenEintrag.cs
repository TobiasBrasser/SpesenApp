using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpesenApp.Models
{
    public class SpesenEintrag
    {
        public int Id { get; set; }

        [Required]
        public DateTime Datum { get; set; }

        public string? Beschreibung { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Kst1 muss gesetzt sein.")]
        public int Kst1 { get; set; }


        public int Kst2 { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Verpflegung { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Reisekosten { get; set; }

        [Range(0, double.MaxValue)]
        public decimal KmAuto { get; set; }

        [Range(0, double.MaxValue)]
        public decimal ReisespesenAuto { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Kursmaterial { get; set; }

        [Range(0, double.MaxValue)]
        public decimal AndereKosten { get; set; }

        [NotMapped]
        public decimal Total => Verpflegung + Reisekosten + ReisespesenAuto + Kursmaterial + AndereKosten;

        public int PersonenId { get; set; }
        public Person? Person { get; set; }
    }

}