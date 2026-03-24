namespace VirtualPetAdoption.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int EnergyLevel { get; set; } // 1-5 scale
    }
}