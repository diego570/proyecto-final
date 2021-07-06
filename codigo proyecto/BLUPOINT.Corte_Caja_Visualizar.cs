// BLUPOINT.Corte_Caja_Visualizar
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Corte_Caja_Visualizar : Form
{
	private Caja box = new Caja();

	private string id = "";

	private IContainer components = null;

	private Panel panel1;

	private PictureBox pictureBox2;

	private PictureBox pictureBox1;

	private Label lblfecha;

	private DateTimePicker dateTimePicker1;

	private DataGridView dataGridView1;

	private PrintDocument printDocument1;

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		dateTimePicker1.Visible = true;
		lblfecha.Visible = true;
	}

	public Corte_Caja_Visualizar()
	{
		InitializeComponent();
		dateTimePicker1.Visible = false;
		lblfecha.Visible = false;
		LoadMoney();
		box.id_caja = id;
		dataGridView1.DataSource = box.GetOpenBox();
	}

	private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\r')
		{
			return;
		}
		try
		{
			box.id_caja = id;
			if (dateTimePicker1.Value.Day.ToString().Length >= 2)
			{
				box.Fecha = dateTimePicker1.Value.Day + "/" + Selectdate(dateTimePicker1.Value.Month.ToString()) + "/" + dateTimePicker1.Value.Year;
			}
			else
			{
				box.Fecha = "0" + dateTimePicker1.Value.Day + "/" + Selectdate(dateTimePicker1.Value.Month.ToString()) + "/" + dateTimePicker1.Value.Year;
			}
			dataGridView1.DataSource = box.GETFilterOpenBox();
		}
		catch
		{
			MessageBox.Show("Ha ocurrido un error contacta a soporte tecnico");
		}
	}

	private string Selectdate(string mont)
	{
		return mont switch
		{
			"1" => "Enero", 
			"2" => "Febrero", 
			"3" => "Marzo", 
			"4" => "Abril", 
			"5" => "Mayo", 
			"6" => "Junio", 
			"7" => "Julio", 
			"8" => "Agosto", 
			"9" => "Septiembre", 
			"10" => "Octubre", 
			"11" => "Noviembre", 
			"12" => "Diciembre", 
			_ => "", 
		};
	}

	private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			try
			{
				string nombre = dataGridView1.CurrentRow.Cells["Usuario"].Value.ToString();
				string calculado = dataGridView1.CurrentRow.Cells["Calculado"].Value.ToString();
				string diferecnia = dataGridView1.CurrentRow.Cells["Diferencia"].Value.ToString();
				string entrada = dataGridView1.CurrentRow.Cells["Contado"].Value.ToString();
				string retirado = dataGridView1.CurrentRow.Cells["Retirado"].Value.ToString();
				string fecha = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
				Ver_corte_caja ver_corte_caja = new Ver_corte_caja(nombre, calculado, diferecnia, entrada, retirado, fecha);
				ver_corte_caja.ShowDialog();
			}
			catch
			{
				MessageBox.Show("No hay resultados que mostrar");
			}
		}
	}

	private void pictureBox2_Click(object sender, EventArgs e)
	{
		try
		{
			string nombre = dataGridView1.CurrentRow.Cells["Usuario"].Value.ToString();
			string calculado = dataGridView1.CurrentRow.Cells["Calculado"].Value.ToString();
			string diferecnia = dataGridView1.CurrentRow.Cells["Diferencia"].Value.ToString();
			string entrada = dataGridView1.CurrentRow.Cells["Contado"].Value.ToString();
			string retirado = dataGridView1.CurrentRow.Cells["Retirado"].Value.ToString();
			string fecha = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
			Ver_corte_caja ver_corte_caja = new Ver_corte_caja(nombre, calculado, diferecnia, entrada, retirado, fecha);
			ver_corte_caja.ShowDialog();
		}
		catch
		{
			MessageBox.Show("No hay resultados que mostrar");
		}
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
		panel1 = new System.Windows.Forms.Panel();
		lblfecha = new System.Windows.Forms.Label();
		dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
		dataGridView1 = new System.Windows.Forms.DataGridView();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(pictureBox2);
		panel1.Controls.Add(pictureBox1);
		panel1.Controls.Add(lblfecha);
		panel1.Controls.Add(dateTimePicker1);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(800, 78);
		panel1.TabIndex = 2;
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
		dataGridView1.AllowUserToAddRows = false;
		dataGridView1.AllowUserToDeleteRows = false;
		dataGridView1.AllowUserToResizeColumns = false;
		dataGridView1.AllowUserToResizeRows = false;
		dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(224, 224, 224);
		dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView1.Location = new System.Drawing.Point(0, 83);
		dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		dataGridView1.Name = "dataGridView1";
		dataGridView1.Size = new System.Drawing.Size(800, 370);
		dataGridView1.TabIndex = 3;
		dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dataGridView1_KeyPress);
		pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox2.Image = BLUPOINT.Properties.Resources.ver;
		pictureBox2.Location = new System.Drawing.Point(88, 18);
		pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(44, 48);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 3;
		pictureBox2.TabStop = false;
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
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(800, 450);
		base.Controls.Add(dataGridView1);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Corte_Caja_Visualizar";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Corte_Caja_Visualizar";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}
}
