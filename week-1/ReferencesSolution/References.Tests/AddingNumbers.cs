
namespace References.Tests;

public class AddingNumbers
{

    [Fact]
    public void CanAddTwoNumbersTwentyAndTenToGiveYouThirty()
    {
        //given 
        int a = 10;
        int b = 20;
        int answer;

        //when
        answer = a + b;

        //then
        //Answer should be 30
        Assert.Equal(31, answer);
    }

    [Theory]
    [InlineData(10, 20, 30)]
    [InlineData(2, 2, 4)]
    [InlineData(10, 3, 13)]
    public void CanAddAnyTwoIntegers(int a, int b, int expected)
    {
        int answer = a + b;
        Assert.Equal(expected, answer);
    }
}