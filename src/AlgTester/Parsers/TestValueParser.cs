using Newtonsoft.Json;

namespace AlgTester.Parsers
{
    static class TestValueParser
    {
        public static T Parse<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
