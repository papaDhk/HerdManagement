using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Applicattion.Data.DTO.Herd
{
    public class HerdCreationDTO
    {
        [Required(ErrorMessage ="Le nom est obligatoire pour creer un troupeau")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Selectionnez une espece SVP")]
        public int SpecieId { get; set; }
    }
}
