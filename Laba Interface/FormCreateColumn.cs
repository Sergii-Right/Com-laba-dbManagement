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
    public partial class FormCreateColumn: Form
    {
        public FormCreateColumn()
        {
            InitializeComponent();
			comboBox.SelectedIndex = 0;
        }

		private void button_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
