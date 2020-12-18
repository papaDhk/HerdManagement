using HerdManagement.Domain.Reproduction.Enumerations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HerdManagement.Domain.Reproduction.Entities
{
    [Table("YoungFemales")]
    public class YoungFemale : Animal
    {
        public YoungFemale()
        {

        }
        /// <summary>
        /// Gets the sex.
        /// </summary>
        /// <value>
        /// The sex.
        /// </value>
        public override SexEnum Sex => SexEnum.Female;      
    }
}
