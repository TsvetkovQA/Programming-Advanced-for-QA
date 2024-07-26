using System;
using System.Collections.Generic;
using System.Linq;


public class Song
{
    public string TypeList { get; set; }
    public string Name { get; set; }
    public string Time { get; set; }

    public Song(string typeList, string name, string time)
    {
        TypeList = typeList;
        Name = name;
        Time = time;
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        
        int numberOfSongs = int.Parse(Console.ReadLine());
        List<Song> songs = new List<Song>();

        for (int i = 0; i < numberOfSongs; i++)
        {
            string[] songData = Console.ReadLine().Split('_');
            string typeList = songData[0];
            string name = songData[1];
            string time = songData[2];

            Song song = new Song(typeList, name, time);
            songs.Add(song);
        }

        string filterTypeList = Console.ReadLine();

        if (filterTypeList == "all")
        {
            foreach (Song song in songs)
            {
                Console.WriteLine(song.Name);
            }
        }
        else
        {
            foreach (Song song in songs)
            {
                if (song.TypeList == filterTypeList)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
}
