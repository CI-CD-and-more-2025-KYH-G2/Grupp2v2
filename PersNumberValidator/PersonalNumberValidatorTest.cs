using Xunit;

public class PersonalNumberValidatorTest
{
    private readonly PersonalNumberValidator _validator;
    public PersonalNumberValidatorTest()
    {
        _validator = new PersonalNumberValidator();
    }
    [Fact]
    public void ClearPersNum_Empty()
    {
        string input = "";
        string cleanedPnr = _validator.CleanPersonalNumber(input);
        Assert.Equal("", cleanedPnr);
    }
}
