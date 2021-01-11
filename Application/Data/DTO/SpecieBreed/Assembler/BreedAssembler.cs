using HerdManagement.Domain.SpecieBreed.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Data.DTO.SpecieBreed.Assembler
{
    public static class BreedAssembler
    {
        public static Breed ToBreed(this BreedCreationDTO breedCreationDTO)
        {
            return new Breed
            {
                Label = breedCreationDTO.Label,
                Specie = new Specie { Id = breedCreationDTO.SpecieId },
            };
        }

        public static Breed ToBreed(this BreedUpdateDTO breedUpdateDTO, int breedId)
        {
            return new Breed
            {
                Id = breedId,
                Label = breedUpdateDTO.Label,
                Specie = new Specie { Id = breedUpdateDTO.SpecieId },
            };
        }

        public static BreedDTO ToBreedDTO(this Breed breed)
        {
            return new BreedDTO
            {
                Id = breed.Id,
                Label = breed.Label,
                Specie = breed.Specie?.ToSpecieDTO(),
            };
        }

        public static Breed ToBreed(this BreedDTO breedDTO)
        {
            return new Breed
            {
                Id = breedDTO.Id,
                Label = breedDTO.Label,
                Specie = breedDTO.Specie?.ToSpecie(),
            };
        }

        public static IEnumerable<BreedDTO> ToBreedDTOList(this IEnumerable<Breed> breeds)
        {
            return breeds != null && breeds.Any() ? breeds.Select(breed => breed.ToBreedDTO()) : new List<BreedDTO>();
        }
    }
}
