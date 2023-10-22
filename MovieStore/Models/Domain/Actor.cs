using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models.Domain
{
    public class Actor
    {
        public int Id { get; set; }
        [Required]
        public string ActorName { get; set; }
    }
}
