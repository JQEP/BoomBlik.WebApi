using AutoMapper;
using BoomBlik.Core.Domain.Dtos;
using BoomBlik.Core.Infrastructure.Entities;

namespace BoomBlik.Infrastructure.Repository.Mappers;

public class TreeReportPictureMapper : Profile
{
    public TreeReportPictureMapper()
    {
        CreateMap<TreeReportPictureDto, TreeReportPictureEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TreeReportId, opt => opt.MapFrom(src => src.TreeReportId))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
            .ForMember(dest => dest.ModifiedOn, opt => opt.MapFrom(src => src.ModifiedOn))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));

        CreateMap<TreeReportPictureEntity, TreeReportPictureDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TreeReportId, opt => opt.MapFrom(src => src.TreeReportId))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
            .ForMember(dest => dest.ModifiedOn, opt => opt.MapFrom(src => src.ModifiedOn))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
    }
}