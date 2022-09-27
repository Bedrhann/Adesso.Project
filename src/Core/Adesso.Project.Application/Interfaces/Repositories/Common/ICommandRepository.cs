using Adesso.Project.Domain.Entities.Common;

namespace Adesso.Project.Application.Interfaces.Repositories.Common
{
    public interface ICommandRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddMultipleAsync(List<T> datas);
        bool Remove(T model);
        bool RemoveMultiple(List<T> datas);
        Task<bool> RemoveByIdAsync(string id);
        bool Update(T model);
        Task SaveAsync();
    }
}
