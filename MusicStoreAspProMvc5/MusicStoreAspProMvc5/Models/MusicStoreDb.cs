namespace MusicStoreAspProMvc5.Models
{
    using System.Data.Entity;

    public class MusicStoreDb : DbContext
    {
        public MusicStoreDb() : base("name=MusicStoreDB")
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}