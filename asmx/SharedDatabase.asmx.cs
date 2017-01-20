using COM_Laba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ASMX
{
	[WebService(Description = "СУБД", Namespace = "http://microsoft.com/webservices/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	//[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class SharedDatabase : WebService
	{
		private COM_Laba.SharedDatabase db = new COM_Laba.SharedDatabase();
		private string file { get { string f = "ASMX.db"; db.InitFile(f); return f; } }

		[Serializable]
		public struct KeyValuePair<K, V>
		{
			public KeyValuePair(K Key, V Value){ this.Key = Key; this.Value = Value; }
			public K Key { get; set; }
			public V Value { get; set; }
		}

		[WebMethod(Description = "Создание базы")]
		public string CreateDatabase(string name) { return db.CreateDatabase(file, name); }

		[WebMethod(Description = "Создание таблицы")]
		public string CreateTable(string database, string name) { return db.CreateTable(file, database, name); }

		[WebMethod(Description = "Создание таблицы без повторений")]
		public string CreateTableDistinct(string database, string table, string name) { return db.CreateTableDistinct(file, database, table, name); }

		[WebMethod(Description = "Создание колонки")]
		public string CreateColumn(string database, string table, string name, string type) { return db.CreateColumn(file, database, table, name, type); }

		[WebMethod(Description = "Создание записи")]
		public void CreateRow(string database, string table) { db.CreateRow(file, database, table); }

		[WebMethod(Description = "Изменение названия базы")]
		public void RenameDatabase(string database, string name) { db.RenameDatabase(file, database, name); }

		[WebMethod(Description = "Изменение названия таблицы")]
		public void RenameTable(string database, string table, string name) { db.RenameTable(file, database, table, name); }

		[WebMethod(Description = "Установка значения ячейки")]
		public void SetValue(string database, string table, string column, int row, string value) { db.SetValue(file, database, table, column, row, value); }

		[WebMethod(Description = "Получения списка баз")]
		public List<KeyValuePair<string, DatabaseData>> GetDatabases() { return db.GetDatabases(file).Select(i=>new KeyValuePair<string, DatabaseData>(i.Key, i.Value)).ToList(); }

		[WebMethod(Description = "Получения списка таблиц")]
		public List<KeyValuePair<string,TableData>> GetTables(string database) { return db.GetTables(file, database).Select(i => new KeyValuePair<string, TableData>(i.Key, i.Value)).ToList(); }

		[WebMethod(Description = "Получения списка колонок")]
		public List<KeyValuePair<string, Column>> GetColumns(string database, string table) { return db.GetColumns(file, database, table).Select(i => new KeyValuePair<string, Column>(i.Key, i.Value)).ToList(); }

		[WebMethod(Description = "Удаление базы")]
		public void DeleteDatabase(string database) { db.DeleteDatabase(file, database); }

		[WebMethod(Description = "Удаление таблицы")]
		public void DeleteTable(string database, string table) { db.DeleteTable(file, database, table); }

		[WebMethod(Description = "Удаление колонки")]
		public void DeleteColumn(string database, string table, string column) { db.DeleteColumn(file, database, table, column); }

		[WebMethod(Description = "Удаление записи")]
		public void DeleteRow(string database, string table, int row) { db.DeleteRow(file, database, table, row); }
	}
}
