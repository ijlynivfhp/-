using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Infrastructure.Identity
{
    /// <summary>
    /// This store isn't implemented as part of this sample.
    /// </summary>
    public class IdentityRoleStore : IRoleStore<ApplicationRole>
    {
		private readonly IdentityRoleRepository _repo;
		public IdentityRoleStore(IdentityRoleRepository repo) {
			_repo = repo;
		}
		public Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
			cancellationToken.ThrowIfCancellationRequested();
			if (role == null) throw new ArgumentNullException(nameof(role));
		 

			return _repo.CreateAsync(role);

		}

        public Task<IdentityResult> DeleteAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
			cancellationToken.ThrowIfCancellationRequested();
			if (role == null) throw new ArgumentNullException(nameof(role));

			return _repo.DeleteAsync(role);
		}

		/// <summary>
		/// Dispose the stores
		/// </summary>
		public void Dispose() => _disposed = true;

		public Task<ApplicationRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
			cancellationToken.ThrowIfCancellationRequested();
			if (string.IsNullOrWhiteSpace(roleId)) throw new ArgumentNullException(nameof(roleId));


			return _repo.FindByIdAsync(roleId);
		}

        public Task<ApplicationRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
			cancellationToken.ThrowIfCancellationRequested();
			if (string.IsNullOrWhiteSpace(normalizedRoleName)) throw new ArgumentNullException(nameof(normalizedRoleName));


			return _repo.FindAsync(s=>s.Name==normalizedRoleName);
		}

        public Task<string> GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
			cancellationToken.ThrowIfCancellationRequested();
			if (role==null) throw new ArgumentNullException(nameof(role));

			return Task.FromResult(role.Name);

		}
		private bool _disposed;
		/// <summary>
		/// Throws if this class has been disposed.
		/// </summary>
		protected void ThrowIfDisposed()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
		}
		public Task<string> GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}
			return Task.FromResult( role.Id+"");
			 
        }

        public Task<string> GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}
			return Task.FromResult(role.Name);
		}

        public Task SetNormalizedRoleNameAsync(ApplicationRole role, string normalizedName, CancellationToken cancellationToken)
        {
			throw new NotImplementedException();
		}

        public Task SetRoleNameAsync(ApplicationRole role, string roleName, CancellationToken cancellationToken)
        {
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}
			return Task.FromResult(role.Name);
		}
		/// <summary>
		/// Gets or sets the <see cref="IdentityErrorDescriber"/> for any error that occurred with the current operation.
		/// </summary>
		public IdentityErrorDescriber ErrorDescriber { get; set; }
		public async Task<IdentityResult> UpdateAsync(ApplicationRole role, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}
			
		 
			try
			{
				if( await  _repo.UpdateAsync(role))
					return IdentityResult.Success;
			}
			catch (Exception)
			{
				return IdentityResult.Failed(ErrorDescriber.ConcurrencyFailure());
			}
			return IdentityResult.Success;
		}
    }
}
