﻿using System.Collections.Generic;

namespace MusicApiData.Models
{
    public class Album
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}