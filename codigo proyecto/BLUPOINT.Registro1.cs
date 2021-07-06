// BLUPOINT.Registro1
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BarcodeLib;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Registro1 : Form
{
	private Empleados emp = new Empleados();

	private string tipos;

	private IContainer components = null;

	private Panel panel3;

	private Label label10;

	private Label label1;

	private Button button1;

	private Panel panel12;

	private Label label4;

	private Panel panel11;

	private Label label3;

	private Panel panel10;

	private Label label2;

	private Panel panel8;

	private Button btnImage;

	private PictureBox Imagen_U;

	private Panel panel7;

	private CheckBox cb4;

	private CheckBox cb3;

	private CheckBox cb2;

	private CheckBox cb1;

	private Panel panel5;

	private Label iD;

	private ComboBox txtCargo;

	private Label label9;

	private DateTimePicker txtFecha;

	private Label label8;

	private TextBox txtApellido;

	private Label label6;

	private TextBox txtNombre;

	private Label label5;

	private Label label7;

	private TextBox txtCodigo;

	private Label txtruta;

	private TextBox txtpass;

	private Label label11;

	private Panel pnlresult;

	private PrintDocument printDocument1;

	public Registro1(string tipo)
	{
		InitializeComponent();
		inicio();
		tipos = tipo;
	}

	private void inicio()
	{
		cb1.Checked = true;
		cb2.Checked = true;
		cb3.Checked = true;
		cb4.Checked = true;
		cb1.Enabled = false;
		cb2.Enabled = false;
		cb3.Enabled = false;
		cb4.Enabled = false;
	}

	private void btnImage_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = "C://Pictures/";
		openFileDialog.Filter = "Archivos de Imagen(*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			Imagen_U.ImageLocation = openFileDialog.FileName;
			txtruta.Text = openFileDialog.FileName;
		}
	}

	private void Guardar()
	{
		emp.Clave = txtCodigo.Text.Trim();
		emp.Nombre_E = txtNombre.Text.Trim();
		emp.Tipo_Emp = txtCargo.Text.Trim();
		emp.Apellido_E = txtApellido.Text.Trim();
		emp.Pass = txtpass.Text.Trim();
		emp.Fecha_N = txtFecha.Value.Day + "/" + txtFecha.Value.Month + "/" + txtFecha.Value.Year;
		if (cb1.Checked)
		{
			emp.usuario = "1";
		}
		else
		{
			emp.usuario = "0";
		}
		if (cb2.Checked)
		{
			emp.Producto = "1";
		}
		else
		{
			emp.Producto = "0";
		}
		if (cb3.Checked)
		{
			emp.Cliente = "1";
		}
		else
		{
			emp.Cliente = "0";
		}
		if (cb4.Checked)
		{
			emp.Caja = "1";
		}
		else
		{
			emp.Caja = "0";
		}
		emp.Imagen = txtruta.Text;
		if (emp.Registrar() == 1)
		{
			Register_2 register_ = new Register_2(tipos);
			register_.Show();
			Hide();
		}
		else if (emp.Registrar() == 0)
		{
			MessageBox.Show("Ha Ocurrido un Error");
		}
		else
		{
			MessageBox.Show("El codigo digitado ya esta en existencia");
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		GenerarCodigo();
		Guardar();
	}

	private void Registro1_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F3)
		{
			if (txtruta.Text == "")
			{
				MessageBox.Show("No puede Dejar La imagen Vacia");
				return;
			}
			GenerarCodigo();
			Guardar();
		}
		else if (e.KeyCode == Keys.F9)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = "C://Pictures/";
			openFileDialog.Filter = "Archivos de Imagen(*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				Imagen_U.ImageLocation = openFileDialog.FileName;
				txtruta.Text = openFileDialog.FileName;
			}
		}
	}

	private void GenerarCodigo()
	{
		try
		{
			Barcode barcode = new Barcode();
			barcode.IncludeLabel = true;
			pnlresult.BackgroundImage = barcode.Encode(TYPE.CODE128, txtCodigo.Text, Color.Black, Color.White, 200, 100);
			Print();
		}
		catch
		{
			MessageBox.Show("Ha ocurrido un problema, contacta con el soporte tecnico");
		}
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
		int num = 20;
		Image backgroundImage = pnlresult.BackgroundImage;
		e.Graphics.DrawImage(backgroundImage, new Rectangle(0, num += 20, 200, 80));
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Registro1));
		panel3 = new System.Windows.Forms.Panel();
		pnlresult = new System.Windows.Forms.Panel();
		txtruta = new System.Windows.Forms.Label();
		panel8 = new System.Windows.Forms.Panel();
		btnImage = new System.Windows.Forms.Button();
		Imagen_U = new System.Windows.Forms.PictureBox();
		label10 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		panel12 = new System.Windows.Forms.Panel();
		label4 = new System.Windows.Forms.Label();
		panel11 = new System.Windows.Forms.Panel();
		label3 = new System.Windows.Forms.Label();
		panel10 = new System.Windows.Forms.Panel();
		label2 = new System.Windows.Forms.Label();
		panel7 = new System.Windows.Forms.Panel();
		cb4 = new System.Windows.Forms.CheckBox();
		cb3 = new System.Windows.Forms.CheckBox();
		cb2 = new System.Windows.Forms.CheckBox();
		cb1 = new System.Windows.Forms.CheckBox();
		panel5 = new System.Windows.Forms.Panel();
		txtpass = new System.Windows.Forms.TextBox();
		label11 = new System.Windows.Forms.Label();
		iD = new System.Windows.Forms.Label();
		txtCargo = new System.Windows.Forms.ComboBox();
		label9 = new System.Windows.Forms.Label();
		txtFecha = new System.Windows.Forms.DateTimePicker();
		label8 = new System.Windows.Forms.Label();
		txtApellido = new System.Windows.Forms.TextBox();
		label6 = new System.Windows.Forms.Label();
		txtNombre = new System.Windows.Forms.TextBox();
		label5 = new System.Windows.Forms.Label();
		label7 = new System.Windows.Forms.Label();
		txtCodigo = new System.Windows.Forms.TextBox();
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		panel3.SuspendLayout();
		panel8.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)Imagen_U).BeginInit();
		panel12.SuspendLayout();
		panel11.SuspendLayout();
		panel10.SuspendLayout();
		panel7.SuspendLayout();
		panel5.SuspendLayout();
		SuspendLayout();
		panel3.BackColor = System.Drawing.Color.White;
		panel3.Controls.Add(pnlresult);
		panel3.Controls.Add(txtruta);
		panel3.Controls.Add(panel8);
		panel3.Controls.Add(label10);
		panel3.Controls.Add(label1);
		panel3.Controls.Add(button1);
		panel3.Controls.Add(panel12);
		panel3.Controls.Add(panel11);
		panel3.Controls.Add(panel10);
		panel3.Controls.Add(panel7);
		panel3.Controls.Add(panel5);
		panel3.Location = new System.Drawing.Point(-1, 0);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(1193, 747);
		panel3.TabIndex = 17;
		pnlresult.BackColor = System.Drawing.Color.White;
		pnlresult.Location = new System.Drawing.Point(852, 287);
		pnlresult.Name = "pnlresult";
		pnlresult.Size = new System.Drawing.Size(200, 100);
		pnlresult.TabIndex = 17;
		txtruta.AutoSize = true;
		txtruta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtruta.Location = new System.Drawing.Point(601, 111);
		txtruta.Name = "txtruta";
		txtruta.Size = new System.Drawing.Size(0, 25);
		txtruta.TabIndex = 16;
		txtruta.Visible = false;
		panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel8.Controls.Add(btnImage);
		panel8.Controls.Add(Imagen_U);
		panel8.Location = new System.Drawing.Point(491, 382);
		panel8.Name = "panel8";
		panel8.Size = new System.Drawing.Size(245, 252);
		panel8.TabIndex = 4;
		btnImage.BackColor = System.Drawing.Color.SteelBlue;
		btnImage.Cursor = System.Windows.Forms.Cursors.Hand;
		btnImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnImage.ForeColor = System.Drawing.Color.White;
		btnImage.Location = new System.Drawing.Point(20, 197);
		btnImage.Name = "btnImage";
		btnImage.Size = new System.Drawing.Size(214, 41);
		btnImage.TabIndex = 2;
		btnImage.Text = "Cargar Imagen (F9)";
		btnImage.UseVisualStyleBackColor = false;
		btnImage.Click += new System.EventHandler(btnImage_Click);
		Imagen_U.Cursor = System.Windows.Forms.Cursors.Arrow;
		Imagen_U.Image = BLUPOINT.Properties.Resources.picture;
		Imagen_U.Location = new System.Drawing.Point(41, 8);
		Imagen_U.Name = "Imagen_U";
		Imagen_U.Size = new System.Drawing.Size(178, 173);
		Imagen_U.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		Imagen_U.TabIndex = 3;
		Imagen_U.TabStop = false;
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label10.Location = new System.Drawing.Point(28, 66);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(692, 42);
		label10.TabIndex = 9;
		label10.Text = resources.GetString("label10.Text");
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(59, 5);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(652, 47);
		label1.TabIndex = 8;
		label1.Text = "CONFIGURA USUARIO ADMINISTRADOR";
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(131, 566);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(250, 68);
		button1.TabIndex = 4;
		button1.Text = "Guardar Usuario (F3)";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		panel12.BackColor = System.Drawing.Color.SteelBlue;
		panel12.Controls.Add(label4);
		panel12.Location = new System.Drawing.Point(489, 340);
		panel12.Name = "panel12";
		panel12.Size = new System.Drawing.Size(245, 39);
		panel12.TabIndex = 7;
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Impact", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label4.ForeColor = System.Drawing.Color.White;
		label4.Location = new System.Drawing.Point(82, 8);
		label4.Name = "label4";
		label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		label4.Size = new System.Drawing.Size(75, 26);
		label4.TabIndex = 2;
		label4.Text = "IMAGEN";
		panel11.BackColor = System.Drawing.Color.SteelBlue;
		panel11.Controls.Add(label3);
		panel11.Location = new System.Drawing.Point(489, 144);
		panel11.Name = "panel11";
		panel11.Size = new System.Drawing.Size(245, 37);
		panel11.TabIndex = 6;
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Impact", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.ForeColor = System.Drawing.Color.White;
		label3.Location = new System.Drawing.Point(3, 6);
		label3.Name = "label3";
		label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		label3.Size = new System.Drawing.Size(239, 26);
		label3.TabIndex = 2;
		label3.Text = "PERMISOS Y HERRAMIENTAS";
		panel10.BackColor = System.Drawing.Color.SteelBlue;
		panel10.Controls.Add(label2);
		panel10.Location = new System.Drawing.Point(12, 144);
		panel10.Name = "panel10";
		panel10.Size = new System.Drawing.Size(445, 38);
		panel10.TabIndex = 6;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Impact", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.ForeColor = System.Drawing.Color.White;
		label2.Location = new System.Drawing.Point(167, 6);
		label2.Name = "label2";
		label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		label2.Size = new System.Drawing.Size(179, 26);
		label2.TabIndex = 1;
		label2.Text = "DATOS DE EMPLEADO";
		panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel7.Controls.Add(cb4);
		panel7.Controls.Add(cb3);
		panel7.Controls.Add(cb2);
		panel7.Controls.Add(cb1);
		panel7.Location = new System.Drawing.Point(489, 182);
		panel7.Name = "panel7";
		panel7.Size = new System.Drawing.Size(245, 147);
		panel7.TabIndex = 3;
		cb4.AutoSize = true;
		cb4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		cb4.Location = new System.Drawing.Point(21, 103);
		cb4.Name = "cb4";
		cb4.Size = new System.Drawing.Size(163, 24);
		cb4.TabIndex = 5;
		cb4.Text = "Cantidad en caja";
		cb4.UseVisualStyleBackColor = true;
		cb3.AutoSize = true;
		cb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		cb3.Location = new System.Drawing.Point(21, 73);
		cb3.Name = "cb3";
		cb3.Size = new System.Drawing.Size(130, 24);
		cb3.TabIndex = 3;
		cb3.Text = "Alta Clientes";
		cb3.UseVisualStyleBackColor = true;
		cb2.AutoSize = true;
		cb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		cb2.Location = new System.Drawing.Point(21, 38);
		cb2.Name = "cb2";
		cb2.Size = new System.Drawing.Size(146, 24);
		cb2.TabIndex = 2;
		cb2.Text = "Alta Productos";
		cb2.UseVisualStyleBackColor = true;
		cb1.AutoSize = true;
		cb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		cb1.Location = new System.Drawing.Point(21, 4);
		cb1.Name = "cb1";
		cb1.Size = new System.Drawing.Size(136, 24);
		cb1.TabIndex = 1;
		cb1.Text = "Alta Usuarios";
		cb1.UseVisualStyleBackColor = true;
		panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel5.Controls.Add(txtpass);
		panel5.Controls.Add(label11);
		panel5.Controls.Add(iD);
		panel5.Controls.Add(txtCargo);
		panel5.Controls.Add(label9);
		panel5.Controls.Add(txtFecha);
		panel5.Controls.Add(label8);
		panel5.Controls.Add(txtApellido);
		panel5.Controls.Add(label6);
		panel5.Controls.Add(txtNombre);
		panel5.Controls.Add(label5);
		panel5.Controls.Add(label7);
		panel5.Controls.Add(txtCodigo);
		panel5.Location = new System.Drawing.Point(12, 182);
		panel5.Name = "panel5";
		panel5.Size = new System.Drawing.Size(445, 367);
		panel5.TabIndex = 1;
		txtpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtpass.Location = new System.Drawing.Point(160, 211);
		txtpass.Name = "txtpass";
		txtpass.PasswordChar = '*';
		txtpass.Size = new System.Drawing.Size(274, 26);
		txtpass.TabIndex = 17;
		label11.AutoSize = true;
		label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label11.Location = new System.Drawing.Point(23, 211);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(102, 20);
		label11.TabIndex = 16;
		label11.Text = "Contraseña";
		iD.AutoSize = true;
		iD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		iD.ForeColor = System.Drawing.Color.White;
		iD.Location = new System.Drawing.Point(24, 2);
		iD.Name = "iD";
		iD.Size = new System.Drawing.Size(0, 25);
		iD.TabIndex = 15;
		txtCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtCargo.FormattingEnabled = true;
		txtCargo.Items.AddRange(new object[1] { "Admin" });
		txtCargo.Location = new System.Drawing.Point(161, 309);
		txtCargo.Name = "txtCargo";
		txtCargo.Size = new System.Drawing.Size(274, 28);
		txtCargo.TabIndex = 14;
		txtCargo.Text = "Selecciona";
		label9.AutoSize = true;
		label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label9.Location = new System.Drawing.Point(24, 317);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(57, 20);
		label9.TabIndex = 13;
		label9.Text = "Cargo";
		txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtFecha.Location = new System.Drawing.Point(204, 260);
		txtFecha.Name = "txtFecha";
		txtFecha.Size = new System.Drawing.Size(230, 26);
		txtFecha.TabIndex = 12;
		label8.AutoSize = true;
		label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label8.Location = new System.Drawing.Point(23, 260);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(153, 20);
		label8.TabIndex = 11;
		label8.Text = "Fecha Nacimiento";
		txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtApellido.Location = new System.Drawing.Point(161, 157);
		txtApellido.Name = "txtApellido";
		txtApellido.Size = new System.Drawing.Size(274, 26);
		txtApellido.TabIndex = 10;
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label6.Location = new System.Drawing.Point(24, 157);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(94, 20);
		label6.TabIndex = 9;
		label6.Text = "Apellido(s)";
		txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtNombre.Location = new System.Drawing.Point(161, 101);
		txtNombre.Name = "txtNombre";
		txtNombre.Size = new System.Drawing.Size(274, 26);
		txtNombre.TabIndex = 8;
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label5.Location = new System.Drawing.Point(24, 104);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(92, 20);
		label5.TabIndex = 7;
		label5.Text = "Nombre(s)";
		label7.AutoSize = true;
		label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(24, 52);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(65, 20);
		label7.TabIndex = 6;
		label7.Text = "Codigo";
		txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtCodigo.Location = new System.Drawing.Point(161, 47);
		txtCodigo.Name = "txtCodigo";
		txtCodigo.Size = new System.Drawing.Size(274, 26);
		txtCodigo.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(767, 655);
		base.Controls.Add(panel3);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Registro1";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Configuracion de Usuario";
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Registro1_KeyUp);
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		panel8.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)Imagen_U).EndInit();
		panel12.ResumeLayout(false);
		panel12.PerformLayout();
		panel11.ResumeLayout(false);
		panel11.PerformLayout();
		panel10.ResumeLayout(false);
		panel10.PerformLayout();
		panel7.ResumeLayout(false);
		panel7.PerformLayout();
		panel5.ResumeLayout(false);
		panel5.PerformLayout();
		ResumeLayout(false);
	}
}
