using System.Collections.Generic;
using HerdManagement.Domain.Reproduction.Entities;

namespace Applicattion.Data.DTO.Reproduction.Assembler
{
    public static class ReproductionAssembler
    {
        public static HerdManagement.Domain.Reproduction.Entities.Reproduction ToReproductionUpdateDTO(
            this HerdManagement.Domain.Reproduction.Entities.Reproduction reproduction)
        {
            if (reproduction is null)
                return null;

            return new HerdManagement.Domain.Reproduction.Entities.Reproduction
            {
                Id = reproduction.Id,
                Female = null,
                FemaleId = reproduction.FemaleId,
                Male = null,
                MaleId = reproduction.MaleId,
                Date = reproduction.Date,
                Type = reproduction.Type,
                States = reproduction.States,
                Commentary = reproduction.Commentary,
                Calvings = new List<Calving>()
            };
        }
    }
}