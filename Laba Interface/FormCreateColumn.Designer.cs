namespace Laba_Interface
{
	partial class FormCreateColumn
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// button
			// 
			this.button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button.Location = new System.Drawing.Point(78, 122);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size(75, 23);
			this.button.TabIndex = 9;
			this.button.Text = "OK";
			this.button.UseVisualStyleBackColor = true;
			this.button.Click += new System.EventHandler(this.button_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 77);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Type";
			// 
			// textBox
			// 
			this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox.Location = new System.Drawing.Point(22, 50);
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(195, 20);
			this.textBox.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Name";
			// 
			// comboBox
			// 
			this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox.FormattingEnabled = true;
			this.comboBox.Items.AddRange(new object[] {
            "Integer",
            "String",
            "Real",
            "Complex Integer",
            "Complex Real"});
			this.comboBox.Location = new System.Drawing.Point(25, 95);
			this.comboBox.Name = "comboBox";
			this.comboBox.Size = new System.Drawing.Size(192, 21);
			this.comboBox.TabIndex = 10;
			// 
			// FormCreateColumn
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(236, 178);
			this.Controls.Add(this.comboBox);
			this.Controls.Add(this.button);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox);
			this.Controls.Add(this.label1);
			this.Name = "FormCreateColumn";
			this.Text = "FormCreateColumn";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox textBox;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.ComboBox comboBox;
	}
}