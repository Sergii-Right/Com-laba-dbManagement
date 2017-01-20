using ExtendedXmlSerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM_Laba
{
	[Serializable]
	public class Data
	{
		public Dictionary<string, Database> Databases = new Dictionary<string, Database>();
	}

	[Serializable]
	public class Database
	{
		public string Name = "";
		public Dictionary<string, Table> Tables = new Dictionary<string, Table>();
	}

	[Serializable]
	public class DatabaseData
	{
		public string Name = "";
		public int Tables = 0;
	}

	[Serializable]
	public class Table
	{
		public string Name = "";
		public Dictionary<string, Column> Columns = new Dictionary<string, Column>();
	}

	[Serializable]
	public class TableData
	{
		public string Name = "";
		public int Columns = 0;
		public int Rows = 0;
	}

	[Serializable]
	public class Column
	{
		public string Name = "";
		public string Type = "";
		public List<Value> Values = new List<Value>();
	}

	[Serializable]
	public class Value
	{
		public string Data = "";
	}

	public static class Method
	{
		public static ExtendedXmlSerializer Serializer = new ExtendedXmlSerializer();
		public static string GenGUID()
		{
			return Guid.NewGuid().ToString();
		}
		private static bool EqualsRow(Table table, int rowA, int rowB)
		{	
			foreach (var column in table.Columns)
			if ((rowA<column.Value.Values.Count && rowB>=column.Value.Values.Count) ||
				(rowB<column.Value.Values.Count && rowA>=column.Value.Values.Count) || 
				(rowA<column.Value.Values.Count && rowB<column.Value.Values.Count &&
					column.Value.Values[rowA].Data!=column.Value.Values[rowB].Data))
				return false;
			return true;
		}
		public static Table Distinct(string name, Table table)
		{
			var result = new Table(){Name=name};
			int rows=table.Columns.Max(i=>i.Value.Values.Count);
			List<int> addRow = new List<int>();
			for(int i=0;i<rows;i++)
			{
				bool ok = true;
				for(int j=i+1;j<rows && ok;j++)
					if (EqualsRow(table, i, j))
						ok = false;
				if (ok) addRow.Add(i);
			}
			foreach (var column in table.Columns)
			{
				List<Value> values = new List<Value>();
				foreach (int row in addRow)
					if (row<column.Value.Values.Count)
						values.Add(new Value(){Data=column.Value.Values[row].Data});
				result.Columns.Add(GenGUID(), new Column(){Name=column.Value.Name, Type=column.Value.Type, Values=values});
			}
			return result;
		}
	}
}