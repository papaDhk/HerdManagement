using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HerdManagement.Domain.Reproduction.Enumerations
{
    public enum SexEnum
    {
        [Display(Name = "Male")]
        Male,

        [Display(Name = "Femelle")]
        Female
    }
}
