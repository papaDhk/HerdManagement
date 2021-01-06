using System.ComponentModel.DataAnnotations;

namespace HerdManagement.Domain.Reproduction.Enumerations
{
    public enum ReproductionTypeEnum
    {
        [Display(Name = "Non renseigné")]
        Undefined = 0,

        [Display(Name = "Reproduction naturelle")]
        Natural = 1,

        [Display(Name = "Insémination artificielle")]
        ArtificialInsemination = 2,
        Embryo = 3
    }
}