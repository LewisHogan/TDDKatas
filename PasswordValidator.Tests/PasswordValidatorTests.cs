using Xunit;

namespace PasswordValidator.Tests;

public class PasswordValidatorTests
{
    [Fact]
    public void GetPasswordState_EmptyPassword_ReturnsInvalidPasswordState()
        => Assert.Equal(new PasswordState(false, "Passwords may not be empty."), PasswordValidator.GetPasswordState(""));

    [Theory]
    [InlineData("2Sh!4t")]
    [InlineData("N01P_ss")]
    [InlineData("N.43")]
    public void GetPasswordState_TooShortPassword_ReturnsInvalidPasswordState(string input)
        => Assert.Equal(new PasswordState(false, "Password must be at least 8 characters."), PasswordValidator.GetPasswordState(input));

    [Theory]
    [InlineData("1S3c_rePassword")]
    [InlineData("Very2S3c_rePassword")]
    [InlineData("Extr3mely3S+curePassword")]
    public void GetPasswordState_MinimumLengthPassword_ReturnsValidPasswordState(string input)
        => Assert.Equal(new PasswordState(true, ""), PasswordValidator.GetPasswordState(input));

    [Theory]
    [InlineData("1234567A~")]
    [InlineData("n£caAs4m3bub")]
    [InlineData("i@m4Ynter2")]
    public void GetPasswordState_TwoNumbers_ReturnsValidPasswordState(string input)
        => Assert.Equal(new PasswordState(true, ""), PasswordValidator.GetPasswordState(input));
    
    [Theory]
    [InlineData("appKEpie~")]
    [InlineData("n£cASsmbub")]
    [InlineData("i@mhuNter")]
    public void GetPasswordState_MissingNumbers_ReturnsInvalidPasswordState(string input)
        => Assert.Equal(new PasswordState(false, "Password must contain at least 2 numbers."), PasswordValidator.GetPasswordState(input));[Theory]
    
    [InlineData("l0w3rc!se")]
    [InlineData("n£caps4m3bub")]
    [InlineData("i@m4unter2")]
    public void GetPasswordState_NoCapitalLetters_ReturnsInValidPasswordState(string input)
        => Assert.Equal(new PasswordState(false, "Password must contain a capital character."), PasswordValidator.GetPasswordState(input));

    [Theory]
    [InlineData("1Secure.Pas5word")]
    [InlineData("Very2S3cure~Password")]
    [InlineData("Extreme1+3SecurePassword")]
    public void GetPasswordState_CapitalLetter_ReturnsValidPasswordState(string input)
        => Assert.Equal(new PasswordState(true, ""), PasswordValidator.GetPasswordState(input));

    [Theory]
    [InlineData("26h#rt")]
    public void GetPasswordState_MultipleErrors_ReturnsInvalidPasswordState(string input)
        => Assert.Equal(new PasswordState(false, "Password must be at least 8 characters.\nPassword must contain a capital character."), PasswordValidator.GetPasswordState(input));
}