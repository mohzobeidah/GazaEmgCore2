using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.Enum
{
    public enum Nationality
    {
        فلسطيني = 1 , اجنبي
           
    }

    public class NationalityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static ICollection<NationalityModel> ConvertEnumToList<T>() where  T  : struct, IConvertible  
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("Type given T must be an Enum");
            }

            var result = System.Enum.GetValues(typeof(T))
                             .Cast<T>()
                             .Select(x => new NationalityModel
                             {
                                 Id = Convert.ToInt32(x),
                                 Name = x.ToString(new CultureInfo("en"))
                             })
                             .ToList()
                             .AsReadOnly();

            return result;
        }
    }
}
