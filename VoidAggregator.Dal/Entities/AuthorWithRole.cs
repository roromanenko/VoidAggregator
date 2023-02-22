using VoidAggregator.Dal.Entities.Enums;

namespace VoidAggregator.Dal.Entities
{
    public class AuthorWithRole
    {
        public int Id { get; set; }
        public AuthorRole AuthorRole { get; set; }
    }
}