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
    public static class WeighingAssembler
    {
        public static Weighing ToWeighingUpdateDTO(this Weighing weighing)
        {
            if (weighing != null)
            {
                return new Weighing
                {
                    Id = weighing.Id,
                    Value = weighing.Value,
                    MeasurementUnitId = weighing.MeasurementUnitId,
                    AnimalId = weighing.AnimalId,
                    DateTime = weighing.DateTime
                };
            }

            return null;
        }
    }
}
