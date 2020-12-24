﻿using System;
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
        public List<Reproduction> Reproductions { get; set; }

        public abstract bool CanBeParentOfAnimalBornIn(DateTime dateTime);
    }
}
