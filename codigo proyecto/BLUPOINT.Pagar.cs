// BLUPOINT.Pagar
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Pagar : Form
{
	private bool acertar;

	private string tipos;

	private string cantidades;

	private IContainer components = null;

	private Label label1;

	private PictureBox pictureBox1;

	private PictureBox pictureBox2;

	private PictureBox pictureBox3;

	private TextBox textBox1;

	private Label label2;

	private Label label3;

	private Label label4;

	private Label change;

	private TabControl tabControl1;

	private TabPage tabPage1;

	private Label label5;

	private TabPage tabPage2;

	private Label label6;

	private Label label7;

	private Label label8;

	private TextBox txtpay;

	private Label label9;

	private TabPage tabPage3;

	private Label label10;

	private Label label11;

	private Label label12;

	private TextBox textBox3;

	private Label label13;

	private Label txtcred;

	private Label label16;

	private Label txtnombre;

	private Label label14;

	private Label txtalert;

	private TextBox txtcode;

	private DateTimePicker dtm1;

	public Label lblPay;

	private Label label15;

	private Button btntryagarcred;

	private Button button4;

	public Pagar(string nombre, string credito, string tipo, string cantida)
	{
		InitializeComponent();
		tipos = tipo;
		cantidades = cantida;
		Inicio(nombre, credito);
	}

	private void Inicio(string name, string cred)
	{
		txtpay.Enabled = true;
		txtpay.Enabled = false;
		textBox3.Enabled = false;
		if (name == "")
		{
			acertar = false;
			textBox3.Enabled = false;
			return;
		}
		acertar = true;
		txtcred.Text = cred;
		txtnombre.Text = name;
		try
		{
			string text = cantidades;
			char c = '.';
			string[] array = text.Split(c);
			if (array[1] == "5")
			{
				textBox3.Text = cantidades;
			}
			else
			{
				double a = Convert.ToDouble(cantidades);
				textBox3.Text = Math.Round(a).ToString();
			}
			btntryagarcred.Enabled = true;
		}
		catch
		{
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		double num = Convert.ToDouble(cantidades);
		double num2 = Convert.ToDouble("100");
		if (num2 >= num)
		{
			Cambio("100", "Efectivo");
		}
		else
		{
			MessageBox.Show("No puedes Introducir menos del valor de la venta");
		}
	}

	private void Cambio(string cantidad, string tipo_pago)
	{
		Venta venta = base.Owner as Venta;
		venta.txtRecipe.Text = cantidad;
		int num;
		switch (tipo_pago)
		{
		case "Efectivo":
		{
			double num2 = Convert.ToDouble(venta.txttotal.Text);
			double num3 = Convert.ToDouble(cantidad);
			double num4 = num3 - num2;
			string text = num4.ToString();
			try
			{
				char c = '.';
				string[] array = text.Split(c);
				int num5;
				switch (text)
				{
				default:
					num5 = ((text == "0.50") ? 1 : 0);
					break;
				case "0.40":
				case "0.41":
				case "0.42":
				case "0.43":
				case "0.44":
				case "0.45":
				case "0.46":
				case "0.47":
				case "0.48":
				case "0.49":
					num5 = 1;
					break;
				}
				if (num5 != 0)
				{
					venta.txtcambio.Text = "0.5";
				}
				else if (array.Length >= 2)
				{
					if (array[1] == "5")
					{
						venta.txtcambio.Text = num4.ToString();
					}
					else
					{
						venta.txtcambio.Text = Math.Round(num4).ToString();
					}
				}
				else
				{
					venta.txtcambio.Text = Math.Round(num4).ToString();
				}
				venta.txtmetodopago.Text = tipo_pago;
				Close();
			}
			catch
			{
				MessageBox.Show("Error, Por favor contacte a soporte tecnico");
			}
			break;
		}
		case "Credito":
		{
			double num2 = Convert.ToDouble(venta.txttotal.Text);
			double num3 = Convert.ToDouble(cantidad);
			double num4 = num3 - num2;
			venta.txtmetodopago.Text = tipo_pago;
			if (RevisarCambio(textBox3.Text) == change.Text)
			{
				venta.txtcambio.Text = change.Text;
				Close();
			}
			else
			{
				MessageBox.Show("No puedes ingresar una cantidad mas alta ni minima a la cantidad que se debe cobrar");
			}
			break;
		}
		default:
			num = ((tipo_pago == "Tarjeta de Debito") ? 1 : 0);
			goto IL_0283;
		case "Tarjeta de Credito":
			{
				num = 1;
				goto IL_0283;
			}
			IL_0283:
			if (num != 0)
			{
				venta.txtmetodopago.Text = tipo_pago;
				double num2 = Convert.ToDouble(venta.txttotal.Text);
				double num3 = Convert.ToDouble(cantidad);
				double num4 = num3 - num2;
				if (num3 < num2)
				{
					MessageBox.Show("No puedes recibir menos del costo del total de la venta");
					break;
				}
				change.Text = num4.ToString();
				venta.txtcambio.Text = num4.ToString();
				Close();
			}
			break;
		}
		try
		{
		}
		catch
		{
			MessageBox.Show("Ha ocurrido un error");
		}
	}

	private string RevisarCambio(string numerosdeci)
	{
		double num = Convert.ToDouble(cantidades);
		double num2 = Convert.ToDouble(numerosdeci);
		double num3 = num2 - num;
		string text = num3.ToString();
		if (num3 == 0.0)
		{
			change.Text = num3.ToString();
			return num3.ToString();
		}
		decimal d = Convert.ToDecimal(text);
		string text2 = decimal.Round(d, 2).ToString();
		char c = '.';
		string[] array = text2.Split(c);
		long num4 = Convert.ToInt64(array[1]);
		if (array[1] == "5")
		{
			change.Text = text;
			return text;
		}
		if (num4 < 30)
		{
			double num5 = Math.Floor(num3);
			change.Text = "0";
			return "0";
		}
		double num6 = Math.Round(num3);
		change.Text = num6.ToString();
		return num6.ToString();
	}

	private void pictureBox2_Click(object sender, EventArgs e)
	{
		double num = Convert.ToDouble(cantidades);
		double num2 = Convert.ToDouble("200");
		if (num2 >= num)
		{
			Cambio("200", "Efectivo");
		}
		else
		{
			MessageBox.Show("No puedes Introducir menos del valor de la venta");
		}
	}

	private void pictureBox3_Click(object sender, EventArgs e)
	{
		double num = Convert.ToDouble(cantidades);
		double num2 = Convert.ToDouble("500");
		if (num2 >= num)
		{
			Cambio("500", "Efectivo");
		}
		else
		{
			MessageBox.Show("No puedes Introducir menos del valor de la venta");
		}
	}

	private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			double num = Convert.ToDouble(cantidades);
			double num2 = Convert.ToDouble(textBox1.Text);
			char c = '.';
			string[] array = cantidades.Split(c);
			if (num2 >= num || array[0] == textBox1.Text)
			{
				Cambio(textBox1.Text, "Efectivo");
			}
			else
			{
				MessageBox.Show("No puedes Introducir menos del valor de la venta");
			}
		}
	}

	private void Pagar_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\u001b')
		{
			Close();
		}
	}

	private void tabControl1_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1)
		{
			tabControl1.SelectedIndex = 0;
		}
		if (e.KeyCode == Keys.F8)
		{
			Tarjeta tarjeta = new Tarjeta();
			AddOwnedForm(tarjeta);
			tarjeta.Show();
		}
		if (e.KeyCode == Keys.F2)
		{
			tabControl1.SelectedIndex = 1;
		}
		if (e.KeyCode == Keys.F3)
		{
			if (!acertar)
			{
				MessageBox.Show("No se puede dar creito sin estar registrado");
			}
			else
			{
				tabControl1.SelectedIndex = 2;
			}
		}
	}

	private void Insertar()
	{
		int num = dtm1.Value.Month + 1;
		Credito credito = new Credito();
		credito.fecha_P = dtm1.Value.Day + "/" + num + "/" + dtm1.Value.Year;
		credito.Nombre_U = txtnombre.Text;
		credito.Total_P = textBox3.Text;
		credito.INSERT();
	}

	private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\r')
		{
		}
	}

	private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			Cambio(txtpay.Text, "Tarjeta de " + lblPay.Text);
		}
	}

	private void comboBox1_TextChanged(object sender, EventArgs e)
	{
		Venta venta = base.Owner as Venta;
		if (tipos == "1" || venta.txttipo_e.Text == "Admin")
		{
			txtpay.Enabled = true;
			txtpay.Focus();
			return;
		}
		txtpay.Enabled = false;
		txtalert.ForeColor = Color.Red;
		txtcode.Visible = true;
		txtcode.Focus();
	}

	private void tabPage2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
	{
	}

	private void label10_Click(object sender, EventArgs e)
	{
	}

	private void lblPay_TextChanged(object sender, EventArgs e)
	{
		if (lblPay.Text != "")
		{
			txtpay.Text = cantidades;
			Cambio(cantidades, lblPay.Text);
		}
	}

	private void textBox1_TextChanged(object sender, EventArgs e)
	{
		if (!(textBox1.Text == ""))
		{
			try
			{
				double num = Convert.ToDouble(textBox1.Text);
			}
			catch
			{
				MessageBox.Show("Introduce solo numeros");
			}
		}
	}

	private void textBox3_TextChanged(object sender, EventArgs e)
	{
		if (!(textBox3.Text == ""))
		{
			try
			{
				double num = Convert.ToDouble(textBox3.Text);
			}
			catch
			{
				MessageBox.Show("Introduce solo numeros");
				textBox3.Text = "";
			}
		}
	}

	private void btntryagarcred_Click(object sender, EventArgs e)
	{
		Cambio(textBox3.Text, "Credito");
		Insertar();
		int num = dtm1.Value.Month + 1;
		MessageBox.Show("Tiene hasta el " + dtm1.Value.Day + "/" + num + "/" + dtm1.Value.Year + "Para Pagar");
	}

	private void button4_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void txtcode_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			Empleados empleados = new Empleados();
			DataTable dataTable = new DataTable();
			empleados.Clave = txtcode.Text;
			dataTable = empleados.Login();
			if (dataTable.Rows[0]["Tipo_Emp"].ToString() == "Admin")
			{
				txtcode.Visible = false;
				txtpay.Enabled = true;
				txtpay.Focus();
				txtalert.ForeColor = Color.White;
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
		label1 = new System.Windows.Forms.Label();
		pictureBox3 = new System.Windows.Forms.PictureBox();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		textBox1 = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		change = new System.Windows.Forms.Label();
		tabControl1 = new System.Windows.Forms.TabControl();
		tabPage1 = new System.Windows.Forms.TabPage();
		label5 = new System.Windows.Forms.Label();
		tabPage2 = new System.Windows.Forms.TabPage();
		lblPay = new System.Windows.Forms.Label();
		label15 = new System.Windows.Forms.Label();
		txtcode = new System.Windows.Forms.TextBox();
		txtalert = new System.Windows.Forms.Label();
		label6 = new System.Windows.Forms.Label();
		label7 = new System.Windows.Forms.Label();
		label8 = new System.Windows.Forms.Label();
		txtpay = new System.Windows.Forms.TextBox();
		label9 = new System.Windows.Forms.Label();
		tabPage3 = new System.Windows.Forms.TabPage();
		btntryagarcred = new System.Windows.Forms.Button();
		dtm1 = new System.Windows.Forms.DateTimePicker();
		txtcred = new System.Windows.Forms.Label();
		label16 = new System.Windows.Forms.Label();
		txtnombre = new System.Windows.Forms.Label();
		label14 = new System.Windows.Forms.Label();
		label10 = new System.Windows.Forms.Label();
		label11 = new System.Windows.Forms.Label();
		label12 = new System.Windows.Forms.Label();
		textBox3 = new System.Windows.Forms.TextBox();
		label13 = new System.Windows.Forms.Label();
		button4 = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		tabControl1.SuspendLayout();
		tabPage1.SuspendLayout();
		tabPage2.SuspendLayout();
		tabPage3.SuspendLayout();
		SuspendLayout();
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 36f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label1.ForeColor = System.Drawing.Color.SteelBlue;
		label1.Location = new System.Drawing.Point(1, -72);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(314, 65);
		label1.TabIndex = 0;
		label1.Text = "SELECCIONA";
		pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox3.Image = BLUPOINT.Properties.Resources._500;
		pictureBox3.Location = new System.Drawing.Point(464, 69);
		pictureBox3.Name = "pictureBox3";
		pictureBox3.Size = new System.Drawing.Size(178, 84);
		pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox3.TabIndex = 3;
		pictureBox3.TabStop = false;
		pictureBox3.Click += new System.EventHandler(pictureBox3_Click);
		pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox2.Image = BLUPOINT.Properties.Resources._200;
		pictureBox2.Location = new System.Drawing.Point(233, 69);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(178, 84);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 2;
		pictureBox2.TabStop = false;
		pictureBox2.Click += new System.EventHandler(pictureBox2_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox1.Image = BLUPOINT.Properties.Resources._100;
		pictureBox1.Location = new System.Drawing.Point(10, 69);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(178, 84);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 1;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		textBox1.ForeColor = System.Drawing.Color.Black;
		textBox1.Location = new System.Drawing.Point(59, 221);
		textBox1.Name = "textBox1";
		textBox1.Size = new System.Drawing.Size(388, 38);
		textBox1.TabIndex = 4;
		textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
		textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 20.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label2.ForeColor = System.Drawing.Color.Black;
		label2.Location = new System.Drawing.Point(158, 181);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(197, 37);
		label2.TabIndex = 5;
		label2.Text = "Otra Cantidad";
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 20.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.ForeColor = System.Drawing.Color.Black;
		label3.Location = new System.Drawing.Point(436, 262);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(116, 37);
		label3.TabIndex = 6;
		label3.Text = "Cambio";
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 20.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label4.ForeColor = System.Drawing.Color.Black;
		label4.Location = new System.Drawing.Point(558, 262);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(33, 37);
		label4.TabIndex = 7;
		label4.Text = "$";
		change.AutoSize = true;
		change.Font = new System.Drawing.Font("Segoe UI", 20.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		change.ForeColor = System.Drawing.Color.Black;
		change.Location = new System.Drawing.Point(583, 263);
		change.Name = "change";
		change.Size = new System.Drawing.Size(56, 37);
		change.TabIndex = 8;
		change.Text = "0.0";
		tabControl1.Controls.Add(tabPage1);
		tabControl1.Controls.Add(tabPage2);
		tabControl1.Controls.Add(tabPage3);
		tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		tabControl1.Location = new System.Drawing.Point(1, 1);
		tabControl1.Name = "tabControl1";
		tabControl1.SelectedIndex = 0;
		tabControl1.Size = new System.Drawing.Size(682, 340);
		tabControl1.TabIndex = 9;
		tabControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(tabControl1_KeyUp);
		tabPage1.Controls.Add(label5);
		tabPage1.Controls.Add(pictureBox2);
		tabPage1.Controls.Add(pictureBox1);
		tabPage1.Controls.Add(change);
		tabPage1.Controls.Add(label1);
		tabPage1.Controls.Add(label4);
		tabPage1.Controls.Add(pictureBox3);
		tabPage1.Controls.Add(label3);
		tabPage1.Controls.Add(textBox1);
		tabPage1.Controls.Add(label2);
		tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		tabPage1.Location = new System.Drawing.Point(4, 34);
		tabPage1.Name = "tabPage1";
		tabPage1.Padding = new System.Windows.Forms.Padding(3);
		tabPage1.Size = new System.Drawing.Size(674, 302);
		tabPage1.TabIndex = 0;
		tabPage1.Text = "Efectivo (F1)";
		tabPage1.UseVisualStyleBackColor = true;
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 20.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label5.ForeColor = System.Drawing.Color.SteelBlue;
		label5.Location = new System.Drawing.Point(171, 14);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(391, 37);
		label5.TabIndex = 9;
		label5.Text = "SELECCIONA UNA CANTIDAD";
		tabPage2.Controls.Add(lblPay);
		tabPage2.Controls.Add(label15);
		tabPage2.Controls.Add(txtcode);
		tabPage2.Controls.Add(txtalert);
		tabPage2.Controls.Add(label6);
		tabPage2.Controls.Add(label7);
		tabPage2.Controls.Add(label8);
		tabPage2.Controls.Add(txtpay);
		tabPage2.Controls.Add(label9);
		tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		tabPage2.Location = new System.Drawing.Point(4, 34);
		tabPage2.Name = "tabPage2";
		tabPage2.Padding = new System.Windows.Forms.Padding(3);
		tabPage2.Size = new System.Drawing.Size(673, 302);
		tabPage2.TabIndex = 1;
		tabPage2.Text = "Tarjeta (F2)";
		tabPage2.UseVisualStyleBackColor = true;
		tabPage2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(tabPage2_PreviewKeyDown);
		lblPay.AutoSize = true;
		lblPay.ForeColor = System.Drawing.Color.White;
		lblPay.Location = new System.Drawing.Point(561, 22);
		lblPay.Name = "lblPay";
		lblPay.Size = new System.Drawing.Size(0, 25);
		lblPay.TabIndex = 18;
		lblPay.TextChanged += new System.EventHandler(lblPay_TextChanged);
		label15.AutoSize = true;
		label15.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label15.ForeColor = System.Drawing.Color.Black;
		label15.Location = new System.Drawing.Point(6, 9);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(274, 30);
		label15.TabIndex = 17;
		label15.Text = "Selecciona tipo de tarjeta F8";
		txtcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtcode.Location = new System.Drawing.Point(255, 171);
		txtcode.Name = "txtcode";
		txtcode.Size = new System.Drawing.Size(164, 38);
		txtcode.TabIndex = 15;
		txtcode.Visible = false;
		txtcode.KeyDown += new System.Windows.Forms.KeyEventHandler(txtcode_KeyDown);
		txtalert.AutoSize = true;
		txtalert.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtalert.ForeColor = System.Drawing.Color.White;
		txtalert.Location = new System.Drawing.Point(211, 135);
		txtalert.Name = "txtalert";
		txtalert.Size = new System.Drawing.Size(265, 21);
		txtalert.TabIndex = 14;
		txtalert.Text = "Necesitas Permiso del Administrador";
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Segoe UI", 20.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label6.ForeColor = System.Drawing.Color.Black;
		label6.Location = new System.Drawing.Point(380, 232);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(56, 37);
		label6.TabIndex = 13;
		label6.Text = "0.0";
		label7.AutoSize = true;
		label7.Font = new System.Drawing.Font("Segoe UI", 20.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.ForeColor = System.Drawing.Color.Black;
		label7.Location = new System.Drawing.Point(355, 231);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(33, 37);
		label7.TabIndex = 12;
		label7.Text = "$";
		label8.AutoSize = true;
		label8.Font = new System.Drawing.Font("Segoe UI", 20.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label8.ForeColor = System.Drawing.Color.Black;
		label8.Location = new System.Drawing.Point(233, 231);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(116, 37);
		label8.TabIndex = 11;
		label8.Text = "Cambio";
		txtpay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtpay.Location = new System.Drawing.Point(145, 94);
		txtpay.Name = "txtpay";
		txtpay.Size = new System.Drawing.Size(388, 38);
		txtpay.TabIndex = 9;
		txtpay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox2_KeyPress);
		label9.AutoSize = true;
		label9.Font = new System.Drawing.Font("Segoe UI", 20.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label9.ForeColor = System.Drawing.Color.Black;
		label9.Location = new System.Drawing.Point(167, 54);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(354, 37);
		label9.TabIndex = 10;
		label9.Text = "Monto a pagar con tarjeta";
		tabPage3.Controls.Add(btntryagarcred);
		tabPage3.Controls.Add(dtm1);
		tabPage3.Controls.Add(txtcred);
		tabPage3.Controls.Add(label16);
		tabPage3.Controls.Add(txtnombre);
		tabPage3.Controls.Add(label14);
		tabPage3.Controls.Add(label10);
		tabPage3.Controls.Add(label11);
		tabPage3.Controls.Add(label12);
		tabPage3.Controls.Add(textBox3);
		tabPage3.Controls.Add(label13);
		tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		tabPage3.Location = new System.Drawing.Point(4, 34);
		tabPage3.Name = "tabPage3";
		tabPage3.Size = new System.Drawing.Size(673, 302);
		tabPage3.TabIndex = 2;
		tabPage3.Text = "Credito (F3)";
		tabPage3.UseVisualStyleBackColor = true;
		btntryagarcred.BackColor = System.Drawing.Color.SteelBlue;
		btntryagarcred.Enabled = false;
		btntryagarcred.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btntryagarcred.ForeColor = System.Drawing.Color.White;
		btntryagarcred.Location = new System.Drawing.Point(551, 179);
		btntryagarcred.Name = "btntryagarcred";
		btntryagarcred.Size = new System.Drawing.Size(131, 40);
		btntryagarcred.TabIndex = 19;
		btntryagarcred.Text = "Acreditar";
		btntryagarcred.UseVisualStyleBackColor = false;
		btntryagarcred.Click += new System.EventHandler(btntryagarcred_Click);
		dtm1.Location = new System.Drawing.Point(473, 43);
		dtm1.Name = "dtm1";
		dtm1.Size = new System.Drawing.Size(200, 31);
		dtm1.TabIndex = 18;
		dtm1.Visible = false;
		txtcred.AutoSize = true;
		txtcred.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtcred.ForeColor = System.Drawing.Color.Black;
		txtcred.Location = new System.Drawing.Point(237, 43);
		txtcred.Name = "txtcred";
		txtcred.Size = new System.Drawing.Size(22, 25);
		txtcred.TabIndex = 17;
		txtcred.Text = "0";
		label16.AutoSize = true;
		label16.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label16.ForeColor = System.Drawing.Color.Black;
		label16.Location = new System.Drawing.Point(237, 18);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(165, 25);
		label16.TabIndex = 16;
		label16.Text = "Derecho a Credito";
		txtnombre.AutoSize = true;
		txtnombre.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtnombre.ForeColor = System.Drawing.Color.Black;
		txtnombre.Location = new System.Drawing.Point(7, 43);
		txtnombre.Name = "txtnombre";
		txtnombre.Size = new System.Drawing.Size(71, 25);
		txtnombre.TabIndex = 15;
		txtnombre.Text = "Cliente";
		label14.AutoSize = true;
		label14.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label14.ForeColor = System.Drawing.Color.Black;
		label14.Location = new System.Drawing.Point(7, 18);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(176, 25);
		label14.TabIndex = 14;
		label14.Text = "Nombre del Cliente";
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Segoe UI", 20.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label10.ForeColor = System.Drawing.Color.Black;
		label10.Location = new System.Drawing.Point(393, 265);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(56, 37);
		label10.TabIndex = 13;
		label10.Text = "0.0";
		label10.Click += new System.EventHandler(label10_Click);
		label11.AutoSize = true;
		label11.Font = new System.Drawing.Font("Segoe UI", 20.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label11.ForeColor = System.Drawing.Color.Black;
		label11.Location = new System.Drawing.Point(368, 264);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(33, 37);
		label11.TabIndex = 12;
		label11.Text = "$";
		label12.AutoSize = true;
		label12.Font = new System.Drawing.Font("Segoe UI", 20.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label12.ForeColor = System.Drawing.Color.Black;
		label12.Location = new System.Drawing.Point(246, 264);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(116, 37);
		label12.TabIndex = 11;
		label12.Text = "Cambio";
		textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		textBox3.Location = new System.Drawing.Point(145, 179);
		textBox3.Name = "textBox3";
		textBox3.Size = new System.Drawing.Size(388, 38);
		textBox3.TabIndex = 9;
		textBox3.TextChanged += new System.EventHandler(textBox3_TextChanged);
		textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox3_KeyPress);
		label13.AutoSize = true;
		label13.Font = new System.Drawing.Font("Segoe UI", 20.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label13.ForeColor = System.Drawing.Color.Black;
		label13.Location = new System.Drawing.Point(168, 139);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(352, 37);
		label13.TabIndex = 10;
		label13.Text = "Digita la Cantidad a Pagar";
		button4.BackColor = System.Drawing.Color.White;
		button4.Cursor = System.Windows.Forms.Cursors.Hand;
		button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
		button4.Location = new System.Drawing.Point(671, 1);
		button4.Name = "button4";
		button4.Size = new System.Drawing.Size(51, 32);
		button4.TabIndex = 11;
		button4.Text = "X";
		button4.UseVisualStyleBackColor = false;
		button4.Click += new System.EventHandler(button4_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.Control;
		base.ClientSize = new System.Drawing.Size(723, 346);
		base.Controls.Add(button4);
		base.Controls.Add(tabControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "Pagar";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Pagar";
		base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Pagar_KeyPress);
		((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		tabControl1.ResumeLayout(false);
		tabPage1.ResumeLayout(false);
		tabPage1.PerformLayout();
		tabPage2.ResumeLayout(false);
		tabPage2.PerformLayout();
		tabPage3.ResumeLayout(false);
		tabPage3.PerformLayout();
		ResumeLayout(false);
	}
}
