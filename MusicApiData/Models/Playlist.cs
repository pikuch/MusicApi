using System;
using System.Collections.Generic;

namespace MusicApiData.Models
{
    public class Playlist
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
