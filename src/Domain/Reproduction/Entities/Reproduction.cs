using HerdManagement.Domain.Common;
using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.Reproduction.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HerdManagement.Domain.Reproduction.ValueObjects
{
    [Table("Reproductions")]
    public class Reproduction : Entity<Reproduction>
    {
        public Reproduction()
        {

        }

        public static Reproduction None => new Reproduction(null, null, DateTime.MinValue,
                                                            ReproductionTypeEnum.Artificial,
                                                            ReproductionStateEnum.Initial);
        public Female Female { get; set; }
        public Male Male { get; set; }      
        public DateTime Date { get; protected set; }
        public ReproductionTypeEnum Type { get; protected set; }
        public IEnumerable<ReproductionState> States { get; } = new List<ReproductionState>();
        public string Commentary { get; protected set; }
        public ReproductionState ActualState => States.Max();

        /// <summary>
        /// Initializes a new instance of the <see cref="Reproduction"/> class.
        /// </summary>
        /// <param name="female">The female.</param>
        /// <param name="male">The male.</param>
        /// <param name="date">The date.</param>
        /// <param name="type">The type.</param>
        /// <param name="status">The status.</param>
        /// <param name="commentary">The commentary.</param>
        private Reproduction(Female female, Male male, DateTime date,
                            ReproductionTypeEnum type, ReproductionStateEnum status,
                            string commentary)
        {
            if(female != null && female.CanBeMated(date) && status == ReproductionStateEnum.Initial)
            {
                Female = female;
                Male = male;
                Date = date;
                Type = type;
                States.Append(new ReproductionState(status, date));
                Commentary = commentary;
            }
            else
            {
                Female = null;
                Male = null;
                Date = DateTime.MinValue;
                Type = ReproductionTypeEnum.Artificial;               
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Reproduction"/> class.
        /// </summary>
        /// <param name="female">The female.</param>
        /// <param name="male">The male.</param>
        /// <param name="date">The date.</param>
        /// <param name="type">The type.</param>
        /// <param name="status">The status.</param>
        private Reproduction(Female female, Male male, DateTime date, ReproductionTypeEnum type,
                            ReproductionStateEnum status) : this(female, male, date, type, status, null) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Reproduction"/> class.
        /// </summary>
        /// <param name="female">The female.</param>
        /// <param name="male">The male.</param>
        /// <param name="date">The date.</param>
        /// <param name="type">The type.</param>
        /// <param name="states">The states.</param>
        /// <param name="commentary">The commentary.</param>
        private Reproduction(Female female, Male male, DateTime date, ReproductionTypeEnum type,
                            IEnumerable<ReproductionState> states, string commentary)
        {
            if (female != null && male != null)
            {
                Female = female;
                Male = male;
                Date = date;
                Type = type;
                States = States.Union(states);
                Commentary = commentary;
            }
            else
            {
                Female = null;
                Male = null;
                Date = DateTime.MinValue;
                Type = ReproductionTypeEnum.Artificial;
            }
        }

        /// <summary>
        ///Creates a reproduction with initial state.
        /// </summary>
        /// <param name="female">The female.</param>
        /// <param name="male">The male.</param>
        /// <param name="date">The date.</param>
        /// <param name="type">The type.</param>
        /// <param name="status">The status.</param>
        /// <param name="commentary">The commentary.</param>
        /// <returns></returns>
        public static Reproduction Initialize(Female female, Male male, DateTime date,
                            ReproductionTypeEnum type, ReproductionStateEnum status,
                            string commentary)
        {
            if (female != null && female.CanBeMated(date) && status == ReproductionStateEnum.Initial)
            {
                return new Reproduction(female, male, date, type, ReproductionStateEnum.Initial, commentary);
            }
            return Reproduction.None;
        }

        /// <summary>
        /// Expresses equality of two reproduction objects.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        protected override bool EqualsCore(Reproduction obj)
        {
            return Date == obj.Date
                   && Male == obj.Male
                   && Female == obj.Female
                   && Type == obj.Type
                   && Equals(States, obj.States);
        }

        /// <summary>
        /// Gets the hash code of this instance.
        /// </summary>
        /// <returns></returns>
        protected override int GetHashCodeCore()
        {
            return Date.GetHashCode() 
                    ^ Male.Id.GetHashCode()
                    ^ Female.Id.GetHashCode()
                    ^ Type.GetHashCode() 
                    ^ States.GetHashCode();
        }

        /// <summary>
        /// Put this instance to gestating state.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public Reproduction ToGestating(DateTime date)
        {   
            if(this != None && ActualState.State == ReproductionStateEnum.Initial)
            {
                return ToNextState(date);
            }
            return Reproduction.None;

        }

        /// <summary>
        ///  Put this instance to completed state
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public Reproduction ToCompleted(DateTime date)
        {
            return ActualState.State != ReproductionStateEnum.Gestating || this == None ? Reproduction.None : ToNextState(date);
        }

        /// <summary>
        ///  Put this instance to aborted state
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public Reproduction ToAborted(DateTime date)
        {
            if((ActualState.State != ReproductionStateEnum.Initial && ActualState.State != ReproductionStateEnum.Gestating) || this == None)
            {
                return Reproduction.None;
            }
            return new Reproduction(Female, Male, date, Type, States.Append(new ReproductionState(ReproductionStateEnum.Aborted, date)), Commentary);
        }

        /// <summary>
        ///  Put this instance to next state if possible
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        private Reproduction ToNextState(DateTime date)
        {
            switch (ActualState.State)
            {
                case ReproductionStateEnum.Initial when date > ActualState.Date:
                    return new Reproduction(Female, Male, date, Type, States.Append(new ReproductionState(ReproductionStateEnum.Gestating, date)), Commentary);

                case ReproductionStateEnum.Gestating when date.Subtract(ActualState.Date) >= TimeSpan.FromDays(Female.Breed.Specie.PregnancyDurationInDays):
                    return new Reproduction(Female, Male, date, Type, States.Append(new ReproductionState(ReproductionStateEnum.Complete, date)), Commentary);

                case ReproductionStateEnum.Complete:
                    return this;

                default:
                    return Reproduction.None;
            }
        }
    }
}
