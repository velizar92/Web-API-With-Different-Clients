namespace ProgrammingModels.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProgrammingLanguage
    {
        public ProgrammingLanguage()
        {
            Tutorials = new HashSet<Tutorial>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Tutorial> Tutorials { get; set; }
    }
}
