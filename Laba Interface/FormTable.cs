using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_Interface
{
	public partial class FormTable : Form
	{
		IDB db = null;
		string database = null;
		string table = null;

		public FormTable(IDB db, string database, string table)
		{
			this.db = db;
			this.database = database;
			this.table = table;
			InitializeComponent();
			Text = "Table " + db.GetTables(database)[table].Name;
			Redraw();
		}

		public void Redraw()
		{
			dataGridView.ClearSelection();
			dataGridView.Rows.Clear();
			dataGridView.Columns.Clear();
			var inputs = db.GetColumns(database, table);
			foreach (var input in inputs)
				dataGridView.Columns.Add(new DataGridViewColumn() { Name = input.Value.Name, ValueType = typeof(string), HeaderText = input.Value.Name + '(' + input.Value.Type + ')', Tag = new Tuple<string, string>(input.Key, input.Value.Type), CellTemplate = new DataGridViewTextBoxCell() });
			int rowsCount = inputs.DefaultIfEmpty(new KeyValuePair<string, COM_Laba.Column>("", new COM_Laba.Column())).Max(i => i.Value.Values.Count);
			for (int rowId = 0; rowId < rowsCount; rowId++)
			{
				List<string> row = new List<string>();
				foreach (var input in inputs)
					if (rowId >= input.Value.Values.Count || input.Value.Values[rowId].Data == "")
						row.Add("(null)");
					else
						row.Add(input.Value.Values[rowId].Data);
				dataGridView.Rows.Add(row.ToArray());
				dataGridView.Rows[rowId].Tag = rowId;
			}
		}

		private void buttonCreateRow_Click(object sender, EventArgs e)
		{
			db.CreateRow(database, table);
			Redraw();
		}

		private void buttonCreateColumn_Click(object sender, EventArgs e)
		{
			using (var form = new FormCreateColumn())
			{
				form.ShowDialog(this);
				db.CreateColumn(database, table, form.textBox.Text, form.comboBox.SelectedItem.ToString());
			}
			Redraw();
		}

		private void buttonEdit_Click(object sender, EventArgs e)
		{
			string type = ((Tuple<string, string>)dataGridView.SelectedCells[0].OwningColumn.Tag).Item2;
			if (type == "Complex Integer" || type == "Complex Real")
			{
				using (var form = new FormInput2("Real Value", "Complex Value"))
				{
					form.ShowDialog(this);
					string realValue = form.textBox1.Text;
					string complexValue = form.textBox2.Text;
					int tempInt;
					double tempReal;
					switch (type)
					{
						case "Complex Integer":
							if (!int.TryParse(realValue, out tempInt)) realValue = "";
							if (!int.TryParse(complexValue, out tempInt)) complexValue = "";
							break;
						case "Complex Real":
							if (!double.TryParse(realValue, out tempReal)) realValue = "";
							if (!double.TryParse(complexValue, out tempReal)) complexValue = "";
							break;
					}
					db.SetValue(database, table, ((Tuple<string, string>)dataGridView.SelectedCells[0].OwningColumn.Tag).Item1, (int)dataGridView.SelectedCells[0].OwningRow.Tag, ((realValue != "" && complexValue != "") ? realValue + "+" + complexValue + "*I" : ""));
				}
			}
			else
			{
				using (var form = new FormInput1("Value"))
				{
					form.ShowDialog(this);
					string value = form.textBox.Text;
					int tempInt;
					double tempReal;
					switch (type)
					{
						case "Integer":
							if (!int.TryParse(value, out tempInt)) value = "";
							break;
						case "Real":
							if (!double.TryParse(value, out tempReal)) value = "";
							break;
					}
					db.SetValue(database, table, ((Tuple<string, string>)dataGridView.SelectedCells[0].OwningColumn.Tag).Item1, (int)dataGridView.SelectedCells[0].OwningRow.Tag, value);
				}
			}
			Redraw();
		}

		private void buttonDeleteRow_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				db.DeleteRow(database, table, (int)dataGridView.SelectedCells[0].OwningRow.Tag);
				Redraw();
			}
		}

		private void buttonDeleteColumn_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				db.DeleteColumn(database, table, ((Tuple<string, string>)dataGridView.SelectedCells[0].OwningColumn.Tag).Item1);
				Redraw();
			}
		}

		private void buttonBack_Click(object sender, EventArgs e)
		{
			new FormDatabase(db, database).Show();
			Close();
		}
	}
}
