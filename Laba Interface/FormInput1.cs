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
	public partial class FormInput1 : Form
	{
		public FormInput1(string text)
		{
			InitializeComponent();
			label.Text = text;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
