#nullable disable

namespace movieapi.Model
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Year { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public double? Rating { get; set; }
        public byte[] Poster { get; set; }
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
