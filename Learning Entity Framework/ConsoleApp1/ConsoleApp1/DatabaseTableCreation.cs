using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApp1
{
    class DatabaseTableCreation
    {
        static void Main(string[] args)
        {
            using (var context = new MusicContext())
            {
                var count = context.Albums.Count();

                //To view the connection string to locate where the database that is being used
                //Console.WriteLine(context.Database.Connection.ConnectionString);

                context.Albums.Add(new Album() { Price = 9.99m, Title = "Wish" });
                context.SaveChanges();

                var album = context.Albums.Where(x => x.Title.Contains("Wish")).ToList();

                Console.WriteLine(album.Count());
                Console.ReadLine();
            }
        }
    }

    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }

    public class MusicContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
    }
}
