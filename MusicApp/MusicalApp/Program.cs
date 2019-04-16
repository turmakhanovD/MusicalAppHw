using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicalApp
{
    class Program
    {
        static void Main(string[] args)
        {    
            var contextService = new ContextService();

            using (var context = new MusicContext())
            {        
                var result = contextService.GetMostRatedSong(context);
                Console.WriteLine(result);
                contextService.AddSongNGroup(context);
                context.SaveChanges();
            }
            Console.WriteLine("Press any key to leave...");
            Console.ReadLine();
        }
    }
}
