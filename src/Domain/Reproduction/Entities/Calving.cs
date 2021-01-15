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
        public string Commentary { get;  set; }
        public int ReproductionId { get; set; }
        public int MaleId { get; set; }
        public int FemaleId { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        /// <summary>
        /// Expresses equality of two Calving objects.
        /// </summary>
        /// <param name="obj">The object.</param>F
        /// <returns></returns>
        protected override bool EqualsCore(Calving obj)
        {
            return Date == obj.Date
                   && Reproduction == obj.Reproduction;
        }

        /// <summary>
        /// Gets the object's hash code.
        /// </summary>
        /// <returns></returns>
        protected override int GetHashCodeCore()
        {
            return Date.GetHashCode() ^ Reproduction.GetHashCode();
        }
    }
}
