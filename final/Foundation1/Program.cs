using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();
        Video video1 = new Video("Silly Cat Compilation", "Catlover52", 643);
        video1.AddComment(new Comment("Angelo67", "Soooo Cute!!!!!!"));
        video1.AddComment(new Comment("Barbara2.0", "Absolutely Adorable!!"));
        video1.AddComment(new Comment("CastielFan<3", "That orange cat is super dumb! <3"));
        videos.Add(video1);
        Video video2 = new Video("Lofi Beats for Gamers", "GamerGeek42", 8500);
        video2.AddComment(new Comment("LOZChamp", "Sweet tunes!"));
        video2.AddComment(new Comment("I_is_Batmen", "Totally relaxing!"));
        video2.AddComment(new Comment("AquaticOwl", "I was able to finish all my homework thanks to this!"));
        videos.Add(video2);
        Video video3 = new Video("99% of Adults Can't Beat Riddle Challenge #37", "OfficialDailyRiddles", 720);
        video3.AddComment(new Comment("AquaticOwl", "It was the butler!"));
        video3.AddComment(new Comment("Angelo67", "I can't figure out puzzle #5"));
        video3.AddComment(new Comment("ADay4Destiny", "There's no way they could hold their breath that long, so the premise is impossible."));
        videos.Add(video3);
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Lenght: {video.GetLength()}");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments: ");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }
            Console.WriteLine(new string('-', 50));
        }
    }
}