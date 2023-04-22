namespace Sc_Test01;

public class UnitTest1
{

    [Fact]     //what we are trying to do '_' what should happen
    public void SetTitle_ShouldSetCorrectString()
    {
        //? AAA setup

        //? Arrange 
        StreamingContentEntity content = new StreamingContentEntity();
        content.Title = "Toy Story";

        //? Action
        string expected = "Toy Story";
        string actual = content.Title;

        //? Assert
        Assert.Equal(expected, actual);

    }

    [Theory]
    [InlineData(MaturityRating.G, true)]
    [InlineData(MaturityRating.TV_PG, true)]
    [InlineData(MaturityRating.R, false)]
    [InlineData(MaturityRating.TV_MA, false)]
    public void SetMaturityRating_ShouldGetCorrectFamilyFriendlyRating(MaturityRating maturityRating, bool expectedFamilyFriendly)
    {
        //? AAA Setup

        //? Arrange
        StreamingContentEntity content = new StreamingContentEntity("Content Title", "Some Description", 4.2, maturityRating, GenreType.SciFi);

        //? Action
        bool expected = expectedFamilyFriendly;
        bool actual = content.IsFamilyFriendly;

        //? Assert
        Assert.Equal(expected, actual);
    }
}