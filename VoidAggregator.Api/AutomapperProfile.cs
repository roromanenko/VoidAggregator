using AutoMapper;
using VoidAggregator.Bl.Dtos;
using VoidAggregator.Api.Models;

namespace VoidAggregator.Api
{
	public class AutomapperProfile : Profile
	{
		public AutomapperProfile()
		{
			CreateMap<User, UserDto>().ReverseMap();
			CreateMap<Label, LabelDto>().ReverseMap();
			CreateMap<Release, ReleaseDto>().ReverseMap();
			CreateMap<AuthorSong, AuthorSongDto>().ReverseMap();
			CreateMap<Author, AuthorDto>().ReverseMap();
			CreateMap<Song, SongDto>().ReverseMap();
		}
	}
}
