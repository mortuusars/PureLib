using Xunit;

namespace PureLib.Tests;

public class ResultTests
{
    public static readonly object[][] ResultData = new object[][]
    {
        new object[] { Result.Ok(), true, string.Empty },
        new object[] { Result.Fail("error"), false, "error" },
    };

    public static readonly object[][] ResultOfTData = new object[][]
    {
        new object[] { Result.Ok(""), true, string.Empty, string.Empty },
        new object[] { Result.Ok<string>(null!), true, null!, string.Empty },
        new object[] { Result.Fail<string>("error"), false, null!, "error" },
    };

    public static readonly object[][] ResultOfValueAndErrorData = new object[][]
    {
        new object[] { Result.Ok<string, bool>(""), true, string.Empty, false },
        new object[] { Result.Ok<string, bool>(null!), true, null!, false },
        new object[] { Result.Fail<string, bool>(false), false, null!, false },
    };

    [Theory]
    [MemberData(nameof(ResultData))]
    public void ResultTest(Result result, bool expectedSuccess, string expectedErrorMsg)
    {
        Assert.Equal(expectedSuccess, result.Success);
        Assert.Equal(expectedErrorMsg, result.Error);
    }

    [Theory]
    [MemberData(nameof(ResultOfTData))]
    public void ResultOfTTest(Result<string> result, bool expectedSuccess, string expectedValue, string expectedErrorMsg)
    {
        Assert.Equal(expectedSuccess, result.Success);
        Assert.Equal(expectedValue, result.Value);
        Assert.Equal(expectedErrorMsg, result.Error);
    }

    [Theory]
    [MemberData(nameof(ResultOfValueAndErrorData))]
    public void ResultOfValueAndErrorTest(Result<string, bool> result, bool expectedSuccess, string expectedValue, bool expectedErrorValue)
    {
        Assert.Equal(expectedSuccess, result.Success);
        Assert.Equal(expectedValue, result.Value);
        Assert.Equal(expectedErrorValue, result.Error);
    }
}