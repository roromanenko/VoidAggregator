namespace VoidAggregator.Bl.Dtos
{
    public class LabelDto : UserDto
    {
        public List<AuthorDto> Authors { get; set; } = new List<AuthorDto>();
    }
}
