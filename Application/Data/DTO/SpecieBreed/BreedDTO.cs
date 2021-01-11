using HerdManagement.Domain.SpecieBreed.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Data.DTO.SpecieBreed
{
    public class BreedDTO
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Espece d'appartenance")]
        [Required(ErrorMessage = "Field should not be empty")]
        public string Label { get; set; }

        public SpecieDTO Specie { get; set; }
    }
}
