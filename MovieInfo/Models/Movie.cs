using System.ComponentModel.DataAnnotations;

namespace MovieInfo.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string? Title { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string? Director { get; set; }
        
        [Range(1,5,ErrorMessage = "Display review must be from 1 to 5 out of 5")]
        public int Review {  get; set; }
    }
}
