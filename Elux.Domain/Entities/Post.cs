﻿namespace Elux.Domain.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public DateTime ReliseData { get; set; }
    }
}
