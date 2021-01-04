using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.Reproduction.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI
{
    public static class Helper
    {
        public static string GetProfilePageUrl(this Animal animal, string herdName)
        {
            if (animal.IsAdult)
            {
                return animal.Sex switch
                {
                    SexEnum.Male => $"/animals/male/{herdName}/{animal.Number}/{animal.Name}",
                    SexEnum.Female => $"/animals/female/{herdName}/{animal.Number}/{animal.Name}"

                };
            }
            else
            {
                return $"/animals/little/{herdName}/{animal.Number}/{animal.Name}";
            }
        }
    }
}
