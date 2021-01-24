using Application.Data.DTO.Herd.Assembler;
using Application.Data.DTO.SpecieBreed.Assembler;
using HerdManagement.Domain.Herd.Entities;
using HerdManagement.Domain.SpecieBreed.Entities;
using HerdManagement.Domain.SpecieBreed.Repository;
using HerdManagement.Domain.SpecieBreed.Service;
using System;
using System.Threading.Tasks;
using Application.Data.DTO.Herd;
using Application.Data.DTO.SpecieBreed;
using Application.Data.Messages;

namespace Application.Services
{
    public class SpecieBreedService : ISpecieBreedService
    {
        private ISpecieRepository _specieRepository;

        private IBreedRepository _breedRepository;

        private IHerdRepository _herdRepository;

        public SpecieBreedService(ISpecieRepository specieRepository, IBreedRepository breedRepository,
            IHerdRepository herdRepository)
        {
            _specieRepository = specieRepository ?? throw new ArgumentNullException(nameof(specieRepository));
            _breedRepository = breedRepository ?? throw new ArgumentNullException(nameof(breedRepository));
            _herdRepository = herdRepository ?? throw new ArgumentNullException(nameof(herdRepository));
        }

        public async Task<Response<Breed>> CreateBreed(BreedCreationDTO breedCreationDTO)
        {
            Response<Breed> response = new Response<Breed> {IsOperationSuccessfull = false};
            if (breedCreationDTO == null)
            {
                return response;
            }

            Specie relatedSpecie = await _specieRepository.GetSpecieById(breedCreationDTO.SpecieId);

            if (relatedSpecie.Id > 0)
            {
                Breed createdBreed = await _breedRepository.CreateBreed(breedCreationDTO.ToBreed());
                if (createdBreed.Id > 0)
                {
                    createdBreed = await _breedRepository.GetBreedById(createdBreed.Id);
                    return response.ToSuccessfull(createdBreed);
                }
            }

            return response;
        }

        public async Task<Response<Herd>> CreateHerd(HerdCreationDTO herdCreationDTO)
        {
            Response<Herd> response = new Response<Herd> {IsOperationSuccessfull = false};
            if (herdCreationDTO == null)
            {
                return response;
            }

            Herd createdHerd = await _herdRepository.CreateHerd(herdCreationDTO.ToHerd());
            
            return createdHerd.Id > 0 ? response.ToSuccessfull(createdHerd) : response;
        }

        public async Task<Response<Breed>> UpdateBreed(int id, BreedUpdateDTO breedUpdateDTO)
        {
            Response<Breed> response = new Response<Breed> {IsOperationSuccessfull = false};
            if (breedUpdateDTO == null)
            {
                return response;
            }

            Breed breedToUpdate = await _breedRepository.GetBreedById(id);
            bool doesBreedExist = breedToUpdate.Id == id;

            if (doesBreedExist)
            {
                int numberOfAffectedRows = await _breedRepository.UpdateBreed(breedUpdateDTO.ToBreed(id));
                if (numberOfAffectedRows > 0)
                {
                    Breed updatedBreed = await _breedRepository.GetBreedById(id);
                    return response.ToSuccessfull(updatedBreed);
                }

                return response;
            }

            return response;
        }

        public async Task<Response<Herd>> UpdateHerd(int id, HerdUpdateDTO herdUpdateDTO)
        {
            Response<Herd> response = new Response<Herd> {IsOperationSuccessfull = false};
            if (herdUpdateDTO == null)
            {
                return response;
            }

            Herd herdToUpdate = await _herdRepository.GetHerdById(id);
            bool doesHerdExist = herdToUpdate.Id == id;

            if (doesHerdExist)
            {
                Specie relatedSpecie = await _specieRepository.GetSpecieById(herdUpdateDTO.SpecieId);

                if (relatedSpecie.Id > 0)
                {
                    int numberOfAffectedRows = await _herdRepository.UpdateHerd(herdUpdateDTO.ToHerd(id));
                    if (numberOfAffectedRows > 0)
                    {
                        Herd updatedHerd = await _herdRepository.GetHerdById(id);
                        return response.ToSuccessfull(updatedHerd);
                    }

                    return response;
                }
            }

            return response;
        }
    }
}