using System;
using System.Linq;
using Newtonsoft.Json;

namespace RestSharpHelper
{
    public class BasicDateTimeConverter : JsonConverter
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
                var values = value.Split('-').Select(int.Parse).ToList();

                switch (values.Count)
                {
                    case 1:
                        return new DateTime(values[0], 1, 1);

                    case 2:
                        return new DateTime(values[0], Normalize(values[1]), 1);

                    case 3:
                        return new DateTime(values[0], Normalize(values[1]), Normalize(values[2]));
                }
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }

        private int Normalize(int value)
        {
            return (value <= 0) ? 1 : value;
        }

        public override bool CanRead => true;

        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }
    }
}
