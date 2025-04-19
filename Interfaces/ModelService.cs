using WebApi_Project.Models.ClassModels;

namespace WebApi_Project.Interfaces
{
    public interface ModelService<T>
    {
        Task<IEnumerable<T>> GetAllItemsAsync();
        Task<T> GetItemByIdAsync(int id);
        Task<T> CreateItemAsync(T Item);
        Task UpdateItemAsync(T Item);
        Task DeleteItemAsync(int id);
    }
}
