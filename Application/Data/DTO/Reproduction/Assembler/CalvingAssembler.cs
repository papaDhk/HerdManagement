using System.Collections.Generic;
using System.Linq;
using HerdManagement.Domain.Reproduction.Entities;

namespace Applicattion.Data.DTO.Reproduction.Assembler
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
                return null;
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
                return null;
            }
        }
        
        public static Calving ToCalvingUpdateDTOWithFullAnimal(this Calving calving)
        {
            if (calving != null)
            {
                return new Calving
                {
                    Id = calving.Id,
                    Date = calving.Date,
                    Commentary = calving.Commentary,
                    FemaleId = calving.FemaleId,
                    MaleId = calving.AnimalId,
                    Animal = calving.Animal.ToAnimalUpdateDTO(),
                    ReproductionId = calving.ReproductionId
                };
            }
            else
            {
                return null;
            }
        }
        
        public static Calving ToCalvingUpdateDTO(this Calving calving)
        {
            if (calving != null)
            {
                return new Calving
                {
                    Id = calving.Id,
                    Date = calving.Date,
                    Commentary = calving.Commentary,
                    FemaleId = calving.FemaleId,
                    MaleId = calving.AnimalId,
                    AnimalId = calving.AnimalId,
                    ReproductionId = calving.ReproductionId
                };
            }
            else
            {
                return null;
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
