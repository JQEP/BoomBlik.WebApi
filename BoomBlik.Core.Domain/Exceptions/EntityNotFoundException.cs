using System.Reflection;

namespace BoomBlik.Core.Domain.Exceptions;

/// <summary>
/// The error thrown when an entity could not be found.
/// </summary>
/// <remarks>
/// Creates a new instance.
/// </remarks>
public class EntityNotFoundException(MemberInfo entityType, Guid id) : EntityException($"Could not find entity {entityType.Name} with id {id}");