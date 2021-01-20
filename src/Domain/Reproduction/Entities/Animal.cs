using HerdManagement.Domain.Common;
using HerdManagement.Domain.Common.Utils;
using HerdManagement.Domain.Reproduction.Enumerations;
using HerdManagement.Domain.SpecieBreed.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using HerdManagement.Domain.Characteristic.Entities;

namespace HerdManagement.Domain.Reproduction.Entities
{
    public class Animal : Entity<Animal>
    {
        public  string Name { get; set; }
        public  int Number { get; set; }
        public virtual SexEnum Sex { get; set; }
        public  DateTime BirthDate { get; set; }
        public  byte[] Picture { get; set; }
        public  AnimalOrigin Origin { get; set; }
        public  uint Weight { get; set; }
        public  PresenceStatusEnum PresenceStatus { get; set; }
        public  DateTime DeathDate { get; set; }
        public int BreedId { get; set; }
        public  Breed Breed { get; set; }
        public int HerdId { get; set; }
        public  Herd.Entities.Herd Herd { get; set; }
        public Calving FromCalving { get; set; }

        public List<BreedCharacteristicValue> BreedCharacteristicValues { get; set; }

        public List<SpecieCharacteristicValue> SpecieCharacteristicValues { get; set; }

        private string _categoryType;
        
        
        public string CategoryType
        {
            get
            {
                if (_categoryType != null)
                {
                    return _categoryType;
                }
                
                if (IsAdult)
                {
                    return Sex == SexEnum.Male ? MALE_TYPE : FEMALE_TYPE;
                }

                return YOUNG_ANIMAL_TYPE;
            }

            set => _categoryType = value;
        }

        public const string YOUNG_ANIMAL_TYPE = "young_animal";
        public const string MALE_TYPE = "male";
        public const string FEMALE_TYPE = "female";
        
        protected override bool EqualsCore(Animal animalToCompareWith)
        {
            return Id == animalToCompareWith.Id && Number == animalToCompareWith.Number;
        }

        protected override int GetHashCodeCore()
        {
            return Id.GetHashCode() ^ Number.GetHashCode();
        }

        public int AgeInDays => DateTime.UtcNow.Subtract(BirthDate).Days;

        public string AgeInString => BirthDate.GetAge(DateTime.UtcNow);

        public bool IsAdult => Breed?.Specie?.ChildhoodDurationInDays < AgeInDays;

        public bool WasAdult(DateTime dateTime) => Breed?.Specie?.ChildhoodDurationInDays < dateTime.Subtract(BirthDate).Days;

        public override string ToString()
        {
            return $"{Number} - {Name} - {Breed.Label}";
        }

        public DateTime ApproximativeOriginReproductionDate => BirthDate.Subtract(TimeSpan.FromDays(this.Breed.Specie.PregnancyDurationInDays));

        public static string GetCategory(Specie specie, SexEnum sex, DateTime birthDate)
        {
            bool isAdult = specie?.ChildhoodDurationInDays < DateTime.UtcNow.Subtract(birthDate).Days;
            
            if (isAdult)
            {
                return sex == SexEnum.Male ? "male" : "female";
            }

            return "young_animal";
        }
    }

    public enum AnimalOrigin
    {
        [Display(Name = "Acheté")]
        Bought,

        [Display(Name = "Dotation")]
        Donated,

        [Display(Name = "Trouvé")]
        Found,

        [Display(Name = "Issu du troupeau")]
        BornInFarm
    }
}
