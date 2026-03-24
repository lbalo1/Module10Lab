using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.Models;

namespace VirtualPetAdoption.Data
{
    //Databse context class 
    public class PetAdoptionContext : DbContext
    {
        //Constuctor for the database context
        public PetAdoptionContext(DbContextOptions<PetAdoptionContext> options)
            : base(options)
        {  
        }

        // Attributes for the class 
        public DbSet<Pet> Pets { get; set; }

        //Methods for the class 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // Create a data model with a group of pets
            modelBuilder.Entity<Pet>(). HasData(
                new Pet
                {
                    Id = 1,
                    Name = "Fluffy",
                    Species = "Cat",
                    Description = "A calm and relaxed cat who enjoys naps.",
                    ImageUrl = "/images/cat.png",
                    EnergyLevel = 2
                },
                new Pet
                {
                    Id = 2,
                    Name = "Rex",
                    Species = "Dog",
                    Description = "A high-energy dog who loves to play fetch.",
                    ImageUrl = "/images/dog.png",
                    EnergyLevel = 5
                },
                new Pet
                {
                    Id = 3,
                    Name = "Nibbles",
                    Species = "Rabbit",
                    Description = "A friendly rabbit with moderate energy.",
                    ImageUrl = "/images/rabbit.png",
                    EnergyLevel = 3
                }

            );
        }
    }
}
