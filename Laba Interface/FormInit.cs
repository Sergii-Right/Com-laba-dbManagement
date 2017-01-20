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
	public partial class FormInit : Form
	{
		public FormInit(IDB db)
		{
			InitializeComponent();
			new FormMain(db).Show();
			Hide();
		}

		private void FormInit_Shown(object sender, EventArgs e)
		{
			Hide();
		}
	}
}
