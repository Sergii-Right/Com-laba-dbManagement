
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceSharedDatabase" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select ServiceSharedDatabase.svc or ServiceSharedDatabase.svc.cs at the Solution Explorer and start debugging.
	public class ServiceSharedDatabase : IServiceSharedDatabase
	{
		private COM_Laba.SharedDatabase db = new COM_Laba.SharedDatabase();
		private string file { get { string f = ConfigurationManager.AppSettings["File"]; db.InitFile(f); return f; } }
		private DatabaseData Convert(COM_Laba.DatabaseData databaseData) { return new DatabaseData { Name = databaseData.Name, Tables = databaseData.Tables }; }
		private TableData Convert(COM_Laba.TableData tableData) { return new TableData { Name = tableData.Name, Columns = tableData.Columns, Rows = tableData.Rows }; }
		private Column Convert(COM_Laba.Column column) { return new Column { Name = column.Name, Type = column.Type, Values = Convert(column.Values) }; }
		private List<Value> Convert(List<COM_Laba.Value> values) { var res = new List<Value>(); for (int i = 0; i < values.Count; i++) res.Add(Convert(values[i])); return res; }
		private Value Convert(COM_Laba.Value value) { return new Value { Data = value.Data }; }

		public string CreateDatabase(string name) { return db.CreateDatabase(file, name); }
		public string CreateTable(string database, string name) { return db.CreateTable(file, database, name); }
		public string CreateTableDistinct(string database, string table, string name) { return db.CreateTableDistinct(file, database, table, name); }
		public string CreateColumn(string database, string table, string name, string type) { return db.CreateColumn(file, database, table, name, type); }
		public void CreateRow(string database, string table) { db.CreateRow(file, database, table); }
		public void RenameDatabase(string database, string name) { db.RenameDatabase(file, database, name); }
		public void RenameTable(string database, string table, string name) { db.RenameTable(file, database, table, name); }
		public void SetValue(string database, string table, string column, int row, string value) { db.SetValue(file, database, table, column, row, value); }
		public List<KeyValuePair<string, DatabaseData>> GetDatabases() { return db.GetDatabases(file).Select(i => new KeyValuePair<string, DatabaseData> { Key = i.Key, Value = Convert(i.Value) }).ToList(); }
		public List<KeyValuePair<string, TableData>> GetTables(string database) { return db.GetTables(file, database).Select(i => new KeyValuePair<string, TableData> { Key = i.Key, Value = Convert(i.Value) }).ToList(); }
		public List<KeyValuePair<string, Column>> GetColumns(string database, string table) { return db.GetColumns(file, database, table).Select(i => new KeyValuePair<string, Column> { Key = i.Key, Value = Convert(i.Value) }).ToList(); }
		public void DeleteDatabase(string database) { db.DeleteDatabase(file, database); }
		public void DeleteTable(string database, string table) { db.DeleteTable(file, database, table); }
		public void DeleteColumn(string database, string table, string column) { db.DeleteColumn(file, database, table, column); }
		public void DeleteRow(string database, string table, int row) { db.DeleteRow(file, database, table, row); }
	}
}
