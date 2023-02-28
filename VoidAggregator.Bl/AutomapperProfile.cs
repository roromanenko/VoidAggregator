using AutoMapper;
using VoidAggregator.Bl.Dtos;
using VoidAggregator.Dal.Entities;
using VoidAggregator.Dal.Entities.Users;

namespace VoidAggregator.Bl
{
	public class AutomapperProfile : Profile
	{
		public AutomapperProfile()
		{
			CreateMap<ApplicationUser, UserDto>().ReverseMap();
			CreateMap<Label, LabelDto>().ReverseMap();
			CreateMap<Release, ReleaseDto>().ReverseMap();
			CreateMap<AuthorSong, AuthorSongDto>().ReverseMap();
			CreateMap<Author, AuthorDto>().ReverseMap();
			CreateMap<Song, SongDto>().ReverseMap();
		}
	}
}
