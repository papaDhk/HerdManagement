using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Data.DTO.Herd
{
    public class HerdUpdateDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public int SpecieId { get; set; }
    }
}
