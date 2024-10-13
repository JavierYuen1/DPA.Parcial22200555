using DPA.Parcial.DOMAIN.Core.Entities;

namespace DPA.Parcial.DOMAIN.Infrastructure.Repositories
{
    public interface IMechanicRepository
    {
        Task<bool> Delete(int id);
        Task GetMechanic();
        Task<Mechanic> GetMechanicById(int id);
        Task<IEnumerable<Mechanic>> GetMechanies();
        Task<int> Insert(Mechanic mechanic);
        Task<bool> Update(Mechanic mechanic);
    }
}