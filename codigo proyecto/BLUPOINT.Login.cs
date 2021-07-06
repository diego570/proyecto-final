// BLUPOINT.Login
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Login : Form
{
	private Empleados emp;

	private IContainer components = null;

	private Panel panel1;

	private TextBox txtCod;

	private Label label1;

	private DateTimePicker dtme;

	private Button button1;

	private Panel panel2;

	private Button button3;

	private PictureBox pictureBox1;

	private PictureBox pictureBox2;

	private ToolTip toolTip1;

	[DllImport("Gdi32.dll")]
	private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

	public Login()
	{
		base.Width = 730;
		base.Height = 420;
		base.FormBorderStyle = FormBorderStyle.None;
		base.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, base.Width, base.Height, 50, 50));
		InitializeComponent();
		txtCod.Select();
	}

	private void txtUSer_KeyPress(object sender, KeyPressEventArgs e)
	{
	}

	private void Login_KeyPress(object sender, KeyPressEventArgs e)
	{
	}

	private void txtCod_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\r')
		{
			return;
		}
		emp = new Empleados();
		emp.Clave = txtCod.Text;
		DataTable dataTable = emp.Login();
		if (dataTable.Rows.Count.ToString() != "0")
		{
			DateTime now = DateTime.Now;
			string text = dataTable.Rows[0]["Tipo_Emp"].ToString();
			string car = dataTable.Rows[0]["Producto"].ToString();
			string car2 = dataTable.Rows[0]["Usuario"].ToString();
			string car3 = dataTable.Rows[0]["Caja"].ToString();
			string car4 = dataTable.Rows[0]["Cliente"].ToString();
			string ruta = dataTable.Rows[0]["Imagen"].ToString();
			string nombre = dataTable.Rows[0]["Nombre"].ToString() + " " + dataTable.Rows[0]["Apellidos"].ToString();
			string id = dataTable.Rows[0]["idEmpleado"].ToString();
			emp.id = id;
			emp.Fecha_N = now.ToString("dd/MMMM/yyyy");
			if (emp.verificarEntrada() == "1")
			{
				Form1 form = new Form1(nombre, ruta, text, id, car, car2, car4, car3);
				Hide();
				form.Show();
			}
			else if (emp.verificarEntrada() == "2")
			{
				Form1 form2 = new Form1(nombre, ruta, text, id, car, car2, car4, car3);
				Hide();
				form2.Show();
			}
			else if (emp.verificarEntrada() == "3" && text != "Admin")
			{
				Alert_Error alert_Error = new Alert_Error("No puedes ingresar al sistema mas \n de 2 veces al dia");
				alert_Error.ShowDialog();
			}
			else
			{
				InsertDate(dataTable);
			}
		}
		else
		{
			Alert_Error alert_Error2 = new Alert_Error("Usuario No Registrado en el Sistema");
			alert_Error2.ShowDialog();
		}
		txtCod.Text = "";
	}

	private void InsertDate(DataTable tb)
	{
		DateTime now = DateTime.Now;
		emp.id = tb.Rows[0]["idEmpleado"].ToString();
		emp.Fecha_N = now.ToString("dd/MMMM/yyyy");
		string hora_in = now.ToString("hh:mm:ss tt");
		emp.InsertHour(hora_in, "");
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Application.Exit();
	}

	private void button3_Click(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Minimized;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Login));
		panel1 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		dtme = new System.Windows.Forms.DateTimePicker();
		label1 = new System.Windows.Forms.Label();
		txtCod = new System.Windows.Forms.TextBox();
		button3 = new System.Windows.Forms.Button();
		panel2 = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		toolTip1 = new System.Windows.Forms.ToolTip(components);
		panel1.SuspendLayout();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(pictureBox1);
		panel1.Controls.Add(txtCod);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(panel2);
		panel1.Controls.Add(button3);
		panel1.Controls.Add(button1);
		panel1.Controls.Add(dtme);
		panel1.Location = new System.Drawing.Point(1, -1);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(735, 384);
		panel1.TabIndex = 0;
		button1.BackColor = System.Drawing.Color.Maroon;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(685, 3);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(34, 30);
		button1.TabIndex = 6;
		button1.Text = "X";
		toolTip1.SetToolTip(button1, "Cerrar (Alt + F4)");
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		dtme.Location = new System.Drawing.Point(516, 342);
		dtme.Name = "dtme";
		dtme.Size = new System.Drawing.Size(200, 20);
		dtme.TabIndex = 4;
		dtme.Visible = false;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Impact", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(327, 98);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(389, 39);
		label1.TabIndex = 3;
		label1.Text = "Escanea tu Codigo de Barras";
		txtCod.BackColor = System.Drawing.Color.White;
		txtCod.BorderStyle = System.Windows.Forms.BorderStyle.None;
		txtCod.ForeColor = System.Drawing.Color.White;
		txtCod.Location = new System.Drawing.Point(433, 210);
		txtCod.Name = "txtCod";
		txtCod.Size = new System.Drawing.Size(147, 13);
		txtCod.TabIndex = 1;
		txtCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCod_KeyPress);
		button3.BackColor = System.Drawing.Color.Gold;
		button3.Cursor = System.Windows.Forms.Cursors.Hand;
		button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button3.ForeColor = System.Drawing.Color.White;
		button3.Location = new System.Drawing.Point(645, 3);
		button3.Name = "button3";
		button3.Size = new System.Drawing.Size(34, 30);
		button3.TabIndex = 14;
		button3.Text = "-";
		button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		toolTip1.SetToolTip(button3, "Minimizar");
		button3.UseVisualStyleBackColor = false;
		button3.Click += new System.EventHandler(button3_Click);
		panel2.BackColor = System.Drawing.Color.FromArgb(68, 140, 202);
		panel2.Controls.Add(pictureBox2);
		panel2.Location = new System.Drawing.Point(0, 0);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(304, 402);
		panel2.TabIndex = 15;
		pictureBox1.Image = BLUPOINT.Properties.Resources.codigo_de_barras;
		pictureBox1.Location = new System.Drawing.Point(422, 156);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(172, 95);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 17;
		pictureBox1.TabStop = false;
		pictureBox2.Image = BLUPOINT.Properties.Resources.icono;
		pictureBox2.Location = new System.Drawing.Point(39, 22);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(178, 184);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 0;
		pictureBox2.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(723, 369);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Login";
		base.Opacity = 0.9;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Login";
		base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Login_KeyPress);
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		ResumeLayout(false);
	}
}
