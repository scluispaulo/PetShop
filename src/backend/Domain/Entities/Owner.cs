using System.Collections.Generic;

namespace Domain.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<Pet> Pets { get; set; }
    }
}