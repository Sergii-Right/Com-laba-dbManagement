using COM_Laba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_Interface
{
	public interface IDB
	{
		string CreateDatabase(string name);
		string CreateTable(string database, string name);
		string CreateTableDistinct(string database, string table, string name);
		string CreateColumn(string database, string table, string name, string type);
		void CreateRow(string database, string table);
		void RenameDatabase(string database, string name);
		void RenameTable(string database, string table, string name);
		void SetValue(string database, string table, string column, int row, string value);
		Dictionary<string, DatabaseData> GetDatabases();
		Dictionary<string, TableData> GetTables(string database);
		Dictionary<string, Column> GetColumns(string database, string table);
		void DeleteDatabase(string database);
		void DeleteTable(string database, string table);
		void DeleteColumn(string database, string table, string column);
		void DeleteRow(string database, string table, int row);
	}
}
