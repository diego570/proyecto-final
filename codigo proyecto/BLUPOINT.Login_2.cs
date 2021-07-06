// BLUPOINT.Login_2
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Source;

public class Login_2 : Form
{
	private Empleados emp;

	private IContainer components = null;

	private Panel panel1;

	private DateTimePicker dtme;

	private Label lblnombre;

	private TextBox txtName;

	private Label lblpass;

	private TextBox txtPass;

	private Button button1;

	private Button button2;

	private Timer timer1;

	private Button button3;

	private PictureBox pictureBox1;

	private PictureBox pictureBox3;

	private PictureBox pictureBox2;

	private ToolTip toolTip1;

	public Login_2()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		emp = new Empleados();
		emp.Nombre_E = txtName.Text;
		emp.Pass = txtPass.Text;
		DataTable dataTable = emp.Login2();
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
		txtName.Focus();
	}

	private void InsertDate(DataTable tb)
	{
		emp.id = tb.Rows[0]["idEmpleado"].ToString();
		DateTime now = DateTime.Now;
		emp.Fecha_N = now.ToString("dd/MMMM/yyyy");
		string hora_in = now.ToString("hh:mm:ss tt");
		emp.InsertHour(hora_in, "");
	}

	private void txtName_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			txtPass.Focus();
		}
	}

	private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			emp = new Empleados();
			emp.Nombre_E = txtName.Text;
			emp.Pass = txtPass.Text;
			DataTable dataTable = emp.Login2();
			if (dataTable.Rows.Count.ToString() != "0")
			{
				InsertDate(dataTable);
				string cargo = dataTable.Rows[0]["Tipo_Emp"].ToString();
				string car = dataTable.Rows[0]["Producto"].ToString();
				string car2 = dataTable.Rows[0]["Usuario"].ToString();
				string car3 = dataTable.Rows[0]["Caja"].ToString();
				string car4 = dataTable.Rows[0]["Cliente"].ToString();
				string ruta = dataTable.Rows[0]["Imagen"].ToString();
				string nombre = dataTable.Rows[0]["Nombre"].ToString() + " " + dataTable.Rows[0]["Apellidos"].ToString();
				string id = dataTable.Rows[0]["idEmpleado"].ToString();
				Form1 form = new Form1(nombre, ruta, cargo, id, car, car2, car4, car3);
				Hide();
				form.Show();
			}
			else
			{
				Alert_Error alert_Error = new Alert_Error("Usuario No Registrado en el Sistema");
				alert_Error.ShowDialog();
			}
			txtName.Focus();
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Application.Exit();
	}

	private void txtPass_TextChanged(object sender, EventArgs e)
	{
	}

	private void txtPass_Enter(object sender, EventArgs e)
	{
		lblpass.Location = new Point(54, 210);
	}

	private void txtPass_Leave(object sender, EventArgs e)
	{
		if (txtPass.Text == "")
		{
			lblpass.Location = new Point(54, 234);
		}
	}

	private void txtName_Enter(object sender, EventArgs e)
	{
		lblnombre.Location = new Point(54, 128);
	}

	private void txtName_Leave(object sender, EventArgs e)
	{
		if (txtName.Text == "")
		{
			lblnombre.Location = new Point(54, 151);
		}
	}

	private void button3_Click(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Minimized;
	}

	private void button1_Enter(object sender, EventArgs e)
	{
		pictureBox1.BackColor = Color.DodgerBlue;
	}

	private void button1_Leave(object sender, EventArgs e)
	{
		pictureBox1.BackColor = Color.FromArgb(54, 185, 219);
	}

	private void button1_MouseHover(object sender, EventArgs e)
	{
		pictureBox1.BackColor = Color.FromArgb(48, 166, 197);
	}

	private void button1_MouseLeave(object sender, EventArgs e)
	{
		pictureBox1.BackColor = Color.FromArgb(54, 185, 219);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Login_2));
		panel1 = new System.Windows.Forms.Panel();
		button3 = new System.Windows.Forms.Button();
		button2 = new System.Windows.Forms.Button();
		button1 = new System.Windows.Forms.Button();
		lblpass = new System.Windows.Forms.Label();
		txtPass = new System.Windows.Forms.TextBox();
		dtme = new System.Windows.Forms.DateTimePicker();
		lblnombre = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.TextBox();
		timer1 = new System.Windows.Forms.Timer(components);
		pictureBox3 = new System.Windows.Forms.PictureBox();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		toolTip1 = new System.Windows.Forms.ToolTip(components);
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(pictureBox3);
		panel1.Controls.Add(pictureBox2);
		panel1.Controls.Add(pictureBox1);
		panel1.Controls.Add(button3);
		panel1.Controls.Add(button2);
		panel1.Controls.Add(button1);
		panel1.Controls.Add(lblpass);
		panel1.Controls.Add(txtPass);
		panel1.Controls.Add(dtme);
		panel1.Controls.Add(lblnombre);
		panel1.Controls.Add(txtName);
		panel1.Location = new System.Drawing.Point(2, 1);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(754, 335);
		panel1.TabIndex = 1;
		button3.BackColor = System.Drawing.Color.Gold;
		button3.Cursor = System.Windows.Forms.Cursors.Hand;
		button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button3.ForeColor = System.Drawing.Color.White;
		button3.Location = new System.Drawing.Point(40, 0);
		button3.Name = "button3";
		button3.Size = new System.Drawing.Size(34, 30);
		button3.TabIndex = 13;
		button3.Text = "-";
		button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		toolTip1.SetToolTip(button3, "Minimizar");
		button3.UseVisualStyleBackColor = false;
		button3.Click += new System.EventHandler(button3_Click);
		button2.BackColor = System.Drawing.Color.Maroon;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Location = new System.Drawing.Point(0, 0);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(34, 30);
		button2.TabIndex = 12;
		button2.Text = "X";
		button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		toolTip1.SetToolTip(button2, "Cerrar (Alt + F4)");
		button2.UseVisualStyleBackColor = false;
		button2.Click += new System.EventHandler(button2_Click);
		button1.BackColor = System.Drawing.Color.FromArgb(54, 185, 219);
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Impact", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		button1.Location = new System.Drawing.Point(456, -8);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(296, 338);
		button1.TabIndex = 11;
		button1.Text = "Iniciar Sesion";
		button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		button1.Enter += new System.EventHandler(button1_Enter);
		button1.Leave += new System.EventHandler(button1_Leave);
		button1.MouseLeave += new System.EventHandler(button1_MouseLeave);
		button1.MouseHover += new System.EventHandler(button1_MouseHover);
		lblpass.AutoSize = true;
		lblpass.BackColor = System.Drawing.Color.White;
		lblpass.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblpass.Location = new System.Drawing.Point(54, 234);
		lblpass.Name = "lblpass";
		lblpass.Size = new System.Drawing.Size(89, 21);
		lblpass.TabIndex = 7;
		lblpass.Text = "Contraseña";
		txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtPass.ForeColor = System.Drawing.Color.Black;
		txtPass.Location = new System.Drawing.Point(47, 226);
		txtPass.Name = "txtPass";
		txtPass.PasswordChar = '*';
		txtPass.Size = new System.Drawing.Size(309, 38);
		txtPass.TabIndex = 6;
		txtPass.TextChanged += new System.EventHandler(txtPass_TextChanged);
		txtPass.Enter += new System.EventHandler(txtPass_Enter);
		txtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtPass_KeyPress);
		txtPass.Leave += new System.EventHandler(txtPass_Leave);
		dtme.Location = new System.Drawing.Point(92, 6);
		dtme.Name = "dtme";
		dtme.Size = new System.Drawing.Size(200, 20);
		dtme.TabIndex = 4;
		dtme.Visible = false;
		lblnombre.AutoSize = true;
		lblnombre.BackColor = System.Drawing.Color.White;
		lblnombre.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblnombre.Location = new System.Drawing.Point(54, 151);
		lblnombre.Name = "lblnombre";
		lblnombre.Size = new System.Drawing.Size(147, 21);
		lblnombre.TabIndex = 3;
		lblnombre.Text = "Nombre de Usuario";
		txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtName.ForeColor = System.Drawing.Color.Black;
		txtName.Location = new System.Drawing.Point(47, 143);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(309, 38);
		txtName.TabIndex = 1;
		txtName.Enter += new System.EventHandler(txtName_Enter);
		txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtName_KeyPress);
		txtName.Leave += new System.EventHandler(txtName_Leave);
		timer1.Interval = 2;
		pictureBox3.Image = (System.Drawing.Image)resources.GetObject("pictureBox3.Image");
		pictureBox3.Location = new System.Drawing.Point(3, 223);
		pictureBox3.Name = "pictureBox3";
		pictureBox3.Size = new System.Drawing.Size(39, 41);
		pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox3.TabIndex = 16;
		pictureBox3.TabStop = false;
		pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
		pictureBox2.Location = new System.Drawing.Point(3, 140);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(39, 41);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 15;
		pictureBox2.TabStop = false;
		pictureBox1.BackColor = System.Drawing.Color.FromArgb(54, 185, 219);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		pictureBox1.Location = new System.Drawing.Point(526, 78);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(166, 157);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 14;
		pictureBox1.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(754, 331);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Login_2";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Login_2";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}
}
