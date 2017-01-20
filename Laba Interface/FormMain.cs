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
	public partial class FormMain : Form
	{
		IDB db = null;

		public FormMain(IDB db)
		{
			this.db = db;
			InitializeComponent();
			Redraw();
		}

		public void Redraw()
		{
			dataGridView.ClearSelection();
			DataTable databases = new DataTable() { TableName = "Databases" };
			databases.Columns.Add("Id", typeof(string));
			databases.Columns.Add("Name", typeof(string));
			databases.Columns.Add("Tables", typeof(int));
			foreach (var database in db.GetDatabases())
				databases.Rows.Add(database.Key, database.Value.Name, database.Value.Tables);
			dataGridView.DataSource = databases;
		}

		private void buttonCreate_Click(object sender, EventArgs e)
		{
			using (var form = new FormInput1("Name"))
			{
				form.ShowDialog(this);
				db.CreateDatabase(form.textBox.Text);
			}
			Redraw();
		}

		private void buttonEdit_Click(object sender, EventArgs e)
		{
			new FormDatabase(db, (string)dataGridView.SelectedRows[0].Cells["Id"].Value).Show();
			Close();
		}

		private void buttonRename_Click(object sender, EventArgs e)
		{
			using (var form = new FormInput1("Name"))
			{
				form.ShowDialog(this);
				db.RenameDatabase((string)dataGridView.SelectedRows[0].Cells["Id"].Value, form.textBox.Text);
			}
			Redraw();
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				db.DeleteDatabase((string)dataGridView.SelectedRows[0].Cells["Id"].Value);
				Redraw();
			}
		}
	}
}
