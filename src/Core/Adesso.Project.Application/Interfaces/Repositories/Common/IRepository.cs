using Adesso.Project.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Adesso.Project.Application.Interfaces.Repositories.Common
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
