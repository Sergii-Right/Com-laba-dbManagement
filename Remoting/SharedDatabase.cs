using COM_Laba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remoting
{
	class SharedDatabase : MarshalByRefObject, ISharedDatabaseLocal
	{
		private COM_Laba.SharedDatabase db = new COM_Laba.SharedDatabase();
		private string file { get { string f = "Remoting.db"; db.InitFile(f); return f; } }
		
		public string CreateDatabase(string name) { return db.CreateDatabase(file, name); }
		public string CreateTable(string database, string name) { return db.CreateTable(file, database, name); }
		public string CreateTableDistinct(string database, string table, string name) { return db.CreateTableDistinct(file, database, table, name); }
		public string CreateColumn(string database, string table, string name, string type) { return db.CreateColumn(file, database, table, name, type); }
		public void CreateRow(string database, string table) { db.CreateRow(file, database, table); }
		public void RenameDatabase(string database, string name) { db.RenameDatabase(file, database, name); }
		public void RenameTable(string database, string table, string name) { db.RenameTable(file, database, table, name); }
		public void SetValue(string database, string table, string column, int row, string value) { db.SetValue(file, database, table, column, row, value); }
		public Dictionary<string, DatabaseData> GetDatabases() { return db.GetDatabases(file); }
		public Dictionary<string, TableData> GetTables(string database) { return db.GetTables(file, database); }
		public Dictionary<string, Column> GetColumns(string database, string table) { return db.GetColumns(file, database, table); }
		public void DeleteDatabase(string database) { db.DeleteDatabase(file, database); }
		public void DeleteTable(string database, string table) { db.DeleteTable(file, database, table); }
		public void DeleteColumn(string database, string table, string column) { db.DeleteColumn(file, database, table, column); }
		public void DeleteRow(string database, string table, int row) { db.DeleteRow(file, database, table, row); }
	}
}
