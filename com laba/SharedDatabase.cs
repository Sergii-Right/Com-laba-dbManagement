using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace COM_Laba
{
	[Guid("DC5D000F-6503-4202-95CB-C56D94C2605B")]
	[ComVisible(true)]
	public interface ISharedDatabaseLocal
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

	[Guid("11126EF8-1838-436B-AAB7-0D9E905E2403")]
	[ComVisible(true)]
	public interface ISharedDatabase
	{
		void InitFile(string file);
		string CreateDatabase(string file, string name);
		string CreateTable(string file, string database, string name);
		string CreateTableDistinct(string file, string database, string table, string name);
		string CreateColumn(string file, string database, string table, string name, string type);
		void CreateRow(string file, string database, string table);
		void RenameDatabase(string file, string database, string name);
		void RenameTable(string file, string database, string table, string name);
		void SetValue(string file, string database, string table, string column, int row, string value);
		Dictionary<string, DatabaseData> GetDatabases(string file);
		Dictionary<string, TableData> GetTables(string file, string database);
		Dictionary<string, Column> GetColumns(string file, string database, string table);
		void DeleteDatabase(string file, string database);
		void DeleteTable(string file, string database, string table);
		void DeleteColumn(string file, string database, string table, string column);
		void DeleteRow(string file, string database, string table, int row);
		string Test(string text);
	}

	[Guid("4B75A307-24AC-4B0E-BB0A-0E492ABA21AA")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	public class SharedDatabase : ISharedDatabase
	{
		public void InitFile(string file)
		{
			if (!File.Exists(file))
			{
				File.Create(file);
				File.SetAttributes(file, FileAttributes.Normal);
				File.WriteAllText(file, Method.Serializer.Serialize(new Data()));
			}
		}

		public string CreateDatabase(string file, string name)
		{
			var data = Method.Serializer.Deserialize<Data>(File.ReadAllText(file));
			string id = Method.GenGUID();
			data.Databases.Add(id, new Database() { Name = name });
			File.WriteAllText(file, Method.Serializer.Serialize(data));
			return id;
		}

		public string CreateTable(string file, string database, string name)
		{
			var data = Method.Serializer.Deserialize<Data>(File.ReadAllText(file));
			string id = Method.GenGUID();
			data.Databases[database].Tables.Add(id, new Table() { Name = name });
			File.WriteAllText(file, Method.Serializer.Serialize(data));
			return id;
		}

		public string CreateTableDistinct(string file, string database, string table, string name)
		{
			var data = Method.Serializer.Deserialize<Data>(File.ReadAllText(file));
			string id = Method.GenGUID();
			data.Databases[database].Tables.Add(id, Method.Distinct(name, data.Databases[database].Tables[table]));
			File.WriteAllText(file, Method.Serializer.Serialize(data));
			return id;
		}

		public string CreateColumn(string file, string database, string table, string name, string type)
		{
			if (!new string[] { "Integer", "Real", "String", "Complex Real", "Complex Integer" }.Contains(type)) return "Not Valid Type";
			var data = Method.Serializer.Deserialize<Data>(File.ReadAllText(file));
			string id = Method.GenGUID();
			int rows = data.Databases[database].Tables[table].Columns.DefaultIfEmpty(new KeyValuePair<string, Column>("", new Column())).Max(j => j.Value.Values.Count);
			data.Databases[database].Tables[table].Columns.Add(id, new Column() { Name = name, Type = type, Values = Enumerable.Range(0, rows).Select(x => new Value()).ToList() });
			File.WriteAllText(file, Method.Serializer.Serialize(data));
			return id;
		}

		public void CreateRow(string file, string database, string table)
		{
			var data = Method.Serializer.Deserialize<Data>(File.ReadAllText(file));
			foreach (var column in data.Databases[database].Tables[table].Columns)
				column.Value.Values.Add(new Value());
			File.WriteAllText(file, Method.Serializer.Serialize(data));
		}

		public void RenameDatabase(string file, string database, string name)
		{
			var data = Method.Serializer.Deserialize<Data>(File.ReadAllText(file));
			data.Databases[database].Name = name;
			File.WriteAllText(file, Method.Serializer.Serialize(data));
		}

		public void RenameTable(string file, string database, string table, string name)
		{
			var data = Method.Serializer.Deserialize<Data>(File.ReadAllText(file));
			data.Databases[database].Tables[table].Name = name;
			File.WriteAllText(file, Method.Serializer.Serialize(data));
		}

		public void SetValue(string file, string database, string table, string column, int row, string value)
		{
			var data = Method.Serializer.Deserialize<Data>(File.ReadAllText(file));
			data.Databases[database].Tables[table].Columns[column].Values[row].Data = value;
			File.WriteAllText(file, Method.Serializer.Serialize(data));
		}

		public Dictionary<string, DatabaseData> GetDatabases(string file)
		{
			var data = Method.Serializer.Deserialize<Data>(File.ReadAllText(file));
			return data.Databases.ToDictionary(i => i.Key, i => new DatabaseData() { Name = i.Value.Name, Tables = i.Value.Tables.Count });
		}

		public Dictionary<string, TableData> GetTables(string file, string database)
		{
			var data = Method.Serializer.Deserialize<Data>(File.ReadAllText(file));
			return data.Databases[database].Tables.ToDictionary(i => i.Key, i => new TableData() { Name = i.Value.Name, Columns = i.Value.Columns.Count, Rows = i.Value.Columns.DefaultIfEmpty(new KeyValuePair<string, Column>("", new Column())).Max(j => j.Value.Values.Count) });
		}

		public Dictionary<string, Column> GetColumns(string file, string database, string table)
		{
			var data = Method.Serializer.Deserialize<Data>(File.ReadAllText(file));
			return data.Databases[database].Tables[table].Columns;
		}

		public void DeleteDatabase(string file, string database)
		{
			var data = Method.Serializer.Deserialize<Data>(File.ReadAllText(file));
			data.Databases.Remove(database);
			File.WriteAllText(file, Method.Serializer.Serialize(data));
		}

		public void DeleteTable(string file, string database, string table)
		{
			var data = Method.Serializer.Deserialize<Data>(File.ReadAllText(file));
			data.Databases[database].Tables.Remove(table);
			File.WriteAllText(file, Method.Serializer.Serialize(data));
		}

		public void DeleteColumn(string file, string database, string table, string column)
		{
			var data = Method.Serializer.Deserialize<Data>(File.ReadAllText(file));
			data.Databases[database].Tables[table].Columns.Remove(column);
			File.WriteAllText(file, Method.Serializer.Serialize(data));
		}

		public void DeleteRow(string file, string database, string table, int row)
		{
			var data = Method.Serializer.Deserialize<Data>(File.ReadAllText(file));
			foreach (var column in data.Databases[database].Tables[table].Columns)
				column.Value.Values.RemoveAt(row);
			File.WriteAllText(file, Method.Serializer.Serialize(data));
		}

		public string Test(string text)
		{
			return text;
		}
	}
}
