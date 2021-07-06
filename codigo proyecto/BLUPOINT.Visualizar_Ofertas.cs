// BLUPOINT.Visualizar_Ofertas
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Source;

public class Visualizar_Ofertas : Form
{
	private Productos prod = new Productos();

	private IContainer components = null;

	private DataGridView DGV;

	private TextBox textBox1;

	private Button button1;

	private Label label1;

	public Visualizar_Ofertas(string nombre)
	{
		InitializeComponent();
		prod.Codigo = nombre;
		DGV.DataSource = prod.CargarOfertas2();
		DGV.Columns[0].Width = 250;
	}

	private void button1_Click(object sender, EventArgs e)
	{
	}

	private void button1_Click_1(object sender, EventArgs e)
	{
		Venta venta = base.Owner as Venta;
		venta.LoadDatatobox(DGV.CurrentRow.Cells["OFERTAS"].Value.ToString());
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
		DGV = new System.Windows.Forms.DataGridView();
		textBox1 = new System.Windows.Forms.TextBox();
		button1 = new System.Windows.Forms.Button();
		label1 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)DGV).BeginInit();
		SuspendLayout();
		DGV.AllowUserToAddRows = false;
		DGV.AllowUserToDeleteRows = false;
		DGV.BackgroundColor = System.Drawing.Color.White;
		DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV.Location = new System.Drawing.Point(23, 15);
		DGV.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
		DGV.Name = "DGV";
		DGV.Size = new System.Drawing.Size(359, 398);
		DGV.TabIndex = 0;
		textBox1.Location = new System.Drawing.Point(416, 144);
		textBox1.Name = "textBox1";
		textBox1.Size = new System.Drawing.Size(259, 31);
		textBox1.TabIndex = 2;
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(447, 215);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(205, 54);
		button1.TabIndex = 3;
		button1.Text = "Aceptar (F3)";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click_1);
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(411, 116);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(282, 25);
		label1.TabIndex = 4;
		label1.Text = "Cantidad de Promociones";
		base.AutoScaleDimensions = new System.Drawing.SizeF(13f, 25f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(699, 467);
		base.Controls.Add(label1);
		base.Controls.Add(button1);
		base.Controls.Add(textBox1);
		base.Controls.Add(DGV);
		Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		base.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
		base.Name = "Visualizar_Ofertas";
		Text = "Visualizar_Ofertas";
		((System.ComponentModel.ISupportInitialize)DGV).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
