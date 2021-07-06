// BLUPOINT.Corte_Caja2
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Corte_Caja2 : Form
{
	private Caja cj = new Caja();

	private string ids;

	private IContainer components = null;

	private Panel panel1;

	private Panel panel2;

	private Panel panel3;

	private PictureBox pictureBox3;

	public TextBox txtRetBox;

	private PictureBox pictureBox2;

	private Label label5;

	private Button button1;

	private Label txttotalcaja;

	private Label label19;

	private Label label18;

	private GroupBox groupBox2;

	private Label txttipo_e;

	private Label txtname;

	private Label label8;

	private Label label9;

	private Label label10;

	private GroupBox groupBox1;

	private Label txtfecha;

	private Label txtbox;

	private Label label3;

	private Label label2;

	private Label label1;

	private Label label7;

	private PictureBox pictureBox1;

	private Label label15;

	public TextBox txtce;

	private Label label11;

	private Label label6;

	private Label txttde;

	private Label txtte;

	private PrintDocument printDocument1;

	private DateTimePicker dtm;

	public Corte_Caja2(string nombre, string tipo)
	{
		InitializeComponent();
		base.KeyPreview = true;
		base.KeyDown += Corte_Caja2_KeyUp;
		txttipo_e.Text = tipo;
		txtname.Text = nombre;
		txtfecha.Text = cj.GETBoxid();
		LoadMoney();
	}

	private void txtce_TextChanged(object sender, EventArgs e)
	{
		if (txtce.Text == "")
		{
			return;
		}
		try
		{
			suma();
			txttde.Enabled = true;
			if (txtce.Text == txtte.Text)
			{
				txttde.Text = "0.0";
				return;
			}
			double num = Convert.ToDouble(txtce.Text);
			double num2 = Convert.ToDouble(txtte.Text);
			txttde.Text = (num - num2).ToString();
		}
		catch
		{
			MessageBox.Show("Solo se pueden introducir numeros");
			txtce.Text = "";
		}
	}

	private void LoadMoney()
	{
		try
		{
			DataTable dataTable = new DataTable();
			dataTable = cj.GETMONEY();
			txtbox.Text = dataTable.Rows[0]["Nombre_Caja"].ToString();
			txttotalcaja.Text = dataTable.Rows[0]["Cantidad"].ToString();
			txtte.Text = dataTable.Rows[0]["Cantidad"].ToString();
			ids = dataTable.Rows[0]["idCaja"].ToString();
		}
		catch
		{
		}
	}

	private void suma()
	{
		try
		{
			double num = Convert.ToDouble(txtce.Text);
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = num + num2 + num3;
		}
		catch
		{
		}
	}

	private void txtRetBox_TextChanged(object sender, EventArgs e)
	{
		if (!(txtRetBox.Text == ""))
		{
			try
			{
				double num = Convert.ToDouble(txtRetBox.Text);
			}
			catch
			{
				MessageBox.Show("Solo se pueden introducir numeros");
				txtRetBox.Text = "";
			}
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		Dinero dinero = new Dinero("Corte_Caja");
		AddOwnedForm(dinero);
		dinero.ShowDialog();
	}

	private void pictureBox3_Click(object sender, EventArgs e)
	{
		Dinero dinero = new Dinero("Retiro_Caja");
		AddOwnedForm(dinero);
		dinero.ShowDialog();
	}

	private void pictureBox2_Click(object sender, EventArgs e)
	{
		Salidas salidas = new Salidas(txtname.Text, txttipo_e.Text, ids);
		salidas.ShowDialog();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			if (txtce.Text == "" || txtce.Text == "0" || txtce.Text == "0.0")
			{
				MessageBox.Show("Debes introducir la cantidad actual de dinero en tu caja");
				return;
			}
			if (Convert.ToDouble(txtce.Text) < 0.0)
			{
				MessageBox.Show("No puedes ingresar numeros negativos, ni caratceres especiales o letras");
				return;
			}
			if (txtRetBox.Text == "" || txtRetBox.Text == "0.0" || txtRetBox.Text == "0")
			{
				cj.id_caja = ids;
				cj.Usuario = txtname.Text;
				cj.Contado = txtce.Text;
				cj.Calculado = txttotalcaja.Text;
				cj.Diferencia = txttde.Text;
				cj.Retirado = txtRetBox.Text;
				DateTime now = DateTime.Now;
				cj.Fecha = now.ToString("dd/MMMM/yyyy");
				if (cj.RealizarCorte() == 1)
				{
					if (MessageBox.Show("Corte de Caja Realizado, Deseas Imprimir un ticket?", "Realizado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Print();
					}
					LoadMoney();
					limpiar();
				}
				else
				{
					MessageBox.Show("Ha ocurrido un error, contacta con soporte tecnico");
				}
				return;
			}
			RegsitrarSalida();
			cj.id_caja = ids;
			cj.Usuario = txtname.Text;
			cj.Contado = txtce.Text;
			cj.Calculado = txttotalcaja.Text;
			cj.Diferencia = txttde.Text;
			cj.Retirado = txtRetBox.Text;
			DateTime now2 = DateTime.Now;
			cj.Fecha = now2.ToString("dd/MMMM/yyyy");
			if (cj.RealizarCorte() == 1)
			{
				if (MessageBox.Show("Corte de Caja Realizado, Deseas Imprimir el ticket?", "Realizado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Print();
				}
				LoadMoney();
				limpiar();
			}
			else
			{
				MessageBox.Show("Ha ocurrido un error, contacta con soporte tecnico");
			}
		}
		catch
		{
			MessageBox.Show("Ha ocurrido un error, contacta con soporte tecnico");
		}
	}

	private void RegsitrarSalida()
	{
		cj.concepto = "Retiro de Dinero";
		cj.Cantidad = txtRetBox.Text;
		DateTime now = DateTime.Now;
		cj.Fecha = now.ToString("dd/MMMM/yyyy");
		cj.INSERTEXIT(txtname.Text, txttipo_e.Text);
	}

	private void limpiar()
	{
		txtce.Text = "0.0";
		txtRetBox.Text = "0.0";
		txttde.Text = "0.0";
		txttde.Enabled = false;
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
		double num = Convert.ToDouble(txttotalcaja.Text);
		double num2 = Convert.ToDouble(txtRetBox.Text);
		double num3 = num - num2;
		Negocio negocio = new Negocio();
		DataTable dataTable = new DataTable();
		dataTable = negocio.GetNegocio();
		string s = "Calle: " + dataTable.Rows[0]["Calle"].ToString() + ", #" + dataTable.Rows[0]["Numero_Ext"].ToString() + ", Col. " + dataTable.Rows[0]["Colonia"].ToString() + "\n" + dataTable.Rows[0]["Municipio"].ToString() + ", " + dataTable.Rows[0]["Estado"].ToString() + ", C.P: " + dataTable.Rows[0]["CP"].ToString();
		Font font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point);
		Font font2 = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Point);
		Font font3 = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point);
		Font font4 = new Font("Segoe UI", 5f, FontStyle.Regular, GraphicsUnit.Point);
		Font font5 = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point);
		int num4 = 220;
		int num5 = 20;
		e.Graphics.DrawString(" ***" + dataTable.Rows[0]["Nombre_N"].ToString() + "*** ", font, Brushes.Black, new RectangleF(0f, num5 += 10, num4, 20f));
		e.Graphics.DrawString(s, font3, Brushes.Black, new RectangleF(8f, num5 += 20, num4, num5 + 20));
		e.Graphics.DrawString("Tel: " + dataTable.Rows[0]["Telefono"].ToString(), font3, Brushes.Black, new RectangleF(8f, num5 += 25, num4, num5 + 15));
		e.Graphics.DrawString("Corte de Caja", font3, Brushes.Black, new RectangleF(8f, num5 += 20, num4, num5 + 20));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("Total en Caja:\t\t$" + txttotalcaja.Text, font, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("Retiro de Caja:\t\t$" + txtRetBox.Text, font, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("Total Actual en Caja:\t$" + num3, font5, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("Corte por:  " + txtname.Text, font3, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("Fecha de Corte: " + dtm.Value.Day + "/" + dtm.Value.Month + "/" + dtm.Value.Year + " " + dtm.Value.Hour + ":" + dtm.Value.Minute + ":" + dtm.Value.Second, font3, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
	}

	private void Corte_Caja2_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F5)
		{
			Salidas salidas = new Salidas(txtname.Text, txttipo_e.Text, ids);
			salidas.ShowDialog();
		}
	}

	private void txtRetBox_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\r')
		{
			return;
		}
		try
		{
			if (txtce.Text == "" || txtce.Text == "0" || txtce.Text == "0.0")
			{
				MessageBox.Show("Debes introducir la cantidad actual de dinero en tu caja");
				return;
			}
			if (Convert.ToDouble(txtce.Text) < 0.0)
			{
				MessageBox.Show("No puedes ingresar numeros negativos, ni caratceres especiales o letras");
				return;
			}
			if (txtRetBox.Text == "" || txtRetBox.Text == "0.0" || txtRetBox.Text == "0")
			{
				cj.id_caja = ids;
				cj.Usuario = txtname.Text;
				cj.Contado = txtce.Text;
				cj.Calculado = txttotalcaja.Text;
				cj.Diferencia = txttde.Text;
				cj.Retirado = txtRetBox.Text;
				DateTime now = DateTime.Now;
				cj.Fecha = now.ToString("dd/MMMM/yyyy");
				if (cj.RealizarCorte() == 1)
				{
					if (MessageBox.Show("Corte de Caja realizado, Deseas Imprimir el ticket??", "Imprimir ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Print();
					}
					LoadMoney();
					limpiar();
				}
				else
				{
					MessageBox.Show("Ha ocurrido un error, contacta con soporte tecnico");
				}
				return;
			}
			RegsitrarSalida();
			cj.id_caja = ids;
			cj.Usuario = txtname.Text;
			cj.Contado = txtce.Text;
			cj.Calculado = txttotalcaja.Text;
			cj.Diferencia = txttde.Text;
			cj.Retirado = txtRetBox.Text;
			DateTime now2 = DateTime.Now;
			cj.Fecha = now2.ToString("dd/MMMM/yyyy");
			if (cj.RealizarCorte() == 1)
			{
				if (MessageBox.Show("Corte de Caja realizado, Deseas Imprimir el ticket??", "Imprimir ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Print();
				}
				LoadMoney();
				limpiar();
			}
			else
			{
				MessageBox.Show("Ha ocurrido un error, contacta con soporte tecnico");
			}
		}
		catch
		{
			MessageBox.Show("Ha ocurrido un error, contacta con soporte tecnico");
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
		panel2 = new System.Windows.Forms.Panel();
		txttde = new System.Windows.Forms.Label();
		txtte = new System.Windows.Forms.Label();
		label7 = new System.Windows.Forms.Label();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label15 = new System.Windows.Forms.Label();
		txtce = new System.Windows.Forms.TextBox();
		label11 = new System.Windows.Forms.Label();
		panel3 = new System.Windows.Forms.Panel();
		label6 = new System.Windows.Forms.Label();
		pictureBox3 = new System.Windows.Forms.PictureBox();
		txtRetBox = new System.Windows.Forms.TextBox();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		label5 = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		txttotalcaja = new System.Windows.Forms.Label();
		label19 = new System.Windows.Forms.Label();
		label18 = new System.Windows.Forms.Label();
		groupBox2 = new System.Windows.Forms.GroupBox();
		txttipo_e = new System.Windows.Forms.Label();
		txtname = new System.Windows.Forms.Label();
		label8 = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		label10 = new System.Windows.Forms.Label();
		groupBox1 = new System.Windows.Forms.GroupBox();
		txtfecha = new System.Windows.Forms.Label();
		txtbox = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		dtm = new System.Windows.Forms.DateTimePicker();
		panel1.SuspendLayout();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		groupBox2.SuspendLayout();
		groupBox1.SuspendLayout();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(panel2);
		panel1.Controls.Add(groupBox2);
		panel1.Controls.Add(groupBox1);
		panel1.Location = new System.Drawing.Point(-8, -2);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(994, 454);
		panel1.TabIndex = 1;
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Controls.Add(txttde);
		panel2.Controls.Add(txtte);
		panel2.Controls.Add(label7);
		panel2.Controls.Add(pictureBox1);
		panel2.Controls.Add(label15);
		panel2.Controls.Add(txtce);
		panel2.Controls.Add(label11);
		panel2.Controls.Add(panel3);
		panel2.Controls.Add(button1);
		panel2.Controls.Add(txttotalcaja);
		panel2.Controls.Add(label19);
		panel2.Controls.Add(label18);
		panel2.Location = new System.Drawing.Point(15, 175);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(951, 265);
		panel2.TabIndex = 7;
		txttde.AutoSize = true;
		txttde.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttde.Location = new System.Drawing.Point(338, 220);
		txttde.Name = "txttde";
		txttde.Size = new System.Drawing.Size(59, 13);
		txttde.TabIndex = 35;
		txttde.Text = "Diferencia";
		txttde.Visible = false;
		txtte.AutoSize = true;
		txtte.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtte.Location = new System.Drawing.Point(213, 220);
		txtte.Name = "txtte";
		txtte.Size = new System.Drawing.Size(71, 13);
		txtte.TabIndex = 34;
		txtte.Text = "Total en caja";
		txtte.Visible = false;
		label7.AutoSize = true;
		label7.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(233, 125);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(183, 13);
		label7.TabIndex = 31;
		label7.Text = "Digita el monto que tienes en caja";
		pictureBox1.Image = BLUPOINT.Properties.Resources.calculadora;
		pictureBox1.Location = new System.Drawing.Point(170, 80);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(37, 40);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 30;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		label15.AutoSize = true;
		label15.Font = new System.Drawing.Font("Segoe UI", 20.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label15.Location = new System.Drawing.Point(288, 38);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(97, 37);
		label15.TabIndex = 29;
		label15.Text = "Monto";
		txtce.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtce.Location = new System.Drawing.Point(224, 82);
		txtce.Name = "txtce";
		txtce.Size = new System.Drawing.Size(202, 38);
		txtce.TabIndex = 28;
		txtce.Text = "0.0";
		txtce.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		txtce.TextChanged += new System.EventHandler(txtce_TextChanged);
		label11.AutoSize = true;
		label11.Font = new System.Drawing.Font("Segoe UI", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label11.Location = new System.Drawing.Point(33, 75);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(131, 45);
		label11.TabIndex = 27;
		label11.Text = "Efectivo";
		panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel3.Controls.Add(label6);
		panel3.Controls.Add(pictureBox3);
		panel3.Controls.Add(txtRetBox);
		panel3.Controls.Add(pictureBox2);
		panel3.Controls.Add(label5);
		panel3.Location = new System.Drawing.Point(568, 3);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(168, 257);
		panel3.TabIndex = 26;
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label6.Location = new System.Drawing.Point(45, 137);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(105, 13);
		label6.TabIndex = 31;
		label6.Text = "Registrar Salida(F5)";
		pictureBox3.Image = BLUPOINT.Properties.Resources.calculadora;
		pictureBox3.Location = new System.Drawing.Point(16, 46);
		pictureBox3.Name = "pictureBox3";
		pictureBox3.Size = new System.Drawing.Size(19, 24);
		pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox3.TabIndex = 30;
		pictureBox3.TabStop = false;
		pictureBox3.Click += new System.EventHandler(pictureBox3_Click);
		txtRetBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtRetBox.Location = new System.Drawing.Point(38, 46);
		txtRetBox.Name = "txtRetBox";
		txtRetBox.Size = new System.Drawing.Size(116, 26);
		txtRetBox.TabIndex = 28;
		txtRetBox.Text = "0.0";
		txtRetBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		txtRetBox.TextChanged += new System.EventHandler(txtRetBox_TextChanged);
		txtRetBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtRetBox_KeyPress);
		pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox2.Image = BLUPOINT.Properties.Resources.ganar_dinero;
		pictureBox2.Location = new System.Drawing.Point(66, 153);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(45, 46);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 24;
		pictureBox2.TabStop = false;
		pictureBox2.Click += new System.EventHandler(pictureBox2_Click);
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.Location = new System.Drawing.Point(38, 18);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(112, 21);
		label5.TabIndex = 29;
		label5.Text = "Retirar de Caja";
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(758, 198);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(188, 51);
		button1.TabIndex = 22;
		button1.Text = "Realizar Corte";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		txttotalcaja.AutoSize = true;
		txttotalcaja.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttotalcaja.Location = new System.Drawing.Point(830, 117);
		txttotalcaja.Name = "txttotalcaja";
		txttotalcaja.Size = new System.Drawing.Size(46, 32);
		txttotalcaja.TabIndex = 21;
		txttotalcaja.Text = "0.0";
		label19.AutoSize = true;
		label19.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label19.Location = new System.Drawing.Point(806, 117);
		label19.Name = "label19";
		label19.Size = new System.Drawing.Size(28, 32);
		label19.TabIndex = 20;
		label19.Text = "$";
		label18.AutoSize = true;
		label18.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label18.Location = new System.Drawing.Point(780, 66);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(132, 30);
		label18.TabIndex = 19;
		label18.Text = "Total en Caja";
		groupBox2.Controls.Add(txttipo_e);
		groupBox2.Controls.Add(txtname);
		groupBox2.Controls.Add(label8);
		groupBox2.Controls.Add(label9);
		groupBox2.Controls.Add(label10);
		groupBox2.Location = new System.Drawing.Point(436, 14);
		groupBox2.Name = "groupBox2";
		groupBox2.Size = new System.Drawing.Size(522, 143);
		groupBox2.TabIndex = 6;
		groupBox2.TabStop = false;
		groupBox2.Text = "INFORMACION DE USUARIO";
		txttipo_e.AutoSize = true;
		txttipo_e.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttipo_e.ForeColor = System.Drawing.SystemColors.Highlight;
		txttipo_e.Location = new System.Drawing.Point(150, 90);
		txttipo_e.Name = "txttipo_e";
		txttipo_e.Size = new System.Drawing.Size(67, 25);
		txttipo_e.TabIndex = 5;
		txttipo_e.Text = "Admin";
		txtname.AutoSize = true;
		txtname.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtname.ForeColor = System.Drawing.SystemColors.HotTrack;
		txtname.Location = new System.Drawing.Point(183, 40);
		txtname.Name = "txtname";
		txtname.Size = new System.Drawing.Size(200, 21);
		txtname.TabIndex = 4;
		txtname.Text = "Alan Jesus Guzman Aguirre";
		label8.AutoSize = true;
		label8.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label8.Location = new System.Drawing.Point(6, 115);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(0, 25);
		label8.TabIndex = 3;
		label9.AutoSize = true;
		label9.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label9.Location = new System.Drawing.Point(6, 90);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(138, 25);
		label9.TabIndex = 2;
		label9.Text = "Rol de Usuario:";
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label10.Location = new System.Drawing.Point(6, 37);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(184, 25);
		label10.TabIndex = 1;
		label10.Text = "Nombre de usuario: ";
		groupBox1.Controls.Add(txtfecha);
		groupBox1.Controls.Add(txtbox);
		groupBox1.Controls.Add(label3);
		groupBox1.Controls.Add(label2);
		groupBox1.Controls.Add(label1);
		groupBox1.Location = new System.Drawing.Point(15, 14);
		groupBox1.Name = "groupBox1";
		groupBox1.Size = new System.Drawing.Size(398, 143);
		groupBox1.TabIndex = 0;
		groupBox1.TabStop = false;
		groupBox1.Text = "INFORMACION DE CAJA";
		txtfecha.AutoSize = true;
		txtfecha.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtfecha.ForeColor = System.Drawing.SystemColors.Highlight;
		txtfecha.Location = new System.Drawing.Point(189, 90);
		txtfecha.Name = "txtfecha";
		txtfecha.Size = new System.Drawing.Size(96, 25);
		txtfecha.TabIndex = 5;
		txtfecha.Text = "12/2/2021";
		txtbox.AutoSize = true;
		txtbox.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtbox.ForeColor = System.Drawing.SystemColors.HotTrack;
		txtbox.Location = new System.Drawing.Point(170, 37);
		txtbox.Name = "txtbox";
		txtbox.Size = new System.Drawing.Size(64, 25);
		txtbox.TabIndex = 4;
		txtbox.Text = "Caja 2";
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(6, 115);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(0, 25);
		label3.TabIndex = 3;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(6, 90);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(177, 25);
		label2.TabIndex = 2;
		label2.Text = "Fecha Ultimo Corte:";
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(6, 37);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(158, 25);
		label1.TabIndex = 1;
		label1.Text = "Nombre de Caja: ";
		dtm.Location = new System.Drawing.Point(653, 458);
		dtm.Name = "dtm";
		dtm.Size = new System.Drawing.Size(200, 20);
		dtm.TabIndex = 2;
		dtm.Visible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(979, 472);
		base.Controls.Add(dtm);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Corte_Caja2";
		Text = "Corte_Caja";
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Corte_Caja2_KeyUp);
		panel1.ResumeLayout(false);
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		groupBox2.ResumeLayout(false);
		groupBox2.PerformLayout();
		groupBox1.ResumeLayout(false);
		groupBox1.PerformLayout();
		ResumeLayout(false);
	}
}
