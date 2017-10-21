using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ApplicationCore.Interfaces;

namespace Infrastructure.Identity
{
	public class IdentityConnection : IIdentityDbConnection
	{
		private IDbConnection _dbConnection;
		public IdentityConnection(string conn)
		{
			_dbConnection = new SqlConnection(conn);
			ConnectionString = conn;
		}

		public string ConnectionString { get; set; }

		public int ConnectionTimeout => 30;

		public string Database => throw new NotImplementedException();

		public ConnectionState State => throw new NotImplementedException();

		public IDbTransaction BeginTransaction()
		{
			throw new NotImplementedException();
		}

		public IDbTransaction BeginTransaction(IsolationLevel il)
		{
			throw new NotImplementedException();
		}

		public void ChangeDatabase(string databaseName)
		{
			throw new NotImplementedException();
		}

		public void Close()
		{
			throw new NotImplementedException();
		}

		public IDbCommand CreateCommand()
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public void Open()
		{
			throw new NotImplementedException();
		}
	}
}
