using System.Collections.Generic;

namespace MusicApiData.Models
{
    public class Artist
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
