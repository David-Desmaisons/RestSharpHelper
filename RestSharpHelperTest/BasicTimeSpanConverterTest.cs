using Newtonsoft.Json;
using RestSharpHelper;
using System;
using Xunit;
using FluentAssertions;

namespace RestSharpHelperTest
{
    public class BasicTimeSpanConverterTest
    {
        private class FakeClass
        {
            [JsonConverter(typeof(BasicTimeSpanConverter))]
            public TimeSpan? date { get; set; }
        }

        private const string _JsonTemplate = "\"date\": \"{0}\"";
        private DateTime _Date = new DateTime(1981, 1, 1);

        [Theory]
        [InlineData("")]
        [InlineData("ffff")]
        [InlineData("20")]
        public void BasicDateTimeConverter_DeserializeCorrectlyNullResult(string data)
        {
            var result = GetDeserialized(data);
            result.date.Should().Be(null);
        }

        [Theory]
        [InlineData("0:46", 0, 0, 46)]
        [InlineData("1:00:36", 1, 0, 36)]
        public void BasicDateTimeConverter_DeserializeCorrectly(string data, int hour, int minute, int second)
        {
            var result = GetDeserialized(data);
            var expected = new TimeSpan(hour, minute, second);
            result.date.Should().Be(expected);
        }

        private FakeClass GetDeserialized(string value)
        {
            var json = "{" + string.Format(_JsonTemplate, value) + "}";
            return JsonConvert.DeserializeObject<FakeClass>(json);
        }
    }
}
