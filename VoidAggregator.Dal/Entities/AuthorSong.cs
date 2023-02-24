﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoidAggregator.Dal.Entities.Enums;
using VoidAggregator.Dal.Entities.Users;

namespace VoidAggregator.Dal.Entities
{
	public class AuthorSong
	{
		public string AuthorId { get; set; }
		public Author Author { get; set; }
		public int SongId { get; set; }
		public Song Song { get; set; }
		public AuthorRole AuthorRole { get; set; }
	}
}