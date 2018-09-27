using System;

namespace FlipkartCache
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Cache cache = new Cache(new CustomPolicy(), null, 5);
            try
            {
                //Test.TestGetInvalidKey();
                Test.TestSetAndGetValue();
                cache.SetValue("key1", "val1");
                cache.SetValue("key2", "val2");
                cache.SetValue("key3", "val3");
                cache.SetValue("key4", "val4");
                cache.SetValue("key5", "val5");

                var x = cache.GetValue("key1");

                cache.SetValue("key6", "val6");
                var y = cache.GetValue("key2");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }
    }
}
