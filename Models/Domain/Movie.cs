

using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string imgUrl { get; set; }

        [Required]
        public int ActorId { get; set; }
        [Required]
        public int DirectorId { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        public int price { get; set; }

        [NotMapped]
        public string? ActorName { get; set; }
        [NotMapped]
        public string? DirectorName { get; set; }
        [NotMapped]
        public string? GenreName { get; set; }

        [NotMapped]
        public List<SelectListItem>? ActorList { get; set; }
        [NotMapped]
        public List<SelectListItem>? DirectorList { get; set; }
        [NotMapped]
        public List<SelectListItem>? GenreList { get; set; }
    }
}
