using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace Service
{
    public class AccommodationService : IAccommodationService
    {
        private readonly PetShopContext _context;

        public AccommodationService(PetShopContext context)
        {
            _context = context;
        }

        public async Task<Accommodation[]> GetAllAccommodations() =>
            await _context.Accommodations.AsNoTracking().OrderBy(x => x.Id).ToArrayAsync();

        public async Task<Accommodation[]> GetFreeAccommodations() =>
            await _context.Accommodations.AsNoTracking().OrderBy(x => x.Id)
            .Where(x => x.State == AccommodationStateEnum.Free).ToArrayAsync();

        public async Task<bool> IsAccommodationFree(int number) =>
            await _context.Accommodations
            .Where(x => x.Number == number)
            .AnyAsync(x => x.State == AccommodationStateEnum.Free);

        public async Task<bool> UpdateAccommodation(Accommodation accommodation)
        {
            _context.Accommodations.Update(accommodation);
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}