using System.Text.Json;

namespace BundleCalculator.Utils
{
    public static class JsonHelper
    {
        public static T Read<T>(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                try
                {
                    string json = file.ReadToEnd();
                    return JsonSerializer.Deserialize<T>(json);
                }
                catch (Exception)
                {
                    Console.WriteLine("Problem reading file");
                    return default;
                }
            }
        }

        public static T MapAnonymousObject<T>(object obj) 
        {
            var json = JsonSerializer.Serialize(obj);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}