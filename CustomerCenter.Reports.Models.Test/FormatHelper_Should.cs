using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Uniban.GlassFileData.Reports.Test
{
    public class FormatHelper_Should
    {
        [Fact]
        public void FormatPhoneNumber_Valid11CharacterPhone()
        {
            string expectedResult = "1 (800) 555-5555";

            string phone = "1-800-555-5555";
            string result = FormatHelper.FormatPhoneNumber(phone);
            result.Should().Be(expectedResult);

            phone = "1 (800) 555-5555";
            result = FormatHelper.FormatPhoneNumber(phone);
            result.Should().Be(expectedResult);

            phone = "1-800-555-5555";
            result = FormatHelper.FormatPhoneNumber(phone);
            result.Should().Be(expectedResult);

            phone = "1.800.555.5555";
            result = FormatHelper.FormatPhoneNumber(phone);
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void FormatPhoneNumber_Valid10CharacterPhone()
        {
            string expectedResult = "(514) 555-5555";
            string phone = "514-555-5555";

            string result = FormatHelper.FormatPhoneNumber(phone);
            result.Should().Be(expectedResult);

            phone = "(514) 555-5555";
            result = FormatHelper.FormatPhoneNumber(phone);
            result.Should().Be(expectedResult);

            phone = "514.555.5555";
            result = FormatHelper.FormatPhoneNumber(phone);
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void FormatPhoneNumber_InvalidPhoneNumber()
        {
            string phone = "toto@gmail.com";
            string result = FormatHelper.FormatPhoneNumber(phone);
            result.Should().Be(string.Empty);

            phone = "toto59@gmail.com";
            result = FormatHelper.FormatPhoneNumber(phone);
            result.Should().Be(string.Empty);
        }



    }
}
