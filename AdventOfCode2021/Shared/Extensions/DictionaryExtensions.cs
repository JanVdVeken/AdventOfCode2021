using System.Collections.Generic;
using System.Linq;

namespace Shared.Extensions
{
    public static class DictionaryExtensions
    {
        public static void AddToDictWithCheckOnExistingKey<T1,T2>(this Dictionary<T1, T2> dict, T1 key, T2 valueOfT2)
        {
            dynamic value = valueOfT2;
            if (dict.Keys.Contains(key)) dict[key] += value;
            else dict[key] = value;
        }
    }
}