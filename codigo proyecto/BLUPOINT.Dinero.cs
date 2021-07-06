// BLUPOINT.Dinero
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;

public class Dinero : Form
{
	private string tipo;

	private IContainer components = null;

	private TextBox txtc1;

	private Label label1;

	private Panel panel1;

	private Label label2;

	private Label label3;

	private Label label4;

	private TextBox txtt1;

	private TextBox txtt4;

	private TextBox txtc4;

	private Label label7;

	private TextBox txtt3;

	private TextBox txtc3;

	private Label label6;

	private TextBox txtt2;

	private TextBox txtc2;

	private Label label5;

	private TextBox txtt5;

	private TextBox txtc5;

	private Label label8;

	private TextBox txtt10;

	private TextBox txtt9;

	private TextBox txtc10;

	private TextBox txtc9;

	private Label label13;

	private Label label12;

	private TextBox txtt8;

	private TextBox txtc8;

	private Label label11;

	private TextBox txtt7;

	private TextBox txtc7;

	private Label label10;

	private TextBox txtt6;

	private TextBox txtc6;

	private Label label9;

	private Button button1;

	private Label label14;

	private Label txttotal;

	public Dinero(string type)
	{
		InitializeComponent();
		tipo = type;
	}

	private void txtc1_TextChanged(object sender, EventArgs e)
	{
		if (txtc1.Text != "")
		{
			try
			{
				int num = 0;
				int num2 = Convert.ToInt32(txtc1.Text);
				txtt1.Text = (num2 * 1000).ToString();
				Sumar();
			}
			catch
			{
				MessageBox.Show("Solo se aceptan numeros enteros");
			}
		}
		else
		{
			txtt1.Text = "0";
		}
	}

	private void Sumar()
	{
		int num = Convert.ToInt32(txtt1.Text);
		int num2 = Convert.ToInt32(txtt2.Text);
		int num3 = Convert.ToInt32(txtt3.Text);
		int num4 = Convert.ToInt32(txtt4.Text);
		int num5 = Convert.ToInt32(txtt5.Text);
		int num6 = Convert.ToInt32(txtt6.Text);
		int num7 = Convert.ToInt32(txtt7.Text);
		int num8 = Convert.ToInt32(txtt8.Text);
		int num9 = Convert.ToInt32(txtt9.Text);
		int num10 = Convert.ToInt32(txtt10.Text);
		txttotal.Text = (num + num2 + (num3 + num4) + (num5 + num6) + (num7 + num8) + (num9 + num10)).ToString();
	}

	private void txtc2_TextChanged(object sender, EventArgs e)
	{
		if (txtc2.Text != "")
		{
			try
			{
				int num = 0;
				int num2 = Convert.ToInt32(txtc2.Text);
				txtt2.Text = (num2 * 500).ToString();
				Sumar();
			}
			catch
			{
				MessageBox.Show("Solo se aceptan numeros enteros");
			}
		}
		else
		{
			txtt2.Text = "0";
		}
	}

	private void txtc3_TextChanged(object sender, EventArgs e)
	{
		if (txtc3.Text != "")
		{
			try
			{
				int num = 0;
				int num2 = Convert.ToInt32(txtc3.Text);
				txtt3.Text = (num2 * 200).ToString();
				Sumar();
			}
			catch
			{
				MessageBox.Show("Solo se aceptan numeros enteros");
			}
		}
		else
		{
			txtt3.Text = "0";
		}
	}

	private void txtc4_TextChanged(object sender, EventArgs e)
	{
		if (txtc4.Text != "")
		{
			try
			{
				int num = 0;
				int num2 = Convert.ToInt32(txtc4.Text);
				txtt4.Text = (num2 * 100).ToString();
				Sumar();
			}
			catch
			{
				MessageBox.Show("Solo se aceptan numeros enteros");
			}
		}
		else
		{
			txtt4.Text = "0";
		}
	}

	private void txtc5_TextChanged(object sender, EventArgs e)
	{
		if (txtc5.Text != "")
		{
			try
			{
				int num = 0;
				int num2 = Convert.ToInt32(txtc5.Text);
				txtt5.Text = (num2 * 50).ToString();
				Sumar();
			}
			catch
			{
				MessageBox.Show("Solo se aceptan numeros enteros");
			}
		}
		else
		{
			txtt5.Text = "0";
		}
	}

