using System.Collections.Generic;
using System.Linq;
using HerdManagement.Domain.SpecieBreed.Entities;

namespace Applicattion.Data.DTO.SpecieBreed.Assembler
{
    public static class SpecieAssembler
    {
        public static SpecieDTO ToSpecieDTO(this Specie specie)
        {
            return specie != null ?
                    new SpecieDTO
                    {
                        Id = specie.Id,
                        Label = specie.Label,
                        ChildhoodDurationInDays = specie.ChildhoodDurationInDays,
                        PregnancyDurationInDays = specie.PregnancyDurationInDays,
                        MinimumTimeSpanBetweenCalvingAndHeatInDays = specie.MinimumTimeSpanBetweenCalvingAndHeatInDays
                    } :
                    null;
        }

        public static Specie ToSpecie(this SpecieDTO specieDTO)
        {
            return specieDTO != null ?
                    new Specie
                    {
                        Id = specieDTO.Id,
                        Label = specieDTO.Label,
                        ChildhoodDurationInDays = specieDTO.ChildhoodDurationInDays,
                        PregnancyDurationInDays = specieDTO.PregnancyDurationInDays,
                        MinimumTimeSpanBetweenCalvingAndHeatInDays = specieDTO.MinimumTimeSpanBetweenCalvingAndHeatInDays
                    } :
                    null;
        }

        public static Specie ToSpecie(this SpecieUpdateDTO specieUpdateDTO, int id)
        {
            return specieUpdateDTO != null ?
                    new Specie
                    {
                        Id = id,
                        Label = specieUpdateDTO.Label,
                        ChildhoodDurationInDays = specieUpdateDTO.ChildhoodDurationInDays,
                        PregnancyDurationInDays = specieUpdateDTO.PregnancyDurationInDays,
                        MinimumTimeSpanBetweenCalvingAndHeatInDays = specieUpdateDTO.MinimumTimeSpanBetweenCalvingAndHeatInDays
                    } :
                    null;
        }

        public static IEnumerable<SpecieDTO> ToSpecieDTOList(this IEnumerable<Specie> species)
        {
            return species != null && species.Any() ?
                   species.Select(specie => specie?.ToSpecieDTO()) :
                   new List<SpecieDTO>();

        }

        public static Specie ToSpecie(this SpecieCreationDTO specieCreationDTO)
        {
            return specieCreationDTO != null ?
                    new Specie
                    {
                        Label = specieCreationDTO.Label,
                        ChildhoodDurationInDays = specieCreationDTO.ChildhoodDurationInDays,
                        PregnancyDurationInDays = specieCreationDTO.PregnancyDurationInDays,
                        MinimumTimeSpanBetweenCalvingAndHeatInDays = specieCreationDTO.MinimumTimeSpanBetweenCalvingAndHeatInDays
                    } :
                    null;
        }
    }
}
