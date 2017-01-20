namespace Laba_Interface
{
	partial class FormTable
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateRow = new System.Windows.Forms.Button();
            this.buttonCreateColumn = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDeleteRow = new System.Windows.Forms.Button();
            this.buttonDeleteColumn = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.Location = new System.Drawing.Point(12, 13);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.Size = new System.Drawing.Size(415, 353);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonCreateRow
            // 
            this.buttonCreateRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCreateRow.BackColor = System.Drawing.Color.LightGreen;
            this.buttonCreateRow.Location = new System.Drawing.Point(433, 13);
            this.buttonCreateRow.Name = "buttonCreateRow";
            this.buttonCreateRow.Size = new System.Drawing.Size(84, 23);
            this.buttonCreateRow.TabIndex = 1;
            this.buttonCreateRow.Text = "Create Row";
            this.buttonCreateRow.UseVisualStyleBackColor = false;
            this.buttonCreateRow.Click += new System.EventHandler(this.buttonCreateRow_Click);
            // 
            // buttonCreateColumn
            // 
            this.buttonCreateColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCreateColumn.BackColor = System.Drawing.Color.LightGreen;
            this.buttonCreateColumn.Location = new System.Drawing.Point(433, 42);
            this.buttonCreateColumn.Name = "buttonCreateColumn";
            this.buttonCreateColumn.Size = new System.Drawing.Size(84, 23);
            this.buttonCreateColumn.TabIndex = 2;
            this.buttonCreateColumn.Text = "Create Colunm";
            this.buttonCreateColumn.UseVisualStyleBackColor = false;
            this.buttonCreateColumn.Click += new System.EventHandler(this.buttonCreateColumn_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.BackColor = System.Drawing.Color.DarkOrange;
            this.buttonEdit.Location = new System.Drawing.Point(433, 71);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(84, 23);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDeleteRow
            // 
            this.buttonDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteRow.BackColor = System.Drawing.Color.Red;
            this.buttonDeleteRow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonDeleteRow.Location = new System.Drawing.Point(433, 100);
            this.buttonDeleteRow.Name = "buttonDeleteRow";
            this.buttonDeleteRow.Size = new System.Drawing.Size(84, 23);
            this.buttonDeleteRow.TabIndex = 4;
            this.buttonDeleteRow.Text = "Delete Row";
            this.buttonDeleteRow.UseVisualStyleBackColor = false;
            this.buttonDeleteRow.Click += new System.EventHandler(this.buttonDeleteRow_Click);
            // 
            // buttonDeleteColumn
            // 
            this.buttonDeleteColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteColumn.BackColor = System.Drawing.Color.Red;
            this.buttonDeleteColumn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonDeleteColumn.Location = new System.Drawing.Point(433, 129);
            this.buttonDeleteColumn.Name = "buttonDeleteColumn";
            this.buttonDeleteColumn.Size = new System.Drawing.Size(84, 23);
            this.buttonDeleteColumn.TabIndex = 5;
            this.buttonDeleteColumn.Text = "Delete Column";
            this.buttonDeleteColumn.UseVisualStyleBackColor = false;
            this.buttonDeleteColumn.Click += new System.EventHandler(this.buttonDeleteColumn_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBack.BackColor = System.Drawing.Color.LightGray;
            this.buttonBack.Location = new System.Drawing.Point(433, 158);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(84, 23);
            this.buttonBack.TabIndex = 6;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // FormTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 378);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonDeleteColumn);
            this.Controls.Add(this.buttonDeleteRow);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonCreateColumn);
            this.Controls.Add(this.buttonCreateRow);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormTable";
            this.Text = "Table";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button buttonCreateRow;
		private System.Windows.Forms.Button buttonCreateColumn;
		private System.Windows.Forms.Button buttonEdit;
		private System.Windows.Forms.Button buttonDeleteRow;
		private System.Windows.Forms.Button buttonDeleteColumn;
		private System.Windows.Forms.Button buttonBack;
	}
}