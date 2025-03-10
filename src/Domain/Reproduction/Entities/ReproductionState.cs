﻿using HerdManagement.Domain.Common;
using HerdManagement.Domain.Reproduction.Enumerations;
using System;

namespace HerdManagement.Domain.Reproduction.Entities
{
    public class ReproductionState : Entity<ReproductionState>, IComparable
    {
        public static ReproductionState Undefined => new ReproductionState { State = ReproductionStateEnum.Undefined };

        public ReproductionState()
        {

        }

        public int ReproductionId { get; set; }

        public ReproductionStateEnum State { get; set; }

        public DateTime Date { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReproductionState"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="date">The date.</param>
        public ReproductionState(ReproductionStateEnum state, DateTime date)
        {
            State = state;
            Date = date;
        }

        /// <summary>
        /// Expresses equality of two ReproductionState objects.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>true if the two objects are equal</returns>
        protected override bool EqualsCore(ReproductionState obj)
        {
            return State == obj.State && Date == obj.Date;
        }

        /// <summary>
        /// Gets the object's hash code
        /// </summary>
        /// <returns></returns>
        protected override int GetHashCodeCore()
        {
            return (int)State ^ Date.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if(obj == null) return 1;

            ReproductionState otherReproductionState = obj as ReproductionState;
            if (otherReproductionState != null)
                return this.State.CompareTo(otherReproductionState.State);
            else
                throw new ArgumentException("Object is not a ReproductionState");
        }

        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator <(ReproductionState a, ReproductionState b) => a.Date < b.Date && a.State < b.State;

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator >(ReproductionState a, ReproductionState b) => a.Date > b.Date && a.State > b.State;


    }
}
