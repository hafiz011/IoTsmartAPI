using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using IoTsmartAPI.Models;
using System.Threading;
using System.Threading.Tasks;

public class MongoRoleStore : IRoleStore<IdentityRole>
{
    private readonly IMongoCollection<IdentityRole> _rolesCollection;

    public MongoRoleStore(IMongoCollection<IdentityRole> rolesCollection)
    {
        _rolesCollection = rolesCollection;
    }

    public async Task<IdentityResult> CreateAsync(IdentityRole role, CancellationToken cancellationToken)
    {
        try
        {
            await _rolesCollection.InsertOneAsync(role, cancellationToken: cancellationToken);
            return IdentityResult.Success;
        }
        catch (Exception ex)
        {
            // Log exception if needed
            return IdentityResult.Failed(new IdentityError { Description = ex.Message });
        }
    }

    public async Task<IdentityResult> DeleteAsync(IdentityRole role, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _rolesCollection.DeleteOneAsync(r => r.Id == role.Id, cancellationToken);
            return result.DeletedCount > 0 ? IdentityResult.Success : IdentityResult.Failed(new IdentityError { Description = "Role not found." });
        }
        catch (Exception ex)
        {
            // Log exception if needed
            return IdentityResult.Failed(new IdentityError { Description = ex.Message });
        }
    }

    public void Dispose()
    {
        // No resources to dispose, MongoDB handles its own connections.
    }

    public async Task<IdentityRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
    {
        return await _rolesCollection.Find(r => r.Id == roleId).SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<IdentityRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
    {
        return await _rolesCollection.Find(r => r.NormalizedName == normalizedRoleName).SingleOrDefaultAsync(cancellationToken);
    }

    public Task<string> GetNormalizedRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
    {
        return Task.FromResult(role.NormalizedName);
    }

    public Task<string> GetRoleIdAsync(IdentityRole role, CancellationToken cancellationToken)
    {
        return Task.FromResult(role.Id);
    }

    public Task<string> GetRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
    {
        return Task.FromResult(role.Name);
    }

    public Task SetNormalizedRoleNameAsync(IdentityRole role, string normalizedName, CancellationToken cancellationToken)
    {
        role.NormalizedName = normalizedName;
        return Task.CompletedTask;
    }

    public Task SetRoleNameAsync(IdentityRole role, string roleName, CancellationToken cancellationToken)
    {
        role.Name = roleName;
        return Task.CompletedTask;
    }

    public async Task<IdentityResult> UpdateAsync(IdentityRole role, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _rolesCollection.ReplaceOneAsync(r => r.Id == role.Id, role, cancellationToken: cancellationToken);
            return result.MatchedCount > 0 ? IdentityResult.Success : IdentityResult.Failed(new IdentityError { Description = "Role not found." });
        }
        catch (Exception ex)
        {
            // Log exception if needed
            return IdentityResult.Failed(new IdentityError { Description = ex.Message });
        }
    }
}
