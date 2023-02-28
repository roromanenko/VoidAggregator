using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoidAggregator.Dal.Entities.Users;

namespace VoidAggregator.Bl.Dtos
{
    public class LabelDto : UserDto
    {
        public List<AuthorDto> Authors { get; set; }
    }
}
