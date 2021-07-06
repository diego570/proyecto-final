// BLUPOINT.Register_2
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Source;

public class Register_2 : Form
{
	private Negocio ne = new Negocio();

	private string tipos;

	private IContainer components = null;

	private Panel panel1;

	private TextBox txtnombre;

	private Label label3;

	private Panel panel2;

	private Panel panel3;

	private Label label1;

	private Panel panel4;

	private Label label2;

	private TextBox txtnoe;

	private TextBox txtcolonia;

	private TextBox txtcalle;

	private TextBox txtcp;

	private Label label9;

	private TextBox txtmuni;

	private Label label8;

	private TextBox txtestado;

	private Label label7;

	private TextBox txtname_f;

	private Label label6;

	private TextBox txtcorreo;

	private Label label5;

	private TextBox txttelefono;

	private Label label4;

	private Panel panel5;

	private Label lblname;

	private Label label12;

	private Label label11;

	private Label label10;

	private Button button2;

	private Button button1;

	private Label label28;

	private Label label27;

	private Label label26;

	private Label label25;

	private Label label24;

	private Label label23;

	private Label label22;

	private Label label21;

	private Label label20;

	private Label label19;

	private Label label18;

	private Label label17;

	private Label label16;

	private Label label15;

	private Label label14;

	private Label label13;

	private Label Phone;

	private Label Domicilio;

	private PrintDocument printDocument1;

	private Label label29;

	public Register_2(string type)
	{
		InitializeComponent();
		tipos = type;
	}

	public void save()
	{
		if (txtnombre.Text != "")
		{
			if (txttelefono.Text != "")
			{
				if (txtcalle.Text != "")
				{
					if (txtcolonia.Text != "")
					{
						if (txtnoe.Text != "")
						{
							if (txtmuni.Text != "")
							{
								if (txtestado.Text != "")
								{
									if (txtcp.Text != "")
									{
										ne.Nombre_N = txtnombre.Text;
										ne.Telefono = txttelefono.Text;
										ne.No_Ext = txtnoe.Text;
										ne.Colonia = txtcolonia.Text;
										ne.Municipio = txtmuni.Text;
										ne.Estado = Estados(txtestado.Text);
										ne.CP = txtcp.Text;
										ne.Nombre_Fiscal = txtname_f.Text;
										ne.Correo = txtcorreo.Text;
										ne.Calle = txtcalle.Text;
										if (ne.INSERT() == 1)
										{
											Complete complete = new Complete(tipos);
											complete.Show();
											Hide();
										}
										else
										{
											MessageBox.Show("Error");
										}
									}
									else
									{
										MessageBox.Show("No puedes dejar ningun campo no opcional vacio");
									}
								}
								else
								{
									MessageBox.Show("No puedes dejar ningun campo no opcional vacio");
								}
							}
							else
							{
								MessageBox.Show("No puedes dejar ningun campo no opcional vacio");
							}
						}
						else
						{
							MessageBox.Show("No puedes dejar ningun campo no opcional vacio");
						}
					}
					else
					{
						MessageBox.Show("No puedes dejar ningun campo no opcional vacio");
					}
				}
				else
				{
					MessageBox.Show("No puedes dejar ningun campo no opcional vacio");
				}
			}
			else
			{
				MessageBox.Show("No puedes dejar ningun campo no opcional vacio");
			}
		}
		else
		{
			MessageBox.Show("No puedes dejar ningun campo no opcional vacio");
		}
	}

	private void txtnombre_TextChanged(object sender, EventArgs e)
	{
		lblname.Text = txtnombre.Text;
	}

	private void txttelefono_TextChanged(object sender, EventArgs e)
	{
		if (txttelefono.Text == "")
		{
			Phone.Text = "Tel: 33675543";
			return;
		}
		try
		{
			long num = Convert.ToInt64(txttelefono.Text);
			Phone.Text = "tel: " + txttelefono.Text;
		}
		catch
		{
			MessageBox.Show("Solo puedes introducir Numeros");
			txttelefono.Text = "";
		}
	}

