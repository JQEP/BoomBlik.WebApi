using BoomBlik.Core.Infrastructure.Entities;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using BoomBlik.Core.Domain.Exceptions;

namespace BoomBlik.Common.Extensions;

/// <summary>
/// Extensions of the CoreEntity.
/// </summary>
public static class DefaultEntityExtensions
{
    /// <summary>
    /// Asserts if an entity was found.
    /// </summary>
    /// <exception cref="EntityNotFoundException">
    /// Throws if the entity was not found.
    /// </exception>
    public static Task<TEntity> AssertEntityFoundOrThrowEntityNotFoundException<TEntity>([NotNull] this TEntity? entity, Guid id) where TEntity : DefaultEntity
    {
        if (entity is null)
        {
            throw new EntityNotFoundException(typeof(TEntity), id);
        }

        return Task.FromResult(entity);
    }

    /// <summary>
    /// Generates the JSON of a CoreEntity instance.
    /// </summary>
    public static string ToJson<TEntity>(this TEntity entity) where TEntity : DefaultEntity
    {
        return JsonSerializer.Serialize(entity, new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }
}