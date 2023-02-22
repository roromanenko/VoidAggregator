﻿using VoidAggregator.Dal.Entities.Enums;

namespace VoidAggregator.Dal.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string SongName { get; set; }
        public List<AuthorWithRole> Authors { get; set; } = new List<AuthorWithRole>();
        public Language Language { get; set; }
        public string SongText { get; set; }
        public bool IsExplicitContent { get; set; }
        public string SongContentPath { get; set; }
    }
}