using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SpesenApp.Models.ViewModels
{
    public class SpesenEintragCreateViewModel
    {
        public int PersonenId { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Datum { get; set; }

        [Display(Name = "Kurzbeschrieb")]
        public string? Beschreibung { get; set; }

        [Display(Name = "KST 1")]
        [Required]
        public int Kst1 { get; set; }

        [Display(Name = "KST 2")]
        public int? Kst2 { get; set; }

        public List<SelectListItem> Kst1Optionen { get; set; } = new List<SelectListItem>();

        [Display(Name = "Verpflegung")]
        [Range(0, double.MaxValue)]
        public decimal Verpflegung { get; set; }

        [Display(Name = "Reisekosten")]
        [Range(0, double.MaxValue)]
        public decimal Reisekosten { get; set; }

        [Display(Name = "Km Auto")]
        [Range(0, double.MaxValue)]
        public decimal KmAuto { get; set; }

        [Display(Name = "Reisespesen Auto")]
        public decimal ReisespesenAuto => KmAuto * 0.7m;


        [Display(Name = "Kursmaterial")]
        [Range(0, double.MaxValue)]
        public decimal Kursmaterial { get; set; }

        [Display(Name = "Andere Kosten")]
        [Range(0, double.MaxValue)]
        public decimal AndereKosten { get; set; }

        [Display(Name = "Totalbetrag")]
        public decimal Total =>
            Verpflegung +
            Reisekosten +
            ReisespesenAuto +
            Kursmaterial +
            AndereKosten;
    }
}
