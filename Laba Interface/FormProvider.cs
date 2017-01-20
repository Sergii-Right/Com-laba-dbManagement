using Laba_Interface.Providers;
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
	public partial class FormProvider : Form
	{
		public IDB db = null;

		private List<KeyValuePair<IDB, string>> GetDBs()
		{
			List<KeyValuePair<IDB, string>> res = new List<KeyValuePair<IDB, string>>();
			res.Add(new KeyValuePair<IDB, string>(new IDB_COM(), "COM"));
			res.Add(new KeyValuePair<IDB, string>(new IDB_webAPI(), "WebApi (Rest)"));
			res.Add(new KeyValuePair<IDB, string>(new IDB_ASMX(), "ASMX"));
			res.Add(new KeyValuePair<IDB, string>(new IDB_WCF(), "WCF"));
			res.Add(new KeyValuePair<IDB, string>(new IDB_ASMX_FOR_WCF(), "ASMX for WCF"));
			res.Add(new KeyValuePair<IDB, string>(new IDB_Remoting(), "NET Remoting"));
			return res;
		}

		public FormProvider()
		{
			InitializeComponent();
			listBox.DisplayMember = "Value";
			listBox.ValueMember = "Key";
			listBox.ClearSelected();
			ArrayList items = new ArrayList();
			foreach (var item in GetDBs())
				items.Add(item);
			listBox.DataSource = items;
		}

		private void button_Click(object sender, EventArgs e)
		{
			db = (IDB)listBox.SelectedValue;
			Close();
		}
	}
}
