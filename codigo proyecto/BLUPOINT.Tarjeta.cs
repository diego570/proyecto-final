// BLUPOINT.Tarjeta
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;

public class Tarjeta : Form
{
	private DataTable t = new DataTable();

	private IContainer components = null;

	private DataGridView Dgv;

	public Tarjeta()
	{
		InitializeComponent();
		load();
	}

	private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void load()
	{
		string[] array = new string[2] { "Tarjeta de Credito", "Tarjeta de Debito" };
		t.Columns.Add("Tipo de Tarjeta");
		for (int i = 0; i < 2; i++)
		{
			Agregar(array[i]);
		}
		Dgv.DataSource = t;
		Dgv.Columns[0].Width = 300;
	}

	private void Agregar(string tarjeta)
	{
		DataRow dataRow = t.NewRow();
		dataRow["Tipo de Tarjeta"] = tarjeta;
		t.Rows.Add(dataRow);
	}

	private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		Pagar pagar = base.Owner as Pagar;
		pagar.lblPay.Text = Dgv.CurrentRow.Cells["Tipo de Tarjeta"].Value.ToString();
		Close();
	}

	private void Tarjeta_Load(object sender, EventArgs e)
	{
	}

	private void Dgv_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			Pagar pagar = base.Owner as Pagar;
			pagar.lblPay.Text = Dgv.CurrentRow.Cells["Tipo de Tarjeta"].Value.ToString();
			Close();
		}
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
		Dgv = new System.Windows.Forms.DataGridView();
		((System.ComponentModel.ISupportInitialize)Dgv).BeginInit();
		SuspendLayout();
		Dgv.AllowUserToAddRows = false;
		Dgv.AllowUserToDeleteRows = false;
		Dgv.AllowUserToResizeColumns = false;
		Dgv.BackgroundColor = System.Drawing.Color.White;
		Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		Dgv.Location = new System.Drawing.Point(0, 2);
		Dgv.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
		Dgv.Name = "Dgv";
		Dgv.Size = new System.Drawing.Size(529, 534);
		Dgv.TabIndex = 0;
		Dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(Dgv_CellClick);
		Dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellContentClick);
		Dgv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Dgv_KeyPress);
		base.AutoScaleDimensions = new System.Drawing.SizeF(14f, 29f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ControlLightLight;
		base.ClientSize = new System.Drawing.Size(315, 113);
		base.Controls.Add(Dgv);
		Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
		base.Name = "Tarjeta";
		Text = "Selecciona Tipo de Tarjeta";
		base.Load += new System.EventHandler(Tarjeta_Load);
		((System.ComponentModel.ISupportInitialize)Dgv).EndInit();
		ResumeLayout(false);
	}
}
