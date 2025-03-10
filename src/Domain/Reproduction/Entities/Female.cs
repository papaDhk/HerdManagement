﻿using HerdManagement.Domain.Reproduction.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HerdManagement.Domain.Reproduction.Entities
{
    public class Female : AdultAnimal
    {
        public Female()
        {
        }

        /// <summary>
        /// Animal Sex
        /// </summary>
        public override SexEnum Sex { get => SexEnum.Female; }

        /// <summary>
        /// Different female's calvings
        /// </summary>
        public List<Calving> Calvings { get; } = new List<Calving>();

        /// <summary>
        /// Indicates wether this female can be mated or not at the given date
        /// </summary>
        /// <param name="date"></param>
        /// <returns>true if this female is able to be mated at the given date. False otherwise</returns>
        public bool CanBeMated(DateTime date)
        {   bool wasAdult = WasAdult(date);

            DateTime lastCalvingDate = Calvings.Any()? Calvings.Max(calving => calving.Date).Date : DateTime.MinValue; //TODO: take last calving at the given date

            return wasAdult && TimeSpan.FromDays(Breed.Specie.MinimumTimeSpanBetweenCalvingAndHeatInDays) < date.Subtract(lastCalvingDate);
        }

        public override bool CanBeParentOfAnimalBornIn(DateTime dateTime)
        {
            var approximativeReproductionDate = dateTime.Subtract(TimeSpan.FromDays(this.Breed.Specie.PregnancyDurationInDays - 10));
            
            return CanBeMated(approximativeReproductionDate);
        }

        /// <summary>
        /// Indicates that the female has been mated by the given male
        /// </summary>
        /// <param name="male"></param>
        /// <param name="date"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="commentary"></param>
        /// <returns>A correct reproduction object with initial state if possible. Otherwise return a default one</returns>
        public Reproduction HasBeenMated(Male male, DateTime date,ReproductionTypeEnum type,
                                                      ReproductionStateEnum status,string commentary)
        {
            return Reproduction.Initialize(this, male, date, type, status, commentary);
        }
    }
}
