﻿using System;
using System.Collections.Generic;

#nullable disable

namespace movieapi.Model
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
