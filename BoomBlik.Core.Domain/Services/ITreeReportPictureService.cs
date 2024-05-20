using BoomBlik.Core.Domain.Dtos;

public interface ITreeReportPictureService
{
    Task<TreeReportPictureDto> GetTreeReportPictureByIdAsync(Guid treeReportPictureId);
    Task<IEnumerable<TreeReportPictureDto>> GetAllTreeReportPicturesAsync();
    Task<TreeReportPictureDto> CreateTreeReportPictureAsync(TreeReportPictureDto treeReportPictureDto);
    Task<TreeReportPictureDto> UpdateTreeReportPictureAsync(TreeReportPictureDto treeReportPictureDto);
    Task DeleteTreeReportPictureAsync(Guid treeReportPictureId);
}