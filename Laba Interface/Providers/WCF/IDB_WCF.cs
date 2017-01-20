using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF;

namespace Laba_Interface.Providers
{
	class IDB_WCF : IDB
	{
		private ServiceSharedDatabaseClient client = null;

		public IDB_WCF()
		{
			var binding = new BasicHttpBinding()
			{
				Name = "BasicHttpBinding_IServiceSharedDatabase",
				MaxBufferSize = 2147483647,
				MaxReceivedMessageSize = 2147483647
			};
			var endpoint = new EndpointAddress("http://localhost:8888/ServiceSharedDatabase.svc");
			client = new ServiceSharedDatabaseClient(binding, endpoint);
		}

		private COM_Laba.DatabaseData Convert(DatabaseData databaseData) { return new COM_Laba.DatabaseData { Name = databaseData.Name, Tables = databaseData.Tables }; }
		private COM_Laba.TableData Convert(TableData tableData) { return new COM_Laba.TableData { Name = tableData.Name, Columns = tableData.Columns, Rows = tableData.Rows }; }
		private COM_Laba.Column Convert(Column column) { return new COM_Laba.Column { Name = column.Name, Type = column.Type, Values = Convert(column.Values) }; }
		private List<COM_Laba.Value> Convert(Value[] values) { var res = new List<COM_Laba.Value>(); for (int i = 0; i < values.Length; i++) res.Add(Convert(values[i])); return res; }
		private COM_Laba.Value Convert(Value value) { return new COM_Laba.Value { Data = value.Data }; }

		public string CreateDatabase(string name) { return client.CreateDatabase(name); }
		public string CreateTable(string database, string name) { return client.CreateTable(database, name); }
		public string CreateTableDistinct(string database, string table, string name) { return client.CreateTableDistinct(database, table, name); }
		public string CreateColumn(string database, string table, string name, string type) { return client.CreateColumn(database, table, name, type); }
		public void CreateRow(string database, string table) { client.CreateRow(database, table); }
		public void RenameDatabase(string database, string name) { client.RenameDatabase(database, name); }
		public void RenameTable(string database, string table, string name) { client.RenameTable(database, table, name); }
		public void SetValue(string database, string table, string column, int row, string value) { client.SetValue(database, table, column, row, value); }
		public Dictionary<string, COM_Laba.DatabaseData> GetDatabases() { return client.GetDatabases().ToDictionary(i => i.Key, i => Convert(i.Value)); }
		public Dictionary<string, COM_Laba.TableData> GetTables(string database) { return client.GetTables(database).ToDictionary(i => i.Key, i => Convert(i.Value)); }
		public Dictionary<string, COM_Laba.Column> GetColumns(string database, string table) { return client.GetColumns(database, table).ToDictionary(i => i.Key, i => Convert(i.Value)); }
		public void DeleteDatabase(string database) { client.DeleteDatabase(database); }
		public void DeleteTable(string database, string table) { client.DeleteTable(database, table); }
		public void DeleteColumn(string database, string table, string column) { client.DeleteColumn(database, table, column); }
		public void DeleteRow(string database, string table, int row) { client.DeleteRow(database, table, row); }
	}
}
