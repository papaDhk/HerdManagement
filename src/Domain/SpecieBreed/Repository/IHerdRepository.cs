using HerdManagement.Domain.Herd.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HerdEntity = HerdManagement.Domain.Herd.Entities.Herd;

namespace HerdManagement.Domain.SpecieBreed.Repository
{
    public interface IHerdRepository
    {
        Task<HerdEntity> GetHerdById(int id);
        Task<IEnumerable<HerdEntity>> GetHerdByName(string name);
        Task<IEnumerable<HerdEntity>> GetAllHerds();
        Task<int> UpdateHerd(HerdEntity herd);
        Task<int> DeleteHerd(int herdId);
        Task<HerdEntity> CreateHerd(HerdEntity herd);
    }
}
