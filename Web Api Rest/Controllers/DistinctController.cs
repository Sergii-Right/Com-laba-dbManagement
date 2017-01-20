using COM_Laba;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_Api_Rest.Controllers
{
	public class DistinctController : ApiController
	{
		private SharedDatabase db = new SharedDatabase();
		private string file { get { var f = ConfigurationManager.AppSettings["File"]; db.InitFile(f); return f; } }

		public class NameParam { public string Name; }

		[HttpPost]
		public string Distinct(string database, string table, [FromBody]NameParam name)
		{
			return db.CreateTableDistinct(file, database, table, name.Name);
		}
	}
}
