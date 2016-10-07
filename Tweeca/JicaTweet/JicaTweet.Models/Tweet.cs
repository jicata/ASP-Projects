namespace JicaTweet.Models
{
    using System;

    public class Tweet
    {
        public Tweet()
        {
            
        }
        public Tweet(string author, string content)
        {
            this.Author = author;
            this.Content = content;
            this.DateOfCreation = DateTime.Now;
        }
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
