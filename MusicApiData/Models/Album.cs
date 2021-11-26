using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicApiData.Models
{
    public class Album
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(127, MinimumLength = 1, ErrorMessage = "Allowed length is from 1 to 127")]
        public string Title { get; set; }

        [Required]
        [Range(1, 3000, ErrorMessage = "Allowed year range is from 1 to 3000")]
        public int Year { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
