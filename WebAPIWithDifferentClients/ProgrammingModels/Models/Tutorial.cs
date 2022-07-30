namespace ProgrammingModels.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tutorial
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
      
        public string? Content { get; set; }

        [ForeignKey(nameof(ProgrammingLanguage))]
        public int ProgrammingLanguageId { get; set; }

        public ProgrammingLanguage? ProgrammingLanguage { get; set; }
    }
}
