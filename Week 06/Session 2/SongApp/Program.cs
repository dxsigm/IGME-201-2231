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
        }
    }
}
