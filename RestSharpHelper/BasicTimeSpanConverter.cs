using Newtonsoft.Json;
using System;
using System.Linq;

namespace RestSharpHelper
{
    public class BasicTimeSpanConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
                return null;

            try
            {
                var value = (string)reader.Value;
                var values = value.Split(':').Select(int.Parse).ToList();
                switch (values.Count)
                {
                    case 2:
                        return new TimeSpan(0, values[0], values[1]);

                    case 3:
                        return new TimeSpan(values[0], values[1], values[2]);
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override bool CanRead => true;

        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TimeSpan);
        }
    }
}
