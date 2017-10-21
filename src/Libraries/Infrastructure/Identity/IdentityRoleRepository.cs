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
	public  class IdentityRoleRepository : DapperRepository<ApplicationRole>
	{
		public IdentityRoleRepository(IDbConnection connection, ISqlGenerator<ApplicationRole> sqlGenerator)
        : base(connection, sqlGenerator)
        {


		}
		#region createrole
		public async Task<IdentityResult> CreateAsync(ApplicationRole role)
		{ 
			if (await InsertAsync(role))
			{
				return IdentityResult.Success;
			}
			return IdentityResult.Failed(new IdentityError { Description = $"Could not insert role {role.Name}." });
		}
		#endregion

		public async Task<IdentityResult> DeleteAsync(ApplicationRole role)
		{ 
			if (await base.DeleteAsync(role) )
			{
				return IdentityResult.Success;
			}
			return IdentityResult.Failed(new IdentityError { Description = $"Could not delete role {role.Name}." });
		}


		public async Task<ApplicationRole> FindByIdAsync(Guid  roleId)
		{ 
			return await base.FindByIdAsync(roleId);
		}


		public async Task<ApplicationRole> FindByNameAsync(string  roleName)
		{ 
			return await  base.FindAsync(s=>s.Name== roleName);
		}

	}
}