	private void txtc6_TextChanged(object sender, EventArgs e)
	{
		if (txtc6.Text != "")
		{
			try
			{
				int num = 0;
				int num2 = Convert.ToInt32(txtc6.Text);
				txtt6.Text = (num2 * 20).ToString();
				Sumar();
			}
			catch
			{
				MessageBox.Show("Solo se aceptan numeros enteros");
			}
		}
		else
		{
			txtt6.Text = "0";
		}
	}

	private void txtc7_TextChanged(object sender, EventArgs e)
	{
		if (txtc7.Text != "")
		{
			try
			{
				int num = 0;
				int num2 = Convert.ToInt32(txtc7.Text);
				txtt7.Text = (num2 * 10).ToString();
				Sumar();
			}
			catch
			{
				MessageBox.Show("Solo se aceptan numeros enteros");
			}
		}
		else
		{
			txtt7.Text = "0";
		}
	}

	private void txtc8_TextChanged(object sender, EventArgs e)
	{
		if (txtc8.Text != "")
		{
			try
			{
				int num = 0;
				int num2 = Convert.ToInt32(txtc8.Text);
				txtt8.Text = (num2 * 5).ToString();
				Sumar();
			}
			catch
			{
				MessageBox.Show("Solo se aceptan numeros enteros");
			}
		}
		else
		{
			txtt8.Text = "0";
		}
	}

	private void txtc9_TextChanged(object sender, EventArgs e)
	{
		if (txtc9.Text != "")
		{
			try
			{
				int num = 0;
				int num2 = Convert.ToInt32(txtc9.Text);
				txtt9.Text = (num2 * 2).ToString();
				Sumar();
			}
			catch
			{
				MessageBox.Show("Solo se aceptan numeros enteros");
			}
		}
		else
		{
			txtt9.Text = "0";
		}
	}

