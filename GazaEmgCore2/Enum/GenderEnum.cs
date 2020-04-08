using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.Enum
{
    public enum GenderEnum
    {
     
            ذكر = 1, أثنى
       
    }
    public class GenderEnumModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public static List<GenderEnumModel> EnumToList<T>()
        //{
        //    var array = (T[])(System.Enum.GetValues(typeof(T)).Cast<T>());
        //    var array2 = System.Enum.GetNames(typeof(T)).ToArray<string>();
        //    List<GenderEnumModel> lst = null;
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        if (lst == null)
        //            lst = new List<GenderEnumModel>();
        //        string name = array2[i];
        //        T value = array[i];
        //        lst.Add(new GenderEnumModel { Name = name, Id = value });
        //    }
        //    return lst;
        //}

        public static ICollection<GenderEnumModel> ConvertEnumToList<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("Type given T must be an Enum");
            }

            var result = System.Enum.GetValues(typeof(T))
                             .Cast<T>()
                             .Select(x => new GenderEnumModel
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
