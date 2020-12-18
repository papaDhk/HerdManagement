using HerdManagement.Domain.SpecieBreed.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HerdManagement.Domain.SpecieBreed.Repository
{
    public interface IBreedRepository
    {
        Task<Breed> GetBreedById(int id);
        Task<IEnumerable<Breed>> GetBreedByLabel(string laebl);
        Task<IEnumerable<Breed>> GetBreedsBySpecie(int SpecieId);
        Task<IEnumerable<Breed>> GetAllBreeds();
        Task<int> UpdateBreed(Breed Breed);
        Task<int> DeleteBreed(int BreedId);
        Task<Breed> CreateBreed(Breed Breed);
    }
}