// BLUPOINT.Rep_Caja_Usr
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Rep_Caja_Usr : Form
{
	private string ids;

	private Empleados emp = new Empleados();

	private Caja cj = new Caja();

	private IContainer components = null;

	private Panel panel1;

	private Label label1;

	private Panel panel16;

	private Label txttipo_e;

	private PictureBox image_user;

	private Label label18;

	private Label txtName;

	private Panel panel2;

	private Button button2;

	private DateTimePicker txtDate;

	private Button button1;

	private Label lbldate;

	private ComboBox cbfilter;

	private DataGridView dgvru;

	private PrintDocument printDocument1;

	public Rep_Caja_Usr(string id, string nombre, string ruta, string cargo)
	{
		InitializeComponent();
		txtName.Text = nombre;
		txttipo_e.Text = cargo;
		base.KeyPreview = true;
		if (ruta == "")
		{
			image_user.Image = Resources.picture;
		}
		else
		{
			image_user.Image = Image.FromFile(ruta);
		}
		txtDate.Visible = false;
		lbldate.Visible = false;
		LoadMoney();
		Iniciar();
	}

	public void LoadMoney()
	{
		DataTable dataTable = new DataTable();
		try
		{
			dataTable = cj.GETMONEY();
			ids = dataTable.Rows[0]["idCaja"].ToString();
		}
		catch
		{
		}
	}

	private void Iniciar()
	{
		emp.id = ids;
		emp.Nombre_E = txtName.Text;
		DateTime now = DateTime.Now;
		emp.Fecha_N = now.ToString("dd/MMMM/yyyy");
		dgvru.DataSource = emp.GETBOX("Normal");
	}

	private void cbfilter_TextChanged(object sender, EventArgs e)
	{
		lbldate.Visible = true;
		txtDate.Visible = true;
		if (cbfilter.Text == "DIA")
		{
			lbldate.Text = "Digita el Dia a solicitar";
		}
		else if (cbfilter.Text == "MES")
		{
			lbldate.Text = "Digita el Mes a solicitar";
		}
		else if (cbfilter.Text == "AÑO")
		{
			lbldate.Text = "Digita el Año a solicitar";
		}
	}

	private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\r')
		{
			return;
		}
		if (cbfilter.Text == "DIA")
		{
			emp.id = ids;
			if (txtDate.Value.Day.ToString().Length >= 2)
			{
				emp.Fecha_N = txtDate.Value.Day + "/" + Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			}
			else
			{
				emp.Fecha_N = "0" + txtDate.Value.Day + "/" + Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			}
			dgvru.DataSource = emp.GETBOX("Dia");
		}
		else if (cbfilter.Text == "MES")
		{
			emp.id = ids;
			emp.Fecha_N = Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			dgvru.DataSource = emp.GETBOX("Mes");
		}
		else if (cbfilter.Text == "AÑO")
		{
			emp.id = ids;
			emp.Fecha_N = txtDate.Value.Year.ToString();
			dgvru.DataSource = emp.GETBOX("Anio");
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

	private void button2_Click(object sender, EventArgs e)
	{
		Det_Box_Us det_Box_Us = new Det_Box_Us(dgvru.CurrentRow.Cells["Fecha"].Value.ToString(), dgvru.CurrentRow.Cells["open"].Value.ToString(), dgvru.CurrentRow.Cells["Tipo_Consumo"].Value.ToString());
		det_Box_Us.Show();
	}

	private void Rep_Caja_Usr_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F2)
		{
			Det_Box_Us det_Box_Us = new Det_Box_Us(dgvru.CurrentRow.Cells["Fecha"].Value.ToString(), dgvru.CurrentRow.Cells["open"].Value.ToString(), dgvru.CurrentRow.Cells["Tipo_Consumo"].Value.ToString());
			det_Box_Us.Show();
		}
		if (e.KeyCode == Keys.Control && e.KeyCode == Keys.P)
		{
			Print();
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Print();
	}

	private void Print()
	{
		printDocument1 = new PrintDocument();
		PrinterSettings printerSettings = new PrinterSettings();
		printDocument1.PrinterSettings = printerSettings;
		printDocument1.PrintPage += Imprimir;
		printDocument1.Print();
	}

	private void Imprimir(object sender, PrintPageEventArgs e)
	{
		Negocio negocio = new Negocio();
		DataTable dataTable = new DataTable();
		dataTable = negocio.GetNegocio();
		string s = "Calle: " + dataTable.Rows[0]["Calle"].ToString() + ", #" + dataTable.Rows[0]["Numero_Ext"].ToString() + ", Col. " + dataTable.Rows[0]["Colonia"].ToString() + "\n" + dataTable.Rows[0]["Municipio"].ToString() + ", " + dataTable.Rows[0]["Estado"].ToString() + ", C.P: " + dataTable.Rows[0]["CP"].ToString();
		Font font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Point);
		Font font2 = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point);
		Font font3 = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point);
		Font font4 = new Font("Segoe UI", 5f, FontStyle.Regular, GraphicsUnit.Point);
		Font font5 = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point);
		int num = 220;
		int num2 = 20;
		e.Graphics.DrawString(" ***" + dataTable.Rows[0]["Nombre_N"].ToString() + "*** ", font, Brushes.Black, new RectangleF(0f, num2 += 10, num, 20f));
		e.Graphics.DrawString(s, font3, Brushes.Black, new RectangleF(8f, num2 += 20, num, num2 + 20));
		e.Graphics.DrawString("Tel: " + dataTable.Rows[0]["Telefono"].ToString(), font3, Brushes.Black, new RectangleF(8f, num2 += 25, num, num2 + 15));
		e.Graphics.DrawString("Reporte de Caja por Usuario", font3, Brushes.Black, new RectangleF(8f, num2 += 15, num, num2 + 20));
		e.Graphics.DrawString(" ************************************* ", font, Brushes.Black, new RectangleF(0f, num2 += 10, num, 20f));
		e.Graphics.DrawString("Nombre: " + txtName.Text, font3, Brushes.Black, new RectangleF(0f, num2 += 15, num, num2 + 20));
		e.Graphics.DrawString("Hora de Apertura", font2, Brushes.Black, new RectangleF(8f, num2 += 25, num, num2 + 20));
		foreach (DataGridViewRow item in (IEnumerable)dgvru.Rows)
		{
			e.Graphics.DrawString(item.Cells["open"].Value?.ToString() + " ", font2, Brushes.Black, new RectangleF(8f, num2 += 20, num, num2 + 15));
		}
		e.Graphics.DrawString("Fecha de Solicitud: " + txtDate.Value.Day + "/" + txtDate.Value.Month + "/" + txtDate.Value.Year, font3, Brushes.Black, new RectangleF(0f, num2 += 15, num, num2 + 15));
		e.Graphics.DrawString(" ************************************* ", font, Brushes.Black, new RectangleF(0f, num2 += 10, num, 20f));
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Rep_Caja_Usr));
		panel1 = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
		panel16 = new System.Windows.Forms.Panel();
		txttipo_e = new System.Windows.Forms.Label();
		label18 = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.Label();
		panel2 = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		txtDate = new System.Windows.Forms.DateTimePicker();
		button1 = new System.Windows.Forms.Button();
		lbldate = new System.Windows.Forms.Label();
		cbfilter = new System.Windows.Forms.ComboBox();
		dgvru = new System.Windows.Forms.DataGridView();
		image_user = new System.Windows.Forms.PictureBox();
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		panel1.SuspendLayout();
		panel16.SuspendLayout();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dgvru).BeginInit();
		((System.ComponentModel.ISupportInitialize)image_user).BeginInit();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(label1);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(934, 64);
		panel1.TabIndex = 3;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Impact", 27.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(324, 9);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(266, 45);
		label1.TabIndex = 0;
		label1.Text = "REPORTE DE CAJA";
		panel16.BackColor = System.Drawing.Color.White;
		panel16.Controls.Add(txttipo_e);
		panel16.Controls.Add(image_user);
		panel16.Controls.Add(label18);
		panel16.Controls.Add(txtName);
		panel16.Location = new System.Drawing.Point(584, 79);
		panel16.Name = "panel16";
		panel16.Size = new System.Drawing.Size(342, 281);
		panel16.TabIndex = 4;
		txttipo_e.AutoSize = true;
		txttipo_e.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttipo_e.Location = new System.Drawing.Point(124, 245);
		txttipo_e.Name = "txttipo_e";
		txttipo_e.Size = new System.Drawing.Size(65, 24);
		txttipo_e.TabIndex = 28;
		txttipo_e.Text = "Cajero";
		label18.AutoSize = true;
		label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label18.ForeColor = System.Drawing.SystemColors.AppWorkspace;
		label18.Location = new System.Drawing.Point(57, 245);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(61, 24);
		label18.TabIndex = 26;
		label18.Text = "Cargo";
		txtName.AutoSize = true;
		txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtName.Location = new System.Drawing.Point(34, 215);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(197, 24);
		txtName.TabIndex = 25;
		txtName.Text = "Jorge Lemus Stripsent";
		panel2.BackColor = System.Drawing.Color.White;
		panel2.Controls.Add(button2);
		panel2.Controls.Add(txtDate);
		panel2.Controls.Add(button1);
		panel2.Controls.Add(lbldate);
		panel2.Controls.Add(cbfilter);
		panel2.Location = new System.Drawing.Point(584, 380);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(342, 210);
		panel2.TabIndex = 5;
		button2.BackColor = System.Drawing.Color.SteelBlue;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Location = new System.Drawing.Point(179, 133);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(156, 52);
		button2.TabIndex = 5;
		button2.Text = "Detalle (F2)";
		button2.UseVisualStyleBackColor = false;
		button2.Click += new System.EventHandler(button2_Click);
		txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtDate.Location = new System.Drawing.Point(9, 81);
		txtDate.Name = "txtDate";
		txtDate.Size = new System.Drawing.Size(296, 26);
		txtDate.TabIndex = 4;
		txtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDate_KeyPress);
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(3, 133);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(162, 52);
		button1.TabIndex = 3;
		button1.Text = "Imprimir (Ctr+p)";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		lbldate.AutoSize = true;
		lbldate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lbldate.Location = new System.Drawing.Point(93, 60);
		lbldate.Name = "lbldate";
		lbldate.Size = new System.Drawing.Size(45, 18);
		lbldate.TabIndex = 2;
		lbldate.Text = "Digita";
		cbfilter.BackColor = System.Drawing.Color.White;
		cbfilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		cbfilter.ForeColor = System.Drawing.Color.Black;
		cbfilter.FormattingEnabled = true;
		cbfilter.Items.AddRange(new object[3] { "DIA", "MES", "AÑO" });
		cbfilter.Location = new System.Drawing.Point(38, 3);
		cbfilter.Name = "cbfilter";
		cbfilter.Size = new System.Drawing.Size(248, 33);
		cbfilter.TabIndex = 0;
		cbfilter.Text = "FILTRAR";
		cbfilter.TextChanged += new System.EventHandler(cbfilter_TextChanged);
		dgvru.BackgroundColor = System.Drawing.Color.White;
		dgvru.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgvru.Location = new System.Drawing.Point(12, 82);
		dgvru.Name = "dgvru";
		dgvru.Size = new System.Drawing.Size(565, 511);
		dgvru.TabIndex = 6;
		image_user.Image = (System.Drawing.Image)resources.GetObject("image_user.Image");
		image_user.Location = new System.Drawing.Point(38, 3);
		image_user.Name = "image_user";
		image_user.Size = new System.Drawing.Size(229, 209);
		image_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		image_user.TabIndex = 24;
		image_user.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(934, 605);
		base.Controls.Add(dgvru);
		base.Controls.Add(panel2);
		base.Controls.Add(panel16);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Rep_Caja_Usr";
		Text = "Rep_Caja_Usr";
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Rep_Caja_Usr_KeyUp);
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		panel16.ResumeLayout(false);
		panel16.PerformLayout();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)dgvru).EndInit();
		((System.ComponentModel.ISupportInitialize)image_user).EndInit();
		ResumeLayout(false);
	}
}
