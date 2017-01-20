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
	public partial class FormInput2 : Form
	{
		public FormInput2(string text1, string text2)
		{
			InitializeComponent();
			label1.Text = text1;
			label2.Text = text2;
		}

		private void button_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
