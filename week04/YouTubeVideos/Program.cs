using System;

class Program
{
    static void Main(string[] args)
    {
       Video video1 = new Video("Programming skills in a nutshell", "Ada Chukwu", 300);
       Video video2 = new Video("Introductory Programming", "Musa Taiwo", 600);
       Video video3 = new Video("Basic C# Programming","Ayomide Bello", 450);

       video1.AddComment(new Comment("John", "This is an amazing tutorial!"));
       video1.AddComment(new Comment("Chinwe", "Very well explained."));
       video1.AddComment(new Comment("Alex", "I learned a lot. Thanks!"));


       video2.AddComment(new Comment("Chris", "The examples were very helpful."));
       video2.AddComment(new Comment("Irene", "Clear and concise!"));
       video2.AddComment(new Comment("Chidi", "I love this channel."));

       video3.AddComment(new Comment("Mira", "Very detailed explanation."));
       video3.AddComment(new Comment("Emeka", "Keep up the good work!"));
       video3.AddComment(new Comment("Ajoke", "Great content as always."));

       List<Video> videos = new List<Video> { video1, video2, video3 };

       foreach (Video video in videos)
       {
        Console.WriteLine($"Title: {video._title}");
        Console.WriteLine($"Author: {video._author}");
        Console.WriteLine($"Length: {video._length} seconds");
        Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
        Console.WriteLine("Comments:");

        foreach (Comment comment in video.GetComment())
        {
            Console.WriteLine($"- {comment.Display()}");
        }

        Console.WriteLine();


       }
       

    }
}