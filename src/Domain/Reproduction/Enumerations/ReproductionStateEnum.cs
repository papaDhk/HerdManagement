using System.ComponentModel.DataAnnotations;

namespace HerdManagement.Domain.Reproduction.Enumerations
{
    public enum ReproductionStateEnum
    {
        [Display(Name="Non renseigné")]
        Undefined = 0,

        [Display(Name = "Initial")]
        Initial = 1,

        [Display(Name = "En gestation")]
        Gestating = 2,

        [Display(Name = "Avortée")]
        Aborted = 3,

        [Display(Name = "Complète")]
        Complete = 4,
    }
}