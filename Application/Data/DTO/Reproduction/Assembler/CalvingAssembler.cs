using Application.Data.DTO.SpecieBreed.Assembler;
using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.SpecieBreed.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.DTO.Reproduction.Assembler
{
    public static class CalvingAssembler
    {
        public static Calving ToCalving(this CalvingDTO calvingDTO)
        {
            if (calvingDTO != null)
            {
                return new Calving
                {
                    Id = calvingDTO.Id,
                    Date = calvingDTO.DateTime,
                    Commentary = calvingDTO.Commentary,
                    FemaleId = calvingDTO.FemaleId,
                    MaleId = calvingDTO.MaleId,
                    AnimalId = calvingDTO.NewBornId,
                    Animal = new Animal
                    {
                        Id = calvingDTO.NewBornId,
                        Number = calvingDTO.NewBornNumber,
                        Name = calvingDTO.NewBornName,
                        BirthDate = calvingDTO.DateTime,
                        BreedId = calvingDTO.BreedId,
                        Sex = calvingDTO.Sex,
                        HerdId = calvingDTO.HerdId,
                        Origin = AnimalOrigin.BornInFarm,
                        Weight = (uint)calvingDTO.BirthWeight                      
                    },
                    ReproductionId =calvingDTO.ReproductionId
                };
            }
            else
            {
                return new Calving();
            }
        }

        public static CalvingDTO ToCalvingDTO(this Calving calving)
        {
            if (calving != null)
            {
                return new CalvingDTO
                {
                    Id = calving.Id,
                    DateTime = calving.Date,
                    Commentary = calving.Commentary,
                    FemaleId = calving.FemaleId,
                    MaleId = calving.AnimalId,
                    NewBornNumber = calving.Animal.Number,
                    NewBornId = calving.Animal.Id,
                    BirthWeight = (int)calving.Animal.Weight,
                    NewBornName = calving.Animal.Name,
                    BreedId = calving.Animal.BreedId,
                    Sex =calving.Animal.Sex,
                    HerdId = calving.Animal.HerdId,
                    PresenceStatus = calving.Animal.PresenceStatus,
                    ReproductionId = calving.ReproductionId
                };
            }
            else
            {
                return new CalvingDTO();
            }
        }

        public static List<CalvingDTO> ToCalvingDTOList(this IEnumerable<Calving> calvings)
        {
            return calvings != null && calvings.Any() ?
                   calvings.Select(calving => calving.ToCalvingDTO()).ToList() :
                   new List<CalvingDTO>();

        }
    }
}