	private void txtc10_TextChanged(object sender, EventArgs e)
	{
		if (txtc10.Text != "")
		{
			try
			{
				int num = 0;
				int num2 = Convert.ToInt32(txtc10.Text);
				num = num2;
				txtt10.Text = num.ToString();
				Sumar();
			}
			catch
			{
				MessageBox.Show("Solo se aceptan numeros enteros");
			}
		}
		else
		{
			txtt10.Text = "0";
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		if (tipo == "Caja1")
		{
			Box box = base.Owner as Box;
			box.textBox2.Text = txttotal.Text;
			Close();
		}
		if (tipo == "Corte_Caja")
		{
			Corte_Caja corte_Caja = base.Owner as Corte_Caja;
			corte_Caja.txtce.Text = txttotal.Text;
			Close();
		}
		if (tipo == "Retiro_Caja")
		{
			Corte_Caja corte_Caja2 = base.Owner as Corte_Caja;
			corte_Caja2.txtRetBox.Text = txttotal.Text;
			Close();
		}
	}

	private void txtc1_Enter(object sender, EventArgs e)
	{
		txtc1.Text = "";
	}

	private void txtc2_Enter(object sender, EventArgs e)
	{
		txtc2.Text = "";
	}

	private void txtc3_Enter(object sender, EventArgs e)
	{
		txtc3.Text = "";
	}

	private void txtc4_Enter(object sender, EventArgs e)
	{
		txtc4.Text = "";
	}

	private void txtc5_Enter(object sender, EventArgs e)
	{
		txtc5.Text = "";
	}

	private void txtc6_Enter(object sender, EventArgs e)
	{
		txtc6.Text = "";
	}

	private void txtc7_Enter(object sender, EventArgs e)
	{
		txtc7.Text = "";
	}

	private void txtc8_Enter(object sender, EventArgs e)
	{
		txtc8.Text = "";
	}

	private void txtc9_Enter(object sender, EventArgs e)
	{
		txtc9.Text = "";
	}

	private void txtc10_Enter(object sender, EventArgs e)
	{
		txtc10.Text = "";
	}

	private void txtc1_Leave(object sender, EventArgs e)
	{
		if (txtc1.Text == "" || txtc1.Text == "0")
		{
			txtc1.Text = "0";
		}
	}

	private void txtc2_Leave(object sender, EventArgs e)
	{
		if (txtc2.Text == "" || txtc2.Text == "0")
		{
			txtc2.Text = "0";
		}
	}

	private void txtc3_Leave(object sender, EventArgs e)
	{
		if (txtc3.Text == "" || txtc3.Text == "0")
		{
			txtc3.Text = "0";
		}
	}

	private void txtc4_Leave(object sender, EventArgs e)
	{
		if (txtc4.Text == "" || txtc4.Text == "0")
		{
			txtc4.Text = "0";
		}
	}

	private void txtc5_Leave(object sender, EventArgs e)
	{
		if (txtc5.Text == "" || txtc5.Text == "0")
		{
			txtc5.Text = "0";
		}
	}

	private void txtc6_Leave(object sender, EventArgs e)
	{
		if (txtc6.Text == "" || txtc6.Text == "0")
		{
			txtc6.Text = "0";
		}
	}

	private void txtc7_Leave(object sender, EventArgs e)
	{
		if (txtc7.Text == "" || txtc7.Text == "0")
		{
			txtc7.Text = "0";
		}
	}

	private void txtc8_Leave(object sender, EventArgs e)
	{
		if (txtc8.Text == "" || txtc8.Text == "0")
		{
			txtc8.Text = "0";
		}
	}

	private void txtc9_Leave(object sender, EventArgs e)
	{
		if (txtc9.Text == "" || txtc9.Text == "0")
		{
			txtc9.Text = "0";
		}
	}

	private void txtc10_Leave(object sender, EventArgs e)
	{
		if (txtc10.Text == "" || txtc10.Text == "0")
		{
			txtc10.Text = "0";
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
		txtc1 = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		panel1 = new System.Windows.Forms.Panel();
		txtt10 = new System.Windows.Forms.TextBox();
		txtt9 = new System.Windows.Forms.TextBox();
		txtc10 = new System.Windows.Forms.TextBox();
		txtc9 = new System.Windows.Forms.TextBox();
		label13 = new System.Windows.Forms.Label();
		label12 = new System.Windows.Forms.Label();
		txtt8 = new System.Windows.Forms.TextBox();
		txtc8 = new System.Windows.Forms.TextBox();
		label11 = new System.Windows.Forms.Label();
		txtt7 = new System.Windows.Forms.TextBox();
		txtc7 = new System.Windows.Forms.TextBox();
		label10 = new System.Windows.Forms.Label();
		txtt6 = new System.Windows.Forms.TextBox();
		txtc6 = new System.Windows.Forms.TextBox();
		label9 = new System.Windows.Forms.Label();
		txtt5 = new System.Windows.Forms.TextBox();
		txtc5 = new System.Windows.Forms.TextBox();
		label8 = new System.Windows.Forms.Label();
		txtt4 = new System.Windows.Forms.TextBox();
		txtc4 = new System.Windows.Forms.TextBox();
		label7 = new System.Windows.Forms.Label();
		txtt3 = new System.Windows.Forms.TextBox();
		txtc3 = new System.Windows.Forms.TextBox();
		label6 = new System.Windows.Forms.Label();
		txtt2 = new System.Windows.Forms.TextBox();
		txtc2 = new System.Windows.Forms.TextBox();
		label5 = new System.Windows.Forms.Label();
		txtt1 = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		label14 = new System.Windows.Forms.Label();
		txttotal = new System.Windows.Forms.Label();
		panel1.SuspendLayout();
		SuspendLayout();
		txtc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtc1.Location = new System.Drawing.Point(5, 33);
		txtc1.Name = "txtc1";
		txtc1.Size = new System.Drawing.Size(83, 26);
		txtc1.TabIndex = 0;
		txtc1.Text = "0";
		txtc1.TextChanged += new System.EventHandler(txtc1_TextChanged);
		txtc1.Enter += new System.EventHandler(txtc1_Enter);
		txtc1.Leave += new System.EventHandler(txtc1_Leave);
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.ForeColor = System.Drawing.Color.Teal;
		label1.Location = new System.Drawing.Point(134, 33);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(78, 21);
		label1.TabIndex = 1;
		label1.Text = "x 1000.00";
		panel1.Controls.Add(txtt10);
		panel1.Controls.Add(txtt9);
		panel1.Controls.Add(txtc10);
		panel1.Controls.Add(txtc9);
		panel1.Controls.Add(label13);
		panel1.Controls.Add(label12);
		panel1.Controls.Add(txtt8);
		panel1.Controls.Add(txtc8);
		panel1.Controls.Add(label11);
		panel1.Controls.Add(txtt7);
		panel1.Controls.Add(txtc7);
		panel1.Controls.Add(label10);
		panel1.Controls.Add(txtt6);
		panel1.Controls.Add(txtc6);
		panel1.Controls.Add(label9);
		panel1.Controls.Add(txtt5);
		panel1.Controls.Add(txtc5);
		panel1.Controls.Add(label8);
		panel1.Controls.Add(txtt4);
		panel1.Controls.Add(txtc4);
		panel1.Controls.Add(label7);
		panel1.Controls.Add(txtt3);
		panel1.Controls.Add(txtc3);
		panel1.Controls.Add(label6);
		panel1.Controls.Add(txtt2);
		panel1.Controls.Add(txtc2);
		panel1.Controls.Add(label5);
		panel1.Controls.Add(txtt1);
		panel1.Controls.Add(txtc1);
		panel1.Controls.Add(label1);
		panel1.Location = new System.Drawing.Point(12, 35);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(370, 488);
		panel1.TabIndex = 2;
		txtt10.Enabled = false;
		txtt10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtt10.Location = new System.Drawing.Point(264, 456);
		txtt10.Name = "txtt10";
		txtt10.Size = new System.Drawing.Size(83, 26);
		txtt10.TabIndex = 23;
		txtt10.Text = "0";
		txtt9.Enabled = false;
		txtt9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtt9.Location = new System.Drawing.Point(264, 413);
		txtt9.Name = "txtt9";
		txtt9.Size = new System.Drawing.Size(83, 26);
		txtt9.TabIndex = 26;
		txtt9.Text = "0";
		txtc10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtc10.Location = new System.Drawing.Point(5, 456);
		txtc10.Name = "txtc10";
		txtc10.Size = new System.Drawing.Size(83, 26);
		txtc10.TabIndex = 21;
		txtc10.Text = "0";
		txtc10.TextChanged += new System.EventHandler(txtc10_TextChanged);
		txtc10.Enter += new System.EventHandler(txtc10_Enter);
		txtc10.Leave += new System.EventHandler(txtc10_Leave);
		txtc9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtc9.Location = new System.Drawing.Point(5, 413);
		txtc9.Name = "txtc9";
		txtc9.Size = new System.Drawing.Size(83, 26);
		txtc9.TabIndex = 24;
		txtc9.Text = "0";
		txtc9.TextChanged += new System.EventHandler(txtc9_TextChanged);
		txtc9.Enter += new System.EventHandler(txtc9_Enter);
		txtc9.Leave += new System.EventHandler(txtc9_Leave);
		label13.AutoSize = true;
		label13.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label13.ForeColor = System.Drawing.Color.Teal;
		label13.Location = new System.Drawing.Point(134, 456);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(51, 21);
		label13.TabIndex = 22;
		label13.Text = "x 1.00";
		label12.AutoSize = true;
		label12.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label12.ForeColor = System.Drawing.Color.Teal;
		label12.Location = new System.Drawing.Point(134, 413);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(51, 21);
		label12.TabIndex = 25;
		label12.Text = "x 2.00";
		txtt8.Enabled = false;
		txtt8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtt8.Location = new System.Drawing.Point(264, 371);
		txtt8.Name = "txtt8";
		txtt8.Size = new System.Drawing.Size(83, 26);
		txtt8.TabIndex = 23;
		txtt8.Text = "0";
		txtc8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtc8.Location = new System.Drawing.Point(5, 371);
		txtc8.Name = "txtc8";
		txtc8.Size = new System.Drawing.Size(83, 26);
		txtc8.TabIndex = 21;
		txtc8.Text = "0";
		txtc8.TextChanged += new System.EventHandler(txtc8_TextChanged);
		txtc8.Enter += new System.EventHandler(txtc8_Enter);
		txtc8.Leave += new System.EventHandler(txtc8_Leave);
		label11.AutoSize = true;
		label11.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label11.ForeColor = System.Drawing.Color.Teal;
		label11.Location = new System.Drawing.Point(134, 371);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(51, 21);
		label11.TabIndex = 22;
		label11.Text = "x 5.00";
		txtt7.Enabled = false;
		txtt7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtt7.Location = new System.Drawing.Point(264, 325);
		txtt7.Name = "txtt7";
		txtt7.Size = new System.Drawing.Size(83, 26);
		txtt7.TabIndex = 20;
		txtt7.Text = "0";
		txtc7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtc7.Location = new System.Drawing.Point(5, 325);
		txtc7.Name = "txtc7";
		txtc7.Size = new System.Drawing.Size(83, 26);
		txtc7.TabIndex = 18;
		txtc7.Text = "0";
		txtc7.TextChanged += new System.EventHandler(txtc7_TextChanged);
		txtc7.Enter += new System.EventHandler(txtc7_Enter);
		txtc7.Leave += new System.EventHandler(txtc7_Leave);
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label10.ForeColor = System.Drawing.Color.Teal;
		label10.Location = new System.Drawing.Point(134, 325);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(60, 21);
		label10.TabIndex = 19;
		label10.Text = "x 10.00";
		txtt6.Enabled = false;
		txtt6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtt6.Location = new System.Drawing.Point(264, 276);
		txtt6.Name = "txtt6";
		txtt6.Size = new System.Drawing.Size(83, 26);
		txtt6.TabIndex = 17;
		txtt6.Text = "0";
		txtc6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtc6.Location = new System.Drawing.Point(5, 276);
		txtc6.Name = "txtc6";
		txtc6.Size = new System.Drawing.Size(83, 26);
		txtc6.TabIndex = 15;
		txtc6.Text = "0";
		txtc6.TextChanged += new System.EventHandler(txtc6_TextChanged);
		txtc6.Enter += new System.EventHandler(txtc6_Enter);
		txtc6.Leave += new System.EventHandler(txtc6_Leave);
		label9.AutoSize = true;
		label9.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label9.ForeColor = System.Drawing.Color.Teal;
		label9.Location = new System.Drawing.Point(134, 276);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(60, 21);
		label9.TabIndex = 16;
		label9.Text = "x 20.00";
		txtt5.Enabled = false;
		txtt5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtt5.Location = new System.Drawing.Point(264, 226);
		txtt5.Name = "txtt5";
		txtt5.Size = new System.Drawing.Size(83, 26);
		txtt5.TabIndex = 14;
		txtt5.Text = "0";
		txtc5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtc5.Location = new System.Drawing.Point(5, 226);
		txtc5.Name = "txtc5";
		txtc5.Size = new System.Drawing.Size(83, 26);
		txtc5.TabIndex = 12;
		txtc5.Text = "0";
		txtc5.TextChanged += new System.EventHandler(txtc5_TextChanged);
		txtc5.Enter += new System.EventHandler(txtc5_Enter);
		txtc5.Leave += new System.EventHandler(txtc5_Leave);
		label8.AutoSize = true;
		label8.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label8.ForeColor = System.Drawing.Color.Teal;
		label8.Location = new System.Drawing.Point(134, 226);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(60, 21);
		label8.TabIndex = 13;
		label8.Text = "x 50.00";
		txtt4.Enabled = false;
		txtt4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtt4.Location = new System.Drawing.Point(264, 176);
		txtt4.Name = "txtt4";
		txtt4.Size = new System.Drawing.Size(83, 26);
		txtt4.TabIndex = 11;
		txtt4.Text = "0";
		txtc4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtc4.Location = new System.Drawing.Point(5, 176);
		txtc4.Name = "txtc4";
		txtc4.Size = new System.Drawing.Size(83, 26);
		txtc4.TabIndex = 9;
		txtc4.Text = "0";
		txtc4.TextChanged += new System.EventHandler(txtc4_TextChanged);
		txtc4.Enter += new System.EventHandler(txtc4_Enter);
		txtc4.Leave += new System.EventHandler(txtc4_Leave);
		label7.AutoSize = true;
		label7.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label7.ForeColor = System.Drawing.Color.Teal;
		label7.Location = new System.Drawing.Point(134, 176);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(69, 21);
		label7.TabIndex = 10;
		label7.Text = "x 100.00";
		txtt3.Enabled = false;
		txtt3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtt3.Location = new System.Drawing.Point(264, 129);
		txtt3.Name = "txtt3";
		txtt3.Size = new System.Drawing.Size(83, 26);
		txtt3.TabIndex = 8;
		txtt3.Text = "0";
		txtc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtc3.Location = new System.Drawing.Point(5, 129);
		txtc3.Name = "txtc3";
		txtc3.Size = new System.Drawing.Size(83, 26);
		txtc3.TabIndex = 6;
		txtc3.Text = "0";
		txtc3.TextChanged += new System.EventHandler(txtc3_TextChanged);
		txtc3.Enter += new System.EventHandler(txtc3_Enter);
		txtc3.Leave += new System.EventHandler(txtc3_Leave);
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label6.ForeColor = System.Drawing.Color.Teal;
		label6.Location = new System.Drawing.Point(134, 129);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(69, 21);
		label6.TabIndex = 7;
		label6.Text = "x 200.00";
		txtt2.Enabled = false;
		txtt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtt2.Location = new System.Drawing.Point(264, 81);
		txtt2.Name = "txtt2";
		txtt2.Size = new System.Drawing.Size(83, 26);
		txtt2.TabIndex = 5;
		txtt2.Text = "0";
		txtc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtc2.Location = new System.Drawing.Point(5, 81);
		txtc2.Name = "txtc2";
		txtc2.Size = new System.Drawing.Size(83, 26);
		txtc2.TabIndex = 3;
		txtc2.Text = "0";
		txtc2.TextChanged += new System.EventHandler(txtc2_TextChanged);
		txtc2.Enter += new System.EventHandler(txtc2_Enter);
		txtc2.Leave += new System.EventHandler(txtc2_Leave);
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.ForeColor = System.Drawing.Color.Teal;
		label5.Location = new System.Drawing.Point(134, 81);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(69, 21);
		label5.TabIndex = 4;
		label5.Text = "x 500.00";
		txtt1.Enabled = false;
		txtt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtt1.Location = new System.Drawing.Point(264, 33);
		txtt1.Name = "txtt1";
		txtt1.Size = new System.Drawing.Size(83, 26);
		txtt1.TabIndex = 2;
		txtt1.Text = "0";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(12, 2);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(96, 30);
		label2.TabIndex = 2;
		label2.Text = "Cantidad";
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(145, 2);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(90, 30);
		label3.TabIndex = 3;
		label3.Text = "Moneda";
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(292, 2);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(57, 30);
		label4.TabIndex = 4;
		label4.Text = "Total";
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(17, 529);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(127, 44);
		button1.TabIndex = 5;
		button1.Text = "Aceptar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		label14.AutoSize = true;
		label14.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label14.ForeColor = System.Drawing.Color.Black;
		label14.Location = new System.Drawing.Point(184, 542);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(72, 30);
		label14.TabIndex = 27;
		label14.Text = "TOTAL";
		txttotal.AutoSize = true;
		txttotal.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttotal.ForeColor = System.Drawing.Color.Teal;
		txttotal.Location = new System.Drawing.Point(272, 542);
		txttotal.Name = "txttotal";
		txttotal.Size = new System.Drawing.Size(40, 30);
		txttotal.TabIndex = 28;
		txttotal.Text = "0.0";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(405, 577);
		base.Controls.Add(txttotal);
		base.Controls.Add(label14);
		base.Controls.Add(button1);
		base.Controls.Add(label4);
		base.Controls.Add(label3);
		base.Controls.Add(label2);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Dinero";
		Text = "Dinero";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}
}
