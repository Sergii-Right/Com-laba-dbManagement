using System;
using System.Collections;
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
	public partial class FormDatabase : Form
	{
		IDB db = null;
		string database = null;

		public FormDatabase(IDB db, string database)
		{
			this.db = db;
			this.database = database;
			InitializeComponent();
			Text = "Database " + db.GetDatabases()[database].Name;
			Redraw();
		}

		public void Redraw()
		{
			dataGridView.ClearSelection();
			DataTable tables = new DataTable() { TableName = "Tables" };
			tables.Columns.Add("Id", typeof(string));
			tables.Columns.Add("Name", typeof(string));
			tables.Columns.Add("Columns", typeof(int));
			tables.Columns.Add("Rows", typeof(int));
			foreach (var table in db.GetTables(database))
				tables.Rows.Add(table.Key, table.Value.Name, table.Value.Columns, table.Value.Rows);
			dataGridView.DataSource = tables;
		}

		private void buttonCreate_Click(object sender, EventArgs e)
		{
			using (var form = new FormInput1("Name"))
			{
				form.ShowDialog(this);
				db.CreateTable(database, form.textBox.Text);
			}
			Redraw();
		}

		private void buttonCreateDistinct_Click(object sender, EventArgs e)
		{
			using (var form = new FormInput1("Name"))
			{
				form.ShowDialog(this);
				db.CreateTableDistinct(database, (string)dataGridView.SelectedRows[0].Cells["Id"].Value, form.textBox.Text);
			}
			Redraw();
		}

		private void buttonEdit_Click(object sender, EventArgs e)
		{
			new FormTable(db, database,(string)dataGridView.SelectedRows[0].Cells["Id"].Value).Show();
			Close();
		}

		private void buttonRename_Click(object sender, EventArgs e)
		{
			using (var form = new FormInput1("Name"))
			{
				form.ShowDialog(this);
				db.RenameTable(database, (string)dataGridView.SelectedRows[0].Cells["Id"].Value, form.textBox.Text);
			}
			Redraw();
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				db.DeleteTable(database, (string)dataGridView.SelectedRows[0].Cells["Id"].Value);
				Redraw();
			}
		}

		private void buttonBack_Click(object sender, EventArgs e)
		{
			new FormMain(db).Show();
			Close();
		}
	}
}
