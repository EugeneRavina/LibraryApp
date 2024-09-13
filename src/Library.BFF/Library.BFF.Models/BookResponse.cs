﻿namespace Library.BFF.Models
{
    public class BookResponse
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Isbn { get; set; }
        public string PublishedDate { get; set; }
    }
}