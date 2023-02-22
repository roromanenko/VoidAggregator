using VoidAggregator.Dal.Entities.Enums;

namespace VoidAggregator.Dal.Entities
{
    public class AuthorWithRole
    {
        public int AuthorId { get; set; }
        public AuthorRole AuthorRole { get; set; }
    }
}