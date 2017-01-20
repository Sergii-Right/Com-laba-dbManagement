using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using COM_Laba;

namespace Web_Api_Rest.Controllers
{
	public class DatabaseController : ApiController
	{
		private SharedDatabase db = new SharedDatabase();
		private string file { get { var f = ConfigurationManager.AppSettings["File"]; db.InitFile(f); return f; } }

		public Dictionary<string,DatabaseData> Get()
		{
			return db.GetDatabases(file);
		}
		
		public Dictionary<string, TableData> Get(string database)
		{
			return db.GetTables(file, database);
		}

		public class NameParam { public string Name; }

		public string Post([FromBody]NameParam name)
		{
			return db.CreateDatabase(file, name.Name);
		}

		public void Put(string database, [FromBody]NameParam name)
		{
			db.RenameDatabase(file, database, name.Name);
		}

		public void Delete(string database)
		{
			db.DeleteDatabase(file, database);
		}
	}
}
