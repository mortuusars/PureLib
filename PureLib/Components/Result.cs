namespace PureLib;

/// <summary>
/// Represents a result of an operation.
/// </summary>
public record Result
{
    /// <summary>
    /// Indicates whether the operation was a success.
    /// </summary>
    public bool Success { get; }
    /// <summary>
    /// Gets the message of what went wrong when operation failed.
    /// </summary>
    public string Error { get; }
    /// <summary>
    /// Indicates whether the operation was a failure.
    /// </summary>
    public bool IsFailure { get => !Success; }

    /// <summary>
    /// Creates instance of class and sets specified properties.
    /// </summary>
    /// <param name="success">Whether operation succeded or not.</param>
    /// <param name="errorMessage">Message of the fail.</param>
    /// <exception cref="InvalidOperationException">If success is <see langword="true"/> and message is not empty.</exception>
    /// <exception cref="InvalidOperationException">If success is <see langword="false"/> and message is empty.</exception>
    protected Result(bool success, string errorMessage)
    {
        if (success && errorMessage != string.Empty)
            throw new InvalidOperationException("Successful result cannot have an error message.");

        if (!success && errorMessage is null)
            throw new InvalidOperationException("Failed result should have an error message.");

        Success = success;
        Error = errorMessage;
    }

    /// <summary>
    /// Successful result.
    /// </summary>
    public static Result Ok() => new Result(true, string.Empty);

    /// <summary>
    /// Successful result with value.
    /// </summary>
    public static Result<T> Ok<T>(T value) => new(true, value, string.Empty);
    /// <summary>
    /// Successful result with value. Error will be default(TError).
    /// </summary>
    public static Result<TValue, TError> Ok<TValue, TError>(TValue value) => new(true, value, default!);

    /// <summary>
    /// Operation failed.
    /// </summary>
    public static Result Fail(string errorMessage) => new(false, errorMessage);

    /// <summary>
    /// Failed result of specified type. Value will be default(T)
    /// </summary>
    public static Result<T> Fail<T>(string errorMessage) => new(false, default!, errorMessage);

    /// <summary>
    /// Failed result of specified type. Value will be default(TValue)
    /// </summary>
    public static Result<TValue, TError> Fail<TValue, TError>(TError error) => new(false, default!, error);
}

/// <summary>
/// Represents a result of an operation with a value.
/// </summary>
/// <typeparam name="T">Type of the value.</typeparam>
public record Result<T> : Result
{
    /// <summary>
    /// Gets the value if result was a success.<br></br>
    /// <see langword="null"/> if result is failure.
    /// </summary>
    public T Value { get; }

    /// <summary>
    /// Creates instance of class and sets specified properties.
    /// </summary>
    /// <param name="success">Whether operation succeded or not.</param>
    /// <param name="value">Value of the result.</param>
    /// <param name="errorMessage">Message of the fail.</param>
    protected internal Result(bool success, T value, string errorMessage) : base(success, errorMessage)
    {
        Value = value;
    }
}

public record Result<TValue, TError> : Result<TValue>
{
    /// <summary>
    /// Gets the error of what went wrong when operation failed.
    /// </summary>
    public new TError Error { get; }

    /// <summary>
    /// Creates instance of Result and sets properties to provided values.
    /// </summary>
    public Result(bool success, TValue value, TError errorValue) : base(success, value, string.Empty)
    {
        Error = errorValue;
    }
}