using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_Interface.Providers
{
	class IDB_ASMX : IDB, IDisposable
	{
		ASMX_ProxyClass.SharedDatabase service = null;

		public IDB_ASMX()
		{
			service = new ASMX_ProxyClass.SharedDatabase();
			service.Url = "http://localhost:7777/SharedDatabase.asmx";
			service.Timeout = 100 * 1000;
		}

		private COM_Laba.DatabaseData Convert(ASMX_ProxyClass.DatabaseData databaseData) { return new COM_Laba.DatabaseData() { Name = databaseData.Name, Tables = databaseData.Tables }; }
		private COM_Laba.TableData Convert(ASMX_ProxyClass.TableData tableData) { return new COM_Laba.TableData() { Name = tableData.Name, Columns = tableData.Columns, Rows = tableData.Rows }; }
		private COM_Laba.Column Convert(ASMX_ProxyClass.Column column) { return new COM_Laba.Column() { Name = column.Name, Type = column.Type, Values = Convert(column.Values) }; }
		private List<COM_Laba.Value> Convert(ASMX_ProxyClass.Value[] values) { var res = new List<COM_Laba.Value>(); for (int i = 0; i < values.Length; i++) res.Add(Convert(values[i])); return res; }
		private COM_Laba.Value Convert(ASMX_ProxyClass.Value value) { return new COM_Laba.Value() { Data = value.Data }; }

		public string CreateDatabase(string name) { return service.CreateDatabase(name); }
		public string CreateTable(string database, string name) { return service.CreateTable(database, name); }
		public string CreateTableDistinct(string database, string table, string name) { return service.CreateTableDistinct(database, table, name); }
		public string CreateColumn(string database, string table, string name, string type) { return service.CreateColumn(database, table, name, type); }
		public void CreateRow(string database, string table) { service.CreateRow(database, table); }
		public void RenameDatabase(string database, string name) { service.RenameDatabase(database, name); }
		public void RenameTable(string database, string table, string name) { service.RenameTable(database, table, name); }
		public void SetValue(string database, string table, string column, int row, string value) { service.SetValue(database, table, column, row, value); }
		public Dictionary<string, COM_Laba.DatabaseData> GetDatabases() { return service.GetDatabases().ToDictionary(i => i.Key, i => Convert(i.Value)); }
		public Dictionary<string, COM_Laba.TableData> GetTables(string database) { return service.GetTables(database).ToDictionary(i => i.Key, i => Convert(i.Value)); }
		public Dictionary<string, COM_Laba.Column> GetColumns(string database, string table) { return service.GetColumns(database, table).ToDictionary(i => i.Key, i => Convert(i.Value)); }
		public void DeleteDatabase(string database) { service.DeleteDatabase(database); }
		public void DeleteTable(string database, string table) { service.DeleteTable(database, table); }
		public void DeleteColumn(string database, string table, string column) { service.DeleteColumn(database, table, column); }
		public void DeleteRow(string database, string table, int row) { service.DeleteRow(database, table, row); }

		public void Dispose()
		{
			service.Dispose();
		}
	}
}
