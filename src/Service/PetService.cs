using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace Service
{
    public class PetService : IPetService
    {
        private readonly PetShopContext _context;

        public PetService(PetShopContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePet(Pet pet)
        {
            UpdateAccommodationStatus(pet.AccommodationId, AccommodationStateEnum.Busy);

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            
            return pet.Id;
        }

        public void UpdateAccommodationStatus(int number, AccommodationStateEnum accommodationState)
        {
            Accommodation accommodation = _context.Accommodations.AsNoTracking().Where(x => x.Number == number).FirstOrDefault();
            accommodation.State = accommodationState;
            _context.Accommodations.Update(accommodation);
            _context.SaveChanges();
        }

        public async Task<Pet> GetPetById(int id, bool inclueOwner)
        {
            IQueryable<Pet> query = _context.Pets.AsNoTracking().Where(x => x.Id == id);

            if (inclueOwner)
            {
                query = query.Include(x => x.Owner);
                query = query.Include(x => x.Accommodation);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pet[]> GetPetsByName(string name, bool inclueOwner)
        {
            IQueryable<Pet> query = _context.Pets.AsNoTracking()
                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .OrderBy(x => x.Id);

            if (inclueOwner)
            {
                query = query.Include(x => x.Owner);
            }

            return await query.ToArrayAsync();
        }

        public async Task<bool> UpdatePet(Pet newPet, int oldAccommodationNumber = 0)
        {
            if (oldAccommodationNumber != 0)
            {
                UpdateAccommodationStatus(oldAccommodationNumber, AccommodationStateEnum.Free);
            }

            _context.Pets.Update(newPet);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> DeletePet(Pet pet)
        {
            UpdateAccommodationStatus(pet.AccommodationId, AccommodationStateEnum.Free);

            _context.Pets.Remove(pet);
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}