// BLUPOINT.Reporte_Usuario
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

public class Reporte_Usuario : Form
{
	private Empleados emp = new Empleados();

	private IContainer components = null;

	private DataGridView dgvru;

	private Panel panel1;

	private ComboBox cbfilter;

	private Panel panel2;

	private Panel panel16;

	private Label txttipo_e;

	private PictureBox image_user;

	private Label label18;

	private Label txtName;

	private ContextMenuStrip contextMenuStrip1;

	private Button button1;

	private Label lbldate;

	private DateTimePicker txtDate;

	private Label label1;

	private Button button2;

	private PrintDocument printDocument1;

	public Reporte_Usuario(string id, string nombre, string ruta, string cargo)
	{
		InitializeComponent();
		base.KeyPreview = true;
		base.KeyDown += Reporte_Usuario_KeyUp;
		Iniciar(id);
		txtName.Text = nombre;
		txttipo_e.Text = cargo;
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
	}

	private void Iniciar(string id)
	{
		emp.id = id;
		dgvru.DataSource = emp.GETASIS("Normal");
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

	private void txtDate_ValueChanged(object sender, EventArgs e)
	{
	}

	private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\r')
		{
			return;
		}
		if (cbfilter.Text == "DIA")
		{
			if (txtDate.Value.Day.ToString().Length >= 2)
			{
				emp.Fecha_N = txtDate.Value.Day + "/" + Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			}
			else
			{
				emp.Fecha_N = "0" + txtDate.Value.Day + "/" + Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			}
			dgvru.DataSource = emp.GETASIS("Dia");
		}
		else if (cbfilter.Text == "MES")
		{
			emp.Fecha_N = Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			dgvru.DataSource = emp.GETASIS("Mes");
		}
		else if (cbfilter.Text == "AÑO")
		{
			emp.Fecha_N = txtDate.Value.Year.ToString();
			dgvru.DataSource = emp.GETASIS("Anio");
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Detlle_Us detlle_Us = new Detlle_Us(dgvru.CurrentRow.Cells["Fecha"].Value.ToString(), dgvru.CurrentRow.Cells["Hora_In"].Value.ToString(), dgvru.CurrentRow.Cells["Hora_fin"].Value.ToString());
		detlle_Us.Show();
	}

	private void Reporte_Usuario_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F2)
		{
			Detlle_Us detlle_Us = new Detlle_Us(dgvru.CurrentRow.Cells["Fecha"].Value.ToString(), dgvru.CurrentRow.Cells["Hora_In"].Value.ToString(), dgvru.CurrentRow.Cells["Hora_fin"].Value.ToString());
			detlle_Us.Show();
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
		e.Graphics.DrawString("Reporte de Asistencia", font3, Brushes.Black, new RectangleF(8f, num2 += 15, num, num2 + 20));
		e.Graphics.DrawString(" ************************************* ", font, Brushes.Black, new RectangleF(0f, num2 += 10, num, 20f));
		e.Graphics.DrawString("Nombre: " + txtName.Text, font3, Brushes.Black, new RectangleF(0f, num2 += 15, num, num2 + 20));
		e.Graphics.DrawString("Hora Entrada\t\tHora Salida", font2, Brushes.Black, new RectangleF(0f, num2 += 25, num, num2 + 20));
		foreach (DataGridViewRow item in (IEnumerable)dgvru.Rows)
		{
			e.Graphics.DrawString(item.Cells["Hora_In"].Value?.ToString() + "\t\t" + item.Cells["Hora_fin"].Value, font2, Brushes.Black, new RectangleF(8f, num2 += 20, num, num2 + 15));
		}
		e.Graphics.DrawString("Fecha de Solicitud: " + txtDate.Value.Day + "/" + txtDate.Value.Month + "/" + txtDate.Value.Year, font3, Brushes.Black, new RectangleF(0f, num2 += 15, num, num2 + 15));
		e.Graphics.DrawString(" ************************************* ", font, Brushes.Black, new RectangleF(0f, num2 += 10, num, 20f));
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Reporte_Usuario));
		dgvru = new System.Windows.Forms.DataGridView();
		panel1 = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
		cbfilter = new System.Windows.Forms.ComboBox();
		panel2 = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		txtDate = new System.Windows.Forms.DateTimePicker();
		button1 = new System.Windows.Forms.Button();
		lbldate = new System.Windows.Forms.Label();
		panel16 = new System.Windows.Forms.Panel();
		txttipo_e = new System.Windows.Forms.Label();
		label18 = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.Label();
		contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
		image_user = new System.Windows.Forms.PictureBox();
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		((System.ComponentModel.ISupportInitialize)dgvru).BeginInit();
		panel1.SuspendLayout();
		panel2.SuspendLayout();
		panel16.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)image_user).BeginInit();
		SuspendLayout();
		dgvru.BackgroundColor = System.Drawing.SystemColors.Control;
		dgvru.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgvru.Location = new System.Drawing.Point(22, 82);
		dgvru.Name = "dgvru";
		dgvru.Size = new System.Drawing.Size(565, 485);
		dgvru.TabIndex = 0;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(label1);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(955, 64);
		panel1.TabIndex = 2;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Impact", 27.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(355, 9);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(365, 45);
		label1.TabIndex = 0;
		label1.Text = "REPORTE DE ASISTENCIA";
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
		panel2.BackColor = System.Drawing.Color.WhiteSmoke;
		panel2.Controls.Add(button2);
		panel2.Controls.Add(txtDate);
		panel2.Controls.Add(button1);
		panel2.Controls.Add(lbldate);
		panel2.Controls.Add(cbfilter);
		panel2.Location = new System.Drawing.Point(601, 357);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(342, 210);
		panel2.TabIndex = 3;
		button2.BackColor = System.Drawing.Color.SteelBlue;
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
		txtDate.ValueChanged += new System.EventHandler(txtDate_ValueChanged);
		txtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDate_KeyPress);
		button1.BackColor = System.Drawing.Color.SteelBlue;
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
		panel16.Controls.Add(txttipo_e);
		panel16.Controls.Add(image_user);
		panel16.Controls.Add(label18);
		panel16.Controls.Add(txtName);
		panel16.Location = new System.Drawing.Point(601, 70);
		panel16.Name = "panel16";
		panel16.Size = new System.Drawing.Size(342, 281);
		panel16.TabIndex = 2;
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
		contextMenuStrip1.Name = "contextMenuStrip1";
		contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
		image_user.Image = (System.Drawing.Image)resources.GetObject("image_user.Image");
		image_user.Location = new System.Drawing.Point(38, 3);
		image_user.Name = "image_user";
		image_user.Size = new System.Drawing.Size(229, 209);
		image_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		image_user.TabIndex = 24;
		image_user.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(955, 579);
		base.Controls.Add(panel16);
		base.Controls.Add(panel2);
		base.Controls.Add(panel1);
		base.Controls.Add(dgvru);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Reporte_Usuario";
		Text = "Reprote de Asistencia";
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Reporte_Usuario_KeyUp);
		((System.ComponentModel.ISupportInitialize)dgvru).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		panel16.ResumeLayout(false);
		panel16.PerformLayout();
		((System.ComponentModel.ISupportInitialize)image_user).EndInit();
		ResumeLayout(false);
	}
}
