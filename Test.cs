using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipkartCache
{
    public static class Test
    {
        /// <summary>
        /// Test whether the key value is set properly.
        /// </summary>
        /// <returns></returns>
        public static bool TestSetAndGetValue()
        {
            Cache cache = new Cache(new CustomPolicy(), null, 5);

            string key = "key1";
            string val = "val1";

            cache.SetValue(key, val);
            var cacheVal = cache.GetValue(key);
            return string.Equals(val, cacheVal);
        }

        /// <summary>
        /// Test proper exception is thrown.
        /// </summary>
        /// <returns></returns>
        public static bool TestGetInvalidKey()
        {
            Cache cache = new Cache(new CustomPolicy(), null, 1);

            string key1 = "key1";
            string val1 = "val1";
            cache.SetValue(key1, val1);

            string key2 = "key2";
            string val2 = "val2";
            cache.SetValue(key2, val2);

            bool result = false;
            try
            {
                var cacheVal = cache.GetValue(key1);
            }
            catch(InvalidOperationException)
            {
                result = true;
            }

            return result;
        }
    }
}
