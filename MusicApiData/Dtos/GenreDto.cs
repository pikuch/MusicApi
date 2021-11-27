using System.ComponentModel.DataAnnotations;

namespace MusicApiData.Dtos
{
    public class GenreDto
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(127, MinimumLength = 1, ErrorMessage = "Allowed length is from 1 to 127")]
        public string Name { get; set; }
    }
}
