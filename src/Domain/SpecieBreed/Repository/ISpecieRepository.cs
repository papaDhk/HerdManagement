using HerdManagement.Domain.SpecieBreed.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HerdManagement.Domain.SpecieBreed.Repository
{
    public interface ISpecieRepository
    {
        Task<Specie> GetSpecieById(int id);
        Task<Specie> GetSpecieByLabel(string label);
        Task<IEnumerable<Specie>> GetAllSpecies();
        Task<int> UpdateSpecie(Specie specie);
        Task<int> DeleteSpecie(int specieId);
        Task<Specie> CreateSpecie(Specie specie);
    }
}
