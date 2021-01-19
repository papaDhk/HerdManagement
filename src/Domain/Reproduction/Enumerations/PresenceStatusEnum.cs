using System.ComponentModel.DataAnnotations;

namespace HerdManagement.Domain.Reproduction.Enumerations
{
    public enum PresenceStatusEnum
    {
        [Display(Name="En vie")]
        Alive = 0,

        [Display(Name = "Mort naturelle")]
        NaturalDeath,

        [Display(Name = "Tué")]
        Killed,

        [Display(Name = "Vendu")]
        Sold
    }
}
