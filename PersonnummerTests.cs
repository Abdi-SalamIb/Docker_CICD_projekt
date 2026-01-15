using Xunit;
using PersonnummerKontrollApp;

namespace Docker_CICD_projekt_Tests
{
    public class PersonnummerValidatorTests
    {
        // ---------- Invalid input / format ----------
        [Theory]
        [InlineData("12345")]
        [InlineData("ABCDEFGHIJKL")]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("!@#$%^&*()")]
        public void Validate_InvalidFormatOrCharacters_ReturnsInvalid(string input)
        {
            var exception = Record.Exception(() => PersonnummerValidator.Validate(input));
            Assert.Null(exception);
            var result = PersonnummerValidator.Validate(input);
            Assert.False(result.IsValid);
            Assert.False(string.IsNullOrWhiteSpace(result.ErrorMessage));
        }

        // ---------- Valid personnummer ----------
        [Theory]
        [InlineData("19811218-9876")]
        [InlineData("198112189876")]
        [InlineData("811218-9876")]
        public void Validate_ValidPersonnummer_ReturnsTrue(string input)
        {
            var result = PersonnummerValidator.Validate(input);
            Assert.True(result.IsValid);
            Assert.NotEqual(default, result.BirthDate);
            Assert.False(string.IsNullOrWhiteSpace(result.Normalized));
        }

        // ---------- Invalid dates ----------
        [Theory]
        [InlineData("19990230-1234")]
        [InlineData("19991301-1234")]
        [InlineData("20000230-1234")]
        public void Validate_InvalidDate_ReturnsFalse(string input)
        {
            var result = PersonnummerValidator.Validate(input);
            Assert.False(result.IsValid);
            Assert.Contains("datum", result.ErrorMessage.ToLower());
        }

        // ---------- Invalid control digit (Luhn) ----------
        [Fact]
        public void Validate_InvalidLuhn_ReturnsFalse()
        {
            string input = "19811218-9875";
            var result = PersonnummerValidator.Validate(input);
            Assert.False(result.IsValid);
            Assert.Contains("kontroll", result.ErrorMessage.ToLower());
        }

        // ---------- Gender hint ----------
        
        [Theory]
        [InlineData("19811218-9876", "Man")]
        [InlineData("19811218-9868", "Kvinna")]
        public void Validate_GenderHint_IsCorrect(string input, string expected)
        {
            var result = PersonnummerValidator.Validate(input);
            Assert.True(result.IsValid);
            Assert.Contains(expected, result.GenderHint);
        }
    }
}