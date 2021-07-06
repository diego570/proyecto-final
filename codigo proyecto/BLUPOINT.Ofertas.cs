// BLUPOINT.Ofertas
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BarcodeLib;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Ofertas : Form
{
	private Productos prod = new Productos();

	private DataTable t;

	private string nombre;

	private DataTable dt = new DataTable();

	private IContainer components = null;

	private DataGridView dgvofer;

	private Panel panel1;

	private TextBox txtNombre;

	private Label label1;

	private Label label2;

	private TextBox txtCant;

	private Button button1;

	private Button button2;

	private TextBox txtBuscar;

	private Button button3;

	private Label label3;

	private Label label4;

	private TextBox txtCodigo;

	private PictureBox pictureBox1;

	private Panel panel2;

	private CheckBox checkBox2;

	private CheckBox checkBox1;

	private Label label5;

	private TextBox txtpre;

	private Panel pnlresults;

	private PrintDocument printDocument1;

	private Button button4;

	public Ofertas()
	{
		InitializeComponent();
		IniciarTablas();
		txtNombre.Text = "Digita el Nombre de la Oferta";
	}

	private void button3_Click(object sender, EventArgs e)
	{
		Buscar();
	}

	private void Buscar()
	{
		if (checkBox1.Checked)
		{
			try
			{
				checkBox2.Checked = false;
				prod.Codigo = txtBuscar.Text.Trim();
				dt = prod.GET();
				txtCant.Text = "0";
				txtpre.Text = dt.Rows[0]["Precio"].ToString();
				button2.Enabled = true;
				button1.Enabled = true;
				pictureBox1.Visible = false;
				enabled();
			}
			catch
			{
				MessageBox.Show("No existe el producto en el inventario");
			}
		}
		else if (checkBox2.Checked)
		{
			try
			{
				checkBox1.Checked = false;
				prod.Codigo = txtBuscar.Text;
				dt = prod.GETOFER();
				nombre = txtBuscar.Text;
				dgvofer.DataSource = dt;
				button2.Enabled = false;
				button1.Enabled = false;
				pictureBox1.Visible = true;
				Disabled();
			}
			catch
			{
				MessageBox.Show("No existe Oferta");
			}
		}
	}

	private void IniciarTablas()
	{
		t = new DataTable();
		t.Columns.Add("id");
		t.Columns.Add("Nombre");
		t.Columns.Add("Precio");
		t.Columns.Add("Cantidad");
		t.Columns.Add("IVA");
		t.Columns.Add("Imagen");
		t.Columns.Add("Codigo");
		t.Columns.Add("Codigo_Alt");
		t.Columns.Add("Proveedor");
		try
		{
			dgvofer.Columns[0].Width = 100;
			dgvofer.Columns[1].Width = 100;
			dgvofer.Columns[2].Width = 100;
			dgvofer.Columns[3].Width = 100;
			dgvofer.Columns[4].Width = 100;
			dgvofer.Columns[5].Width = 100;
			dgvofer.Columns[6].Width = 100;
			dgvofer.Columns[7].Width = 100;
			dgvofer.Columns[8].Width = 100;
		}
		catch
		{
		}
	}

	private void AgregarDatos()
	{
		try
		{
			DataRow dataRow = t.NewRow();
			dataRow["id"] = dt.Rows[0]["idProducto"].ToString();
			dataRow["Nombre"] = dt.Rows[0]["Nombre_P"].ToString();
			dataRow["Precio"] = txtpre.Text;
			dataRow["Cantidad"] = txtCant.Text;
			dataRow["IVA"] = dt.Rows[0]["Iva"].ToString();
			dataRow["Imagen"] = dt.Rows[0]["Imagen"].ToString();
			dataRow["Codigo"] = txtCodigo.Text;
			dataRow["Codigo_Alt"] = dt.Rows[0]["Codigo_Alterno"].ToString();
			dataRow["Proveedor"] = dt.Rows[0]["Proveedor"].ToString();
			t.Rows.Add(dataRow);
			dgvofer.DataSource = t;
		}
		catch
		{
			MessageBox.Show("No hay ningun producto seleccionado");
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		if (txtCodigo.Text == "")
		{
			Alert_Error alert_Error = new Alert_Error("No se Puede dejar el campo vacio");
			alert_Error.ShowDialog();
			return;
		}
		AgregarDatos();
		txtCant.Text = "";
		txtCodigo.Text = "";
		txtpre.Text = "";
		txtBuscar.Text = "";
	}

	private void txtCant_TextChanged(object sender, EventArgs e)
	{
		if (!(txtCant.Text == ""))
		{
			try
			{
				double num = Convert.ToDouble(txtCant.Text);
			}
			catch
			{
				Alert_Error alert_Error = new Alert_Error("Solo pueden ingresar numeros enteros y decimal");
				alert_Error.ShowDialog();
				txtCant.Text = "";
			}
		}
	}

	private void txtCant_Enter(object sender, EventArgs e)
	{
		txtCant.Text = "";
	}

	private void dgvofer_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F6)
		{
			int index = dgvofer.CurrentRow.Index;
			dgvofer.Rows.RemoveAt(index);
		}
	}

	private void txtNombre_Enter(object sender, EventArgs e)
	{
		txtNombre.Text = "";
	}

	private void txtNombre_Leave(object sender, EventArgs e)
	{
		if (!(txtNombre.Text != "Digita el Nombre de la Oferta"))
		{
			txtNombre.Text = "Digita el Nombre de la Oferta";
		}
	}

	private int InsertarOferta()
	{
		prod.ofer = txtNombre.Text;
		return prod.AgregarOferta();
	}

	private void InsertarProductos_Ofer()
	{
		foreach (DataGridViewRow item in (IEnumerable)dgvofer.Rows)
		{
			prod.Id = txtNombre.Text;
			prod.Nombre_P = item.Cells["Nombre"].Value.ToString();
			prod.Cantidad = item.Cells["Cantidad"].Value.ToString();
			prod.Precio_U = item.Cells["Precio"].Value.ToString();
			prod.IVA = item.Cells["IVA"].Value.ToString();
			prod.Codigo = item.Cells["Codigo"].Value.ToString();
			prod.Cod_Alt = item.Cells["Codigo_Alt"].Value.ToString();
			prod.Imagen = item.Cells["Imagen"].Value.ToString();
			prod.proveedor = item.Cells["Proveedor"].Value.ToString();
			prod.AgregarDatosOfer();
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		if (dgvofer.DataSource == null)
		{
			Alert_Error alert_Error = new Alert_Error("Datos no Agregados, ErrCod: 091");
			alert_Error.ShowDialog();
		}
		else if (InsertarOferta() == 1)
		{
			InsertarProductos_Ofer();
			ImprimirTicket();
			MessageBox.Show("Oferta Agregada con exito");
			txtNombre.Text = "";
			DataTable dataTable = (DataTable)dgvofer.DataSource;
			dataTable.Clear();
		}
		else
		{
			Alert_Error alert_Error2 = new Alert_Error("No se ha podido Registrar");
			alert_Error2.ShowDialog();
		}
	}

	private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			Buscar();
		}
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox1.Checked)
		{
			checkBox2.Checked = false;
		}
	}

	private void checkBox2_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox2.Checked)
		{
			checkBox1.Checked = false;
		}
	}

	private void Disabled()
	{
		txtCant.Enabled = false;
		txtNombre.Enabled = false;
		txtCodigo.Enabled = false;
		txtCant.Text = "";
		txtCodigo.Text = "";
		txtNombre.Text = "";
	}

	private void enabled()
	{
		txtCant.Enabled = true;
		txtNombre.Enabled = true;
		txtCodigo.Enabled = true;
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		prod.ofer = nombre;
		if (prod.BorrarOferta() == 0)
		{
			DataTable dataTable = (DataTable)dgvofer.DataSource;
			MessageBox.Show("Oferta Elminada con exito");
			dataTable.Clear();
		}
		else
		{
			Alert_Error alert_Error = new Alert_Error("No se ha podido Registrar");
			alert_Error.ShowDialog();
		}
	}

	private void Ofertas_Load(object sender, EventArgs e)
	{
	}

	private void ImprimirTicket()
	{
		try
		{
			Barcode barcode = new Barcode();
			barcode.IncludeLabel = true;
			pnlresults.BackgroundImage = barcode.Encode(TYPE.CODE128, txtNombre.Text, Color.Black, Color.White, 200, 100);
			Print();
		}
		catch
		{
			Alert_Error alert_Error = new Alert_Error("Ha ocurrido un Problema, ErrCod: 207");
			alert_Error.ShowDialog();
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
		Image backgroundImage = pnlresults.BackgroundImage;
		e.Graphics.DrawImage(backgroundImage, new Rectangle(0, num += 20, 200, 80));
	}

	private void button4_Click(object sender, EventArgs e)
	{
		Close();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Ofertas));
		dgvofer = new System.Windows.Forms.DataGridView();
		panel1 = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label3 = new System.Windows.Forms.Label();
		txtNombre = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		txtCant = new System.Windows.Forms.TextBox();
		button1 = new System.Windows.Forms.Button();
		button2 = new System.Windows.Forms.Button();
		txtBuscar = new System.Windows.Forms.TextBox();
		button3 = new System.Windows.Forms.Button();
		label4 = new System.Windows.Forms.Label();
		txtCodigo = new System.Windows.Forms.TextBox();
		panel2 = new System.Windows.Forms.Panel();
		checkBox2 = new System.Windows.Forms.CheckBox();
		checkBox1 = new System.Windows.Forms.CheckBox();
		label5 = new System.Windows.Forms.Label();
		txtpre = new System.Windows.Forms.TextBox();
		pnlresults = new System.Windows.Forms.Panel();
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		button4 = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)dgvofer).BeginInit();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel2.SuspendLayout();
		SuspendLayout();
		dgvofer.AllowUserToAddRows = false;
		dgvofer.AllowUserToDeleteRows = false;
		dgvofer.AllowUserToResizeColumns = false;
		dgvofer.AllowUserToResizeRows = false;
		dgvofer.BackgroundColor = System.Drawing.Color.White;
		dgvofer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgvofer.Location = new System.Drawing.Point(12, 156);
		dgvofer.Name = "dgvofer";
		dgvofer.Size = new System.Drawing.Size(480, 332);
		dgvofer.TabIndex = 1;
		dgvofer.KeyUp += new System.Windows.Forms.KeyEventHandler(dgvofer_KeyUp);
		panel1.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		panel1.Controls.Add(button4);
		panel1.Controls.Add(label3);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(870, 50);
		panel1.TabIndex = 2;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox1.Image = BLUPOINT.Properties.Resources.borrar;
		pictureBox1.Location = new System.Drawing.Point(413, 504);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(79, 86);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 1;
		pictureBox1.TabStop = false;
		pictureBox1.Visible = false;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.ForeColor = System.Drawing.Color.White;
		label3.Location = new System.Drawing.Point(361, 9);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(152, 30);
		label3.TabIndex = 0;
		label3.Text = "Agregar Oferta";
		txtNombre.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtNombre.Location = new System.Drawing.Point(531, 180);
		txtNombre.Name = "txtNombre";
		txtNombre.Size = new System.Drawing.Size(286, 35);
		txtNombre.TabIndex = 3;
		txtNombre.Enter += new System.EventHandler(txtNombre_Enter);
		txtNombre.Leave += new System.EventHandler(txtNombre_Leave);
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(526, 147);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(183, 30);
		label1.TabIndex = 4;
		label1.Text = "Nombre de Oferta";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(526, 233);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(96, 30);
		label2.TabIndex = 6;
		label2.Text = "Cantidad";
		txtCant.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtCant.Location = new System.Drawing.Point(530, 269);
		txtCant.Name = "txtCant";
		txtCant.Size = new System.Drawing.Size(286, 35);
		txtCant.TabIndex = 5;
		txtCant.TextChanged += new System.EventHandler(txtCant_TextChanged);
		txtCant.Enter += new System.EventHandler(txtCant_Enter);
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(556, 504);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(261, 50);
		button1.TabIndex = 7;
		button1.Text = "Agregar Producto";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		button2.BackColor = System.Drawing.Color.SteelBlue;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Location = new System.Drawing.Point(556, 573);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(261, 50);
		button2.TabIndex = 8;
		button2.Text = "Guardar Oferta";
		button2.UseVisualStyleBackColor = false;
		button2.Click += new System.EventHandler(button2_Click);
		txtBuscar.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtBuscar.Location = new System.Drawing.Point(12, 85);
		txtBuscar.Name = "txtBuscar";
		txtBuscar.Size = new System.Drawing.Size(322, 35);
		txtBuscar.TabIndex = 9;
		txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBuscar_KeyPress);
		button3.BackColor = System.Drawing.Color.SteelBlue;
		button3.Cursor = System.Windows.Forms.Cursors.Hand;
		button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button3.ForeColor = System.Drawing.Color.White;
		button3.Location = new System.Drawing.Point(340, 85);
		button3.Name = "button3";
		button3.Size = new System.Drawing.Size(152, 35);
		button3.TabIndex = 10;
		button3.Text = "Buscar";
		button3.UseVisualStyleBackColor = false;
		button3.Click += new System.EventHandler(button3_Click);
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(525, 325);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(149, 30);
		label4.TabIndex = 12;
		label4.Text = "Nuevo_Codigo";
		txtCodigo.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtCodigo.Location = new System.Drawing.Point(530, 358);
		txtCodigo.Name = "txtCodigo";
		txtCodigo.Size = new System.Drawing.Size(286, 35);
		txtCodigo.TabIndex = 11;
		panel2.BackColor = System.Drawing.Color.White;
		panel2.Controls.Add(checkBox2);
		panel2.Controls.Add(checkBox1);
		panel2.Location = new System.Drawing.Point(531, 69);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(285, 69);
		panel2.TabIndex = 13;
		checkBox2.AutoSize = true;
		checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		checkBox2.Location = new System.Drawing.Point(10, 37);
		checkBox2.Name = "checkBox2";
		checkBox2.Size = new System.Drawing.Size(142, 28);
		checkBox2.TabIndex = 1;
		checkBox2.Text = "Buscar Oferta";
		checkBox2.UseVisualStyleBackColor = true;
		checkBox2.CheckedChanged += new System.EventHandler(checkBox2_CheckedChanged);
		checkBox1.AutoSize = true;
		checkBox1.Checked = true;
		checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
		checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		checkBox1.Location = new System.Drawing.Point(11, 3);
		checkBox1.Name = "checkBox1";
		checkBox1.Size = new System.Drawing.Size(168, 28);
		checkBox1.TabIndex = 0;
		checkBox1.Text = "Buscar Producto";
		checkBox1.UseVisualStyleBackColor = true;
		checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.Location = new System.Drawing.Point(526, 408);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(70, 30);
		label5.TabIndex = 15;
		label5.Text = "Precio";
		txtpre.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtpre.Location = new System.Drawing.Point(531, 441);
		txtpre.Name = "txtpre";
		txtpre.Size = new System.Drawing.Size(286, 35);
		txtpre.TabIndex = 14;
		pnlresults.Location = new System.Drawing.Point(946, 350);
		pnlresults.Name = "pnlresults";
		pnlresults.Size = new System.Drawing.Size(200, 100);
		pnlresults.TabIndex = 16;
		button4.BackColor = System.Drawing.Color.White;
		button4.Cursor = System.Windows.Forms.Cursors.Hand;
		button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
		button4.Location = new System.Drawing.Point(786, 3);
		button4.Name = "button4";
		button4.Size = new System.Drawing.Size(81, 36);
		button4.TabIndex = 1;
		button4.Text = "X";
		button4.UseVisualStyleBackColor = false;
		button4.Click += new System.EventHandler(button4_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
		base.ClientSize = new System.Drawing.Size(870, 650);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(pnlresults);
		base.Controls.Add(label5);
		base.Controls.Add(txtpre);
		base.Controls.Add(panel2);
		base.Controls.Add(label4);
		base.Controls.Add(txtCodigo);
		base.Controls.Add(button3);
		base.Controls.Add(txtBuscar);
		base.Controls.Add(button2);
		base.Controls.Add(button1);
		base.Controls.Add(label2);
		base.Controls.Add(txtCant);
		base.Controls.Add(label1);
		base.Controls.Add(txtNombre);
		base.Controls.Add(panel1);
		base.Controls.Add(dgvofer);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Ofertas";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Agregar Oferta";
		base.Load += new System.EventHandler(Ofertas_Load);
		((System.ComponentModel.ISupportInitialize)dgvofer).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}
}
