using System.ComponentModel.DataAnnotations;

namespace SpesenApp.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Vorname { get; set; } = string.Empty;
        
        [Required]
        public string Nachname { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public List<SpesenEintrag> Spesen { get; set; } = new();
    }
}