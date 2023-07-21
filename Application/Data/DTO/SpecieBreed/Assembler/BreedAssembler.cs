using System.Collections.Generic;
using System.Linq;
using HerdManagement.Domain.SpecieBreed.Entities;

namespace Applicattion.Data.DTO.SpecieBreed.Assembler
{
    public static class BreedAssembler
    {
        public static Breed ToBreed(this BreedCreationDTO breedCreationDTO)
        {
            if (breedCreationDTO is null)
                return null;

            return new Breed
            {
                Label = breedCreationDTO.Label,
                Specie = new Specie { Id = breedCreationDTO.SpecieId },
            };
        }

        public static Breed ToBreed(this BreedUpdateDTO breedUpdateDTO, int breedId)
        {
            if (breedUpdateDTO is null)
                return null;

            return new Breed
            {
                Id = breedId,
                Label = breedUpdateDTO.Label,
                Specie = new Specie { Id = breedUpdateDTO.SpecieId },
            };
        }

        public static BreedDTO ToBreedDTO(this Breed breed)
        {
            if (breed is null)
                return null;

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
