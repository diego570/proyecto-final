// BLUPOINT.Ver_corte_caja
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BLUPOINT.Source;

public class Ver_corte_caja : Form
{
	private IContainer components = null;

	private Label label1;

	private Panel panel1;

	private Label label2;

	private Label txtnombre;

	private Panel panel2;

	private Label label4;

	private Label label5;

	private Label label6;

	private Label txttotal;

	private Label txtingreso;

	private Label label9;

	private Label label10;

	private Label txtdiferencia;

	private Label label12;

	private Label label13;

	private Label txtret;

	private Label label15;

	private Label label16;

	private Panel panel3;

	private Label txtfecha;

	private Label label17;

	private Button button1;

	private Button button2;

	private PrintDocument printDocument1;

	private DateTimePicker dtm1;

	public Ver_corte_caja(string nombre, string calculado, string diferecnia, string entrada, string retirado, string fecha)
	{
		InitializeComponent();
		txtnombre.Text = nombre;
		txttotal.Text = calculado;
		txtdiferencia.Text = diferecnia;
		txtingreso.Text = entrada;
		txtret.Text = retirado;
		txtfecha.Text = fecha;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void button2_Click(object sender, EventArgs e)
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
		Font font2 = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Point);
		Font font3 = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point);
		Font font4 = new Font("Segoe UI", 5f, FontStyle.Regular, GraphicsUnit.Point);
		Font font5 = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point);
		int num = 220;
		int num2 = 20;
		e.Graphics.DrawString(" ***" + dataTable.Rows[0]["Nombre_N"].ToString() + "*** ", font, Brushes.Black, new RectangleF(0f, num2 += 10, num, 20f));
		e.Graphics.DrawString(s, font3, Brushes.Black, new RectangleF(8f, num2 += 20, num, num2 + 20));
		e.Graphics.DrawString("Tel: " + dataTable.Rows[0]["Telefono"].ToString(), font3, Brushes.Black, new RectangleF(8f, num2 += 25, num, num2 + 15));
		e.Graphics.DrawString("Rep. Corte Caja", font3, Brushes.Black, new RectangleF(8f, num2 += 20, num, num2 + 20));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("    Datos de Empleado  ", font3, Brushes.Black, new RectangleF(8f, num2 += 15, num, num2 + 20));
		e.Graphics.DrawString("Nombre: " + txtnombre.Text, font3, Brushes.Black, new RectangleF(8f, num2 += 15, num, num2 + 20));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("Total Calculado:\t$" + txttotal.Text, font5, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("Cant. Ingresada:\t$" + txtingreso.Text, font5, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("Diferencia:\t$" + txtdiferencia.Text, font5, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("Retirado:\t$" + txtret.Text, font5, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("Fecha de Solicitud: " + dtm1.Value.Day + "/" + dtm1.Value.Month + "/" + dtm1.Value.Year + " " + dtm1.Value.Hour + ":" + dtm1.Value.Minute + ":" + dtm1.Value.Second, font3, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
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
		panel1 = new System.Windows.Forms.Panel();
		label2 = new System.Windows.Forms.Label();
		txtnombre = new System.Windows.Forms.Label();
		panel2 = new System.Windows.Forms.Panel();
		label4 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		label6 = new System.Windows.Forms.Label();
		txttotal = new System.Windows.Forms.Label();
		txtingreso = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		label10 = new System.Windows.Forms.Label();
		txtdiferencia = new System.Windows.Forms.Label();
		label12 = new System.Windows.Forms.Label();
		label13 = new System.Windows.Forms.Label();
		txtret = new System.Windows.Forms.Label();
		label15 = new System.Windows.Forms.Label();
		label16 = new System.Windows.Forms.Label();
		panel3 = new System.Windows.Forms.Panel();
		label17 = new System.Windows.Forms.Label();
		txtfecha = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		button2 = new System.Windows.Forms.Button();
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		dtm1 = new System.Windows.Forms.DateTimePicker();
		panel1.SuspendLayout();
		panel2.SuspendLayout();
		panel3.SuspendLayout();
		SuspendLayout();
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 16f);
		label1.ForeColor = System.Drawing.Color.Gray;
		label1.Location = new System.Drawing.Point(11, 61);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(94, 30);
		label1.TabIndex = 0;
		label1.Text = "Nombre";
		panel1.BackColor = System.Drawing.Color.SteelBlue;
		panel1.Controls.Add(label2);
		panel1.Location = new System.Drawing.Point(0, -1);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(775, 50);
		panel1.TabIndex = 1;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 16f);
		label2.ForeColor = System.Drawing.Color.White;
		label2.Location = new System.Drawing.Point(11, 11);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(239, 30);
		label2.TabIndex = 2;
		label2.Text = "Informacion de Usuario";
		txtnombre.AutoSize = true;
		txtnombre.Font = new System.Drawing.Font("Segoe UI", 16f);
		txtnombre.ForeColor = System.Drawing.Color.Black;
		txtnombre.Location = new System.Drawing.Point(123, 61);
		txtnombre.Name = "txtnombre";
		txtnombre.Size = new System.Drawing.Size(274, 30);
		txtnombre.TabIndex = 2;
		txtnombre.Text = "Alan Jesus Guzman Aguirre";
		panel2.BackColor = System.Drawing.Color.SteelBlue;
		panel2.Controls.Add(label4);
		panel2.Location = new System.Drawing.Point(0, 107);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(775, 50);
		panel2.TabIndex = 3;
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 16f);
		label4.ForeColor = System.Drawing.Color.White;
		label4.Location = new System.Drawing.Point(11, 11);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(223, 30);
		label4.TabIndex = 2;
		label4.Text = "Informacion de Retiro";
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 16f);
		label5.ForeColor = System.Drawing.Color.Black;
		label5.Location = new System.Drawing.Point(216, 183);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(25, 30);
		label5.TabIndex = 5;
		label5.Text = "$";
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Segoe UI", 16f);
		label6.ForeColor = System.Drawing.Color.Gray;
		label6.Location = new System.Drawing.Point(13, 185);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(197, 30);
		label6.TabIndex = 4;
		label6.Text = "Cantidad Calculada";
		txttotal.AutoSize = true;
		txttotal.Font = new System.Drawing.Font("Segoe UI", 16f);
		txttotal.ForeColor = System.Drawing.Color.Black;
		txttotal.Location = new System.Drawing.Point(236, 184);
		txttotal.Name = "txttotal";
		txttotal.Size = new System.Drawing.Size(42, 30);
		txttotal.TabIndex = 6;
		txttotal.Text = "0.0";
		txtingreso.AutoSize = true;
		txtingreso.Font = new System.Drawing.Font("Segoe UI", 16f);
		txtingreso.ForeColor = System.Drawing.Color.Black;
		txtingreso.Location = new System.Drawing.Point(236, 240);
		txtingreso.Name = "txtingreso";
		txtingreso.Size = new System.Drawing.Size(42, 30);
		txtingreso.TabIndex = 9;
		txtingreso.Text = "0.0";
		label9.AutoSize = true;
		label9.Font = new System.Drawing.Font("Segoe UI", 16f);
		label9.ForeColor = System.Drawing.Color.Black;
		label9.Location = new System.Drawing.Point(216, 239);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(25, 30);
		label9.TabIndex = 8;
		label9.Text = "$";
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Segoe UI", 16f);
		label10.ForeColor = System.Drawing.Color.Gray;
		label10.Location = new System.Drawing.Point(13, 241);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(200, 30);
		label10.TabIndex = 7;
		label10.Text = "Cantidad Ingresada";
		txtdiferencia.AutoSize = true;
		txtdiferencia.Font = new System.Drawing.Font("Segoe UI", 16f);
		txtdiferencia.ForeColor = System.Drawing.Color.Black;
		txtdiferencia.Location = new System.Drawing.Point(233, 290);
		txtdiferencia.Name = "txtdiferencia";
		txtdiferencia.Size = new System.Drawing.Size(42, 30);
		txtdiferencia.TabIndex = 12;
		txtdiferencia.Text = "0.0";
		label12.AutoSize = true;
		label12.Font = new System.Drawing.Font("Segoe UI", 16f);
		label12.ForeColor = System.Drawing.Color.Black;
		label12.Location = new System.Drawing.Point(213, 289);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(25, 30);
		label12.TabIndex = 11;
		label12.Text = "$";
		label13.AutoSize = true;
		label13.Font = new System.Drawing.Font("Segoe UI", 16f);
		label13.ForeColor = System.Drawing.Color.Gray;
		label13.Location = new System.Drawing.Point(100, 290);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(110, 30);
		label13.TabIndex = 10;
		label13.Text = "Diferencia";
		txtret.AutoSize = true;
		txtret.Font = new System.Drawing.Font("Segoe UI", 16f);
		txtret.ForeColor = System.Drawing.Color.Black;
		txtret.Location = new System.Drawing.Point(233, 334);
		txtret.Name = "txtret";
		txtret.Size = new System.Drawing.Size(42, 30);
		txtret.TabIndex = 15;
		txtret.Text = "0.0";
		label15.AutoSize = true;
		label15.Font = new System.Drawing.Font("Segoe UI", 16f);
		label15.ForeColor = System.Drawing.Color.Black;
		label15.Location = new System.Drawing.Point(213, 333);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(25, 30);
		label15.TabIndex = 14;
		label15.Text = "$";
		label16.AutoSize = true;
		label16.Font = new System.Drawing.Font("Segoe UI", 16f);
		label16.ForeColor = System.Drawing.Color.Gray;
		label16.Location = new System.Drawing.Point(113, 334);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(94, 30);
		label16.TabIndex = 13;
		label16.Text = "Retirado";
		panel3.BackColor = System.Drawing.Color.SteelBlue;
		panel3.Controls.Add(txtfecha);
		panel3.Controls.Add(label17);
		panel3.Location = new System.Drawing.Point(0, 367);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(775, 50);
		panel3.TabIndex = 4;
		label17.AutoSize = true;
		label17.Font = new System.Drawing.Font("Segoe UI", 16f);
		label17.ForeColor = System.Drawing.Color.White;
		label17.Location = new System.Drawing.Point(11, 11);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(160, 30);
		label17.TabIndex = 2;
		label17.Text = "Fecha de Corte";
		txtfecha.AutoSize = true;
		txtfecha.Font = new System.Drawing.Font("Segoe UI", 16f);
		txtfecha.ForeColor = System.Drawing.Color.White;
		txtfecha.Location = new System.Drawing.Point(588, 11);
		txtfecha.Name = "txtfecha";
		txtfecha.Size = new System.Drawing.Size(127, 30);
		txtfecha.TabIndex = 3;
		txtfecha.Text = "12/21/2021";
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(180, 441);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(178, 46);
		button1.TabIndex = 16;
		button1.Text = "Aceptar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		button2.BackColor = System.Drawing.Color.SteelBlue;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Location = new System.Drawing.Point(460, 441);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(178, 46);
		button2.TabIndex = 17;
		button2.Text = "Imprimir";
		button2.UseVisualStyleBackColor = false;
		button2.Click += new System.EventHandler(button2_Click);
		dtm1.Location = new System.Drawing.Point(689, 441);
		dtm1.Name = "dtm1";
		dtm1.Size = new System.Drawing.Size(61, 20);
		dtm1.TabIndex = 18;
		dtm1.Visible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(776, 488);
		base.Controls.Add(dtm1);
		base.Controls.Add(button2);
		base.Controls.Add(button1);
		base.Controls.Add(panel3);
		base.Controls.Add(txtret);
		base.Controls.Add(label15);
		base.Controls.Add(label16);
		base.Controls.Add(txtdiferencia);
		base.Controls.Add(label12);
		base.Controls.Add(label13);
		base.Controls.Add(txtingreso);
		base.Controls.Add(label9);
		base.Controls.Add(label10);
		base.Controls.Add(txttotal);
		base.Controls.Add(label5);
		base.Controls.Add(label6);
		base.Controls.Add(panel2);
		base.Controls.Add(txtnombre);
		base.Controls.Add(panel1);
		base.Controls.Add(label1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Ver_corte_caja";
		Text = "Detalle Corte de Caja";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}
}