	private void txtcalle_TextChanged(object sender, EventArgs e)
	{
		if (txtcalle.Text == "")
		{
			Domicilio.Text = "Calle Ejemplo, # 001, Col. Centro\nQueretaro, Qto, C.P:30422";
			txtnoe.Enabled = false;
			txtcolonia.Enabled = false;
		}
		else
		{
			Domicilio.Text = "Calle: " + txtcalle.Text;
			txtnoe.Enabled = true;
		}
	}

	private void txtnoe_TextChanged(object sender, EventArgs e)
	{
		if (txtnoe.Text == "")
		{
			Domicilio.Text = "Calle: " + txtcalle.Text;
			txtcolonia.Enabled = false;
			return;
		}
		Domicilio.Text = "Calle: " + txtcalle.Text + ", #" + txtnoe.Text + ". ";
		txtcolonia.Enabled = true;
	}

	private void txtcolonia_TextChanged(object sender, EventArgs e)
	{
		if (txtcolonia.Text == "")
		{
			Domicilio.Text = "Calle: " + txtcalle.Text + ", #" + txtnoe.Text + ". ";
		}
		else
		{
			Domicilio.Text = "Calle: " + txtcalle.Text + ", #" + txtnoe.Text + ", Col. " + txtcolonia.Text;
		}
	}

	private void txtmuni_TextChanged(object sender, EventArgs e)
	{
		if (txtmuni.Text == "")
		{
			Domicilio.Text = "Calle: " + txtcalle.Text + ", #" + txtnoe.Text + ", Col. " + txtcolonia.Text;
		}
		else
		{
			Domicilio.Text = "Calle: " + txtcalle.Text + ", #" + txtnoe.Text + ", Col. " + txtcolonia.Text + "\n" + txtmuni.Text;
		}
	}

	private string Estados(string estado)
	{
		int num;
		switch (estado)
		{
		default:
			num = ((estado == "Michoacán") ? 1 : 0);
			break;
		case "Michoacan":
		case "michoacan":
		case "michoacán":
			num = 1;
			break;
		}
		if (num != 0)
		{
			estado = "Mich";
			return estado;
		}
		if (estado == "Guanajuato" || estado == "guanajuato")
		{
			estado = "Gto";
			return estado;
		}
		if (estado == "Queretaro" || estado == "queretaro")
		{
			estado = "Qto";
			return estado;
		}
		if (estado == "Guadalajara" || estado == "guadalajara")
		{
			estado = "Gdl";
			return estado;
		}
		int num2;
		switch (estado)
		{
		default:
			num2 = ((estado == "GUANAJUATO") ? 1 : 0);
			break;
		case "MICHOACAN":
		case "GUADALAJARA":
		case "QUERETARO":
			num2 = 1;
			break;
		}
		if (num2 != 0)
		{
			MessageBox.Show("Debes introducir minusculas o solo la inicial con mayuscula");
			return "";
		}
		return estado;
	}

	private void txtestado_TextChanged(object sender, EventArgs e)
	{
		if (txtestado.Text == "")
		{
			Domicilio.Text = "Calle: " + txtcalle.Text + ", #" + txtnoe.Text + ", Col. " + txtcolonia.Text + "\n" + txtmuni.Text;
		}
		else
		{
			Domicilio.Text = "Calle: " + txtcalle.Text + ", #" + txtnoe.Text + ", Col. " + txtcolonia.Text + "\n" + txtmuni.Text + ", " + Estados(txtestado.Text);
		}
	}

