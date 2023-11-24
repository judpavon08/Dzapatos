using Domain.Endpoint.Entities;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
    }
}