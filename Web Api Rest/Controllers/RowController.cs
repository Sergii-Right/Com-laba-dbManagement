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
	public class RowController : ApiController
	{
		private SharedDatabase db = new SharedDatabase();
		private string file { get { var f = ConfigurationManager.AppSettings["File"]; db.InitFile(f); return f; } }

		public class ValueParam { public string Value; }

		public void Put(string database, string table, string column, int row, [FromBody]ValueParam value)
		{
			db.SetValue(file, database, table, column, row, value.Value);
		}

		public void Delete(string file, string database, string table, int row)
		{
			db.DeleteRow(file, database, table, row);
		}
	}
}
