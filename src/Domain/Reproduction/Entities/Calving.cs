using HerdManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HerdManagement.Domain.Reproduction.Entities
{
    [Table("Calvings")]
    public class Calving : Entity<Calving>
    {
        public Calving()
        {

        }

        public DateTime Date { get;  set; }
        public Reproduction Reproduction { get;  set; }
        public uint NumberOfNewborn { get;  set; }
        public string Commentary { get;  set; }
        public int ReproductionId { get; set; }

        public List<YoungAnimal> YoungAnimals { get; set; }

        /// <summary>
        /// Expresses equality of two Calving objects.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        protected override bool EqualsCore(Calving obj)
        {
            return Date == obj.Date
                   && Reproduction == obj.Reproduction
                   && NumberOfNewborn == obj.NumberOfNewborn;
        }

        /// <summary>
        /// Gets the object's hash code.
        /// </summary>
        /// <returns></returns>
        protected override int GetHashCodeCore()
        {
            return Date.GetHashCode() ^ Reproduction.GetHashCode() ^ (int)NumberOfNewborn;
        }
    }
}
