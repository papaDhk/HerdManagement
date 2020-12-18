using HerdManagement.Domain.Reproduction.Enumerations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HerdManagement.Domain.Reproduction.Entities
{
    [Table("YoungMales")]
    public class YoungMale : Animal
    {
        
        public YoungMale()
        {

        }

        /// <summary>
        /// Gets the sex.
        /// </summary>
        /// <value>
        /// The sex.
        /// </value>
        public override SexEnum Sex => SexEnum.Male;
    }
}
