using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    public class Movies
    {
        // Primary key for the movie
        [Key] [Required] public int MovieID { get; set; }

        // Movie category (e.g., action, drama)
        [Required] public string Category { get; set; } 

        // Movie title
        [Required] public string Title { get; set; }

        // Release year of the movie
        [Required] public int Year { get; set; }

        // Director of the movie
        [Required] public string Director { get; set; }

        // Movie rating (e.g., PG, R)
        [Required] public string Rating { get; set; }

        // Indicates if the movie was edited
        public bool? Edited { get; set; }

        // Person to whom the movie was lent
        public string? LentTo { get; set; }

        // Notes about the movie, with a max length of 25 characters
        [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }
    }
}