	private void txtcp_TextChanged(object sender, EventArgs e)
	{
		if (txtestado.Text == "")
		{
			Domicilio.Text = "Calle: " + txtcalle.Text + ", #" + txtnoe.Text + ", Col. " + txtcolonia.Text + "\n" + txtmuni.Text + ", " + Estados(txtestado.Text);
			return;
		}
		try
		{
			long num = Convert.ToInt64(txtcp.Text);
			Domicilio.Text = "Calle: " + txtcalle.Text + ", #" + txtnoe.Text + ", Col. " + txtcolonia.Text + "\n" + txtmuni.Text + ", " + Estados(txtestado.Text) + ", C.P: " + txtcp.Text;
		}
		catch
		{
			MessageBox.Show("Solo puedes introducir Numeros");
			txtcp.Text = "";
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
		decimal numberAsString = Convert.ToDecimal("900");
		Font font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Point);
		Font font2 = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Point);
		Font font3 = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point);
		Font font4 = new Font("Segoe UI", 5f, FontStyle.Regular, GraphicsUnit.Point);
		Font font5 = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point);
		int num = 220;
		int num2 = 20;
		e.Graphics.DrawString(" *** " + txtnombre.Text + "*** ", font, Brushes.Black, new RectangleF(0f, num2 += 10, num, 20f));
		e.Graphics.DrawString(Domicilio.Text, font3, Brushes.Black, new RectangleF(8f, num2 += 20, num, num2 + 20));
		e.Graphics.DrawString("Ticket Prueba", font3, Brushes.Black, new RectangleF(8f, num2 += 25, num, num2 + 20));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("Nombre \tCant.\t\tImpor.", font3, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("Prod1\t\t12\t\t$230", font3, Brushes.Black, new RectangleF(0f, num2 += 20, 200f, 20f));
		e.Graphics.DrawString("Prod2\t\t2\t\t$100", font3, Brushes.Black, new RectangleF(0f, num2 += 20, 200f, 20f));
		e.Graphics.DrawString("Prod3\t\t8\t\t$70", font3, Brushes.Black, new RectangleF(0f, num2 += 20, 200f, 20f));
		e.Graphics.DrawString("Prod4\t\t10\t\t$500", font3, Brushes.Black, new RectangleF(0f, num2 += 20, 200f, 20f));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("Subtotal:\t\t\t$900", font3, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("Descuento:\t\t\t$0", font3, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("Cambio:\t\t\t\t$0", font3, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("Total:\t\t          $900", font2, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString(numberAsString.NumeroLetras(), font3, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("Atendio:\tNombre Empleado", font3, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("Fecha de Expedicion: 21/1/2021  12:34:22", font3, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("GRACIAS POR SU COMPRA", font5, Brushes.Black, new RectangleF(0f, num2 += 10, num, 20f));
	}

	private void button2_Click(object sender, EventArgs e)
	{
		save();
	}

	private void txtcorreo_TextChanged(object sender, EventArgs e)
	{
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
		button2 = new System.Windows.Forms.Button();
		txtestado = new System.Windows.Forms.TextBox();
		label7 = new System.Windows.Forms.Label();
		txtnoe = new System.Windows.Forms.TextBox();
		txtcolonia = new System.Windows.Forms.TextBox();
		txtcalle = new System.Windows.Forms.TextBox();
		txtcp = new System.Windows.Forms.TextBox();
		label9 = new System.Windows.Forms.Label();
		txtmuni = new System.Windows.Forms.TextBox();
		label8 = new System.Windows.Forms.Label();
		txtname_f = new System.Windows.Forms.TextBox();
		label6 = new System.Windows.Forms.Label();
		txtcorreo = new System.Windows.Forms.TextBox();
		label5 = new System.Windows.Forms.Label();
		txttelefono = new System.Windows.Forms.TextBox();
		label4 = new System.Windows.Forms.Label();
		txtnombre = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		panel2 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		panel5 = new System.Windows.Forms.Panel();
		label29 = new System.Windows.Forms.Label();
		label28 = new System.Windows.Forms.Label();
		label27 = new System.Windows.Forms.Label();
		label26 = new System.Windows.Forms.Label();
		label25 = new System.Windows.Forms.Label();
		label24 = new System.Windows.Forms.Label();
		label23 = new System.Windows.Forms.Label();
		label22 = new System.Windows.Forms.Label();
		label21 = new System.Windows.Forms.Label();
		label20 = new System.Windows.Forms.Label();
		label19 = new System.Windows.Forms.Label();
		label18 = new System.Windows.Forms.Label();
		label17 = new System.Windows.Forms.Label();
		label16 = new System.Windows.Forms.Label();
		label15 = new System.Windows.Forms.Label();
		label14 = new System.Windows.Forms.Label();
		label13 = new System.Windows.Forms.Label();
		Phone = new System.Windows.Forms.Label();
		Domicilio = new System.Windows.Forms.Label();
		lblname = new System.Windows.Forms.Label();
		label12 = new System.Windows.Forms.Label();
		label11 = new System.Windows.Forms.Label();
		panel3 = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
		panel4 = new System.Windows.Forms.Panel();
		label2 = new System.Windows.Forms.Label();
		label10 = new System.Windows.Forms.Label();
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		panel1.SuspendLayout();
		panel2.SuspendLayout();
		panel5.SuspendLayout();
		panel3.SuspendLayout();
		panel4.SuspendLayout();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(button2);
		panel1.Controls.Add(txtestado);
		panel1.Controls.Add(label7);
		panel1.Controls.Add(txtnoe);
		panel1.Controls.Add(txtcolonia);
		panel1.Controls.Add(txtcalle);
		panel1.Controls.Add(txtcp);
		panel1.Controls.Add(label9);
		panel1.Controls.Add(txtmuni);
		panel1.Controls.Add(label8);
		panel1.Controls.Add(txtname_f);
		panel1.Controls.Add(label6);
		panel1.Controls.Add(txtcorreo);
		panel1.Controls.Add(label5);
		panel1.Controls.Add(txttelefono);
		panel1.Controls.Add(label4);
		panel1.Controls.Add(txtnombre);
		panel1.Controls.Add(label3);
		panel1.Location = new System.Drawing.Point(3, 67);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(435, 558);
		panel1.TabIndex = 0;
		button2.BackColor = System.Drawing.Color.Navy;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatAppearance.BorderSize = 0;
		button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Location = new System.Drawing.Point(117, 512);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(205, 43);
		button2.TabIndex = 19;
		button2.Text = "Aceptar";
		button2.UseVisualStyleBackColor = false;
		button2.Click += new System.EventHandler(button2_Click);
		txtestado.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtestado.Location = new System.Drawing.Point(192, 394);
		txtestado.Name = "txtestado";
		txtestado.Size = new System.Drawing.Size(223, 33);
		txtestado.TabIndex = 9;
		txtestado.TextChanged += new System.EventHandler(txtestado_TextChanged);
		label7.AutoSize = true;
		label7.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(112, 405);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(68, 25);
		label7.TabIndex = 8;
		label7.Text = "Estado";
		txtnoe.Enabled = false;
		txtnoe.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtnoe.Location = new System.Drawing.Point(239, 276);
		txtnoe.MaxLength = 5;
		txtnoe.Name = "txtnoe";
		txtnoe.Size = new System.Drawing.Size(45, 33);
		txtnoe.TabIndex = 16;
		txtnoe.Text = "No.E";
		txtnoe.TextChanged += new System.EventHandler(txtnoe_TextChanged);
		txtcolonia.Enabled = false;
		txtcolonia.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtcolonia.Location = new System.Drawing.Point(311, 278);
		txtcolonia.MaxLength = 20;
		txtcolonia.Name = "txtcolonia";
		txtcolonia.Size = new System.Drawing.Size(105, 33);
		txtcolonia.TabIndex = 15;
		txtcolonia.Text = "Colonia";
		txtcolonia.TextChanged += new System.EventHandler(txtcolonia_TextChanged);
		txtcalle.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtcalle.Location = new System.Drawing.Point(93, 278);
		txtcalle.MaxLength = 15;
		txtcalle.Name = "txtcalle";
		txtcalle.Size = new System.Drawing.Size(105, 33);
		txtcalle.TabIndex = 14;
		txtcalle.Text = "Calle";
		txtcalle.TextChanged += new System.EventHandler(txtcalle_TextChanged);
		txtcp.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtcp.Location = new System.Drawing.Point(192, 451);
		txtcp.MaxLength = 5;
		txtcp.Name = "txtcp";
		txtcp.Size = new System.Drawing.Size(223, 33);
		txtcp.TabIndex = 13;
		txtcp.TextChanged += new System.EventHandler(txtcp_TextChanged);
		label9.AutoSize = true;
		label9.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label9.Location = new System.Drawing.Point(138, 462);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(39, 25);
		label9.TabIndex = 12;
		label9.Text = "C.P";
		txtmuni.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtmuni.Location = new System.Drawing.Point(192, 332);
		txtmuni.Name = "txtmuni";
		txtmuni.Size = new System.Drawing.Size(223, 33);
		txtmuni.TabIndex = 11;
		txtmuni.TextChanged += new System.EventHandler(txtmuni_TextChanged);
		label8.AutoSize = true;
		label8.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label8.Location = new System.Drawing.Point(83, 343);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(97, 25);
		label8.TabIndex = 10;
		label8.Text = "Municipio";
		txtname_f.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtname_f.Location = new System.Drawing.Point(193, 210);
		txtname_f.Name = "txtname_f";
		txtname_f.Size = new System.Drawing.Size(223, 33);
		txtname_f.TabIndex = 7;
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label6.Location = new System.Drawing.Point(7, 216);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(174, 25);
		label6.TabIndex = 6;
		label6.Text = "Nombre Fiscal (Op)";
		txtcorreo.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtcorreo.Location = new System.Drawing.Point(193, 150);
		txtcorreo.Name = "txtcorreo";
		txtcorreo.Size = new System.Drawing.Size(223, 33);
		txtcorreo.TabIndex = 5;
		txtcorreo.TextChanged += new System.EventHandler(txtcorreo_TextChanged);
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.Location = new System.Drawing.Point(69, 153);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(117, 25);
		label5.TabIndex = 4;
		label5.Text = "Correo (Op) ";
		txttelefono.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttelefono.Location = new System.Drawing.Point(193, 88);
		txttelefono.MaxLength = 11;
		txttelefono.Name = "txttelefono";
		txttelefono.Size = new System.Drawing.Size(223, 33);
		txttelefono.TabIndex = 3;
		txttelefono.TextChanged += new System.EventHandler(txttelefono_TextChanged);
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(102, 91);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(84, 25);
		label4.TabIndex = 2;
		label4.Text = "Telefono";
		txtnombre.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtnombre.Location = new System.Drawing.Point(193, 23);
		txtnombre.MaxLength = 15;
		txtnombre.Name = "txtnombre";
		txtnombre.Size = new System.Drawing.Size(223, 33);
		txtnombre.TabIndex = 1;
		txtnombre.TextChanged += new System.EventHandler(txtnombre_TextChanged);
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(29, 26);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(157, 25);
		label3.TabIndex = 0;
		label3.Text = "Nombre Negocio";
		panel2.BackColor = System.Drawing.Color.White;
		panel2.Controls.Add(button1);
		panel2.Controls.Add(panel5);
		panel2.Location = new System.Drawing.Point(456, 67);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(349, 558);
		panel2.TabIndex = 1;
		button1.BackColor = System.Drawing.Color.Navy;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(61, 486);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(205, 43);
		button1.TabIndex = 18;
		button1.Text = "Probar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel5.Controls.Add(label29);
		panel5.Controls.Add(label28);
		panel5.Controls.Add(label27);
		panel5.Controls.Add(label26);
		panel5.Controls.Add(label25);
		panel5.Controls.Add(label24);
		panel5.Controls.Add(label23);
		panel5.Controls.Add(label22);
		panel5.Controls.Add(label21);
		panel5.Controls.Add(label20);
		panel5.Controls.Add(label19);
		panel5.Controls.Add(label18);
		panel5.Controls.Add(label17);
		panel5.Controls.Add(label16);
		panel5.Controls.Add(label15);
		panel5.Controls.Add(label14);
		panel5.Controls.Add(label13);
		panel5.Controls.Add(Phone);
		panel5.Controls.Add(Domicilio);
		panel5.Controls.Add(lblname);
		panel5.Controls.Add(label12);
		panel5.Controls.Add(label11);
		panel5.Location = new System.Drawing.Point(43, 24);
		panel5.Name = "panel5";
		panel5.Size = new System.Drawing.Size(246, 428);
		panel5.TabIndex = 0;
		label29.AutoSize = true;
		label29.Font = new System.Drawing.Font("Segoe UI Black", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label29.Location = new System.Drawing.Point(39, 287);
		label29.Name = "label29";
		label29.Size = new System.Drawing.Size(151, 15);
		label29.TabIndex = 40;
		label29.Text = "Total                            $900";
		label28.AutoSize = true;
		label28.Font = new System.Drawing.Font("Segoe UI Black", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label28.Location = new System.Drawing.Point(39, 404);
		label28.Name = "label28";
		label28.Size = new System.Drawing.Size(165, 15);
		label28.TabIndex = 39;
		label28.Text = "GRACIAS POR SU COMPRA";
		label27.AutoSize = true;
		label27.Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label27.Location = new System.Drawing.Point(24, 383);
		label27.Name = "label27";
		label27.Size = new System.Drawing.Size(198, 20);
		label27.TabIndex = 38;
		label27.Text = "***************************";
		label26.AutoSize = true;
		label26.Font = new System.Drawing.Font("Segoe UI", 6f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label26.Location = new System.Drawing.Point(49, 365);
		label26.Name = "label26";
		label26.Size = new System.Drawing.Size(151, 11);
		label26.TabIndex = 37;
		label26.Text = "Fecha de expedicion: 02/11/2021 12:00:03";
		label25.AutoSize = true;
		label25.Font = new System.Drawing.Font("Segoe UI", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label25.Location = new System.Drawing.Point(49, 347);
		label25.Name = "label25";
		label25.Size = new System.Drawing.Size(126, 12);
		label25.TabIndex = 36;
		label25.Text = "Atendio: Nombre Empleado";
		label24.AutoSize = true;
		label24.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label24.Location = new System.Drawing.Point(31, 311);
		label24.Name = "label24";
		label24.Size = new System.Drawing.Size(159, 15);
		label24.TabIndex = 35;
		label24.Text = "NOVESCIENTOS PESOS 0/100";
		label23.AutoSize = true;
		label23.Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label23.Location = new System.Drawing.Point(23, 326);
		label23.Name = "label23";
		label23.Size = new System.Drawing.Size(198, 20);
		label23.TabIndex = 34;
		label23.Text = "***************************";
		label22.AutoSize = true;
		label22.Font = new System.Drawing.Font("Segoe UI Black", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label22.Location = new System.Drawing.Point(39, 265);
		label22.Name = "label22";
		label22.Size = new System.Drawing.Size(136, 15);
		label22.TabIndex = 33;
		label22.Text = "Cambio                       $0";
		label21.AutoSize = true;
		label21.Font = new System.Drawing.Font("Segoe UI Black", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label21.Location = new System.Drawing.Point(39, 244);
		label21.Name = "label21";
		label21.Size = new System.Drawing.Size(136, 15);
		label21.TabIndex = 32;
		label21.Text = "Descuento                 $0";
		label20.AutoSize = true;
		label20.Font = new System.Drawing.Font("Segoe UI Black", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label20.Location = new System.Drawing.Point(39, 226);
		label20.Name = "label20";
		label20.Size = new System.Drawing.Size(150, 15);
		label20.TabIndex = 31;
		label20.Text = "Subtotal                     $900";
		label19.AutoSize = true;
		label19.Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label19.Location = new System.Drawing.Point(23, 206);
		label19.Name = "label19";
		label19.Size = new System.Drawing.Size(198, 20);
		label19.TabIndex = 30;
		label19.Text = "***************************";
		label18.AutoSize = true;
		label18.Font = new System.Drawing.Font("Segoe UI", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label18.Location = new System.Drawing.Point(43, 188);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(138, 12);
		label18.TabIndex = 29;
		label18.Text = "Prod4                 10                     $500";
		label17.AutoSize = true;
		label17.Font = new System.Drawing.Font("Segoe UI", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label17.Location = new System.Drawing.Point(43, 167);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(134, 12);
		label17.TabIndex = 28;
		label17.Text = "Prod3                 8                        $70";
		label16.AutoSize = true;
		label16.Font = new System.Drawing.Font("Segoe UI", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label16.Location = new System.Drawing.Point(43, 146);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(137, 12);
		label16.TabIndex = 27;
		label16.Text = "Prod2                  2                      $100";
		label15.AutoSize = true;
		label15.Font = new System.Drawing.Font("Segoe UI", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label15.Location = new System.Drawing.Point(43, 128);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(138, 12);
		label15.TabIndex = 26;
		label15.Text = "Prod1                 12                     $230";
		label14.AutoSize = true;
		label14.Font = new System.Drawing.Font("Segoe UI", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label14.Location = new System.Drawing.Point(43, 107);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(138, 12);
		label14.TabIndex = 25;
		label14.Text = "Nombre            Cant                  Imp";
		label13.AutoSize = true;
		label13.Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label13.Location = new System.Drawing.Point(19, 87);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(198, 20);
		label13.TabIndex = 24;
		label13.Text = "***************************";
		Phone.AutoSize = true;
		Phone.Font = new System.Drawing.Font("Segoe UI", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		Phone.Location = new System.Drawing.Point(43, 66);
		Phone.Name = "Phone";
		Phone.Size = new System.Drawing.Size(61, 12);
		Phone.TabIndex = 23;
		Phone.Text = "Tel: 33675543";
		Domicilio.AutoSize = true;
		Domicilio.Font = new System.Drawing.Font("Segoe UI", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		Domicilio.Location = new System.Drawing.Point(43, 38);
		Domicilio.Name = "Domicilio";
		Domicilio.Size = new System.Drawing.Size(144, 24);
		Domicilio.TabIndex = 22;
		Domicilio.Text = "Calle Ejemplo, # 001, Col. Centro\r\nQueretaro, Qto, C.P:30422\r\n";
		lblname.AutoSize = true;
		lblname.Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		lblname.Location = new System.Drawing.Point(45, 15);
		lblname.Name = "lblname";
		lblname.Size = new System.Drawing.Size(89, 20);
		lblname.TabIndex = 21;
		lblname.Text = "NOMBRE_P";
		label12.AutoSize = true;
		label12.Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label12.Location = new System.Drawing.Point(183, 16);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(30, 20);
		label12.TabIndex = 20;
		label12.Text = "***";
		label11.AutoSize = true;
		label11.Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label11.Location = new System.Drawing.Point(19, 18);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(30, 20);
		label11.TabIndex = 19;
		label11.Text = "***";
		panel3.BackColor = System.Drawing.Color.SteelBlue;
		panel3.Controls.Add(label1);
		panel3.Location = new System.Drawing.Point(3, 23);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(435, 38);
		panel3.TabIndex = 0;
		label1.AutoSize = true;
		label1.BackColor = System.Drawing.Color.Transparent;
		label1.Font = new System.Drawing.Font("Impact", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.ForeColor = System.Drawing.Color.White;
		label1.Location = new System.Drawing.Point(132, 7);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(166, 26);
		label1.TabIndex = 0;
		label1.Text = "DATOS DE NEGOCIO";
		panel4.BackColor = System.Drawing.Color.SteelBlue;
		panel4.Controls.Add(label2);
		panel4.Location = new System.Drawing.Point(456, 23);
		panel4.Name = "panel4";
		panel4.Size = new System.Drawing.Size(349, 38);
		panel4.TabIndex = 1;
		label2.AutoSize = true;
		label2.BackColor = System.Drawing.Color.Transparent;
		label2.Font = new System.Drawing.Font("Impact", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.ForeColor = System.Drawing.Color.White;
		label2.Location = new System.Drawing.Point(97, 7);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(181, 26);
		label2.TabIndex = 1;
		label2.Text = "VISTA PREVIA TICKET";
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label10.Location = new System.Drawing.Point(0, 628);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(580, 15);
		label10.TabIndex = 18;
		label10.Text = "Configura los datos de tu negocio, ten en cuenta que la informacion que registres se vera reflejada en el Tiket";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(838, 646);
		base.Controls.Add(label10);
		base.Controls.Add(panel4);
		base.Controls.Add(panel3);
		base.Controls.Add(panel2);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "Register_2";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Register_2";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		panel2.ResumeLayout(false);
		panel5.ResumeLayout(false);
		panel5.PerformLayout();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		panel4.ResumeLayout(false);
		panel4.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}
}
