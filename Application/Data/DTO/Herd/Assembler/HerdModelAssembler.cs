using HerdEntity = HerdManagement.Domain.Herd.Entities.Herd;
using HerdManagement.Domain.SpecieBreed.Entities;
using System.Collections.Generic;
using System.Linq;
using Application.Data.DTO.SpecieBreed.Assembler;

namespace Application.Data.DTO.Herd.Assembler
{
    public static class HerdModelAssembler
    {
        public static HerdEntity ToHerd(this HerdCreationDTO herdCreationDTO)
        {
            if (herdCreationDTO is null)
            {
                return new HerdEntity();
            }

            return new HerdEntity
            {
                Name = herdCreationDTO.Name,
                SpecieId = herdCreationDTO.SpecieId,
                Color = herdCreationDTO.Color,
                Description = herdCreationDTO.Description
            };
        }
        
        public static HerdCreationDTO ToHerdCreationDto(this HerdEntity herdDTO)
        {
            if (herdDTO is null)
            {
                return new HerdCreationDTO();
            }

            return new HerdCreationDTO()
            {
                Name = herdDTO.Name,
                SpecieId = herdDTO.SpecieId,
                Color = herdDTO.Color,
                Description = herdDTO.Description
            };
        }

        public static HerdEntity ToHerd(this HerdUpdateDTO herdUpdateDTO, int herdId)
        {
            if (herdUpdateDTO is null)
            {
                return new HerdEntity();
            }

            return new HerdEntity
            {
                Id = herdId,
                Name = herdUpdateDTO.Name,
                SpecieId = herdUpdateDTO.SpecieId,
                Color = herdUpdateDTO.Color,
                Description = herdUpdateDTO.Description
            };
        }

        public static HerdEntity ToHerd(this HerdDTO herdDTO)
        {
            if (herdDTO is null)
            {
                return new HerdEntity();
            }

            return new HerdEntity
            {
                Id = herdDTO.Id,
                Name = herdDTO.Name,
                Specie = new Specie {Id = herdDTO.Specie?.Id ?? 0},
                Color = herdDTO.Color,
                Description = herdDTO.Description
            };
        }

        public static HerdDTO ToHerdDTO(this HerdEntity herd)
        {
            if (herd is null)
            {
                return new HerdDTO();
            }

            return new HerdDTO
            {
                Id = herd.Id,
                Name = herd.Name,
                Specie = herd.Specie?.ToSpecieDTO(),
                Color = herd.Color,
                Description = herd.Description
            };
        }

        public static IEnumerable<HerdDTO> ToHerdDTOList(this IEnumerable<HerdEntity> herds)
        {
            return herds != null && herds.Any() ? herds.Select(herd => herd.ToHerdDTO()) : new List<HerdDTO>();
        }
    }
}