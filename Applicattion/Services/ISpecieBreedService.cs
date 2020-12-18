using HerdManagement.Domain.SpecieBreed.Entities;
using HerdEntity = HerdManagement.Domain.Herd.Entities.Herd;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Applicattion.Data.DTO.Herd;
using Applicattion.Data.DTO.SpecieBreed;
using Applicattion.Data.Messages;

namespace HerdManagement.Domain.SpecieBreed.Service
{
    public interface ISpecieBreedService
    {
        Task<Response<HerdEntity>> CreateHerd(HerdCreationDTO herdCreationDTO);
        Task<Response<HerdEntity>> UpdateHerd(int HerdId, HerdUpdateDTO herdUpdateDTO);
        Task<Response<Breed>> CreateBreed(BreedCreationDTO breedCreationDTO);
        Task<Response<Breed>> UpdateBreed(int BreedId, BreedUpdateDTO breedUpdateDTO);
    }
}
