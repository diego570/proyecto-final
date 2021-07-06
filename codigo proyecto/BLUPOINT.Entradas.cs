// BLUPOINT.Entradas
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Entradas : Form
{
	private Caja box = new Caja();

	private string id = "";

	private string name;

	private IContainer components = null;

	private DataGridView dataGridView1;

	private Panel panel1;

	private PictureBox pictureBox2;

	private ToolTip toolTip1;

	private PictureBox pictureBox1;

	private Label lblfecha;

	private DateTimePicker dateTimePicker1;

	public Entradas(string nombre)
	{
		InitializeComponent();
		getEntradas();
		dateTimePicker1.Visible = false;
		lblfecha.Visible = false;
		name = nombre;
	}

	private void getEntradas()
	{
		box.Fecha = dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year;
		box.id_caja = LoadMoney();
		dataGridView1.DataSource = box.GETENTER();
		dataGridView1.Columns[0].Width = 100;
		dataGridView1.Columns[1].Width = 150;
		dataGridView1.Columns[2].Width = 250;
		dataGridView1.Columns[3].Width = 100;
		dataGridView1.Columns[4].Width = 100;
	}

	private string LoadMoney()
	{
		DataTable dataTable = new DataTable();
		try
		{
			dataTable = box.GETMONEY();
			id = dataTable.Rows[0]["idCaja"].ToString();
			return id;
		}
		catch
		{
			return id;
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		dateTimePicker1.Visible = true;
		lblfecha.Visible = true;
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
	}

	private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			try
			{
				Visualizar_entrada visualizar_entrada = new Visualizar_entrada(dataGridView1.CurrentRow.Cells["Concepto"].Value.ToString(), dataGridView1.CurrentRow.Cells["Tipo_Pago"].Value.ToString(), dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString(), dataGridView1.CurrentRow.Cells["Nombre_E"].Value.ToString(), dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString());
				visualizar_entrada.ShowDialog();
			}
			catch
			{
				MessageBox.Show("No se puede elegir un campo vacio");
			}
		}
	}

	private void pictureBox2_Click(object sender, EventArgs e)
	{
		try
		{
			Visualizar_entrada visualizar_entrada = new Visualizar_entrada(dataGridView1.CurrentRow.Cells["Concepto"].Value.ToString(), dataGridView1.CurrentRow.Cells["Tipo_Pago"].Value.ToString(), dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString(), dataGridView1.CurrentRow.Cells["Nombre_E"].Value.ToString(), dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString());
			visualizar_entrada.ShowDialog();
		}
		catch
		{
			MessageBox.Show("No se puede elegir un campo vacio");
		}
	}

	private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			try
			{
				box.Nombre_U = name;
				box.id_caja = id;
				box.Fecha = dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year;
				dataGridView1.DataSource = box.GETENTER();
			}
			catch
			{
				MessageBox.Show("Ha ocurrido un error contacta a soporte tecnico");
			}
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
		components = new System.ComponentModel.Container();
		dataGridView1 = new System.Windows.Forms.DataGridView();
		panel1 = new System.Windows.Forms.Panel();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		lblfecha = new System.Windows.Forms.Label();
		dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
		toolTip1 = new System.Windows.Forms.ToolTip(components);
		((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		dataGridView1.AllowUserToAddRows = false;
		dataGridView1.AllowUserToDeleteRows = false;
		dataGridView1.AllowUserToResizeColumns = false;
		dataGridView1.AllowUserToResizeRows = false;
		dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(224, 224, 224);
		dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView1.Location = new System.Drawing.Point(4, 88);
		dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		dataGridView1.Name = "dataGridView1";
		dataGridView1.Size = new System.Drawing.Size(1227, 606);
		dataGridView1.TabIndex = 0;
		dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dataGridView1_KeyPress);
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(pictureBox2);
		panel1.Controls.Add(pictureBox1);
		panel1.Controls.Add(lblfecha);
		panel1.Controls.Add(dateTimePicker1);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(736, 78);
		panel1.TabIndex = 1;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox2.Image = BLUPOINT.Properties.Resources.ver;
		pictureBox2.Location = new System.Drawing.Point(88, 18);
		pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(44, 48);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 3;
		pictureBox2.TabStop = false;
		toolTip1.SetToolTip(pictureBox2, "Vista Previa");
		pictureBox2.Click += new System.EventHandler(pictureBox2_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox1.Image = BLUPOINT.Properties.Resources.filtrar;
		pictureBox1.Location = new System.Drawing.Point(13, 15);
		pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(51, 48);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 2;
		pictureBox1.TabStop = false;
		toolTip1.SetToolTip(pictureBox1, "Filtrar por fecha");
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		lblfecha.AutoSize = true;
		lblfecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblfecha.Location = new System.Drawing.Point(504, 15);
		lblfecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		lblfecha.Name = "lblfecha";
		lblfecha.Size = new System.Drawing.Size(140, 24);
		lblfecha.TabIndex = 1;
		lblfecha.Text = "Filtrar por fecha";
		dateTimePicker1.CalendarFont = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dateTimePicker1.Location = new System.Drawing.Point(415, 44);
		dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		dateTimePicker1.Name = "dateTimePicker1";
		dateTimePicker1.Size = new System.Drawing.Size(308, 29);
		dateTimePicker1.TabIndex = 0;
		dateTimePicker1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dateTimePicker1_KeyPress);
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(736, 349);
		base.Controls.Add(panel1);
		base.Controls.Add(dataGridView1);
		Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		base.Name = "Entradas";
		Text = "Entradas";
		((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}
}
