using Xunit;

namespace PureLib.Tests;


public class FileSizeTests
{
    [Theory]
    [InlineData(1, "1 B")]
    [InlineData(1025, "1 KB")]
    [InlineData(1500000, "1.4 MB")]
    [InlineData(-1500000, "-1.4 MB")]
    [InlineData(-10000500000, "-9.3 GB")]
    public void ToSizeTests(long input, string expected)
    {
        Assert.Equal(expected, input.ToSize());
    }
}
