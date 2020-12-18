using System;
using System.Collections.Generic;
using System.Text;

namespace HerdManagement.Domain.Reproduction.Entities
{
    public abstract class AdultAnimal : Animal
    {
        /// <summary>
        /// Gets the animal's reproductions
        /// </summary>
        /// <value>
        /// The reproductions.
        /// </value>
        public List<ValueObjects.Reproduction> reproductions { get; } = new List<ValueObjects.Reproduction>();
    }
}
