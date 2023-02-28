using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoidAggregator.Dal.Entities;

namespace VoidAggregator.Bl.Dtos
{
    public class AuthorDto : UserDto
    {
        public List<AuthorSongDto> AuthorsSongs { get; set; } = new List<AuthorSongDto>();
        public List<Release> Releases { get; set; }
        public LabelDto Label { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
