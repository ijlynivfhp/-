using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
	public  class IdentityUserRepository: DapperRepository<ApplicationUser>
	{
		public IdentityUserRepository(IDbConnection connection, ISqlGenerator<ApplicationUser> sqlGenerator)
        : base(connection, sqlGenerator)
        {


		}
		#region createuser
		public async Task<IdentityResult> CreateAsync(ApplicationUser user)
		{ 
			if (await InsertAsync(user))
			{
				return IdentityResult.Success;
			}
			return IdentityResult.Failed(new IdentityError { Description = $"Could not insert user {user.Email}." });
		}
		#endregion

		public async Task<IdentityResult> DeleteAsync(ApplicationUser user)
		{ 
			if (await base.DeleteAsync(user) )
			{
				return IdentityResult.Success;
			}
			return IdentityResult.Failed(new IdentityError { Description = $"Could not delete user {user.Email}." });
		}


		public async Task<ApplicationUser> FindByIdAsync(Guid userId)
		{ 
			return await base.FindByIdAsync(userId);
		}


		public async Task<ApplicationUser> FindByNameAsync(string userName)
		{ 
			return await  base.FindAsync(s=>s.UserName==userName);
		}

	}
}
