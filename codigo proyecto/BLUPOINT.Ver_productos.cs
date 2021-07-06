// BLUPOINT.Ver_productos
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT.Source;

public class Ver_productos : Form
{
	private Productos prod = new Productos();

	private IContainer components = null;

	private DataGridView dgvprod;

	private Button button1;

	public Ver_productos()
	{
		InitializeComponent();
		dgvprod.DataSource = prod.ProdFaltantes();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		dgvprod = new System.Windows.Forms.DataGridView();
		button1 = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)dgvprod).BeginInit();
		SuspendLayout();
		dgvprod.BackgroundColor = System.Drawing.Color.White;
		dgvprod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgvprod.GridColor = System.Drawing.Color.White;
		dgvprod.Location = new System.Drawing.Point(1, 2);
		dgvprod.Name = "dgvprod";
		dgvprod.Size = new System.Drawing.Size(694, 315);
		dgvprod.TabIndex = 0;
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(216, 323);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(194, 46);
		button1.TabIndex = 1;
		button1.Text = "Aceptar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(696, 366);
		base.Controls.Add(button1);
		base.Controls.Add(dgvprod);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Ver_productos";
		Text = "Ver_productos";
		((System.ComponentModel.ISupportInitialize)dgvprod).EndInit();
		ResumeLayout(false);
	}
}
