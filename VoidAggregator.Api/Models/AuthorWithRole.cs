using VoidAggregator.Api.Models.Enums;

namespace VoidAggregator.Api.Models
{
    public class AuthorWithRole
    {
        public int Id { get; set; }
        public AuthorRole AuthorRole { get; set; }
    }
}