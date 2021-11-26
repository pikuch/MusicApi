using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicApiData.Models
{
    public class Playlist
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(127, MinimumLength = 1, ErrorMessage = "Allowed length is from 1 to 127")]
        public string Name { get; set; }

        [Required]
        [Range(typeof(DateTime), "01/01/1900", "01/01/3000", ErrorMessage = "Allowed dates for the property {0} are between {1} and {2}")]
        public DateTime Created { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
