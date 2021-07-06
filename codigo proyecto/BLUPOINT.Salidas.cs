// BLUPOINT.Salidas
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Salidas : Form
{
	private string nombre;

	private string tipo;

	private string ids;

	private Caja cj = new Caja();

	private IContainer components = null;

	private Panel panel1;

	private Panel panel2;

	private Button button1;

	private Label label2;

	private TextBox txtCantidad;

	private Label label1;

	private TextBox txtConcepto;

	private Panel panel3;

	private DataGridView DGV1;

	private PictureBox pictureBox3;

	private PictureBox pictureBox2;

	private PictureBox pictureBox1;

	private Label lblfecha;

	private DateTimePicker dtm;

	private ToolTip toolTip1;

	private DateTimePicker dtm1;

	public Salidas(string nombre_e, string tipo_e, string id)
	{
		InitializeComponent();
		nombre = nombre_e;
		tipo = tipo_e;
		ids = id;
		getSalidas();
	}

	private void txtCantidad_TextChanged(object sender, EventArgs e)
	{
		if (!(txtCantidad.Text == ""))
		{
			try
			{
				double num = Convert.ToDouble(txtCantidad.Text);
			}
			catch
			{
				MessageBox.Show("Solo introduce numeros numeros");
				txtCantidad.Text = "";
			}
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		lblfecha.Visible = true;
		dtm.Visible = true;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		cj.concepto = txtConcepto.Text;
		cj.Cantidad = txtCantidad.Text;
		DateTime now = DateTime.Now;
		cj.Fecha = now.ToString("dd/MMMM/yyyy");
		if (cj.INSERTEXIT(nombre, tipo) == 1)
		{
			MessageBox.Show("La salida ha sido registrada");
			Openbox();
			Limpiar();
		}
		else
		{
			MessageBox.Show("Ha ocurrido un error por favor contecta a soporte tecnico");
		}
	}

	private void Openbox()
	{
		cj.id_caja = ids;
		cj.Nombre_U = nombre;
		cj.Hora = dtm1.Value.Hour + ":" + dtm1.Value.Minute + ":" + dtm1.Value.Second;
		DateTime now = DateTime.Now;
		cj.Fecha = now.ToString("dd/MMMM/yyyy");
		cj.Tipo_E = tipo;
		cj.tipo_consumo = "Salida";
		cj.OpenBox();
	}

	private void pictureBox3_Click(object sender, EventArgs e)
	{
		txtCantidad.Enabled = true;
		txtConcepto.Enabled = true;
		button1.Enabled = true;
	}

	private void Limpiar()
	{
		lblfecha.Visible = false;
		dtm.Visible = false;
		txtCantidad.Text = "";
		txtConcepto.Text = "";
		txtCantidad.Enabled = false;
		txtConcepto.Enabled = false;
		button1.Enabled = false;
		getSalidas();
	}

	private void dtm_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			cj.Nombre_U = nombre;
			cj.id_caja = ids;
			cj.Fecha = dtm.Value.Day + "/" + Selectdate(dtm.Value.Month.ToString()) + "/" + dtm.Value.Year;
			DGV1.DataSource = cj.GETSAL();
		}
	}

	private void DGV1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			try
			{
				Visualizar_Salidas visualizar_Salidas = new Visualizar_Salidas(DGV1.CurrentRow.Cells["Concepto"].Value.ToString(), DGV1.CurrentRow.Cells["Fecha"].Value.ToString(), DGV1.CurrentRow.Cells["Usuario"].Value.ToString(), DGV1.CurrentRow.Cells["Cantidad"].Value.ToString());
				visualizar_Salidas.ShowDialog();
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
			Visualizar_Salidas visualizar_Salidas = new Visualizar_Salidas(DGV1.CurrentRow.Cells["Concepto"].Value.ToString(), DGV1.CurrentRow.Cells["Fecha"].Value.ToString(), DGV1.CurrentRow.Cells["Usuario"].Value.ToString(), DGV1.CurrentRow.Cells["Cantidad"].Value.ToString());
			visualizar_Salidas.ShowDialog();
		}
		catch
		{
			MessageBox.Show("No se puede elegir un campo vacio");
		}
	}

	private void getSalidas()
	{
		if (tipo == "Admin")
		{
			cj.id_caja = LoadMoney();
			DateTime now = DateTime.Now;
			cj.Fecha = now.ToString("dd/MMMM/yyyy");
			DGV1.DataSource = cj.GETSAL();
			DGV1.Columns[0].Width = 100;
			DGV1.Columns[1].Width = 150;
			DGV1.Columns[2].Width = 250;
			DGV1.Columns[3].Width = 100;
			DGV1.Columns[4].Width = 100;
		}
		else
		{
			cj.id_caja = LoadMoney();
			cj.Usuario = nombre;
			DateTime now2 = DateTime.Now;
			cj.Fecha = now2.ToString("dd:MMMM:yyyy");
			DGV1.DataSource = cj.GETSALID();
			DGV1.Columns[0].Width = 100;
			DGV1.Columns[1].Width = 150;
			DGV1.Columns[2].Width = 250;
			DGV1.Columns[3].Width = 100;
			DGV1.Columns[4].Width = 100;
		}
	}

	private string LoadMoney()
	{
		string result = "";
		DataTable dataTable = new DataTable();
		try
		{
			dataTable = cj.GETMONEY();
			result = dataTable.Rows[0]["idCaja"].ToString();
			return result;
		}
		catch
		{
			return result;
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
		panel1 = new System.Windows.Forms.Panel();
		dtm1 = new System.Windows.Forms.DateTimePicker();
		pictureBox3 = new System.Windows.Forms.PictureBox();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		lblfecha = new System.Windows.Forms.Label();
		dtm = new System.Windows.Forms.DateTimePicker();
		panel2 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		label2 = new System.Windows.Forms.Label();
		txtCantidad = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		txtConcepto = new System.Windows.Forms.TextBox();
		panel3 = new System.Windows.Forms.Panel();
		DGV1 = new System.Windows.Forms.DataGridView();
		toolTip1 = new System.Windows.Forms.ToolTip(components);
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel2.SuspendLayout();
		panel3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)DGV1).BeginInit();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(dtm1);
		panel1.Controls.Add(pictureBox3);
		panel1.Controls.Add(pictureBox2);
		panel1.Controls.Add(pictureBox1);
		panel1.Controls.Add(lblfecha);
		panel1.Controls.Add(dtm);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(995, 67);
		panel1.TabIndex = 0;
		dtm1.CalendarFont = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dtm1.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dtm1.Location = new System.Drawing.Point(343, 19);
		dtm1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		dtm1.Name = "dtm1";
		dtm1.Size = new System.Drawing.Size(308, 29);
		dtm1.TabIndex = 9;
		dtm1.Visible = false;
		pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox3.Image = BLUPOINT.Properties.Resources.anadir;
		pictureBox3.Location = new System.Drawing.Point(13, 8);
		pictureBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		pictureBox3.Name = "pictureBox3";
		pictureBox3.Size = new System.Drawing.Size(51, 48);
		pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox3.TabIndex = 8;
		pictureBox3.TabStop = false;
		pictureBox3.Click += new System.EventHandler(pictureBox3_Click);
		pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox2.Image = BLUPOINT.Properties.Resources.ver;
		pictureBox2.Location = new System.Drawing.Point(88, 8);
		pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(44, 48);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 7;
		pictureBox2.TabStop = false;
		toolTip1.SetToolTip(pictureBox2, "Visualizar ");
		pictureBox2.Click += new System.EventHandler(pictureBox2_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox1.Image = BLUPOINT.Properties.Resources.filtrar;
		pictureBox1.Location = new System.Drawing.Point(152, 8);
		pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(51, 48);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 6;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		lblfecha.AutoSize = true;
		lblfecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblfecha.Location = new System.Drawing.Point(756, 4);
		lblfecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		lblfecha.Name = "lblfecha";
		lblfecha.Size = new System.Drawing.Size(140, 24);
		lblfecha.TabIndex = 5;
		lblfecha.Text = "Filtrar por fecha";
		lblfecha.Visible = false;
		dtm.CalendarFont = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dtm.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dtm.Location = new System.Drawing.Point(674, 31);
		dtm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		dtm.Name = "dtm";
		dtm.Size = new System.Drawing.Size(308, 29);
		dtm.TabIndex = 4;
		dtm.Visible = false;
		dtm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtm_KeyPress);
		panel2.BackColor = System.Drawing.Color.White;
		panel2.Controls.Add(button1);
		panel2.Controls.Add(label2);
		panel2.Controls.Add(txtCantidad);
		panel2.Controls.Add(label1);
		panel2.Controls.Add(txtConcepto);
		panel2.Location = new System.Drawing.Point(658, 85);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(337, 366);
		panel2.TabIndex = 1;
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.Enabled = false;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(50, 243);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(247, 83);
		button1.TabIndex = 4;
		button1.Text = "ACEPTAR";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(28, 113);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(84, 24);
		label2.TabIndex = 3;
		label2.Text = "Cantidad";
		txtCantidad.Enabled = false;
		txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtCantidad.Location = new System.Drawing.Point(32, 140);
		txtCantidad.Name = "txtCantidad";
		txtCantidad.Size = new System.Drawing.Size(266, 35);
		txtCantidad.TabIndex = 2;
		txtCantidad.TextChanged += new System.EventHandler(txtCantidad_TextChanged);
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(28, 17);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(92, 24);
		label1.TabIndex = 1;
		label1.Text = "Concepto";
		txtConcepto.Enabled = false;
		txtConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtConcepto.Location = new System.Drawing.Point(32, 44);
		txtConcepto.Name = "txtConcepto";
		txtConcepto.Size = new System.Drawing.Size(266, 35);
		txtConcepto.TabIndex = 0;
		panel3.BackColor = System.Drawing.Color.White;
		panel3.Controls.Add(DGV1);
		panel3.Location = new System.Drawing.Point(0, 85);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(625, 366);
		panel3.TabIndex = 2;
		DGV1.BackgroundColor = System.Drawing.Color.White;
		DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV1.Location = new System.Drawing.Point(0, 3);
		DGV1.Name = "DGV1";
		DGV1.Size = new System.Drawing.Size(622, 360);
		DGV1.TabIndex = 0;
		DGV1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGV1_KeyPress);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
		base.ClientSize = new System.Drawing.Size(995, 450);
		base.Controls.Add(panel3);
		base.Controls.Add(panel2);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Salidas";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Salidas";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		panel3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)DGV1).EndInit();
		ResumeLayout(false);
	}
}
