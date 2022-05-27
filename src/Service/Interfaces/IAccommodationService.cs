using System.Threading.Tasks;
using Domain.Entities;

namespace Service.Interfaces
{
    public interface IAccommodationService
    {
        Task<Accommodation[]> GetAllAccommodations();
        Task<Accommodation[]> GetFreeAccommodations();
        Task<bool> UpdateAccommodation(Accommodation accommodation);
        Task<bool> IsAccommodationFree(int id);
    }
}