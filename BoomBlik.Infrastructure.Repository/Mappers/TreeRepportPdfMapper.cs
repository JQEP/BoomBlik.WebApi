using AutoMapper;
using BoomBlik.Core.Domain.Dtos;
using BoomBlik.Core.Infrastructure.Entities;

namespace BoomBlik.Infrastructure.Repository.Mappers;

public class TreeReportPdfMapper : Profile
{
    public TreeReportPdfMapper()
    {
        CreateMap<TreeReportPdfDto, TreeReportPdfEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TreeReportId, opt => opt.MapFrom(src => src.TreeReportId))
            .ForMember(dest => dest.PdfUrl, opt => opt.MapFrom(src => src.PdfUrl))
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
            .ForMember(dest => dest.ModifiedOn, opt => opt.MapFrom(src => src.ModifiedOn))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));

        CreateMap<TreeReportPdfEntity, TreeReportPdfDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.TreeReportId, opt => opt.MapFrom(src => src.TreeReportId))
            .ForMember(dest => dest.PdfUrl, opt => opt.MapFrom(src => src.PdfUrl))
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
            .ForMember(dest => dest.ModifiedOn, opt => opt.MapFrom(src => src.ModifiedOn))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
    }
}