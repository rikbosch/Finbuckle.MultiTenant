// Copyright Finbuckle LLC, Andrew White, and Contributors.
// Refer to the solution LICENSE file for more inforation.

using System.Collections.Generic;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Finbuckle.MultiTenant;


/// <summary>
/// Interface definition for tenant stores.
/// </summary>
/// <typeparam name="TTenantInfo">The ITenantInfo implementation type.</typeparam>
public interface IMultiTenantStore<TTenantInfo> where TTenantInfo : class, ITenantInfo, new()
{
    /// <summary>
    /// Try to add the TTenantInfo to the store.
    /// </summary>
    /// <param name="tenantInfo">New TTenantInfo instance to add.</param>
    /// <returns>True if successfully added</returns>
    Task<bool> TryAddAsync(TTenantInfo tenantInfo);

    /// <summary>
    /// Try to update the TTenantInfo in the store.
    /// </summary>
    /// <param name="tenantInfo">Existing TTenantInfo instance to update.</param>
    /// <returns>True if successfully updated.</returns>
    Task<bool> TryUpdateAsync(TTenantInfo tenantInfo);

    /// <summary>
    /// Try to remove the TTenantInfo from the store.
    /// </summary>
    /// <param name="identifier">Identifier for the tenant to remove. </param>
    /// <returns>True if successfully removed</returns>
    Task<bool> TryRemoveAsync(string identifier);

    /// <summary>
    /// Retrieve the TTenantInfo for a given identifier.
    /// </summary>
    /// <param name="identifier">Identifier for the tenant to retrieve.</param>
    /// <returns>Returns TTenantInfo instance if found or null.</returns>
    ///  TODO make obsolete
    Task<TTenantInfo?> TryGetByIdentifierAsync(string identifier);

    /// <summary>
    /// Retrieve the TTenantInfo for a given tenant Id.
    /// </summary>
    /// <param name="id">TenantId for the tenant to retrieve.</param>
    /// <returns>Returns TTenantInfo instance if found or null.</returns>
    ///  TODO make obsolete
    Task<TTenantInfo?> TryGetAsync(string id);


    /// <summary>
    /// Retrieve all the TTenantInfo's from the store.
    /// </summary>
    /// <returns>IEnumerable of all tenants in the store.</returns>
    Task<IEnumerable<TTenantInfo>> GetAllAsync();
}