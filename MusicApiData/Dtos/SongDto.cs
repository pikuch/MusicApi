using System.ComponentModel.DataAnnotations;

namespace MusicApiData.Dtos
{
    public class SongDto
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(127, MinimumLength = 1, ErrorMessage = "Allowed length is from 1 to 127")]
        public string Title { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Allowed length is from {0} to {1}")]
        public int LengthInSeconds { get; set; }
        public long AlbumId { get; set; }
        public long ArtistId { get; set; }
        public long GenreId { get; set; }
    }
}
