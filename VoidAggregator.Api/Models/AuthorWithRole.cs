using VoidAggregator.Api.Models.Enums;

namespace VoidAggregator.Api.Models
{
    public class AuthorWithRole
    {
        public int AuthorId { get; set; }
        public AuthorRole AuthorRole { get; set; }
    }
}