// BLUPOINT.Creditos
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BLUPOINT.Source;

public class Creditos : Form
{
	private Credito cr = new Credito();

	private Clientes cl = new Clientes();

	private Caja cj = new Caja();

	private string nombre_e;

	private string tipo_e;

	private string ids;

	private IContainer components = null;

	private TextBox txtcode;

	private Label label1;

	private DataGridView dGVcL;

	private Panel panel1;

	private Button btnabo;

	private Label label5;

	private Label Apellido;

	private Label label4;

	private Label txtname;

	private Label label3;

	private TextBox txtpago;

	private Label label2;

	private Label txtadeudo;

	private Label label7;

	private Label label6;

	private Panel panel2;

	private Label label9;

	private CheckBox ch2;

	private CheckBox ch1;

	private DateTimePicker dtm1;

	private Label id;

	private PrintDocument printDocument1;

	public Creditos(string nombre, string tipo, string id)
	{
		InitializeComponent();
		Iniciar();
		nombre_e = nombre;
		tipo_e = tipo;
		ids = id;
	}

	private void Iniciar()
	{
		btnabo.Enabled = false;
		txtpago.Enabled = false;
		ch1.Enabled = false;
		ch2.Enabled = false;
		ch1.Checked = true;
	}

	private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			if (ch1.Checked)
			{
				cr.Nombre_U = txtcode.Text;
				dGVcL.DataSource = cr.GetUser(ch1.Text);
				ch2.Enabled = true;
				ch1.Enabled = true;
			}
			else if (ch2.Checked)
			{
				cr.Nombre_U = txtcode.Text;
				dGVcL.DataSource = cr.GetUser(ch2.Text);
			}
		}
	}

	private void GetUser()
	{
		try
		{
			cl.Nombre = dGVcL.CurrentRow.Cells["Nombre_U"].Value.ToString();
			DataTable bYID = cl.GETBYID();
			txtname.Text = bYID.Rows[0]["Nombre"].ToString();
			Apellido.Text = bYID.Rows[0]["Apellidos"].ToString();
			txtadeudo.Text = dGVcL.CurrentRow.Cells["Total_Pago"].Value.ToString();
			id.Text = dGVcL.CurrentRow.Cells["idCredito"].Value.ToString();
		}
		catch
		{
			MessageBox.Show("Ha ocurrido un error, Por favor contacta a soporte tecnico");
		}
	}

	private void dGVcL_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		GetUser();
		txtpago.Enabled = true;
		btnabo.Enabled = true;
	}

	private void ch1_CheckedChanged(object sender, EventArgs e)
	{
		ch2.Checked = false;
	}

	private void ch2_CheckedChanged(object sender, EventArgs e)
	{
		ch1.Checked = false;
	}

	private void txtpago_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			double num = Convert.ToDouble(txtadeudo.Text);
			double num2 = Convert.ToDouble(txtpago.Text);
			double num3 = num - num2;
			if (num3 < 0.0)
			{
				MessageBox.Show("No puedes ingresar mas dinero del adeudado");
				return;
			}
			cr.id_Cred = id.Text;
			cr.abono = txtpago.Text;
			cr.fecha_P = dtm1.Value.Day + "/" + dtm1.Value.Month + "/" + dtm1.Value.Year;
			cr.Abono();
			InsertarCaja();
			Updates();
			Print();
			MessageBox.Show("Dinero Abonado");
			Limpiar();
		}
	}

	private void Updates()
	{
		cr.id_Cred = id.Text;
		double num = Convert.ToDouble(txtadeudo.Text) - Convert.ToDouble(txtpago.Text);
		cr.Total_P = num.ToString();
		if (num == 0.0)
		{
			Deletes();
		}
		else
		{
			cr.Actualizar();
		}
	}

	public void Deletes()
	{
		cr.id_Cred = id.Text;
		cr.Eliminar();
	}

	private void Limpiar()
	{
		txtadeudo.Text = "0.0";
		txtname.Text = "";
		txtpago.Text = "";
		Apellido.Text = "";
		ch1.Checked = true;
		Iniciar();
		dGVcL.DataSource = null;
	}

	private void btnabo_Click(object sender, EventArgs e)
	{
		double num = Convert.ToDouble(txtpago.Text);
		if (num < 0.0)
		{
			MessageBox.Show("No puedes ingresar menos dinero del adeudado");
			return;
		}
		double num2 = Convert.ToDouble(txtadeudo.Text);
		double num3 = Convert.ToDouble(txtpago.Text);
		double num4 = num2 - num3;
		if (num4 < 0.0)
		{
			MessageBox.Show("No puedes ingresar mas dinero del adeudado");
			return;
		}
		cr.id_Cred = id.Text;
		cr.abono = txtpago.Text;
		cr.fecha_P = dtm1.Value.Day + "/" + dtm1.Value.Month + "/" + dtm1.Value.Year;
		cr.Abono();
		InsertarCaja();
		Updates();
		Print();
		Openbox();
		MessageBox.Show("Dinero Abonado");
		Limpiar();
	}

	private void InsertarCaja()
	{
		try
		{
			cj.Cantidad = txtpago.Text;
			cj.Fecha = dtm1.Value.Day + "/" + dtm1.Value.Month + "/" + dtm1.Value.Year;
			cj.id_caja = ids;
			cj.Tipo_Pago = "Efectivo";
			cj.concepto = "Abono Crediticio";
			cj.INSERTBOX(nombre_e, tipo_e);
		}
		catch
		{
		}
	}

	private void Openbox()
	{
		cj.id_caja = ids;
		cj.Nombre_U = nombre_e;
		cj.Hora = dtm1.Value.Hour + ":" + dtm1.Value.Minute + ":" + dtm1.Value.Second;
		cj.Fecha = dtm1.Value.Day + "/" + dtm1.Value.Month + "/" + dtm1.Value.Year;
		cj.Tipo_E = tipo_e;
		cj.tipo_consumo = "Entrada Abono";
		cj.OpenBox();
	}

	private void btnimp_Click(object sender, EventArgs e)
	{
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
		double num = Convert.ToDouble(txtadeudo.Text);
		double num2 = Convert.ToDouble(txtpago.Text);
		double num3 = num - num2;
		Negocio negocio = new Negocio();
		DataTable dataTable = new DataTable();
		dataTable = negocio.GetNegocio();
		string s = "Calle: " + dataTable.Rows[0]["Calle"].ToString() + ", #" + dataTable.Rows[0]["Numero_Ext"].ToString() + ", Col. " + dataTable.Rows[0]["Colonia"].ToString() + "\n" + dataTable.Rows[0]["Municipio"].ToString() + ", " + dataTable.Rows[0]["Estado"].ToString() + ", C.P: " + dataTable.Rows[0]["CP"].ToString();
		Font font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Point);
		Font font2 = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Point);
		Font font3 = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point);
		Font font4 = new Font("Segoe UI", 5f, FontStyle.Regular, GraphicsUnit.Point);
		Font font5 = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point);
		int num4 = 220;
		int num5 = 20;
		e.Graphics.DrawString(" ***" + dataTable.Rows[0]["Nombre_N"].ToString() + "*** ", font, Brushes.Black, new RectangleF(0f, num5 += 10, num4, 20f));
		e.Graphics.DrawString(s, font3, Brushes.Black, new RectangleF(8f, num5 += 20, num4, num5 + 20));
		e.Graphics.DrawString("Tel: " + dataTable.Rows[0]["Telefono"].ToString(), font3, Brushes.Black, new RectangleF(8f, num5 += 25, num4, num5 + 15));
		e.Graphics.DrawString("Abono", font3, Brushes.Black, new RectangleF(8f, num5 += 20, num4, num5 + 20));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("    Datos de Cliente   ", font3, Brushes.Black, new RectangleF(8f, num5 += 25, num4, num5 + 20));
		e.Graphics.DrawString("Nombre: " + txtname.Text + " " + Apellido.Text, font3, Brushes.Black, new RectangleF(8f, num5 += 25, num4, num5 + 20));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("Total Adeudo:\t\t$" + txtadeudo.Text, font, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("Abonado: \t\t$" + txtpago.Text, font5, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("Total Actual Adeudo:\t$" + num3, font5, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("Abonado por:  " + txtname.Text, font3, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("Fecha de Abono: " + dtm1.Value.Day + "/" + dtm1.Value.Month + "/" + dtm1.Value.Year + " " + dtm1.Value.Hour + ":" + dtm1.Value.Minute + ":" + dtm1.Value.Second, font3, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
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
		txtcode = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		dGVcL = new System.Windows.Forms.DataGridView();
		panel1 = new System.Windows.Forms.Panel();
		id = new System.Windows.Forms.Label();
		txtadeudo = new System.Windows.Forms.Label();
		label7 = new System.Windows.Forms.Label();
		label6 = new System.Windows.Forms.Label();
		btnabo = new System.Windows.Forms.Button();
		label5 = new System.Windows.Forms.Label();
		Apellido = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		txtname = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		txtpago = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		panel2 = new System.Windows.Forms.Panel();
		label9 = new System.Windows.Forms.Label();
		ch2 = new System.Windows.Forms.CheckBox();
		ch1 = new System.Windows.Forms.CheckBox();
		dtm1 = new System.Windows.Forms.DateTimePicker();
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		((System.ComponentModel.ISupportInitialize)dGVcL).BeginInit();
		panel1.SuspendLayout();
		panel2.SuspendLayout();
		SuspendLayout();
		txtcode.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtcode.Location = new System.Drawing.Point(12, 48);
		txtcode.Name = "txtcode";
		txtcode.Size = new System.Drawing.Size(342, 35);
		txtcode.TabIndex = 0;
		txtcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtNombres_KeyPress);
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(12, 15);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(174, 30);
		label1.TabIndex = 1;
		label1.Text = "Digita el nombre ";
		dGVcL.BackgroundColor = System.Drawing.Color.White;
		dGVcL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dGVcL.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
		dGVcL.Location = new System.Drawing.Point(12, 89);
		dGVcL.Name = "dGVcL";
		dGVcL.Size = new System.Drawing.Size(342, 167);
		dGVcL.TabIndex = 2;
		dGVcL.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dGVcL_CellClick);
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(id);
		panel1.Controls.Add(txtadeudo);
		panel1.Controls.Add(label7);
		panel1.Controls.Add(label6);
		panel1.Controls.Add(btnabo);
		panel1.Controls.Add(label5);
		panel1.Controls.Add(Apellido);
		panel1.Controls.Add(label4);
		panel1.Controls.Add(txtname);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(txtpago);
		panel1.Controls.Add(label2);
		panel1.Location = new System.Drawing.Point(387, 48);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(415, 401);
		panel1.TabIndex = 3;
		id.AutoSize = true;
		id.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		id.Location = new System.Drawing.Point(271, 4);
		id.Name = "id";
		id.Size = new System.Drawing.Size(0, 30);
		id.TabIndex = 13;
		id.Visible = false;
		txtadeudo.AutoSize = true;
		txtadeudo.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtadeudo.Location = new System.Drawing.Point(167, 177);
		txtadeudo.Name = "txtadeudo";
		txtadeudo.Size = new System.Drawing.Size(40, 30);
		txtadeudo.TabIndex = 12;
		txtadeudo.Text = "0.0";
		label7.AutoSize = true;
		label7.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(137, 177);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(24, 30);
		label7.TabIndex = 11;
		label7.Text = "$";
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
		label6.Location = new System.Drawing.Point(149, 147);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(86, 30);
		label6.TabIndex = 10;
		label6.Text = "Adeudo";
		btnabo.BackColor = System.Drawing.Color.SteelBlue;
		btnabo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnabo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnabo.ForeColor = System.Drawing.Color.White;
		btnabo.Location = new System.Drawing.Point(124, 346);
		btnabo.Name = "btnabo";
		btnabo.Size = new System.Drawing.Size(188, 50);
		btnabo.TabIndex = 9;
		btnabo.Text = "ABONAR";
		btnabo.UseVisualStyleBackColor = false;
		btnabo.Click += new System.EventHandler(btnabo_Click);
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.Location = new System.Drawing.Point(101, 269);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(193, 30);
		label5.TabIndex = 8;
		label5.Text = "Cantidad de Abono";
		Apellido.AutoSize = true;
		Apellido.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Apellido.Location = new System.Drawing.Point(228, 84);
		Apellido.Name = "Apellido";
		Apellido.Size = new System.Drawing.Size(0, 30);
		Apellido.TabIndex = 7;
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
		label4.Location = new System.Drawing.Point(228, 51);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(98, 30);
		label4.TabIndex = 6;
		label4.Text = "Apellidos";
		txtname.AutoSize = true;
		txtname.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtname.Location = new System.Drawing.Point(14, 84);
		txtname.Name = "txtname";
		txtname.Size = new System.Drawing.Size(0, 30);
		txtname.TabIndex = 5;
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
		label3.Location = new System.Drawing.Point(11, 51);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(89, 30);
		label3.TabIndex = 4;
		label3.Text = "Nombre";
		txtpago.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtpago.Location = new System.Drawing.Point(16, 302);
		txtpago.Name = "txtpago";
		txtpago.Size = new System.Drawing.Size(372, 35);
		txtpago.TabIndex = 4;
		txtpago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtpago_KeyPress);
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(101, 4);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(164, 30);
		label2.TabIndex = 4;
		label2.Text = "Datos de Abono";
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Controls.Add(label9);
		panel2.Controls.Add(ch2);
		panel2.Controls.Add(ch1);
		panel2.Location = new System.Drawing.Point(17, 275);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(337, 90);
		panel2.TabIndex = 4;
		label9.AutoSize = true;
		label9.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
		label9.Location = new System.Drawing.Point(104, 0);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(110, 30);
		label9.TabIndex = 13;
		label9.Text = "Buscar Por";
		ch2.AutoSize = true;
		ch2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ch2.Location = new System.Drawing.Point(194, 42);
		ch2.Name = "ch2";
		ch2.Size = new System.Drawing.Size(104, 29);
		ch2.TabIndex = 1;
		ch2.Text = "Abonos";
		ch2.UseVisualStyleBackColor = true;
		ch2.CheckedChanged += new System.EventHandler(ch2_CheckedChanged);
		ch1.AutoSize = true;
		ch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ch1.Location = new System.Drawing.Point(22, 42);
		ch1.Name = "ch1";
		ch1.Size = new System.Drawing.Size(116, 29);
		ch1.TabIndex = 0;
		ch1.Text = "Adeudos";
		ch1.UseVisualStyleBackColor = true;
		ch1.CheckedChanged += new System.EventHandler(ch1_CheckedChanged);
		dtm1.Location = new System.Drawing.Point(471, 27);
		dtm1.Name = "dtm1";
		dtm1.Size = new System.Drawing.Size(200, 20);
		dtm1.TabIndex = 14;
		dtm1.Visible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(820, 450);
		base.Controls.Add(dtm1);
		base.Controls.Add(panel2);
		base.Controls.Add(panel1);
		base.Controls.Add(dGVcL);
		base.Controls.Add(label1);
		base.Controls.Add(txtcode);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Creditos";
		Text = "Creditos";
		((System.ComponentModel.ISupportInitialize)dGVcL).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}
}
