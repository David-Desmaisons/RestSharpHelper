using Newtonsoft.Json;
using RestSharpHelper;
using System;
using Xunit;
using FluentAssertions;

namespace RestSharpHelperTest
{
    public class BasicDateTimeConverterTest
    {
        private class FakeClass
        {
            [JsonConverter(typeof(BasicDateTimeConverter))]
            public DateTime? date { get; set; }
        }

        private const string _JsonTemplate = "\"date\": \"{0}\"";
        private DateTime _Date = new DateTime(1981, 1, 1);

        [Theory]
        [InlineData("")]
        [InlineData("ffff")]
        [InlineData("2000-32-32")]
        public void BasicDateTimeConverter_DeserializeCorrectlyNullResult(string data)
        {
            var json = "{" + string.Format(_JsonTemplate, data) + "}";
            var result = JsonConvert.DeserializeObject<FakeClass>(json);
            result.date.Should().Be(null);
        }

        [Theory]
        [InlineData("1981", 1981, 1, 1)]
        [InlineData("1990-11", 1990, 11, 1)]
        [InlineData("2000-11-25", 2000, 11, 25)]
        public void BasicDateTimeConverter_DeserializeCorrectly(string data, int year, int month, int day)
        {
            var json = "{" + string.Format(_JsonTemplate, data) + "}";
            var result = JsonConvert.DeserializeObject<FakeClass>(json);
            var expected = new DateTime(year, month, day);
            result.date.Should().Be(expected);
        }
    }
}
