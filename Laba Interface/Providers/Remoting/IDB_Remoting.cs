using COM_Laba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace Laba_Interface.Providers
{
	class IDB_Remoting : IDB
	{
		private ISharedDatabaseLocal db = null;

		public IDB_Remoting()
		{
			TcpChannel tcpChannel = new TcpChannel();
			ChannelServices.RegisterChannel(tcpChannel, false);
			db = (ISharedDatabaseLocal)Activator.GetObject(typeof(ISharedDatabaseLocal), "tcp://localhost:9999/SharedDatabase");
		}

		public string CreateDatabase(string name) { return db.CreateDatabase(name); }
		public string CreateTable(string database, string name) { return db.CreateTable(database, name); }
		public string CreateTableDistinct(string database, string table, string name) { return db.CreateTableDistinct(database, table, name); }
		public string CreateColumn(string database, string table, string name, string type) { return db.CreateColumn(database, table, name, type); }
		public void CreateRow(string database, string table) { db.CreateRow(database, table); }
		public void RenameDatabase(string database, string name) { db.RenameDatabase(database, name); }
		public void RenameTable(string database, string table, string name) { db.RenameTable(database, table, name); }
		public void SetValue(string database, string table, string column, int row, string value) { db.SetValue(database, table, column, row, value); }
		public Dictionary<string, DatabaseData> GetDatabases() { return db.GetDatabases(); }
		public Dictionary<string, TableData> GetTables(string database) { return db.GetTables(database); }
		public Dictionary<string, Column> GetColumns(string database, string table) { return db.GetColumns(database, table); }
		public void DeleteDatabase(string database) { db.DeleteDatabase(database); }
		public void DeleteTable(string database, string table) { db.DeleteTable(database, table); }
		public void DeleteColumn(string database, string table, string column) { db.DeleteColumn(database, table, column); }
		public void DeleteRow(string database, string table, int row) { db.DeleteRow(database, table, row); }
	}
}
