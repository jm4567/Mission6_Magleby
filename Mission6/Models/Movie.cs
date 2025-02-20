using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models
{
    public class Movie
    {
        // Primary key for the movie
        [Key] [Required] public int MovieId { get; set; }

        
        // Movie category (e.g., action, drama)
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; } 
        public Category? Category { get; set; }
        

        // Movie title
        [Required] public string Title { get; set; }

        // Release year of the movie
        [Required]     
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }

        // Director of the movie
        public string? Director { get; set; }

        // Movie rating (e.g., PG, R)
        public string? Rating { get; set; }

        // Indicates if the movie was edited
        [Required] public bool Edited { get; set; }

        // Person to whom the movie was lent
        public string? LentTo { get; set; }
        
        [Required] public bool CopiedToPlex { get; set; }

        // Notes about the movie, with a max length of 25 characters
        [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }
    }
}