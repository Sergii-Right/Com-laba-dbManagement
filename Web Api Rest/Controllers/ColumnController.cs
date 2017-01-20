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
	public class ColumnController : ApiController
	{
		private SharedDatabase db = new SharedDatabase();
		private string file { get { var f = ConfigurationManager.AppSettings["File"]; db.InitFile(f); return f; } }

		public Dictionary<string, Column> Get(string database, string table)
		{
			return db.GetColumns(file, database, table);
		}

		public Column Get(string database, string table, string column)
		{
			return db.GetColumns(file, database, table)[column];
		}

		public class NameTypeParam { public string Name; public string Type; }

		public string Post(string database, string table, [FromBody]NameTypeParam param)
		{
			return db.CreateColumn(file, database, table, param.Name, param.Type);
		}

		public void Delete(string database, string table, string column)
		{
			db.DeleteColumn(file, database, table, column);
		}
	}
}
