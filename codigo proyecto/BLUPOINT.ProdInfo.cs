// BLUPOINT.ProdInfo
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT.Source;

public class ProdInfo : Form
{
	private Productos prod = new Productos();

	private DataTable dt = new DataTable();

	private string code = "";

	private IContainer components = null;

	private Label label1;

	private Panel panel1;

	private Button button1;

	private Label txtNp;

	private Label label3;

	private Label txtPrecio;

	public ProdInfo(string codigo)
	{
		code = codigo;
		InitializeComponent();
		CargarDatos();
	}

	public void CargarDatos()
	{
		prod.Codigo = code;
		dt = prod.GET();
		txtNp.Text = dt.Rows[0]["Nombre_P"].ToString();
		txtPrecio.Text = dt.Rows[0]["Precio"].ToString();
	}

	private void ProdInfo_Load(object sender, EventArgs e)
	{
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
		label1 = new System.Windows.Forms.Label();
		panel1 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		txtNp = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		txtPrecio = new System.Windows.Forms.Label();
		panel1.SuspendLayout();
		SuspendLayout();
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(12, 40);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(474, 45);
		label1.TabIndex = 0;
		label1.Text = "INFORMACION DEL PRODCUTO";
		panel1.BackColor = System.Drawing.Color.SteelBlue;
		panel1.Controls.Add(button1);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(503, 37);
		panel1.TabIndex = 1;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(457, 3);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(44, 31);
		button1.TabIndex = 0;
		button1.Text = "X";
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		txtNp.AutoSize = true;
		txtNp.Font = new System.Drawing.Font("Segoe UI", 26.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtNp.Location = new System.Drawing.Point(98, 112);
		txtNp.Name = "txtNp";
		txtNp.Size = new System.Drawing.Size(290, 47);
		txtNp.TabIndex = 2;
		txtNp.Text = "Producto Suavel";
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 72f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.ForeColor = System.Drawing.Color.Green;
		label3.Location = new System.Drawing.Point(12, 180);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(110, 128);
		label3.TabIndex = 3;
		label3.Text = "$";
		txtPrecio.AutoSize = true;
		txtPrecio.Font = new System.Drawing.Font("Segoe UI", 72f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtPrecio.ForeColor = System.Drawing.Color.Green;
		txtPrecio.Location = new System.Drawing.Point(174, 180);
		txtPrecio.Name = "txtPrecio";
		txtPrecio.Size = new System.Drawing.Size(191, 128);
		txtPrecio.TabIndex = 4;
		txtPrecio.Text = "0.0";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(503, 331);
		base.Controls.Add(txtPrecio);
		base.Controls.Add(label3);
		base.Controls.Add(txtNp);
		base.Controls.Add(panel1);
		base.Controls.Add(label1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "ProdInfo";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "ProdInfo";
		base.Load += new System.EventHandler(ProdInfo_Load);
		panel1.ResumeLayout(false);
		ResumeLayout(false);
		PerformLayout();
	}
}
