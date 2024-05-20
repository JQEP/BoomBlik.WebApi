using BoomBlik.Core.Domain.Dtos;

public interface ITreeService
{
    Task<TreeDto> GetTreeByIdAsync(Guid treeId);
    Task<IEnumerable<TreeDto>> GetAllTreesAsync();
    Task<TreeDto> CreateTreeAsync(TreeDto treeDto);
    Task<TreeDto> UpdateTreeAsync(TreeDto treeDto);
    Task DeleteTreeAsync(Guid treeId);
}