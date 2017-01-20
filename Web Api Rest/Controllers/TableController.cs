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
	public class TableController : ApiController
	{
		private SharedDatabase db = new SharedDatabase();
		private string file { get { var f = ConfigurationManager.AppSettings["File"]; db.InitFile(f); return f; } }

		public Dictionary<string, TableData> Get(string database)
		{
			return db.GetTables(file, database);
		}

		public Dictionary<string, Column> Get(string database, string table)
		{
			return db.GetColumns(file, database, table);
		}

		public void Post(string database, string table)
		{
			db.CreateRow(file, database, table);
		}

		public class NameParam { public string Name; }

		public string Post(string database, [FromBody]NameParam name)
		{
			return db.CreateTable(file, database, name.Name);
		}

		public void Put(string database, string table, [FromBody]NameParam name)
		{
			db.RenameTable(file, database, table, name.Name);
		}

		public void Delete(string database, string table)
		{
			db.DeleteTable(file, database, table);
		}
	}
}
