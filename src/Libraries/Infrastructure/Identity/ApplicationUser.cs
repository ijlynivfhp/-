using System;
using System.Collections.Generic;
using System.Text;
 
namespace Infrastructure.Identity
{
	public class ApplicationUser  
	{
		public string Id { get; set; }

		public string UserName { get; set; }

		public string Pwd { get; set; }
	}
}
