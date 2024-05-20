namespace BoomBlik.Core.Domain.Exceptions;

/// <summary>
/// The base exception class.
/// </summary>
public abstract class EntityException : Exception
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    protected EntityException()
    { }

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    protected EntityException(string message) : base(message)
    { }

    /// <summary>
    /// Creates a new instance.
    /// </summary>a
    protected EntityException(string message, Exception innerException) : base(message, innerException)
    { }
}