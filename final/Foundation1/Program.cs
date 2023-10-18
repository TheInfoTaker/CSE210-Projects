using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    public void AddComment(string commenterName, string commentText)
    {
        Comments.Add(new Comment(commenterName, commentText));
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length (in seconds): {LengthInSeconds}");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");

        Console.WriteLine($"Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"Commenter: {comment.CommenterName}");
            Console.WriteLine($"Comment Text: {comment.CommentText}");
        }

        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Going to paris!", "Jammie and Sam", 300);
        Video video2 = new Video("Animal Crossing Vacation!", "Mimi's Corner", 240);
        Video video3 = new Video("First Time Baking Challenge!", "First Time Feast", 420);

        video1.AddComment("Mike", "Amazing video!");
        video1.AddComment("SniperMuncher275", "I don't like you");
        video2.AddComment("Kylee", "I love you!");
        video2.AddComment("Spippy2847", "That's interesting");
        video3.AddComment("BabyTaco", "I've always wanted to try that!");
        video3.AddComment("JoeyJojoBizar", "I think that's over rated!");

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}