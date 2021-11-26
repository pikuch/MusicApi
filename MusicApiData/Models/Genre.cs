using System.Collections.Generic;

namespace MusicApiData.Models
{
    public class Genre
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
