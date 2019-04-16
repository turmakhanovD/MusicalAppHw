using System;
using System.Linq;

namespace MusicalApp
{
    public class ContextService
    {
        public string GetMostRatedGroup(MusicContext context)
        {
                var result = (from x in context.Groups
                              orderby x.Rating ascending
                              select x).FirstOrDefault().Name;

                return result;
        }

        public void AddSongNGroup(/*string name,string text , int duration, int rating, */MusicContext context)
        {
            Console.WriteLine("Enter name: ");
            var name = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Enter text: ");
            var text = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Enter duration: ");
            int duration = 0;
            while (!int.TryParse(Console.ReadLine(), out duration))
            {
                Console.Clear();
                Console.WriteLine("Enter duration: ");
            }
            Console.Clear();

            Console.WriteLine("Enter rating (less 5): ");
            int rating = 0;
            while (!int.TryParse(Console.ReadLine(), out rating) || rating > 5)
            {
                Console.Clear();
                Console.WriteLine("Enter rating (less 5): ");
            }
            Console.Clear();

            Console.WriteLine("Enter Group name: ");
            var gName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Enter Group member count: ");
            int gMemCount = 0;
            while (!int.TryParse(Console.ReadLine(), out gMemCount))
            {
                Console.Clear();
                Console.WriteLine("Enter Group member count: ");
            }
            Console.Clear();

            Console.WriteLine("Enter Group rating : ");
            int gRating = 0;
            while (!int.TryParse(Console.ReadLine(), out gRating))
            {
                Console.Clear();
                Console.WriteLine("Enter Group rating: ");
            }
            Console.Clear();

            Console.WriteLine("Enter Group created time : ");
            DateTime gCreatedDate = new DateTime();
            while (!DateTime.TryParse(Console.ReadLine(), out gCreatedDate))
            {
                Console.Clear();
                Console.WriteLine("Enter Group created time :");
            }
            Console.Clear();

            var newGroup = new Group
            {
                   Name = gName,
                   MemberCount = gMemCount,
                   CreatedDate = gCreatedDate,
                   Rating = gRating
            };


            var newMusic = new Song
            {
                Name = name,
                Text = text,
                Duration = duration,
                Rating = rating,
                Group = newGroup,
                GroupId = newGroup.Id
            };
        
                context.Songs.Add(newMusic);
                context.Groups.Add(newGroup);
                context.SaveChanges();
            
        }

        public string GetMostRatedSong(MusicContext context)
        {
                var result = (from x in context.Songs
                              orderby x.Rating ascending
                              select x).FirstOrDefault().Name;

                return result;
        }
    }
}
