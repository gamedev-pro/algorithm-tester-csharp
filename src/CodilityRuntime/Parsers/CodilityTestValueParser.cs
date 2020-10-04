using Newtonsoft.Json;

namespace CodilityRuntime.Parsers
{
    static class CodilityTestValueParser
    {
        public static T Parse<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
