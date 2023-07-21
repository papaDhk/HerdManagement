using System.Threading.Tasks;
using Applicattion.Data.DTO.Herd;
using Applicattion.Data.DTO.SpecieBreed;
using Applicattion.Data.Messages;
using HerdManagement.Domain.SpecieBreed.Entities;
using HerdEntity = HerdManagement.Domain.Herd.Entities.Herd;

namespace Applicattion.Services
{
    public interface ISpecieBreedService
    {
        Task<Response<HerdEntity>> CreateHerd(HerdCreationDTO herdCreationDTO);
        Task<Response<HerdEntity>> UpdateHerd(int HerdId, HerdUpdateDTO herdUpdateDTO);
        Task<Response<Breed>> CreateBreed(BreedCreationDTO breedCreationDTO);
        Task<Response<Breed>> UpdateBreed(int BreedId, BreedUpdateDTO breedUpdateDTO);
    }
}
