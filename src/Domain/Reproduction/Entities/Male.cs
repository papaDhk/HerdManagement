using HerdManagement.Domain.Reproduction.Enumerations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HerdManagement.Domain.Reproduction.Entities
{
    [Table("males")]
    public class Male : AdultAnimal
    {
        public Male()
        {

        }

        /// <summary>
        /// Animal's sex
        /// </summary>
        public override SexEnum Sex => SexEnum.Male;

        /// <summary>
        /// Indicates that the specified male has mated the given female.
        /// </summary>
        /// <param name="female">The female.</param>
        /// <param name="date">The date.</param>
        /// <param name="type">The type.</param>
        /// <param name="status">The status.</param>
        /// <param name="commentary">The commentary.</param>
        /// <returns>A Reproduction object with initial state</returns>
        public Reproduction HasMated(Female female, DateTime date,
                                              ReproductionTypeEnum type, ReproductionStateEnum status,
                                              string commentary)
        {   
            return Reproduction.Initialize(female, this, date, type, status, commentary);
        }
    }
}
