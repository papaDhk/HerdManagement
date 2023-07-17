using HerdManagement.Domain.Reproduction.Entities;
using HerdManagement.Domain.Reproduction.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                    SexEnum.Male => $"/herds/{herdName}/animals/male/{animal.Number}/{animal.Name}",
                    SexEnum.Female => $"/herds/{herdName}/animals/female/{animal.Number}/{animal.Name}"

                };
            }
            else
            {
                return $"/herds/{herdName}/animals/little/{animal.Number}/{animal.Name}";
            }
        }

        public static Dictionary<string, string> GetKeyValuesFromEnum(Type enumType)
        {
            Dictionary<string, string> results = new Dictionary<string, string>();
            //var type = typeof(T);
            foreach (var field in enumType.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;
                if (attribute == null)
                {
                    if (field.Name != "value__")
                    {
                        results.Add(field.Name, field.Name);
                    }
                }
                else
                {
                    results.Add(field.Name, attribute.Name);
                }
            }

            return results;
        }

        public static string GetDisplayName(Enum enumType)
        {
            return GetKeyValuesFromEnum(enumType.GetType()).GetValueOrDefault(enumType.ToString());
        }
        public static List<EnumKeyValue> GetKeyValuesAsListFromEnum(Type enumType)
        {
            List<EnumKeyValue> results = new List<EnumKeyValue>();

            foreach (var field in enumType.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;
                if (attribute == null)
                {
                    if (field.Name != "value__")
                    {
                        results.Add(new EnumKeyValue { Key = field.Name, Value = field.Name });
                    }
                }
                else
                {
                    results.Add(new EnumKeyValue { Key = field.Name, Value = attribute.Name });
                }
            }

            return results.OrderBy(o => o.Value).ToList(); ;
        }

        public class EnumKeyValue
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
}
