using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceSharedDatabase" in both code and config file together.
	[ServiceContract]
	public interface IServiceSharedDatabase
	{
		[OperationContract]
		string CreateDatabase(string name);
		[OperationContract]
		string CreateTable(string database, string name);
		[OperationContract]
		string CreateTableDistinct(string database, string table, string name);
		[OperationContract]
		string CreateColumn(string database, string table, string name, string type);
		[OperationContract]
		void CreateRow(string database, string table);
		[OperationContract]
		void RenameDatabase(string database, string name);
		[OperationContract]
		void RenameTable(string database, string table, string name);
		[OperationContract]
		void SetValue(string database, string table, string column, int row, string value);
		[OperationContract]
		List<KeyValuePair<string, DatabaseData>> GetDatabases();
		[OperationContract]
		List<KeyValuePair<string, TableData>> GetTables(string database);
		[OperationContract]
		List<KeyValuePair<string, Column>> GetColumns(string database, string table);
		[OperationContract]
		void DeleteDatabase(string database);
		[OperationContract]
		void DeleteTable(string database, string table);
		[OperationContract]
		void DeleteColumn(string database, string table, string column);
		[OperationContract]
		void DeleteRow(string database, string table, int row);
	}

	[DataContract]
	public struct KeyValuePair<K, V>
	{
		public K key { get; set; }
		public V value { get; set; }

		[DataMember]
		public K Key
		{
			get { return key; }
			set { key = value; }
		}

		[DataMember]
		public V Value
		{
			get { return value; }
			set { this.value = value; }
		}
	}

	[DataContract]
	public class DatabaseData
	{
		public string name = "";
		public int tables = 0;

		[DataMember]
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		[DataMember]
		public int Tables
		{
			get { return tables; }
			set { tables = value; }
		}
	}

	[DataContract]
	public class TableData
	{
		public string name = "";
		public int columns = 0;
		public int rows = 0;

		[DataMember]
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		[DataMember]
		public int Columns
		{
			get { return columns; }
			set { columns = value; }
		}

		[DataMember]
		public int Rows
		{
			get { return rows; }
			set { rows = value; }
		}
	}

	[DataContract]
	public class Column
	{
		public string name = "";
		public string type = "";
		public List<Value> values = new List<Value>();

		[DataMember]
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		[DataMember]
		public string Type
		{
			get { return type; }
			set { type = value; }
		}

		[DataMember]
		public List<Value> Values
		{
			get { return values; }
			set { values = value; }
		}
	}

	[DataContract]
	public class Value
	{
		public string data = "";

		[DataMember]
		public string Data
		{
			get { return data; }
			set { data = value; }
		}
	}

}
