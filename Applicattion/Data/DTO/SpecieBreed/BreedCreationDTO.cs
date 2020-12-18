using HerdManagement.Domain.SpecieBreed.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Applicattion.Data.DTO.SpecieBreed
{
    public class BreedCreationDTO
    {
        public string Label { get; set; }

        public int SpecieId { get; set; }
    }
}
