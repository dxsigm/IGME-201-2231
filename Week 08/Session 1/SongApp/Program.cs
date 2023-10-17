using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongLib;

namespace SongApp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Song song;
            VinylSong song2 = new VinylSong();
            song2.Play();
            song2.Sing();
            song2.Dance();

            List<Song> songs = new List<Song>();

            // this will use the CompareTo() method of the class to sort them
            songs.Sort();

            // we can specifically sort by other field by using the OrderBy() method

            // pass a method that returns the field to sort by
            songs = songs.OrderBy(OrderByName).ToList();

            // use delegates and lambda expressions
            songs = songs.OrderBy(delegate (Song song1) { return song1.Name; }).ToList();
            songs = songs.OrderBy((Song song1) => { return song1.Name; }).ToList();
            songs = songs.OrderBy((song1) => { return song1.Name; }).ToList();
            songs = songs.OrderBy((song1) => song1.Name).ToList();
            songs = songs.OrderBy(song1 => song1.Name).ToList();
        }

        static string OrderByName(Song song)
        {
            return song.Name;
        }
    }
}
