namespace MusicalApp
{
    using System.Data.Entity;

    public class MusicContext : DbContext
    {
        public MusicContext()
            : base("name=MusicContext")
        {
        }

         public virtual DbSet<Song> Songs { get; set; }
         public virtual DbSet<Group> Groups { get; set; }
    }

}