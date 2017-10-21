using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ApplicationCore.Interfaces
{
	 
	public interface IWebDbConnection: IDbConnection
	{
    }
	public interface IIdentityDbConnection : IDbConnection
	{
	}
}
