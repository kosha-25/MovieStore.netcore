using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models.Domain
{
    public class Director
    {
        public int Id { get; set; }
        [Required]
        public string DirectorName { get; set; }
    }
}
