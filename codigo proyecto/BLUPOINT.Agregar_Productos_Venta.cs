// BLUPOINT.Agregar_Productos_Venta
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Agregar_Productos_Venta : Form
{
	private Productos prod = new Productos();

	private Proveedores prov = new Proveedores();

	private bool editar;

	private bool validacion;

	private IContainer components = null;

	private Panel panel3;

	private Label iD;

	private Panel panel7;

	private Label txtruta;

	private Panel panel13;

	private Label label13;

	private Panel panel12;

	private Label label12;

	private Panel panel11;

	private Panel panel15;

	private TextBox txtprecio_mayoreo;

	private TextBox txtdesc;

	private Label label16;

	private Label label15;

	private DateTimePicker txtfecha_cad;

	private Label label14;

	private Panel panel14;

	private CheckBox ch3;

	private CheckBox ch2;

	private CheckBox ch1;

	private Panel panel10;

	private Label label7;

	private Panel panel9;

	private Button btnimage;

	private PictureBox pictureBox1;

	private Panel panel8;

	private NumericUpDown Min;

	private Label label23;

	private NumericUpDown Max;

	private Label label22;

	private DateTimePicker txtFecha;

	private ComboBox txtprov;

	private Label label11;

	private Label label10;

	private Label label9;

	private TextBox txtIVA;

	private Label label8;

	private TextBox txtPrecio;

	private Label label6;

	private TextBox txtCantidad;

	private Label label5;

	private TextBox txtNombre;

	private Label label4;

	private TextBox txtCBA;

	private Label label3;

	private TextBox txtCB;

	private Panel panel6;

	private DataGridView dataGridView1;

	private Panel panel5;

	private Button button1;

	private Label label2;

	private TextBox txtSearch;

	private Panel panel4;

	private Label label1;

	private Label label27;

	private PictureBox pictureBox4;

	private Label label18;

	private PictureBox save;

	public Agregar_Productos_Venta()
	{
		InitializeComponent();
		Disabled();
		CargarCombo();
	}

	public void CargarCombo()
	{
		txtprov.DataSource = prov.GETPROV();
		txtprov.DisplayMember = "Nombre";
		txtprov.ValueMember = "Nombre";
	}

	private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			prod.Codigo = txtSearch.Text;
			DataTable dataTable = new DataTable();
			dataTable = prod.GET();
			dataGridView1.DataSource = dataTable;
			txtSearch.Text = "";
			LoadData();
		}
	}

	private void Disabled()
	{
		ch1.Enabled = false;
		txtFecha.Enabled = false;
		txtfecha_cad.Enabled = false;
		txtprecio_mayoreo.Enabled = false;
		txtdesc.Enabled = false;
		ch2.Enabled = false;
		ch3.Enabled = false;
		ch1.Checked = false;
		ch2.Checked = false;
		ch3.Checked = false;
	}

	private void Habilitar()
	{
		ch1.Enabled = true;
		ch2.Enabled = true;
		ch3.Enabled = true;
	}

	private bool Validar(string campo)
	{
		double num = 0.0;
		bool flag = false;
		if (campo == "")
		{
			return false;
		}
		try
		{
			num = Convert.ToDouble(campo);
			return true;
		}
		catch
		{
			MessageBox.Show("Debe ser un numero no se aceptan caracteres");
			return false;
		}
	}

	private void Guardar()
	{
		if (validacion)
		{
			prod.Nombre_P = txtNombre.Text.Trim();
			prod.Cantidad = txtCantidad.Text.Trim();
			prod.Codigo = txtCB.Text.Trim();
			prod.Cod_Alt = txtCBA.Text.Trim();
			prod.Descuento = txtdesc.Text.Trim();
			prod.Fecha_Reg = txtFecha.Value.Day + "/" + txtFecha.Value.Month + "/" + txtFecha.Value.Year;
			prod.Precio_Mayoreo = txtprecio_mayoreo.Text.Trim();
			prod.proveedor = txtprov.Text;
			prod.Precio_U = txtPrecio.Text.Trim();
			prod.IVA = "0." + txtIVA.Text.Trim();
			prod.Imagen = txtruta.Text;
			prod.Minimos = Min.Value.ToString();
			prod.Maximos = Max.Value.ToString();
			if (ch1.Checked)
			{
				prod.Fecha_Cad = txtfecha_cad.Value.Day + "/" + txtfecha_cad.Value.Month + "/" + txtfecha_cad.Value.Year;
			}
			else
			{
				prod.Fecha_Cad = "";
			}
			if (prod.POST() == 1)
			{
				MessageBox.Show("Producto Añadido con Exito");
				Limpiar();
				Disabled();
			}
			else if (prod.POST() == 2)
			{
				MessageBox.Show("Ha Ocurrido un Error");
			}
			else if (prod.POST() == 3)
			{
				MessageBox.Show("El producto ya existe en inventario");
			}
		}
		else
		{
			MessageBox.Show("Verifica que los campos no esten vacios, o que las cantidades no contengan letras");
		}
	}

	private void Limpiar()
	{
		txtprecio_mayoreo.Text = "0";
		txtPrecio.Text = "0";
		txtCantidad.Text = "0";
		txtNombre.Text = "";
		txtfecha_cad.ResetText();
		txtCB.Text = "";
		txtCBA.Text = "";
		txtdesc.Text = "0";
		txtIVA.Text = "0";
		txtprov.Text = "";
		pictureBox1.Image = Resources.picture;
		dataGridView1.DataSource = null;
		Max.Value = 0m;
		Min.Value = 0m;
		iD.Text = "";
	}

	private void LoadData()
	{
		try
		{
			string text = dataGridView1.Rows[0].Cells["IVA"].Value.ToString();
			string[] array = text.Split('.');
			if (text == "0")
			{
				txtIVA.Text = "0";
			}
			else
			{
				txtIVA.Text = array[1];
			}
			iD.Text = dataGridView1.Rows[0].Cells["idProducto"].Value.ToString();
			txtCB.Text = dataGridView1.Rows[0].Cells["Codigo"].Value.ToString();
			txtCBA.Text = dataGridView1.Rows[0].Cells["Codigo_Alterno"].Value.ToString();
			txtNombre.Text = dataGridView1.Rows[0].Cells["Nombre_P"].Value.ToString();
			txtCantidad.Text = dataGridView1.Rows[0].Cells["Cantidad"].Value.ToString();
			txtprecio_mayoreo.Text = dataGridView1.Rows[0].Cells["Mayoreo"].Value.ToString();
			txtfecha_cad.Text = dataGridView1.Rows[0].Cells["Fecha_Cad"].Value.ToString();
			txtdesc.Text = dataGridView1.Rows[0].Cells["Descuento"].Value.ToString();
			txtPrecio.Text = dataGridView1.Rows[0].Cells["Precio"].Value.ToString();
			txtprov.Text = dataGridView1.Rows[0].Cells["Proveedor"].Value.ToString();
			if (dataGridView1.Rows[0].Cells["Imagen"].Value.ToString() == "")
			{
				pictureBox1.Image = Resources.picture;
			}
			else
			{
				pictureBox1.Image = Image.FromFile(dataGridView1.Rows[0].Cells["Imagen"].Value.ToString());
			}
			txtruta.Text = dataGridView1.Rows[0].Cells["Imagen"].Value.ToString();
			string value = dataGridView1.Rows[0].Cells["Maximos"].Value.ToString();
			string value2 = dataGridView1.Rows[0].Cells["Minimos"].Value.ToString();
			Max.Value = Convert.ToInt32(value);
			Min.Value = Convert.ToInt32(value2);
			editar = true;
			Habilitar();
		}
		catch
		{
			MessageBox.Show("El producto solicitado no se encuentra en inventario");
		}
	}

	private void Editar()
	{
		prod.Id = iD.Text;
		prod.Nombre_P = txtNombre.Text.Trim();
		prod.Cantidad = txtCantidad.Text.Trim();
		prod.Codigo = txtCB.Text.Trim();
		prod.Cod_Alt = txtCBA.Text.Trim();
		prod.Descuento = txtdesc.Text.Trim();
		prod.Fecha_Reg = txtFecha.Value.Day + "/" + txtFecha.Value.Month + "/" + txtFecha.Value.Year;
		prod.Precio_U = txtPrecio.Text.Trim();
		prod.IVA = "0." + txtIVA.Text.Trim();
		prod.Precio_Mayoreo = txtprecio_mayoreo.Text.Trim();
		prod.proveedor = txtprov.Text.Trim();
		prod.Imagen = txtruta.Text;
		prod.Maximos = Max.Value.ToString();
		prod.Minimos = Min.Value.ToString();
		if (ch1.Checked)
		{
			prod.Fecha_Cad = txtfecha_cad.Value.Day + "/" + txtfecha_cad.Value.Month + "/" + txtfecha_cad.Value.Year;
		}
		else
		{
			prod.Fecha_Cad = "";
		}
		if (prod.UPDATE() == 1)
		{
			MessageBox.Show("Producto Editado con Exito");
			Limpiar();
			Disabled();
			editar = false;
		}
		else if (prod.UPDATE() == 2)
		{
			MessageBox.Show("Ha Ocurrido un Error");
		}
	}

	private void LoadImage()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = "C://Pictures/";
		openFileDialog.Filter = "Archivos de Imagen(*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			pictureBox1.ImageLocation = openFileDialog.FileName;
			txtruta.Text = openFileDialog.FileName;
		}
	}

	private void ch1_Click(object sender, EventArgs e)
	{
		if (ch1.Checked)
		{
			txtfecha_cad.Enabled = true;
		}
		else
		{
			txtfecha_cad.Enabled = false;
		}
	}

	private void ch2_Click(object sender, EventArgs e)
	{
		if (ch2.Checked)
		{
			txtdesc.Enabled = true;
		}
		else
		{
			txtdesc.Enabled = false;
		}
	}

	private void ch3_Click(object sender, EventArgs e)
	{
		if (ch3.Checked)
		{
			txtprecio_mayoreo.Enabled = true;
		}
		else
		{
			txtprecio_mayoreo.Enabled = false;
		}
	}

	private void txtPrecio_TextChanged(object sender, EventArgs e)
	{
		validacion = Validar(txtPrecio.Text);
		if (!validacion)
		{
			txtPrecio.Text = "";
		}
	}

	private void txtIVA_TextChanged(object sender, EventArgs e)
	{
		validacion = Validar(txtIVA.Text);
		if (!validacion)
		{
			txtIVA.Text = "";
		}
	}

	private void txtdesc_TextChanged(object sender, EventArgs e)
	{
		validacion = Validar(txtdesc.Text);
		if (!validacion)
		{
			txtdesc.Text = "";
		}
	}

	private void txtprecio_mayoreo_TextChanged(object sender, EventArgs e)
	{
		validacion = Validar(txtprecio_mayoreo.Text);
		if (!validacion)
		{
			txtprecio_mayoreo.Text = "";
		}
	}

	private void btnimage_Click(object sender, EventArgs e)
	{
		LoadImage();
	}

	private void txtCBA_Enter(object sender, EventArgs e)
	{
		if (!(txtCB.Text == ""))
		{
			Habilitar();
		}
	}

	private void save_Click(object sender, EventArgs e)
	{
		if (editar)
		{
			Editar();
		}
		else
		{
			Guardar();
		}
	}

	private void pictureBox4_Click(object sender, EventArgs e)
	{
		Codigo_Barras_Prod codigo_Barras_Prod = new Codigo_Barras_Prod();
		codigo_Barras_Prod.ShowDialog();
	}

	private void Agregar_Productos_Venta_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1)
		{
			if (editar)
			{
				Editar();
			}
			else
			{
				Guardar();
			}
		}
		else if (e.KeyCode == Keys.F3)
		{
			Codigo_Barras_Prod codigo_Barras_Prod = new Codigo_Barras_Prod();
			codigo_Barras_Prod.ShowDialog();
		}
	}

	private void txtCantidad_TextChanged(object sender, EventArgs e)
	{
		validacion = Validar(txtCantidad.Text);
		if (!validacion)
		{
			txtCantidad.Text = "";
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Agregar_Productos_Venta));
		panel3 = new System.Windows.Forms.Panel();
		label18 = new System.Windows.Forms.Label();
		save = new System.Windows.Forms.PictureBox();
		label27 = new System.Windows.Forms.Label();
		pictureBox4 = new System.Windows.Forms.PictureBox();
		iD = new System.Windows.Forms.Label();
		panel7 = new System.Windows.Forms.Panel();
		txtruta = new System.Windows.Forms.Label();
		panel13 = new System.Windows.Forms.Panel();
		label13 = new System.Windows.Forms.Label();
		panel12 = new System.Windows.Forms.Panel();
		label12 = new System.Windows.Forms.Label();
		panel11 = new System.Windows.Forms.Panel();
		panel15 = new System.Windows.Forms.Panel();
		txtprecio_mayoreo = new System.Windows.Forms.TextBox();
		txtdesc = new System.Windows.Forms.TextBox();
		label16 = new System.Windows.Forms.Label();
		label15 = new System.Windows.Forms.Label();
		txtfecha_cad = new System.Windows.Forms.DateTimePicker();
		label14 = new System.Windows.Forms.Label();
		panel14 = new System.Windows.Forms.Panel();
		ch3 = new System.Windows.Forms.CheckBox();
		ch2 = new System.Windows.Forms.CheckBox();
		ch1 = new System.Windows.Forms.CheckBox();
		panel10 = new System.Windows.Forms.Panel();
		label7 = new System.Windows.Forms.Label();
		panel9 = new System.Windows.Forms.Panel();
		btnimage = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel8 = new System.Windows.Forms.Panel();
		Min = new System.Windows.Forms.NumericUpDown();
		label23 = new System.Windows.Forms.Label();
		Max = new System.Windows.Forms.NumericUpDown();
		label22 = new System.Windows.Forms.Label();
		txtFecha = new System.Windows.Forms.DateTimePicker();
		txtprov = new System.Windows.Forms.ComboBox();
		label11 = new System.Windows.Forms.Label();
		label10 = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		txtIVA = new System.Windows.Forms.TextBox();
		label8 = new System.Windows.Forms.Label();
		txtPrecio = new System.Windows.Forms.TextBox();
		label6 = new System.Windows.Forms.Label();
		txtCantidad = new System.Windows.Forms.TextBox();
		label5 = new System.Windows.Forms.Label();
		txtNombre = new System.Windows.Forms.TextBox();
		label4 = new System.Windows.Forms.Label();
		txtCBA = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		txtCB = new System.Windows.Forms.TextBox();
		panel6 = new System.Windows.Forms.Panel();
		dataGridView1 = new System.Windows.Forms.DataGridView();
		panel5 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		label2 = new System.Windows.Forms.Label();
		txtSearch = new System.Windows.Forms.TextBox();
		panel4 = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
		panel3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)save).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
		panel7.SuspendLayout();
		panel13.SuspendLayout();
		panel12.SuspendLayout();
		panel11.SuspendLayout();
		panel15.SuspendLayout();
		panel14.SuspendLayout();
		panel10.SuspendLayout();
		panel9.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel8.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)Min).BeginInit();
		((System.ComponentModel.ISupportInitialize)Max).BeginInit();
		panel6.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
		panel5.SuspendLayout();
		panel4.SuspendLayout();
		SuspendLayout();
		panel3.BackColor = System.Drawing.Color.White;
		panel3.Controls.Add(label18);
		panel3.Controls.Add(save);
		panel3.Controls.Add(label27);
		panel3.Controls.Add(pictureBox4);
		panel3.Controls.Add(iD);
		panel3.Controls.Add(panel7);
		panel3.Controls.Add(panel6);
		panel3.Controls.Add(panel5);
		panel3.Controls.Add(panel4);
		panel3.Location = new System.Drawing.Point(0, 1);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(1028, 712);
		panel3.TabIndex = 16;
		label18.AutoSize = true;
		label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label18.Location = new System.Drawing.Point(196, 536);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(77, 15);
		label18.TabIndex = 20;
		label18.Text = "Guardar (F1)";
		save.BackColor = System.Drawing.Color.Transparent;
		save.Cursor = System.Windows.Forms.Cursors.Hand;
		save.Image = BLUPOINT.Properties.Resources.disquete;
		save.Location = new System.Drawing.Point(208, 464);
		save.Name = "save";
		save.Size = new System.Drawing.Size(65, 69);
		save.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		save.TabIndex = 18;
		save.TabStop = false;
		save.Click += new System.EventHandler(save_Click);
		label27.AutoSize = true;
		label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label27.Location = new System.Drawing.Point(27, 536);
		label27.Name = "label27";
		label27.Size = new System.Drawing.Size(119, 15);
		label27.TabIndex = 5;
		label27.Text = "Generar Codigo (F3)";
		pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox4.Image = BLUPOINT.Properties.Resources.codigo_de_barras;
		pictureBox4.Location = new System.Drawing.Point(30, 438);
		pictureBox4.Name = "pictureBox4";
		pictureBox4.Size = new System.Drawing.Size(107, 95);
		pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox4.TabIndex = 4;
		pictureBox4.TabStop = false;
		pictureBox4.Click += new System.EventHandler(pictureBox4_Click);
		iD.AutoSize = true;
		iD.ForeColor = System.Drawing.Color.White;
		iD.Location = new System.Drawing.Point(19, 13);
		iD.Name = "iD";
		iD.Size = new System.Drawing.Size(0, 13);
		iD.TabIndex = 4;
		panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel7.Controls.Add(txtruta);
		panel7.Controls.Add(panel13);
		panel7.Controls.Add(panel12);
		panel7.Controls.Add(panel11);
		panel7.Controls.Add(panel10);
		panel7.Controls.Add(panel9);
		panel7.Controls.Add(panel8);
		panel7.Location = new System.Drawing.Point(314, 43);
		panel7.Name = "panel7";
		panel7.Size = new System.Drawing.Size(671, 624);
		panel7.TabIndex = 3;
		txtruta.AutoSize = true;
		txtruta.ForeColor = System.Drawing.Color.White;
		txtruta.Location = new System.Drawing.Point(417, 555);
		txtruta.Name = "txtruta";
		txtruta.Size = new System.Drawing.Size(0, 13);
		txtruta.TabIndex = 2;
		panel13.BackColor = System.Drawing.Color.SteelBlue;
		panel13.Controls.Add(label13);
		panel13.Location = new System.Drawing.Point(393, 299);
		panel13.Name = "panel13";
		panel13.Size = new System.Drawing.Size(257, 34);
		panel13.TabIndex = 3;
		label13.AutoSize = true;
		label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label13.ForeColor = System.Drawing.Color.White;
		label13.Location = new System.Drawing.Point(89, 4);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(94, 25);
		label13.TabIndex = 0;
		label13.Text = "IMAGEN";
		panel12.BackColor = System.Drawing.Color.SteelBlue;
		panel12.Controls.Add(label12);
		panel12.Location = new System.Drawing.Point(393, 3);
		panel12.Name = "panel12";
		panel12.Size = new System.Drawing.Size(257, 34);
		panel12.TabIndex = 2;
		label12.AutoSize = true;
		label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label12.ForeColor = System.Drawing.Color.White;
		label12.Location = new System.Drawing.Point(80, 3);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(96, 25);
		label12.TabIndex = 0;
		label12.Text = "EXTRAS";
		panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel11.Controls.Add(panel15);
		panel11.Controls.Add(panel14);
		panel11.Location = new System.Drawing.Point(393, 38);
		panel11.Name = "panel11";
		panel11.Size = new System.Drawing.Size(257, 255);
		panel11.TabIndex = 2;
		panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel15.Controls.Add(txtprecio_mayoreo);
		panel15.Controls.Add(txtdesc);
		panel15.Controls.Add(label16);
		panel15.Controls.Add(label15);
		panel15.Controls.Add(txtfecha_cad);
		panel15.Controls.Add(label14);
		panel15.Location = new System.Drawing.Point(3, 113);
		panel15.Name = "panel15";
		panel15.Size = new System.Drawing.Size(245, 127);
		panel15.TabIndex = 3;
		txtprecio_mayoreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtprecio_mayoreo.Location = new System.Drawing.Point(83, 94);
		txtprecio_mayoreo.Name = "txtprecio_mayoreo";
		txtprecio_mayoreo.Size = new System.Drawing.Size(152, 26);
		txtprecio_mayoreo.TabIndex = 20;
		txtprecio_mayoreo.Text = "0";
		txtprecio_mayoreo.TextChanged += new System.EventHandler(txtprecio_mayoreo_TextChanged);
		txtdesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtdesc.Location = new System.Drawing.Point(84, 55);
		txtdesc.Name = "txtdesc";
		txtdesc.Size = new System.Drawing.Size(152, 26);
		txtdesc.TabIndex = 19;
		txtdesc.Text = "0";
		txtdesc.TextChanged += new System.EventHandler(txtdesc_TextChanged);
		label16.AutoSize = true;
		label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label16.ForeColor = System.Drawing.Color.Navy;
		label16.Location = new System.Drawing.Point(0, 94);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(77, 16);
		label16.TabIndex = 18;
		label16.Text = "Precio/May";
		label15.AutoSize = true;
		label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label15.ForeColor = System.Drawing.Color.Navy;
		label15.Location = new System.Drawing.Point(3, 59);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(73, 16);
		label15.TabIndex = 17;
		label15.Text = "Descuento";
		txtfecha_cad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtfecha_cad.Location = new System.Drawing.Point(84, 11);
		txtfecha_cad.Name = "txtfecha_cad";
		txtfecha_cad.Size = new System.Drawing.Size(156, 29);
		txtfecha_cad.TabIndex = 16;
		label14.AutoSize = true;
		label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label14.ForeColor = System.Drawing.Color.Navy;
		label14.Location = new System.Drawing.Point(3, 18);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(75, 16);
		label14.TabIndex = 0;
		label14.Text = "Fecha/Cad";
		panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel14.Controls.Add(ch3);
		panel14.Controls.Add(ch2);
		panel14.Controls.Add(ch1);
		panel14.Location = new System.Drawing.Point(4, 8);
		panel14.Name = "panel14";
		panel14.Size = new System.Drawing.Size(245, 99);
		panel14.TabIndex = 0;
		ch3.AutoSize = true;
		ch3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ch3.Location = new System.Drawing.Point(3, 67);
		ch3.Name = "ch3";
		ch3.Size = new System.Drawing.Size(167, 28);
		ch3.TabIndex = 2;
		ch3.Text = "Precio Mayorista";
		ch3.UseVisualStyleBackColor = true;
		ch3.Click += new System.EventHandler(ch3_Click);
		ch2.AutoSize = true;
		ch2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ch2.Location = new System.Drawing.Point(3, 35);
		ch2.Name = "ch2";
		ch2.Size = new System.Drawing.Size(120, 28);
		ch2.TabIndex = 1;
		ch2.Text = "Descuento";
		ch2.UseVisualStyleBackColor = true;
		ch2.Click += new System.EventHandler(ch2_Click);
		ch1.AutoSize = true;
		ch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ch1.Location = new System.Drawing.Point(3, 7);
		ch1.Name = "ch1";
		ch1.Size = new System.Drawing.Size(206, 28);
		ch1.TabIndex = 0;
		ch1.Text = "Fecha de Caducidad";
		ch1.UseVisualStyleBackColor = true;
		ch1.Click += new System.EventHandler(ch1_Click);
		panel10.BackColor = System.Drawing.Color.SteelBlue;
		panel10.Controls.Add(label7);
		panel10.Location = new System.Drawing.Point(4, 4);
		panel10.Name = "panel10";
		panel10.Size = new System.Drawing.Size(384, 34);
		panel10.TabIndex = 1;
		label7.AutoSize = true;
		label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label7.ForeColor = System.Drawing.Color.White;
		label7.Location = new System.Drawing.Point(79, 6);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(256, 25);
		label7.TabIndex = 0;
		label7.Text = "DATOS DEL PRODUCTO";
		panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		panel9.Controls.Add(btnimage);
		panel9.Controls.Add(pictureBox1);
		panel9.Location = new System.Drawing.Point(393, 329);
		panel9.Name = "panel9";
		panel9.Size = new System.Drawing.Size(257, 263);
		panel9.TabIndex = 1;
		btnimage.BackColor = System.Drawing.Color.SteelBlue;
		btnimage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnimage.ForeColor = System.Drawing.Color.White;
		btnimage.Location = new System.Drawing.Point(42, 157);
		btnimage.Name = "btnimage";
		btnimage.Size = new System.Drawing.Size(184, 47);
		btnimage.TabIndex = 1;
		btnimage.Text = "Seleccionar Imagen (F9)";
		btnimage.UseVisualStyleBackColor = false;
		btnimage.Click += new System.EventHandler(btnimage_Click);
		pictureBox1.Image = BLUPOINT.Properties.Resources.picture;
		pictureBox1.Location = new System.Drawing.Point(56, -2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(162, 160);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 0;
		pictureBox1.TabStop = false;
		panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel8.Controls.Add(Min);
		panel8.Controls.Add(label23);
		panel8.Controls.Add(Max);
		panel8.Controls.Add(label22);
		panel8.Controls.Add(txtFecha);
		panel8.Controls.Add(txtprov);
		panel8.Controls.Add(label11);
		panel8.Controls.Add(label10);
		panel8.Controls.Add(label9);
		panel8.Controls.Add(txtIVA);
		panel8.Controls.Add(label8);
		panel8.Controls.Add(txtPrecio);
		panel8.Controls.Add(label6);
		panel8.Controls.Add(txtCantidad);
		panel8.Controls.Add(label5);
		panel8.Controls.Add(txtNombre);
		panel8.Controls.Add(label4);
		panel8.Controls.Add(txtCBA);
		panel8.Controls.Add(label3);
		panel8.Controls.Add(txtCB);
		panel8.Location = new System.Drawing.Point(4, 36);
		panel8.Name = "panel8";
		panel8.Size = new System.Drawing.Size(384, 554);
		panel8.TabIndex = 0;
		Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Min.Location = new System.Drawing.Point(295, 507);
		Min.Name = "Min";
		Min.Size = new System.Drawing.Size(77, 31);
		Min.TabIndex = 20;
		label23.AutoSize = true;
		label23.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label23.Location = new System.Drawing.Point(201, 507);
		label23.Name = "label23";
		label23.Size = new System.Drawing.Size(93, 30);
		label23.TabIndex = 19;
		label23.Text = "Minimos";
		Max.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Max.Location = new System.Drawing.Point(111, 509);
		Max.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
		Max.Name = "Max";
		Max.Size = new System.Drawing.Size(84, 31);
		Max.TabIndex = 18;
		label22.AutoSize = true;
		label22.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label22.Location = new System.Drawing.Point(8, 509);
		label22.Name = "label22";
		label22.Size = new System.Drawing.Size(97, 30);
		label22.TabIndex = 17;
		label22.Text = "Maximos";
		txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtFecha.Location = new System.Drawing.Point(118, 453);
		txtFecha.Name = "txtFecha";
		txtFecha.Size = new System.Drawing.Size(251, 29);
		txtFecha.TabIndex = 15;
		txtprov.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtprov.FormattingEnabled = true;
		txtprov.Location = new System.Drawing.Point(118, 398);
		txtprov.Name = "txtprov";
		txtprov.Size = new System.Drawing.Size(251, 32);
		txtprov.TabIndex = 14;
		txtprov.Text = "Selecciona";
		label11.AutoSize = true;
		label11.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label11.Location = new System.Drawing.Point(5, 453);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(67, 30);
		label11.TabIndex = 13;
		label11.Text = "Fecha";
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label10.Location = new System.Drawing.Point(5, 399);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(107, 30);
		label10.TabIndex = 12;
		label10.Text = "Proveedor";
		label9.AutoSize = true;
		label9.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label9.Location = new System.Drawing.Point(5, 338);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(79, 30);
		label9.TabIndex = 11;
		label9.Text = "I.V.A %";
		txtIVA.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtIVA.Location = new System.Drawing.Point(121, 339);
		txtIVA.Name = "txtIVA";
		txtIVA.Size = new System.Drawing.Size(251, 33);
		txtIVA.TabIndex = 10;
		txtIVA.Text = "0";
		txtIVA.TextChanged += new System.EventHandler(txtIVA_TextChanged);
		label8.AutoSize = true;
		label8.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label8.Location = new System.Drawing.Point(5, 279);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(70, 30);
		label8.TabIndex = 9;
		label8.Text = "Precio";
		txtPrecio.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtPrecio.Location = new System.Drawing.Point(121, 280);
		txtPrecio.Name = "txtPrecio";
		txtPrecio.Size = new System.Drawing.Size(251, 33);
		txtPrecio.TabIndex = 8;
		txtPrecio.Text = "0";
		txtPrecio.TextChanged += new System.EventHandler(txtPrecio_TextChanged);
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label6.Location = new System.Drawing.Point(5, 220);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(96, 30);
		label6.TabIndex = 7;
		label6.Text = "Cantidad";
		txtCantidad.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtCantidad.Location = new System.Drawing.Point(121, 221);
		txtCantidad.Name = "txtCantidad";
		txtCantidad.Size = new System.Drawing.Size(251, 33);
		txtCantidad.TabIndex = 6;
		txtCantidad.Text = "0";
		txtCantidad.TextChanged += new System.EventHandler(txtCantidad_TextChanged);
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.Location = new System.Drawing.Point(5, 159);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(89, 30);
		label5.TabIndex = 5;
		label5.Text = "Nombre";
		txtNombre.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtNombre.Location = new System.Drawing.Point(121, 160);
		txtNombre.MaxLength = 12;
		txtNombre.Name = "txtNombre";
		txtNombre.Size = new System.Drawing.Size(251, 33);
		txtNombre.TabIndex = 4;
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(5, 98);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(153, 30);
		label4.TabIndex = 3;
		label4.Text = "Codigo Alterno";
		txtCBA.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtCBA.Location = new System.Drawing.Point(180, 99);
		txtCBA.Name = "txtCBA";
		txtCBA.Size = new System.Drawing.Size(192, 33);
		txtCBA.TabIndex = 2;
		txtCBA.Enter += new System.EventHandler(txtCBA_Enter);
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(5, 41);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(171, 30);
		label3.TabIndex = 1;
		label3.Text = "Codigo de Barras";
		txtCB.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtCB.Location = new System.Drawing.Point(180, 38);
		txtCB.Name = "txtCB";
		txtCB.Size = new System.Drawing.Size(192, 33);
		txtCB.TabIndex = 0;
		panel6.Controls.Add(dataGridView1);
		panel6.Location = new System.Drawing.Point(22, 248);
		panel6.Name = "panel6";
		panel6.Size = new System.Drawing.Size(290, 184);
		panel6.TabIndex = 2;
		dataGridView1.AllowUserToAddRows = false;
		dataGridView1.AllowUserToDeleteRows = false;
		dataGridView1.BackgroundColor = System.Drawing.Color.White;
		dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView1.GridColor = System.Drawing.Color.White;
		dataGridView1.Location = new System.Drawing.Point(0, 0);
		dataGridView1.Name = "dataGridView1";
		dataGridView1.Size = new System.Drawing.Size(282, 179);
		dataGridView1.TabIndex = 0;
		panel5.Controls.Add(button1);
		panel5.Controls.Add(label2);
		panel5.Controls.Add(txtSearch);
		panel5.Location = new System.Drawing.Point(22, 76);
		panel5.Name = "panel5";
		panel5.Size = new System.Drawing.Size(282, 168);
		panel5.TabIndex = 1;
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 192, 192);
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(8, 101);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(260, 51);
		button1.TabIndex = 2;
		button1.Text = "Mostrar todos los productos";
		button1.UseVisualStyleBackColor = false;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(74, 24);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(148, 13);
		label2.TabIndex = 1;
		label2.Text = "Escribe o escanea el codigo";
		txtSearch.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtSearch.Location = new System.Drawing.Point(9, 41);
		txtSearch.Name = "txtSearch";
		txtSearch.Size = new System.Drawing.Size(260, 39);
		txtSearch.TabIndex = 0;
		txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSearch_KeyPress);
		panel4.BackColor = System.Drawing.Color.SteelBlue;
		panel4.Controls.Add(label1);
		panel4.Location = new System.Drawing.Point(22, 42);
		panel4.Name = "panel4";
		panel4.Size = new System.Drawing.Size(282, 34);
		panel4.TabIndex = 0;
		label1.AutoSize = true;
		label1.BackColor = System.Drawing.Color.SteelBlue;
		label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.ForeColor = System.Drawing.Color.White;
		label1.Location = new System.Drawing.Point(91, 2);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(116, 25);
		label1.TabIndex = 0;
		label1.Text = "BUCADOR";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(967, 663);
		base.Controls.Add(panel3);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Agregar_Productos_Venta";
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Agregar_Productos_Venta_KeyUp);
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)save).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
		panel7.ResumeLayout(false);
		panel7.PerformLayout();
		panel13.ResumeLayout(false);
		panel13.PerformLayout();
		panel12.ResumeLayout(false);
		panel12.PerformLayout();
		panel11.ResumeLayout(false);
		panel15.ResumeLayout(false);
		panel15.PerformLayout();
		panel14.ResumeLayout(false);
		panel14.PerformLayout();
		panel10.ResumeLayout(false);
		panel10.PerformLayout();
		panel9.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel8.ResumeLayout(false);
		panel8.PerformLayout();
		((System.ComponentModel.ISupportInitialize)Min).EndInit();
		((System.ComponentModel.ISupportInitialize)Max).EndInit();
		panel6.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
		panel5.ResumeLayout(false);
		panel5.PerformLayout();
		panel4.ResumeLayout(false);
		panel4.PerformLayout();
		ResumeLayout(false);
	}
}

// BLUPOINT.alert_danger
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;

public class alert_danger : Form
{
	private IContainer components = null;

	private Button button2;

	private Label Message;

	private Button button3;

	private Label Title;

	private PictureBox pictureBox1;

	public alert_danger(string titulo, string mensaje)
	{
		InitializeComponent();
		CargarCuadro(titulo, mensaje);
	}

	private void CargarCuadro(string titulo, string mensaje)
	{
		Title.Text = titulo;
		Message.Text = mensaje;
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Principal("si");
		Empleado("si");
		Venta("si");
		Producto("si");
	}

	private void button3_Click(object sender, EventArgs e)
	{
		Principal("no");
		Empleado("no");
		Venta("no");
		Producto("no");
	}

	private void Venta(string deci)
	{
		if (deci == "si")
		{
			try
			{
				Venta venta = base.Owner as Venta;
				venta.respuesta = "Si";
				Close();
			}
			catch
			{
			}
		}
		else
		{
			try
			{
				Venta venta2 = base.Owner as Venta;
				venta2.respuesta = "No";
				Close();
			}
			catch
			{
			}
		}
	}

	private void Producto(string deci)
	{
		if (deci == "si")
		{
			try
			{
				Producto producto = base.Owner as Producto;
				producto.respuesta = "Si";
				Close();
			}
			catch
			{
			}
		}
		else
		{
			try
			{
				Producto producto2 = base.Owner as Producto;
				producto2.respuesta = "No";
				Close();
			}
			catch
			{
			}
		}
	}

	private void Empleado(string deci)
	{
		if (deci == "si")
		{
			try
			{
				Empleado empleado = base.Owner as Empleado;
				empleado.respuesta = "Si";
				Close();
			}
			catch
			{
			}
		}
		else
		{
			try
			{
				Empleado empleado2 = base.Owner as Empleado;
				empleado2.respuesta = "No";
				Close();
			}
			catch
			{
			}
		}
	}

	private void Principal(string deci)
	{
		if (deci == "si")
		{
			try
			{
				Form1 form = base.Owner as Form1;
				form.respuesta = "Si";
				Close();
			}
			catch
			{
			}
		}
		else
		{
			try
			{
				Form1 form2 = base.Owner as Form1;
				form2.respuesta = "No";
				Close();
			}
			catch
			{
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
		button2 = new System.Windows.Forms.Button();
		Message = new System.Windows.Forms.Label();
		button3 = new System.Windows.Forms.Button();
		Title = new System.Windows.Forms.Label();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		button2.BackColor = System.Drawing.Color.Green;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Location = new System.Drawing.Point(43, 281);
		button2.Name = "button2";
		button2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		button2.Size = new System.Drawing.Size(167, 37);
		button2.TabIndex = 5;
		button2.Text = "Si";
		button2.UseVisualStyleBackColor = false;
		button2.Click += new System.EventHandler(button2_Click);
		Message.AutoSize = true;
		Message.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Message.Location = new System.Drawing.Point(26, 228);
		Message.Name = "Message";
		Message.Size = new System.Drawing.Size(430, 25);
		Message.TabIndex = 4;
		Message.Text = "En este recuadro se posicionara  el texto principal";
		button3.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
		button3.Cursor = System.Windows.Forms.Cursors.Hand;
		button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button3.ForeColor = System.Drawing.Color.White;
		button3.Location = new System.Drawing.Point(273, 281);
		button3.Name = "button3";
		button3.Size = new System.Drawing.Size(165, 37);
		button3.TabIndex = 6;
		button3.Text = "No";
		button3.UseVisualStyleBackColor = false;
		button3.Click += new System.EventHandler(button3_Click);
		Title.AutoSize = true;
		Title.BackColor = System.Drawing.Color.Transparent;
		Title.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		Title.ForeColor = System.Drawing.Color.Black;
		Title.Location = new System.Drawing.Point(155, 171);
		Title.Name = "Title";
		Title.Size = new System.Drawing.Size(174, 32);
		Title.TabIndex = 7;
		Title.Text = "Tipo de alerta";
		pictureBox1.Image = BLUPOINT.Properties.Resources.info;
		pictureBox1.Location = new System.Drawing.Point(174, 21);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(134, 136);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 8;
		pictureBox1.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(488, 340);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(Title);
		base.Controls.Add(button3);
		base.Controls.Add(button2);
		base.Controls.Add(Message);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "alert_danger";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "alert_danger";
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}

// BLUPOINT.Alert_Error
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT.Properties;

public class Alert_Error : Form
{
	private IContainer components = null;

	private PictureBox pictureBox1;

	private Label label1;

	private Label Mesa;

	private Button button1;

	public Alert_Error(string mensaje)
	{
		InitializeComponent();
		Mesa.Text = mensaje;
	}

	private void button1_Click(object sender, EventArgs e)
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
		label1 = new System.Windows.Forms.Label();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		Mesa = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 26.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(180, 151);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(132, 47);
		label1.TabIndex = 1;
		label1.Text = "Oops...";
		pictureBox1.Image = BLUPOINT.Properties.Resources.error;
		pictureBox1.Location = new System.Drawing.Point(188, 12);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(141, 131);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 0;
		pictureBox1.TabStop = false;
		Mesa.AutoSize = true;
		Mesa.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Mesa.Location = new System.Drawing.Point(110, 212);
		Mesa.Name = "Mesa";
		Mesa.Size = new System.Drawing.Size(202, 30);
		Mesa.TabIndex = 2;
		Mesa.Text = "Ha ocurrido un error";
		button1.BackColor = System.Drawing.Color.FromArgb(54, 185, 219);
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(174, 268);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(166, 42);
		button1.TabIndex = 3;
		button1.Text = "Aceptar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(506, 322);
		base.Controls.Add(button1);
		base.Controls.Add(Mesa);
		base.Controls.Add(label1);
		base.Controls.Add(pictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "Alert_Error";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Alert_Error";
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}

// BLUPOINT.alert_success
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT.Properties;

public class alert_success : Form
{
	private IContainer components = null;

	private PictureBox pictureBox1;

	private Button button1;

	private Label Mesa;

	private Label label1;

	public alert_success(string mensaje)
	{
		InitializeComponent();
		Mesa.Text = mensaje;
	}

	private void button1_Click(object sender, EventArgs e)
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
		pictureBox1 = new System.Windows.Forms.PictureBox();
		button1 = new System.Windows.Forms.Button();
		Mesa = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		pictureBox1.Image = BLUPOINT.Properties.Resources.success;
		pictureBox1.Location = new System.Drawing.Point(122, 40);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(122, 120);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 0;
		pictureBox1.TabStop = false;
		button1.BackColor = System.Drawing.Color.FromArgb(54, 185, 219);
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(96, 284);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(166, 42);
		button1.TabIndex = 4;
		button1.Text = "Aceptar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		Mesa.AutoSize = true;
		Mesa.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Mesa.Location = new System.Drawing.Point(68, 226);
		Mesa.Name = "Mesa";
		Mesa.Size = new System.Drawing.Size(202, 30);
		Mesa.TabIndex = 6;
		Mesa.Text = "Ha ocurrido un error";
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 26.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(65, 163);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(244, 47);
		label1.TabIndex = 5;
		label1.Text = "¡Completado!";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(400, 332);
		base.Controls.Add(Mesa);
		base.Controls.Add(label1);
		base.Controls.Add(button1);
		base.Controls.Add(pictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "alert_success";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "alert_success";
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}

// BLUPOINT.Box
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Box : Form
{
	private Caja cj = new Caja();

	private string name;

	private string tipos;

	private string permisos;

	private string editar;

	private string id_box;

	private IContainer components = null;

	private TextBox textBox1;

	private Label label1;

	private Label label2;

	private PictureBox pictureBox1;

	private Button button1;

	public TextBox textBox2;

	private Panel panel1;

	private PictureBox pictureBox2;

	private Panel panel2;

	private DataGridView dataGridView1;

	private Panel panel3;

	private Label label3;

	private PictureBox pictureBox3;

	private PictureBox pictureBox4;

	private PictureBox pictureBox5;

	private ToolTip toolTip1;

	private PictureBox pictureBox6;

	private PictureBox pictureBox7;

	public Box(string nombre, string tipo, string permiso)
	{
		InitializeComponent();
		dataGridView1.DataSource = cj.GET();
		name = nombre;
		tipos = tipo;
		permisos = permiso;
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		Dinero dinero = new Dinero("Caja1");
		AddOwnedForm(dinero);
		dinero.ShowDialog();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		if (editar == "1")
		{
			if (textBox1.Text == "")
			{
				MessageBox.Show("No puedes dejar la caja sin nombre");
				return;
			}
			if (textBox2.Text == "")
			{
				MessageBox.Show("No puedes dejar la caja sin dinero");
				return;
			}
			cj.Nombre_C = textBox1.Text;
			cj.Cantidad = textBox2.Text;
			cj.id_caja = id_box;
			if (cj.UPDATEBOX() == 1)
			{
				MessageBox.Show("Caja Actualizada");
				editar = "0";
				button1.Text = "AGREGAR (F2)";
				textBox1.Enabled = false;
				textBox2.Enabled = false;
				textBox1.Text = "";
				textBox2.Text = "";
				dataGridView1.DataSource = cj.GET();
			}
			else
			{
				MessageBox.Show("Error");
			}
		}
		else if (textBox1.Text == "")
		{
			MessageBox.Show("No puedes Registrar una caja sin antes ponerle un nombre");
		}
		else if (textBox2.Text == "")
		{
			MessageBox.Show("No puedes Registrar una caja sin antes ponerle una cantidad");
		}
		else
		{
			cj.Nombre_C = textBox1.Text;
			cj.Cantidad = textBox2.Text;
			cj.Default = "0";
			if (cj.Box() == 1)
			{
				MessageBox.Show("Caja agregada");
				textBox1.Enabled = false;
				textBox2.Enabled = false;
				textBox1.Text = "";
				textBox2.Text = "";
				dataGridView1.DataSource = cj.GET();
			}
		}
	}

	private void pictureBox2_Click(object sender, EventArgs e)
	{
		textBox1.Enabled = true;
		textBox2.Enabled = true;
	}

	private void pictureBox3_Click(object sender, EventArgs e)
	{
		if (dataGridView1.SelectedRows.Count <= 0)
		{
			MessageBox.Show("Debes seleccionar una fila");
			return;
		}
		cj.id_caja = dataGridView1.CurrentRow.Cells["idCaja"].Value.ToString();
		if (cj.DELETE() == 1)
		{
			MessageBox.Show("Caja Eliminada con exito");
			Form1 form = base.Owner as Form1;
			form.LoadMoney();
			dataGridView1.DataSource = cj.GET();
		}
		else
		{
			MessageBox.Show("Ha ocurrido un error, por favor contacta con soporte tecnico");
		}
	}

	private void pictureBox6_Click(object sender, EventArgs e)
	{
		if (dataGridView1.SelectedRows.Count <= 0)
		{
			MessageBox.Show("Debes seleccionar una fila");
			return;
		}
		int num = 0;
		foreach (DataGridViewRow item in (IEnumerable)dataGridView1.Rows)
		{
			num += Convert.ToInt32(item.Cells["Defaults"].Value);
		}
		if (num >= 1)
		{
			cj.id_caja = dataGridView1.CurrentRow.Cells["idcaja"].Value.ToString();
			cj.Default = "0";
			if (cj.Asignar() == 1)
			{
				MessageBox.Show(dataGridView1.CurrentRow.Cells["Nombre_Caja"].Value.ToString() + " Se ha quitado");
				dataGridView1.DataSource = cj.GET();
				Form1 form = base.Owner as Form1;
				form.LoadMoney();
			}
			else
			{
				MessageBox.Show("Ha ocurrido un error");
			}
		}
		else
		{
			MessageBox.Show("No tienes cajas asignadas");
		}
	}

	private void pictureBox5_Click(object sender, EventArgs e)
	{
		if (dataGridView1.SelectedRows.Count <= 0)
		{
			MessageBox.Show("Debes seleccionar una fila");
			return;
		}
		int num = 0;
		foreach (DataGridViewRow item in (IEnumerable)dataGridView1.Rows)
		{
			num += Convert.ToInt32(item.Cells["Defaults"].Value);
		}
		if (num >= 1)
		{
			MessageBox.Show("No Puedes asignar mas de 2 cajas, debes desabilitar una");
			return;
		}
		cj.id_caja = dataGridView1.CurrentRow.Cells["idcaja"].Value.ToString();
		cj.Default = "1";
		if (cj.Asignar() == 1)
		{
			try
			{
				Form1 form = base.Owner as Form1;
				form.LoadMoney();
				MessageBox.Show(dataGridView1.CurrentRow.Cells["Nombre_Caja"].Value.ToString() + " Asignada");
				dataGridView1.DataSource = cj.GET();
			}
			catch
			{
				try
				{
					Venta venta = base.Owner as Venta;
					venta.LoadMoney();
					MessageBox.Show(dataGridView1.CurrentRow.Cells["Nombre_Caja"].Value.ToString() + " Asignada");
					dataGridView1.DataSource = cj.GET();
				}
				catch
				{
				}
			}
		}
		else
		{
			MessageBox.Show("Ha ocurrido un error");
		}
	}

	private void textBox2_TextChanged(object sender, EventArgs e)
	{
		if (!(textBox2.Text == ""))
		{
			try
			{
				double num = Convert.ToDouble(textBox2.Text);
			}
			catch
			{
				MessageBox.Show("Solo se pueden introducir Numeros");
				textBox2.Text = "";
			}
		}
	}

	private void Box_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F2)
		{
			if (editar == "1")
			{
				if (textBox1.Text == "")
				{
					MessageBox.Show("No puedes dejar la caja sin nombre");
				}
				else if (textBox2.Text == "")
				{
					MessageBox.Show("No puedes dejar la caja sin dinero");
				}
				else
				{
					cj.Nombre_C = textBox1.Text;
					cj.Cantidad = textBox2.Text;
					cj.id_caja = id_box;
					if (cj.UPDATEBOX() == 1)
					{
						MessageBox.Show("Caja Actualizada");
						editar = "0";
						button1.Text = "AGREGAR (F2)";
						textBox1.Enabled = false;
						textBox2.Enabled = false;
						textBox1.Text = "";
						textBox2.Text = "";
						dataGridView1.DataSource = cj.GET();
					}
				}
			}
			else if (textBox1.Text == "")
			{
				MessageBox.Show("No puedes Registrar una caja sin antes ponerle un nombre");
			}
			else if (textBox2.Text == "")
			{
				MessageBox.Show("No puedes Registrar una caja sin antes ponerle una cantidad");
			}
			else
			{
				cj.Nombre_C = textBox1.Text;
				cj.Cantidad = textBox2.Text;
				cj.Default = "0";
				if (cj.Box() == 1)
				{
					MessageBox.Show("Caja agregada");
					textBox1.Enabled = false;
					textBox2.Enabled = false;
					textBox1.Text = "";
					textBox2.Text = "";
					dataGridView1.DataSource = cj.GET();
				}
			}
		}
		if (e.KeyCode == Keys.F1)
		{
			textBox1.Enabled = true;
			textBox2.Enabled = true;
		}
		if (e.KeyCode == Keys.F3)
		{
			if (dataGridView1.SelectedRows.Count <= 0)
			{
				MessageBox.Show("Debes seleccionar una fila");
			}
			else
			{
				int num = 0;
				foreach (DataGridViewRow item in (IEnumerable)dataGridView1.Rows)
				{
					num += Convert.ToInt32(item.Cells["Defaults"].Value);
				}
				if (num >= 1)
				{
					MessageBox.Show("No Puedes asignar mas de 2 cajas, debes desabilitar una");
				}
				else
				{
					cj.id_caja = dataGridView1.CurrentRow.Cells["idcaja"].Value.ToString();
					cj.Default = "1";
					if (cj.Asignar() == 1)
					{
						Form1 form = base.Owner as Form1;
						form.txtmoney.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
						MessageBox.Show(dataGridView1.CurrentRow.Cells["Nombre_Caja"].Value.ToString() + " Asignada");
						dataGridView1.DataSource = cj.GET();
					}
					else
					{
						MessageBox.Show("Ha ocurrido un error");
					}
				}
			}
		}
		if (e.KeyCode == Keys.F4)
		{
			if (dataGridView1.SelectedRows.Count <= 0)
			{
				MessageBox.Show("Debes seleccionar una fila");
			}
			else
			{
				cj.id_caja = dataGridView1.CurrentRow.Cells["idCaja"].Value.ToString();
				if (cj.DELETE() == 1)
				{
					MessageBox.Show("Caja Eliminada con exito");
					Form1 form2 = base.Owner as Form1;
					form2.txtmoney.Text = "0.0";
					dataGridView1.DataSource = cj.GET();
				}
				else
				{
					MessageBox.Show("Ha ocurrido un error, por favor contacta con soporte tecnico");
				}
			}
		}
		if (e.KeyCode != Keys.Escape)
		{
			return;
		}
		if (dataGridView1.SelectedRows.Count <= 0)
		{
			MessageBox.Show("Debes seleccionar una fila");
		}
		else
		{
			int num2 = 0;
			foreach (DataGridViewRow item2 in (IEnumerable)dataGridView1.Rows)
			{
				num2 += Convert.ToInt32(item2.Cells["Defaults"].Value);
			}
			if (num2 >= 1)
			{
				cj.id_caja = dataGridView1.CurrentRow.Cells["idcaja"].Value.ToString();
				cj.Default = "0";
				if (cj.Asignar() == 1)
				{
					MessageBox.Show(dataGridView1.CurrentRow.Cells["Nombre_Caja"].Value.ToString() + " Se ha quitado");
					dataGridView1.DataSource = cj.GET();
					Form1 form3 = base.Owner as Form1;
					form3.txtmoney.Text = "0.0";
				}
				else
				{
					MessageBox.Show("Ha ocurrido un error");
				}
			}
			else
			{
				MessageBox.Show("No tienes cajas asignadas");
			}
		}
		if (e.KeyCode == Keys.F5)
		{
			Corte_Caja corte_Caja = new Corte_Caja(name, tipos);
			corte_Caja.ShowDialog();
		}
	}

	private void pictureBox7_Click(object sender, EventArgs e)
	{
		if (permisos == "1")
		{
			if (dataGridView1.SelectedRows.Count <= 0)
			{
				MessageBox.Show("Debes seleccionar una fila");
				return;
			}
			textBox1.Enabled = true;
			textBox2.Enabled = true;
			textBox1.Text = dataGridView1.CurrentRow.Cells["Nombre_Caja"].Value.ToString();
			textBox2.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
			id_box = dataGridView1.CurrentRow.Cells["idCaja"].Value.ToString();
			button1.Text = "GUARDAR (F2)";
			editar = "1";
		}
		else
		{
			MessageBox.Show("No tienes los permisos para ejecutar esta accion");
		}
	}

	private void pictureBox4_Click(object sender, EventArgs e)
	{
		Corte_Caja corte_Caja = new Corte_Caja(name, tipos);
		corte_Caja.ShowDialog();
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
		textBox1 = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		textBox2 = new System.Windows.Forms.TextBox();
		button1 = new System.Windows.Forms.Button();
		panel1 = new System.Windows.Forms.Panel();
		pictureBox7 = new System.Windows.Forms.PictureBox();
		pictureBox6 = new System.Windows.Forms.PictureBox();
		pictureBox5 = new System.Windows.Forms.PictureBox();
		pictureBox4 = new System.Windows.Forms.PictureBox();
		pictureBox3 = new System.Windows.Forms.PictureBox();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		panel2 = new System.Windows.Forms.Panel();
		dataGridView1 = new System.Windows.Forms.DataGridView();
		panel3 = new System.Windows.Forms.Panel();
		label3 = new System.Windows.Forms.Label();
		toolTip1 = new System.Windows.Forms.ToolTip(components);
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
		panel3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		textBox1.Enabled = false;
		textBox1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		textBox1.Location = new System.Drawing.Point(391, 119);
		textBox1.Name = "textBox1";
		textBox1.Size = new System.Drawing.Size(285, 35);
		textBox1.TabIndex = 0;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(386, 86);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(164, 30);
		label1.TabIndex = 1;
		label1.Text = "Nombre de Caja";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(386, 200);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(190, 30);
		label2.TabIndex = 3;
		label2.Text = "Cantidad a agregar";
		textBox2.Enabled = false;
		textBox2.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		textBox2.Location = new System.Drawing.Point(426, 233);
		textBox2.Name = "textBox2";
		textBox2.Size = new System.Drawing.Size(285, 35);
		textBox2.TabIndex = 2;
		textBox2.TextChanged += new System.EventHandler(textBox2_TextChanged);
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(484, 301);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(158, 40);
		button1.TabIndex = 5;
		button1.Text = "AGREGAR (F2)";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(pictureBox7);
		panel1.Controls.Add(pictureBox6);
		panel1.Controls.Add(pictureBox5);
		panel1.Controls.Add(pictureBox4);
		panel1.Controls.Add(pictureBox3);
		panel1.Controls.Add(pictureBox2);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(736, 39);
		panel1.TabIndex = 6;
		pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox7.Image = BLUPOINT.Properties.Resources.bolsa_de_dinero_de_dolares;
		pictureBox7.Location = new System.Drawing.Point(226, 3);
		pictureBox7.Name = "pictureBox7";
		pictureBox7.Size = new System.Drawing.Size(33, 36);
		pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox7.TabIndex = 5;
		pictureBox7.TabStop = false;
		toolTip1.SetToolTip(pictureBox7, "Agrega dinero o edita la cantidad en caja manualmente");
		pictureBox7.Click += new System.EventHandler(pictureBox7_Click);
		pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox6.Image = BLUPOINT.Properties.Resources.eliminar;
		pictureBox6.Location = new System.Drawing.Point(277, 3);
		pictureBox6.Name = "pictureBox6";
		pictureBox6.Size = new System.Drawing.Size(33, 36);
		pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox6.TabIndex = 4;
		pictureBox6.TabStop = false;
		toolTip1.SetToolTip(pictureBox6, "Desasigna una caja");
		pictureBox6.Click += new System.EventHandler(pictureBox6_Click);
		pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox5.Image = BLUPOINT.Properties.Resources.marca_de_verificacion;
		pictureBox5.Location = new System.Drawing.Point(178, 3);
		pictureBox5.Name = "pictureBox5";
		pictureBox5.Size = new System.Drawing.Size(33, 36);
		pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox5.TabIndex = 3;
		pictureBox5.TabStop = false;
		toolTip1.SetToolTip(pictureBox5, "Seleccina una caja y da click para usar esa caja");
		pictureBox5.Click += new System.EventHandler(pictureBox5_Click);
		pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox4.Image = BLUPOINT.Properties.Resources.caja_registradora;
		pictureBox4.Location = new System.Drawing.Point(123, 3);
		pictureBox4.Name = "pictureBox4";
		pictureBox4.Size = new System.Drawing.Size(33, 36);
		pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox4.TabIndex = 2;
		pictureBox4.TabStop = false;
		toolTip1.SetToolTip(pictureBox4, "Selecciona una Caja para realizar su Corte");
		pictureBox4.Click += new System.EventHandler(pictureBox4_Click);
		pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox3.Image = BLUPOINT.Properties.Resources.borrar;
		pictureBox3.Location = new System.Drawing.Point(74, 0);
		pictureBox3.Name = "pictureBox3";
		pictureBox3.Size = new System.Drawing.Size(33, 36);
		pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox3.TabIndex = 1;
		pictureBox3.TabStop = false;
		toolTip1.SetToolTip(pictureBox3, "Selecciona una caja y luego eliminala");
		pictureBox3.Click += new System.EventHandler(pictureBox3_Click);
		pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox2.Image = BLUPOINT.Properties.Resources.anadir;
		pictureBox2.Location = new System.Drawing.Point(23, 0);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(33, 36);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 0;
		pictureBox2.TabStop = false;
		toolTip1.SetToolTip(pictureBox2, "Añadir nueva Caja");
		pictureBox2.Click += new System.EventHandler(pictureBox2_Click);
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Controls.Add(dataGridView1);
		panel2.Location = new System.Drawing.Point(12, 99);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(346, 270);
		panel2.TabIndex = 7;
		dataGridView1.AllowUserToAddRows = false;
		dataGridView1.AllowUserToDeleteRows = false;
		dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
		dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView1.GridColor = System.Drawing.Color.Black;
		dataGridView1.Location = new System.Drawing.Point(0, 3);
		dataGridView1.Name = "dataGridView1";
		dataGridView1.Size = new System.Drawing.Size(343, 301);
		dataGridView1.TabIndex = 0;
		panel3.BackColor = System.Drawing.Color.SteelBlue;
		panel3.Controls.Add(label3);
		panel3.Location = new System.Drawing.Point(13, 57);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(343, 40);
		panel3.TabIndex = 8;
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.ForeColor = System.Drawing.Color.White;
		label3.Location = new System.Drawing.Point(79, 4);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(174, 30);
		label3.TabIndex = 9;
		label3.Text = "Cajas Registradas";
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox1.Image = BLUPOINT.Properties.Resources.calculadora;
		pictureBox1.Location = new System.Drawing.Point(391, 233);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(29, 35);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 4;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
		base.ClientSize = new System.Drawing.Size(736, 383);
		base.Controls.Add(panel3);
		base.Controls.Add(panel2);
		base.Controls.Add(panel1);
		base.Controls.Add(button1);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(label2);
		base.Controls.Add(textBox2);
		base.Controls.Add(label1);
		base.Controls.Add(textBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.Name = "Box";
		Text = "Caja";
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Box_KeyUp);
		panel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}

// BLUPOINT.Cliente
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Cliente : Form
{
	private string rutas;

	private string ids;

	private string cargo1;

	private string cargo2;

	private string cargo3;

	private string cargo4;

	private Clientes cl = new Clientes();

	private Caja cj = new Caja();

	private bool editar;

	private IContainer components = null;

	private Panel panel2;

	private PictureBox search;

	private PictureBox Delete;

	private PictureBox cancel;

	private PictureBox save;

	private PictureBox edit;

	private PictureBox add;

	private Panel panel1;

	private Panel panel16;

	private Label txttipo_e;

	private Label label19;

	private PictureBox image_user;

	private Label label18;

	private Label txtName;

	private Panel panel3;

	private DateTimePicker dtmp;

	private Label label6;

	private Label label5;

	private TextBox txtphone;

	private Label label4;

	private TextBox txtmail;

	private TextBox txtapell;

	private Label label3;

	private TextBox txtn;

	private Label label2;

	private Label label1;

	private TextBox txtc;

	private Panel panel4;

	private Button button1;

	private DataGridView dgvcl;

	private TextBox txtcode;

	private Panel panel5;

	private Panel panel6;

	private Panel panel7;

	private Label label8;

	private Panel panel8;

	private Label label7;

	private Panel panel9;

	private Label label9;

	private Panel panel10;

	private Label label10;

	private CheckBox cb2;

	private CheckBox cb1;

	private Label txtid;

	private TextBox txtno;

	private TextBox txtcol;

	private Label label11;

	private TextBox txtcalle;

	private ToolTip toolTip1;

	private PictureBox pictureBox1;

	private Label label12;

	public Label txtmoney;

	private Label label14;

	private Label label15;

	private Label txtidbox;

	private PictureBox pictureBox5;

	public Cliente(string nombre, string ruta, string cargo, string id, string car1, string car2, string car3, string car4)
	{
		InitializeComponent();
		base.KeyDown += Cliente_KeyUp;
		base.KeyPreview = true;
		rutas = ruta;
		ids = id;
		txtName.Text = nombre;
		txttipo_e.Text = cargo;
		Disabled();
		editar = false;
		cargo1 = car1;
		cargo2 = car2;
		cargo3 = car3;
		cargo4 = car4;
		LoadMoney();
	}

	private void LoadMoney()
	{
		DataTable dataTable = new DataTable();
		try
		{
			dataTable = cj.GETMONEY();
			txtmoney.Text = dataTable.Rows[0]["Cantidad"].ToString();
			txtidbox.Text = dataTable.Rows[0]["idCaja"].ToString();
		}
		catch
		{
		}
	}

	private void txtcode_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			cl.Nombre = txtcode.Text;
			dgvcl.DataSource = cl.GETBYID();
			txtcode.Text = "";
		}
	}

	private void Disabled()
	{
		txtn.Enabled = false;
		txtmail.Enabled = false;
		txtapell.Enabled = false;
		txtcode.Enabled = false;
		txtphone.Enabled = false;
		txtc.Enabled = false;
		cb1.Enabled = false;
		cb2.Enabled = false;
		txtno.Enabled = false;
		txtcol.Enabled = false;
		txtcalle.Enabled = false;
		edit.Enabled = false;
		Delete.Enabled = false;
		save.Enabled = false;
		cancel.Enabled = false;
		edit.Image = Resources.usuario__2_;
		Delete.Image = Resources.eliminar_usuario__1_;
		cancel.Image = Resources.eliminar1;
		save.Image = Resources.disquete1;
		add.Enabled = true;
		add.Image = Resources.agregar_simbolo_de_usuario1;
		dgvcl.DataSource = cl.GETCli();
	}

	private void Habilitar()
	{
		txtn.Enabled = true;
		txtmail.Enabled = true;
		txtapell.Enabled = true;
		txtcode.Enabled = true;
		txtphone.Enabled = true;
		cb1.Enabled = true;
		cb2.Enabled = true;
		txtno.Enabled = true;
		txtcol.Enabled = true;
		txtcalle.Enabled = true;
		txtn.Focus();
		edit.Enabled = false;
		Delete.Enabled = false;
		save.Enabled = true;
		cancel.Enabled = true;
		edit.Image = Resources.usuario__2_;
		Delete.Image = Resources.eliminar_usuario__1_;
		cancel.Image = Resources.eliminar;
		save.Image = Resources.disquete;
		add.Image = Resources.agregar_simbolo_de_usuario1;
	}

	private int Clave_Unica()
	{
		int tickCount = Environment.TickCount;
		Random random = new Random(tickCount);
		int num = random.Next(1, 125678);
		if (cl.RevisarExistencia(num) == "1")
		{
			return Clave_Unica();
		}
		return num;
	}

	private void HabilitarEdicion()
	{
		Delete.Enabled = true;
		cancel.Enabled = true;
		save.Enabled = true;
		add.Enabled = false;
		add.Image = Resources.agregar_simbolo_de_usuario__1_;
		Delete.Image = Resources.eliminar_usuario;
		cancel.Image = Resources.eliminar;
		save.Image = Resources.disquete;
		editar = true;
		txtn.Enabled = true;
		txtmail.Enabled = true;
		txtapell.Enabled = true;
		txtcode.Enabled = true;
		txtphone.Enabled = true;
		cb1.Enabled = true;
		cb2.Enabled = true;
		txtno.Enabled = true;
		txtcol.Enabled = true;
		txtcalle.Enabled = true;
	}

	private void Limpiar()
	{
		txtn.Text = "";
		txtcalle.Text = "Calle";
		txtcol.Text = "Colonia";
		txtno.Text = "# Exterior";
		txtc.Text = "";
		txtmail.Text = "";
		txtapell.Text = "";
		txtphone.Text = "";
		cb1.Checked = false;
		cb2.Checked = false;
		txtcode.Text = "";
	}

	private void add_Click(object sender, EventArgs e)
	{
		Habilitar();
		Limpiar();
		txtc.Text = Clave_Unica().ToString();
	}

	private void UPDATE()
	{
		cl.Nombre = txtn.Text;
		cl.Apellido = txtapell.Text;
		cl.Clave_U = txtc.Text;
		cl.Calle = txtcalle.Text;
		cl.Correo = txtmail.Text;
		cl.Telefono = txtphone.Text;
		cl.No_Ex = txtno.Text;
		cl.Fecha_Nac = dtmp.Value.Day + "/" + dtmp.Value.Month + "/" + dtmp.Value.Year;
		cl.Colonia = txtcol.Text;
		if (cb1.Checked)
		{
			cl.Credito = "1";
		}
		else
		{
			cl.Credito = "0";
		}
		if (cb2.Checked)
		{
			cl.Mayorista = "1";
		}
		else
		{
			cl.Mayorista = "0";
		}
		if (cl.UPDATE() == 1)
		{
			MessageBox.Show("Cliente Actualizado con exito");
			Limpiar();
			Disabled();
		}
		else if (cl.UPDATE() == 0)
		{
			MessageBox.Show("Error");
		}
	}

	private void Guardar()
	{
		if (!(txtno.Text == ""))
		{
			cl.Nombre = txtn.Text;
			cl.Apellido = txtapell.Text;
			cl.Clave_U = txtc.Text;
			cl.Calle = txtcalle.Text;
			cl.Correo = txtmail.Text;
			cl.Telefono = txtphone.Text;
			cl.No_Ex = txtno.Text;
			cl.Fecha_Nac = dtmp.Value.Day + "/" + dtmp.Value.Month + "/" + dtmp.Value.Year;
			cl.Colonia = txtcol.Text;
			if (cb1.Checked)
			{
				cl.Credito = "1";
			}
			else
			{
				cl.Credito = "0";
			}
			if (cb2.Checked)
			{
				cl.Mayorista = "1";
			}
			else
			{
				cl.Mayorista = "0";
			}
			if (cl.INSERT() == 1)
			{
				MessageBox.Show("Cliente registrado con exito");
				Limpiar();
				Disabled();
			}
			else if (cl.INSERT() == 2)
			{
				MessageBox.Show("El cliente que intentas registrar ya esta en el sistema");
			}
			else
			{
				MessageBox.Show("Ha ocurrido un error");
			}
		}
	}

	private void cancel_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Deseas cancelar la operacion??", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			Disabled();
			Limpiar();
			editar = false;
		}
	}

	private void save_Click(object sender, EventArgs e)
	{
		if (editar)
		{
			cl.id = txtid.Text;
			UPDATE();
		}
		else
		{
			Guardar();
		}
	}

	private void Delete_Click(object sender, EventArgs e)
	{
		if (txtid.Text != "")
		{
			cl.id = txtid.Text;
			if (cl.DELETE() == 1)
			{
				MessageBox.Show("Clienete eliminado con exito");
				Limpiar();
				Disabled();
			}
			else
			{
				MessageBox.Show("Error al eliminar");
			}
		}
		else
		{
			MessageBox.Show("No puedes Eliminar un cliente sin antes Seleccionarlo");
		}
	}

	private void txtcalle_Enter(object sender, EventArgs e)
	{
		txtcalle.Text = "";
	}

	private void txtcol_Enter(object sender, EventArgs e)
	{
		txtcol.Text = "";
	}

	private void txtno_Enter(object sender, EventArgs e)
	{
		txtno.Text = "";
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		Creditos creditos = new Creditos(txtName.Text, txttipo_e.Text, txtidbox.Text);
		creditos.ShowDialog();
	}

	private void label14_Click(object sender, EventArgs e)
	{
	}

	private void txtphone_TextChanged(object sender, EventArgs e)
	{
		if (!(txtphone.Text == ""))
		{
			try
			{
				long num = Convert.ToInt64(txtphone.Text);
			}
			catch
			{
				MessageBox.Show("Solo se pueden introducir Numeros");
				txtphone.Text = "";
			}
		}
	}

	private void pictureBox5_Click(object sender, EventArgs e)
	{
		Form1 form = new Form1(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
		Hide();
		form.Show();
	}

	private void dgvcl_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (txtcode.Enabled)
		{
			txtn.Text = dgvcl.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
			txtapell.Text = dgvcl.Rows[e.RowIndex].Cells["Apellidos"].Value.ToString();
			txtcalle.Text = dgvcl.Rows[e.RowIndex].Cells["Calle"].Value.ToString();
			txtc.Text = dgvcl.Rows[e.RowIndex].Cells["Clave_U"].Value.ToString();
			txtcol.Text = dgvcl.Rows[e.RowIndex].Cells["Colonia"].Value.ToString();
			txtid.Text = dgvcl.Rows[e.RowIndex].Cells["idCliente"].Value.ToString();
			txtmail.Text = dgvcl.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
			txtphone.Text = dgvcl.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
			txtno.Text = dgvcl.Rows[e.RowIndex].Cells["No_Ex"].Value.ToString();
			dtmp.Text = dgvcl.Rows[e.RowIndex].Cells["Fecha_Nac"].Value.ToString();
			string text = dgvcl.Rows[e.RowIndex].Cells["Credito"].Value.ToString();
			string text2 = dgvcl.Rows[e.RowIndex].Cells["Mayorista"].Value.ToString();
			if (text == "1")
			{
				cb1.Checked = true;
			}
			else
			{
				cb1.Checked = false;
			}
			if (text2 == "1")
			{
				cb2.Checked = true;
			}
			else
			{
				cb2.Checked = false;
			}
			edit.Enabled = true;
			edit.Image = Resources.usuario__1_;
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		cl.Nombre = txtcode.Text;
		dgvcl.DataSource = cl.GETBYID();
		txtcode.Text = "";
	}

	private void edit_Click(object sender, EventArgs e)
	{
		if (txtid.Text != "")
		{
			MessageBox.Show("Edicion Activada");
			editar = true;
			HabilitarEdicion();
		}
		else
		{
			MessageBox.Show("No puedes Editar un cliente sin antes Seleccionarlo");
		}
	}

	private void Cliente_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F6)
		{
			Creditos creditos = new Creditos(txtName.Text, txttipo_e.Text, txtidbox.Text);
			creditos.ShowDialog();
		}
		else if (e.KeyCode == Keys.F1)
		{
			Habilitar();
			Limpiar();
			txtc.Text = Clave_Unica().ToString();
		}
		else if (e.KeyCode == Keys.F2)
		{
			if (txtid.Text != "")
			{
				MessageBox.Show("Edicion Activada");
				editar = true;
				HabilitarEdicion();
			}
			else
			{
				MessageBox.Show("No puedes Editar un cliente sin antes Seleccionarlo");
			}
		}
		else if (e.KeyCode == Keys.F3)
		{
			if (editar)
			{
				cl.id = txtid.Text;
				UPDATE();
			}
			else
			{
				Guardar();
			}
		}
		else if (e.KeyCode == Keys.F4)
		{
			if (txtid.Text != "")
			{
				cl.id = txtid.Text;
				if (cl.DELETE() == 1)
				{
					MessageBox.Show("Clienete eliminado con exito");
					Limpiar();
					Disabled();
				}
				else
				{
					MessageBox.Show("Error al eliminar");
				}
			}
			else
			{
				MessageBox.Show("No puedes Eliminar un cliente sin antes Seleccionarlo");
			}
		}
		else if (e.KeyCode == Keys.F5)
		{
			txtcode.Enabled = true;
			txtcode.Focus();
		}
		else if (e.KeyCode == Keys.F12)
		{
			Form1 form = new Form1(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
			Hide();
			form.Show();
		}
		else if (e.KeyCode == Keys.Escape && MessageBox.Show("Deseas cancelar la operacion??", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			Disabled();
			Limpiar();
			editar = false;
		}
	}

	private void search_Click(object sender, EventArgs e)
	{
		txtcode.Enabled = true;
		txtcode.Focus();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Cliente));
		panel2 = new System.Windows.Forms.Panel();
		txtmoney = new System.Windows.Forms.Label();
		label14 = new System.Windows.Forms.Label();
		txtidbox = new System.Windows.Forms.Label();
		label15 = new System.Windows.Forms.Label();
		search = new System.Windows.Forms.PictureBox();
		Delete = new System.Windows.Forms.PictureBox();
		cancel = new System.Windows.Forms.PictureBox();
		save = new System.Windows.Forms.PictureBox();
		edit = new System.Windows.Forms.PictureBox();
		add = new System.Windows.Forms.PictureBox();
		panel1 = new System.Windows.Forms.Panel();
		txtid = new System.Windows.Forms.Label();
		panel16 = new System.Windows.Forms.Panel();
		txttipo_e = new System.Windows.Forms.Label();
		label19 = new System.Windows.Forms.Label();
		image_user = new System.Windows.Forms.PictureBox();
		label18 = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.Label();
		panel3 = new System.Windows.Forms.Panel();
		txtno = new System.Windows.Forms.TextBox();
		txtcol = new System.Windows.Forms.TextBox();
		label11 = new System.Windows.Forms.Label();
		txtcalle = new System.Windows.Forms.TextBox();
		dtmp = new System.Windows.Forms.DateTimePicker();
		label6 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		txtphone = new System.Windows.Forms.TextBox();
		label4 = new System.Windows.Forms.Label();
		txtmail = new System.Windows.Forms.TextBox();
		txtapell = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		txtn = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		txtc = new System.Windows.Forms.TextBox();
		panel4 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		dgvcl = new System.Windows.Forms.DataGridView();
		txtcode = new System.Windows.Forms.TextBox();
		panel5 = new System.Windows.Forms.Panel();
		label8 = new System.Windows.Forms.Label();
		panel6 = new System.Windows.Forms.Panel();
		cb2 = new System.Windows.Forms.CheckBox();
		cb1 = new System.Windows.Forms.CheckBox();
		panel7 = new System.Windows.Forms.Panel();
		label12 = new System.Windows.Forms.Label();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel8 = new System.Windows.Forms.Panel();
		label7 = new System.Windows.Forms.Label();
		panel9 = new System.Windows.Forms.Panel();
		label9 = new System.Windows.Forms.Label();
		panel10 = new System.Windows.Forms.Panel();
		label10 = new System.Windows.Forms.Label();
		toolTip1 = new System.Windows.Forms.ToolTip(components);
		pictureBox5 = new System.Windows.Forms.PictureBox();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)search).BeginInit();
		((System.ComponentModel.ISupportInitialize)Delete).BeginInit();
		((System.ComponentModel.ISupportInitialize)cancel).BeginInit();
		((System.ComponentModel.ISupportInitialize)save).BeginInit();
		((System.ComponentModel.ISupportInitialize)edit).BeginInit();
		((System.ComponentModel.ISupportInitialize)add).BeginInit();
		panel1.SuspendLayout();
		panel16.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)image_user).BeginInit();
		panel3.SuspendLayout();
		panel4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dgvcl).BeginInit();
		panel5.SuspendLayout();
		panel6.SuspendLayout();
		panel7.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel8.SuspendLayout();
		panel9.SuspendLayout();
		panel10.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
		SuspendLayout();
		panel2.BackColor = System.Drawing.Color.White;
		panel2.Controls.Add(pictureBox5);
		panel2.Controls.Add(txtidbox);
		panel2.Controls.Add(search);
		panel2.Controls.Add(Delete);
		panel2.Controls.Add(cancel);
		panel2.Controls.Add(save);
		panel2.Controls.Add(edit);
		panel2.Controls.Add(add);
		panel2.Dock = System.Windows.Forms.DockStyle.Left;
		panel2.Location = new System.Drawing.Point(0, 0);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(127, 788);
		panel2.TabIndex = 15;
		txtmoney.AutoSize = true;
		txtmoney.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtmoney.Location = new System.Drawing.Point(60, 9);
		txtmoney.Name = "txtmoney";
		txtmoney.Size = new System.Drawing.Size(36, 25);
		txtmoney.TabIndex = 8;
		txtmoney.Text = "0.0";
		label14.AutoSize = true;
		label14.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label14.Location = new System.Drawing.Point(35, 9);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(22, 25);
		label14.TabIndex = 7;
		label14.Text = "$";
		label14.Click += new System.EventHandler(label14_Click);
		txtidbox.AutoSize = true;
		txtidbox.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtidbox.Location = new System.Drawing.Point(3, 9);
		txtidbox.Name = "txtidbox";
		txtidbox.Size = new System.Drawing.Size(0, 25);
		txtidbox.TabIndex = 9;
		txtidbox.Visible = false;
		label15.AutoSize = true;
		label15.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label15.Location = new System.Drawing.Point(7, 34);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(127, 21);
		label15.TabIndex = 6;
		label15.Text = "Cantidad en Caja";
		search.BackColor = System.Drawing.Color.Transparent;
		search.Cursor = System.Windows.Forms.Cursors.Hand;
		search.Image = BLUPOINT.Properties.Resources.buscar;
		search.Location = new System.Drawing.Point(33, 525);
		search.Name = "search";
		search.Size = new System.Drawing.Size(65, 69);
		search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		search.TabIndex = 19;
		search.TabStop = false;
		search.Click += new System.EventHandler(search_Click);
		Delete.BackColor = System.Drawing.Color.Transparent;
		Delete.Cursor = System.Windows.Forms.Cursors.Hand;
		Delete.Image = BLUPOINT.Properties.Resources.eliminar_usuario__1_;
		Delete.Location = new System.Drawing.Point(33, 422);
		Delete.Name = "Delete";
		Delete.Size = new System.Drawing.Size(65, 69);
		Delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		Delete.TabIndex = 18;
		Delete.TabStop = false;
		Delete.Click += new System.EventHandler(Delete_Click);
		cancel.BackColor = System.Drawing.Color.Transparent;
		cancel.Cursor = System.Windows.Forms.Cursors.Hand;
		cancel.Image = BLUPOINT.Properties.Resources.eliminar1;
		cancel.Location = new System.Drawing.Point(33, 629);
		cancel.Name = "cancel";
		cancel.Size = new System.Drawing.Size(65, 69);
		cancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		cancel.TabIndex = 17;
		cancel.TabStop = false;
		cancel.Click += new System.EventHandler(cancel_Click);
		save.BackColor = System.Drawing.Color.Transparent;
		save.Cursor = System.Windows.Forms.Cursors.Hand;
		save.Image = BLUPOINT.Properties.Resources.disquete1;
		save.Location = new System.Drawing.Point(33, 303);
		save.Name = "save";
		save.Size = new System.Drawing.Size(65, 69);
		save.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		save.TabIndex = 16;
		save.TabStop = false;
		save.Click += new System.EventHandler(save_Click);
		edit.BackColor = System.Drawing.Color.Transparent;
		edit.Cursor = System.Windows.Forms.Cursors.Hand;
		edit.Image = BLUPOINT.Properties.Resources.usuario__2_;
		edit.Location = new System.Drawing.Point(33, 185);
		edit.Name = "edit";
		edit.Size = new System.Drawing.Size(65, 69);
		edit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		edit.TabIndex = 7;
		edit.TabStop = false;
		edit.Click += new System.EventHandler(edit_Click);
		add.BackColor = System.Drawing.Color.Transparent;
		add.Cursor = System.Windows.Forms.Cursors.Hand;
		add.Image = BLUPOINT.Properties.Resources.agregar_simbolo_de_usuario1;
		add.Location = new System.Drawing.Point(33, 79);
		add.Name = "add";
		add.Size = new System.Drawing.Size(65, 63);
		add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		add.TabIndex = 6;
		add.TabStop = false;
		add.Click += new System.EventHandler(add_Click);
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(txtmoney);
		panel1.Controls.Add(label14);
		panel1.Controls.Add(txtid);
		panel1.Controls.Add(panel16);
		panel1.Controls.Add(label15);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(127, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(1259, 65);
		panel1.TabIndex = 16;
		txtid.AutoSize = true;
		txtid.ForeColor = System.Drawing.Color.White;
		txtid.Location = new System.Drawing.Point(148, 28);
		txtid.Name = "txtid";
		txtid.Size = new System.Drawing.Size(41, 13);
		txtid.TabIndex = 2;
		txtid.Text = "label11";
		panel16.Controls.Add(txttipo_e);
		panel16.Controls.Add(label19);
		panel16.Controls.Add(image_user);
		panel16.Controls.Add(label18);
		panel16.Controls.Add(txtName);
		panel16.Dock = System.Windows.Forms.DockStyle.Right;
		panel16.Location = new System.Drawing.Point(948, 0);
		panel16.Name = "panel16";
		panel16.Size = new System.Drawing.Size(311, 65);
		panel16.TabIndex = 1;
		txttipo_e.AutoSize = true;
		txttipo_e.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttipo_e.Location = new System.Drawing.Point(176, 44);
		txttipo_e.Name = "txttipo_e";
		txttipo_e.Size = new System.Drawing.Size(52, 18);
		txttipo_e.TabIndex = 28;
		txttipo_e.Text = "Cajero";
		label19.AutoSize = true;
		label19.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
		label19.Location = new System.Drawing.Point(207, 28);
		label19.Name = "label19";
		label19.Size = new System.Drawing.Size(37, 13);
		label19.TabIndex = 27;
		label19.Text = "Activo";
		image_user.Image = (System.Drawing.Image)resources.GetObject("image_user.Image");
		image_user.Location = new System.Drawing.Point(257, 0);
		image_user.Name = "image_user";
		image_user.Size = new System.Drawing.Size(54, 62);
		image_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		image_user.TabIndex = 24;
		image_user.TabStop = false;
		label18.AutoSize = true;
		label18.ForeColor = System.Drawing.SystemColors.AppWorkspace;
		label18.Location = new System.Drawing.Point(171, 28);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(37, 13);
		label18.TabIndex = 26;
		label18.Text = "Status";
		txtName.AutoSize = true;
		txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtName.Location = new System.Drawing.Point(4, 0);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(197, 24);
		txtName.TabIndex = 25;
		txtName.Text = "Jorge Lemus Stripsent";
		panel3.BackColor = System.Drawing.Color.White;
		panel3.Controls.Add(txtno);
		panel3.Controls.Add(txtcol);
		panel3.Controls.Add(label11);
		panel3.Controls.Add(txtcalle);
		panel3.Controls.Add(dtmp);
		panel3.Controls.Add(label6);
		panel3.Controls.Add(label5);
		panel3.Controls.Add(txtphone);
		panel3.Controls.Add(label4);
		panel3.Controls.Add(txtmail);
		panel3.Controls.Add(txtapell);
		panel3.Controls.Add(label3);
		panel3.Controls.Add(txtn);
		panel3.Controls.Add(label2);
		panel3.Controls.Add(label1);
		panel3.Controls.Add(txtc);
		panel3.Location = new System.Drawing.Point(585, 109);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(531, 638);
		panel3.TabIndex = 17;
		txtno.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtno.Location = new System.Drawing.Point(399, 520);
		txtno.Name = "txtno";
		txtno.Size = new System.Drawing.Size(113, 31);
		txtno.TabIndex = 15;
		txtno.Text = "# Exterior";
		txtno.Enter += new System.EventHandler(txtno_Enter);
		txtcol.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtcol.Location = new System.Drawing.Point(281, 520);
		txtcol.Name = "txtcol";
		txtcol.Size = new System.Drawing.Size(112, 31);
		txtcol.TabIndex = 14;
		txtcol.Text = "Colonia";
		txtcol.Enter += new System.EventHandler(txtcol_Enter);
		label11.AutoSize = true;
		label11.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label11.Location = new System.Drawing.Point(44, 521);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(100, 30);
		label11.TabIndex = 13;
		label11.Text = "Domicilio";
		txtcalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtcalle.Location = new System.Drawing.Point(166, 520);
		txtcalle.Name = "txtcalle";
		txtcalle.Size = new System.Drawing.Size(109, 31);
		txtcalle.TabIndex = 12;
		txtcalle.Text = "Calle";
		txtcalle.Enter += new System.EventHandler(txtcalle_Enter);
		dtmp.Enabled = false;
		dtmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dtmp.Location = new System.Drawing.Point(230, 442);
		dtmp.Name = "dtmp";
		dtmp.Size = new System.Drawing.Size(266, 31);
		dtmp.TabIndex = 11;
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label6.Location = new System.Drawing.Point(44, 442);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(180, 30);
		label6.TabIndex = 10;
		label6.Text = "Fecha de creacion";
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.Location = new System.Drawing.Point(44, 361);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(92, 30);
		label5.TabIndex = 9;
		label5.Text = "Telefono";
		txtphone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtphone.Location = new System.Drawing.Point(180, 360);
		txtphone.MaxLength = 11;
		txtphone.Name = "txtphone";
		txtphone.Size = new System.Drawing.Size(316, 31);
		txtphone.TabIndex = 8;
		txtphone.TextChanged += new System.EventHandler(txtphone_TextChanged);
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(44, 284);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(75, 30);
		label4.TabIndex = 7;
		label4.Text = "Correo";
		txtmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtmail.Location = new System.Drawing.Point(180, 283);
		txtmail.Name = "txtmail";
		txtmail.Size = new System.Drawing.Size(316, 31);
		txtmail.TabIndex = 6;
		txtapell.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtapell.Location = new System.Drawing.Point(180, 206);
		txtapell.Name = "txtapell";
		txtapell.Size = new System.Drawing.Size(316, 31);
		txtapell.TabIndex = 5;
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(44, 207);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(110, 30);
		label3.TabIndex = 4;
		label3.Text = "Apellido(s)";
		txtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtn.Location = new System.Drawing.Point(180, 130);
		txtn.Name = "txtn";
		txtn.Size = new System.Drawing.Size(316, 31);
		txtn.TabIndex = 3;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(44, 131);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(110, 30);
		label2.TabIndex = 2;
		label2.Text = "Nombre(s)";
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(44, 60);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(138, 30);
		label1.TabIndex = 1;
		label1.Text = "Codigo_Clave";
		txtc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtc.Location = new System.Drawing.Point(188, 61);
		txtc.Name = "txtc";
		txtc.Size = new System.Drawing.Size(308, 31);
		txtc.TabIndex = 0;
		toolTip1.SetToolTip(txtc, "Este campo se genera automaticamente y no puede ser editado");
		panel4.BackColor = System.Drawing.Color.White;
		panel4.Controls.Add(button1);
		panel4.Controls.Add(dgvcl);
		panel4.Controls.Add(txtcode);
		panel4.Location = new System.Drawing.Point(151, 109);
		panel4.Name = "panel4";
		panel4.Size = new System.Drawing.Size(396, 638);
		panel4.TabIndex = 18;
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(127, 76);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(157, 49);
		button1.TabIndex = 2;
		button1.Text = "Buscar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		dgvcl.BackgroundColor = System.Drawing.Color.White;
		dgvcl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgvcl.Location = new System.Drawing.Point(0, 131);
		dgvcl.Name = "dgvcl";
		dgvcl.Size = new System.Drawing.Size(396, 534);
		dgvcl.TabIndex = 1;
		dgvcl.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgvcl_CellClick);
		txtcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtcode.Location = new System.Drawing.Point(62, 32);
		txtcode.Name = "txtcode";
		txtcode.Size = new System.Drawing.Size(272, 31);
		txtcode.TabIndex = 0;
		txtcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtcode_KeyPress);
		panel5.BackColor = System.Drawing.Color.SteelBlue;
		panel5.Controls.Add(label8);
		panel5.Location = new System.Drawing.Point(151, 71);
		panel5.Name = "panel5";
		panel5.Size = new System.Drawing.Size(396, 41);
		panel5.TabIndex = 19;
		label8.AutoSize = true;
		label8.Font = new System.Drawing.Font("Impact", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label8.ForeColor = System.Drawing.Color.White;
		label8.Location = new System.Drawing.Point(98, 8);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(166, 29);
		label8.TabIndex = 1;
		label8.Text = "BUSCAR CLIENTE";
		panel6.BackColor = System.Drawing.Color.White;
		panel6.Controls.Add(cb2);
		panel6.Controls.Add(cb1);
		panel6.Location = new System.Drawing.Point(1122, 109);
		panel6.Name = "panel6";
		panel6.Size = new System.Drawing.Size(257, 298);
		panel6.TabIndex = 20;
		cb2.AutoSize = true;
		cb2.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		cb2.Location = new System.Drawing.Point(19, 127);
		cb2.Name = "cb2";
		cb2.Size = new System.Drawing.Size(233, 34);
		cb2.TabIndex = 1;
		cb2.Text = "Comprador Mayorista";
		cb2.UseVisualStyleBackColor = true;
		cb1.AutoSize = true;
		cb1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		cb1.Location = new System.Drawing.Point(19, 46);
		cb1.Name = "cb1";
		cb1.Size = new System.Drawing.Size(200, 34);
		cb1.TabIndex = 0;
		cb1.Text = "Derecho a Credito";
		cb1.UseVisualStyleBackColor = true;
		panel7.BackColor = System.Drawing.Color.White;
		panel7.Controls.Add(label12);
		panel7.Controls.Add(pictureBox1);
		panel7.Location = new System.Drawing.Point(1122, 459);
		panel7.Name = "panel7";
		panel7.Size = new System.Drawing.Size(257, 288);
		panel7.TabIndex = 21;
		label12.AutoSize = true;
		label12.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label12.Location = new System.Drawing.Point(79, 125);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(102, 21);
		label12.TabIndex = 1;
		label12.Text = "Adeudos (F6)";
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox1.Image = BLUPOINT.Properties.Resources.dinero2;
		pictureBox1.Location = new System.Drawing.Point(76, 21);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(105, 101);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 0;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		panel8.BackColor = System.Drawing.Color.SteelBlue;
		panel8.Controls.Add(label7);
		panel8.Location = new System.Drawing.Point(585, 71);
		panel8.Name = "panel8";
		panel8.Size = new System.Drawing.Size(531, 41);
		panel8.TabIndex = 20;
		label7.AutoSize = true;
		label7.Font = new System.Drawing.Font("Impact", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label7.ForeColor = System.Drawing.Color.White;
		label7.Location = new System.Drawing.Point(213, 8);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(186, 29);
		label7.TabIndex = 0;
		label7.Text = "DATOS DEL CLIENTE";
		panel9.BackColor = System.Drawing.Color.SteelBlue;
		panel9.Controls.Add(label9);
		panel9.Location = new System.Drawing.Point(1122, 71);
		panel9.Name = "panel9";
		panel9.Size = new System.Drawing.Size(257, 41);
		panel9.TabIndex = 21;
		label9.AutoSize = true;
		label9.Font = new System.Drawing.Font("Impact", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label9.ForeColor = System.Drawing.Color.White;
		label9.Location = new System.Drawing.Point(45, 6);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(168, 29);
		label9.TabIndex = 1;
		label9.Text = "OPCIONES EXTRA";
		panel10.BackColor = System.Drawing.Color.SteelBlue;
		panel10.Controls.Add(label10);
		panel10.Location = new System.Drawing.Point(1122, 421);
		panel10.Name = "panel10";
		panel10.Size = new System.Drawing.Size(257, 41);
		panel10.TabIndex = 22;
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Impact", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label10.ForeColor = System.Drawing.Color.White;
		label10.Location = new System.Drawing.Point(45, 6);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(155, 29);
		label10.TabIndex = 1;
		label10.Text = "HERRAMIENTAS";
		pictureBox5.BackColor = System.Drawing.Color.Transparent;
		pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox5.Image = BLUPOINT.Properties.Resources.atras;
		pictureBox5.Location = new System.Drawing.Point(0, 3);
		pictureBox5.Name = "pictureBox5";
		pictureBox5.Size = new System.Drawing.Size(35, 35);
		pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox5.TabIndex = 22;
		pictureBox5.TabStop = false;
		toolTip1.SetToolTip(pictureBox5, "Añadir (F1)");
		pictureBox5.Click += new System.EventHandler(pictureBox5_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1386, 788);
		base.Controls.Add(panel10);
		base.Controls.Add(panel9);
		base.Controls.Add(panel8);
		base.Controls.Add(panel7);
		base.Controls.Add(panel6);
		base.Controls.Add(panel5);
		base.Controls.Add(panel4);
		base.Controls.Add(panel3);
		base.Controls.Add(panel1);
		base.Controls.Add(panel2);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "Cliente";
		Text = "Cliente";
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Cliente_KeyUp);
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)search).EndInit();
		((System.ComponentModel.ISupportInitialize)Delete).EndInit();
		((System.ComponentModel.ISupportInitialize)cancel).EndInit();
		((System.ComponentModel.ISupportInitialize)save).EndInit();
		((System.ComponentModel.ISupportInitialize)edit).EndInit();
		((System.ComponentModel.ISupportInitialize)add).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		panel16.ResumeLayout(false);
		panel16.PerformLayout();
		((System.ComponentModel.ISupportInitialize)image_user).EndInit();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		panel4.ResumeLayout(false);
		panel4.PerformLayout();
		((System.ComponentModel.ISupportInitialize)dgvcl).EndInit();
		panel5.ResumeLayout(false);
		panel5.PerformLayout();
		panel6.ResumeLayout(false);
		panel6.PerformLayout();
		panel7.ResumeLayout(false);
		panel7.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel8.ResumeLayout(false);
		panel8.PerformLayout();
		panel9.ResumeLayout(false);
		panel9.PerformLayout();
		panel10.ResumeLayout(false);
		panel10.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
		ResumeLayout(false);
	}
}

// BLUPOINT.Codigo_Barras_Prod
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BarcodeLib;

public class Codigo_Barras_Prod : Form
{
	private bool pregunta;

	private IContainer components = null;

	private Panel pnlresult;

	private TextBox txtname;

	private Button button1;

	private PrintDocument printDocument1;

	private CheckBox checkBox1;

	public Codigo_Barras_Prod()
	{
		InitializeComponent();
		pregunta = false;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			Barcode barcode = new Barcode();
			barcode.IncludeLabel = true;
			pnlresult.BackgroundImage = barcode.Encode(TYPE.CODE128, txtname.Text, Color.Black, Color.White, 200, 100);
			if (!pregunta)
			{
				if (MessageBox.Show("Deseas Imprimir la etiqueta??", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Print();
				}
			}
			else
			{
				Print();
			}
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

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox1.Checked)
		{
			pregunta = true;
		}
		else
		{
			pregunta = false;
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
		pnlresult = new System.Windows.Forms.Panel();
		txtname = new System.Windows.Forms.TextBox();
		button1 = new System.Windows.Forms.Button();
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		checkBox1 = new System.Windows.Forms.CheckBox();
		SuspendLayout();
		pnlresult.BackColor = System.Drawing.Color.White;
		pnlresult.Location = new System.Drawing.Point(82, 36);
		pnlresult.Name = "pnlresult";
		pnlresult.Size = new System.Drawing.Size(200, 100);
		pnlresult.TabIndex = 0;
		txtname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtname.Location = new System.Drawing.Point(22, 142);
		txtname.Name = "txtname";
		txtname.Size = new System.Drawing.Size(293, 31);
		txtname.TabIndex = 1;
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(109, 179);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(124, 51);
		button1.TabIndex = 2;
		button1.Text = "Generar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		checkBox1.AutoSize = true;
		checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		checkBox1.Location = new System.Drawing.Point(2, 4);
		checkBox1.Name = "checkBox1";
		checkBox1.Size = new System.Drawing.Size(147, 24);
		checkBox1.TabIndex = 3;
		checkBox1.Text = "Siempre Imprimir";
		checkBox1.UseVisualStyleBackColor = true;
		checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(345, 225);
		base.Controls.Add(checkBox1);
		base.Controls.Add(button1);
		base.Controls.Add(txtname);
		base.Controls.Add(pnlresult);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Codigo_Barras_Prod";
		Text = "Codigo_Barras_Prod";
		ResumeLayout(false);
		PerformLayout();
	}
}

// BLUPOINT.Complete
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;

public class Complete : Form
{
	private string tipos;

	private IContainer components = null;

	private PictureBox pictureBox1;

	private Label label1;

	private Button button1;

	private Label label2;

	public Complete(string tipo)
	{
		InitializeComponent();
		tipos = tipo;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		if (tipos == "1")
		{
			Login login = new Login();
			Hide();
			login.Show();
		}
		else
		{
			Login_2 login_ = new Login_2();
			Hide();
			login_.Show();
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
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label1 = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		label2 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		pictureBox1.Image = BLUPOINT.Properties.Resources._240_F_303721767_iNO49Cr0bPrcZT9eIuTr0VUa5QXuK1es;
		pictureBox1.Location = new System.Drawing.Point(255, 12);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(237, 230);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 0;
		pictureBox1.TabStop = false;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 36f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
		label1.Location = new System.Drawing.Point(207, 206);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(333, 65);
		label1.TabIndex = 1;
		label1.Text = "COMPLETADO";
		button1.BackColor = System.Drawing.Color.Navy;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(271, 363);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(171, 43);
		button1.TabIndex = 11;
		button1.Text = "Continuar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.ForeColor = System.Drawing.Color.Black;
		label2.Location = new System.Drawing.Point(59, 339);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(647, 21);
		label2.TabIndex = 12;
		label2.Text = "Se ha completado la configuracion del sistema. Da click en continuar para acceder al sistema";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(745, 418);
		base.Controls.Add(label2);
		base.Controls.Add(button1);
		base.Controls.Add(label1);
		base.Controls.Add(pictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "Complete";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Complete";
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}

// BLUPOINT.Corte_Caja
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Corte_Caja : Form
{
	private Caja cj = new Caja();

	private string ids;

	private IContainer components = null;

	private Panel panel1;

	private Panel panel2;

	private PictureBox pictureBox1;

	private Button button1;

	private Label txttotalcaja;

	private Label label19;

	private Label label18;

	private Label label17;

	private TextBox txttotal2;

	private TextBox txttdc;

	private TextBox txttdt;

	private TextBox txttde;

	private Label label16;

	private TextBox txttotal1;

	private TextBox txttc;

	private TextBox txttt;

	private TextBox txtte;

	private Label label15;

	private TextBox txttotal;

	private Label label14;

	private TextBox txtcc;

	private Label label13;

	private TextBox txtct;

	private Label label12;

	private Label label11;

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

	public TextBox txtce;

	private PictureBox pictureBox2;

	private DateTimePicker dtm;

	private ToolTip toolTip1;

	private Label label4;

	private Panel panel3;

	private PictureBox pictureBox3;

	public TextBox txtRetBox;

	private Label label5;

	private PrintDocument printDocument1;

	private Label label6;

	private PictureBox pictureBox4;

	public Corte_Caja(string nombre, string tipo)
	{
		InitializeComponent();
		LoadMoney();
		Inicio();
		base.KeyPreview = true;
		base.KeyDown += Corte_Caja_KeyUp;
		txttipo_e.Text = tipo;
		txtname.Text = nombre;
		txtfecha.Text = cj.GETBoxid();
	}

	private void Inicio()
	{
		cj.id_caja = ids;
		cj.Fecha = dtm.Value.Day + "/" + dtm.Value.Month + "/" + dtm.Value.Year;
		if (cj.GETType("Tarjeta") == "")
		{
			txtct.Text = "0.0";
		}
		else
		{
			txtct.Text = cj.GETType("Tarjeta");
		}
		if (cj.GETType("Credito") == "")
		{
			txtcc.Text = "0.0";
		}
		else
		{
			txtcc.Text = cj.GETType("Credito");
		}
		suma();
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		Dinero dinero = new Dinero("Corte_Caja");
		AddOwnedForm(dinero);
		dinero.ShowDialog();
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
				txttde.ForeColor = Color.Green;
				return;
			}
			double num = Convert.ToDouble(txtce.Text);
			double num2 = Convert.ToDouble(txtte.Text);
			txttde.Text = (num - num2).ToString();
			if (num < num2)
			{
				txttde.ForeColor = Color.Red;
			}
			else
			{
				txttde.ForeColor = Color.Green;
			}
		}
		catch
		{
			MessageBox.Show("Solo se pueden introducir numeros");
			txtce.Text = "";
		}
	}

	private void suma()
	{
		try
		{
			double num = Convert.ToDouble(txtce.Text);
			double num2 = Convert.ToDouble(txtct.Text);
			double num3 = Convert.ToDouble(txtcc.Text);
			txttotal.Text = (num + num2 + num3).ToString();
		}
		catch
		{
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

	private void txttde_Enter(object sender, EventArgs e)
	{
		MessageBox.Show("No puedes editar este Campo");
		txtce.Focus();
	}

	private void txttde_Click(object sender, EventArgs e)
	{
		MessageBox.Show("No puedes editar este Campo");
		txtce.Focus();
	}

	private void pictureBox2_Click(object sender, EventArgs e)
	{
		Selected_forms selected_forms = new Selected_forms(txtname.Text, txttipo_e.Text, ids);
		selected_forms.ShowDialog();
	}

	private void Corte_Caja_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F5)
		{
			Selected_forms selected_forms = new Selected_forms(txtname.Text, txttipo_e.Text, ids);
			selected_forms.ShowDialog();
		}
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
					if (MessageBox.Show("Corte de Caja realizado, Deseas Imprimir el ticket??", "Imprimir ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Print();
					}
					LoadMoney();
					Inicio();
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
				Inicio();
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

	private void pictureBox3_Click(object sender, EventArgs e)
	{
		Dinero dinero = new Dinero("Retiro_Caja");
		AddOwnedForm(dinero);
		dinero.ShowDialog();
	}

	private void txtRetBox_Click(object sender, EventArgs e)
	{
		txtRetBox.Select();
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
		e.Graphics.DrawString("Diferencia: \t\t$" + txttde.Text, font5, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("Retiro de Caja:\t\t$" + txtRetBox.Text, font, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("Total Actual en Caja:\t$" + num3, font5, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("Corte por:  " + txtname.Text, font3, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("Fecha de Corte: " + dtm.Value.Day + "/" + dtm.Value.Month + "/" + dtm.Value.Year + " " + dtm.Value.Hour + ":" + dtm.Value.Minute + ":" + dtm.Value.Second, font3, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num5 += 20, num4, 20f));
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
					Inicio();
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
				Inicio();
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

	private void pictureBox4_Click(object sender, EventArgs e)
	{
		Corte_Caja_Visualizar corte_Caja_Visualizar = new Corte_Caja_Visualizar();
		corte_Caja_Visualizar.Show();
	}

	private void txtce_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			txtRetBox.Select();
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
		components = new System.ComponentModel.Container();
		panel1 = new System.Windows.Forms.Panel();
		panel2 = new System.Windows.Forms.Panel();
		panel3 = new System.Windows.Forms.Panel();
		label6 = new System.Windows.Forms.Label();
		pictureBox4 = new System.Windows.Forms.PictureBox();
		pictureBox3 = new System.Windows.Forms.PictureBox();
		label4 = new System.Windows.Forms.Label();
		txtRetBox = new System.Windows.Forms.TextBox();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		label5 = new System.Windows.Forms.Label();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		button1 = new System.Windows.Forms.Button();
		txttotalcaja = new System.Windows.Forms.Label();
		label19 = new System.Windows.Forms.Label();
		label18 = new System.Windows.Forms.Label();
		label17 = new System.Windows.Forms.Label();
		txttotal2 = new System.Windows.Forms.TextBox();
		txttdc = new System.Windows.Forms.TextBox();
		txttdt = new System.Windows.Forms.TextBox();
		txttde = new System.Windows.Forms.TextBox();
		label16 = new System.Windows.Forms.Label();
		txttotal1 = new System.Windows.Forms.TextBox();
		txttc = new System.Windows.Forms.TextBox();
		txttt = new System.Windows.Forms.TextBox();
		txtte = new System.Windows.Forms.TextBox();
		label15 = new System.Windows.Forms.Label();
		txttotal = new System.Windows.Forms.TextBox();
		label14 = new System.Windows.Forms.Label();
		txtcc = new System.Windows.Forms.TextBox();
		label13 = new System.Windows.Forms.Label();
		txtct = new System.Windows.Forms.TextBox();
		label12 = new System.Windows.Forms.Label();
		txtce = new System.Windows.Forms.TextBox();
		label11 = new System.Windows.Forms.Label();
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
		dtm = new System.Windows.Forms.DateTimePicker();
		toolTip1 = new System.Windows.Forms.ToolTip(components);
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		panel1.SuspendLayout();
		panel2.SuspendLayout();
		panel3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		groupBox2.SuspendLayout();
		groupBox1.SuspendLayout();
		SuspendLayout();
		panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel1.Controls.Add(panel2);
		panel1.Controls.Add(groupBox2);
		panel1.Controls.Add(groupBox1);
		panel1.Location = new System.Drawing.Point(21, 12);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(994, 454);
		panel1.TabIndex = 0;
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Controls.Add(panel3);
		panel2.Controls.Add(pictureBox1);
		panel2.Controls.Add(button1);
		panel2.Controls.Add(txttotalcaja);
		panel2.Controls.Add(label19);
		panel2.Controls.Add(label18);
		panel2.Controls.Add(label17);
		panel2.Controls.Add(txttotal2);
		panel2.Controls.Add(txttdc);
		panel2.Controls.Add(txttdt);
		panel2.Controls.Add(txttde);
		panel2.Controls.Add(label16);
		panel2.Controls.Add(txttotal1);
		panel2.Controls.Add(txttc);
		panel2.Controls.Add(txttt);
		panel2.Controls.Add(txtte);
		panel2.Controls.Add(label15);
		panel2.Controls.Add(txttotal);
		panel2.Controls.Add(label14);
		panel2.Controls.Add(txtcc);
		panel2.Controls.Add(label13);
		panel2.Controls.Add(txtct);
		panel2.Controls.Add(label12);
		panel2.Controls.Add(txtce);
		panel2.Controls.Add(label11);
		panel2.Location = new System.Drawing.Point(15, 175);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(951, 265);
		panel2.TabIndex = 7;
		panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel3.Controls.Add(label6);
		panel3.Controls.Add(pictureBox4);
		panel3.Controls.Add(pictureBox3);
		panel3.Controls.Add(label4);
		panel3.Controls.Add(txtRetBox);
		panel3.Controls.Add(pictureBox2);
		panel3.Controls.Add(label5);
		panel3.Location = new System.Drawing.Point(568, 19);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(168, 241);
		panel3.TabIndex = 26;
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label6.Location = new System.Drawing.Point(30, 174);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(113, 13);
		label6.TabIndex = 32;
		label6.Text = "Visualizar Cortes (F6)";
		pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox4.Image = BLUPOINT.Properties.Resources.ver;
		pictureBox4.Location = new System.Drawing.Point(62, 190);
		pictureBox4.Name = "pictureBox4";
		pictureBox4.Size = new System.Drawing.Size(45, 46);
		pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox4.TabIndex = 31;
		pictureBox4.TabStop = false;
		toolTip1.SetToolTip(pictureBox4, "Ver entradas y Salidas de Dinero (F5)");
		pictureBox4.Click += new System.EventHandler(pictureBox4_Click);
		pictureBox3.Image = BLUPOINT.Properties.Resources.calculadora;
		pictureBox3.Location = new System.Drawing.Point(16, 46);
		pictureBox3.Name = "pictureBox3";
		pictureBox3.Size = new System.Drawing.Size(19, 24);
		pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox3.TabIndex = 30;
		pictureBox3.TabStop = false;
		pictureBox3.Click += new System.EventHandler(pictureBox3_Click);
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(23, 97);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(120, 13);
		label4.TabIndex = 25;
		label4.Text = "Entradas y Salidas (F5)";
		txtRetBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtRetBox.Location = new System.Drawing.Point(38, 46);
		txtRetBox.Name = "txtRetBox";
		txtRetBox.Size = new System.Drawing.Size(116, 26);
		txtRetBox.TabIndex = 28;
		txtRetBox.Text = "0.0";
		txtRetBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		txtRetBox.Click += new System.EventHandler(txtRetBox_Click);
		txtRetBox.TextChanged += new System.EventHandler(txtRetBox_TextChanged);
		txtRetBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtRetBox_KeyPress);
		pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox2.Image = BLUPOINT.Properties.Resources.ganar_dinero;
		pictureBox2.Location = new System.Drawing.Point(62, 113);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(45, 46);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 24;
		pictureBox2.TabStop = false;
		toolTip1.SetToolTip(pictureBox2, "Ver entradas y Salidas de Dinero (F5)");
		pictureBox2.Click += new System.EventHandler(pictureBox2_Click);
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.Location = new System.Drawing.Point(38, 18);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(112, 21);
		label5.TabIndex = 29;
		label5.Text = "Retirar de Caja";
		pictureBox1.Image = BLUPOINT.Properties.Resources.calculadora;
		pictureBox1.Location = new System.Drawing.Point(81, 43);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(19, 24);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 23;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
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
		label17.AutoSize = true;
		label17.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label17.Location = new System.Drawing.Point(432, 16);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(80, 21);
		label17.TabIndex = 18;
		label17.Text = "Diferencia";
		txttotal2.Enabled = false;
		txttotal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttotal2.Location = new System.Drawing.Point(405, 209);
		txttotal2.Name = "txttotal2";
		txttotal2.Size = new System.Drawing.Size(123, 26);
		txttotal2.TabIndex = 17;
		txttotal2.Text = "0.0";
		txttotal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		txttdc.Enabled = false;
		txttdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttdc.Location = new System.Drawing.Point(405, 158);
		txttdc.Name = "txttdc";
		txttdc.Size = new System.Drawing.Size(123, 26);
		txttdc.TabIndex = 16;
		txttdc.Text = "0.0";
		txttdc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		txttdt.Enabled = false;
		txttdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttdt.Location = new System.Drawing.Point(405, 100);
		txttdt.Name = "txttdt";
		txttdt.Size = new System.Drawing.Size(123, 26);
		txttdt.TabIndex = 15;
		txttdt.Text = "0.0";
		txttdt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		txttde.Enabled = false;
		txttde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttde.Location = new System.Drawing.Point(405, 43);
		txttde.Name = "txttde";
		txttde.Size = new System.Drawing.Size(123, 26);
		txttde.TabIndex = 14;
		txttde.Text = "0.0";
		txttde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		txttde.Click += new System.EventHandler(txttde_Click);
		txttde.Enter += new System.EventHandler(txttde_Enter);
		label16.AutoSize = true;
		label16.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label16.Location = new System.Drawing.Point(261, 16);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(114, 21);
		label16.TabIndex = 13;
		label16.Text = "Total Calculado";
		txttotal1.Enabled = false;
		txttotal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttotal1.Location = new System.Drawing.Point(252, 209);
		txttotal1.Name = "txttotal1";
		txttotal1.Size = new System.Drawing.Size(123, 26);
		txttotal1.TabIndex = 12;
		txttotal1.Text = "0.0";
		txttotal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		txttc.Enabled = false;
		txttc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttc.Location = new System.Drawing.Point(252, 158);
		txttc.Name = "txttc";
		txttc.Size = new System.Drawing.Size(123, 26);
		txttc.TabIndex = 11;
		txttc.Text = "0.0";
		txttc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		txttt.Enabled = false;
		txttt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttt.Location = new System.Drawing.Point(252, 100);
		txttt.Name = "txttt";
		txttt.Size = new System.Drawing.Size(123, 26);
		txttt.TabIndex = 10;
		txttt.Text = "0.0";
		txttt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		txtte.Enabled = false;
		txtte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtte.Location = new System.Drawing.Point(252, 43);
		txtte.Name = "txtte";
		txtte.Size = new System.Drawing.Size(123, 26);
		txtte.TabIndex = 9;
		txtte.Text = "0.0";
		txtte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		label15.AutoSize = true;
		label15.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label15.Location = new System.Drawing.Point(123, 16);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(56, 21);
		label15.TabIndex = 8;
		label15.Text = "Monto";
		txttotal.Enabled = false;
		txttotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttotal.Location = new System.Drawing.Point(103, 209);
		txttotal.Name = "txttotal";
		txttotal.Size = new System.Drawing.Size(116, 26);
		txttotal.TabIndex = 7;
		txttotal.Text = "0.0";
		txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		label14.AutoSize = true;
		label14.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label14.Location = new System.Drawing.Point(18, 211);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(42, 21);
		label14.TabIndex = 6;
		label14.Text = "Total";
		txtcc.Enabled = false;
		txtcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtcc.Location = new System.Drawing.Point(103, 158);
		txtcc.Name = "txtcc";
		txtcc.Size = new System.Drawing.Size(116, 26);
		txtcc.TabIndex = 5;
		txtcc.Text = "0.0";
		txtcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		label13.AutoSize = true;
		label13.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label13.Location = new System.Drawing.Point(18, 158);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(61, 21);
		label13.TabIndex = 4;
		label13.Text = "Credito";
		txtct.Enabled = false;
		txtct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtct.Location = new System.Drawing.Point(103, 100);
		txtct.Name = "txtct";
		txtct.Size = new System.Drawing.Size(116, 26);
		txtct.TabIndex = 3;
		txtct.Text = "0.0";
		txtct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		label12.AutoSize = true;
		label12.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label12.Location = new System.Drawing.Point(18, 100);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(56, 21);
		label12.TabIndex = 2;
		label12.Text = "Trajeta";
		txtce.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtce.Location = new System.Drawing.Point(103, 43);
		txtce.Name = "txtce";
		txtce.Size = new System.Drawing.Size(116, 26);
		txtce.TabIndex = 1;
		txtce.Text = "0.0";
		txtce.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		txtce.TextChanged += new System.EventHandler(txtce_TextChanged);
		txtce.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtce_KeyPress);
		label11.AutoSize = true;
		label11.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label11.Location = new System.Drawing.Point(18, 45);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(64, 21);
		label11.TabIndex = 0;
		label11.Text = "Efectivo";
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
		txtbox.Text = "Caja 1";
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
		dtm.Location = new System.Drawing.Point(719, 477);
		dtm.Name = "dtm";
		dtm.Size = new System.Drawing.Size(200, 20);
		dtm.TabIndex = 1;
		dtm.Visible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(992, 492);
		base.Controls.Add(dtm);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Corte_Caja";
		Text = "Corte_Caja";
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Corte_Caja_KeyUp);
		panel1.ResumeLayout(false);
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		groupBox2.ResumeLayout(false);
		groupBox2.PerformLayout();
		groupBox1.ResumeLayout(false);
		groupBox1.PerformLayout();
		ResumeLayout(false);
	}
}

// BLUPOINT.Corte_Caja_Visualizar
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Corte_Caja_Visualizar : Form
{
	private Caja box = new Caja();

	private string id = "";

	private IContainer components = null;

	private Panel panel1;

	private PictureBox pictureBox2;

	private PictureBox pictureBox1;

	private Label lblfecha;

	private DateTimePicker dateTimePicker1;

	private DataGridView dataGridView1;

	private PrintDocument printDocument1;

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		dateTimePicker1.Visible = true;
		lblfecha.Visible = true;
	}

	public Corte_Caja_Visualizar()
	{
		InitializeComponent();
		dateTimePicker1.Visible = false;
		lblfecha.Visible = false;
		LoadMoney();
		box.id_caja = id;
		dataGridView1.DataSource = box.GetOpenBox();
	}

	private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\r')
		{
			return;
		}
		try
		{
			box.id_caja = id;
			if (dateTimePicker1.Value.Day.ToString().Length >= 2)
			{
				box.Fecha = dateTimePicker1.Value.Day + "/" + Selectdate(dateTimePicker1.Value.Month.ToString()) + "/" + dateTimePicker1.Value.Year;
			}
			else
			{
				box.Fecha = "0" + dateTimePicker1.Value.Day + "/" + Selectdate(dateTimePicker1.Value.Month.ToString()) + "/" + dateTimePicker1.Value.Year;
			}
			dataGridView1.DataSource = box.GETFilterOpenBox();
		}
		catch
		{
			MessageBox.Show("Ha ocurrido un error contacta a soporte tecnico");
		}
	}

	private string Selectdate(string mont)
	{
		return mont switch
		{
			"1" => "Enero", 
			"2" => "Febrero", 
			"3" => "Marzo", 
			"4" => "Abril", 
			"5" => "Mayo", 
			"6" => "Junio", 
			"7" => "Julio", 
			"8" => "Agosto", 
			"9" => "Septiembre", 
			"10" => "Octubre", 
			"11" => "Noviembre", 
			"12" => "Diciembre", 
			_ => "", 
		};
	}

	private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			try
			{
				string nombre = dataGridView1.CurrentRow.Cells["Usuario"].Value.ToString();
				string calculado = dataGridView1.CurrentRow.Cells["Calculado"].Value.ToString();
				string diferecnia = dataGridView1.CurrentRow.Cells["Diferencia"].Value.ToString();
				string entrada = dataGridView1.CurrentRow.Cells["Contado"].Value.ToString();
				string retirado = dataGridView1.CurrentRow.Cells["Retirado"].Value.ToString();
				string fecha = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
				Ver_corte_caja ver_corte_caja = new Ver_corte_caja(nombre, calculado, diferecnia, entrada, retirado, fecha);
				ver_corte_caja.ShowDialog();
			}
			catch
			{
				MessageBox.Show("No hay resultados que mostrar");
			}
		}
	}

	private void pictureBox2_Click(object sender, EventArgs e)
	{
		try
		{
			string nombre = dataGridView1.CurrentRow.Cells["Usuario"].Value.ToString();
			string calculado = dataGridView1.CurrentRow.Cells["Calculado"].Value.ToString();
			string diferecnia = dataGridView1.CurrentRow.Cells["Diferencia"].Value.ToString();
			string entrada = dataGridView1.CurrentRow.Cells["Contado"].Value.ToString();
			string retirado = dataGridView1.CurrentRow.Cells["Retirado"].Value.ToString();
			string fecha = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
			Ver_corte_caja ver_corte_caja = new Ver_corte_caja(nombre, calculado, diferecnia, entrada, retirado, fecha);
			ver_corte_caja.ShowDialog();
		}
		catch
		{
			MessageBox.Show("No hay resultados que mostrar");
		}
	}

	private string LoadMoney()
	{
		DataTable dataTable = new DataTable();
		try
		{
			dataTable = box.GETMONEY();
			id = dataTable.Rows[0]["idCaja"].ToString();
			return id;
		}
		catch
		{
			return id;
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
		lblfecha = new System.Windows.Forms.Label();
		dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
		dataGridView1 = new System.Windows.Forms.DataGridView();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(pictureBox2);
		panel1.Controls.Add(pictureBox1);
		panel1.Controls.Add(lblfecha);
		panel1.Controls.Add(dateTimePicker1);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(800, 78);
		panel1.TabIndex = 2;
		lblfecha.AutoSize = true;
		lblfecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblfecha.Location = new System.Drawing.Point(504, 15);
		lblfecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		lblfecha.Name = "lblfecha";
		lblfecha.Size = new System.Drawing.Size(140, 24);
		lblfecha.TabIndex = 1;
		lblfecha.Text = "Filtrar por fecha";
		dateTimePicker1.CalendarFont = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dateTimePicker1.Location = new System.Drawing.Point(415, 44);
		dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		dateTimePicker1.Name = "dateTimePicker1";
		dateTimePicker1.Size = new System.Drawing.Size(308, 29);
		dateTimePicker1.TabIndex = 0;
		dateTimePicker1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dateTimePicker1_KeyPress);
		dataGridView1.AllowUserToAddRows = false;
		dataGridView1.AllowUserToDeleteRows = false;
		dataGridView1.AllowUserToResizeColumns = false;
		dataGridView1.AllowUserToResizeRows = false;
		dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(224, 224, 224);
		dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView1.Location = new System.Drawing.Point(0, 83);
		dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		dataGridView1.Name = "dataGridView1";
		dataGridView1.Size = new System.Drawing.Size(800, 370);
		dataGridView1.TabIndex = 3;
		dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dataGridView1_KeyPress);
		pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox2.Image = BLUPOINT.Properties.Resources.ver;
		pictureBox2.Location = new System.Drawing.Point(88, 18);
		pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(44, 48);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 3;
		pictureBox2.TabStop = false;
		pictureBox2.Click += new System.EventHandler(pictureBox2_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox1.Image = BLUPOINT.Properties.Resources.filtrar;
		pictureBox1.Location = new System.Drawing.Point(13, 15);
		pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(51, 48);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 2;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(800, 450);
		base.Controls.Add(dataGridView1);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Corte_Caja_Visualizar";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Corte_Caja_Visualizar";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}
}

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

// BLUPOINT.Det_Box_Us
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class Det_Box_Us : Form
{
	private IContainer components = null;

	private Button Aceptar;

	private Label label3;

	private TextBox txtfecha;

	private Label label1;

	private TextBox txtentrada;

	private Label label2;

	private TextBox txtconcept;

	public Det_Box_Us(string fecha, string hora, string concep)
	{
		InitializeComponent();
		txtfecha.Text = fecha;
		txtconcept.Text = concep;
		txtentrada.Text = hora;
	}

	private void Aceptar_Click(object sender, EventArgs e)
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
		Aceptar = new System.Windows.Forms.Button();
		label3 = new System.Windows.Forms.Label();
		txtfecha = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		txtentrada = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		txtconcept = new System.Windows.Forms.TextBox();
		SuspendLayout();
		Aceptar.BackColor = System.Drawing.Color.SteelBlue;
		Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		Aceptar.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Aceptar.ForeColor = System.Drawing.Color.White;
		Aceptar.Location = new System.Drawing.Point(43, 295);
		Aceptar.Name = "Aceptar";
		Aceptar.Size = new System.Drawing.Size(189, 51);
		Aceptar.TabIndex = 13;
		Aceptar.Text = "Aceptar";
		Aceptar.UseVisualStyleBackColor = false;
		Aceptar.Click += new System.EventHandler(Aceptar_Click);
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(40, 26);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(61, 25);
		label3.TabIndex = 12;
		label3.Text = "Fecha";
		txtfecha.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtfecha.Location = new System.Drawing.Point(43, 54);
		txtfecha.Name = "txtfecha";
		txtfecha.Size = new System.Drawing.Size(191, 33);
		txtfecha.TabIndex = 11;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(40, 109);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(158, 25);
		label1.TabIndex = 8;
		label1.Text = "Hora de Apertura";
		txtentrada.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtentrada.Location = new System.Drawing.Point(43, 137);
		txtentrada.Name = "txtentrada";
		txtentrada.Size = new System.Drawing.Size(191, 33);
		txtentrada.TabIndex = 7;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(40, 204);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(98, 25);
		label2.TabIndex = 15;
		label2.Text = "Concepto ";
		txtconcept.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtconcept.Location = new System.Drawing.Point(43, 232);
		txtconcept.Name = "txtconcept";
		txtconcept.Size = new System.Drawing.Size(191, 33);
		txtconcept.TabIndex = 14;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(294, 358);
		base.Controls.Add(label2);
		base.Controls.Add(txtconcept);
		base.Controls.Add(Aceptar);
		base.Controls.Add(label3);
		base.Controls.Add(txtfecha);
		base.Controls.Add(label1);
		base.Controls.Add(txtentrada);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "Det_Box_Us";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Det_Box_Us";
		ResumeLayout(false);
		PerformLayout();
	}
}

// BLUPOINT.Detlle_Us
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class Detlle_Us : Form
{
	private IContainer components = null;

	private TextBox txtentrada;

	private Label label1;

	private Label label2;

	private TextBox txtsalida;

	private Label label3;

	private TextBox txtfecha;

	private Button Aceptar;

	public Detlle_Us(string fecha, string h_e, string h_f)
	{
		InitializeComponent();
		base.KeyPreview = true;
		base.KeyDown += Detlle_Us_KeyUp;
		Inicio(fecha, h_e, h_f);
	}

	private void Inicio(string f, string h_e, string h_f)
	{
		txtfecha.Text = f;
		txtentrada.Text = h_e;
		txtsalida.Text = h_f;
	}

	private void Aceptar_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void Detlle_Us_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			Close();
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
		txtentrada = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		txtsalida = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		txtfecha = new System.Windows.Forms.TextBox();
		Aceptar = new System.Windows.Forms.Button();
		SuspendLayout();
		txtentrada.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtentrada.Location = new System.Drawing.Point(19, 182);
		txtentrada.Name = "txtentrada";
		txtentrada.Size = new System.Drawing.Size(191, 33);
		txtentrada.TabIndex = 0;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(16, 154);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(149, 25);
		label1.TabIndex = 1;
		label1.Text = "Hora de Entrada";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(16, 266);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(135, 25);
		label2.TabIndex = 3;
		label2.Text = "Hora de Salida";
		txtsalida.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtsalida.Location = new System.Drawing.Point(19, 294);
		txtsalida.Name = "txtsalida";
		txtsalida.Size = new System.Drawing.Size(191, 33);
		txtsalida.TabIndex = 2;
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(16, 30);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(61, 25);
		label3.TabIndex = 5;
		label3.Text = "Fecha";
		txtfecha.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtfecha.Location = new System.Drawing.Point(19, 58);
		txtfecha.Name = "txtfecha";
		txtfecha.Size = new System.Drawing.Size(191, 33);
		txtfecha.TabIndex = 4;
		Aceptar.BackColor = System.Drawing.Color.SteelBlue;
		Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		Aceptar.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Aceptar.ForeColor = System.Drawing.Color.White;
		Aceptar.Location = new System.Drawing.Point(81, 398);
		Aceptar.Name = "Aceptar";
		Aceptar.Size = new System.Drawing.Size(129, 40);
		Aceptar.TabIndex = 6;
		Aceptar.Text = "Aceptar";
		Aceptar.UseVisualStyleBackColor = false;
		Aceptar.Click += new System.EventHandler(Aceptar_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(322, 450);
		base.Controls.Add(Aceptar);
		base.Controls.Add(label3);
		base.Controls.Add(txtfecha);
		base.Controls.Add(label2);
		base.Controls.Add(txtsalida);
		base.Controls.Add(label1);
		base.Controls.Add(txtentrada);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "Detlle_Us";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Detlle_Us";
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Detlle_Us_KeyUp);
		ResumeLayout(false);
		PerformLayout();
	}
}

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

// BLUPOINT.Editar_Negocio
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Editar_Negocio : Form
{
	private Negocio ne = new Negocio();

	private IContainer components = null;

	private Panel panel3;

	private Label label1;

	private Panel panel1;

	private Button button2;

	private TextBox txtestado;

	private Label label7;

	private TextBox txtnoe;

	private TextBox txtcolonia;

	private TextBox txtcalle;

	private TextBox txtcp;

	private Label label9;

	private TextBox txtmuni;

	private Label label8;

	private TextBox txtname_f;

	private Label label6;

	private TextBox txtcorreo;

	private Label label5;

	private TextBox txttelefono;

	private Label label4;

	private TextBox txtnombre;

	private Label label3;

	private Panel panel4;

	private Label label2;

	private Panel panel2;

	private Panel panel5;

	private Label label29;

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

	private Label lblname;

	private Label label12;

	private Label label11;

	private Button button1;

	private PrintDocument printDocument1;

	public Editar_Negocio()
	{
		InitializeComponent();
		loadDatos();
	}

	private void loadDatos()
	{
		DataTable dataTable = new DataTable();
		dataTable = ne.GetBusinees();
		txtnombre.Text = dataTable.Rows[0]["Nombre_N"].ToString();
		txtmuni.Text = dataTable.Rows[0]["Municipio"].ToString();
		txtcalle.Text = dataTable.Rows[0]["Calle"].ToString();
		txtcolonia.Text = dataTable.Rows[0]["Colonia"].ToString();
		txtcp.Text = dataTable.Rows[0]["CP"].ToString();
		txtnoe.Text = dataTable.Rows[0]["Numero_Ext"].ToString();
		txttelefono.Text = dataTable.Rows[0]["Telefono"].ToString();
		txtcorreo.Text = dataTable.Rows[0]["Correo"].ToString();
		txtestado.Text = dataTable.Rows[0]["Estado"].ToString();
		txtname_f.Text = dataTable.Rows[0]["Nombre_Fiscal"].ToString();
		Domicilio.Text = "Calle: " + txtcalle.Text + ", #" + txtnoe.Text + ", Col. " + txtcolonia.Text + "\n" + txtmuni.Text + ", " + Estados(txtestado.Text) + ", C.P: " + txtcp.Text;
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

	private void button2_Click(object sender, EventArgs e)
	{
		try
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
			if (ne.UPDATE() == 1)
			{
				MessageBox.Show("Negocio Actualizado");
			}
		}
		catch
		{
			MessageBox.Show("Error al actualizar datos");
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
		decimal numberAsString = Convert.ToDecimal("900");
		Font font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Point);
		Font font2 = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Point);
		Font font3 = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point);
		Font font4 = new Font("Segoe UI", 5f, FontStyle.Regular, GraphicsUnit.Point);
		Font font5 = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point);
		int num = 220;
		int num2 = 20;
		Image expendio = Resources.expendio;
		e.Graphics.DrawImage(expendio, new Rectangle(0, 0, 180, 80));
		e.Graphics.DrawString(" *** " + txtnombre.Text + "*** ", font, Brushes.Black, new RectangleF(0f, num2 += 65, num, 20f));
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

	private void button1_Click(object sender, EventArgs e)
	{
		Print();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Editar_Negocio));
		panel3 = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
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
		panel4 = new System.Windows.Forms.Panel();
		label2 = new System.Windows.Forms.Label();
		panel2 = new System.Windows.Forms.Panel();
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
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		button1 = new System.Windows.Forms.Button();
		panel3.SuspendLayout();
		panel1.SuspendLayout();
		panel4.SuspendLayout();
		panel2.SuspendLayout();
		panel5.SuspendLayout();
		SuspendLayout();
		panel3.BackColor = System.Drawing.Color.SteelBlue;
		panel3.Controls.Add(label1);
		panel3.Location = new System.Drawing.Point(12, 4);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(435, 38);
		panel3.TabIndex = 1;
		label1.AutoSize = true;
		label1.BackColor = System.Drawing.Color.Transparent;
		label1.Font = new System.Drawing.Font("Impact", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.ForeColor = System.Drawing.Color.White;
		label1.Location = new System.Drawing.Point(132, 7);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(166, 26);
		label1.TabIndex = 0;
		label1.Text = "DATOS DE NEGOCIO";
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
		panel1.Location = new System.Drawing.Point(12, 48);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(435, 571);
		panel1.TabIndex = 2;
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
		panel4.BackColor = System.Drawing.Color.SteelBlue;
		panel4.Controls.Add(label2);
		panel4.Location = new System.Drawing.Point(489, 4);
		panel4.Name = "panel4";
		panel4.Size = new System.Drawing.Size(349, 38);
		panel4.TabIndex = 3;
		label2.AutoSize = true;
		label2.BackColor = System.Drawing.Color.Transparent;
		label2.Font = new System.Drawing.Font("Impact", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.ForeColor = System.Drawing.Color.White;
		label2.Location = new System.Drawing.Point(97, 7);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(181, 26);
		label2.TabIndex = 1;
		label2.Text = "VISTA PREVIA TICKET";
		panel2.BackColor = System.Drawing.Color.White;
		panel2.Controls.Add(button1);
		panel2.Controls.Add(panel5);
		panel2.Location = new System.Drawing.Point(489, 48);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(349, 558);
		panel2.TabIndex = 4;
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
		button1.BackColor = System.Drawing.Color.Navy;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(71, 484);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(205, 43);
		button1.TabIndex = 20;
		button1.Text = "Imprimir";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ControlLightLight;
		base.ClientSize = new System.Drawing.Size(884, 631);
		base.Controls.Add(panel4);
		base.Controls.Add(panel2);
		base.Controls.Add(panel3);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Editar_Negocio";
		Text = "Editar Negocio";
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		panel4.ResumeLayout(false);
		panel4.PerformLayout();
		panel2.ResumeLayout(false);
		panel5.ResumeLayout(false);
		panel5.PerformLayout();
		ResumeLayout(false);
	}
}

// BLUPOINT.Empleado
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Empleado : Form
{
	private bool editar;

	private string rutas;

	private string ids;

	private string cargo1;

	private string cargo2;

	private string cargo3;

	private string cargo4;

	private string idis;

	private Empleados emp = new Empleados();

	private Caja cj = new Caja();

	public string respuesta = "";

	private IContainer components = null;

	private Panel panel2;

	private PictureBox search;

	private PictureBox Delete;

	private PictureBox cancel;

	private PictureBox save;

	private PictureBox edit;

	private PictureBox add;

	private Panel panel1;

	private Panel panel3;

	private Panel panel16;

	private Label label19;

	private PictureBox image_user;

	private Label label18;

	private Label txtName;

	private Panel panel5;

	private Panel panel4;

	private DataGridView DGVE;

	private Panel panel8;

	private Panel panel7;

	private Panel panel6;

	private Button btnSearch;

	private TextBox txtSearch;

	private Panel panel12;

	private Label label4;

	private Panel panel11;

	private Label label3;

	private Panel panel10;

	private Label label2;

	private TextBox txtCodigo;

	private ComboBox txtCargo;

	private Label label9;

	private DateTimePicker txtFecha;

	private Label label8;

	private TextBox txtApellido;

	private Label label6;

	private TextBox txtNombre;

	private Label label5;

	private Label label7;

	private Panel panel13;

	private PictureBox btnreport;

	private PictureBox btnventas;

	private ToolTip toolTip1;

	private PictureBox btncaja;

	private Button btnImage;

	private PictureBox Imagen_U;

	private CheckBox cb3;

	private CheckBox cb2;

	private CheckBox cb1;

	private Label txtruta;

	private Label iD;

	private Label txttipo_e;

	private Panel panel14;

	private Label label10;

	private DateTimePicker dtmpick;

	private CheckBox cb4;

	private PrintDocument printDocument1;

	private Label txtmoney;

	private Label label25;

	private Label label26;

	private TextBox txtpass;

	private Label label1;

	private PictureBox pictureBox1;

	private PictureBox pictureBox5;

	public Empleado(string nombre, string ruta, string cargo, string id, string car1, string car2, string car3, string car4)
	{
		InitializeComponent();
		base.KeyPreview = true;
		base.KeyDown += Empleado_KeyUp;
		Inicio();
		editar = false;
		txtName.Text = nombre;
		if (ruta == "")
		{
			image_user.Image = Resources.picture;
		}
		else
		{
			image_user.Image = Image.FromFile(ruta);
		}
		txttipo_e.Text = cargo;
		rutas = ruta;
		ids = id;
		cargo1 = car1;
		cargo2 = car2;
		cargo3 = car3;
		cargo4 = car4;
		LoadMoney();
	}

	private void LoadMoney()
	{
		DataTable dataTable = new DataTable();
		try
		{
			dataTable = cj.GETMONEY();
			txtmoney.Text = dataTable.Rows[0]["Cantidad"].ToString();
			idis = dataTable.Rows[0]["idCaja"].ToString();
		}
		catch
		{
		}
	}

	private void Inicio()
	{
		iD.Text = "";
		txtApellido.Enabled = false;
		txtNombre.Enabled = false;
		txtCargo.Enabled = false;
		txtCodigo.Enabled = false;
		txtFecha.Enabled = false;
		txtSearch.Enabled = false;
		txtpass.Enabled = false;
		cb1.Enabled = false;
		cb2.Enabled = false;
		cb3.Enabled = false;
		cb4.Enabled = false;
		btnImage.Enabled = false;
		edit.Enabled = false;
		Delete.Enabled = false;
		save.Enabled = false;
		cancel.Enabled = false;
		edit.Image = Resources.usuario__2_;
		Delete.Image = Resources.eliminar_usuario__1_;
		cancel.Image = Resources.eliminar1;
		save.Image = Resources.disquete1;
		add.Enabled = true;
		Imagen_U.Image = Resources.picture;
		add.Image = Resources.agregar_simbolo_de_usuario1;
		DGVE.DataSource = emp.GETEmp();
	}

	private void Habilitar()
	{
		txtApellido.Enabled = true;
		txtNombre.Enabled = true;
		txtCargo.Enabled = true;
		txtCodigo.Enabled = true;
		txtFecha.Enabled = true;
		txtSearch.Enabled = true;
		txtpass.Enabled = true;
		txtCodigo.Focus();
		save.Image = Resources.disquete;
		save.Enabled = true;
		cancel.Image = Resources.eliminar;
		cancel.Enabled = true;
		btnImage.Enabled = true;
		btnSearch.Enabled = true;
		cb1.Enabled = true;
		cb2.Enabled = true;
		cb3.Enabled = true;
		cb4.Enabled = true;
	}

	private void Limpiar()
	{
		iD.Text = "";
		txtApellido.Text = "";
		txtCargo.Text = "";
		txtCodigo.Text = "";
		txtFecha.ResetText();
		txtNombre.Text = "";
		txtSearch.Text = "";
		txtpass.Text = "";
		Imagen_U.Image = null;
		cb1.Checked = false;
		cb2.Checked = false;
		cb3.Checked = false;
		cb4.Checked = false;
	}

	public void LoadData()
	{
		try
		{
			iD.Text = DGVE.Rows[0].Cells["idEmpleado"].Value.ToString();
			txtNombre.Text = DGVE.Rows[0].Cells["Nombre"].Value.ToString();
			txtCodigo.Text = DGVE.Rows[0].Cells["Clave"].Value.ToString();
			txtFecha.Text = DGVE.Rows[0].Cells["Fecha_N"].Value.ToString();
			txtruta.Text = DGVE.Rows[0].Cells["Imagen"].Value.ToString();
			string text = DGVE.Rows[0].Cells["Imagen"].Value.ToString();
			txtpass.Text = DGVE.Rows[0].Cells["Pass"].Value.ToString();
			if (text == "")
			{
				Imagen_U.Image = null;
			}
			else
			{
				Imagen_U.Image = Image.FromFile(DGVE.Rows[0].Cells["Imagen"].Value.ToString());
			}
			txtCargo.Text = DGVE.Rows[0].Cells["Tipo_Emp"].Value.ToString();
			txtApellido.Text = DGVE.Rows[0].Cells["Apellidos"].Value.ToString();
			string text2 = DGVE.Rows[0].Cells["Usuario"].Value.ToString();
			string text3 = DGVE.Rows[0].Cells["Producto"].Value.ToString();
			string text4 = DGVE.Rows[0].Cells["Cliente"].Value.ToString();
			string text5 = DGVE.Rows[0].Cells["Caja"].Value.ToString();
			if (text5 == "1")
			{
				cb4.Checked = true;
			}
			else
			{
				cb4.Checked = false;
			}
			if (text2 == "1")
			{
				cb1.Checked = true;
			}
			else
			{
				cb1.Checked = false;
			}
			if (text3 == "1")
			{
				cb2.Checked = true;
			}
			else
			{
				cb2.Checked = false;
			}
			if (text4 == "1")
			{
				cb3.Checked = true;
			}
			else
			{
				cb3.Checked = false;
			}
			edit.Image = Resources.usuario__1_;
			edit.Enabled = true;
			cb1.Enabled = false;
			cb2.Enabled = false;
			cb3.Enabled = false;
			cb4.Enabled = false;
		}
		catch
		{
			MessageBox.Show("Empleado solicitado No Encontrado");
			edit.Enabled = false;
			Delete.Enabled = false;
			Delete.Image = Resources.eliminar_usuario__1_;
			edit.Image = Resources.usuario__2_;
		}
	}

	private void Guardar()
	{
		emp.Clave = txtCodigo.Text.Trim();
		emp.Nombre_E = txtNombre.Text.Trim();
		emp.Tipo_Emp = txtCargo.Text.Trim();
		emp.Pass = txtpass.Text.Trim();
		emp.Apellido_E = txtApellido.Text.Trim();
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
			MessageBox.Show("Empleado Registrado con exito");
			Limpiar();
			Inicio();
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

	private void Editar()
	{
		emp.id = iD.Text;
		emp.Clave = txtCodigo.Text.Trim();
		emp.Nombre_E = txtNombre.Text.Trim();
		emp.Pass = txtpass.Text.Trim();
		emp.Tipo_Emp = txtCargo.Text.Trim();
		emp.Apellido_E = txtApellido.Text.Trim();
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
		string text = txtNombre.Text + " " + txtApellido.Text;
		emp.id = iD.Text;
		if (text == txtName.Text)
		{
			MessageBox.Show("No puedes editarte a ti mismo");
		}
		else if (emp.UPDATE() == 1)
		{
			MessageBox.Show("Empleado Editado con exito");
			Limpiar();
			Inicio();
			editar = false;
		}
		else
		{
			MessageBox.Show("Ha Ocurrido un Error");
		}
	}

	private void Empleado_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F12)
		{
			Form1 form = new Form1(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
			form.Show();
			Close();
		}
		else if (e.KeyCode == Keys.Escape)
		{
			if (MessageBox.Show("Cancelar", "Deseas Cancelar el registro??", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				Limpiar();
				Inicio();
			}
		}
		else if (e.KeyCode == Keys.F1)
		{
			Habilitar();
		}
		else if (e.KeyCode == Keys.F2)
		{
			if (txtCodigo.Text != "")
			{
				HabilitarEdicion();
			}
			else
			{
				MessageBox.Show("No se puede editar sin un empleado activo");
			}
		}
		else if (e.KeyCode == Keys.F3)
		{
			if (save.Enabled)
			{
				if (!editar)
				{
					Guardar();
				}
				else
				{
					Editar();
				}
			}
		}
		else if (e.KeyCode == Keys.F4)
		{
			if (editar)
			{
				string text = txtNombre.Text + " " + txtApellido.Text;
				emp.id = iD.Text;
				if (text == txtName.Text)
				{
					MessageBox.Show("No puedes eliminarte a ti mismo");
				}
				else if (emp.DELETE() == 1)
				{
					MessageBox.Show("Empleado Eliminado con exito");
					Limpiar();
					Inicio();
					editar = false;
				}
				else
				{
					MessageBox.Show("No se pudo eliminar");
				}
			}
		}
		else if (e.KeyCode == Keys.F5)
		{
			txtSearch.Enabled = true;
			txtSearch.Focus();
		}
		else if (e.KeyCode == Keys.F6)
		{
			if (iD.Text == "")
			{
				MessageBox.Show("Escanea el codigo para Obtener los datos del empleado");
			}
			else
			{
				Reporte_Usuario reporte_Usuario = new Reporte_Usuario(iD.Text, txtNombre.Text, txtruta.Text, txtCargo.Text);
				reporte_Usuario.ShowDialog();
			}
		}
		else if (e.KeyCode == Keys.F9)
		{
			LoadImage();
		}
		else if (e.KeyCode == Keys.F7)
		{
			if (iD.Text == "")
			{
				MessageBox.Show("Escanea el codigo para Obtener los datos del empleado");
			}
			else
			{
				Rep_Venta rep_Venta = new Rep_Venta(iD.Text, txtNombre.Text + " " + txtApellido.Text, txtruta.Text, txtCargo.Text);
				rep_Venta.ShowDialog();
			}
		}
		else if (e.KeyCode == Keys.F10)
		{
			Codigo_Barras_Prod codigo_Barras_Prod = new Codigo_Barras_Prod();
			codigo_Barras_Prod.ShowDialog();
		}
		if (e.KeyCode == Keys.F8)
		{
			if (iD.Text == "")
			{
				MessageBox.Show("Escanea el codigo para Obtener los datos del empleado");
				return;
			}
			Rep_Caja_Usr rep_Caja_Usr = new Rep_Caja_Usr(idis, txtNombre.Text + " " + txtApellido.Text, txtruta.Text, txtCargo.Text);
			rep_Caja_Usr.ShowDialog();
		}
	}

	private void Empleado_Load(object sender, EventArgs e)
	{
	}

	private void Cargo_TextChanged(object sender, EventArgs e)
	{
		if (txtCargo.Text == "Admin")
		{
			cb1.Enabled = true;
			cb2.Enabled = true;
			cb3.Enabled = true;
			cb1.Checked = true;
			cb2.Checked = true;
			cb3.Checked = true;
			cb4.Enabled = true;
			cb4.Checked = true;
		}
	}

	private void add_Click(object sender, EventArgs e)
	{
		Habilitar();
	}

	private void cancel_Click(object sender, EventArgs e)
	{
		alert_danger alert_danger2 = new alert_danger("Cancelar", "Deseas Cancelar el Registro??");
		AddOwnedForm(alert_danger2);
		alert_danger2.ShowDialog();
		if (respuesta == "Si")
		{
			Limpiar();
			Inicio();
		}
	}

	private void btnreport_Click(object sender, EventArgs e)
	{
		if (iD.Text == "")
		{
			MessageBox.Show("Escanea el codigo para Obtener los datos del empleado");
			return;
		}
		Reporte_Usuario reporte_Usuario = new Reporte_Usuario(iD.Text, txtNombre.Text + " " + txtApellido.Text, txtruta.Text, txtCargo.Text);
		reporte_Usuario.ShowDialog();
	}

	private void save_Click(object sender, EventArgs e)
	{
		if (!editar)
		{
			Guardar();
		}
		else
		{
			Editar();
		}
	}

	private void LoadImage()
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

	private void btnImage_Click(object sender, EventArgs e)
	{
		LoadImage();
	}

	private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			emp.Clave = txtSearch.Text;
			DGVE.DataSource = emp.GETBYID();
			LoadData();
		}
	}

	private void search_Click(object sender, EventArgs e)
	{
		txtSearch.Enabled = true;
		txtSearch.Focus();
	}

	private void btnSearch_Click(object sender, EventArgs e)
	{
		emp.Clave = txtSearch.Text;
		DGVE.DataSource = emp.GETBYID();
		edit.Image = Resources.usuario__1_;
		edit.Enabled = true;
		LoadData();
	}

	private void btnventas_Click(object sender, EventArgs e)
	{
		if (iD.Text == "")
		{
			MessageBox.Show("Necesitas seleccionar un usuario antes");
			return;
		}
		Rep_Venta rep_Venta = new Rep_Venta(iD.Text, txtNombre.Text + " " + txtApellido.Text, txtruta.Text, txtCargo.Text);
		rep_Venta.ShowDialog();
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		Codigo_Barras_Prod codigo_Barras_Prod = new Codigo_Barras_Prod();
		codigo_Barras_Prod.ShowDialog();
	}

	private void pictureBox5_Click(object sender, EventArgs e)
	{
		Form1 form = new Form1(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
		form.Show();
		Close();
	}

	private void DGVE_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		iD.Text = DGVE.CurrentRow.Cells["idEmpleado"].Value.ToString();
		txtNombre.Text = DGVE.CurrentRow.Cells["Nombre"].Value.ToString();
		txtCodigo.Text = DGVE.CurrentRow.Cells["Clave"].Value.ToString();
		txtFecha.Text = DGVE.CurrentRow.Cells["Fecha_N"].Value.ToString();
		txtruta.Text = DGVE.CurrentRow.Cells["Imagen"].Value.ToString();
		string text = DGVE.Rows[0].Cells["Imagen"].Value.ToString();
		txtpass.Text = DGVE.CurrentRow.Cells["Pass"].Value.ToString();
		if (text == "")
		{
			Imagen_U.Image = null;
		}
		else
		{
			Imagen_U.Image = Image.FromFile(DGVE.CurrentRow.Cells["Imagen"].Value.ToString());
		}
		txtCargo.Text = DGVE.CurrentRow.Cells["Tipo_Emp"].Value.ToString();
		txtApellido.Text = DGVE.CurrentRow.Cells["Apellidos"].Value.ToString();
		string text2 = DGVE.CurrentRow.Cells["Usuario"].Value.ToString();
		string text3 = DGVE.CurrentRow.Cells["Producto"].Value.ToString();
		string text4 = DGVE.CurrentRow.Cells["Cliente"].Value.ToString();
		string text5 = DGVE.CurrentRow.Cells["Caja"].Value.ToString();
		if (text5 == "1")
		{
			cb4.Checked = true;
		}
		else
		{
			cb4.Checked = false;
		}
		if (text2 == "1")
		{
			cb1.Checked = true;
		}
		else
		{
			cb1.Checked = false;
		}
		if (text3 == "1")
		{
			cb2.Checked = true;
		}
		else
		{
			cb2.Checked = false;
		}
		if (text4 == "1")
		{
			cb3.Checked = true;
		}
		else
		{
			cb3.Checked = false;
		}
		edit.Image = Resources.usuario__1_;
		edit.Enabled = true;
		cb1.Enabled = false;
		cb2.Enabled = false;
		cb3.Enabled = false;
		cb4.Enabled = false;
	}

	private void btncaja_Click(object sender, EventArgs e)
	{
		if (iD.Text == "")
		{
			MessageBox.Show("Escanea el codigo para Obtener los datos del empleado");
			return;
		}
		Rep_Caja_Usr rep_Caja_Usr = new Rep_Caja_Usr(iD.Text, txtNombre.Text + " " + txtApellido.Text, txtruta.Text, txtCargo.Text);
		rep_Caja_Usr.ShowDialog();
	}

	private void HabilitarEdicion()
	{
		Delete.Enabled = true;
		cancel.Enabled = true;
		save.Enabled = true;
		add.Enabled = false;
		add.Image = Resources.agregar_simbolo_de_usuario__1_;
		Delete.Image = Resources.eliminar_usuario;
		cancel.Image = Resources.eliminar;
		save.Image = Resources.disquete;
		editar = true;
		txtApellido.Enabled = true;
		txtNombre.Enabled = true;
		txtCargo.Enabled = true;
		txtCodigo.Enabled = true;
		txtFecha.Enabled = true;
		txtSearch.Enabled = true;
		txtCodigo.Focus();
		btnImage.Enabled = true;
		txtpass.Enabled = true;
		cb1.Enabled = true;
		cb2.Enabled = true;
		cb3.Enabled = true;
		cb4.Enabled = true;
		MessageBox.Show("Edicion Habilitada");
	}

	private void edit_Click(object sender, EventArgs e)
	{
		HabilitarEdicion();
	}

	private void Delete_Click(object sender, EventArgs e)
	{
		string text = txtNombre.Text + " " + txtApellido.Text;
		emp.id = iD.Text;
		if (text == txtName.Text)
		{
			MessageBox.Show("No puedes eliminarte a ti mismo");
		}
		else if (emp.DELETE() == 1)
		{
			MessageBox.Show("Empleado Eliminado con exito");
			Limpiar();
			Inicio();
			editar = false;
		}
		else
		{
			MessageBox.Show("No se pudo eliminar");
		}
	}

	private void Empleado_FormClosed(object sender, FormClosedEventArgs e)
	{
	}

	private void Empleado_FormClosing(object sender, FormClosingEventArgs e)
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
		components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Empleado));
		panel2 = new System.Windows.Forms.Panel();
		pictureBox5 = new System.Windows.Forms.PictureBox();
		search = new System.Windows.Forms.PictureBox();
		Delete = new System.Windows.Forms.PictureBox();
		cancel = new System.Windows.Forms.PictureBox();
		save = new System.Windows.Forms.PictureBox();
		edit = new System.Windows.Forms.PictureBox();
		add = new System.Windows.Forms.PictureBox();
		txtmoney = new System.Windows.Forms.Label();
		label25 = new System.Windows.Forms.Label();
		label26 = new System.Windows.Forms.Label();
		panel1 = new System.Windows.Forms.Panel();
		panel16 = new System.Windows.Forms.Panel();
		txttipo_e = new System.Windows.Forms.Label();
		label19 = new System.Windows.Forms.Label();
		image_user = new System.Windows.Forms.PictureBox();
		label18 = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.Label();
		panel3 = new System.Windows.Forms.Panel();
		panel14 = new System.Windows.Forms.Panel();
		label10 = new System.Windows.Forms.Label();
		dtmpick = new System.Windows.Forms.DateTimePicker();
		panel13 = new System.Windows.Forms.Panel();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		btncaja = new System.Windows.Forms.PictureBox();
		btnventas = new System.Windows.Forms.PictureBox();
		btnreport = new System.Windows.Forms.PictureBox();
		panel12 = new System.Windows.Forms.Panel();
		label4 = new System.Windows.Forms.Label();
		panel11 = new System.Windows.Forms.Panel();
		label3 = new System.Windows.Forms.Label();
		panel10 = new System.Windows.Forms.Panel();
		label2 = new System.Windows.Forms.Label();
		panel8 = new System.Windows.Forms.Panel();
		btnImage = new System.Windows.Forms.Button();
		Imagen_U = new System.Windows.Forms.PictureBox();
		panel7 = new System.Windows.Forms.Panel();
		cb4 = new System.Windows.Forms.CheckBox();
		cb3 = new System.Windows.Forms.CheckBox();
		cb2 = new System.Windows.Forms.CheckBox();
		cb1 = new System.Windows.Forms.CheckBox();
		panel6 = new System.Windows.Forms.Panel();
		btnSearch = new System.Windows.Forms.Button();
		txtSearch = new System.Windows.Forms.TextBox();
		panel5 = new System.Windows.Forms.Panel();
		txtpass = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
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
		panel4 = new System.Windows.Forms.Panel();
		DGVE = new System.Windows.Forms.DataGridView();
		toolTip1 = new System.Windows.Forms.ToolTip(components);
		txtruta = new System.Windows.Forms.Label();
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)search).BeginInit();
		((System.ComponentModel.ISupportInitialize)Delete).BeginInit();
		((System.ComponentModel.ISupportInitialize)cancel).BeginInit();
		((System.ComponentModel.ISupportInitialize)save).BeginInit();
		((System.ComponentModel.ISupportInitialize)edit).BeginInit();
		((System.ComponentModel.ISupportInitialize)add).BeginInit();
		panel1.SuspendLayout();
		panel16.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)image_user).BeginInit();
		panel3.SuspendLayout();
		panel14.SuspendLayout();
		panel13.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)btncaja).BeginInit();
		((System.ComponentModel.ISupportInitialize)btnventas).BeginInit();
		((System.ComponentModel.ISupportInitialize)btnreport).BeginInit();
		panel12.SuspendLayout();
		panel11.SuspendLayout();
		panel10.SuspendLayout();
		panel8.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)Imagen_U).BeginInit();
		panel7.SuspendLayout();
		panel6.SuspendLayout();
		panel5.SuspendLayout();
		panel4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)DGVE).BeginInit();
		SuspendLayout();
		panel2.BackColor = System.Drawing.Color.White;
		panel2.Controls.Add(pictureBox5);
		panel2.Controls.Add(search);
		panel2.Controls.Add(Delete);
		panel2.Controls.Add(cancel);
		panel2.Controls.Add(save);
		panel2.Controls.Add(edit);
		panel2.Controls.Add(add);
		panel2.Dock = System.Windows.Forms.DockStyle.Left;
		panel2.Location = new System.Drawing.Point(0, 0);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(127, 740);
		panel2.TabIndex = 14;
		pictureBox5.BackColor = System.Drawing.Color.Transparent;
		pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox5.Image = BLUPOINT.Properties.Resources.atras;
		pictureBox5.Location = new System.Drawing.Point(0, -1);
		pictureBox5.Name = "pictureBox5";
		pictureBox5.Size = new System.Drawing.Size(35, 35);
		pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox5.TabIndex = 21;
		pictureBox5.TabStop = false;
		toolTip1.SetToolTip(pictureBox5, "Añadir (F1)");
		pictureBox5.Click += new System.EventHandler(pictureBox5_Click);
		search.BackColor = System.Drawing.Color.Transparent;
		search.Cursor = System.Windows.Forms.Cursors.Hand;
		search.Image = BLUPOINT.Properties.Resources.buscar;
		search.Location = new System.Drawing.Point(33, 525);
		search.Name = "search";
		search.Size = new System.Drawing.Size(65, 69);
		search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		search.TabIndex = 19;
		search.TabStop = false;
		search.Click += new System.EventHandler(search_Click);
		Delete.BackColor = System.Drawing.Color.Transparent;
		Delete.Cursor = System.Windows.Forms.Cursors.Hand;
		Delete.Image = BLUPOINT.Properties.Resources.eliminar_usuario__1_;
		Delete.Location = new System.Drawing.Point(33, 422);
		Delete.Name = "Delete";
		Delete.Size = new System.Drawing.Size(65, 69);
		Delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		Delete.TabIndex = 18;
		Delete.TabStop = false;
		Delete.Click += new System.EventHandler(Delete_Click);
		cancel.BackColor = System.Drawing.Color.Transparent;
		cancel.Cursor = System.Windows.Forms.Cursors.Hand;
		cancel.Image = BLUPOINT.Properties.Resources.eliminar1;
		cancel.Location = new System.Drawing.Point(33, 629);
		cancel.Name = "cancel";
		cancel.Size = new System.Drawing.Size(65, 69);
		cancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		cancel.TabIndex = 17;
		cancel.TabStop = false;
		cancel.Click += new System.EventHandler(cancel_Click);
		save.BackColor = System.Drawing.Color.Transparent;
		save.Cursor = System.Windows.Forms.Cursors.Hand;
		save.Image = BLUPOINT.Properties.Resources.disquete1;
		save.Location = new System.Drawing.Point(33, 303);
		save.Name = "save";
		save.Size = new System.Drawing.Size(65, 69);
		save.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		save.TabIndex = 16;
		save.TabStop = false;
		save.Click += new System.EventHandler(save_Click);
		edit.BackColor = System.Drawing.Color.Transparent;
		edit.Cursor = System.Windows.Forms.Cursors.Hand;
		edit.Image = BLUPOINT.Properties.Resources.usuario__2_;
		edit.Location = new System.Drawing.Point(33, 185);
		edit.Name = "edit";
		edit.Size = new System.Drawing.Size(65, 69);
		edit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		edit.TabIndex = 7;
		edit.TabStop = false;
		edit.Click += new System.EventHandler(edit_Click);
		add.BackColor = System.Drawing.Color.Transparent;
		add.Cursor = System.Windows.Forms.Cursors.Hand;
		add.Image = BLUPOINT.Properties.Resources.agregar_simbolo_de_usuario1;
		add.Location = new System.Drawing.Point(33, 79);
		add.Name = "add";
		add.Size = new System.Drawing.Size(65, 63);
		add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		add.TabIndex = 6;
		add.TabStop = false;
		add.Click += new System.EventHandler(add_Click);
		txtmoney.AutoSize = true;
		txtmoney.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtmoney.Location = new System.Drawing.Point(47, 9);
		txtmoney.Name = "txtmoney";
		txtmoney.Size = new System.Drawing.Size(36, 25);
		txtmoney.TabIndex = 25;
		txtmoney.Text = "0.0";
		label25.AutoSize = true;
		label25.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label25.Location = new System.Drawing.Point(31, 9);
		label25.Name = "label25";
		label25.Size = new System.Drawing.Size(22, 25);
		label25.TabIndex = 24;
		label25.Text = "$";
		label26.AutoSize = true;
		label26.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label26.Location = new System.Drawing.Point(3, 31);
		label26.Name = "label26";
		label26.Size = new System.Drawing.Size(127, 21);
		label26.TabIndex = 23;
		label26.Text = "Cantidad en Caja";
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(txtmoney);
		panel1.Controls.Add(label25);
		panel1.Controls.Add(panel16);
		panel1.Controls.Add(label26);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(127, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(1134, 65);
		panel1.TabIndex = 15;
		panel16.Controls.Add(txttipo_e);
		panel16.Controls.Add(label19);
		panel16.Controls.Add(image_user);
		panel16.Controls.Add(label18);
		panel16.Controls.Add(txtName);
		panel16.Dock = System.Windows.Forms.DockStyle.Right;
		panel16.Location = new System.Drawing.Point(823, 0);
		panel16.Name = "panel16";
		panel16.Size = new System.Drawing.Size(311, 65);
		panel16.TabIndex = 1;
		txttipo_e.AutoSize = true;
		txttipo_e.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttipo_e.Location = new System.Drawing.Point(176, 44);
		txttipo_e.Name = "txttipo_e";
		txttipo_e.Size = new System.Drawing.Size(52, 18);
		txttipo_e.TabIndex = 28;
		txttipo_e.Text = "Cajero";
		label19.AutoSize = true;
		label19.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
		label19.Location = new System.Drawing.Point(207, 28);
		label19.Name = "label19";
		label19.Size = new System.Drawing.Size(37, 13);
		label19.TabIndex = 27;
		label19.Text = "Activo";
		image_user.Image = (System.Drawing.Image)resources.GetObject("image_user.Image");
		image_user.Location = new System.Drawing.Point(257, 0);
		image_user.Name = "image_user";
		image_user.Size = new System.Drawing.Size(54, 62);
		image_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		image_user.TabIndex = 24;
		image_user.TabStop = false;
		label18.AutoSize = true;
		label18.ForeColor = System.Drawing.SystemColors.AppWorkspace;
		label18.Location = new System.Drawing.Point(171, 28);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(37, 13);
		label18.TabIndex = 26;
		label18.Text = "Status";
		txtName.AutoSize = true;
		txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtName.Location = new System.Drawing.Point(4, 0);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(197, 24);
		txtName.TabIndex = 25;
		txtName.Text = "Jorge Lemus Stripsent";
		panel3.BackColor = System.Drawing.Color.White;
		panel3.Controls.Add(panel14);
		panel3.Controls.Add(dtmpick);
		panel3.Controls.Add(panel13);
		panel3.Controls.Add(panel12);
		panel3.Controls.Add(panel11);
		panel3.Controls.Add(panel10);
		panel3.Controls.Add(panel8);
		panel3.Controls.Add(panel7);
		panel3.Controls.Add(panel6);
		panel3.Controls.Add(panel5);
		panel3.Controls.Add(panel4);
		panel3.Location = new System.Drawing.Point(133, 71);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(1116, 643);
		panel3.TabIndex = 16;
		panel14.BackColor = System.Drawing.Color.SteelBlue;
		panel14.Controls.Add(label10);
		panel14.Location = new System.Drawing.Point(14, 17);
		panel14.Name = "panel14";
		panel14.Size = new System.Drawing.Size(369, 37);
		panel14.TabIndex = 10;
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Impact", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label10.ForeColor = System.Drawing.Color.White;
		label10.Location = new System.Drawing.Point(98, 6);
		label10.Name = "label10";
		label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		label10.Size = new System.Drawing.Size(186, 26);
		label10.TabIndex = 0;
		label10.Text = "VISOR DE EMPLEADOS";
		dtmpick.Location = new System.Drawing.Point(68, 29);
		dtmpick.Name = "dtmpick";
		dtmpick.Size = new System.Drawing.Size(200, 20);
		dtmpick.TabIndex = 2;
		panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel13.Controls.Add(pictureBox1);
		panel13.Controls.Add(btncaja);
		panel13.Controls.Add(btnventas);
		panel13.Controls.Add(btnreport);
		panel13.Location = new System.Drawing.Point(399, 546);
		panel13.Name = "panel13";
		panel13.Size = new System.Drawing.Size(445, 87);
		panel13.TabIndex = 8;
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox1.Image = BLUPOINT.Properties.Resources.codigo_de_barras;
		pictureBox1.Location = new System.Drawing.Point(357, 10);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(68, 66);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 3;
		pictureBox1.TabStop = false;
		toolTip1.SetToolTip(pictureBox1, "Genrar Codigo de Barras (F10)");
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		btncaja.Cursor = System.Windows.Forms.Cursors.Hand;
		btncaja.Image = BLUPOINT.Properties.Resources.reporte_v_1;
		btncaja.Location = new System.Drawing.Point(257, 10);
		btncaja.Name = "btncaja";
		btncaja.Size = new System.Drawing.Size(68, 66);
		btncaja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		btncaja.TabIndex = 2;
		btncaja.TabStop = false;
		toolTip1.SetToolTip(btncaja, "Reporte de Caja Por Usuario (F8)");
		btncaja.Click += new System.EventHandler(btncaja_Click);
		btnventas.Cursor = System.Windows.Forms.Cursors.Hand;
		btnventas.Image = BLUPOINT.Properties.Resources.informe_de_venta;
		btnventas.Location = new System.Drawing.Point(140, 10);
		btnventas.Name = "btnventas";
		btnventas.Size = new System.Drawing.Size(69, 66);
		btnventas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		btnventas.TabIndex = 1;
		btnventas.TabStop = false;
		toolTip1.SetToolTip(btnventas, "Reporte de Ventas Por Usuario (F7)");
		btnventas.Click += new System.EventHandler(btnventas_Click);
		btnreport.Cursor = System.Windows.Forms.Cursors.Hand;
		btnreport.Image = BLUPOINT.Properties.Resources.informe_medico;
		btnreport.Location = new System.Drawing.Point(29, 10);
		btnreport.Name = "btnreport";
		btnreport.Size = new System.Drawing.Size(70, 66);
		btnreport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		btnreport.TabIndex = 0;
		btnreport.TabStop = false;
		toolTip1.SetToolTip(btnreport, "Reporte de Asistencia (F6)");
		btnreport.Click += new System.EventHandler(btnreport_Click);
		panel12.BackColor = System.Drawing.Color.SteelBlue;
		panel12.Controls.Add(label4);
		panel12.Location = new System.Drawing.Point(861, 308);
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
		panel11.Location = new System.Drawing.Point(861, 17);
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
		panel10.Location = new System.Drawing.Point(399, 17);
		panel10.Name = "panel10";
		panel10.Size = new System.Drawing.Size(445, 37);
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
		panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel8.Controls.Add(btnImage);
		panel8.Controls.Add(Imagen_U);
		panel8.Location = new System.Drawing.Point(861, 345);
		panel8.Name = "panel8";
		panel8.Size = new System.Drawing.Size(245, 289);
		panel8.TabIndex = 4;
		btnImage.BackColor = System.Drawing.Color.SteelBlue;
		btnImage.Cursor = System.Windows.Forms.Cursors.Hand;
		btnImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnImage.ForeColor = System.Drawing.Color.White;
		btnImage.Location = new System.Drawing.Point(21, 236);
		btnImage.Name = "btnImage";
		btnImage.Size = new System.Drawing.Size(214, 41);
		btnImage.TabIndex = 2;
		btnImage.Text = "Cargar Imagen (F9)";
		btnImage.UseVisualStyleBackColor = false;
		btnImage.Click += new System.EventHandler(btnImage_Click);
		Imagen_U.Cursor = System.Windows.Forms.Cursors.Arrow;
		Imagen_U.Image = BLUPOINT.Properties.Resources.picture;
		Imagen_U.Location = new System.Drawing.Point(21, 8);
		Imagen_U.Name = "Imagen_U";
		Imagen_U.Size = new System.Drawing.Size(214, 222);
		Imagen_U.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		Imagen_U.TabIndex = 3;
		Imagen_U.TabStop = false;
		toolTip1.SetToolTip(Imagen_U, "Reporte de Ventas Por Usuario");
		panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel7.Controls.Add(cb4);
		panel7.Controls.Add(cb3);
		panel7.Controls.Add(cb2);
		panel7.Controls.Add(cb1);
		panel7.Location = new System.Drawing.Point(861, 55);
		panel7.Name = "panel7";
		panel7.Size = new System.Drawing.Size(245, 212);
		panel7.TabIndex = 3;
		cb4.AutoSize = true;
		cb4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		cb4.Location = new System.Drawing.Point(21, 160);
		cb4.Name = "cb4";
		cb4.Size = new System.Drawing.Size(209, 29);
		cb4.TabIndex = 5;
		cb4.Text = "Cantidad en caja";
		toolTip1.SetToolTip(cb4, "Establece que el usuario al entrar y no haber dinero en caja puede añadirlo de forma manual");
		cb4.UseVisualStyleBackColor = true;
		cb3.AutoSize = true;
		cb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		cb3.Location = new System.Drawing.Point(21, 111);
		cb3.Name = "cb3";
		cb3.Size = new System.Drawing.Size(165, 29);
		cb3.TabIndex = 3;
		cb3.Text = "Alta Clientes";
		cb3.UseVisualStyleBackColor = true;
		cb2.AutoSize = true;
		cb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		cb2.Location = new System.Drawing.Point(21, 58);
		cb2.Name = "cb2";
		cb2.Size = new System.Drawing.Size(185, 29);
		cb2.TabIndex = 2;
		cb2.Text = "Alta Productos";
		cb2.UseVisualStyleBackColor = true;
		cb1.AutoSize = true;
		cb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		cb1.Location = new System.Drawing.Point(21, 4);
		cb1.Name = "cb1";
		cb1.Size = new System.Drawing.Size(172, 29);
		cb1.TabIndex = 1;
		cb1.Text = "Alta Usuarios";
		cb1.UseVisualStyleBackColor = true;
		panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel6.Controls.Add(btnSearch);
		panel6.Controls.Add(txtSearch);
		panel6.Location = new System.Drawing.Point(11, 520);
		panel6.Name = "panel6";
		panel6.Size = new System.Drawing.Size(372, 107);
		panel6.TabIndex = 2;
		btnSearch.BackColor = System.Drawing.Color.SteelBlue;
		btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
		btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnSearch.ForeColor = System.Drawing.Color.White;
		btnSearch.Location = new System.Drawing.Point(120, 61);
		btnSearch.Name = "btnSearch";
		btnSearch.Size = new System.Drawing.Size(113, 41);
		btnSearch.TabIndex = 1;
		btnSearch.Text = "BUSCAR";
		btnSearch.UseVisualStyleBackColor = false;
		btnSearch.Click += new System.EventHandler(btnSearch_Click);
		txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtSearch.Location = new System.Drawing.Point(34, 24);
		txtSearch.Name = "txtSearch";
		txtSearch.Size = new System.Drawing.Size(303, 31);
		txtSearch.TabIndex = 0;
		txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSearch_KeyPress);
		panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel5.Controls.Add(txtpass);
		panel5.Controls.Add(label1);
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
		panel5.Location = new System.Drawing.Point(399, 55);
		panel5.Name = "panel5";
		panel5.Size = new System.Drawing.Size(445, 485);
		panel5.TabIndex = 1;
		txtpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtpass.Location = new System.Drawing.Point(161, 280);
		txtpass.Name = "txtpass";
		txtpass.Size = new System.Drawing.Size(274, 31);
		txtpass.TabIndex = 17;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(24, 280);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(133, 25);
		label1.TabIndex = 16;
		label1.Text = "Contraseña";
		iD.AutoSize = true;
		iD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		iD.ForeColor = System.Drawing.Color.White;
		iD.Location = new System.Drawing.Point(24, 2);
		iD.Name = "iD";
		iD.Size = new System.Drawing.Size(0, 25);
		iD.TabIndex = 15;
		txtCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtCargo.FormattingEnabled = true;
		txtCargo.Items.AddRange(new object[3] { "Admin", "Cajero", "Capturista" });
		txtCargo.Location = new System.Drawing.Point(161, 425);
		txtCargo.Name = "txtCargo";
		txtCargo.Size = new System.Drawing.Size(274, 33);
		txtCargo.TabIndex = 14;
		txtCargo.Text = "Selecciona";
		txtCargo.TextChanged += new System.EventHandler(Cargo_TextChanged);
		label9.AutoSize = true;
		label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label9.Location = new System.Drawing.Point(24, 433);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(75, 25);
		label9.TabIndex = 13;
		label9.Text = "Cargo";
		txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtFecha.Location = new System.Drawing.Point(237, 349);
		txtFecha.Name = "txtFecha";
		txtFecha.Size = new System.Drawing.Size(198, 31);
		txtFecha.TabIndex = 12;
		label8.AutoSize = true;
		label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label8.Location = new System.Drawing.Point(24, 349);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(201, 25);
		label8.TabIndex = 11;
		label8.Text = "Fecha Nacimiento";
		txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtApellido.Location = new System.Drawing.Point(161, 211);
		txtApellido.Name = "txtApellido";
		txtApellido.Size = new System.Drawing.Size(274, 31);
		txtApellido.TabIndex = 10;
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label6.Location = new System.Drawing.Point(24, 211);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(125, 25);
		label6.TabIndex = 9;
		label6.Text = "Apellido(s)";
		txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtNombre.Location = new System.Drawing.Point(161, 130);
		txtNombre.Name = "txtNombre";
		txtNombre.Size = new System.Drawing.Size(274, 31);
		txtNombre.TabIndex = 8;
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label5.Location = new System.Drawing.Point(24, 133);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(121, 25);
		label5.TabIndex = 7;
		label5.Text = "Nombre(s)";
		label7.AutoSize = true;
		label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(24, 52);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(86, 25);
		label7.TabIndex = 6;
		label7.Text = "Codigo";
		txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtCodigo.Location = new System.Drawing.Point(161, 47);
		txtCodigo.Name = "txtCodigo";
		txtCodigo.Size = new System.Drawing.Size(274, 31);
		txtCodigo.TabIndex = 0;
		panel4.Controls.Add(DGVE);
		panel4.Location = new System.Drawing.Point(11, 55);
		panel4.Name = "panel4";
		panel4.Size = new System.Drawing.Size(372, 468);
		panel4.TabIndex = 0;
		DGVE.AllowUserToAddRows = false;
		DGVE.AllowUserToDeleteRows = false;
		DGVE.BackgroundColor = System.Drawing.Color.White;
		DGVE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGVE.GridColor = System.Drawing.Color.White;
		DGVE.Location = new System.Drawing.Point(3, 3);
		DGVE.Name = "DGVE";
		DGVE.Size = new System.Drawing.Size(366, 456);
		DGVE.TabIndex = 0;
		DGVE.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(DGVE_CellClick);
		txtruta.AutoSize = true;
		txtruta.ForeColor = System.Drawing.Color.White;
		txtruta.Location = new System.Drawing.Point(1126, 728);
		txtruta.Name = "txtruta";
		txtruta.Size = new System.Drawing.Size(0, 13);
		txtruta.TabIndex = 17;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1261, 740);
		base.Controls.Add(txtruta);
		base.Controls.Add(panel3);
		base.Controls.Add(panel1);
		base.Controls.Add(panel2);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Empleado";
		Text = "Empleado";
		base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		base.Load += new System.EventHandler(Empleado_Load);
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Empleado_KeyUp);
		panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)search).EndInit();
		((System.ComponentModel.ISupportInitialize)Delete).EndInit();
		((System.ComponentModel.ISupportInitialize)cancel).EndInit();
		((System.ComponentModel.ISupportInitialize)save).EndInit();
		((System.ComponentModel.ISupportInitialize)edit).EndInit();
		((System.ComponentModel.ISupportInitialize)add).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		panel16.ResumeLayout(false);
		panel16.PerformLayout();
		((System.ComponentModel.ISupportInitialize)image_user).EndInit();
		panel3.ResumeLayout(false);
		panel14.ResumeLayout(false);
		panel14.PerformLayout();
		panel13.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)btncaja).EndInit();
		((System.ComponentModel.ISupportInitialize)btnventas).EndInit();
		((System.ComponentModel.ISupportInitialize)btnreport).EndInit();
		panel12.ResumeLayout(false);
		panel12.PerformLayout();
		panel11.ResumeLayout(false);
		panel11.PerformLayout();
		panel10.ResumeLayout(false);
		panel10.PerformLayout();
		panel8.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)Imagen_U).EndInit();
		panel7.ResumeLayout(false);
		panel7.PerformLayout();
		panel6.ResumeLayout(false);
		panel6.PerformLayout();
		panel5.ResumeLayout(false);
		panel5.PerformLayout();
		panel4.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)DGVE).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}

// BLUPOINT.Entradas
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Entradas : Form
{
	private Caja box = new Caja();

	private string id = "";

	private string name;

	private IContainer components = null;

	private DataGridView dataGridView1;

	private Panel panel1;

	private PictureBox pictureBox2;

	private ToolTip toolTip1;

	private PictureBox pictureBox1;

	private Label lblfecha;

	private DateTimePicker dateTimePicker1;

	public Entradas(string nombre)
	{
		InitializeComponent();
		getEntradas();
		dateTimePicker1.Visible = false;
		lblfecha.Visible = false;
		name = nombre;
	}

	private void getEntradas()
	{
		box.Fecha = dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year;
		box.id_caja = LoadMoney();
		dataGridView1.DataSource = box.GETENTER();
		dataGridView1.Columns[0].Width = 100;
		dataGridView1.Columns[1].Width = 150;
		dataGridView1.Columns[2].Width = 250;
		dataGridView1.Columns[3].Width = 100;
		dataGridView1.Columns[4].Width = 100;
	}

	private string LoadMoney()
	{
		DataTable dataTable = new DataTable();
		try
		{
			dataTable = box.GETMONEY();
			id = dataTable.Rows[0]["idCaja"].ToString();
			return id;
		}
		catch
		{
			return id;
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		dateTimePicker1.Visible = true;
		lblfecha.Visible = true;
	}

	private void panel1_Paint(object sender, PaintEventArgs e)
	{
	}

	private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			try
			{
				Visualizar_entrada visualizar_entrada = new Visualizar_entrada(dataGridView1.CurrentRow.Cells["Concepto"].Value.ToString(), dataGridView1.CurrentRow.Cells["Tipo_Pago"].Value.ToString(), dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString(), dataGridView1.CurrentRow.Cells["Nombre_E"].Value.ToString(), dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString());
				visualizar_entrada.ShowDialog();
			}
			catch
			{
				MessageBox.Show("No se puede elegir un campo vacio");
			}
		}
	}

	private void pictureBox2_Click(object sender, EventArgs e)
	{
		try
		{
			Visualizar_entrada visualizar_entrada = new Visualizar_entrada(dataGridView1.CurrentRow.Cells["Concepto"].Value.ToString(), dataGridView1.CurrentRow.Cells["Tipo_Pago"].Value.ToString(), dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString(), dataGridView1.CurrentRow.Cells["Nombre_E"].Value.ToString(), dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString());
			visualizar_entrada.ShowDialog();
		}
		catch
		{
			MessageBox.Show("No se puede elegir un campo vacio");
		}
	}

	private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			try
			{
				box.Nombre_U = name;
				box.id_caja = id;
				box.Fecha = dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year;
				dataGridView1.DataSource = box.GETENTER();
			}
			catch
			{
				MessageBox.Show("Ha ocurrido un error contacta a soporte tecnico");
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
		components = new System.ComponentModel.Container();
		dataGridView1 = new System.Windows.Forms.DataGridView();
		panel1 = new System.Windows.Forms.Panel();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		lblfecha = new System.Windows.Forms.Label();
		dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
		toolTip1 = new System.Windows.Forms.ToolTip(components);
		((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		dataGridView1.AllowUserToAddRows = false;
		dataGridView1.AllowUserToDeleteRows = false;
		dataGridView1.AllowUserToResizeColumns = false;
		dataGridView1.AllowUserToResizeRows = false;
		dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(224, 224, 224);
		dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView1.Location = new System.Drawing.Point(4, 88);
		dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		dataGridView1.Name = "dataGridView1";
		dataGridView1.Size = new System.Drawing.Size(1227, 606);
		dataGridView1.TabIndex = 0;
		dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dataGridView1_KeyPress);
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(pictureBox2);
		panel1.Controls.Add(pictureBox1);
		panel1.Controls.Add(lblfecha);
		panel1.Controls.Add(dateTimePicker1);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(736, 78);
		panel1.TabIndex = 1;
		panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
		pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox2.Image = BLUPOINT.Properties.Resources.ver;
		pictureBox2.Location = new System.Drawing.Point(88, 18);
		pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(44, 48);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 3;
		pictureBox2.TabStop = false;
		toolTip1.SetToolTip(pictureBox2, "Vista Previa");
		pictureBox2.Click += new System.EventHandler(pictureBox2_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox1.Image = BLUPOINT.Properties.Resources.filtrar;
		pictureBox1.Location = new System.Drawing.Point(13, 15);
		pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(51, 48);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 2;
		pictureBox1.TabStop = false;
		toolTip1.SetToolTip(pictureBox1, "Filtrar por fecha");
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		lblfecha.AutoSize = true;
		lblfecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblfecha.Location = new System.Drawing.Point(504, 15);
		lblfecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		lblfecha.Name = "lblfecha";
		lblfecha.Size = new System.Drawing.Size(140, 24);
		lblfecha.TabIndex = 1;
		lblfecha.Text = "Filtrar por fecha";
		dateTimePicker1.CalendarFont = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dateTimePicker1.Location = new System.Drawing.Point(415, 44);
		dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		dateTimePicker1.Name = "dateTimePicker1";
		dateTimePicker1.Size = new System.Drawing.Size(308, 29);
		dateTimePicker1.TabIndex = 0;
		dateTimePicker1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dateTimePicker1_KeyPress);
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(736, 349);
		base.Controls.Add(panel1);
		base.Controls.Add(dataGridView1);
		Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		base.Name = "Entradas";
		Text = "Entradas";
		((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}
}

// BLUPOINT.errodbalert
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT.Properties;

public class errodbalert : Form
{
	private IContainer components = null;

	private Button button1;

	private Label Mesa;

	private Label label1;

	private PictureBox pictureBox1;

	public errodbalert()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Application.Exit();
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
		button1 = new System.Windows.Forms.Button();
		Mesa = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		button1.BackColor = System.Drawing.Color.FromArgb(54, 185, 219);
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(181, 400);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(166, 42);
		button1.TabIndex = 7;
		button1.Text = "Aceptar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		Mesa.AutoSize = true;
		Mesa.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Mesa.Location = new System.Drawing.Point(86, 222);
		Mesa.Name = "Mesa";
		Mesa.Size = new System.Drawing.Size(371, 147);
		Mesa.TabIndex = 6;
		Mesa.Text = "Ha ocurrido un error al crear la base de datos.\r\n\r\nPosibilidades:\r\n1. Tabla test no existente (versiones superiores a 5.6)\r\n2. Conector .Net \r\n3. Usuario incorrecto\r\n4. Contraseña Incorecta";
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 26.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(173, 163);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(193, 47);
		label1.TabIndex = 5;
		label1.Text = "ERROR DB";
		pictureBox1.Image = BLUPOINT.Properties.Resources.error;
		pictureBox1.Location = new System.Drawing.Point(206, 12);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(141, 131);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 4;
		pictureBox1.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(523, 452);
		base.Controls.Add(button1);
		base.Controls.Add(Mesa);
		base.Controls.Add(label1);
		base.Controls.Add(pictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "errodbalert";
		Text = "errodbalert";
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}

// BLUPOINT.Form1
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Form1 : Form
{
	public string respuesta;

	private Empleados emp = new Empleados();

	private Ventas ven = new Ventas();

	private Productos prod = new Productos();

	private Caja cj = new Caja();

	private string rutas;

	private string ids;

	private string cargo1;

	private string cargo2;

	private string cargo3;

	private string cargo4;

	private string idbox;

	private bool down = false;

	private bool verificarcaja;

	private Point inicial;

	private IContainer components = null;

	private Panel panel1;

	private Label Hora;

	private Panel panel2;

	private Timer timer1;

	private Panel panel16;

	private Label label19;

	private PictureBox image_user;

	private Label label18;

	private Label txtName;

	private Label txttipo_e;

	private DateTimePicker dtmpick;

	private PictureBox pictureBox8;

	private Button button7;

	private PictureBox pictureBox6;

	private Button button5;

	private PictureBox pictureBox5;

	private PictureBox pictureBox4;

	private Button button3;

	private Button button4;

	private PictureBox pictureBox3;

	private PictureBox pictureBox2;

	private Button button2;

	private Button button1;

	private PictureBox pictureBox1;

	private Button Productos;

	private Label label4;

	private ToolTip toolTip1;

	private Label label2;

	private Label label1;

	private GroupBox ventass;

	private Button button8;

	private PictureBox pictureBox7;

	private GroupBox groupBox1;

	private Button button12;

	private Panel panel3;

	private Label ven_tot;

	private Label label5;

	private PictureBox pictureBox10;

	private Panel panel4;

	private Label totalp;

	private Label label9;

	private GroupBox groupBox2;

	private Panel panel5;

	private Label profal;

	private Label label8;

	private PictureBox pictureBox11;

	private Button button9;

	private GroupBox groupBox3;

	private Panel panel6;

	private Label txtnp;

	private Label label11;

	private PictureBox pictureBox12;

	private Button button10;

	private GroupBox groupBox4;

	private Chart chart1;

	private Button button11;

	public Label txtmoney;

	private PictureBox pictureBox9;

	private Button button6;

	private Label label3;

	private TextBox textNombre_prod;

	private Label label6;

	public Form1(string nombre, string ruta, string cargo, string id, string car1, string car2, string car3, string car4)
	{
		InitializeComponent();
		Inicio();
		(from ctr in base.Controls.OfType<Control>()
			where ctr is GroupBox
			select ctr).ToList().ForEach(delegate(Control ctr)
		{
			ctr.MouseDown += Ctr_MouseDown;
			ctr.MouseUp += Ctr_MouseUp;
			ctr.MouseMove += Ctr_MouseMove;
		});
		base.KeyPreview = true;
		base.KeyDown += Form1_KeyUp;
		timer1.Enabled = true;
		txtName.Text = nombre;
		if (ruta == "")
		{
			image_user.Image = Resources.picture;
		}
		else
		{
			image_user.Image = Image.FromFile(ruta);
		}
		rutas = ruta;
		textNombre_prod.Select();
		txttipo_e.Text = cargo;
		ids = id;
		cargo1 = car1;
		cargo2 = car2;
		cargo3 = car3;
		cargo4 = car4;
		LoadGraph();
		LoadMoney();
		Visibles();
	}

	private void Visibles()
	{
		if (txttipo_e.Text == "Admin")
		{
			ventass.Visible = true;
			groupBox1.Visible = true;
			groupBox2.Visible = true;
			groupBox4.Visible = true;
		}
	}

	private void Inicio()
	{
		totalp.Text = prod.ProductosTotales();
		ven_tot.Text = ven.VentasTotales();
		profal.Text = prod.ProductosTotalesFalt();
		txtnp.Text = ven.ProdMasVendido();
	}

	public void LoadMoney()
	{
		DataTable dataTable = new DataTable();
		try
		{
			dataTable = cj.GETMONEY();
			txtmoney.Text = dataTable.Rows[0]["Cantidad"].ToString();
			idbox = dataTable.Rows[0]["idCaja"].ToString();
			verificarcaja = true;
		}
		catch
		{
			verificarcaja = false;
		}
	}

	private void Ctr_MouseMove(object sender, MouseEventArgs e)
	{
		Control control = (Control)sender;
		if (down)
		{
			control.Left = e.X + control.Left - inicial.X;
			control.Top = e.Y + control.Top - inicial.Y;
		}
	}

	private void LoadGraph()
	{
		int num = Convert.ToInt32(totalp.Text);
		int num2 = Convert.ToInt32(ven_tot.Text);
		int num3 = Convert.ToInt32(emp.EmpleadosTotales());
		string[] array = new string[3] { "Productos", "Ventas", "Empleados" };
		int[] array2 = new int[3] { num, num2, num3 };
		chart1.Palette = ChartColorPalette.Pastel;
		chart1.Titles.Add("Graficas");
		for (int i = 0; i < array.Length; i++)
		{
			Series series = chart1.Series.Add(array[i]);
			series.Label = array2[i].ToString();
			series.Points.Add(array2[i]);
		}
	}

	private void Ctr_MouseUp(object sender, MouseEventArgs e)
	{
		down = false;
	}

	private void Ctr_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			down = true;
			inicial = e.Location;
		}
	}

	private void Form1_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			return;
		}
		if (e.KeyCode == Keys.NumPad1)
		{
			if (cargo1 == "1")
			{
				Hide();
				Producto producto = new Producto(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
				producto.Show();
			}
			else
			{
				MessageBox.Show("No tienes Permiso para acceder a Productos");
			}
		}
		else if (e.KeyCode == Keys.NumPad2)
		{
			if (cargo2 == "1")
			{
				Hide();
				Empleado empleado = new Empleado(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
				empleado.Show();
			}
			else
			{
				MessageBox.Show("No tienes Permiso para acceder a Empleados");
			}
		}
		else if (e.KeyCode == Keys.NumPad5)
		{
			Hide();
			Venta venta = new Venta(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
			venta.Show();
		}
		else if (e.KeyCode == Keys.NumPad4)
		{
			if (txttipo_e.Text == "Admin")
			{
				Proveedor proveedor = new Proveedor("");
				proveedor.Show();
			}
			else
			{
				MessageBox.Show("Solo el Administrador Puede Acceder a esta Opcion");
			}
		}
		else if (e.KeyCode == Keys.NumPad3)
		{
			if (cargo3 == "1")
			{
				Hide();
				Cliente cliente = new Cliente(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
				cliente.Show();
			}
			else
			{
				MessageBox.Show("No tienes Permiso para acceder a Clientes");
			}
		}
	}

	private void Form1_FormClosing(object sender, FormClosingEventArgs e)
	{
		emp.id = ids;
		emp.Fecha_N = dtmpick.Value.Hour + ":" + dtmpick.Value.Minute + ":" + dtmpick.Value.Second;
		string fecha = dtmpick.Value.Day + "/" + dtmpick.Value.Month + "/" + dtmpick.Value.Year;
		if (emp.Salida(fecha) == 1)
		{
			Application.Exit();
		}
		else
		{
			Show();
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		Hora.Text = DateTime.Now.ToString();
	}

	private void timer1_Tick_1(object sender, EventArgs e)
	{
		Hora.Text = DateTime.Now.ToString();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Hide();
		Producto producto = new Producto(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
		producto.Show();
	}

	private void Productos_Click_1(object sender, EventArgs e)
	{
		if (cargo1 == "1")
		{
			Hide();
			Producto producto = new Producto(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
			producto.Show();
		}
		else
		{
			Alert_Error alert_Error = new Alert_Error("No Tienes permiso para acceder");
			alert_Error.ShowDialog();
		}
	}

	private void button7_Click(object sender, EventArgs e)
	{
		CerrarCaja();
	}

	private void button8_Click(object sender, EventArgs e)
	{
		ventass.Visible = false;
	}

	private void button9_Click(object sender, EventArgs e)
	{
	}

	private void button10_Click(object sender, EventArgs e)
	{
		if (cargo1 == "1")
		{
			Hide();
			Producto producto = new Producto(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
			producto.Show();
		}
		else
		{
			Alert_Error alert_Error = new Alert_Error("No Tienes permiso para acceder");
			alert_Error.ShowDialog();
		}
	}

	private void button5_Click(object sender, EventArgs e)
	{
		if (txttipo_e.Text == "Admin" || cargo4 == "1")
		{
			Box box = new Box(txtName.Text, txttipo_e.Text, cargo4);
			AddOwnedForm(box);
			box.Show();
		}
		else if (verificarcaja)
		{
			Corte_Caja2 corte_Caja = new Corte_Caja2(txtName.Text, txttipo_e.Text);
			AddOwnedForm(corte_Caja);
			corte_Caja.Show();
		}
		else
		{
			Alert_Error alert_Error = new Alert_Error("No hay Caja Asignada, ErrCod: 980");
			alert_Error.ShowDialog();
		}
	}

	private void button12_Click(object sender, EventArgs e)
	{
		groupBox1.Visible = false;
	}

	private void button11_Click(object sender, EventArgs e)
	{
		groupBox4.Visible = false;
	}

	private void button9_Click_1(object sender, EventArgs e)
	{
		groupBox2.Visible = false;
	}

	private void button10_Click_1(object sender, EventArgs e)
	{
		groupBox3.Visible = false;
	}

	private void panel5_DoubleClick(object sender, EventArgs e)
	{
		if (!(profal.Text == ""))
		{
			Ver_productos ver_productos = new Ver_productos();
			ver_productos.ShowDialog();
		}
	}

	private void button6_Click(object sender, EventArgs e)
	{
		if (txttipo_e.Text == "Admin")
		{
			Editar_Negocio editar_Negocio = new Editar_Negocio();
			editar_Negocio.ShowDialog();
		}
	}

	private void textNp_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			try
			{
				ProdInfo prodInfo = new ProdInfo(textNombre_prod.Text);
				prodInfo.ShowDialog();
				textNombre_prod.Text = "";
			}
			catch
			{
				Alert_Error alert_Error = new Alert_Error("Producto No Existente....");
				alert_Error.ShowDialog();
				textNombre_prod.Text = "";
			}
		}
	}

	private void button3_Click(object sender, EventArgs e)
	{
		Hide();
		Venta venta = new Venta(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
		venta.Show();
	}

	private void button1_Click_1(object sender, EventArgs e)
	{
		if (cargo2 == "1")
		{
			Hide();
			Empleado empleado = new Empleado(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
			empleado.Show();
		}
		else
		{
			Alert_Error alert_Error = new Alert_Error("No Tienes permiso para acceder");
			alert_Error.ShowDialog();
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		if (cargo3 == "1")
		{
			Hide();
			Cliente cliente = new Cliente(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
			cliente.Show();
		}
		else
		{
			Alert_Error alert_Error = new Alert_Error("No Tienes permiso para acceder");
			alert_Error.ShowDialog();
		}
	}

	private void button4_Click(object sender, EventArgs e)
	{
		if (txttipo_e.Text == "Admin")
		{
			Proveedor proveedor = new Proveedor("");
			proveedor.Show();
		}
		else
		{
			Alert_Error alert_Error = new Alert_Error("Usuario sin permisos suficientes");
			alert_Error.ShowDialog();
		}
	}

	private void Productos_Click(object sender, EventArgs e)
	{
	}

	private string Selectdate(string mont)
	{
		return mont switch
		{
			"1" => "Enero", 
			"2" => "Febrero", 
			"3" => "Marzo", 
			"4" => "Abril", 
			"5" => "Mayo", 
			"6" => "Junio", 
			"7" => "Julio", 
			"8" => "Agosto", 
			"9" => "Septiembre", 
			"10" => "Octubre", 
			"11" => "Noviembre", 
			"12" => "Diciembre", 
			_ => "", 
		};
	}

	private void CerrarCaja()
	{
		if (verificarcaja)
		{
			Caja caja = new Caja();
			DateTime now = DateTime.Now;
			string text = "";
			text = ((dtmpick.Value.Day.ToString().Length < 2) ? ("0" + dtmpick.Value.Day + "/" + Selectdate(dtmpick.Value.Month.ToString()) + "/" + dtmpick.Value.Year) : (dtmpick.Value.Day + "/" + Selectdate(dtmpick.Value.Month.ToString()) + "/" + dtmpick.Value.Year));
			caja.id_caja = idbox;
			caja.Fecha = text;
			emp.id = ids;
			caja.Usuario = txtName.Text;
			if (emp.VerificarTurno(text) == "1")
			{
				if (caja.VerificarDato() == "1")
				{
					emp.Fecha_N = now.ToString("hh:mm:ss tt");
					if (emp.Salida(text) == 1)
					{
						Application.Exit();
					}
					else
					{
						Show();
					}
					return;
				}
				alert_danger alert_danger2 = new alert_danger("Cerrar Sesion??", "No has cerrado la Caja. Te gustaria cerrarla ya?");
				AddOwnedForm(alert_danger2);
				alert_danger2.ShowDialog();
				if (respuesta == "Si")
				{
					if (txttipo_e.Text == "Admin")
					{
						Corte_Caja corte_Caja = new Corte_Caja(txtName.Text, txttipo_e.Text);
						corte_Caja.ShowDialog();
					}
					else
					{
						Corte_Caja2 corte_Caja2 = new Corte_Caja2(txtName.Text, txttipo_e.Text);
						corte_Caja2.ShowDialog();
					}
				}
				else if (txttipo_e.Text == "Admin")
				{
					Application.Exit();
				}
			}
			else
			{
				if (!(emp.VerificarTurno(text) == "2"))
				{
					return;
				}
				if (caja.VerificarDato() == "2")
				{
					emp.id = ids;
					string text4 = (emp.Fecha_N = (emp.Fecha_N = now.ToString("hh:mm:ss tt")));
					if (emp.Salida(text) == 1)
					{
						Application.Exit();
					}
					else
					{
						Show();
					}
					return;
				}
				alert_danger alert_danger3 = new alert_danger("Cerrar Sesion??", "No has cerrado la Caja. Te gustaria cerrarla ya?");
				AddOwnedForm(alert_danger3);
				alert_danger3.ShowDialog();
				if (respuesta == "Si")
				{
					if (txttipo_e.Text == "Admin")
					{
						Corte_Caja corte_Caja3 = new Corte_Caja(txtName.Text, txttipo_e.Text);
						corte_Caja3.ShowDialog();
					}
					else
					{
						Corte_Caja2 corte_Caja4 = new Corte_Caja2(txtName.Text, txttipo_e.Text);
						corte_Caja4.ShowDialog();
					}
				}
				else if (txttipo_e.Text == "Admin")
				{
					Application.Exit();
				}
			}
		}
		else
		{
			Application.Exit();
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
		components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Form1));
		System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
		System.Windows.Forms.DataVisualization.Charting.Legend legend = new System.Windows.Forms.DataVisualization.Charting.Legend();
		panel1 = new System.Windows.Forms.Panel();
		label3 = new System.Windows.Forms.Label();
		textNombre_prod = new System.Windows.Forms.TextBox();
		label4 = new System.Windows.Forms.Label();
		txtmoney = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		dtmpick = new System.Windows.Forms.DateTimePicker();
		panel16 = new System.Windows.Forms.Panel();
		txttipo_e = new System.Windows.Forms.Label();
		label19 = new System.Windows.Forms.Label();
		image_user = new System.Windows.Forms.PictureBox();
		label18 = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.Label();
		Hora = new System.Windows.Forms.Label();
		panel2 = new System.Windows.Forms.Panel();
		pictureBox9 = new System.Windows.Forms.PictureBox();
		button6 = new System.Windows.Forms.Button();
		pictureBox8 = new System.Windows.Forms.PictureBox();
		button7 = new System.Windows.Forms.Button();
		pictureBox6 = new System.Windows.Forms.PictureBox();
		button5 = new System.Windows.Forms.Button();
		pictureBox5 = new System.Windows.Forms.PictureBox();
		pictureBox4 = new System.Windows.Forms.PictureBox();
		button3 = new System.Windows.Forms.Button();
		button4 = new System.Windows.Forms.Button();
		pictureBox3 = new System.Windows.Forms.PictureBox();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		button2 = new System.Windows.Forms.Button();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		Productos = new System.Windows.Forms.Button();
		timer1 = new System.Windows.Forms.Timer(components);
		toolTip1 = new System.Windows.Forms.ToolTip(components);
		ventass = new System.Windows.Forms.GroupBox();
		panel3 = new System.Windows.Forms.Panel();
		ven_tot = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		pictureBox7 = new System.Windows.Forms.PictureBox();
		button8 = new System.Windows.Forms.Button();
		groupBox1 = new System.Windows.Forms.GroupBox();
		panel4 = new System.Windows.Forms.Panel();
		totalp = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		pictureBox10 = new System.Windows.Forms.PictureBox();
		button12 = new System.Windows.Forms.Button();
		groupBox2 = new System.Windows.Forms.GroupBox();
		panel5 = new System.Windows.Forms.Panel();
		profal = new System.Windows.Forms.Label();
		label8 = new System.Windows.Forms.Label();
		pictureBox11 = new System.Windows.Forms.PictureBox();
		button9 = new System.Windows.Forms.Button();
		groupBox3 = new System.Windows.Forms.GroupBox();
		panel6 = new System.Windows.Forms.Panel();
		txtnp = new System.Windows.Forms.Label();
		label11 = new System.Windows.Forms.Label();
		pictureBox12 = new System.Windows.Forms.PictureBox();
		button10 = new System.Windows.Forms.Button();
		groupBox4 = new System.Windows.Forms.GroupBox();
		chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
		button11 = new System.Windows.Forms.Button();
		label6 = new System.Windows.Forms.Label();
		panel1.SuspendLayout();
		panel16.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)image_user).BeginInit();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		ventass.SuspendLayout();
		panel3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
		groupBox1.SuspendLayout();
		panel4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
		groupBox2.SuspendLayout();
		panel5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
		groupBox3.SuspendLayout();
		panel6.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox12).BeginInit();
		groupBox4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(label3);
		panel1.Controls.Add(textNombre_prod);
		panel1.Controls.Add(label4);
		panel1.Controls.Add(txtmoney);
		panel1.Controls.Add(label2);
		panel1.Controls.Add(label1);
		panel1.Controls.Add(dtmpick);
		panel1.Controls.Add(panel16);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(127, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(1259, 64);
		panel1.TabIndex = 10;
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(398, 7);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(190, 21);
		label3.TabIndex = 8;
		label3.Text = "Acceso Rapido a Prodcuto";
		textNombre_prod.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		textNombre_prod.Location = new System.Drawing.Point(357, 30);
		textNombre_prod.Name = "textNombre_prod";
		textNombre_prod.Size = new System.Drawing.Size(260, 31);
		textNombre_prod.TabIndex = 7;
		textNombre_prod.KeyUp += new System.Windows.Forms.KeyEventHandler(textNp_KeyUp);
		label4.AutoSize = true;
		label4.Cursor = System.Windows.Forms.Cursors.Hand;
		label4.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label4.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
		label4.Location = new System.Drawing.Point(35, 46);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(54, 15);
		label4.TabIndex = 6;
		label4.Text = "Verificar";
		toolTip1.SetToolTip(label4, "Ctrl + V, Muestra la cantidad de veces que la caja se ha abierto");
		txtmoney.AutoSize = true;
		txtmoney.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtmoney.Location = new System.Drawing.Point(49, 3);
		txtmoney.Name = "txtmoney";
		txtmoney.Size = new System.Drawing.Size(36, 25);
		txtmoney.TabIndex = 5;
		txtmoney.Text = "0.0";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(33, 0);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(22, 25);
		label2.TabIndex = 4;
		label2.Text = "$";
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(5, 25);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(127, 21);
		label1.TabIndex = 3;
		label1.Text = "Cantidad en Caja";
		dtmpick.Location = new System.Drawing.Point(742, 12);
		dtmpick.Name = "dtmpick";
		dtmpick.Size = new System.Drawing.Size(200, 20);
		dtmpick.TabIndex = 2;
		dtmpick.Visible = false;
		panel16.Controls.Add(txttipo_e);
		panel16.Controls.Add(label19);
		panel16.Controls.Add(image_user);
		panel16.Controls.Add(label18);
		panel16.Controls.Add(txtName);
		panel16.Dock = System.Windows.Forms.DockStyle.Right;
		panel16.Location = new System.Drawing.Point(948, 0);
		panel16.Name = "panel16";
		panel16.Size = new System.Drawing.Size(311, 64);
		panel16.TabIndex = 1;
		txttipo_e.AutoSize = true;
		txttipo_e.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttipo_e.Location = new System.Drawing.Point(171, 42);
		txttipo_e.Name = "txttipo_e";
		txttipo_e.Size = new System.Drawing.Size(49, 18);
		txttipo_e.TabIndex = 29;
		txttipo_e.Text = "Admin";
		label19.AutoSize = true;
		label19.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
		label19.Location = new System.Drawing.Point(207, 29);
		label19.Name = "label19";
		label19.Size = new System.Drawing.Size(37, 13);
		label19.TabIndex = 27;
		label19.Text = "Activo";
		image_user.Image = (System.Drawing.Image)resources.GetObject("image_user.Image");
		image_user.Location = new System.Drawing.Point(257, 0);
		image_user.Name = "image_user";
		image_user.Size = new System.Drawing.Size(54, 50);
		image_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		image_user.TabIndex = 24;
		image_user.TabStop = false;
		label18.AutoSize = true;
		label18.ForeColor = System.Drawing.SystemColors.AppWorkspace;
		label18.Location = new System.Drawing.Point(171, 29);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(37, 13);
		label18.TabIndex = 26;
		label18.Text = "Status";
		txtName.AutoSize = true;
		txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtName.Location = new System.Drawing.Point(3, 4);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(197, 24);
		txtName.TabIndex = 25;
		txtName.Text = "Jorge Lemus Stripsent";
		Hora.AutoSize = true;
		Hora.BackColor = System.Drawing.Color.Transparent;
		Hora.Font = new System.Drawing.Font("Segoe UI", 27.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Hora.ForeColor = System.Drawing.Color.CadetBlue;
		Hora.Location = new System.Drawing.Point(916, 670);
		Hora.Name = "Hora";
		Hora.Size = new System.Drawing.Size(158, 50);
		Hora.TabIndex = 9;
		Hora.Text = "00:00:00";
		panel2.BackColor = System.Drawing.Color.White;
		panel2.Controls.Add(label6);
		panel2.Controls.Add(pictureBox9);
		panel2.Controls.Add(button6);
		panel2.Controls.Add(pictureBox8);
		panel2.Controls.Add(button7);
		panel2.Controls.Add(pictureBox6);
		panel2.Controls.Add(button5);
		panel2.Controls.Add(pictureBox5);
		panel2.Controls.Add(pictureBox4);
		panel2.Controls.Add(button3);
		panel2.Controls.Add(button4);
		panel2.Controls.Add(pictureBox3);
		panel2.Controls.Add(pictureBox2);
		panel2.Controls.Add(button2);
		panel2.Controls.Add(button1);
		panel2.Controls.Add(pictureBox1);
		panel2.Controls.Add(Productos);
		panel2.Dock = System.Windows.Forms.DockStyle.Left;
		panel2.Location = new System.Drawing.Point(0, 0);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(127, 682);
		panel2.TabIndex = 6;
		pictureBox9.BackColor = System.Drawing.Color.Transparent;
		pictureBox9.Image = BLUPOINT.Properties.Resources.tienda;
		pictureBox9.Location = new System.Drawing.Point(15, 496);
		pictureBox9.Name = "pictureBox9";
		pictureBox9.Size = new System.Drawing.Size(27, 24);
		pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox9.TabIndex = 40;
		pictureBox9.TabStop = false;
		button6.BackColor = System.Drawing.Color.White;
		button6.Cursor = System.Windows.Forms.Cursors.Hand;
		button6.FlatAppearance.BorderSize = 0;
		button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
		button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button6.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button6.ForeColor = System.Drawing.Color.Black;
		button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		button6.Location = new System.Drawing.Point(-1, 478);
		button6.Name = "button6";
		button6.Size = new System.Drawing.Size(127, 64);
		button6.TabIndex = 39;
		button6.Text = "Negocio";
		button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		button6.UseVisualStyleBackColor = false;
		button6.Click += new System.EventHandler(button6_Click);
		pictureBox8.BackColor = System.Drawing.Color.Transparent;
		pictureBox8.Image = BLUPOINT.Properties.Resources.boton_de_encendido;
		pictureBox8.Location = new System.Drawing.Point(13, 569);
		pictureBox8.Name = "pictureBox8";
		pictureBox8.Size = new System.Drawing.Size(27, 24);
		pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox8.TabIndex = 38;
		pictureBox8.TabStop = false;
		button7.BackColor = System.Drawing.Color.White;
		button7.Cursor = System.Windows.Forms.Cursors.Hand;
		button7.FlatAppearance.BorderSize = 0;
		button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
		button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button7.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button7.ForeColor = System.Drawing.Color.Black;
		button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		button7.Location = new System.Drawing.Point(-1, 551);
		button7.Name = "button7";
		button7.Size = new System.Drawing.Size(127, 64);
		button7.TabIndex = 37;
		button7.Text = "Salir";
		button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		button7.UseVisualStyleBackColor = false;
		button7.Click += new System.EventHandler(button7_Click);
		pictureBox6.BackColor = System.Drawing.Color.Transparent;
		pictureBox6.Image = BLUPOINT.Properties.Resources.cajero_automatico;
		pictureBox6.Location = new System.Drawing.Point(14, 420);
		pictureBox6.Name = "pictureBox6";
		pictureBox6.Size = new System.Drawing.Size(27, 24);
		pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox6.TabIndex = 34;
		pictureBox6.TabStop = false;
		button5.BackColor = System.Drawing.Color.White;
		button5.Cursor = System.Windows.Forms.Cursors.Hand;
		button5.FlatAppearance.BorderSize = 0;
		button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
		button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button5.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button5.ForeColor = System.Drawing.Color.Black;
		button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		button5.Location = new System.Drawing.Point(0, 397);
		button5.Name = "button5";
		button5.Size = new System.Drawing.Size(127, 64);
		button5.TabIndex = 33;
		button5.Text = "Caja\r\n";
		button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		button5.UseVisualStyleBackColor = false;
		button5.Click += new System.EventHandler(button5_Click);
		pictureBox5.BackColor = System.Drawing.Color.Transparent;
		pictureBox5.Image = BLUPOINT.Properties.Resources.produccion;
		pictureBox5.Location = new System.Drawing.Point(14, 291);
		pictureBox5.Name = "pictureBox5";
		pictureBox5.Size = new System.Drawing.Size(27, 24);
		pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox5.TabIndex = 32;
		pictureBox5.TabStop = false;
		pictureBox4.BackColor = System.Drawing.Color.Transparent;
		pictureBox4.Image = BLUPOINT.Properties.Resources.carro;
		pictureBox4.Location = new System.Drawing.Point(14, 352);
		pictureBox4.Name = "pictureBox4";
		pictureBox4.Size = new System.Drawing.Size(27, 24);
		pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox4.TabIndex = 31;
		pictureBox4.TabStop = false;
		button3.BackColor = System.Drawing.Color.White;
		button3.Cursor = System.Windows.Forms.Cursors.Hand;
		button3.FlatAppearance.BorderSize = 0;
		button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
		button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button3.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button3.ForeColor = System.Drawing.Color.Black;
		button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		button3.Location = new System.Drawing.Point(0, 332);
		button3.Name = "button3";
		button3.Size = new System.Drawing.Size(127, 64);
		button3.TabIndex = 30;
		button3.Text = "Realizar\r\nVenta\r\n";
		button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		button3.UseVisualStyleBackColor = false;
		button3.Click += new System.EventHandler(button3_Click);
		button4.BackColor = System.Drawing.Color.White;
		button4.Cursor = System.Windows.Forms.Cursors.Hand;
		button4.FlatAppearance.BorderSize = 0;
		button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
		button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button4.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button4.ForeColor = System.Drawing.Color.Black;
		button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		button4.Location = new System.Drawing.Point(0, 268);
		button4.Name = "button4";
		button4.Size = new System.Drawing.Size(127, 64);
		button4.TabIndex = 29;
		button4.Text = "Proveedor";
		button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		button4.UseVisualStyleBackColor = false;
		button4.Click += new System.EventHandler(button4_Click);
		pictureBox3.BackColor = System.Drawing.Color.Transparent;
		pictureBox3.Image = BLUPOINT.Properties.Resources.empleado;
		pictureBox3.Location = new System.Drawing.Point(13, 164);
		pictureBox3.Name = "pictureBox3";
		pictureBox3.Size = new System.Drawing.Size(27, 24);
		pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox3.TabIndex = 28;
		pictureBox3.TabStop = false;
		pictureBox2.BackColor = System.Drawing.Color.Transparent;
		pictureBox2.Image = BLUPOINT.Properties.Resources.cliente;
		pictureBox2.Location = new System.Drawing.Point(13, 227);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(27, 24);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 27;
		pictureBox2.TabStop = false;
		button2.BackColor = System.Drawing.Color.White;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatAppearance.BorderSize = 0;
		button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
		button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.Black;
		button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		button2.Location = new System.Drawing.Point(0, 207);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(127, 64);
		button2.TabIndex = 26;
		button2.Text = "Clientes";
		button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		button2.UseVisualStyleBackColor = false;
		button2.Click += new System.EventHandler(button2_Click);
		button1.BackColor = System.Drawing.Color.White;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
		button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.Black;
		button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		button1.Location = new System.Drawing.Point(0, 143);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(127, 64);
		button1.TabIndex = 25;
		button1.Text = "Empleado";
		button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click_1);
		pictureBox1.BackColor = System.Drawing.Color.Transparent;
		pictureBox1.Image = BLUPOINT.Properties.Resources.producto;
		pictureBox1.Location = new System.Drawing.Point(13, 99);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(27, 24);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 23;
		pictureBox1.TabStop = false;
		Productos.BackColor = System.Drawing.Color.White;
		Productos.Cursor = System.Windows.Forms.Cursors.Hand;
		Productos.FlatAppearance.BorderSize = 0;
		Productos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
		Productos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		Productos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		Productos.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Productos.ForeColor = System.Drawing.Color.Black;
		Productos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		Productos.Location = new System.Drawing.Point(-1, 79);
		Productos.Name = "Productos";
		Productos.Size = new System.Drawing.Size(127, 64);
		Productos.TabIndex = 24;
		Productos.Text = "Productos";
		Productos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		Productos.UseVisualStyleBackColor = false;
		Productos.Click += new System.EventHandler(Productos_Click_1);
		timer1.Tick += new System.EventHandler(timer1_Tick_1);
		ventass.BackColor = System.Drawing.Color.White;
		ventass.Controls.Add(panel3);
		ventass.Controls.Add(pictureBox7);
		ventass.Controls.Add(button8);
		ventass.Location = new System.Drawing.Point(220, 143);
		ventass.Name = "ventass";
		ventass.Size = new System.Drawing.Size(349, 196);
		ventass.TabIndex = 11;
		ventass.TabStop = false;
		ventass.Visible = false;
		panel3.BackColor = System.Drawing.Color.FromArgb(43, 54, 80);
		panel3.Controls.Add(ven_tot);
		panel3.Controls.Add(label5);
		panel3.Location = new System.Drawing.Point(1, 147);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(349, 47);
		panel3.TabIndex = 1;
		ven_tot.AutoSize = true;
		ven_tot.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ven_tot.ForeColor = System.Drawing.Color.FromArgb(97, 177, 176);
		ven_tot.Location = new System.Drawing.Point(242, 5);
		ven_tot.Name = "ven_tot";
		ven_tot.Size = new System.Drawing.Size(54, 32);
		ven_tot.TabIndex = 1;
		ven_tot.Text = "120";
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.ForeColor = System.Drawing.Color.White;
		label5.Location = new System.Drawing.Point(34, 7);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(175, 30);
		label5.TabIndex = 0;
		label5.Text = "VENTAS TOTALES";
		pictureBox7.Image = BLUPOINT.Properties.Resources.ven_tot;
		pictureBox7.Location = new System.Drawing.Point(118, 10);
		pictureBox7.Name = "pictureBox7";
		pictureBox7.Size = new System.Drawing.Size(115, 122);
		pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox7.TabIndex = 1;
		pictureBox7.TabStop = false;
		button8.BackColor = System.Drawing.Color.Maroon;
		button8.Cursor = System.Windows.Forms.Cursors.Hand;
		button8.FlatAppearance.BorderSize = 0;
		button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button8.ForeColor = System.Drawing.Color.White;
		button8.Location = new System.Drawing.Point(309, 0);
		button8.Name = "button8";
		button8.Size = new System.Drawing.Size(40, 23);
		button8.TabIndex = 0;
		button8.Text = "X";
		button8.UseVisualStyleBackColor = false;
		button8.Click += new System.EventHandler(button8_Click);
		groupBox1.BackColor = System.Drawing.Color.White;
		groupBox1.Controls.Add(panel4);
		groupBox1.Controls.Add(pictureBox10);
		groupBox1.Controls.Add(button12);
		groupBox1.Location = new System.Drawing.Point(221, 369);
		groupBox1.Name = "groupBox1";
		groupBox1.Size = new System.Drawing.Size(348, 255);
		groupBox1.TabIndex = 13;
		groupBox1.TabStop = false;
		groupBox1.Visible = false;
		panel4.BackColor = System.Drawing.Color.FromArgb(43, 54, 80);
		panel4.Controls.Add(totalp);
		panel4.Controls.Add(label9);
		panel4.Location = new System.Drawing.Point(0, 187);
		panel4.Name = "panel4";
		panel4.Size = new System.Drawing.Size(349, 64);
		panel4.TabIndex = 2;
		totalp.AutoSize = true;
		totalp.Font = new System.Drawing.Font("Segoe UI", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		totalp.ForeColor = System.Drawing.Color.FromArgb(97, 177, 176);
		totalp.Location = new System.Drawing.Point(240, 12);
		totalp.Name = "totalp";
		totalp.Size = new System.Drawing.Size(77, 47);
		totalp.TabIndex = 1;
		totalp.Text = "120";
		label9.AutoSize = true;
		label9.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label9.ForeColor = System.Drawing.Color.White;
		label9.Location = new System.Drawing.Point(6, 4);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(148, 60);
		label9.TabIndex = 0;
		label9.Text = "CANTIDAD DE\r\n PRODUCTOS";
		pictureBox10.Image = BLUPOINT.Properties.Resources.caja;
		pictureBox10.Location = new System.Drawing.Point(107, 34);
		pictureBox10.Name = "pictureBox10";
		pictureBox10.Size = new System.Drawing.Size(143, 139);
		pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox10.TabIndex = 2;
		pictureBox10.TabStop = false;
		button12.BackColor = System.Drawing.Color.Maroon;
		button12.Cursor = System.Windows.Forms.Cursors.Hand;
		button12.FlatAppearance.BorderSize = 0;
		button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button12.ForeColor = System.Drawing.Color.White;
		button12.Location = new System.Drawing.Point(308, 3);
		button12.Name = "button12";
		button12.Size = new System.Drawing.Size(41, 23);
		button12.TabIndex = 0;
		button12.Text = "X";
		button12.UseVisualStyleBackColor = false;
		button12.Click += new System.EventHandler(button12_Click);
		groupBox2.BackColor = System.Drawing.Color.White;
		groupBox2.Controls.Add(panel5);
		groupBox2.Controls.Add(pictureBox11);
		groupBox2.Controls.Add(button9);
		groupBox2.Cursor = System.Windows.Forms.Cursors.Hand;
		groupBox2.Location = new System.Drawing.Point(620, 143);
		groupBox2.Name = "groupBox2";
		groupBox2.Size = new System.Drawing.Size(349, 212);
		groupBox2.TabIndex = 12;
		groupBox2.TabStop = false;
		groupBox2.Visible = false;
		panel5.BackColor = System.Drawing.Color.FromArgb(43, 54, 80);
		panel5.Controls.Add(profal);
		panel5.Controls.Add(label8);
		panel5.Location = new System.Drawing.Point(1, 147);
		panel5.Name = "panel5";
		panel5.Size = new System.Drawing.Size(349, 65);
		panel5.TabIndex = 1;
		panel5.DoubleClick += new System.EventHandler(panel5_DoubleClick);
		profal.AutoSize = true;
		profal.Font = new System.Drawing.Font("Segoe UI", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		profal.ForeColor = System.Drawing.Color.FromArgb(97, 177, 176);
		profal.Location = new System.Drawing.Point(262, 7);
		profal.Name = "profal";
		profal.Size = new System.Drawing.Size(77, 47);
		profal.TabIndex = 1;
		profal.Text = "120";
		label8.AutoSize = true;
		label8.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label8.ForeColor = System.Drawing.Color.White;
		label8.Location = new System.Drawing.Point(3, 1);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(244, 60);
		label8.TabIndex = 0;
		label8.Text = "PRODUCTOS FALTANTES\r\n       EN ALMACEN";
		pictureBox11.Image = BLUPOINT.Properties.Resources.almacen;
		pictureBox11.Location = new System.Drawing.Point(118, 10);
		pictureBox11.Name = "pictureBox11";
		pictureBox11.Size = new System.Drawing.Size(115, 122);
		pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox11.TabIndex = 1;
		pictureBox11.TabStop = false;
		button9.BackColor = System.Drawing.Color.Maroon;
		button9.Cursor = System.Windows.Forms.Cursors.Hand;
		button9.FlatAppearance.BorderSize = 0;
		button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button9.ForeColor = System.Drawing.Color.White;
		button9.Location = new System.Drawing.Point(309, 0);
		button9.Name = "button9";
		button9.Size = new System.Drawing.Size(40, 23);
		button9.TabIndex = 0;
		button9.Text = "X";
		button9.UseVisualStyleBackColor = false;
		button9.Click += new System.EventHandler(button9_Click_1);
		groupBox3.BackColor = System.Drawing.Color.White;
		groupBox3.Controls.Add(panel6);
		groupBox3.Controls.Add(pictureBox12);
		groupBox3.Controls.Add(button10);
		groupBox3.Location = new System.Drawing.Point(1007, 139);
		groupBox3.Name = "groupBox3";
		groupBox3.Size = new System.Drawing.Size(349, 212);
		groupBox3.TabIndex = 13;
		groupBox3.TabStop = false;
		panel6.BackColor = System.Drawing.Color.FromArgb(43, 54, 80);
		panel6.Controls.Add(txtnp);
		panel6.Controls.Add(label11);
		panel6.Location = new System.Drawing.Point(1, 147);
		panel6.Name = "panel6";
		panel6.Size = new System.Drawing.Size(349, 65);
		panel6.TabIndex = 1;
		txtnp.AutoSize = true;
		txtnp.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtnp.ForeColor = System.Drawing.Color.FromArgb(97, 177, 176);
		txtnp.Location = new System.Drawing.Point(181, 15);
		txtnp.Name = "txtnp";
		txtnp.Size = new System.Drawing.Size(126, 32);
		txtnp.TabIndex = 1;
		txtnp.Text = "Nombre_P";
		label11.AutoSize = true;
		label11.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label11.ForeColor = System.Drawing.Color.White;
		label11.Location = new System.Drawing.Point(3, 1);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(172, 60);
		label11.TabIndex = 0;
		label11.Text = "PRODUCTO MAS\r\n    VENDIDO\r\n";
		pictureBox12.Image = BLUPOINT.Properties.Resources.picture;
		pictureBox12.Location = new System.Drawing.Point(118, 10);
		pictureBox12.Name = "pictureBox12";
		pictureBox12.Size = new System.Drawing.Size(115, 122);
		pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox12.TabIndex = 1;
		pictureBox12.TabStop = false;
		button10.BackColor = System.Drawing.Color.Maroon;
		button10.Cursor = System.Windows.Forms.Cursors.Hand;
		button10.FlatAppearance.BorderSize = 0;
		button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button10.ForeColor = System.Drawing.Color.White;
		button10.Location = new System.Drawing.Point(309, 0);
		button10.Name = "button10";
		button10.Size = new System.Drawing.Size(40, 23);
		button10.TabIndex = 0;
		button10.Text = "X";
		button10.UseVisualStyleBackColor = false;
		button10.Click += new System.EventHandler(button10_Click_1);
		groupBox4.BackColor = System.Drawing.Color.White;
		groupBox4.Controls.Add(chart1);
		groupBox4.Controls.Add(button11);
		groupBox4.Location = new System.Drawing.Point(602, 369);
		groupBox4.Name = "groupBox4";
		groupBox4.Size = new System.Drawing.Size(754, 255);
		groupBox4.TabIndex = 14;
		groupBox4.TabStop = false;
		groupBox4.Visible = false;
		chartArea.Name = "ChartArea1";
		chart1.ChartAreas.Add(chartArea);
		legend.Name = "Legend1";
		chart1.Legends.Add(legend);
		chart1.Location = new System.Drawing.Point(83, 8);
		chart1.Name = "chart1";
		chart1.Size = new System.Drawing.Size(598, 243);
		chart1.TabIndex = 1;
		chart1.Text = "chart1";
		button11.BackColor = System.Drawing.Color.Maroon;
		button11.Cursor = System.Windows.Forms.Cursors.Hand;
		button11.FlatAppearance.BorderSize = 0;
		button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button11.ForeColor = System.Drawing.Color.White;
		button11.Location = new System.Drawing.Point(713, 0);
		button11.Name = "button11";
		button11.Size = new System.Drawing.Size(41, 23);
		button11.TabIndex = 0;
		button11.Text = "X";
		button11.UseVisualStyleBackColor = false;
		button11.Click += new System.EventHandler(button11_Click);
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(25, 666);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(69, 13);
		label6.TabIndex = 15;
		label6.Text = "Version 1.0.6";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
		base.ClientSize = new System.Drawing.Size(1386, 682);
		base.Controls.Add(groupBox4);
		base.Controls.Add(groupBox3);
		base.Controls.Add(groupBox2);
		base.Controls.Add(groupBox1);
		base.Controls.Add(ventass);
		base.Controls.Add(panel1);
		base.Controls.Add(Hora);
		base.Controls.Add(panel2);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Form1";
		Text = "BLUPOINT";
		base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Form1_KeyUp);
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		panel16.ResumeLayout(false);
		panel16.PerformLayout();
		((System.ComponentModel.ISupportInitialize)image_user).EndInit();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ventass.ResumeLayout(false);
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
		groupBox1.ResumeLayout(false);
		panel4.ResumeLayout(false);
		panel4.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
		groupBox2.ResumeLayout(false);
		panel5.ResumeLayout(false);
		panel5.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
		groupBox3.ResumeLayout(false);
		panel6.ResumeLayout(false);
		panel6.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox12).EndInit();
		groupBox4.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)chart1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}

// BLUPOINT.Licencia
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;

public class Licencia : Form
{
	private IContainer components = null;

	private TextBox textBox1;

	private Label label1;

	private Panel panel1;

	private Label label2;

	private Label lblresponse;

	public Licencia()
	{
		InitializeComponent();
	}

	private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			if (Licenciaa(textBox1.Text) == 1)
			{
				Step_2 step_ = new Step_2();
				step_.Show();
				Close();
			}
			else
			{
				lblresponse.ForeColor = Color.Red;
				lblresponse.Text = "Codigo Invalido, intenta nuevamente";
			}
		}
	}

	private int Licenciaa(string campo)
	{
		return campo switch
		{
			"XBSZ-DDFR-Z65G-NM8F" => 1, 
			"P8UH-ZD7R-L379-AB89" => 1, 
			"SSJH-LLMK-ÑOPA-SSDE" => 1, 
			"FJHY-76YH-PCF6-77XH" => 1, 
			"FFNU-DPXS-36G5-Y76G" => 1, 
			_ => 0, 
		};
	}

	private void textBox1_TextChanged(object sender, EventArgs e)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Licencia));
		textBox1 = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		panel1 = new System.Windows.Forms.Panel();
		label2 = new System.Windows.Forms.Label();
		lblresponse = new System.Windows.Forms.Label();
		panel1.SuspendLayout();
		SuspendLayout();
		textBox1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		textBox1.Location = new System.Drawing.Point(113, 191);
		textBox1.Name = "textBox1";
		textBox1.Size = new System.Drawing.Size(524, 35);
		textBox1.TabIndex = 0;
		textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
		textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(108, 158);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(287, 30);
		label1.TabIndex = 1;
		label1.Text = "Introduce la clave del sistema";
		panel1.BackColor = System.Drawing.Color.Navy;
		panel1.Controls.Add(label2);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(781, 66);
		panel1.TabIndex = 2;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 27.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.ForeColor = System.Drawing.Color.White;
		label2.Location = new System.Drawing.Point(142, 9);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(485, 50);
		label2.TabIndex = 3;
		label2.Text = "ACTIVACION DE PRODUCTO";
		lblresponse.AutoSize = true;
		lblresponse.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblresponse.Location = new System.Drawing.Point(245, 239);
		lblresponse.Name = "lblresponse";
		lblresponse.Size = new System.Drawing.Size(0, 30);
		lblresponse.TabIndex = 3;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(781, 377);
		base.Controls.Add(lblresponse);
		base.Controls.Add(panel1);
		base.Controls.Add(label1);
		base.Controls.Add(textBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Licencia";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Licencia";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}
}

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

// BLUPOINT.ProdInfo
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT.Source;

public class ProdInfo : Form
{
	private Productos prod = new Productos();

	private DataTable dt = new DataTable();

	private string code = "";

	private IContainer components = null;

	private Label label1;

	private Panel panel1;

	private Button button1;

	private Label txtNp;

	private Label label3;

	private Label txtPrecio;

	public ProdInfo(string codigo)
	{
		code = codigo;
		InitializeComponent();
		CargarDatos();
	}

	public void CargarDatos()
	{
		prod.Codigo = code;
		dt = prod.GET();
		txtNp.Text = dt.Rows[0]["Nombre_P"].ToString();
		txtPrecio.Text = dt.Rows[0]["Precio"].ToString();
	}

	private void ProdInfo_Load(object sender, EventArgs e)
	{
	}

	private void button1_Click(object sender, EventArgs e)
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
		label1 = new System.Windows.Forms.Label();
		panel1 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		txtNp = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		txtPrecio = new System.Windows.Forms.Label();
		panel1.SuspendLayout();
		SuspendLayout();
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(12, 40);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(474, 45);
		label1.TabIndex = 0;
		label1.Text = "INFORMACION DEL PRODCUTO";
		panel1.BackColor = System.Drawing.Color.SteelBlue;
		panel1.Controls.Add(button1);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(503, 37);
		panel1.TabIndex = 1;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(457, 3);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(44, 31);
		button1.TabIndex = 0;
		button1.Text = "X";
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		txtNp.AutoSize = true;
		txtNp.Font = new System.Drawing.Font("Segoe UI", 26.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtNp.Location = new System.Drawing.Point(98, 112);
		txtNp.Name = "txtNp";
		txtNp.Size = new System.Drawing.Size(290, 47);
		txtNp.TabIndex = 2;
		txtNp.Text = "Producto Suavel";
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 72f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.ForeColor = System.Drawing.Color.Green;
		label3.Location = new System.Drawing.Point(12, 180);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(110, 128);
		label3.TabIndex = 3;
		label3.Text = "$";
		txtPrecio.AutoSize = true;
		txtPrecio.Font = new System.Drawing.Font("Segoe UI", 72f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtPrecio.ForeColor = System.Drawing.Color.Green;
		txtPrecio.Location = new System.Drawing.Point(174, 180);
		txtPrecio.Name = "txtPrecio";
		txtPrecio.Size = new System.Drawing.Size(191, 128);
		txtPrecio.TabIndex = 4;
		txtPrecio.Text = "0.0";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(503, 331);
		base.Controls.Add(txtPrecio);
		base.Controls.Add(label3);
		base.Controls.Add(txtNp);
		base.Controls.Add(panel1);
		base.Controls.Add(label1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "ProdInfo";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "ProdInfo";
		base.Load += new System.EventHandler(ProdInfo_Load);
		panel1.ResumeLayout(false);
		ResumeLayout(false);
		PerformLayout();
	}
}

// BLUPOINT.Producto
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Producto : Form
{
	private Productos prod = new Productos();

	private Proveedores prov = new Proveedores();

	private Caja cj = new Caja();

	private bool editares;

	private bool validacion;

	public string rutas;

	public string ids;

	public string cargo1;

	public string cargo2;

	public string cargo3;

	public string cargo4;

	public string respuesta;

	private IContainer components = null;

	private Panel panel1;

	private Panel panel2;

	private PictureBox add;

	private Panel panel3;

	private PictureBox save;

	private PictureBox edit;

	private ToolTip toolTip1;

	private PictureBox cancel;

	private PictureBox delete;

	private PictureBox search;

	private Label label1;

	private Panel panel5;

	private Panel panel4;

	private Panel panel6;

	private Button button1;

	private Label label2;

	private TextBox txtSearch;

	private DataGridView dataGridView1;

	private Panel panel7;

	private Panel panel10;

	private Label label7;

	private Panel panel9;

	private Panel panel8;

	private Label label6;

	private TextBox txtCantidad;

	private Label label5;

	private TextBox txtNombre;

	private Label label4;

	private TextBox txtCBA;

	private Label label3;

	private TextBox txtCB;

	private Label label8;

	private TextBox txtPrecio;

	private Label label9;

	private TextBox txtIVA;

	private Panel panel13;

	private Label label13;

	private Panel panel12;

	private Label label12;

	private Panel panel11;

	private Panel panel15;

	private TextBox txtprecio_mayoreo;

	private TextBox txtdesc;

	private Label label16;

	private Label label15;

	private DateTimePicker txtfecha_cad;

	private Label label14;

	private Panel panel14;

	private CheckBox ch3;

	private CheckBox ch2;

	private CheckBox ch1;

	private DateTimePicker txtFecha;

	private Label label11;

	private Label label10;

	private Button btnimage;

	private PictureBox pictureBox1;

	private Label txtruta;

	private Label iD;

	private Panel panel16;

	private Label label19;

	private PictureBox image_user;

	private Label label18;

	private Label txtName;

	private PictureBox btnoption;

	private Label label20;

	private Label txttipo_e;

	private Panel panel17;

	private PictureBox pictureBox2;

	private PictureBox pictureBox3;

	private PrintDocument printDocument1;

	private Label label21;

	private Label label17;

	private NumericUpDown Min;

	private Label label23;

	private NumericUpDown Max;

	private Label label22;

	private Label txtmoney;

	private Label label25;

	private Label label26;

	private PictureBox pictureBox4;

	private Label label27;

	private ComboBox txtprov;

	private PictureBox pictureBox5;

	private Label label24;

	private PictureBox pictureBox6;

	public Producto(string nombre, string ruta, string cargo, string id, string car1, string car2, string car3, string car4)
	{
		InitializeComponent();
		base.KeyPreview = true;
		base.KeyDown += Producto_KeyUp;
		Disabled();
		LoadMoney();
		editares = true;
		rutas = ruta;
		txttipo_e.Text = cargo;
		txtName.Text = nombre;
		if (ruta == "")
		{
			image_user.Image = Resources.picture;
		}
		else
		{
			image_user.Image = Image.FromFile(ruta);
		}
		ids = id;
		cargo1 = car1;
		cargo2 = car2;
		cargo3 = car3;
		cargo4 = car4;
	}

	private void LoadMoney()
	{
		DataTable dataTable = new DataTable();
		try
		{
			dataTable = cj.GETMONEY();
			txtmoney.Text = dataTable.Rows[0]["Cantidad"].ToString();
		}
		catch
		{
		}
	}

	public void CargarCombo(bool cargar)
	{
		if (cargar)
		{
			txtprov.DataSource = prov.GETPROV();
			txtprov.DisplayMember = "Nombre";
			txtprov.ValueMember = "Nombre";
		}
	}

	private bool Validar(string campo)
	{
		double num = 0.0;
		bool flag = false;
		if (campo == "")
		{
			return false;
		}
		try
		{
			num = Convert.ToDouble(campo);
			return true;
		}
		catch
		{
			MessageBox.Show("Debe ser un numero no se aceptan caracteres");
			return false;
		}
	}

	private bool Validar2(string campo)
	{
		int num = 0;
		bool flag = false;
		if (campo == "")
		{
			return false;
		}
		try
		{
			num = Convert.ToInt32(campo);
			return true;
		}
		catch
		{
			MessageBox.Show("Debe ser un numero no se aceptan caracteres");
			return false;
		}
	}

	private void Disabled()
	{
		txtprov.DataSource = prov.GETPROV();
		txtprov.DisplayMember = "Nombre";
		txtprov.ValueMember = "Nombre";
		cancel.Image = Resources.eliminar1;
		edit.Image = Resources.editar1;
		delete.Image = Resources.borrar1;
		save.Image = Resources.disquete1;
		btnoption.Enabled = false;
		btnoption.Image = Resources.en_el_boton;
		edit.Enabled = false;
		delete.Enabled = false;
		save.Enabled = false;
		cancel.Enabled = false;
		txtCantidad.Enabled = false;
		txtNombre.Enabled = false;
		txtFecha.Enabled = false;
		txtfecha_cad.Enabled = false;
		txtCB.Enabled = false;
		txtCBA.Enabled = false;
		txtdesc.Enabled = false;
		txtIVA.Enabled = false;
		txtprov.Enabled = false;
		txtprecio_mayoreo.Enabled = false;
		txtPrecio.Enabled = false;
		ch1.Enabled = false;
		ch2.Enabled = false;
		ch3.Enabled = false;
		ch1.Checked = false;
		ch2.Checked = false;
		ch3.Checked = false;
		Max.Enabled = false;
		Min.Enabled = false;
		btnimage.Enabled = false;
		pictureBox1.Image = Resources.picture;
	}

	private void Habilitar()
	{
		cancel.Image = Resources.eliminar;
		search.Image = Resources.buscar;
		save.Image = Resources.disquete;
		txtCB.Focus();
		txtSearch.Enabled = true;
		save.Enabled = true;
		cancel.Enabled = true;
		txtPrecio.Enabled = true;
		txtCantidad.Enabled = true;
		txtNombre.Enabled = true;
		txtCB.Enabled = true;
		txtCBA.Enabled = true;
		txtIVA.Enabled = true;
		txtprov.Enabled = true;
		ch1.Enabled = true;
		ch2.Enabled = true;
		ch3.Enabled = true;
		btnimage.Enabled = true;
		Max.Enabled = true;
		Min.Enabled = true;
	}

	private void add_MouseEnter(object sender, EventArgs e)
	{
		add.BackColor = Color.LightGray;
	}

	private void add_MouseLeave(object sender, EventArgs e)
	{
		add.BackColor = Color.White;
	}

	private void label1_Click(object sender, EventArgs e)
	{
	}

	private void add_Click(object sender, EventArgs e)
	{
		Habilitar();
		Limpiar();
		txtCB.Focus();
	}

	private void search_Click(object sender, EventArgs e)
	{
		txtSearch.Enabled = true;
		txtSearch.Focus();
	}

	private void cancel_Click(object sender, EventArgs e)
	{
		alert_danger alert_danger2 = new alert_danger("Cancelar Registro", "deseas cancelar el registro?");
		AddOwnedForm(alert_danger2);
		alert_danger2.ShowDialog();
		if (respuesta == "Si")
		{
			Disabled();
			Limpiar();
			add.Image = Resources.anadir;
			add.Enabled = true;
			editares = true;
		}
	}

	private void panel4_Paint(object sender, PaintEventArgs e)
	{
	}

	private void Guardar()
	{
		if (validacion)
		{
			prod.Nombre_P = txtNombre.Text.Trim();
			prod.Cantidad = txtCantidad.Text.Trim();
			prod.Codigo = txtCB.Text.Trim();
			prod.Cod_Alt = txtCBA.Text.Trim();
			prod.Descuento = txtdesc.Text.Trim();
			prod.Fecha_Reg = txtFecha.Value.Day + "/" + txtFecha.Value.Month + "/" + txtFecha.Value.Year;
			prod.Precio_Mayoreo = txtprecio_mayoreo.Text.Trim();
			prod.proveedor = txtprov.Text;
			prod.Precio_U = txtPrecio.Text.Trim();
			prod.IVA = "0." + txtIVA.Text.Trim();
			prod.Imagen = txtruta.Text;
			prod.Minimos = Min.Value.ToString();
			prod.Maximos = Max.Value.ToString();
			if (ch1.Checked)
			{
				prod.Fecha_Cad = txtfecha_cad.Value.Day + "/" + txtfecha_cad.Value.Month + "/" + txtfecha_cad.Value.Year;
			}
			else
			{
				prod.Fecha_Cad = "";
			}
			if (prod.POST() == 1)
			{
				alert_success alert_success2 = new alert_success("Producto Guardado con exito");
				alert_success2.ShowDialog();
				Limpiar();
				Disabled();
			}
			else if (prod.POST() == 2)
			{
				Alert_Error alert_Error = new Alert_Error("Ha Ocurrido un error, ErrCod: 896");
				alert_Error.ShowDialog();
			}
			else if (prod.POST() == 3)
			{
				Alert_Error alert_Error2 = new Alert_Error("Producto ya existente");
				alert_Error2.ShowDialog();
			}
		}
		else
		{
			Alert_Error alert_Error3 = new Alert_Error("Verifica campos vacios, o cantidad \n con letra");
			alert_Error3.ShowDialog();
		}
	}

	private void Limpiar()
	{
		txtprecio_mayoreo.Text = "0";
		txtPrecio.Text = "0";
		txtCantidad.Text = "0";
		txtNombre.Text = "";
		txtfecha_cad.ResetText();
		txtCB.Text = "";
		txtCBA.Text = "";
		txtdesc.Text = "0";
		txtIVA.Text = "0";
		txtprov.Text = "";
		pictureBox1.Image = Resources.picture;
		dataGridView1.DataSource = null;
		Max.Value = 0m;
		Min.Value = 0m;
		iD.Text = "";
	}

	private void save_Click(object sender, EventArgs e)
	{
		if (editares)
		{
			int num = Convert.ToInt32(txtCantidad.Text);
			if ((decimal)num > Max.Value)
			{
				Alert_Error alert_Error = new Alert_Error("La cantidad debe ser menor o igual al maximo");
				alert_Error.ShowDialog();
			}
			else if ((decimal)num < Min.Value)
			{
				Alert_Error alert_Error2 = new Alert_Error("La cantidad debe ser mayor a lo minimo");
				alert_Error2.ShowDialog();
			}
			else
			{
				Guardar();
			}
			return;
		}
		int num2 = Convert.ToInt32(txtCantidad.Text);
		if ((decimal)num2 > Max.Value)
		{
			Alert_Error alert_Error3 = new Alert_Error("La cantidad debe ser menor o igual al maximo");
			alert_Error3.ShowDialog();
		}
		else if ((decimal)num2 < Min.Value)
		{
			Alert_Error alert_Error4 = new Alert_Error("La cantidad debe ser mayor a lo minimo");
			alert_Error4.ShowDialog();
		}
		else
		{
			Editar();
			editares = true;
		}
	}

	private void txtCB_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Down)
		{
			txtCBA.Focus();
		}
		else if (e.KeyCode == Keys.Left)
		{
			txtSearch.Focus();
		}
		else if (e.KeyCode == Keys.Right)
		{
			ch1.Focus();
		}
		else if (e.KeyCode == Keys.Up)
		{
			txtprov.Focus();
		}
		else if (e.KeyCode == Keys.Return)
		{
			txtCBA.Focus();
		}
	}

	private void btnimage_Click(object sender, EventArgs e)
	{
		LoadImage();
	}

	private void LoadImage()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = "C://Pictures/";
		openFileDialog.Filter = "Archivos de Imagen(*.jpg)(*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|*.png";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			pictureBox1.ImageLocation = openFileDialog.FileName;
			txtruta.Text = openFileDialog.FileName;
		}
	}

	private void Producto_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			alert_danger alert_danger2 = new alert_danger("Cancelar Registro", "deseas cancelar el registro?");
			AddOwnedForm(alert_danger2);
			alert_danger2.ShowDialog();
			if (respuesta == "Si")
			{
				Disabled();
				Limpiar();
				add.Image = Resources.anadir;
				add.Enabled = true;
			}
		}
		if (e.KeyCode == Keys.F1)
		{
			Habilitar();
			Limpiar();
			txtCB.Focus();
		}
		if (e.KeyCode == Keys.F2)
		{
			if (iD.Text != "")
			{
				HabilitarEdicion();
				editares = false;
			}
			else
			{
				Alert_Error alert_Error = new Alert_Error("Selecciona un producto antes");
				alert_Error.ShowDialog();
			}
		}
		if (e.KeyCode == Keys.F12)
		{
			Form1 form = new Form1(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
			form.Show();
			Close();
		}
		else if (e.KeyCode == Keys.F5)
		{
			txtSearch.Enabled = true;
			txtSearch.Focus();
		}
		if (e.KeyCode == Keys.F3)
		{
			if (editares)
			{
				int num = Convert.ToInt32(txtCantidad.Text);
				if ((decimal)num > Max.Value)
				{
					Alert_Error alert_Error2 = new Alert_Error("La cantidad debe ser menor o igual al maximo");
					alert_Error2.ShowDialog();
				}
				else if ((decimal)num < Min.Value)
				{
					Alert_Error alert_Error3 = new Alert_Error("La cantidad debe ser mayor a lo minimo");
					alert_Error3.ShowDialog();
				}
				else
				{
					Guardar();
				}
				return;
			}
			int num2 = Convert.ToInt32(txtCantidad.Text);
			if ((decimal)num2 > Max.Value)
			{
				Alert_Error alert_Error4 = new Alert_Error("La cantidad debe ser menor o igual al maximo");
				alert_Error4.ShowDialog();
			}
			else if ((decimal)num2 < Min.Value)
			{
				Alert_Error alert_Error5 = new Alert_Error("La cantidad debe ser mayor a lo minimo");
				alert_Error5.ShowDialog();
			}
			else
			{
				Editar();
				editares = true;
			}
		}
		else if (e.KeyCode == Keys.F9)
		{
			LoadImage();
		}
		else if (e.KeyCode == Keys.F8)
		{
			Ofertas ofertas = new Ofertas();
			ofertas.ShowDialog();
		}
		else if (e.KeyCode == Keys.F6)
		{
			if (txttipo_e.Text == "Admin")
			{
				Proveedor proveedor = new Proveedor("");
				proveedor.ShowDialog();
			}
			else
			{
				Alert_Error alert_Error6 = new Alert_Error("Permisos Insuficientes, ErrCode: Adm001");
				alert_Error6.ShowDialog();
			}
		}
		else if (e.KeyCode == Keys.F4)
		{
			prod.Id = iD.Text;
			alert_danger alert_danger3 = new alert_danger("Eliuminar Producto", "Deseas eliminar Producto?");
			AddOwnedForm(alert_danger3);
			alert_danger3.ShowDialog();
			if (respuesta == "Si")
			{
				if (prod.DELETE() == 1)
				{
					Limpiar();
					Disabled();
					MessageBox.Show("Producto Eliminado con exito");
					editares = true;
				}
				else
				{
					Alert_Error alert_Error7 = new Alert_Error("Error al eliminar el producto");
					alert_Error7.ShowDialog();
				}
			}
		}
		else if (e.Control && e.KeyCode == Keys.P)
		{
			Print();
		}
		else if (e.KeyCode == Keys.F7)
		{
			Codigo_Barras_Prod codigo_Barras_Prod = new Codigo_Barras_Prod();
			codigo_Barras_Prod.ShowDialog();
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		DataTable dataTable = new DataTable();
		dataTable = prod.GETProd();
		dataGridView1.DataSource = dataTable;
		txtSearch.Text = "";
	}

	private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			prod.Codigo = txtSearch.Text;
			DataTable dataTable = new DataTable();
			dataTable = prod.GET();
			dataGridView1.DataSource = dataTable;
			txtSearch.Text = "";
			Disabled();
			LoadData();
		}
	}

	private void ch1_Click(object sender, EventArgs e)
	{
		if (ch1.Checked)
		{
			txtfecha_cad.Enabled = true;
		}
		else
		{
			txtfecha_cad.Enabled = false;
		}
	}

	private void ch2_Click(object sender, EventArgs e)
	{
		if (ch2.Checked)
		{
			txtdesc.Enabled = true;
		}
		else
		{
			txtdesc.Enabled = false;
		}
	}

	private void ch3_Click(object sender, EventArgs e)
	{
		if (ch3.Checked)
		{
			txtprecio_mayoreo.Enabled = true;
		}
		else
		{
			txtprecio_mayoreo.Enabled = false;
		}
	}

	private void txtCantidad_TextChanged(object sender, EventArgs e)
	{
		validacion = Validar(txtCantidad.Text);
		if (!validacion)
		{
			txtCantidad.Text = "";
		}
	}

	private void txtPrecio_TextChanged(object sender, EventArgs e)
	{
		validacion = Validar(txtPrecio.Text);
		if (!validacion)
		{
			txtPrecio.Text = "";
		}
	}

	private void txtdesc_TextChanged(object sender, EventArgs e)
	{
		validacion = Validar(txtdesc.Text);
		if (!validacion)
		{
			txtdesc.Text = "";
		}
	}

	private void txtprecio_mayoreo_TextChanged(object sender, EventArgs e)
	{
		validacion = Validar(txtprecio_mayoreo.Text);
		if (!validacion)
		{
			txtprecio_mayoreo.Text = "";
		}
	}

	private void txtCantidad_Click(object sender, EventArgs e)
	{
		txtCantidad.Text = "";
	}

	private void txtPrecio_Click(object sender, EventArgs e)
	{
		txtPrecio.Text = "";
	}

	private void txtdesc_Click(object sender, EventArgs e)
	{
		txtdesc.Text = "";
	}

	private void txtprecio_mayoreo_Click(object sender, EventArgs e)
	{
		txtprecio_mayoreo.Text = "";
	}

	private void txtCBA_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Down)
		{
			txtNombre.Focus();
		}
		else if (e.KeyCode == Keys.Up)
		{
			txtCB.Focus();
		}
	}

	private void txtNombre_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Down)
		{
			txtCantidad.Focus();
		}
		else if (e.KeyCode == Keys.Up)
		{
			txtCBA.Focus();
		}
	}

	private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Down)
		{
			txtPrecio.Focus();
		}
		else if (e.KeyCode == Keys.Up)
		{
			txtNombre.Focus();
		}
	}

	private void LoadData()
	{
		try
		{
			string text = dataGridView1.Rows[0].Cells["IVA"].Value.ToString();
			string[] array = text.Split('.');
			if (text == "0")
			{
				txtIVA.Text = "0";
			}
			else
			{
				txtIVA.Text = array[1];
			}
			iD.Text = dataGridView1.Rows[0].Cells["idProducto"].Value.ToString();
			txtCB.Text = dataGridView1.Rows[0].Cells["Codigo"].Value.ToString();
			txtCBA.Text = dataGridView1.Rows[0].Cells["Codigo_Alterno"].Value.ToString();
			txtNombre.Text = dataGridView1.Rows[0].Cells["Nombre_P"].Value.ToString();
			txtCantidad.Text = dataGridView1.Rows[0].Cells["Cantidad"].Value.ToString();
			txtprecio_mayoreo.Text = dataGridView1.Rows[0].Cells["Mayoreo"].Value.ToString();
			txtfecha_cad.Text = dataGridView1.Rows[0].Cells["Fecha_Cad"].Value.ToString();
			txtdesc.Text = dataGridView1.Rows[0].Cells["Descuento"].Value.ToString();
			txtPrecio.Text = dataGridView1.Rows[0].Cells["Precio"].Value.ToString();
			txtprov.Text = dataGridView1.Rows[0].Cells["Proveedor"].Value.ToString();
			if (dataGridView1.Rows[0].Cells["Imagen"].Value.ToString() == "")
			{
				pictureBox1.Image = Resources.picture;
			}
			else
			{
				pictureBox1.Image = Image.FromFile(dataGridView1.Rows[0].Cells["Imagen"].Value.ToString());
			}
			txtruta.Text = dataGridView1.Rows[0].Cells["Imagen"].Value.ToString();
			string value = dataGridView1.Rows[0].Cells["Maximos"].Value.ToString();
			string value2 = dataGridView1.Rows[0].Cells["Minimos"].Value.ToString();
			Max.Value = Convert.ToInt32(value);
			Min.Value = Convert.ToInt32(value2);
			edit.Enabled = true;
			delete.Enabled = true;
			delete.Image = Resources.borrar;
			edit.Image = Resources.editar;
			btnoption.Enabled = true;
		}
		catch
		{
			Alert_Error alert_Error = new Alert_Error("Producto no encontrado en inventario");
			alert_Error.ShowDialog();
			edit.Enabled = false;
			delete.Enabled = false;
			delete.Image = Resources.borrar1;
			edit.Image = Resources.editar1;
		}
	}

	private void edit_Click(object sender, EventArgs e)
	{
		editares = false;
		HabilitarEdicion();
	}

	private void HabilitarEdicion()
	{
		delete.Image = Resources.borrar;
		btnoption.Image = Resources.en_el_boton__1_;
		delete.Enabled = true;
		txtPrecio.Enabled = true;
		txtCantidad.Enabled = true;
		txtNombre.Enabled = true;
		btnoption.Enabled = true;
		txtCB.Enabled = true;
		txtCBA.Enabled = true;
		txtIVA.Enabled = true;
		txtprov.Enabled = true;
		ch1.Enabled = true;
		ch2.Enabled = true;
		ch3.Enabled = true;
		btnimage.Enabled = true;
		txtCB.Focus();
		save.Enabled = true;
		add.Enabled = false;
		cancel.Enabled = true;
		delete.Enabled = true;
		Min.Enabled = true;
		Max.Enabled = true;
		save.Image = Resources.disquete;
		cancel.Image = Resources.eliminar;
		add.Image = Resources.anadir1;
		delete.Image = Resources.borrar;
		MessageBox.Show("Edicion Activada");
	}

	private void Editar()
	{
		prod.Id = iD.Text;
		prod.Nombre_P = txtNombre.Text.Trim();
		prod.Cantidad = txtCantidad.Text.Trim();
		prod.Codigo = txtCB.Text.Trim();
		prod.Cod_Alt = txtCBA.Text.Trim();
		prod.Descuento = txtdesc.Text.Trim();
		prod.Fecha_Reg = txtFecha.Value.Day + "/" + txtFecha.Value.Month + "/" + txtFecha.Value.Year;
		prod.Precio_U = txtPrecio.Text.Trim();
		prod.IVA = "0." + txtIVA.Text.Trim();
		prod.Precio_Mayoreo = txtprecio_mayoreo.Text.Trim();
		prod.proveedor = txtprov.Text.Trim();
		prod.Imagen = txtruta.Text;
		prod.Maximos = Max.Value.ToString();
		prod.Minimos = Min.Value.ToString();
		if (ch1.Checked)
		{
			prod.Fecha_Cad = txtfecha_cad.Value.Day + "/" + txtfecha_cad.Value.Month + "/" + txtfecha_cad.Value.Year;
		}
		else
		{
			prod.Fecha_Cad = "";
		}
		if (prod.UPDATE() == 1)
		{
			alert_success alert_success2 = new alert_success("Producto Editado con exito");
			alert_success2.ShowDialog();
			Limpiar();
			Disabled();
			add.Enabled = true;
			add.Image = Resources.anadir;
			editares = false;
		}
		else if (prod.UPDATE() == 2)
		{
			Alert_Error alert_Error = new Alert_Error("Ha Ocurrido un error: ErrCod: 607");
			alert_Error.ShowDialog();
		}
	}

	private void delete_Click(object sender, EventArgs e)
	{
		prod.Id = iD.Text;
		alert_danger alert_danger2 = new alert_danger("Eliminar Producto", "Deseas Eliminar el Producto?");
		AddOwnedForm(alert_danger2);
		alert_danger2.ShowDialog();
		if (respuesta == "Si")
		{
			if (prod.DELETE() == 1)
			{
				Limpiar();
				Disabled();
				alert_success alert_success2 = new alert_success("Producto eliminado con exito");
				alert_success2.ShowDialog();
				editares = true;
			}
			else
			{
				Alert_Error alert_Error = new Alert_Error("Error al eliminar Producto, ErrCod: DB87");
				alert_Error.ShowDialog();
			}
		}
	}

	private void pictureBox3_Click(object sender, EventArgs e)
	{
		if (editares)
		{
			editares = false;
			HabilitarEdicion();
			btnoption.Image = Resources.en_el_boton__1_;
			return;
		}
		editares = true;
		Disabled();
		Limpiar();
		add.Image = Resources.anadir;
		add.Enabled = true;
		btnoption.Image = Resources.en_el_boton;
	}

	private void Producto_FormClosed(object sender, FormClosedEventArgs e)
	{
	}

	private void txtIVA_TextChanged(object sender, EventArgs e)
	{
		validacion = Validar2(txtIVA.Text);
		if (!validacion)
		{
			txtIVA.Text = "";
		}
	}

	private void pictureBox4_Click(object sender, EventArgs e)
	{
		Codigo_Barras_Prod codigo_Barras_Prod = new Codigo_Barras_Prod();
		codigo_Barras_Prod.ShowDialog();
	}

	private void txtCantidad_Leave(object sender, EventArgs e)
	{
		if (txtCantidad.Text == "")
		{
			txtCantidad.Text = "0";
		}
	}

	private void txtPrecio_Leave(object sender, EventArgs e)
	{
		if (txtPrecio.Text == "")
		{
			txtPrecio.Text = "0";
		}
	}

	private void txtIVA_Enter(object sender, EventArgs e)
	{
		if (txtIVA.Text == "0")
		{
			txtIVA.Text = "";
		}
	}

	private void txtIVA_Leave(object sender, EventArgs e)
	{
		try
		{
			if (txtIVA.Text == "")
			{
				txtIVA.Text = "0";
				return;
			}
			double num = Convert.ToDouble(txtIVA.Text);
			if (num < 0.0)
			{
				Alert_Error alert_Error = new Alert_Error("Ingresa mas del 1% de IVA");
				alert_Error.ShowDialog();
				txtIVA.Text = "0";
			}
		}
		catch
		{
		}
	}

	private void txtdesc_Leave(object sender, EventArgs e)
	{
		if (txtdesc.Text == "")
		{
			txtdesc.Text = "0";
		}
	}

	private void txtprecio_mayoreo_Leave(object sender, EventArgs e)
	{
		if (txtprecio_mayoreo.Text == "")
		{
			txtprecio_mayoreo.Text = "0";
		}
	}

	private void txtIVA_KeyPress(object sender, KeyPressEventArgs e)
	{
	}

	private void panel7_Paint(object sender, PaintEventArgs e)
	{
	}

	private void pictureBox5_Click(object sender, EventArgs e)
	{
		alert_danger alert_danger2 = new alert_danger("Saliendo", "deseas salir?");
		AddOwnedForm(alert_danger2);
		alert_danger2.ShowDialog();
		if (respuesta == "Si")
		{
			Form1 form = new Form1(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
			form.Show();
			Close();
		}
	}

	private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			string text = dataGridView1.CurrentRow.Cells["IVA"].Value.ToString();
			string[] array = text.Split('.');
			if (text == "0")
			{
				txtIVA.Text = "0";
			}
			else
			{
				txtIVA.Text = array[1];
			}
			iD.Text = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
			txtCB.Text = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
			txtCBA.Text = dataGridView1.CurrentRow.Cells["Codigo_Alterno"].Value.ToString();
			txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre_P"].Value.ToString();
			txtCantidad.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
			txtprecio_mayoreo.Text = dataGridView1.CurrentRow.Cells["Mayoreo"].Value.ToString();
			txtfecha_cad.Text = dataGridView1.CurrentRow.Cells["Fecha_Cad"].Value.ToString();
			txtdesc.Text = dataGridView1.CurrentRow.Cells["Descuento"].Value.ToString();
			txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
			txtprov.Text = dataGridView1.CurrentRow.Cells["Proveedor"].Value.ToString();
			if (dataGridView1.CurrentRow.Cells["Imagen"].Value.ToString() == "")
			{
				pictureBox1.Image = Resources.picture;
			}
			else
			{
				pictureBox1.Image = Image.FromFile(dataGridView1.CurrentRow.Cells["Imagen"].Value.ToString());
			}
			txtruta.Text = dataGridView1.CurrentRow.Cells["Imagen"].Value.ToString();
			string value = dataGridView1.CurrentRow.Cells["Maximos"].Value.ToString();
			string value2 = dataGridView1.CurrentRow.Cells["Minimos"].Value.ToString();
			Max.Value = Convert.ToInt32(value);
			Min.Value = Convert.ToInt32(value2);
			edit.Enabled = true;
			delete.Enabled = true;
			delete.Image = Resources.borrar;
			edit.Image = Resources.editar;
			btnoption.Enabled = true;
		}
		catch
		{
			Alert_Error alert_Error = new Alert_Error("Producto no encontrado en inventario");
			alert_Error.ShowDialog();
			edit.Enabled = false;
			delete.Enabled = false;
			delete.Image = Resources.borrar1;
			edit.Image = Resources.editar1;
		}
	}

	private void pictureBox6_Click(object sender, EventArgs e)
	{
		Ofertas ofertas = new Ofertas();
		ofertas.ShowDialog();
	}

	private void pictureBox2_Click(object sender, EventArgs e)
	{
		if (txttipo_e.Text == "Admin")
		{
			Proveedor proveedor = new Proveedor("Producto");
			AddOwnedForm(proveedor);
			proveedor.Show();
		}
		else
		{
			Alert_Error alert_Error = new Alert_Error("Permisos Insuficientes, ErrCod: Adm001");
			alert_Error.ShowDialog();
		}
	}

	private void panel3_Paint(object sender, PaintEventArgs e)
	{
	}

	private void pictureBox3_Click_1(object sender, EventArgs e)
	{
		dataGridView1.DataSource = prod.GETProd();
		if (dataGridView1.RowCount <= 0)
		{
			Alert_Error alert_Error = new Alert_Error("No hay Productos Registrados");
			alert_Error.ShowDialog();
		}
		else
		{
			Print();
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
		Image picture = Resources.picture;
		e.Graphics.DrawString(" ***" + dataTable.Rows[0]["Nombre_N"].ToString() + "*** ", font, Brushes.Black, new RectangleF(0f, num2 += 10, num, 20f));
		e.Graphics.DrawString(s, font3, Brushes.Black, new RectangleF(8f, num2 += 20, num, num2 + 20));
		e.Graphics.DrawString("Tel: " + dataTable.Rows[0]["Telefono"].ToString(), font3, Brushes.Black, new RectangleF(8f, num2 += 25, num, num2 + 15));
		e.Graphics.DrawString("Productos", font3, Brushes.Black, new RectangleF(8f, num2 += 20, num, num2 + 20));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("Nombre \tCant.\t\tPrecio", font3, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		foreach (DataGridViewRow item in (IEnumerable)dataGridView1.Rows)
		{
			if (item.Cells["Nombre_P"].Value.ToString().Length >= 8)
			{
				e.Graphics.DrawString(item.Cells["Nombre_P"].Value.ToString() + "\t" + item.Cells["Cantidad"].Value.ToString() + "\t\t$" + item.Cells["Precio"].Value.ToString(), font3, Brushes.Black, new RectangleF(0f, num2 += 20, 200f, 20f));
			}
			else
			{
				e.Graphics.DrawString(item.Cells["Nombre_P"].Value.ToString() + "\t\t" + item.Cells["Cantidad"].Value.ToString() + "\t\t$" + item.Cells["Precio"].Value.ToString(), font3, Brushes.Black, new RectangleF(0f, num2 += 20, 200f, 20f));
			}
		}
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("Tick Por:\t" + txtName.Text, font3, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num2 += 20, num, 20f));
	}

	private void Producto_FormClosing(object sender, FormClosingEventArgs e)
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
		components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Producto));
		panel1 = new System.Windows.Forms.Panel();
		txtmoney = new System.Windows.Forms.Label();
		btnoption = new System.Windows.Forms.PictureBox();
		label25 = new System.Windows.Forms.Label();
		label20 = new System.Windows.Forms.Label();
		label26 = new System.Windows.Forms.Label();
		panel16 = new System.Windows.Forms.Panel();
		txttipo_e = new System.Windows.Forms.Label();
		label19 = new System.Windows.Forms.Label();
		image_user = new System.Windows.Forms.PictureBox();
		label18 = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.Label();
		panel2 = new System.Windows.Forms.Panel();
		pictureBox5 = new System.Windows.Forms.PictureBox();
		search = new System.Windows.Forms.PictureBox();
		delete = new System.Windows.Forms.PictureBox();
		cancel = new System.Windows.Forms.PictureBox();
		save = new System.Windows.Forms.PictureBox();
		edit = new System.Windows.Forms.PictureBox();
		add = new System.Windows.Forms.PictureBox();
		panel3 = new System.Windows.Forms.Panel();
		panel17 = new System.Windows.Forms.Panel();
		label27 = new System.Windows.Forms.Label();
		pictureBox4 = new System.Windows.Forms.PictureBox();
		label21 = new System.Windows.Forms.Label();
		label17 = new System.Windows.Forms.Label();
		pictureBox3 = new System.Windows.Forms.PictureBox();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		iD = new System.Windows.Forms.Label();
		panel7 = new System.Windows.Forms.Panel();
		txtruta = new System.Windows.Forms.Label();
		panel13 = new System.Windows.Forms.Panel();
		label13 = new System.Windows.Forms.Label();
		panel12 = new System.Windows.Forms.Panel();
		label12 = new System.Windows.Forms.Label();
		panel11 = new System.Windows.Forms.Panel();
		panel15 = new System.Windows.Forms.Panel();
		txtprecio_mayoreo = new System.Windows.Forms.TextBox();
		txtdesc = new System.Windows.Forms.TextBox();
		label16 = new System.Windows.Forms.Label();
		label15 = new System.Windows.Forms.Label();
		txtfecha_cad = new System.Windows.Forms.DateTimePicker();
		label14 = new System.Windows.Forms.Label();
		panel14 = new System.Windows.Forms.Panel();
		ch3 = new System.Windows.Forms.CheckBox();
		ch2 = new System.Windows.Forms.CheckBox();
		ch1 = new System.Windows.Forms.CheckBox();
		panel10 = new System.Windows.Forms.Panel();
		label7 = new System.Windows.Forms.Label();
		panel9 = new System.Windows.Forms.Panel();
		btnimage = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		panel8 = new System.Windows.Forms.Panel();
		Min = new System.Windows.Forms.NumericUpDown();
		label23 = new System.Windows.Forms.Label();
		Max = new System.Windows.Forms.NumericUpDown();
		label22 = new System.Windows.Forms.Label();
		txtFecha = new System.Windows.Forms.DateTimePicker();
		txtprov = new System.Windows.Forms.ComboBox();
		label11 = new System.Windows.Forms.Label();
		label10 = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		txtIVA = new System.Windows.Forms.TextBox();
		label8 = new System.Windows.Forms.Label();
		txtPrecio = new System.Windows.Forms.TextBox();
		label6 = new System.Windows.Forms.Label();
		txtCantidad = new System.Windows.Forms.TextBox();
		label5 = new System.Windows.Forms.Label();
		txtNombre = new System.Windows.Forms.TextBox();
		label4 = new System.Windows.Forms.Label();
		txtCBA = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		txtCB = new System.Windows.Forms.TextBox();
		panel6 = new System.Windows.Forms.Panel();
		dataGridView1 = new System.Windows.Forms.DataGridView();
		panel5 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		label2 = new System.Windows.Forms.Label();
		txtSearch = new System.Windows.Forms.TextBox();
		panel4 = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
		toolTip1 = new System.Windows.Forms.ToolTip(components);
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		pictureBox6 = new System.Windows.Forms.PictureBox();
		label24 = new System.Windows.Forms.Label();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)btnoption).BeginInit();
		panel16.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)image_user).BeginInit();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)search).BeginInit();
		((System.ComponentModel.ISupportInitialize)delete).BeginInit();
		((System.ComponentModel.ISupportInitialize)cancel).BeginInit();
		((System.ComponentModel.ISupportInitialize)save).BeginInit();
		((System.ComponentModel.ISupportInitialize)edit).BeginInit();
		((System.ComponentModel.ISupportInitialize)add).BeginInit();
		panel3.SuspendLayout();
		panel17.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		panel7.SuspendLayout();
		panel13.SuspendLayout();
		panel12.SuspendLayout();
		panel11.SuspendLayout();
		panel15.SuspendLayout();
		panel14.SuspendLayout();
		panel10.SuspendLayout();
		panel9.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel8.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)Min).BeginInit();
		((System.ComponentModel.ISupportInitialize)Max).BeginInit();
		panel6.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
		panel5.SuspendLayout();
		panel4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(txtmoney);
		panel1.Controls.Add(btnoption);
		panel1.Controls.Add(label25);
		panel1.Controls.Add(label20);
		panel1.Controls.Add(label26);
		panel1.Controls.Add(panel16);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(133, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(1097, 60);
		panel1.TabIndex = 14;
		txtmoney.AutoSize = true;
		txtmoney.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtmoney.Location = new System.Drawing.Point(50, 6);
		txtmoney.Name = "txtmoney";
		txtmoney.Size = new System.Drawing.Size(36, 25);
		txtmoney.TabIndex = 22;
		txtmoney.Text = "0.0";
		btnoption.Image = BLUPOINT.Properties.Resources.en_el_boton;
		btnoption.Location = new System.Drawing.Point(371, 16);
		btnoption.Name = "btnoption";
		btnoption.Size = new System.Drawing.Size(23, 23);
		btnoption.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		btnoption.TabIndex = 2;
		btnoption.TabStop = false;
		toolTip1.SetToolTip(btnoption, "Da click para activar la edicion");
		btnoption.Click += new System.EventHandler(pictureBox3_Click);
		label25.AutoSize = true;
		label25.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label25.Location = new System.Drawing.Point(34, 6);
		label25.Name = "label25";
		label25.Size = new System.Drawing.Size(22, 25);
		label25.TabIndex = 21;
		label25.Text = "$";
		label20.AutoSize = true;
		label20.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label20.Location = new System.Drawing.Point(279, 11);
		label20.Name = "label20";
		label20.Size = new System.Drawing.Size(96, 30);
		label20.TabIndex = 1;
		label20.Text = "EDICION";
		label26.AutoSize = true;
		label26.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label26.Location = new System.Drawing.Point(6, 28);
		label26.Name = "label26";
		label26.Size = new System.Drawing.Size(127, 21);
		label26.TabIndex = 20;
		label26.Text = "Cantidad en Caja";
		panel16.Controls.Add(txttipo_e);
		panel16.Controls.Add(label19);
		panel16.Controls.Add(image_user);
		panel16.Controls.Add(label18);
		panel16.Controls.Add(txtName);
		panel16.Dock = System.Windows.Forms.DockStyle.Right;
		panel16.Location = new System.Drawing.Point(786, 0);
		panel16.Name = "panel16";
		panel16.Size = new System.Drawing.Size(311, 60);
		panel16.TabIndex = 0;
		txttipo_e.AutoSize = true;
		txttipo_e.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttipo_e.Location = new System.Drawing.Point(187, 39);
		txttipo_e.Name = "txttipo_e";
		txttipo_e.Size = new System.Drawing.Size(52, 18);
		txttipo_e.TabIndex = 29;
		txttipo_e.Text = "Cajero";
		label19.AutoSize = true;
		label19.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
		label19.Location = new System.Drawing.Point(207, 28);
		label19.Name = "label19";
		label19.Size = new System.Drawing.Size(37, 13);
		label19.TabIndex = 27;
		label19.Text = "Activo";
		image_user.Image = (System.Drawing.Image)resources.GetObject("image_user.Image");
		image_user.Location = new System.Drawing.Point(250, 0);
		image_user.Name = "image_user";
		image_user.Size = new System.Drawing.Size(61, 57);
		image_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		image_user.TabIndex = 24;
		image_user.TabStop = false;
		label18.AutoSize = true;
		label18.ForeColor = System.Drawing.SystemColors.AppWorkspace;
		label18.Location = new System.Drawing.Point(171, 28);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(37, 13);
		label18.TabIndex = 26;
		label18.Text = "Status";
		txtName.AutoSize = true;
		txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtName.Location = new System.Drawing.Point(3, 0);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(197, 24);
		txtName.TabIndex = 25;
		txtName.Text = "Jorge Lemus Stripsent";
		panel2.BackColor = System.Drawing.Color.White;
		panel2.Controls.Add(pictureBox5);
		panel2.Controls.Add(search);
		panel2.Controls.Add(delete);
		panel2.Controls.Add(cancel);
		panel2.Controls.Add(save);
		panel2.Controls.Add(edit);
		panel2.Controls.Add(add);
		panel2.Dock = System.Windows.Forms.DockStyle.Left;
		panel2.Location = new System.Drawing.Point(0, 0);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(133, 788);
		panel2.TabIndex = 13;
		pictureBox5.BackColor = System.Drawing.Color.Transparent;
		pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox5.Image = BLUPOINT.Properties.Resources.atras;
		pictureBox5.Location = new System.Drawing.Point(0, 0);
		pictureBox5.Name = "pictureBox5";
		pictureBox5.Size = new System.Drawing.Size(35, 35);
		pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox5.TabIndex = 20;
		pictureBox5.TabStop = false;
		toolTip1.SetToolTip(pictureBox5, "Añadir (F1)");
		pictureBox5.Click += new System.EventHandler(pictureBox5_Click);
		search.BackColor = System.Drawing.Color.Transparent;
		search.Cursor = System.Windows.Forms.Cursors.Hand;
		search.Image = BLUPOINT.Properties.Resources.buscar;
		search.Location = new System.Drawing.Point(33, 525);
		search.Name = "search";
		search.Size = new System.Drawing.Size(65, 69);
		search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		search.TabIndex = 19;
		search.TabStop = false;
		toolTip1.SetToolTip(search, "Buscar (F5)");
		search.Click += new System.EventHandler(search_Click);
		delete.BackColor = System.Drawing.Color.Transparent;
		delete.Cursor = System.Windows.Forms.Cursors.Hand;
		delete.Image = BLUPOINT.Properties.Resources.borrar1;
		delete.Location = new System.Drawing.Point(33, 422);
		delete.Name = "delete";
		delete.Size = new System.Drawing.Size(65, 69);
		delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		delete.TabIndex = 18;
		delete.TabStop = false;
		toolTip1.SetToolTip(delete, "Eliminar  (F4)");
		delete.Click += new System.EventHandler(delete_Click);
		cancel.BackColor = System.Drawing.Color.Transparent;
		cancel.Cursor = System.Windows.Forms.Cursors.Hand;
		cancel.Image = BLUPOINT.Properties.Resources.eliminar1;
		cancel.Location = new System.Drawing.Point(33, 629);
		cancel.Name = "cancel";
		cancel.Size = new System.Drawing.Size(65, 69);
		cancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		cancel.TabIndex = 17;
		cancel.TabStop = false;
		toolTip1.SetToolTip(cancel, "Cancelar (Esc)");
		cancel.Click += new System.EventHandler(cancel_Click);
		save.BackColor = System.Drawing.Color.Transparent;
		save.Cursor = System.Windows.Forms.Cursors.Hand;
		save.Image = BLUPOINT.Properties.Resources.disquete1;
		save.Location = new System.Drawing.Point(33, 303);
		save.Name = "save";
		save.Size = new System.Drawing.Size(65, 69);
		save.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		save.TabIndex = 16;
		save.TabStop = false;
		toolTip1.SetToolTip(save, "Guardar (F3)");
		save.Click += new System.EventHandler(save_Click);
		edit.BackColor = System.Drawing.Color.Transparent;
		edit.Cursor = System.Windows.Forms.Cursors.Hand;
		edit.Image = BLUPOINT.Properties.Resources.editar1;
		edit.Location = new System.Drawing.Point(33, 185);
		edit.Name = "edit";
		edit.Size = new System.Drawing.Size(65, 69);
		edit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		edit.TabIndex = 7;
		edit.TabStop = false;
		toolTip1.SetToolTip(edit, "Editar (F2)");
		edit.Click += new System.EventHandler(edit_Click);
		add.BackColor = System.Drawing.Color.Transparent;
		add.Cursor = System.Windows.Forms.Cursors.Hand;
		add.Image = BLUPOINT.Properties.Resources.anadir;
		add.Location = new System.Drawing.Point(33, 79);
		add.Name = "add";
		add.Size = new System.Drawing.Size(65, 63);
		add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		add.TabIndex = 6;
		add.TabStop = false;
		toolTip1.SetToolTip(add, "Añadir (F1)");
		add.Click += new System.EventHandler(add_Click);
		add.MouseEnter += new System.EventHandler(add_MouseEnter);
		add.MouseLeave += new System.EventHandler(add_MouseLeave);
		panel3.BackColor = System.Drawing.Color.White;
		panel3.Controls.Add(panel17);
		panel3.Controls.Add(iD);
		panel3.Controls.Add(panel7);
		panel3.Controls.Add(panel6);
		panel3.Controls.Add(panel5);
		panel3.Controls.Add(panel4);
		panel3.Location = new System.Drawing.Point(137, 64);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(1028, 712);
		panel3.TabIndex = 15;
		panel3.Paint += new System.Windows.Forms.PaintEventHandler(panel3_Paint);
		panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel17.Controls.Add(label24);
		panel17.Controls.Add(pictureBox6);
		panel17.Controls.Add(label27);
		panel17.Controls.Add(pictureBox4);
		panel17.Controls.Add(label21);
		panel17.Controls.Add(label17);
		panel17.Controls.Add(pictureBox3);
		panel17.Controls.Add(pictureBox2);
		panel17.Location = new System.Drawing.Point(22, 447);
		panel17.Name = "panel17";
		panel17.Size = new System.Drawing.Size(296, 214);
		panel17.TabIndex = 5;
		label27.AutoSize = true;
		label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label27.Location = new System.Drawing.Point(170, 191);
		label27.Name = "label27";
		label27.Size = new System.Drawing.Size(119, 15);
		label27.TabIndex = 5;
		label27.Text = "Generar Codigo (F7)";
		pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox4.Image = BLUPOINT.Properties.Resources.codigo_de_barras;
		pictureBox4.Location = new System.Drawing.Point(197, 119);
		pictureBox4.Name = "pictureBox4";
		pictureBox4.Size = new System.Drawing.Size(75, 73);
		pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox4.TabIndex = 4;
		pictureBox4.TabStop = false;
		pictureBox4.Click += new System.EventHandler(pictureBox4_Click);
		label21.AutoSize = true;
		label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label21.Location = new System.Drawing.Point(157, 83);
		label21.Name = "label21";
		label21.Size = new System.Drawing.Size(134, 15);
		label21.TabIndex = 3;
		label21.Text = "Agregar Proveedor (F6)";
		label17.AutoSize = true;
		label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label17.Location = new System.Drawing.Point(19, 86);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(94, 15);
		label17.TabIndex = 2;
		label17.Text = "Imprimir (Ctr+P)";
		pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox3.Image = BLUPOINT.Properties.Resources.impresion;
		pictureBox3.Location = new System.Drawing.Point(28, 3);
		pictureBox3.Name = "pictureBox3";
		pictureBox3.Size = new System.Drawing.Size(63, 73);
		pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox3.TabIndex = 1;
		pictureBox3.TabStop = false;
		pictureBox3.Click += new System.EventHandler(pictureBox3_Click_1);
		pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox2.Image = BLUPOINT.Properties.Resources.inventario;
		pictureBox2.Location = new System.Drawing.Point(192, 6);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(75, 73);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 0;
		pictureBox2.TabStop = false;
		pictureBox2.Click += new System.EventHandler(pictureBox2_Click);
		iD.AutoSize = true;
		iD.ForeColor = System.Drawing.Color.White;
		iD.Location = new System.Drawing.Point(19, 13);
		iD.Name = "iD";
		iD.Size = new System.Drawing.Size(0, 13);
		iD.TabIndex = 4;
		panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel7.Controls.Add(txtruta);
		panel7.Controls.Add(panel13);
		panel7.Controls.Add(panel12);
		panel7.Controls.Add(panel11);
		panel7.Controls.Add(panel10);
		panel7.Controls.Add(panel9);
		panel7.Controls.Add(panel8);
		panel7.Location = new System.Drawing.Point(343, 43);
		panel7.Name = "panel7";
		panel7.Size = new System.Drawing.Size(671, 624);
		panel7.TabIndex = 3;
		panel7.Paint += new System.Windows.Forms.PaintEventHandler(panel7_Paint);
		txtruta.AutoSize = true;
		txtruta.ForeColor = System.Drawing.Color.White;
		txtruta.Location = new System.Drawing.Point(417, 555);
		txtruta.Name = "txtruta";
		txtruta.Size = new System.Drawing.Size(0, 13);
		txtruta.TabIndex = 2;
		panel13.BackColor = System.Drawing.Color.SteelBlue;
		panel13.Controls.Add(label13);
		panel13.Location = new System.Drawing.Point(409, 317);
		panel13.Name = "panel13";
		panel13.Size = new System.Drawing.Size(257, 34);
		panel13.TabIndex = 3;
		label13.AutoSize = true;
		label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label13.ForeColor = System.Drawing.Color.White;
		label13.Location = new System.Drawing.Point(89, 4);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(94, 25);
		label13.TabIndex = 0;
		label13.Text = "IMAGEN";
		panel12.BackColor = System.Drawing.Color.SteelBlue;
		panel12.Controls.Add(label12);
		panel12.Location = new System.Drawing.Point(409, 21);
		panel12.Name = "panel12";
		panel12.Size = new System.Drawing.Size(257, 34);
		panel12.TabIndex = 2;
		label12.AutoSize = true;
		label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label12.ForeColor = System.Drawing.Color.White;
		label12.Location = new System.Drawing.Point(80, 3);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(96, 25);
		label12.TabIndex = 0;
		label12.Text = "EXTRAS";
		panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel11.Controls.Add(panel15);
		panel11.Controls.Add(panel14);
		panel11.Location = new System.Drawing.Point(409, 56);
		panel11.Name = "panel11";
		panel11.Size = new System.Drawing.Size(257, 255);
		panel11.TabIndex = 2;
		panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel15.Controls.Add(txtprecio_mayoreo);
		panel15.Controls.Add(txtdesc);
		panel15.Controls.Add(label16);
		panel15.Controls.Add(label15);
		panel15.Controls.Add(txtfecha_cad);
		panel15.Controls.Add(label14);
		panel15.Location = new System.Drawing.Point(3, 113);
		panel15.Name = "panel15";
		panel15.Size = new System.Drawing.Size(245, 127);
		panel15.TabIndex = 3;
		txtprecio_mayoreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtprecio_mayoreo.Location = new System.Drawing.Point(83, 94);
		txtprecio_mayoreo.Name = "txtprecio_mayoreo";
		txtprecio_mayoreo.Size = new System.Drawing.Size(152, 26);
		txtprecio_mayoreo.TabIndex = 20;
		txtprecio_mayoreo.Text = "0";
		txtprecio_mayoreo.Click += new System.EventHandler(txtprecio_mayoreo_Click);
		txtprecio_mayoreo.TextChanged += new System.EventHandler(txtprecio_mayoreo_TextChanged);
		txtprecio_mayoreo.Leave += new System.EventHandler(txtprecio_mayoreo_Leave);
		txtdesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtdesc.Location = new System.Drawing.Point(84, 55);
		txtdesc.Name = "txtdesc";
		txtdesc.Size = new System.Drawing.Size(152, 26);
		txtdesc.TabIndex = 19;
		txtdesc.Text = "0";
		txtdesc.Click += new System.EventHandler(txtdesc_Click);
		txtdesc.TextChanged += new System.EventHandler(txtdesc_TextChanged);
		txtdesc.Leave += new System.EventHandler(txtdesc_Leave);
		label16.AutoSize = true;
		label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label16.ForeColor = System.Drawing.Color.Navy;
		label16.Location = new System.Drawing.Point(0, 94);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(77, 16);
		label16.TabIndex = 18;
		label16.Text = "Precio/May";
		label15.AutoSize = true;
		label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label15.ForeColor = System.Drawing.Color.Navy;
		label15.Location = new System.Drawing.Point(3, 59);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(73, 16);
		label15.TabIndex = 17;
		label15.Text = "Descuento";
		txtfecha_cad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtfecha_cad.Location = new System.Drawing.Point(84, 11);
		txtfecha_cad.Name = "txtfecha_cad";
		txtfecha_cad.Size = new System.Drawing.Size(156, 29);
		txtfecha_cad.TabIndex = 16;
		label14.AutoSize = true;
		label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label14.ForeColor = System.Drawing.Color.Navy;
		label14.Location = new System.Drawing.Point(3, 18);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(75, 16);
		label14.TabIndex = 0;
		label14.Text = "Fecha/Cad";
		panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel14.Controls.Add(ch3);
		panel14.Controls.Add(ch2);
		panel14.Controls.Add(ch1);
		panel14.Location = new System.Drawing.Point(4, 8);
		panel14.Name = "panel14";
		panel14.Size = new System.Drawing.Size(245, 99);
		panel14.TabIndex = 0;
		ch3.AutoSize = true;
		ch3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ch3.Location = new System.Drawing.Point(3, 67);
		ch3.Name = "ch3";
		ch3.Size = new System.Drawing.Size(167, 28);
		ch3.TabIndex = 2;
		ch3.Text = "Precio Mayorista";
		ch3.UseVisualStyleBackColor = true;
		ch3.Click += new System.EventHandler(ch3_Click);
		ch2.AutoSize = true;
		ch2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ch2.Location = new System.Drawing.Point(3, 35);
		ch2.Name = "ch2";
		ch2.Size = new System.Drawing.Size(120, 28);
		ch2.TabIndex = 1;
		ch2.Text = "Descuento";
		ch2.UseVisualStyleBackColor = true;
		ch2.Click += new System.EventHandler(ch2_Click);
		ch1.AutoSize = true;
		ch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		ch1.Location = new System.Drawing.Point(3, 7);
		ch1.Name = "ch1";
		ch1.Size = new System.Drawing.Size(206, 28);
		ch1.TabIndex = 0;
		ch1.Text = "Fecha de Caducidad";
		ch1.UseVisualStyleBackColor = true;
		ch1.Click += new System.EventHandler(ch1_Click);
		panel10.BackColor = System.Drawing.Color.SteelBlue;
		panel10.Controls.Add(label7);
		panel10.Location = new System.Drawing.Point(19, 24);
		panel10.Name = "panel10";
		panel10.Size = new System.Drawing.Size(384, 34);
		panel10.TabIndex = 1;
		label7.AutoSize = true;
		label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label7.ForeColor = System.Drawing.Color.White;
		label7.Location = new System.Drawing.Point(79, 6);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(256, 25);
		label7.TabIndex = 0;
		label7.Text = "DATOS DEL PRODUCTO";
		panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		panel9.Controls.Add(btnimage);
		panel9.Controls.Add(pictureBox1);
		panel9.Location = new System.Drawing.Point(409, 347);
		panel9.Name = "panel9";
		panel9.Size = new System.Drawing.Size(257, 263);
		panel9.TabIndex = 1;
		btnimage.BackColor = System.Drawing.Color.SteelBlue;
		btnimage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnimage.ForeColor = System.Drawing.Color.White;
		btnimage.Location = new System.Drawing.Point(42, 157);
		btnimage.Name = "btnimage";
		btnimage.Size = new System.Drawing.Size(184, 47);
		btnimage.TabIndex = 1;
		btnimage.Text = "Seleccionar Imagen (F9)";
		btnimage.UseVisualStyleBackColor = false;
		btnimage.Click += new System.EventHandler(btnimage_Click);
		pictureBox1.Image = BLUPOINT.Properties.Resources.picture;
		pictureBox1.Location = new System.Drawing.Point(56, -2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(162, 160);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 0;
		pictureBox1.TabStop = false;
		panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel8.Controls.Add(Min);
		panel8.Controls.Add(label23);
		panel8.Controls.Add(Max);
		panel8.Controls.Add(label22);
		panel8.Controls.Add(txtFecha);
		panel8.Controls.Add(txtprov);
		panel8.Controls.Add(label11);
		panel8.Controls.Add(label10);
		panel8.Controls.Add(label9);
		panel8.Controls.Add(txtIVA);
		panel8.Controls.Add(label8);
		panel8.Controls.Add(txtPrecio);
		panel8.Controls.Add(label6);
		panel8.Controls.Add(txtCantidad);
		panel8.Controls.Add(label5);
		panel8.Controls.Add(txtNombre);
		panel8.Controls.Add(label4);
		panel8.Controls.Add(txtCBA);
		panel8.Controls.Add(label3);
		panel8.Controls.Add(txtCB);
		panel8.Location = new System.Drawing.Point(19, 56);
		panel8.Name = "panel8";
		panel8.Size = new System.Drawing.Size(384, 554);
		panel8.TabIndex = 0;
		Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Min.Location = new System.Drawing.Point(295, 507);
		Min.Name = "Min";
		Min.Size = new System.Drawing.Size(77, 31);
		Min.TabIndex = 20;
		label23.AutoSize = true;
		label23.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label23.Location = new System.Drawing.Point(201, 507);
		label23.Name = "label23";
		label23.Size = new System.Drawing.Size(93, 30);
		label23.TabIndex = 19;
		label23.Text = "Minimos";
		Max.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Max.Location = new System.Drawing.Point(111, 509);
		Max.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
		Max.Name = "Max";
		Max.Size = new System.Drawing.Size(84, 31);
		Max.TabIndex = 18;
		label22.AutoSize = true;
		label22.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label22.Location = new System.Drawing.Point(8, 509);
		label22.Name = "label22";
		label22.Size = new System.Drawing.Size(97, 30);
		label22.TabIndex = 17;
		label22.Text = "Maximos";
		txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtFecha.Location = new System.Drawing.Point(118, 453);
		txtFecha.Name = "txtFecha";
		txtFecha.Size = new System.Drawing.Size(251, 29);
		txtFecha.TabIndex = 15;
		txtprov.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtprov.FormattingEnabled = true;
		txtprov.Location = new System.Drawing.Point(118, 398);
		txtprov.Name = "txtprov";
		txtprov.Size = new System.Drawing.Size(251, 32);
		txtprov.TabIndex = 14;
		txtprov.Text = "Selecciona";
		label11.AutoSize = true;
		label11.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label11.Location = new System.Drawing.Point(5, 453);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(67, 30);
		label11.TabIndex = 13;
		label11.Text = "Fecha";
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label10.Location = new System.Drawing.Point(5, 399);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(107, 30);
		label10.TabIndex = 12;
		label10.Text = "Proveedor";
		label9.AutoSize = true;
		label9.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label9.Location = new System.Drawing.Point(5, 338);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(79, 30);
		label9.TabIndex = 11;
		label9.Text = "I.V.A %";
		txtIVA.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtIVA.Location = new System.Drawing.Point(121, 339);
		txtIVA.Name = "txtIVA";
		txtIVA.Size = new System.Drawing.Size(251, 33);
		txtIVA.TabIndex = 10;
		txtIVA.Text = "0";
		txtIVA.TextChanged += new System.EventHandler(txtIVA_TextChanged);
		txtIVA.Enter += new System.EventHandler(txtIVA_Enter);
		txtIVA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtIVA_KeyPress);
		txtIVA.Leave += new System.EventHandler(txtIVA_Leave);
		label8.AutoSize = true;
		label8.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label8.Location = new System.Drawing.Point(5, 279);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(70, 30);
		label8.TabIndex = 9;
		label8.Text = "Precio";
		txtPrecio.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtPrecio.Location = new System.Drawing.Point(121, 280);
		txtPrecio.Name = "txtPrecio";
		txtPrecio.Size = new System.Drawing.Size(251, 33);
		txtPrecio.TabIndex = 8;
		txtPrecio.Text = "0";
		txtPrecio.Click += new System.EventHandler(txtPrecio_Click);
		txtPrecio.TextChanged += new System.EventHandler(txtPrecio_TextChanged);
		txtPrecio.Leave += new System.EventHandler(txtPrecio_Leave);
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label6.Location = new System.Drawing.Point(5, 220);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(96, 30);
		label6.TabIndex = 7;
		label6.Text = "Cantidad";
		txtCantidad.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtCantidad.Location = new System.Drawing.Point(121, 221);
		txtCantidad.Name = "txtCantidad";
		txtCantidad.Size = new System.Drawing.Size(251, 33);
		txtCantidad.TabIndex = 6;
		txtCantidad.Text = "0";
		txtCantidad.Click += new System.EventHandler(txtCantidad_Click);
		txtCantidad.TextChanged += new System.EventHandler(txtCantidad_TextChanged);
		txtCantidad.KeyUp += new System.Windows.Forms.KeyEventHandler(txtCantidad_KeyUp);
		txtCantidad.Leave += new System.EventHandler(txtCantidad_Leave);
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.Location = new System.Drawing.Point(5, 159);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(89, 30);
		label5.TabIndex = 5;
		label5.Text = "Nombre";
		txtNombre.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtNombre.Location = new System.Drawing.Point(121, 160);
		txtNombre.MaxLength = 12;
		txtNombre.Name = "txtNombre";
		txtNombre.Size = new System.Drawing.Size(251, 33);
		txtNombre.TabIndex = 4;
		txtNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(txtNombre_KeyUp);
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(5, 98);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(153, 30);
		label4.TabIndex = 3;
		label4.Text = "Codigo Alterno";
		txtCBA.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtCBA.Location = new System.Drawing.Point(180, 99);
		txtCBA.Name = "txtCBA";
		txtCBA.Size = new System.Drawing.Size(192, 33);
		txtCBA.TabIndex = 2;
		txtCBA.KeyUp += new System.Windows.Forms.KeyEventHandler(txtCBA_KeyUp);
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(5, 41);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(171, 30);
		label3.TabIndex = 1;
		label3.Text = "Codigo de Barras";
		txtCB.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtCB.Location = new System.Drawing.Point(180, 38);
		txtCB.Name = "txtCB";
		txtCB.Size = new System.Drawing.Size(192, 33);
		txtCB.TabIndex = 0;
		txtCB.KeyUp += new System.Windows.Forms.KeyEventHandler(txtCB_KeyUp);
		panel6.Controls.Add(dataGridView1);
		panel6.Location = new System.Drawing.Point(22, 248);
		panel6.Name = "panel6";
		panel6.Size = new System.Drawing.Size(299, 193);
		panel6.TabIndex = 2;
		dataGridView1.AllowUserToAddRows = false;
		dataGridView1.AllowUserToDeleteRows = false;
		dataGridView1.BackgroundColor = System.Drawing.Color.White;
		dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView1.GridColor = System.Drawing.Color.White;
		dataGridView1.Location = new System.Drawing.Point(0, 0);
		dataGridView1.Name = "dataGridView1";
		dataGridView1.Size = new System.Drawing.Size(296, 179);
		dataGridView1.TabIndex = 0;
		dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellClick);
		panel5.Controls.Add(button1);
		panel5.Controls.Add(label2);
		panel5.Controls.Add(txtSearch);
		panel5.Location = new System.Drawing.Point(22, 76);
		panel5.Name = "panel5";
		panel5.Size = new System.Drawing.Size(299, 168);
		panel5.TabIndex = 1;
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 192, 192);
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(23, 98);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(260, 51);
		button1.TabIndex = 2;
		button1.Text = "Mostrar todos los productos";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(88, 23);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(148, 13);
		label2.TabIndex = 1;
		label2.Text = "Escribe o escanea el codigo";
		txtSearch.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtSearch.Location = new System.Drawing.Point(23, 46);
		txtSearch.Name = "txtSearch";
		txtSearch.Size = new System.Drawing.Size(260, 39);
		txtSearch.TabIndex = 0;
		txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSearch_KeyPress);
		panel4.BackColor = System.Drawing.Color.SteelBlue;
		panel4.Controls.Add(label1);
		panel4.Location = new System.Drawing.Point(22, 42);
		panel4.Name = "panel4";
		panel4.Size = new System.Drawing.Size(299, 34);
		panel4.TabIndex = 0;
		panel4.Paint += new System.Windows.Forms.PaintEventHandler(panel4_Paint);
		label1.AutoSize = true;
		label1.BackColor = System.Drawing.Color.SteelBlue;
		label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.ForeColor = System.Drawing.Color.White;
		label1.Location = new System.Drawing.Point(91, 2);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(116, 25);
		label1.TabIndex = 0;
		label1.Text = "BUCADOR";
		label1.Click += new System.EventHandler(label1_Click);
		pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox6.Image = BLUPOINT.Properties.Resources.promociones;
		pictureBox6.Location = new System.Drawing.Point(19, 119);
		pictureBox6.Name = "pictureBox6";
		pictureBox6.Size = new System.Drawing.Size(75, 73);
		pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox6.TabIndex = 6;
		pictureBox6.TabStop = false;
		pictureBox6.Click += new System.EventHandler(pictureBox6_Click);
		label24.AutoSize = true;
		label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label24.Location = new System.Drawing.Point(4, 192);
		label24.Name = "label24";
		label24.Size = new System.Drawing.Size(138, 15);
		label24.TabIndex = 7;
		label24.Text = "Agregar Promocion (F8)";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1230, 788);
		base.Controls.Add(panel3);
		base.Controls.Add(panel1);
		base.Controls.Add(panel2);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Producto";
		Text = "Producto";
		base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Producto_FormClosing);
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Producto_FormClosed);
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Producto_KeyUp);
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)btnoption).EndInit();
		panel16.ResumeLayout(false);
		panel16.PerformLayout();
		((System.ComponentModel.ISupportInitialize)image_user).EndInit();
		panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)search).EndInit();
		((System.ComponentModel.ISupportInitialize)delete).EndInit();
		((System.ComponentModel.ISupportInitialize)cancel).EndInit();
		((System.ComponentModel.ISupportInitialize)save).EndInit();
		((System.ComponentModel.ISupportInitialize)edit).EndInit();
		((System.ComponentModel.ISupportInitialize)add).EndInit();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		panel17.ResumeLayout(false);
		panel17.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		panel7.ResumeLayout(false);
		panel7.PerformLayout();
		panel13.ResumeLayout(false);
		panel13.PerformLayout();
		panel12.ResumeLayout(false);
		panel12.PerformLayout();
		panel11.ResumeLayout(false);
		panel15.ResumeLayout(false);
		panel15.PerformLayout();
		panel14.ResumeLayout(false);
		panel14.PerformLayout();
		panel10.ResumeLayout(false);
		panel10.PerformLayout();
		panel9.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel8.ResumeLayout(false);
		panel8.PerformLayout();
		((System.ComponentModel.ISupportInitialize)Min).EndInit();
		((System.ComponentModel.ISupportInitialize)Max).EndInit();
		panel6.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
		panel5.ResumeLayout(false);
		panel5.PerformLayout();
		panel4.ResumeLayout(false);
		panel4.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
		ResumeLayout(false);
	}
}

// BLUPOINT.Program
using System;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Config;
using BLUPOINT.Source;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		DB dB = new DB();
		Negocio negocio = new Negocio();
		try
		{
			dB.Conexion().Open();
			if (negocio.GetLogin() == 1)
			{
				Application.Run(new Login());
			}
			else if (negocio.GetLogin() == 2)
			{
				Application.Run(new Login_2());
			}
		}
		catch
		{
			Application.Run(new Star_Install());
		}
	}
}

// BLUPOINT.Proveedor
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Proveedor : Form
{
	private bool edits;

	private Proveedores prov;

	private string tipos;

	private IContainer components = null;

	private Panel panel1;

	private Label label5;

	private TextBox txtName;

	private Panel panel2;

	private DataGridView dgv1;

	private Panel panel3;

	private Label label4;

	private Label label3;

	private Label label2;

	private Label label1;

	private DateTimePicker txtreg;

	private TextBox txtmail;

	private TextBox txttelefono;

	private TextBox txtNombre;

	private PictureBox borrar;

	private PictureBox edit;

	private PictureBox add;

	private Label txtid;

	private PictureBox saves;

	public Proveedor(string tipo)
	{
		InitializeComponent();
		Disabled();
		base.KeyPreview = true;
		base.KeyDown += Proveedor_KeyUp;
		tipos = tipo;
	}

	private void Disabled()
	{
		edits = false;
		add.Enabled = true;
		add.Image = Resources.anadir;
		prov = new Proveedores();
		dgv1.DataSource = prov.GET();
		edit.Enabled = false;
		saves.Enabled = false;
		borrar.Enabled = false;
		edit.Image = Resources.editar1;
		saves.Image = Resources.disquete1;
		borrar.Image = Resources.borrar1;
		txtNombre.Enabled = false;
		txtmail.Enabled = false;
		txtreg.Enabled = false;
		txttelefono.Enabled = false;
	}

	private void Limpiar()
	{
		txtmail.Text = "";
		txtName.Text = "";
		txtNombre.Text = "";
		txttelefono.Text = "";
		txtreg.ResetText();
	}

	private void Habilitar()
	{
		saves.Enabled = true;
		saves.Image = Resources.disquete;
		txtNombre.Enabled = true;
		txtmail.Enabled = true;
		txttelefono.Enabled = true;
		edits = false;
		txtNombre.Select();
	}

	private void LoadData()
	{
		try
		{
			txtNombre.Text = dgv1.Rows[0].Cells["Nombre"].Value.ToString();
			txtmail.Text = dgv1.Rows[0].Cells["Mail"].Value.ToString();
			txttelefono.Text = dgv1.Rows[0].Cells["Telefono"].Value.ToString();
			txtreg.Text = dgv1.Rows[0].Cells["Fecha"].Value.ToString();
			txtid.Text = dgv1.Rows[0].Cells["idProveedor"].Value.ToString();
			edit.Enabled = true;
			edit.Image = Resources.editar;
		}
		catch
		{
			MessageBox.Show("Proveedor sin existencia");
		}
	}

	private void ACT()
	{
		prov = new Proveedores(txtid.Text, txtNombre.Text, txttelefono.Text, txtmail.Text, txtreg.Value.Day + "/" + txtreg.Value.Month + "/" + txtreg.Value.Year);
		if (prov.UPDATE() == 1)
		{
			MessageBox.Show("Proveedor Actualizado con Exito");
			Disabled();
			Limpiar();
		}
		else
		{
			MessageBox.Show("Ha Ocurrido un Error");
		}
	}

	private void SAVE()
	{
		prov = new Proveedores("", txtNombre.Text, txttelefono.Text, txtmail.Text, txtreg.Value.Day + "/" + txtreg.Value.Month + "/" + txtreg.Value.Year);
		if (prov.POST() == 1)
		{
			MessageBox.Show("Proveedor Registrado con Exito");
			Disabled();
			Limpiar();
			if (!(tipos == ""))
			{
				Producto producto = base.Owner as Producto;
				producto.CargarCombo(cargar: true);
			}
		}
		else if (prov.POST() == 2 || prov.POST() == 0)
		{
			MessageBox.Show("Hubo un problema");
		}
		else if (prov.POST() == 3)
		{
			MessageBox.Show("Ya existe esta empresa");
		}
	}

	private void EnabledEdit()
	{
		saves.Enabled = true;
		add.Enabled = false;
		borrar.Enabled = true;
		add.Image = Resources.anadir1;
		edit.Image = Resources.editar;
		saves.Image = Resources.disquete;
		borrar.Image = Resources.borrar;
		txtNombre.Enabled = true;
		txtmail.Enabled = true;
		txttelefono.Enabled = true;
		edits = true;
		MessageBox.Show("Edicion Habilitada");
	}

	private void add_Click(object sender, EventArgs e)
	{
		Habilitar();
	}

	private void edit_Click(object sender, EventArgs e)
	{
		if (txtid.Text == "0")
		{
			MessageBox.Show("Debes Seleccionar un campo");
		}
		else
		{
			EnabledEdit();
		}
	}

	private void save_Click(object sender, EventArgs e)
	{
	}

	private void borrar_Click(object sender, EventArgs e)
	{
		if (txtid.Text == "")
		{
			MessageBox.Show("Debes seleccionar un Proveedor Antes");
			return;
		}
		prov = new Proveedores();
		prov.id = txtid.Text;
		prov.DELETE();
		Limpiar();
		Disabled();
	}

	private void txtName_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			prov = new Proveedores();
			prov.Nombre = txtName.Text;
			dgv1.DataSource = prov.GETBYNAME();
			LoadData();
		}
	}

	private void saves_Click(object sender, EventArgs e)
	{
		if (!edits)
		{
			SAVE();
		}
		else
		{
			ACT();
		}
	}

	private void Proveedor_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && MessageBox.Show("Cancelar", "Deseas Cancelar??", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
		{
			Limpiar();
			Disabled();
		}
		if (e.KeyCode == Keys.F1)
		{
			Habilitar();
		}
		else if (e.KeyCode == Keys.F2)
		{
			if (txtid.Text == "0")
			{
				MessageBox.Show("Debes Seleccionar un campo");
			}
			else
			{
				EnabledEdit();
			}
		}
		else if (e.KeyCode == Keys.F3)
		{
			if (!edits)
			{
				SAVE();
			}
			else
			{
				ACT();
			}
		}
		else if (e.KeyCode == Keys.F4)
		{
			if (txtid.Text == "")
			{
				MessageBox.Show("Debes seleccionar un Proveedor Antes");
				return;
			}
			prov = new Proveedores();
			prov.id = txtid.Text;
			prov.DELETE();
			Limpiar();
			Disabled();
		}
		else if (e.Control && e.KeyCode == Keys.E)
		{
			Close();
		}
	}

	private void Proveedor_FormClosing(object sender, FormClosingEventArgs e)
	{
	}

	private void txttelefono_TextChanged(object sender, EventArgs e)
	{
		if (!(txttelefono.Text == ""))
		{
			try
			{
				long num = Convert.ToInt64(txttelefono.Text);
			}
			catch
			{
				MessageBox.Show("Solo se pueden introducir Numeros");
				txttelefono.Text = "";
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
		panel1 = new System.Windows.Forms.Panel();
		saves = new System.Windows.Forms.PictureBox();
		txtid = new System.Windows.Forms.Label();
		borrar = new System.Windows.Forms.PictureBox();
		edit = new System.Windows.Forms.PictureBox();
		add = new System.Windows.Forms.PictureBox();
		label5 = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.TextBox();
		panel2 = new System.Windows.Forms.Panel();
		dgv1 = new System.Windows.Forms.DataGridView();
		panel3 = new System.Windows.Forms.Panel();
		label4 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		txtreg = new System.Windows.Forms.DateTimePicker();
		txtmail = new System.Windows.Forms.TextBox();
		txttelefono = new System.Windows.Forms.TextBox();
		txtNombre = new System.Windows.Forms.TextBox();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)saves).BeginInit();
		((System.ComponentModel.ISupportInitialize)borrar).BeginInit();
		((System.ComponentModel.ISupportInitialize)edit).BeginInit();
		((System.ComponentModel.ISupportInitialize)add).BeginInit();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dgv1).BeginInit();
		panel3.SuspendLayout();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(saves);
		panel1.Controls.Add(txtid);
		panel1.Controls.Add(borrar);
		panel1.Controls.Add(edit);
		panel1.Controls.Add(add);
		panel1.Controls.Add(label5);
		panel1.Controls.Add(txtName);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(770, 66);
		panel1.TabIndex = 0;
		saves.Cursor = System.Windows.Forms.Cursors.Hand;
		saves.Image = BLUPOINT.Properties.Resources.disquete1;
		saves.Location = new System.Drawing.Point(589, 16);
		saves.Name = "saves";
		saves.Size = new System.Drawing.Size(48, 50);
		saves.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		saves.TabIndex = 14;
		saves.TabStop = false;
		saves.Click += new System.EventHandler(saves_Click);
		txtid.AutoSize = true;
		txtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtid.ForeColor = System.Drawing.Color.White;
		txtid.Location = new System.Drawing.Point(9, 9);
		txtid.Name = "txtid";
		txtid.Size = new System.Drawing.Size(16, 18);
		txtid.TabIndex = 13;
		txtid.Text = "0";
		borrar.Cursor = System.Windows.Forms.Cursors.Hand;
		borrar.Image = BLUPOINT.Properties.Resources.borrar1;
		borrar.Location = new System.Drawing.Point(652, 16);
		borrar.Name = "borrar";
		borrar.Size = new System.Drawing.Size(48, 50);
		borrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		borrar.TabIndex = 12;
		borrar.TabStop = false;
		borrar.Click += new System.EventHandler(borrar_Click);
		edit.Cursor = System.Windows.Forms.Cursors.Hand;
		edit.Image = BLUPOINT.Properties.Resources.editar1;
		edit.Location = new System.Drawing.Point(519, 13);
		edit.Name = "edit";
		edit.Size = new System.Drawing.Size(48, 50);
		edit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		edit.TabIndex = 10;
		edit.TabStop = false;
		edit.Click += new System.EventHandler(edit_Click);
		add.Cursor = System.Windows.Forms.Cursors.Hand;
		add.Image = BLUPOINT.Properties.Resources.anadir;
		add.Location = new System.Drawing.Point(452, 12);
		add.Name = "add";
		add.Size = new System.Drawing.Size(48, 50);
		add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		add.TabIndex = 9;
		add.TabStop = false;
		add.Click += new System.EventHandler(add_Click);
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.Location = new System.Drawing.Point(148, 9);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(126, 18);
		label5.TabIndex = 8;
		label5.Text = "Nombre Empresa";
		txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtName.Location = new System.Drawing.Point(44, 32);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(324, 31);
		txtName.TabIndex = 8;
		txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtName_KeyPress);
		panel2.BackColor = System.Drawing.Color.White;
		panel2.Controls.Add(dgv1);
		panel2.Location = new System.Drawing.Point(12, 87);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(356, 310);
		panel2.TabIndex = 1;
		dgv1.BackgroundColor = System.Drawing.Color.White;
		dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgv1.Location = new System.Drawing.Point(3, 3);
		dgv1.Name = "dgv1";
		dgv1.Size = new System.Drawing.Size(350, 323);
		dgv1.TabIndex = 0;
		panel3.BackColor = System.Drawing.Color.White;
		panel3.Controls.Add(label4);
		panel3.Controls.Add(label3);
		panel3.Controls.Add(label2);
		panel3.Controls.Add(label1);
		panel3.Controls.Add(txtreg);
		panel3.Controls.Add(txtmail);
		panel3.Controls.Add(txttelefono);
		panel3.Controls.Add(txtNombre);
		panel3.Location = new System.Drawing.Point(388, 87);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(356, 310);
		panel3.TabIndex = 2;
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(3, 249);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(109, 18);
		label4.TabIndex = 7;
		label4.Text = "Fecha Registro";
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(3, 179);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(123, 18);
		label3.TabIndex = 6;
		label3.Text = "Correo  Empresa";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(3, 111);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(130, 18);
		label2.TabIndex = 5;
		label2.Text = "Telefono Empresa";
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(3, 53);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(126, 18);
		label1.TabIndex = 4;
		label1.Text = "Nombre Empresa";
		txtreg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtreg.Location = new System.Drawing.Point(147, 239);
		txtreg.Name = "txtreg";
		txtreg.Size = new System.Drawing.Size(193, 31);
		txtreg.TabIndex = 3;
		txtmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtmail.Location = new System.Drawing.Point(147, 171);
		txtmail.Name = "txtmail";
		txtmail.Size = new System.Drawing.Size(193, 31);
		txtmail.TabIndex = 2;
		txttelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttelefono.Location = new System.Drawing.Point(147, 111);
		txttelefono.MaxLength = 11;
		txttelefono.Name = "txttelefono";
		txttelefono.Size = new System.Drawing.Size(193, 31);
		txttelefono.TabIndex = 1;
		txttelefono.TextChanged += new System.EventHandler(txttelefono_TextChanged);
		txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtNombre.Location = new System.Drawing.Point(147, 45);
		txtNombre.Name = "txtNombre";
		txtNombre.Size = new System.Drawing.Size(193, 31);
		txtNombre.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(770, 450);
		base.Controls.Add(panel3);
		base.Controls.Add(panel2);
		base.Controls.Add(panel1);
		base.Name = "Proveedor";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Proveedor";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Proveedor_FormClosing);
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Proveedor_KeyUp);
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)saves).EndInit();
		((System.ComponentModel.ISupportInitialize)borrar).EndInit();
		((System.ComponentModel.ISupportInitialize)edit).EndInit();
		((System.ComponentModel.ISupportInitialize)add).EndInit();
		panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)dgv1).EndInit();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		ResumeLayout(false);
	}
}

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

// BLUPOINT.Rep_Caja_Usr
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Rep_Caja_Usr : Form
{
	private string ids;

	private Empleados emp = new Empleados();

	private Caja cj = new Caja();

	private IContainer components = null;

	private Panel panel1;

	private Label label1;

	private Panel panel16;

	private Label txttipo_e;

	private PictureBox image_user;

	private Label label18;

	private Label txtName;

	private Panel panel2;

	private Button button2;

	private DateTimePicker txtDate;

	private Button button1;

	private Label lbldate;

	private ComboBox cbfilter;

	private DataGridView dgvru;

	private PrintDocument printDocument1;

	public Rep_Caja_Usr(string id, string nombre, string ruta, string cargo)
	{
		InitializeComponent();
		txtName.Text = nombre;
		txttipo_e.Text = cargo;
		base.KeyPreview = true;
		if (ruta == "")
		{
			image_user.Image = Resources.picture;
		}
		else
		{
			image_user.Image = Image.FromFile(ruta);
		}
		txtDate.Visible = false;
		lbldate.Visible = false;
		LoadMoney();
		Iniciar();
	}

	public void LoadMoney()
	{
		DataTable dataTable = new DataTable();
		try
		{
			dataTable = cj.GETMONEY();
			ids = dataTable.Rows[0]["idCaja"].ToString();
		}
		catch
		{
		}
	}

	private void Iniciar()
	{
		emp.id = ids;
		emp.Nombre_E = txtName.Text;
		DateTime now = DateTime.Now;
		emp.Fecha_N = now.ToString("dd/MMMM/yyyy");
		dgvru.DataSource = emp.GETBOX("Normal");
	}

	private void cbfilter_TextChanged(object sender, EventArgs e)
	{
		lbldate.Visible = true;
		txtDate.Visible = true;
		if (cbfilter.Text == "DIA")
		{
			lbldate.Text = "Digita el Dia a solicitar";
		}
		else if (cbfilter.Text == "MES")
		{
			lbldate.Text = "Digita el Mes a solicitar";
		}
		else if (cbfilter.Text == "AÑO")
		{
			lbldate.Text = "Digita el Año a solicitar";
		}
	}

	private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\r')
		{
			return;
		}
		if (cbfilter.Text == "DIA")
		{
			emp.id = ids;
			if (txtDate.Value.Day.ToString().Length >= 2)
			{
				emp.Fecha_N = txtDate.Value.Day + "/" + Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			}
			else
			{
				emp.Fecha_N = "0" + txtDate.Value.Day + "/" + Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			}
			dgvru.DataSource = emp.GETBOX("Dia");
		}
		else if (cbfilter.Text == "MES")
		{
			emp.id = ids;
			emp.Fecha_N = Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			dgvru.DataSource = emp.GETBOX("Mes");
		}
		else if (cbfilter.Text == "AÑO")
		{
			emp.id = ids;
			emp.Fecha_N = txtDate.Value.Year.ToString();
			dgvru.DataSource = emp.GETBOX("Anio");
		}
	}

	private string Selectdate(string mont)
	{
		return mont switch
		{
			"1" => "Enero", 
			"2" => "Febrero", 
			"3" => "Marzo", 
			"4" => "Abril", 
			"5" => "Mayo", 
			"6" => "Junio", 
			"7" => "Julio", 
			"8" => "Agosto", 
			"9" => "Septiembre", 
			"10" => "Octubre", 
			"11" => "Noviembre", 
			"12" => "Diciembre", 
			_ => "", 
		};
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Det_Box_Us det_Box_Us = new Det_Box_Us(dgvru.CurrentRow.Cells["Fecha"].Value.ToString(), dgvru.CurrentRow.Cells["open"].Value.ToString(), dgvru.CurrentRow.Cells["Tipo_Consumo"].Value.ToString());
		det_Box_Us.Show();
	}

	private void Rep_Caja_Usr_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F2)
		{
			Det_Box_Us det_Box_Us = new Det_Box_Us(dgvru.CurrentRow.Cells["Fecha"].Value.ToString(), dgvru.CurrentRow.Cells["open"].Value.ToString(), dgvru.CurrentRow.Cells["Tipo_Consumo"].Value.ToString());
			det_Box_Us.Show();
		}
		if (e.KeyCode == Keys.Control && e.KeyCode == Keys.P)
		{
			Print();
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
		Negocio negocio = new Negocio();
		DataTable dataTable = new DataTable();
		dataTable = negocio.GetNegocio();
		string s = "Calle: " + dataTable.Rows[0]["Calle"].ToString() + ", #" + dataTable.Rows[0]["Numero_Ext"].ToString() + ", Col. " + dataTable.Rows[0]["Colonia"].ToString() + "\n" + dataTable.Rows[0]["Municipio"].ToString() + ", " + dataTable.Rows[0]["Estado"].ToString() + ", C.P: " + dataTable.Rows[0]["CP"].ToString();
		Font font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Point);
		Font font2 = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point);
		Font font3 = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point);
		Font font4 = new Font("Segoe UI", 5f, FontStyle.Regular, GraphicsUnit.Point);
		Font font5 = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point);
		int num = 220;
		int num2 = 20;
		e.Graphics.DrawString(" ***" + dataTable.Rows[0]["Nombre_N"].ToString() + "*** ", font, Brushes.Black, new RectangleF(0f, num2 += 10, num, 20f));
		e.Graphics.DrawString(s, font3, Brushes.Black, new RectangleF(8f, num2 += 20, num, num2 + 20));
		e.Graphics.DrawString("Tel: " + dataTable.Rows[0]["Telefono"].ToString(), font3, Brushes.Black, new RectangleF(8f, num2 += 25, num, num2 + 15));
		e.Graphics.DrawString("Reporte de Caja por Usuario", font3, Brushes.Black, new RectangleF(8f, num2 += 15, num, num2 + 20));
		e.Graphics.DrawString(" ************************************* ", font, Brushes.Black, new RectangleF(0f, num2 += 10, num, 20f));
		e.Graphics.DrawString("Nombre: " + txtName.Text, font3, Brushes.Black, new RectangleF(0f, num2 += 15, num, num2 + 20));
		e.Graphics.DrawString("Hora de Apertura", font2, Brushes.Black, new RectangleF(8f, num2 += 25, num, num2 + 20));
		foreach (DataGridViewRow item in (IEnumerable)dgvru.Rows)
		{
			e.Graphics.DrawString(item.Cells["open"].Value?.ToString() + " ", font2, Brushes.Black, new RectangleF(8f, num2 += 20, num, num2 + 15));
		}
		e.Graphics.DrawString("Fecha de Solicitud: " + txtDate.Value.Day + "/" + txtDate.Value.Month + "/" + txtDate.Value.Year, font3, Brushes.Black, new RectangleF(0f, num2 += 15, num, num2 + 15));
		e.Graphics.DrawString(" ************************************* ", font, Brushes.Black, new RectangleF(0f, num2 += 10, num, 20f));
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Rep_Caja_Usr));
		panel1 = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
		panel16 = new System.Windows.Forms.Panel();
		txttipo_e = new System.Windows.Forms.Label();
		label18 = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.Label();
		panel2 = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		txtDate = new System.Windows.Forms.DateTimePicker();
		button1 = new System.Windows.Forms.Button();
		lbldate = new System.Windows.Forms.Label();
		cbfilter = new System.Windows.Forms.ComboBox();
		dgvru = new System.Windows.Forms.DataGridView();
		image_user = new System.Windows.Forms.PictureBox();
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		panel1.SuspendLayout();
		panel16.SuspendLayout();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dgvru).BeginInit();
		((System.ComponentModel.ISupportInitialize)image_user).BeginInit();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(label1);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(934, 64);
		panel1.TabIndex = 3;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Impact", 27.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(324, 9);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(266, 45);
		label1.TabIndex = 0;
		label1.Text = "REPORTE DE CAJA";
		panel16.BackColor = System.Drawing.Color.White;
		panel16.Controls.Add(txttipo_e);
		panel16.Controls.Add(image_user);
		panel16.Controls.Add(label18);
		panel16.Controls.Add(txtName);
		panel16.Location = new System.Drawing.Point(584, 79);
		panel16.Name = "panel16";
		panel16.Size = new System.Drawing.Size(342, 281);
		panel16.TabIndex = 4;
		txttipo_e.AutoSize = true;
		txttipo_e.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttipo_e.Location = new System.Drawing.Point(124, 245);
		txttipo_e.Name = "txttipo_e";
		txttipo_e.Size = new System.Drawing.Size(65, 24);
		txttipo_e.TabIndex = 28;
		txttipo_e.Text = "Cajero";
		label18.AutoSize = true;
		label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label18.ForeColor = System.Drawing.SystemColors.AppWorkspace;
		label18.Location = new System.Drawing.Point(57, 245);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(61, 24);
		label18.TabIndex = 26;
		label18.Text = "Cargo";
		txtName.AutoSize = true;
		txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtName.Location = new System.Drawing.Point(34, 215);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(197, 24);
		txtName.TabIndex = 25;
		txtName.Text = "Jorge Lemus Stripsent";
		panel2.BackColor = System.Drawing.Color.White;
		panel2.Controls.Add(button2);
		panel2.Controls.Add(txtDate);
		panel2.Controls.Add(button1);
		panel2.Controls.Add(lbldate);
		panel2.Controls.Add(cbfilter);
		panel2.Location = new System.Drawing.Point(584, 380);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(342, 210);
		panel2.TabIndex = 5;
		button2.BackColor = System.Drawing.Color.SteelBlue;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Location = new System.Drawing.Point(179, 133);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(156, 52);
		button2.TabIndex = 5;
		button2.Text = "Detalle (F2)";
		button2.UseVisualStyleBackColor = false;
		button2.Click += new System.EventHandler(button2_Click);
		txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtDate.Location = new System.Drawing.Point(9, 81);
		txtDate.Name = "txtDate";
		txtDate.Size = new System.Drawing.Size(296, 26);
		txtDate.TabIndex = 4;
		txtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDate_KeyPress);
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(3, 133);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(162, 52);
		button1.TabIndex = 3;
		button1.Text = "Imprimir (Ctr+p)";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		lbldate.AutoSize = true;
		lbldate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lbldate.Location = new System.Drawing.Point(93, 60);
		lbldate.Name = "lbldate";
		lbldate.Size = new System.Drawing.Size(45, 18);
		lbldate.TabIndex = 2;
		lbldate.Text = "Digita";
		cbfilter.BackColor = System.Drawing.Color.White;
		cbfilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		cbfilter.ForeColor = System.Drawing.Color.Black;
		cbfilter.FormattingEnabled = true;
		cbfilter.Items.AddRange(new object[3] { "DIA", "MES", "AÑO" });
		cbfilter.Location = new System.Drawing.Point(38, 3);
		cbfilter.Name = "cbfilter";
		cbfilter.Size = new System.Drawing.Size(248, 33);
		cbfilter.TabIndex = 0;
		cbfilter.Text = "FILTRAR";
		cbfilter.TextChanged += new System.EventHandler(cbfilter_TextChanged);
		dgvru.BackgroundColor = System.Drawing.Color.White;
		dgvru.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgvru.Location = new System.Drawing.Point(12, 82);
		dgvru.Name = "dgvru";
		dgvru.Size = new System.Drawing.Size(565, 511);
		dgvru.TabIndex = 6;
		image_user.Image = (System.Drawing.Image)resources.GetObject("image_user.Image");
		image_user.Location = new System.Drawing.Point(38, 3);
		image_user.Name = "image_user";
		image_user.Size = new System.Drawing.Size(229, 209);
		image_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		image_user.TabIndex = 24;
		image_user.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(934, 605);
		base.Controls.Add(dgvru);
		base.Controls.Add(panel2);
		base.Controls.Add(panel16);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Rep_Caja_Usr";
		Text = "Rep_Caja_Usr";
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Rep_Caja_Usr_KeyUp);
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		panel16.ResumeLayout(false);
		panel16.PerformLayout();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)dgvru).EndInit();
		((System.ComponentModel.ISupportInitialize)image_user).EndInit();
		ResumeLayout(false);
	}
}

// BLUPOINT.Rep_Venta
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Rep_Venta : Form
{
	private Ventas ven = new Ventas();

	private string filtro;

	private string ids;

	private IContainer components = null;

	private Panel panel1;

	private DataGridView dgv1;

	private Label label1;

	private Panel panel2;

	private Label txtcant;

	private Label label2;

	private Label txttipo_e;

	private PictureBox image_user;

	private Label label18;

	private Label txtName;

	private Panel panel3;

	private DateTimePicker txtDate;

	private ComboBox cbfilter;

	private Panel panel4;

	private Label label5;

	private Label txttotal;

	private Label label4;

	public Rep_Venta(string id, string nombre, string ruta, string cargo)
	{
		InitializeComponent();
		txtName.Text = nombre;
		txttipo_e.Text = cargo;
		ids = id;
		if (ruta == "")
		{
			image_user.Image = Resources.picture;
		}
		else
		{
			image_user.Image = Image.FromFile(ruta);
		}
		txtDate.Visible = false;
		Loads();
		CountVentas();
	}

	private void CountVentas()
	{
		int num = 0;
		double num2 = 0.0;
		foreach (DataGridViewRow item in (IEnumerable)dgv1.Rows)
		{
			num++;
			num2 += Convert.ToDouble(item.Cells["Total"].Value);
		}
		txttotal.Text = num2.ToString();
		txtcant.Text = num.ToString();
	}

	private void Loads()
	{
		ven.Nombre_E = txtName.Text;
		DateTime now = DateTime.Now;
		ven.Fecha = now.ToString("dd/MMMM/yyyy");
		dgv1.DataSource = ven.GET("Normal");
	}

	private void cbfilter_TextChanged(object sender, EventArgs e)
	{
		if (cbfilter.Text == "DIA")
		{
			txtDate.Visible = true;
			filtro = "Dia";
		}
		if (cbfilter.Text == "MES")
		{
			txtDate.Visible = true;
			filtro = "Mes";
		}
		if (cbfilter.Text == "AÑO")
		{
			txtDate.Visible = true;
			filtro = "Año";
		}
	}

	private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\r')
		{
			return;
		}
		if (filtro == "Dia")
		{
			ven.Nombre_E = txtName.Text;
			if (txtDate.Value.Day.ToString().Length >= 2)
			{
				ven.Fecha = txtDate.Value.Day + "/" + Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			}
			else
			{
				ven.Fecha = "0" + txtDate.Value.Day + "/" + Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			}
			dgv1.DataSource = ven.GET("Dia");
		}
		else if (filtro == "Mes")
		{
			ven.Nombre_E = txtName.Text;
			ven.Fecha = Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			dgv1.DataSource = ven.GET("Mes");
		}
		else if (filtro == "Año")
		{
			ven.Nombre_E = txtName.Text;
			ven.Fecha = txtDate.Value.Year.ToString();
			dgv1.DataSource = ven.GET("Año");
		}
		CountVentas();
	}

	private void button1_Click(object sender, EventArgs e)
	{
	}

	private string Selectdate(string mont)
	{
		return mont switch
		{
			"1" => "Enero", 
			"2" => "Febrero", 
			"3" => "Marzo", 
			"4" => "Abril", 
			"5" => "Mayo", 
			"6" => "Junio", 
			"7" => "Julio", 
			"8" => "Agosto", 
			"9" => "Septiembre", 
			"10" => "Octubre", 
			"11" => "Noviembre", 
			"12" => "Diciembre", 
			_ => "", 
		};
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Rep_Venta));
		panel1 = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
		dgv1 = new System.Windows.Forms.DataGridView();
		panel2 = new System.Windows.Forms.Panel();
		label5 = new System.Windows.Forms.Label();
		txttotal = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		txtcant = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		txttipo_e = new System.Windows.Forms.Label();
		image_user = new System.Windows.Forms.PictureBox();
		label18 = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.Label();
		panel3 = new System.Windows.Forms.Panel();
		txtDate = new System.Windows.Forms.DateTimePicker();
		cbfilter = new System.Windows.Forms.ComboBox();
		panel4 = new System.Windows.Forms.Panel();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dgv1).BeginInit();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)image_user).BeginInit();
		panel3.SuspendLayout();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(label1);
		panel1.Controls.Add(dgv1);
		panel1.Location = new System.Drawing.Point(12, 12);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(421, 434);
		panel1.TabIndex = 0;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(71, 12);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(247, 25);
		label1.TabIndex = 1;
		label1.Text = "VENTAS POR USUARIO";
		dgv1.AllowUserToAddRows = false;
		dgv1.AllowUserToDeleteRows = false;
		dgv1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
		dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgv1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
		dgv1.Location = new System.Drawing.Point(3, 55);
		dgv1.Name = "dgv1";
		dgv1.Size = new System.Drawing.Size(415, 371);
		dgv1.TabIndex = 0;
		panel2.BackColor = System.Drawing.Color.White;
		panel2.Controls.Add(label5);
		panel2.Controls.Add(txttotal);
		panel2.Controls.Add(label4);
		panel2.Controls.Add(txtcant);
		panel2.Controls.Add(label2);
		panel2.Controls.Add(txttipo_e);
		panel2.Controls.Add(image_user);
		panel2.Controls.Add(label18);
		panel2.Controls.Add(txtName);
		panel2.Location = new System.Drawing.Point(465, 15);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(423, 259);
		panel2.TabIndex = 1;
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.ForeColor = System.Drawing.Color.Teal;
		label5.Location = new System.Drawing.Point(248, 215);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(36, 39);
		label5.TabIndex = 37;
		label5.Text = "$";
		txttotal.AutoSize = true;
		txttotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttotal.ForeColor = System.Drawing.Color.Teal;
		txttotal.Location = new System.Drawing.Point(277, 215);
		txttotal.Name = "txttotal";
		txttotal.Size = new System.Drawing.Size(36, 39);
		txttotal.TabIndex = 36;
		txttotal.Text = "0";
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
		label4.Location = new System.Drawing.Point(256, 188);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(160, 24);
		label4.TabIndex = 35;
		label4.Text = "Cantidad Vendida";
		txtcant.AutoSize = true;
		txtcant.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtcant.ForeColor = System.Drawing.Color.Teal;
		txtcant.Location = new System.Drawing.Point(305, 117);
		txtcant.Name = "txtcant";
		txtcant.Size = new System.Drawing.Size(36, 39);
		txtcant.TabIndex = 34;
		txtcant.Text = "0";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
		label2.Location = new System.Drawing.Point(256, 93);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(134, 24);
		label2.TabIndex = 33;
		label2.Text = "Ventas Totales";
		txttipo_e.AutoSize = true;
		txttipo_e.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttipo_e.Location = new System.Drawing.Point(323, 34);
		txttipo_e.Name = "txttipo_e";
		txttipo_e.Size = new System.Drawing.Size(65, 24);
		txttipo_e.TabIndex = 32;
		txttipo_e.Text = "Cajero";
		image_user.Image = (System.Drawing.Image)resources.GetObject("image_user.Image");
		image_user.Location = new System.Drawing.Point(13, 3);
		image_user.Name = "image_user";
		image_user.Size = new System.Drawing.Size(229, 209);
		image_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		image_user.TabIndex = 29;
		image_user.TabStop = false;
		label18.AutoSize = true;
		label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label18.ForeColor = System.Drawing.SystemColors.AppWorkspace;
		label18.Location = new System.Drawing.Point(256, 34);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(61, 24);
		label18.TabIndex = 31;
		label18.Text = "Cargo";
		txtName.AutoSize = true;
		txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtName.Location = new System.Drawing.Point(9, 215);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(197, 24);
		txtName.TabIndex = 30;
		txtName.Text = "Jorge Lemus Stripsent";
		panel3.BackColor = System.Drawing.Color.White;
		panel3.Controls.Add(txtDate);
		panel3.Controls.Add(cbfilter);
		panel3.Location = new System.Drawing.Point(465, 280);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(423, 81);
		panel3.TabIndex = 2;
		txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtDate.Location = new System.Drawing.Point(13, 52);
		txtDate.Name = "txtDate";
		txtDate.Size = new System.Drawing.Size(391, 26);
		txtDate.TabIndex = 7;
		txtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDate_KeyPress);
		cbfilter.BackColor = System.Drawing.Color.White;
		cbfilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		cbfilter.ForeColor = System.Drawing.Color.Black;
		cbfilter.FormattingEnabled = true;
		cbfilter.Items.AddRange(new object[3] { "DIA", "MES", "AÑO" });
		cbfilter.Location = new System.Drawing.Point(3, 3);
		cbfilter.Name = "cbfilter";
		cbfilter.Size = new System.Drawing.Size(401, 33);
		cbfilter.TabIndex = 5;
		cbfilter.Text = "FILTRAR";
		cbfilter.TextChanged += new System.EventHandler(cbfilter_TextChanged);
		panel4.BackColor = System.Drawing.Color.White;
		panel4.Location = new System.Drawing.Point(467, 369);
		panel4.Name = "panel4";
		panel4.Size = new System.Drawing.Size(420, 68);
		panel4.TabIndex = 3;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(900, 450);
		base.Controls.Add(panel4);
		base.Controls.Add(panel3);
		base.Controls.Add(panel2);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Rep_Venta";
		Text = "Reporte Venta por Usuario";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)dgv1).EndInit();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)image_user).EndInit();
		panel3.ResumeLayout(false);
		ResumeLayout(false);
	}
}

// BLUPOINT.Reporte_Usuario
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Reporte_Usuario : Form
{
	private Empleados emp = new Empleados();

	private IContainer components = null;

	private DataGridView dgvru;

	private Panel panel1;

	private ComboBox cbfilter;

	private Panel panel2;

	private Panel panel16;

	private Label txttipo_e;

	private PictureBox image_user;

	private Label label18;

	private Label txtName;

	private ContextMenuStrip contextMenuStrip1;

	private Button button1;

	private Label lbldate;

	private DateTimePicker txtDate;

	private Label label1;

	private Button button2;

	private PrintDocument printDocument1;

	public Reporte_Usuario(string id, string nombre, string ruta, string cargo)
	{
		InitializeComponent();
		base.KeyPreview = true;
		base.KeyDown += Reporte_Usuario_KeyUp;
		Iniciar(id);
		txtName.Text = nombre;
		txttipo_e.Text = cargo;
		if (ruta == "")
		{
			image_user.Image = Resources.picture;
		}
		else
		{
			image_user.Image = Image.FromFile(ruta);
		}
		txtDate.Visible = false;
		lbldate.Visible = false;
	}

	private void Iniciar(string id)
	{
		emp.id = id;
		dgvru.DataSource = emp.GETASIS("Normal");
	}

	private void cbfilter_TextChanged(object sender, EventArgs e)
	{
		lbldate.Visible = true;
		txtDate.Visible = true;
		if (cbfilter.Text == "DIA")
		{
			lbldate.Text = "Digita el Dia a solicitar";
		}
		else if (cbfilter.Text == "MES")
		{
			lbldate.Text = "Digita el Mes a solicitar";
		}
		else if (cbfilter.Text == "AÑO")
		{
			lbldate.Text = "Digita el Año a solicitar";
		}
	}

	private void txtDate_ValueChanged(object sender, EventArgs e)
	{
	}

	private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\r')
		{
			return;
		}
		if (cbfilter.Text == "DIA")
		{
			if (txtDate.Value.Day.ToString().Length >= 2)
			{
				emp.Fecha_N = txtDate.Value.Day + "/" + Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			}
			else
			{
				emp.Fecha_N = "0" + txtDate.Value.Day + "/" + Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			}
			dgvru.DataSource = emp.GETASIS("Dia");
		}
		else if (cbfilter.Text == "MES")
		{
			emp.Fecha_N = Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			dgvru.DataSource = emp.GETASIS("Mes");
		}
		else if (cbfilter.Text == "AÑO")
		{
			emp.Fecha_N = txtDate.Value.Year.ToString();
			dgvru.DataSource = emp.GETASIS("Anio");
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Detlle_Us detlle_Us = new Detlle_Us(dgvru.CurrentRow.Cells["Fecha"].Value.ToString(), dgvru.CurrentRow.Cells["Hora_In"].Value.ToString(), dgvru.CurrentRow.Cells["Hora_fin"].Value.ToString());
		detlle_Us.Show();
	}

	private void Reporte_Usuario_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F2)
		{
			Detlle_Us detlle_Us = new Detlle_Us(dgvru.CurrentRow.Cells["Fecha"].Value.ToString(), dgvru.CurrentRow.Cells["Hora_In"].Value.ToString(), dgvru.CurrentRow.Cells["Hora_fin"].Value.ToString());
			detlle_Us.Show();
		}
		if (e.KeyCode == Keys.Control && e.KeyCode == Keys.P)
		{
			Print();
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
		Negocio negocio = new Negocio();
		DataTable dataTable = new DataTable();
		dataTable = negocio.GetNegocio();
		string s = "Calle: " + dataTable.Rows[0]["Calle"].ToString() + ", #" + dataTable.Rows[0]["Numero_Ext"].ToString() + ", Col. " + dataTable.Rows[0]["Colonia"].ToString() + "\n" + dataTable.Rows[0]["Municipio"].ToString() + ", " + dataTable.Rows[0]["Estado"].ToString() + ", C.P: " + dataTable.Rows[0]["CP"].ToString();
		Font font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Point);
		Font font2 = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point);
		Font font3 = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point);
		Font font4 = new Font("Segoe UI", 5f, FontStyle.Regular, GraphicsUnit.Point);
		Font font5 = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point);
		int num = 220;
		int num2 = 20;
		e.Graphics.DrawString(" ***" + dataTable.Rows[0]["Nombre_N"].ToString() + "*** ", font, Brushes.Black, new RectangleF(0f, num2 += 10, num, 20f));
		e.Graphics.DrawString(s, font3, Brushes.Black, new RectangleF(8f, num2 += 20, num, num2 + 20));
		e.Graphics.DrawString("Tel: " + dataTable.Rows[0]["Telefono"].ToString(), font3, Brushes.Black, new RectangleF(8f, num2 += 25, num, num2 + 15));
		e.Graphics.DrawString("Reporte de Asistencia", font3, Brushes.Black, new RectangleF(8f, num2 += 15, num, num2 + 20));
		e.Graphics.DrawString(" ************************************* ", font, Brushes.Black, new RectangleF(0f, num2 += 10, num, 20f));
		e.Graphics.DrawString("Nombre: " + txtName.Text, font3, Brushes.Black, new RectangleF(0f, num2 += 15, num, num2 + 20));
		e.Graphics.DrawString("Hora Entrada\t\tHora Salida", font2, Brushes.Black, new RectangleF(0f, num2 += 25, num, num2 + 20));
		foreach (DataGridViewRow item in (IEnumerable)dgvru.Rows)
		{
			e.Graphics.DrawString(item.Cells["Hora_In"].Value?.ToString() + "\t\t" + item.Cells["Hora_fin"].Value, font2, Brushes.Black, new RectangleF(8f, num2 += 20, num, num2 + 15));
		}
		e.Graphics.DrawString("Fecha de Solicitud: " + txtDate.Value.Day + "/" + txtDate.Value.Month + "/" + txtDate.Value.Year, font3, Brushes.Black, new RectangleF(0f, num2 += 15, num, num2 + 15));
		e.Graphics.DrawString(" ************************************* ", font, Brushes.Black, new RectangleF(0f, num2 += 10, num, 20f));
	}

	private string Selectdate(string mont)
	{
		return mont switch
		{
			"1" => "Enero", 
			"2" => "Febrero", 
			"3" => "Marzo", 
			"4" => "Abril", 
			"5" => "Mayo", 
			"6" => "Junio", 
			"7" => "Julio", 
			"8" => "Agosto", 
			"9" => "Septiembre", 
			"10" => "Octubre", 
			"11" => "Noviembre", 
			"12" => "Diciembre", 
			_ => "", 
		};
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Reporte_Usuario));
		dgvru = new System.Windows.Forms.DataGridView();
		panel1 = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
		cbfilter = new System.Windows.Forms.ComboBox();
		panel2 = new System.Windows.Forms.Panel();
		button2 = new System.Windows.Forms.Button();
		txtDate = new System.Windows.Forms.DateTimePicker();
		button1 = new System.Windows.Forms.Button();
		lbldate = new System.Windows.Forms.Label();
		panel16 = new System.Windows.Forms.Panel();
		txttipo_e = new System.Windows.Forms.Label();
		label18 = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.Label();
		contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
		image_user = new System.Windows.Forms.PictureBox();
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		((System.ComponentModel.ISupportInitialize)dgvru).BeginInit();
		panel1.SuspendLayout();
		panel2.SuspendLayout();
		panel16.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)image_user).BeginInit();
		SuspendLayout();
		dgvru.BackgroundColor = System.Drawing.SystemColors.Control;
		dgvru.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgvru.Location = new System.Drawing.Point(22, 82);
		dgvru.Name = "dgvru";
		dgvru.Size = new System.Drawing.Size(565, 485);
		dgvru.TabIndex = 0;
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(label1);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(955, 64);
		panel1.TabIndex = 2;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Impact", 27.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(355, 9);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(365, 45);
		label1.TabIndex = 0;
		label1.Text = "REPORTE DE ASISTENCIA";
		cbfilter.BackColor = System.Drawing.Color.White;
		cbfilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		cbfilter.ForeColor = System.Drawing.Color.Black;
		cbfilter.FormattingEnabled = true;
		cbfilter.Items.AddRange(new object[3] { "DIA", "MES", "AÑO" });
		cbfilter.Location = new System.Drawing.Point(38, 3);
		cbfilter.Name = "cbfilter";
		cbfilter.Size = new System.Drawing.Size(248, 33);
		cbfilter.TabIndex = 0;
		cbfilter.Text = "FILTRAR";
		cbfilter.TextChanged += new System.EventHandler(cbfilter_TextChanged);
		panel2.BackColor = System.Drawing.Color.WhiteSmoke;
		panel2.Controls.Add(button2);
		panel2.Controls.Add(txtDate);
		panel2.Controls.Add(button1);
		panel2.Controls.Add(lbldate);
		panel2.Controls.Add(cbfilter);
		panel2.Location = new System.Drawing.Point(601, 357);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(342, 210);
		panel2.TabIndex = 3;
		button2.BackColor = System.Drawing.Color.SteelBlue;
		button2.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Location = new System.Drawing.Point(179, 133);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(156, 52);
		button2.TabIndex = 5;
		button2.Text = "Detalle (F2)";
		button2.UseVisualStyleBackColor = false;
		button2.Click += new System.EventHandler(button2_Click);
		txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtDate.Location = new System.Drawing.Point(9, 81);
		txtDate.Name = "txtDate";
		txtDate.Size = new System.Drawing.Size(296, 26);
		txtDate.TabIndex = 4;
		txtDate.ValueChanged += new System.EventHandler(txtDate_ValueChanged);
		txtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDate_KeyPress);
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(3, 133);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(162, 52);
		button1.TabIndex = 3;
		button1.Text = "Imprimir (Ctr+p)";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		lbldate.AutoSize = true;
		lbldate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lbldate.Location = new System.Drawing.Point(93, 60);
		lbldate.Name = "lbldate";
		lbldate.Size = new System.Drawing.Size(45, 18);
		lbldate.TabIndex = 2;
		lbldate.Text = "Digita";
		panel16.Controls.Add(txttipo_e);
		panel16.Controls.Add(image_user);
		panel16.Controls.Add(label18);
		panel16.Controls.Add(txtName);
		panel16.Location = new System.Drawing.Point(601, 70);
		panel16.Name = "panel16";
		panel16.Size = new System.Drawing.Size(342, 281);
		panel16.TabIndex = 2;
		txttipo_e.AutoSize = true;
		txttipo_e.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttipo_e.Location = new System.Drawing.Point(124, 245);
		txttipo_e.Name = "txttipo_e";
		txttipo_e.Size = new System.Drawing.Size(65, 24);
		txttipo_e.TabIndex = 28;
		txttipo_e.Text = "Cajero";
		label18.AutoSize = true;
		label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label18.ForeColor = System.Drawing.SystemColors.AppWorkspace;
		label18.Location = new System.Drawing.Point(57, 245);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(61, 24);
		label18.TabIndex = 26;
		label18.Text = "Cargo";
		txtName.AutoSize = true;
		txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtName.Location = new System.Drawing.Point(34, 215);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(197, 24);
		txtName.TabIndex = 25;
		txtName.Text = "Jorge Lemus Stripsent";
		contextMenuStrip1.Name = "contextMenuStrip1";
		contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
		image_user.Image = (System.Drawing.Image)resources.GetObject("image_user.Image");
		image_user.Location = new System.Drawing.Point(38, 3);
		image_user.Name = "image_user";
		image_user.Size = new System.Drawing.Size(229, 209);
		image_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		image_user.TabIndex = 24;
		image_user.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(955, 579);
		base.Controls.Add(panel16);
		base.Controls.Add(panel2);
		base.Controls.Add(panel1);
		base.Controls.Add(dgvru);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Reporte_Usuario";
		Text = "Reprote de Asistencia";
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Reporte_Usuario_KeyUp);
		((System.ComponentModel.ISupportInitialize)dgvru).EndInit();
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		panel16.ResumeLayout(false);
		panel16.PerformLayout();
		((System.ComponentModel.ISupportInitialize)image_user).EndInit();
		ResumeLayout(false);
	}
}

// BLUPOINT.Reportes
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class Reportes : Form
{
	private IContainer components = null;

	private Panel panel1;

	private Label label1;

	private PictureBox pictureBox1;

	private PictureBox pictureBox2;

	private PictureBox pictureBox3;

	public Reportes()
	{
		InitializeComponent();
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
		label1 = new System.Windows.Forms.Label();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		pictureBox3 = new System.Windows.Forms.PictureBox();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.SteelBlue;
		panel1.Controls.Add(label1);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(901, 64);
		panel1.TabIndex = 0;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 26.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label1.ForeColor = System.Drawing.Color.White;
		label1.Location = new System.Drawing.Point(393, 9);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(193, 47);
		label1.TabIndex = 0;
		label1.Text = "REPORTES";
		pictureBox1.Location = new System.Drawing.Point(65, 116);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(228, 249);
		pictureBox1.TabIndex = 1;
		pictureBox1.TabStop = false;
		pictureBox2.Location = new System.Drawing.Point(336, 116);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(228, 249);
		pictureBox2.TabIndex = 2;
		pictureBox2.TabStop = false;
		pictureBox3.Location = new System.Drawing.Point(637, 116);
		pictureBox3.Name = "pictureBox3";
		pictureBox3.Size = new System.Drawing.Size(228, 249);
		pictureBox3.TabIndex = 3;
		pictureBox3.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(901, 507);
		base.Controls.Add(pictureBox3);
		base.Controls.Add(pictureBox2);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(panel1);
		base.Name = "Reportes";
		Text = "Reportes";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
		ResumeLayout(false);
	}
}

// BLUPOINT.Salidas
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Salidas : Form
{
	private string nombre;

	private string tipo;

	private string ids;

	private Caja cj = new Caja();

	private IContainer components = null;

	private Panel panel1;

	private Panel panel2;

	private Button button1;

	private Label label2;

	private TextBox txtCantidad;

	private Label label1;

	private TextBox txtConcepto;

	private Panel panel3;

	private DataGridView DGV1;

	private PictureBox pictureBox3;

	private PictureBox pictureBox2;

	private PictureBox pictureBox1;

	private Label lblfecha;

	private DateTimePicker dtm;

	private ToolTip toolTip1;

	private DateTimePicker dtm1;

	public Salidas(string nombre_e, string tipo_e, string id)
	{
		InitializeComponent();
		nombre = nombre_e;
		tipo = tipo_e;
		ids = id;
		getSalidas();
	}

	private void txtCantidad_TextChanged(object sender, EventArgs e)
	{
		if (!(txtCantidad.Text == ""))
		{
			try
			{
				double num = Convert.ToDouble(txtCantidad.Text);
			}
			catch
			{
				MessageBox.Show("Solo introduce numeros numeros");
				txtCantidad.Text = "";
			}
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		lblfecha.Visible = true;
		dtm.Visible = true;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		cj.concepto = txtConcepto.Text;
		cj.Cantidad = txtCantidad.Text;
		DateTime now = DateTime.Now;
		cj.Fecha = now.ToString("dd/MMMM/yyyy");
		if (cj.INSERTEXIT(nombre, tipo) == 1)
		{
			MessageBox.Show("La salida ha sido registrada");
			Openbox();
			Limpiar();
		}
		else
		{
			MessageBox.Show("Ha ocurrido un error por favor contecta a soporte tecnico");
		}
	}

	private void Openbox()
	{
		cj.id_caja = ids;
		cj.Nombre_U = nombre;
		cj.Hora = dtm1.Value.Hour + ":" + dtm1.Value.Minute + ":" + dtm1.Value.Second;
		DateTime now = DateTime.Now;
		cj.Fecha = now.ToString("dd/MMMM/yyyy");
		cj.Tipo_E = tipo;
		cj.tipo_consumo = "Salida";
		cj.OpenBox();
	}

	private void pictureBox3_Click(object sender, EventArgs e)
	{
		txtCantidad.Enabled = true;
		txtConcepto.Enabled = true;
		button1.Enabled = true;
	}

	private void Limpiar()
	{
		lblfecha.Visible = false;
		dtm.Visible = false;
		txtCantidad.Text = "";
		txtConcepto.Text = "";
		txtCantidad.Enabled = false;
		txtConcepto.Enabled = false;
		button1.Enabled = false;
		getSalidas();
	}

	private void dtm_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			cj.Nombre_U = nombre;
			cj.id_caja = ids;
			cj.Fecha = dtm.Value.Day + "/" + Selectdate(dtm.Value.Month.ToString()) + "/" + dtm.Value.Year;
			DGV1.DataSource = cj.GETSAL();
		}
	}

	private void DGV1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			try
			{
				Visualizar_Salidas visualizar_Salidas = new Visualizar_Salidas(DGV1.CurrentRow.Cells["Concepto"].Value.ToString(), DGV1.CurrentRow.Cells["Fecha"].Value.ToString(), DGV1.CurrentRow.Cells["Usuario"].Value.ToString(), DGV1.CurrentRow.Cells["Cantidad"].Value.ToString());
				visualizar_Salidas.ShowDialog();
			}
			catch
			{
				MessageBox.Show("No se puede elegir un campo vacio");
			}
		}
	}

	private void pictureBox2_Click(object sender, EventArgs e)
	{
		try
		{
			Visualizar_Salidas visualizar_Salidas = new Visualizar_Salidas(DGV1.CurrentRow.Cells["Concepto"].Value.ToString(), DGV1.CurrentRow.Cells["Fecha"].Value.ToString(), DGV1.CurrentRow.Cells["Usuario"].Value.ToString(), DGV1.CurrentRow.Cells["Cantidad"].Value.ToString());
			visualizar_Salidas.ShowDialog();
		}
		catch
		{
			MessageBox.Show("No se puede elegir un campo vacio");
		}
	}

	private void getSalidas()
	{
		if (tipo == "Admin")
		{
			cj.id_caja = LoadMoney();
			DateTime now = DateTime.Now;
			cj.Fecha = now.ToString("dd/MMMM/yyyy");
			DGV1.DataSource = cj.GETSAL();
			DGV1.Columns[0].Width = 100;
			DGV1.Columns[1].Width = 150;
			DGV1.Columns[2].Width = 250;
			DGV1.Columns[3].Width = 100;
			DGV1.Columns[4].Width = 100;
		}
		else
		{
			cj.id_caja = LoadMoney();
			cj.Usuario = nombre;
			DateTime now2 = DateTime.Now;
			cj.Fecha = now2.ToString("dd:MMMM:yyyy");
			DGV1.DataSource = cj.GETSALID();
			DGV1.Columns[0].Width = 100;
			DGV1.Columns[1].Width = 150;
			DGV1.Columns[2].Width = 250;
			DGV1.Columns[3].Width = 100;
			DGV1.Columns[4].Width = 100;
		}
	}

	private string LoadMoney()
	{
		string result = "";
		DataTable dataTable = new DataTable();
		try
		{
			dataTable = cj.GETMONEY();
			result = dataTable.Rows[0]["idCaja"].ToString();
			return result;
		}
		catch
		{
			return result;
		}
	}

	private string Selectdate(string mont)
	{
		return mont switch
		{
			"1" => "Enero", 
			"2" => "Febrero", 
			"3" => "Marzo", 
			"4" => "Abril", 
			"5" => "Mayo", 
			"6" => "Junio", 
			"7" => "Julio", 
			"8" => "Agosto", 
			"9" => "Septiembre", 
			"10" => "Octubre", 
			"11" => "Noviembre", 
			"12" => "Diciembre", 
			_ => "", 
		};
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
		panel1 = new System.Windows.Forms.Panel();
		dtm1 = new System.Windows.Forms.DateTimePicker();
		pictureBox3 = new System.Windows.Forms.PictureBox();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		lblfecha = new System.Windows.Forms.Label();
		dtm = new System.Windows.Forms.DateTimePicker();
		panel2 = new System.Windows.Forms.Panel();
		button1 = new System.Windows.Forms.Button();
		label2 = new System.Windows.Forms.Label();
		txtCantidad = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		txtConcepto = new System.Windows.Forms.TextBox();
		panel3 = new System.Windows.Forms.Panel();
		DGV1 = new System.Windows.Forms.DataGridView();
		toolTip1 = new System.Windows.Forms.ToolTip(components);
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel2.SuspendLayout();
		panel3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)DGV1).BeginInit();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(dtm1);
		panel1.Controls.Add(pictureBox3);
		panel1.Controls.Add(pictureBox2);
		panel1.Controls.Add(pictureBox1);
		panel1.Controls.Add(lblfecha);
		panel1.Controls.Add(dtm);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(995, 67);
		panel1.TabIndex = 0;
		dtm1.CalendarFont = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dtm1.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dtm1.Location = new System.Drawing.Point(343, 19);
		dtm1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		dtm1.Name = "dtm1";
		dtm1.Size = new System.Drawing.Size(308, 29);
		dtm1.TabIndex = 9;
		dtm1.Visible = false;
		pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox3.Image = BLUPOINT.Properties.Resources.anadir;
		pictureBox3.Location = new System.Drawing.Point(13, 8);
		pictureBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		pictureBox3.Name = "pictureBox3";
		pictureBox3.Size = new System.Drawing.Size(51, 48);
		pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox3.TabIndex = 8;
		pictureBox3.TabStop = false;
		pictureBox3.Click += new System.EventHandler(pictureBox3_Click);
		pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox2.Image = BLUPOINT.Properties.Resources.ver;
		pictureBox2.Location = new System.Drawing.Point(88, 8);
		pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(44, 48);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 7;
		pictureBox2.TabStop = false;
		toolTip1.SetToolTip(pictureBox2, "Visualizar ");
		pictureBox2.Click += new System.EventHandler(pictureBox2_Click);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox1.Image = BLUPOINT.Properties.Resources.filtrar;
		pictureBox1.Location = new System.Drawing.Point(152, 8);
		pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(51, 48);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 6;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		lblfecha.AutoSize = true;
		lblfecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblfecha.Location = new System.Drawing.Point(756, 4);
		lblfecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		lblfecha.Name = "lblfecha";
		lblfecha.Size = new System.Drawing.Size(140, 24);
		lblfecha.TabIndex = 5;
		lblfecha.Text = "Filtrar por fecha";
		lblfecha.Visible = false;
		dtm.CalendarFont = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dtm.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dtm.Location = new System.Drawing.Point(674, 31);
		dtm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		dtm.Name = "dtm";
		dtm.Size = new System.Drawing.Size(308, 29);
		dtm.TabIndex = 4;
		dtm.Visible = false;
		dtm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dtm_KeyPress);
		panel2.BackColor = System.Drawing.Color.White;
		panel2.Controls.Add(button1);
		panel2.Controls.Add(label2);
		panel2.Controls.Add(txtCantidad);
		panel2.Controls.Add(label1);
		panel2.Controls.Add(txtConcepto);
		panel2.Location = new System.Drawing.Point(658, 85);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(337, 366);
		panel2.TabIndex = 1;
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.Enabled = false;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(50, 243);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(247, 83);
		button1.TabIndex = 4;
		button1.Text = "ACEPTAR";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(28, 113);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(84, 24);
		label2.TabIndex = 3;
		label2.Text = "Cantidad";
		txtCantidad.Enabled = false;
		txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtCantidad.Location = new System.Drawing.Point(32, 140);
		txtCantidad.Name = "txtCantidad";
		txtCantidad.Size = new System.Drawing.Size(266, 35);
		txtCantidad.TabIndex = 2;
		txtCantidad.TextChanged += new System.EventHandler(txtCantidad_TextChanged);
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(28, 17);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(92, 24);
		label1.TabIndex = 1;
		label1.Text = "Concepto";
		txtConcepto.Enabled = false;
		txtConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtConcepto.Location = new System.Drawing.Point(32, 44);
		txtConcepto.Name = "txtConcepto";
		txtConcepto.Size = new System.Drawing.Size(266, 35);
		txtConcepto.TabIndex = 0;
		panel3.BackColor = System.Drawing.Color.White;
		panel3.Controls.Add(DGV1);
		panel3.Location = new System.Drawing.Point(0, 85);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(625, 366);
		panel3.TabIndex = 2;
		DGV1.BackgroundColor = System.Drawing.Color.White;
		DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV1.Location = new System.Drawing.Point(0, 3);
		DGV1.Name = "DGV1";
		DGV1.Size = new System.Drawing.Size(622, 360);
		DGV1.TabIndex = 0;
		DGV1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DGV1_KeyPress);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
		base.ClientSize = new System.Drawing.Size(995, 450);
		base.Controls.Add(panel3);
		base.Controls.Add(panel2);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Salidas";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "Salidas";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		panel3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)DGV1).EndInit();
		ResumeLayout(false);
	}
}

// BLUPOINT.Search_user
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Source;

public class Search_user : Form
{
	private Clientes cl = new Clientes();

	private IContainer components = null;

	private DataGridView dataGridView2;

	private TextBox textBox1;

	private Label label1;

	private Button button1;

	public Search_user()
	{
		InitializeComponent();
		base.KeyPreview = true;
		base.KeyDown += Search_user_KeyUp;
		textBox1.Focus();
		textBox1.Select();
	}

	private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
	{
	}

	private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			cl.Nombre = textBox1.Text;
			dataGridView2.DataSource = cl.GETBYID();
		}
	}

	private void textBox1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Down)
		{
			dataGridView2.Focus();
		}
	}

	private void Search_user_KeyPress(object sender, KeyPressEventArgs e)
	{
	}

	private void Search_user_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			Close();
		}
		if (e.KeyCode == Keys.F1)
		{
			LoadUser();
		}
	}

	private void dataGridView2_KeyUp(object sender, KeyEventArgs e)
	{
	}

	private void button1_Click(object sender, EventArgs e)
	{
		LoadUser();
	}

	private void LoadUser()
	{
		try
		{
			Venta venta = base.Owner as Venta;
			venta.txtNo_Cl.Text = dataGridView2.CurrentRow.Cells["Nombre"].Value.ToString();
			venta.txt_App.Text = dataGridView2.CurrentRow.Cells["Apellidos"].Value.ToString();
			string text = dataGridView2.CurrentRow.Cells["Mayorista"].Value.ToString();
			string text2 = dataGridView2.CurrentRow.Cells["Credito"].Value.ToString();
			if (text2 == "1")
			{
				venta.txtCred.Text = "Si";
				venta.txtCred.ForeColor = Color.Green;
			}
			else
			{
				venta.txtCred.Text = "No";
				venta.txtCred.ForeColor = Color.Red;
			}
			if (text == "1")
			{
				venta.txt_May.Text = "Si";
				venta.txt_May.ForeColor = Color.Green;
			}
			else
			{
				venta.txt_May.Text = "No";
				venta.txt_May.ForeColor = Color.Red;
			}
			Close();
		}
		catch
		{
			MessageBox.Show("No se Puede Cargar un campo vacio");
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
		dataGridView2 = new System.Windows.Forms.DataGridView();
		textBox1 = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
		SuspendLayout();
		dataGridView2.AllowUserToAddRows = false;
		dataGridView2.AllowUserToDeleteRows = false;
		dataGridView2.AllowUserToResizeColumns = false;
		dataGridView2.AllowUserToResizeRows = false;
		dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
		dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView2.GridColor = System.Drawing.SystemColors.Control;
		dataGridView2.Location = new System.Drawing.Point(4, 60);
		dataGridView2.Name = "dataGridView2";
		dataGridView2.Size = new System.Drawing.Size(934, 354);
		dataGridView2.TabIndex = 1;
		dataGridView2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(dataGridView2_KeyPress);
		dataGridView2.KeyUp += new System.Windows.Forms.KeyEventHandler(dataGridView2_KeyUp);
		textBox1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		textBox1.Location = new System.Drawing.Point(322, 19);
		textBox1.Name = "textBox1";
		textBox1.Size = new System.Drawing.Size(599, 35);
		textBox1.TabIndex = 2;
		textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox1_KeyDown);
		textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(-1, 24);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(317, 30);
		label1.TabIndex = 3;
		label1.Text = "Digita su nombre o codigo unico";
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(326, 425);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(324, 58);
		button1.TabIndex = 4;
		button1.Text = "Seleccionar Usuario (F1)";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(933, 486);
		base.Controls.Add(button1);
		base.Controls.Add(label1);
		base.Controls.Add(textBox1);
		base.Controls.Add(dataGridView2);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Search_user";
		Text = "Search_user";
		base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Search_user_KeyPress);
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Search_user_KeyUp);
		((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}

// BLUPOINT.Selected_forms
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;

public class Selected_forms : Form
{
	private string nombre;

	private string tipos;

	private string ids;

	private IContainer components = null;

	private Button button1;

	private Button button2;

	public Selected_forms(string name, string tipo, string id)
	{
		InitializeComponent();
		nombre = name;
		tipos = tipo;
		base.KeyPreview = true;
		base.KeyDown += Selected_forms_KeyUp;
		ids = id;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Entradas entradas = new Entradas(nombre);
		entradas.ShowDialog();
		Close();
	}

	private void button3_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void Selected_forms_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1)
		{
			Entradas entradas = new Entradas(nombre);
			entradas.ShowDialog();
			Close();
		}
		if (e.KeyCode == Keys.F2)
		{
			Salidas salidas = new Salidas(nombre, tipos, ids);
			salidas.ShowDialog();
			Close();
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Salidas salidas = new Salidas(nombre, tipos, ids);
		salidas.ShowDialog();
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
		button1 = new System.Windows.Forms.Button();
		button2 = new System.Windows.Forms.Button();
		SuspendLayout();
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(126, 63);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(178, 61);
		button1.TabIndex = 0;
		button1.Text = "Entradas (F1)";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		button2.BackColor = System.Drawing.Color.SteelBlue;
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Location = new System.Drawing.Point(126, 185);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(178, 52);
		button2.TabIndex = 1;
		button2.Text = "Salidas (F2)";
		button2.UseVisualStyleBackColor = false;
		button2.Click += new System.EventHandler(button2_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(401, 298);
		base.Controls.Add(button2);
		base.Controls.Add(button1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Selected_forms";
		Text = "Selected_forms";
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Selected_forms_KeyUp);
		ResumeLayout(false);
	}
}

// BLUPOINT.Star_Install
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;

public class Star_Install : Form
{
	private IContainer components = null;

	private Panel panel1;

	private Label label1;

	private PictureBox pictureBox1;

	private Label label2;

	private Button button1;

	private Button button2;

	public Star_Install()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Step_1 step_ = new Step_1();
		step_.Show();
		Hide();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Seguro que deseas Cancelar??", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			Application.Exit();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Star_Install));
		panel1 = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label2 = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		button2 = new System.Windows.Forms.Button();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.Navy;
		panel1.Controls.Add(label1);
		panel1.Location = new System.Drawing.Point(1, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(725, 63);
		panel1.TabIndex = 7;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 27.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.ForeColor = System.Drawing.Color.White;
		label1.Location = new System.Drawing.Point(154, 9);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(486, 50);
		label1.TabIndex = 0;
		label1.Text = "PROCESO DE INSTALACION ";
		pictureBox1.Image = BLUPOINT.Properties.Resources.spoint;
		pictureBox1.Location = new System.Drawing.Point(164, 81);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(444, 162);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 8;
		pictureBox1.TabStop = false;
		label2.AutoSize = true;
		label2.BackColor = System.Drawing.Color.White;
		label2.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.ForeColor = System.Drawing.Color.Black;
		label2.Location = new System.Drawing.Point(-2, 434);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(257, 17);
		label2.TabIndex = 1;
		label2.Text = "El proceso de instalacion configurara todo";
		button1.BackColor = System.Drawing.Color.Navy;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(302, 271);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(171, 43);
		button1.TabIndex = 9;
		button1.Text = "Instalar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		button2.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatAppearance.BorderSize = 0;
		button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Location = new System.Drawing.Point(302, 335);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(171, 43);
		button2.TabIndex = 10;
		button2.Text = "Cancelar";
		button2.UseVisualStyleBackColor = false;
		button2.Click += new System.EventHandler(button2_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(726, 450);
		base.Controls.Add(button2);
		base.Controls.Add(button1);
		base.Controls.Add(label2);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(panel1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Star_Install";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "BLUPOINT INSTALL";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}

// BLUPOINT.Step_1
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;

public class Step_1 : Form
{
	private IContainer components = null;

	private PictureBox pictureBox1;

	private Label label1;

	private Label label2;

	private Button button1;

	public Step_1()
	{
		InitializeComponent();
	}

	private void Step_1_FormClosing(object sender, FormClosingEventArgs e)
	{
		Application.Exit();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Licencia licencia = new Licencia();
		licencia.Show();
		Hide();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Step_1));
		label1 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(12, 327);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(193, 30);
		label1.TabIndex = 1;
		label1.Text = "AHORA MAS FACIL";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(12, 357);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(718, 34);
		label2.TabIndex = 2;
		label2.Text = resources.GetString("label2.Text");
		button1.BackColor = System.Drawing.Color.Navy;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(616, 407);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(171, 43);
		button1.TabIndex = 10;
		button1.Text = "Continuar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		pictureBox1.Image = BLUPOINT.Properties.Resources.img_1;
		pictureBox1.Location = new System.Drawing.Point(2, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(773, 313);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 0;
		pictureBox1.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(787, 450);
		base.Controls.Add(button1);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.Controls.Add(pictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Step_1";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Instalar";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Step_1_FormClosing);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}

// BLUPOINT.Step_2
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using MySql.Data.MySqlClient;

public class Step_2 : Form
{
	private string MyConString = "SERVER=localhost;DATABASE=test;UID=root;PASSWORD=blupoint01;";

	private IContainer components = null;

	private PictureBox pictureBox1;

	private Label label1;

	private Label label2;

	private Button button1;

	private ProgressBar progressBar1;

	private Timer timer1;

	public Step_2()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		CrearDB();
		CrearTablas();
	}

	private void CrearDB()
	{
		try
		{
			MySqlConnection mySqlConnection = new MySqlConnection(MyConString);
			MySqlCommand mySqlCommand = new MySqlCommand("CREATE DATABASE IF NOT EXISTS blupoint;", mySqlConnection);
			mySqlConnection.Open();
			mySqlCommand.ExecuteNonQuery();
			mySqlConnection.Close();
		}
		catch
		{
			errodbalert errodbalert2 = new errodbalert();
			errodbalert2.ShowDialog();
		}
	}

	private void CrearTablas()
	{
		MySqlConnection mySqlConnection = new MySqlConnection(MyConString);
		MySqlCommand mySqlCommand = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`abono`;CREATE TABLE  `blupoint`.`abono` (`idAbono` int(10) unsigned NOT NULL AUTO_INCREMENT,`id_credito` varchar(45) NOT NULL DEFAULT '',`Abono` varchar(45) NOT NULL DEFAULT '',`Fecha` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY(`idAbono`)) ENGINE = InnoDB AUTO_INCREMENT = 9 DEFAULT CHARSET = latin1; ", mySqlConnection);
		MySqlCommand mySqlCommand2 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`asistencia`;CREATE TABLE  `blupoint`.`asistencia` (`idAsistencia` int(10) unsigned NOT NULL AUTO_INCREMENT,`Id_Us` varchar(45) NOT NULL DEFAULT '',`Hora_In` varchar(45) NOT NULL DEFAULT '',`Turno` varchar(45) NOT NULL DEFAULT '',`Hora_fin` varchar(45) NOT NULL DEFAULT '',`Fecha` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idAsistencia`)) ENGINE=InnoDB AUTO_INCREMENT=90 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand3 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`caja`;CREATE TABLE  `blupoint`.`caja` (`idCaja` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre_Caja` varchar(45) NOT NULL DEFAULT '',`Cantidad` varchar(45) NOT NULL DEFAULT '',`Defaults` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idCaja`)) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand4 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`cliente`;CREATE TABLE  `blupoint`.`cliente` (`idCliente` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre` varchar(45) NOT NULL DEFAULT '',`Apellidos` varchar(45) NOT NULL DEFAULT '',`Fecha_Nac` varchar(45) NOT NULL DEFAULT '',`Calle` varchar(45) NOT NULL DEFAULT '',`Colonia` varchar(45) NOT NULL DEFAULT '',`No_Ex` varchar(45) NOT NULL DEFAULT '',`Clave_U` varchar(45) NOT NULL DEFAULT '',`Mayorista` varchar(45) NOT NULL DEFAULT '',`Credito` varchar(45) NOT NULL DEFAULT '',`Telefono` varchar(45) NOT NULL DEFAULT '',`Correo` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idCliente`)) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand5 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`corte_caja`;CREATE TABLE  `blupoint`.`corte_caja` (`idCorte_Caja` int(10) unsigned NOT NULL AUTO_INCREMENT,`id_Caja` varchar(45) NOT NULL DEFAULT '',`Usuario` varchar(45) NOT NULL DEFAULT '',`Contado` varchar(45) NOT NULL DEFAULT '',`Calculado` varchar(45) NOT NULL DEFAULT '',`Diferencia` varchar(45) NOT NULL DEFAULT '',`Retirado` varchar(45) NOT NULL DEFAULT '',`Fecha` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idCorte_Caja`)) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand6 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`credito`;CREATE TABLE  `blupoint`.`credito` (`idCredito` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre_U` varchar(45) NOT NULL DEFAULT '',`Total_Pago` varchar(45) NOT NULL DEFAULT '',`Fecha_Pago` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idCredito`)) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;", mySqlConnection);
		MySqlCommand mySqlCommand7 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`empleado`;CREATE TABLE  `blupoint`.`empleado` (`idEmpleado` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre` varchar(450) NOT NULL DEFAULT '',`Apellidos` varchar(450) NOT NULL DEFAULT '',`Fecha_N` varchar(450) NOT NULL DEFAULT '',`Tipo_Emp` varchar(45) NOT NULL DEFAULT '',`Pass` varchar(45) NOT NULL DEFAULT '',`Clave` varchar(45) NOT NULL DEFAULT '',`Imagen` varchar(4500) NOT NULL DEFAULT '',`Cliente` varchar(45) NOT NULL DEFAULT '',`Producto` varchar(45) NOT NULL DEFAULT '',`Usuario` varchar(45) NOT NULL DEFAULT '',`Caja` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idEmpleado`)) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand8 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`entradas`;CREATE TABLE  `blupoint`.`entradas` (`idEntradas` int(10) unsigned NOT NULL AUTO_INCREMENT,`Cantidad` varchar(45) NOT NULL DEFAULT '',`Fecha` varchar(45) NOT NULL DEFAULT '',`Nombre_E` varchar(45) NOT NULL DEFAULT '',`Tipo_E` varchar(45) NOT NULL DEFAULT '',`id_caja` varchar(45) NOT NULL DEFAULT '',`Concepto` varchar(45) NOT NULL DEFAULT '',`Tipo_Pago` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idEntradas`)) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand9 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`producto`;CREATE TABLE  `blupoint`.`producto` (`idProducto` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre_P` varchar(450) NOT NULL DEFAULT '',`Precio` varchar(45) NOT NULL DEFAULT '',`IVA` varchar(45) NOT NULL DEFAULT '',`Descuento` varchar(45) NOT NULL DEFAULT '',`Imagen` varchar(4500) NOT NULL DEFAULT '',`Codigo` varchar(450) NOT NULL DEFAULT '',`Cantidad` varchar(45) NOT NULL DEFAULT '',`Codigo_Alterno` varchar(45) NOT NULL DEFAULT '',`Fecha_reg` varchar(45) NOT NULL DEFAULT '',`Fecha_cad` varchar(45) NOT NULL DEFAULT '',`Proveedor` varchar(45) NOT NULL DEFAULT '',`Mayoreo` varchar(45) NOT NULL DEFAULT '',`Maximos` varchar(45) NOT NULL DEFAULT '',`Minimos` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idProducto`)) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand10 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`proveedor`;CREATE TABLE  `blupoint`.`proveedor` (`idProveedor` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre` varchar(45) NOT NULL DEFAULT '',`Mail` varchar(45) NOT NULL DEFAULT '',`Telefono` varchar(45) NOT NULL DEFAULT '',`Fecha` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idProveedor`)) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand11 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`salidas`;CREATE TABLE  `blupoint`.`salidas` (`idSalidas` int(10) unsigned NOT NULL AUTO_INCREMENT,`Cantidad` varchar(45) NOT NULL DEFAULT '',`Fecha` varchar(45) NOT NULL DEFAULT '',`Usuario` varchar(45) NOT NULL DEFAULT '',`Tipo_E` varchar(45) NOT NULL DEFAULT '',`id_caja` varchar(45) NOT NULL DEFAULT '',`Concepto` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idSalidas`)) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand12 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`venta`;CREATE TABLE  `blupoint`.`venta` (`idVenta` int(10) unsigned NOT NULL DEFAULT '0',`Nombre_U` varchar(45) NOT NULL DEFAULT '',`Fecha` varchar(45) NOT NULL DEFAULT '',`Nombre_C` varchar(45) NOT NULL DEFAULT '',`Apellido_C` varchar(45) NOT NULL DEFAULT '',`Total` varchar(45) NOT NULL DEFAULT '',`Subtotal` varchar(45) NOT NULL DEFAULT '',`Efectivo` varchar(45) NOT NULL DEFAULT '',`Cambio` varchar(45) NOT NULL DEFAULT '',`Descuento_Total` varchar(45) NOT NULL DEFAULT '',`Tipo_Pago` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idVenta`)) ENGINE=InnoDB DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand13 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`venta_detalle`; CREATE TABLE  `blupoint`.`venta_detalle` (`idVenta_Detalle` int(10) unsigned NOT NULL AUTO_INCREMENT,`Id_Venta` varchar(45) NOT NULL DEFAULT '',`Nombre_Prod` varchar(45) NOT NULL DEFAULT '',`Cantidad` varchar(45) NOT NULL DEFAULT '',`Precio` varchar(45) NOT NULL DEFAULT '',`Iva` varchar(45) NOT NULL DEFAULT '',`Descuento` varchar(45) NOT NULL DEFAULT '',`Codigo` varchar(45) NOT NULL DEFAULT '',`Importe` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY(`idVenta_Detalle`)) ENGINE = InnoDB AUTO_INCREMENT = 45 DEFAULT CHARSET = utf8; ", mySqlConnection);
		MySqlCommand mySqlCommand14 = new MySqlCommand("CREATE TABLE `blupoint`.`Config_Log` (`idConfig_Log` INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,`Tipo` VARCHAR(45) NOT NULL DEFAULT '',PRIMARY KEY(`idConfig_Log`))ENGINE = InnoDB;", mySqlConnection);
		MySqlCommand mySqlCommand15 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`negocio`;CREATE TABLE  `blupoint`.`negocio` (`idNegocio` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre_N` varchar(45) NOT NULL DEFAULT '',`Calle` varchar(45) NOT NULL DEFAULT '',`Colonia` varchar(45) NOT NULL DEFAULT '',`Numero_Ext` varchar(45) NOT NULL DEFAULT '',`CP` varchar(45) NOT NULL DEFAULT '',`Telefono` varchar(45) NOT NULL DEFAULT '',`Correo` varchar(45) NOT NULL DEFAULT '',`Municipio` varchar(45) NOT NULL DEFAULT '',`Estado` varchar(45) NOT NULL DEFAULT '',`Nombre_Fiscal` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idNegocio`)) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand16 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`caja_open`;CREATE TABLE  `blupoint`.`caja_open` (`idCaja_Open` int(10) unsigned NOT NULL AUTO_INCREMENT,`Id_Caja` varchar(45) NOT NULL DEFAULT '',`Tipo_Consumo` varchar(45) NOT NULL DEFAULT '',`open` varchar(45) NOT NULL DEFAULT '',`Fecha` varchar(45) NOT NULL DEFAULT '',`Nombre_Us` varchar(45) NOT NULL DEFAULT '',`Tipo_E` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idCaja_Open`)) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand17 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`oferta`;CREATE TABLE  `blupoint`.`oferta` (`idOferta` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre_Offer` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idOferta`)) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand18 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`oferta_detalle`;CREATE TABLE  `blupoint`.`oferta_detalle` (`idOferta_Detalle` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre_Ofer` varchar(45) NOT NULL DEFAULT '',`Nombre_P` varchar(45) NOT NULL DEFAULT '',`Cantidad` varchar(45) NOT NULL DEFAULT '',`Precio` varchar(45) NOT NULL DEFAULT '',`IVA` varchar(45) NOT NULL DEFAULT '',`Imagen` varchar(450) NOT NULL DEFAULT '',`Codigo` varchar(45) NOT NULL DEFAULT '',`Codigo_Alterno` varchar(45) NOT NULL DEFAULT '',`Proveedor` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idOferta_Detalle`)) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;", mySqlConnection);
		mySqlConnection.Open();
		progressBar1.Visible = true;
		progressBar1.Enabled = true;
		if (mySqlCommand.ExecuteNonQuery() == 0)
		{
			progressBar1.Value = 5;
			if (mySqlCommand2.ExecuteNonQuery() == 0)
			{
				progressBar1.Value = 10;
				if (mySqlCommand3.ExecuteNonQuery() == 0)
				{
					progressBar1.Value = 15;
					if (mySqlCommand4.ExecuteNonQuery() == 0)
					{
						progressBar1.Value = 20;
						if (mySqlCommand5.ExecuteNonQuery() == 0)
						{
							progressBar1.Value = 25;
							if (mySqlCommand6.ExecuteNonQuery() == 0)
							{
								progressBar1.Value = 30;
								if (mySqlCommand7.ExecuteNonQuery() == 0)
								{
									progressBar1.Value = 35;
									if (mySqlCommand8.ExecuteNonQuery() == 0)
									{
										progressBar1.Value = 40;
										if (mySqlCommand9.ExecuteNonQuery() == 0)
										{
											progressBar1.Value = 45;
											if (mySqlCommand10.ExecuteNonQuery() == 0)
											{
												progressBar1.Value = 50;
												if (mySqlCommand11.ExecuteNonQuery() == 0)
												{
													progressBar1.Value = 55;
													if (mySqlCommand12.ExecuteNonQuery() == 0)
													{
														progressBar1.Value = 60;
														if (mySqlCommand13.ExecuteNonQuery() == 0)
														{
															progressBar1.Value = 65;
															if (mySqlCommand14.ExecuteNonQuery() == 0)
															{
																progressBar1.Value = 70;
																if (mySqlCommand15.ExecuteNonQuery() == 0)
																{
																	progressBar1.Value = 82;
																	if (mySqlCommand16.ExecuteNonQuery() == 0)
																	{
																		progressBar1.Value = 95;
																		if (mySqlCommand17.ExecuteNonQuery() == 0)
																		{
																			progressBar1.Value = 100;
																			if (mySqlCommand18.ExecuteNonQuery() == 0 && progressBar1.Value == 100)
																			{
																				MessageBox.Show("Base de datos creada");
																				Step_3 step_ = new Step_3();
																				step_.Show();
																				Close();
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		mySqlConnection.Close();
	}

	private void tabla1()
	{
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		progressBar1.Visible = true;
		progressBar1.Enabled = true;
		if (progressBar1.Value < 100)
		{
			progressBar1.Value++;
		}
		else
		{
			timer1.Stop();
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
		components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Step_2));
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label1 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		progressBar1 = new System.Windows.Forms.ProgressBar();
		timer1 = new System.Windows.Forms.Timer(components);
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		pictureBox1.Image = BLUPOINT.Properties.Resources.verificacion;
		pictureBox1.Location = new System.Drawing.Point(290, 12);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(187, 205);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 0;
		pictureBox1.TabStop = false;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 21.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(12, 277);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(240, 40);
		label1.TabIndex = 1;
		label1.Text = "INSTALAR DATOS";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(12, 330);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(725, 42);
		label2.TabIndex = 2;
		label2.Text = "Haremos las configuraciones Principales e instalaremos la base de datos, una vez completada la accion, \r\nrealizaras el registro del usuario administrador y podras configurar tu punto de venta.";
		button1.BackColor = System.Drawing.Color.Navy;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(318, 395);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(205, 43);
		button1.TabIndex = 10;
		button1.Text = "Aceptar e Instalar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		progressBar1.Enabled = false;
		progressBar1.Location = new System.Drawing.Point(183, 233);
		progressBar1.Name = "progressBar1";
		progressBar1.Size = new System.Drawing.Size(377, 23);
		progressBar1.TabIndex = 11;
		progressBar1.Visible = false;
		timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(800, 450);
		base.Controls.Add(progressBar1);
		base.Controls.Add(button1);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.Controls.Add(pictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Step_2";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Step_2";
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}

// BLUPOINT.Step_3
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Config;
using BLUPOINT.Properties;
using MySql.Data.MySqlClient;

public class Step_3 : Form
{
	private IContainer components = null;

	private Panel panel1;

	private Panel panel3;

	private Panel panel2;

	private Label label1;

	private PictureBox pictureBox2;

	private PictureBox pictureBox1;

	private Panel panel6;

	private Label label5;

	private Panel panel5;

	private Label label4;

	private Panel panel4;

	private Label label2;

	private Label label3;

	private ToolTip toolTip1;

	public Step_3()
	{
		InitializeComponent();
	}

	private void panel2_Paint(object sender, PaintEventArgs e)
	{
	}

	private void Insertar(string tipo)
	{
		DB dB = new DB();
		dB.Conexion().Open();
		MySqlCommand mySqlCommand = new MySqlCommand();
		mySqlCommand.CommandType = CommandType.Text;
		mySqlCommand.CommandText = "INSERT INTO config_log(Tipo)VALUES(@tip)";
		mySqlCommand.Parameters.AddWithValue("tip", tipo);
		if (dB.ExeNonQuery(mySqlCommand) == 1)
		{
			Registro1 registro = new Registro1(tipo);
			registro.Show();
			Hide();
		}
	}

	private void panel3_Paint(object sender, PaintEventArgs e)
	{
	}

	private void panel2_MouseClick(object sender, MouseEventArgs e)
	{
		Insertar("1");
	}

	private void panel3_MouseClick(object sender, MouseEventArgs e)
	{
	}

	private void panel3_MouseClick_1(object sender, MouseEventArgs e)
	{
		Insertar("2");
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Step_3));
		panel1 = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
		panel3 = new System.Windows.Forms.Panel();
		panel6 = new System.Windows.Forms.Panel();
		label5 = new System.Windows.Forms.Label();
		panel5 = new System.Windows.Forms.Panel();
		label4 = new System.Windows.Forms.Label();
		panel4 = new System.Windows.Forms.Panel();
		label2 = new System.Windows.Forms.Label();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		panel2 = new System.Windows.Forms.Panel();
		label3 = new System.Windows.Forms.Label();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		toolTip1 = new System.Windows.Forms.ToolTip(components);
		panel1.SuspendLayout();
		panel3.SuspendLayout();
		panel6.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(label1);
		panel1.Controls.Add(panel3);
		panel1.Controls.Add(panel2);
		panel1.Location = new System.Drawing.Point(12, 12);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(764, 437);
		panel1.TabIndex = 0;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 20.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(215, 0);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(431, 37);
		label1.TabIndex = 2;
		label1.Text = "SELECCIONA UNA VISTA DE INICIO";
		panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel3.Controls.Add(panel6);
		panel3.Controls.Add(panel5);
		panel3.Controls.Add(label4);
		panel3.Controls.Add(panel4);
		panel3.Controls.Add(label2);
		panel3.Controls.Add(pictureBox2);
		panel3.Cursor = System.Windows.Forms.Cursors.Hand;
		panel3.Location = new System.Drawing.Point(404, 76);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(342, 332);
		panel3.TabIndex = 1;
		toolTip1.SetToolTip(panel3, "En esta vista, es mas familiarizado con los sistemas convencionales, introduces el nombre del empleado y su contraseña el sistema en automatico detectara quien es y dara acceso al panel principal.");
		panel3.Paint += new System.Windows.Forms.PaintEventHandler(panel3_Paint);
		panel3.MouseClick += new System.Windows.Forms.MouseEventHandler(panel3_MouseClick_1);
		panel6.BackColor = System.Drawing.Color.Navy;
		panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel6.Controls.Add(label5);
		panel6.Location = new System.Drawing.Point(54, 287);
		panel6.Name = "panel6";
		panel6.Size = new System.Drawing.Size(232, 30);
		panel6.TabIndex = 12;
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.ForeColor = System.Drawing.Color.White;
		label5.Location = new System.Drawing.Point(67, 5);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(96, 20);
		label5.TabIndex = 13;
		label5.Text = "Iniciar Sesion";
		panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel5.Location = new System.Drawing.Point(54, 239);
		panel5.Name = "panel5";
		panel5.Size = new System.Drawing.Size(232, 30);
		panel5.TabIndex = 11;
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(50, 216);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(83, 20);
		label4.TabIndex = 10;
		label4.Text = "Contraseña";
		panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel4.Location = new System.Drawing.Point(54, 176);
		panel4.Name = "panel4";
		panel4.Size = new System.Drawing.Size(232, 30);
		panel4.TabIndex = 9;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(50, 153);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(139, 20);
		label2.TabIndex = 8;
		label2.Text = "Nombre de Usuario";
		pictureBox2.Image = BLUPOINT.Properties.Resources.spoint;
		pictureBox2.Location = new System.Drawing.Point(40, 26);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(265, 103);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 7;
		pictureBox2.TabStop = false;
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Controls.Add(label3);
		panel2.Controls.Add(pictureBox1);
		panel2.Cursor = System.Windows.Forms.Cursors.Hand;
		panel2.Location = new System.Drawing.Point(24, 76);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(342, 332);
		panel2.TabIndex = 0;
		toolTip1.SetToolTip(panel2, "En esta vista solo se escanea el codigo de barras del usuario y da acceso al sistema con sus privilegios en automatico");
		panel2.Paint += new System.Windows.Forms.PaintEventHandler(panel2_Paint);
		panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(panel2_MouseClick);
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(43, 186);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(244, 20);
		label3.TabIndex = 7;
		label3.Text = "Escanea tu Codigo de Barras";
		pictureBox1.Image = BLUPOINT.Properties.Resources.spoint;
		pictureBox1.Location = new System.Drawing.Point(31, 26);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(265, 103);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 6;
		pictureBox1.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(779, 450);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Step_3";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Step_3";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		panel6.ResumeLayout(false);
		panel6.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}
}

// BLUPOINT.Tarjeta
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;

public class Tarjeta : Form
{
	private DataTable t = new DataTable();

	private IContainer components = null;

	private DataGridView Dgv;

	public Tarjeta()
	{
		InitializeComponent();
		load();
	}

	private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void load()
	{
		string[] array = new string[2] { "Tarjeta de Credito", "Tarjeta de Debito" };
		t.Columns.Add("Tipo de Tarjeta");
		for (int i = 0; i < 2; i++)
		{
			Agregar(array[i]);
		}
		Dgv.DataSource = t;
		Dgv.Columns[0].Width = 300;
	}

	private void Agregar(string tarjeta)
	{
		DataRow dataRow = t.NewRow();
		dataRow["Tipo de Tarjeta"] = tarjeta;
		t.Rows.Add(dataRow);
	}

	private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		Pagar pagar = base.Owner as Pagar;
		pagar.lblPay.Text = Dgv.CurrentRow.Cells["Tipo de Tarjeta"].Value.ToString();
		Close();
	}

	private void Tarjeta_Load(object sender, EventArgs e)
	{
	}

	private void Dgv_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			Pagar pagar = base.Owner as Pagar;
			pagar.lblPay.Text = Dgv.CurrentRow.Cells["Tipo de Tarjeta"].Value.ToString();
			Close();
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
		Dgv = new System.Windows.Forms.DataGridView();
		((System.ComponentModel.ISupportInitialize)Dgv).BeginInit();
		SuspendLayout();
		Dgv.AllowUserToAddRows = false;
		Dgv.AllowUserToDeleteRows = false;
		Dgv.AllowUserToResizeColumns = false;
		Dgv.BackgroundColor = System.Drawing.Color.White;
		Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		Dgv.Location = new System.Drawing.Point(0, 2);
		Dgv.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
		Dgv.Name = "Dgv";
		Dgv.Size = new System.Drawing.Size(529, 534);
		Dgv.TabIndex = 0;
		Dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(Dgv_CellClick);
		Dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellContentClick);
		Dgv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Dgv_KeyPress);
		base.AutoScaleDimensions = new System.Drawing.SizeF(14f, 29f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ControlLightLight;
		base.ClientSize = new System.Drawing.Size(315, 113);
		base.Controls.Add(Dgv);
		Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
		base.Name = "Tarjeta";
		Text = "Selecciona Tipo de Tarjeta";
		base.Load += new System.EventHandler(Tarjeta_Load);
		((System.ComponentModel.ISupportInitialize)Dgv).EndInit();
		ResumeLayout(false);
	}
}

// BLUPOINT.Venta
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Venta : Form
{
	private DataTable t;

	private string rutas;

	private string ids;

	private string cargo1;

	private string cargo2;

	private string cargo3;

	private string cargo4;

	private DataColumn c;

	private DataColumn c2;

	private DataColumn c3;

	private Ventas ven = new Ventas();

	private Caja cj = new Caja();

	private bool verificarcaja;

	public string respuesta;

	private IContainer components = null;

	private Panel panel1;

	private Panel panel2;

	private Panel panel3;

	private Panel panel7;

	private TextBox txtCod;

	private DataGridView dgvV;

	private Panel panel9;

	private Label ticket;

	private Label label10;

	private Panel panel10;

	private Button button15;

	private Panel panel8;

	private Label label7;

	private Label txtsubtotal;

	private Label label3;

	private Label label2;

	private Label label4;

	private Label Disponibilidad;

	private Label txtPrecio;

	private Label label1;

	private Label txtNombre_P;

	private PictureBox picb1;

	private Panel panel16;

	private Label label19;

	private PictureBox image_user;

	private Label label18;

	private Label txtName;

	public Label txt_May;

	public Label txtCred;

	public Label txt_App;

	public Label txtNo_Cl;

	private PrintDocument printDocument1;

	private Button button1;

	public Label label11;

	public Label label9;

	public Label label6;

	public Label label5;

	private Label label13;

	private Label txtdes;

	private Label label12;

	private DateTimePicker dtm;

	public Label txtRecipe;

	public Label txtcambio;

	public Label txttotal;

	private Label label14;

	private Label label15;

	public Label txtmetodopago;

	private Label label20;

	private Label label17;

	private Label label16;

	public Label txttipo_e;

	private Label txtmoney;

	private Label label22;

	private Label label23;

	private Label txtidbox;

	private Label label8;

	private PictureBox pictureBox5;

	private Label label21;

	private PictureBox pictureBox1;

	private Label label24;

	private PictureBox pictureBox2;

	private Label label25;

	private PictureBox pictureBox3;

	public Venta(string nombre, string ruta, string cargo, string id, string car1, string car2, string car3, string car4)
	{
		InitializeComponent();
		base.KeyPreview = true;
		base.KeyDown += Venta_KeyUp;
		Inicio();
		rutas = ruta;
		txtName.Text = nombre;
		txttipo_e.Text = cargo;
		rutas = ruta;
		if (ruta == "")
		{
			image_user.Image = Resources.picture;
		}
		else
		{
			image_user.Image = Image.FromFile(ruta);
		}
		ids = id;
		cargo1 = car1;
		cargo2 = car2;
		cargo3 = car3;
		cargo4 = car4;
		LoadMoney();
	}

	private void InsertBox()
	{
		try
		{
			if (txtmetodopago.Text == "Efectivo")
			{
				double num = Convert.ToDouble(txtRecipe.Text);
				string text = txttotal.Text;
				char c = '.';
				string[] array = text.Split(c);
				int num2 = Convert.ToInt32(array[1]);
				if (txtcambio.Text == "0" && num > Convert.ToDouble(txttotal.Text))
				{
					cj.Cantidad = num.ToString();
				}
				else if ((num2 >= 5 && num2 < 6) || (num2 >= 50 && num2 < 60))
				{
					cj.Cantidad = txttotal.Text;
				}
				else
				{
					double num3 = Math.Round(Convert.ToDouble(txttotal.Text));
					cj.Cantidad = num3.ToString();
				}
				cj.Fecha = dtm.Value.Day + "/" + dtm.Value.Month + "/" + dtm.Value.Year;
				cj.concepto = "Venta";
				cj.Tipo_Pago = txtmetodopago.Text;
				cj.id_caja = txtidbox.Text;
				cj.INSERTBOX(txtName.Text, txttipo_e.Text);
				Openbox();
				LoadMoney();
			}
			else
			{
				cj.Cantidad = txttotal.Text;
				cj.Fecha = dtm.Value.Day + "/" + dtm.Value.Month + "/" + dtm.Value.Year;
				cj.concepto = "Venta";
				cj.Tipo_Pago = txtmetodopago.Text;
				cj.id_caja = txtidbox.Text;
				cj.INSERTBOX(txtName.Text, txttipo_e.Text);
			}
		}
		catch
		{
			MessageBox.Show("Error en insercion de datos");
		}
	}

	public void LoadMoney()
	{
		DataTable dataTable = new DataTable();
		try
		{
			dataTable = cj.GETMONEY();
			txtmoney.Text = dataTable.Rows[0]["Cantidad"].ToString();
			txtidbox.Text = dataTable.Rows[0]["idCaja"].ToString();
			verificarcaja = true;
		}
		catch
		{
			verificarcaja = false;
		}
	}

	private void Inicio()
	{
		DataTable dataTable = new DataTable();
		dataTable = ven.GETID();
		string text = dataTable.Rows[0]["idVenta"].ToString();
		int num = ((!(text == "")) ? Convert.ToInt32(text) : 0);
		ticket.Text = (num + 1).ToString();
		base.KeyPreview = true;
		base.KeyDown += Venta_KeyDown;
		txtCod.Select();
		t = new DataTable();
		t.Columns.Add("Nombre");
		t.Columns.Add("Descuento", typeof(decimal));
		t.Columns.Add("Cantidad", typeof(decimal));
		t.Columns.Add("Precio", typeof(decimal));
		t.Columns.Add("IVA", typeof(decimal));
		t.Columns.Add("Codigo");
		c = t.Columns.Add("Importe", typeof(decimal));
		c2 = t.Columns.Add("Desc_Total", typeof(decimal));
		c3 = t.Columns.Add("Subtotal", typeof(decimal));
		t.Columns.Add("Codigo_Alt");
	}

	private void AdWidth()
	{
		try
		{
			dgvV.Columns[0].Width = 100;
			dgvV.Columns[1].Width = 130;
			dgvV.Columns[2].Width = 110;
			dgvV.Columns[3].Width = 100;
			dgvV.Columns[4].Width = 120;
			dgvV.Columns[5].Width = 250;
			dgvV.Columns[6].Width = 100;
			dgvV.Columns[7].Width = 100;
			dgvV.Columns[8].Width = 100;
			dgvV.Columns[9].Width = 100;
		}
		catch
		{
		}
	}

	private void label8_Click(object sender, EventArgs e)
	{
	}

	private void Total()
	{
		decimal d = default(decimal);
		foreach (DataGridViewRow item in (IEnumerable)dgvV.Rows)
		{
			d += Convert.ToDecimal(item.Cells["Importe"].Value);
		}
		d = decimal.Round(d, 1);
		txttotal.Text = Convert.ToString(d);
		TotalDesc();
		TotalSub();
	}

	private void TotalDesc()
	{
		double num = 0.0;
		foreach (DataGridViewRow item in (IEnumerable)dgvV.Rows)
		{
			num += Convert.ToDouble(item.Cells["Desc_Total"].Value);
		}
		txtdes.Text = Convert.ToString(num);
	}

	private void TotalSub()
	{
		double num = 0.0;
		foreach (DataGridViewRow item in (IEnumerable)dgvV.Rows)
		{
			num += Convert.ToDouble(item.Cells["Subtotal"].Value);
		}
		txtsubtotal.Text = Convert.ToString(num);
	}

	private void Venta_KeyDown(object sender, KeyEventArgs e)
	{
	}

	private void ObtenerProducto()
	{
		c.Expression = "([Cantidad] * [Precio])-([Descuento]*[Cantidad])+(([Precio]*[IVA])*[Cantidad])";
		c2.Expression = "([Descuento]*[Cantidad])";
		c3.Expression = "([Precio]*[Cantidad])";
		dgvV.DataSource = t;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Search_user search_user = new Search_user();
		AddOwnedForm(search_user);
		search_user.ShowDialog();
	}

	public void LoadDatatobox(string codigo)
	{
		Productos productos = new Productos();
		DataTable dataTable = new DataTable();
		productos.ofer = codigo;
		dataTable = productos.ObtenerOferta();
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			if (Checks(dataTable.Rows[i]["Codigo"].ToString()) == 1)
			{
				if (Checar(dataTable.Rows[0]["Cantidad"].ToString()) != 1)
				{
					RevisarCiclo2(dataTable.Rows[i]["Codigo"].ToString(), Convert.ToInt32(dataTable.Rows[i]["Cantidad"].ToString()));
				}
				else
				{
					Disponibilidad.Text = "No disponible";
					Disponibilidad.ForeColor = Color.Red;
					MessageBox.Show("Ya no hay mas producto en Almacen");
				}
				Total();
			}
			else if (AgregarDatos2(dataTable.Rows[i]["Codigo_Alterno"].ToString(), dataTable.Rows[i]["Codigo"].ToString()) == 0)
			{
				break;
			}
		}
	}

	private int AgregarDatos2(string alt, string codigo)
	{
		try
		{
			DataTable dataTable = new DataTable();
			Productos productos = new Productos();
			DataRow dataRow = t.NewRow();
			productos.Codigo = codigo;
			dataTable = productos.GETOBJETODETALLEOFERTA();
			int num = productos.VerificarExistenciaProductosOferta(alt);
			if (num >= Convert.ToInt32(dataTable.Rows[0]["Cantidad"].ToString()))
			{
				txtNombre_P.Text = dataTable.Rows[0]["Nombre_P"].ToString();
				txtPrecio.Text = dataTable.Rows[0]["Precio"].ToString();
				if (dataTable.Rows[0]["Imagen"].ToString() == "")
				{
					picb1.Image = Resources.picture;
				}
				else
				{
					picb1.Image = Image.FromFile(dataTable.Rows[0]["Imagen"].ToString());
				}
				label1.Text = "$";
				if (dataTable.Rows[0]["Cantidad"].ToString() != "0")
				{
					Disponibilidad.Text = "Disponible";
					Disponibilidad.ForeColor = Color.Green;
					dataRow["Nombre"] = dataTable.Rows[0]["Nombre_P"].ToString();
					dataRow["Descuento"] = "0";
					dataRow["Cantidad"] = dataTable.Rows[0]["Cantidad"].ToString();
					dataRow["Codigo_Alt"] = dataTable.Rows[0]["Codigo_Alterno"].ToString();
					dataRow["Precio"] = dataTable.Rows[0]["Precio"].ToString();
					dataRow["IVA"] = dataTable.Rows[0]["IVA"].ToString();
					dataRow["Codigo"] = dataTable.Rows[0]["Codigo"].ToString();
					ObtenerProducto();
					t.Rows.Add(dataRow);
					Total();
				}
				else
				{
					Disponibilidad.ForeColor = Color.Red;
					Disponibilidad.Text = "No Disponible";
				}
				return 1;
			}
			MessageBox.Show("No hay en Existencia algun producto de la promocion");
			Limpiar();
			return 0;
		}
		catch
		{
			MessageBox.Show("El producto no se encuentra en almacen, intenta digital el codigo alterno", "Producto no Enontrado");
			return 0;
		}
	}

	private void AgregarDatos()
	{
		try
		{
			DataTable dataTable = new DataTable();
			Productos productos = new Productos();
			DataRow dataRow = t.NewRow();
			productos.Codigo = txtCod.Text.Trim();
			dataTable = productos.GET();
			txtNombre_P.Text = dataTable.Rows[0]["Nombre_P"].ToString();
			txtPrecio.Text = dataTable.Rows[0]["Precio"].ToString();
			if (dataTable.Rows[0]["Imagen"].ToString() == "")
			{
				picb1.Image = Resources.picture;
			}
			else
			{
				picb1.Image = Image.FromFile(dataTable.Rows[0]["Imagen"].ToString());
			}
			label1.Text = "$";
			if (dataTable.Rows[0]["Cantidad"].ToString() != "0")
			{
				Disponibilidad.Text = "Disponible";
				Disponibilidad.ForeColor = Color.Green;
				dataRow["Nombre"] = dataTable.Rows[0]["Nombre_P"].ToString();
				dataRow["Descuento"] = dataTable.Rows[0]["Descuento"].ToString();
				dataRow["Cantidad"] = "1";
				dataRow["Codigo_Alt"] = dataTable.Rows[0]["Codigo_Alterno"].ToString();
				if (txt_May.Text == "" || txt_May.Text == "No")
				{
					dataRow["Precio"] = dataTable.Rows[0]["Precio"].ToString();
				}
				else if (dataTable.Rows[0]["Mayoreo"].ToString() == "0" || dataTable.Rows[0]["Mayoreo"].ToString() == "0.0")
				{
					dataRow["Precio"] = dataTable.Rows[0]["Precio"].ToString();
				}
				else
				{
					dataRow["Precio"] = dataTable.Rows[0]["Mayoreo"].ToString();
				}
				dataRow["IVA"] = dataTable.Rows[0]["IVA"].ToString();
				dataRow["Codigo"] = dataTable.Rows[0]["Codigo"].ToString();
				ObtenerProducto();
				t.Rows.Add(dataRow);
			}
			else
			{
				Disponibilidad.ForeColor = Color.Red;
				Disponibilidad.Text = "No Disponible";
			}
		}
		catch
		{
			MessageBox.Show("El producto no se encuentra en almacen, intenta digital el codigo alterno", "Producto no Enontrado");
		}
	}

	private void RevisarCiclo2(string codigo, int cantidad)
	{
		foreach (DataGridViewRow item in (IEnumerable)dgvV.Rows)
		{
			if (item.Cells[6].Value != null && (item.Cells[5].Value.ToString() == txtCod.Text || item.Cells[5].Value.ToString() == codigo))
			{
				int num = Convert.ToInt32(item.Cells[2].Value);
				num += cantidad;
				item.Cells[2].Value = num;
				txtCod.Text = "";
			}
		}
	}

	private void RevisarCiclo(string codigo)
	{
		foreach (DataGridViewRow item in (IEnumerable)dgvV.Rows)
		{
			if (item.Cells[6].Value != null && (item.Cells[5].Value.ToString() == txtCod.Text || item.Cells[5].Value.ToString() == codigo))
			{
				int num = Convert.ToInt32(item.Cells[2].Value);
				num++;
				item.Cells[2].Value = num;
				txtCod.Text = "";
			}
		}
	}

	private int Checar(string pr)
	{
		foreach (DataGridViewRow item in (IEnumerable)dgvV.Rows)
		{
			if (item.Cells[6].Value != null && item.Cells[5].Value.ToString() == txtCod.Text)
			{
				if (item.Cells[2].Value.ToString() == pr)
				{
					return 1;
				}
				return 2;
			}
		}
		return 2;
	}

	private int Checks(string codigo)
	{
		foreach (DataGridViewRow item in (IEnumerable)dgvV.Rows)
		{
			if ((item.Cells[5].Value != null || item.Cells[9].Value != null) && (item.Cells[5].Value.ToString() == txtCod.Text || item.Cells[9].Value.ToString() == txtCod.Text || item.Cells[5].Value.ToString() == codigo || item.Cells[9].Value.ToString() == codigo))
			{
				return 1;
			}
		}
		return 2;
	}

	private void txtCod_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\r')
		{
			return;
		}
		Productos productos = new Productos();
		DataTable dataTable = new DataTable();
		productos.Codigo = txtCod.Text;
		dataTable = productos.GET();
		if (dgvV.RowCount > 0)
		{
			if (Checks(txtCod.Text) == 1)
			{
				if (Checar(dataTable.Rows[0]["Cantidad"].ToString()) != 1)
				{
					RevisarCiclo(txtCod.Text);
				}
				else
				{
					Disponibilidad.Text = "No disponible";
					Disponibilidad.ForeColor = Color.Red;
					MessageBox.Show("Ya no hay mas producto en Almacen");
				}
				Total();
			}
			else if (Checks(txtCod.Text) == 2)
			{
				if (VerificarDato() == 1)
				{
					LoadDatatobox(txtCod.Text);
				}
				else
				{
					AgregarDatos();
					Total();
				}
			}
		}
		else if (VerificarDato() == 1)
		{
			LoadDatatobox(txtCod.Text);
		}
		else
		{
			AgregarDatos();
			AdWidth();
			txtCod.Text = "";
			Total();
		}
		txtCod.Text = "";
	}

	private int VerificarDato()
	{
		Productos productos = new Productos();
		DataTable dataTable = new DataTable();
		productos.Codigo = txtCod.Text;
		if (productos.ObtenerProductoOferta() == 1)
		{
			return 1;
		}
		return 0;
	}

	private void dgvV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		ObtenerProducto();
	}

	private void txtCod_Enter(object sender, EventArgs e)
	{
		txtCod.Text = "";
	}

	private void button15_Click(object sender, EventArgs e)
	{
		Pago();
	}

	private void Pago()
	{
		if (verificarcaja)
		{
			if (txttotal.Text == "0.0" || txttotal.Text == "0")
			{
				Alert_Error alert_Error = new Alert_Error("Venta sin productos no permitido");
				alert_Error.ShowDialog();
				return;
			}
			Pagar pagar = new Pagar(txtNo_Cl.Text, txtCred.Text, cargo3, txttotal.Text);
			AddOwnedForm(pagar);
			pagar.ShowDialog();
			if (!(txtmetodopago.Text == "Metodo de Pago"))
			{
				Venta1();
				alert_success alert_success2 = new alert_success("Venta Realizada con exito");
				alert_success2.ShowDialog();
				Limpiar();
			}
		}
		else if (txttipo_e.Text == "Admin" || cargo4 == "1")
		{
			alert_danger alert_danger2 = new alert_danger("No hay caja asignada", "Crear Caja ahora mismo??");
			AddOwnedForm(alert_danger2);
			alert_danger2.ShowDialog();
			if (respuesta == "Si")
			{
				Box box = new Box(txtName.Text, txttipo_e.Text, cargo4);
				AddOwnedForm(box);
				box.Show();
			}
		}
		else
		{
			Alert_Error alert_Error2 = new Alert_Error("No hay Caja Asignada, ErrCod: B0X1");
			alert_Error2.ShowDialog();
		}
	}

	private void Venta1()
	{
		try
		{
			DateTime now = DateTime.Now;
			ven.idVenta = ticket.Text;
			ven.Nombre_E = txtName.Text;
			ven.Fecha = now.ToString("dd/MMMM/yyyy");
			if (txtNo_Cl.Text == "")
			{
				ven.Nombre_C = "Publico General";
				ven.Apellido_C = "";
			}
			else
			{
				ven.Nombre_C = txtNo_Cl.Text;
				ven.Apellido_C = txt_App.Text;
			}
			ven.Tipo_Pago = txtmetodopago.Text;
			ven.SubTotal = txtsubtotal.Text;
			ven.Total = txttotal.Text;
			ven.Efectivo = txtRecipe.Text;
			ven.Cambio = txtcambio.Text;
			ven.Desc_Total = txtdes.Text;
			if (ven.POST() == 1)
			{
				Venta2();
				UpdateVent();
				InsertBox();
				alert_danger alert_danger2 = new alert_danger("Imprimir ticket", "Deseas Imprimir ticket??");
				AddOwnedForm(alert_danger2);
				alert_danger2.ShowDialog();
				if (respuesta == "Si")
				{
					Print();
				}
			}
			else
			{
				Alert_Error alert_Error = new Alert_Error("Error al realizar la venta, ErrCod: 1025");
				alert_Error.ShowDialog();
			}
		}
		catch
		{
			Alert_Error alert_Error2 = new Alert_Error("Error al realizar la venta, ErrCod: 1026");
			alert_Error2.ShowDialog();
		}
	}

	private void Venta2()
	{
		foreach (DataGridViewRow item in (IEnumerable)dgvV.Rows)
		{
			ven.idVenta = ticket.Text;
			ven.Cantidad = item.Cells["Cantidad"].Value.ToString();
			ven.Nombre_P = item.Cells["Nombre"].Value.ToString();
			ven.Precio = item.Cells["Precio"].Value.ToString();
			ven.Descuento = item.Cells["Descuento"].Value.ToString();
			ven.Codigo = item.Cells["Codigo"].Value.ToString();
			ven.Iva = item.Cells["IVA"].Value.ToString();
			ven.Importe = item.Cells["Importe"].Value.ToString();
			ven.POST2();
		}
	}

	private void UpdateVent()
	{
		foreach (DataGridViewRow item in (IEnumerable)dgvV.Rows)
		{
			ven.Cantidad = item.Cells["Cantidad"].Value.ToString();
			ven.Nombre_P = item.Cells["Nombre"].Value.ToString();
			ven.Disminium();
		}
	}

	private void Openbox()
	{
		DateTime now = DateTime.Now;
		cj.id_caja = txtidbox.Text;
		cj.Nombre_U = txtName.Text;
		cj.Hora = now.ToString("hh:mm:ss tt");
		cj.Fecha = now.ToString("dd/MMMM/yyyy");
		cj.Tipo_E = txttipo_e.Text;
		cj.tipo_consumo = "Entrada Venta";
		cj.OpenBox();
	}

	private void Print()
	{
		printDocument1 = new PrintDocument();
		PrinterSettings printerSettings = new PrinterSettings();
		printDocument1.PrinterSettings = printerSettings;
		printDocument1.PrintPage += Imprimir;
		printDocument1.Print();
	}

	private void label15_Click(object sender, EventArgs e)
	{
	}

	private void Venta_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			txtCod.Focus();
		}
		else if (e.KeyCode == Keys.F1)
		{
			EliminarProd();
		}
		else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
		{
			dgvV.Focus();
		}
		else if (e.KeyCode == Keys.F12)
		{
			alert_danger alert_danger2 = new alert_danger("Saliendo", "Deseas Salir??");
			AddOwnedForm(alert_danger2);
			alert_danger2.ShowDialog();
			if (respuesta == "Si")
			{
				Form1 form = new Form1(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
				Close();
				form.Show();
			}
		}
		else if (e.KeyCode == Keys.Escape)
		{
			alert_danger alert_danger3 = new alert_danger("Cancelar Venta", "Deseas Cancelar la venta??");
			AddOwnedForm(alert_danger3);
			alert_danger3.ShowDialog();
			if (respuesta == "Si")
			{
				Limpiar();
			}
		}
		else if (e.KeyCode == Keys.F5)
		{
			Pago();
		}
		else if (e.KeyCode == Keys.F2)
		{
			Search_user search_user = new Search_user();
			AddOwnedForm(search_user);
			search_user.ShowDialog();
		}
	}

	private void dgvV_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void pictureBox5_Click(object sender, EventArgs e)
	{
		alert_danger alert_danger2 = new alert_danger("Saliendo", "Deseas Salir??");
		AddOwnedForm(alert_danger2);
		alert_danger2.ShowDialog();
		if (respuesta == "Si")
		{
			Form1 form = new Form1(txtName.Text, rutas, txttipo_e.Text, ids, cargo1, cargo2, cargo3, cargo4);
			Close();
			form.Show();
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		if (cargo2 == "1" && txttipo_e.Text == "Admin")
		{
			Agregar_Productos_Venta agregar_Productos_Venta = new Agregar_Productos_Venta();
			agregar_Productos_Venta.Show();
		}
		else
		{
			MessageBox.Show("No tienes los permisos para acceder");
		}
	}

	private void pictureBox2_Click(object sender, EventArgs e)
	{
		if (cargo2 == "1" && txttipo_e.Text == "Admin")
		{
			Ofertas ofertas = new Ofertas();
			ofertas.ShowDialog();
		}
		else
		{
			MessageBox.Show("No tienes los permisos para acceder");
		}
	}

	private void pictureBox3_Click(object sender, EventArgs e)
	{
		EliminarProd();
	}

	private void Imprimir(object sender, PrintPageEventArgs e)
	{
		double num = 0.0;
		double num2 = 0.0;
		Negocio negocio = new Negocio();
		DataTable dataTable = new DataTable();
		dataTable = negocio.GetNegocio();
		string s = "Calle: " + dataTable.Rows[0]["Calle"].ToString() + ", #" + dataTable.Rows[0]["Numero_Ext"].ToString() + ", Col. " + dataTable.Rows[0]["Colonia"].ToString() + "\n" + dataTable.Rows[0]["Municipio"].ToString() + ", " + dataTable.Rows[0]["Estado"].ToString() + ", C.P: " + dataTable.Rows[0]["CP"].ToString();
		decimal numberAsString = Convert.ToDecimal(txttotal.Text);
		Font font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Point);
		Font font2 = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Point);
		Font font3 = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point);
		Font font4 = new Font("Segoe UI", 8f, FontStyle.Regular, GraphicsUnit.Point);
		Font font5 = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point);
		int num3 = 220;
		int num4 = 20;
		Image expendio = Resources.expendio;
		e.Graphics.DrawImage(expendio, new Rectangle(0, 0, 180, 80));
		e.Graphics.DrawString(" ***" + dataTable.Rows[0]["Nombre_N"].ToString() + "*** ", font, Brushes.Black, new RectangleF(0f, num4 += 65, num3, 20f));
		e.Graphics.DrawString(s, font3, Brushes.Black, new RectangleF(8f, num4 += 20, num3, num4 + 20));
		e.Graphics.DrawString("Tel: " + dataTable.Rows[0]["Telefono"].ToString(), font3, Brushes.Black, new RectangleF(8f, num4 += 25, num3, num4 + 15));
		e.Graphics.DrawString("Ticket de Venta", font3, Brushes.Black, new RectangleF(8f, num4 += 20, num3, num4 + 20));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num4 += 20, num3, 20f));
		e.Graphics.DrawString("Nombre \tCant.\t\tImpor.", font3, Brushes.Black, new RectangleF(0f, num4 += 20, num3, 20f));
		foreach (DataGridViewRow item in (IEnumerable)dgvV.Rows)
		{
			double num5 = Convert.ToDouble(item.Cells["Precio"].Value) * Convert.ToDouble(item.Cells["IVA"].Value);
			double num6 = num5 * Convert.ToDouble(item.Cells["Cantidad"].Value);
			num = num6;
			num2 += num;
			if (item.Cells["Nombre"].Value.ToString().Length >= 8)
			{
				e.Graphics.DrawString(item.Cells["Nombre"].Value.ToString() + "\t" + item.Cells["Cantidad"].Value.ToString() + "\t\t$" + item.Cells["Importe"].Value.ToString(), font3, Brushes.Black, new RectangleF(0f, num4 += 20, 200f, 20f));
			}
			else
			{
				e.Graphics.DrawString(item.Cells["Nombre"].Value.ToString() + "\t\t" + item.Cells["Cantidad"].Value.ToString() + "\t\t$" + item.Cells["Importe"].Value.ToString(), font3, Brushes.Black, new RectangleF(0f, num4 += 20, 200f, 20f));
			}
		}
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num4 += 20, num3, 20f));
		e.Graphics.DrawString("Subtotal:\t\t$" + txtsubtotal.Text, font4, Brushes.Black, new RectangleF(0f, num4 += 20, num3, 20f));
		e.Graphics.DrawString("Descuento:\t\t$" + txtdes.Text, font4, Brushes.Black, new RectangleF(0f, num4 += 20, num3, 20f));
		e.Graphics.DrawString("Pago con:\t\t$" + txtRecipe.Text, font4, Brushes.Black, new RectangleF(0f, num4 += 20, num3, 20f));
		e.Graphics.DrawString("Cambio:\t\t\t$" + txtcambio.Text, font4, Brushes.Black, new RectangleF(0f, num4 += 20, num3, 20f));
		if (txtmetodopago.Text == "Credito")
		{
			e.Graphics.DrawString("Por Pagar:\t\t\t$" + txttotal.Text, font3, Brushes.Black, new RectangleF(0f, num4 += 20, num3, 20f));
		}
		e.Graphics.DrawString("Total:\t\t    $" + txttotal.Text, font2, Brushes.Black, new RectangleF(0f, num4 += 20, num3, 20f));
		e.Graphics.DrawString(numberAsString.NumeroLetras(), font3, Brushes.Black, new RectangleF(0f, num4 += 20, num3, 25f));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num4 += 20, num3, 20f));
		e.Graphics.DrawString("   PAGO EN EFECTIVO\n    CON " + txtmetodopago.Text, font5, Brushes.Black, new RectangleF(0f, num4 += 20, num3, 30f));
		e.Graphics.DrawString("Atendio:\t" + txtName.Text, font3, Brushes.Black, new RectangleF(0f, num4 += 35, num3, 20f));
		DateTime now = DateTime.Now;
		e.Graphics.DrawString("Fecha: " + now.ToString("dd/MMM/yyyy") + "   Hora:" + now.ToString("hh:mm:ss tt"), font3, Brushes.Black, new RectangleF(0f, num4 += 20, num3, 20f));
		e.Graphics.DrawString("*******************************************", font, Brushes.Black, new RectangleF(0f, num4 += 20, num3, 20f));
		e.Graphics.DrawString("GRACIAS POR SU COMPRA", font5, Brushes.Black, new RectangleF(0f, num4 += 10, num3, 20f));
	}

	private void Limpiar()
	{
		try
		{
			txt_May.Text = "";
			txtcambio.Text = "0.0";
			txtCred.Text = "";
			txtNombre_P.Text = "";
			txtRecipe.Text = "0.0";
			txtdes.Text = "0.0";
			txtNombre_P.Text = "";
			txtNo_Cl.Text = "";
			txt_App.Text = "";
			txtPrecio.Text = "";
			txttotal.Text = "0.0";
			txtsubtotal.Text = "0.0";
			Disponibilidad.Text = "";
			picb1.Image = null;
			DataTable dataTable = (DataTable)dgvV.DataSource;
			dataTable.Clear();
			label1.Text = "";
			txtmetodopago.Text = "Metodo de Pago";
			Inicio();
		}
		catch
		{
		}
	}

	private void dgvV_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F6)
		{
			EliminarProd();
		}
	}

	private void RevisarDiscount(string codigo)
	{
		foreach (DataGridViewRow item in (IEnumerable)dgvV.Rows)
		{
			if (item.Cells[6].Value != null && item.Cells[5].Value.ToString() == codigo)
			{
				int num = Convert.ToInt32(item.Cells[2].Value);
				num--;
				item.Cells[2].Value = num;
				txtCod.Text = "";
			}
		}
	}

	private void EliminarProd()
	{
		try
		{
			if (dgvV.CurrentRow.Cells["Cantidad"].Value.ToString() == "1")
			{
				int index = dgvV.CurrentRow.Index;
				dgvV.Rows.RemoveAt(index);
				decimal num = default(decimal);
				decimal num2 = default(decimal);
				decimal num3 = default(decimal);
				decimal num4 = default(decimal);
				decimal num5 = default(decimal);
				foreach (DataGridViewRow item in (IEnumerable)dgvV.Rows)
				{
					num3 += Convert.ToDecimal(item.Cells["Importe"].Value);
					num4 += Convert.ToDecimal(item.Cells["Descuento"].Value);
					num5 += Convert.ToDecimal(item.Cells["Subtotal"].Value);
				}
				num2 = num5 - num4;
				num2 = decimal.Round(num2, 1);
				num = num3 - num4;
				num = decimal.Round(num, 1);
				txttotal.Text = Convert.ToString(num);
				txtdes.Text = num4.ToString();
				txtsubtotal.Text = num2.ToString();
			}
			else
			{
				RevisarDiscount(dgvV.CurrentRow.Cells["Codigo"].Value.ToString());
				ObtenerProducto();
				Total();
			}
		}
		catch
		{
			MessageBox.Show("No puedes eliminar filas vacias");
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Venta));
		panel1 = new System.Windows.Forms.Panel();
		pictureBox5 = new System.Windows.Forms.PictureBox();
		txtidbox = new System.Windows.Forms.Label();
		txtmoney = new System.Windows.Forms.Label();
		label22 = new System.Windows.Forms.Label();
		label23 = new System.Windows.Forms.Label();
		dtm = new System.Windows.Forms.DateTimePicker();
		panel16 = new System.Windows.Forms.Panel();
		txttipo_e = new System.Windows.Forms.Label();
		label19 = new System.Windows.Forms.Label();
		image_user = new System.Windows.Forms.PictureBox();
		label18 = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.Label();
		panel2 = new System.Windows.Forms.Panel();
		label11 = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		label6 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		txt_May = new System.Windows.Forms.Label();
		txtCred = new System.Windows.Forms.Label();
		txt_App = new System.Windows.Forms.Label();
		txtNo_Cl = new System.Windows.Forms.Label();
		panel3 = new System.Windows.Forms.Panel();
		Disponibilidad = new System.Windows.Forms.Label();
		label14 = new System.Windows.Forms.Label();
		txtPrecio = new System.Windows.Forms.Label();
		picb1 = new System.Windows.Forms.PictureBox();
		label1 = new System.Windows.Forms.Label();
		txtNombre_P = new System.Windows.Forms.Label();
		panel7 = new System.Windows.Forms.Panel();
		txtCod = new System.Windows.Forms.TextBox();
		dgvV = new System.Windows.Forms.DataGridView();
		panel9 = new System.Windows.Forms.Panel();
		ticket = new System.Windows.Forms.Label();
		label10 = new System.Windows.Forms.Label();
		panel10 = new System.Windows.Forms.Panel();
		label24 = new System.Windows.Forms.Label();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		label21 = new System.Windows.Forms.Label();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		button15 = new System.Windows.Forms.Button();
		panel8 = new System.Windows.Forms.Panel();
		label20 = new System.Windows.Forms.Label();
		label17 = new System.Windows.Forms.Label();
		label16 = new System.Windows.Forms.Label();
		txtmetodopago = new System.Windows.Forms.Label();
		label15 = new System.Windows.Forms.Label();
		label13 = new System.Windows.Forms.Label();
		txtdes = new System.Windows.Forms.Label();
		label12 = new System.Windows.Forms.Label();
		txttotal = new System.Windows.Forms.Label();
		label8 = new System.Windows.Forms.Label();
		label7 = new System.Windows.Forms.Label();
		txtcambio = new System.Windows.Forms.Label();
		txtRecipe = new System.Windows.Forms.Label();
		txtsubtotal = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		label25 = new System.Windows.Forms.Label();
		pictureBox3 = new System.Windows.Forms.PictureBox();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
		panel16.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)image_user).BeginInit();
		panel2.SuspendLayout();
		panel3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)picb1).BeginInit();
		panel7.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dgvV).BeginInit();
		panel9.SuspendLayout();
		panel10.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		panel8.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(pictureBox5);
		panel1.Controls.Add(txtidbox);
		panel1.Controls.Add(txtmoney);
		panel1.Controls.Add(label22);
		panel1.Controls.Add(label23);
		panel1.Controls.Add(dtm);
		panel1.Controls.Add(panel16);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(1386, 65);
		panel1.TabIndex = 0;
		pictureBox5.BackColor = System.Drawing.Color.Transparent;
		pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox5.Image = BLUPOINT.Properties.Resources.atras;
		pictureBox5.Location = new System.Drawing.Point(0, 3);
		pictureBox5.Name = "pictureBox5";
		pictureBox5.Size = new System.Drawing.Size(35, 35);
		pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox5.TabIndex = 21;
		pictureBox5.TabStop = false;
		pictureBox5.Click += new System.EventHandler(pictureBox5_Click);
		txtidbox.AutoSize = true;
		txtidbox.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtidbox.Location = new System.Drawing.Point(675, 20);
		txtidbox.Name = "txtidbox";
		txtidbox.Size = new System.Drawing.Size(36, 25);
		txtidbox.TabIndex = 9;
		txtidbox.Text = "0.0";
		txtidbox.Visible = false;
		txtmoney.AutoSize = true;
		txtmoney.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtmoney.Location = new System.Drawing.Point(204, 9);
		txtmoney.Name = "txtmoney";
		txtmoney.Size = new System.Drawing.Size(36, 25);
		txtmoney.TabIndex = 8;
		txtmoney.Text = "0.0";
		label22.AutoSize = true;
		label22.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label22.Location = new System.Drawing.Point(188, 8);
		label22.Name = "label22";
		label22.Size = new System.Drawing.Size(22, 25);
		label22.TabIndex = 7;
		label22.Text = "$";
		label23.AutoSize = true;
		label23.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label23.Location = new System.Drawing.Point(160, 33);
		label23.Name = "label23";
		label23.Size = new System.Drawing.Size(127, 21);
		label23.TabIndex = 6;
		label23.Text = "Cantidad en Caja";
		dtm.Location = new System.Drawing.Point(315, 23);
		dtm.Name = "dtm";
		dtm.Size = new System.Drawing.Size(126, 20);
		dtm.TabIndex = 3;
		dtm.Visible = false;
		panel16.Controls.Add(txttipo_e);
		panel16.Controls.Add(label19);
		panel16.Controls.Add(image_user);
		panel16.Controls.Add(label18);
		panel16.Controls.Add(txtName);
		panel16.Dock = System.Windows.Forms.DockStyle.Right;
		panel16.Location = new System.Drawing.Point(1075, 0);
		panel16.Name = "panel16";
		panel16.Size = new System.Drawing.Size(311, 65);
		panel16.TabIndex = 2;
		txttipo_e.AutoSize = true;
		txttipo_e.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttipo_e.Location = new System.Drawing.Point(171, 44);
		txttipo_e.Name = "txttipo_e";
		txttipo_e.Size = new System.Drawing.Size(52, 18);
		txttipo_e.TabIndex = 28;
		txttipo_e.Text = "Cajero";
		label19.AutoSize = true;
		label19.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
		label19.Location = new System.Drawing.Point(207, 28);
		label19.Name = "label19";
		label19.Size = new System.Drawing.Size(37, 13);
		label19.TabIndex = 27;
		label19.Text = "Activo";
		image_user.Image = (System.Drawing.Image)resources.GetObject("image_user.Image");
		image_user.Location = new System.Drawing.Point(257, 0);
		image_user.Name = "image_user";
		image_user.Size = new System.Drawing.Size(54, 62);
		image_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		image_user.TabIndex = 24;
		image_user.TabStop = false;
		label18.AutoSize = true;
		label18.ForeColor = System.Drawing.SystemColors.AppWorkspace;
		label18.Location = new System.Drawing.Point(171, 28);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(37, 13);
		label18.TabIndex = 26;
		label18.Text = "Status";
		txtName.AutoSize = true;
		txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtName.Location = new System.Drawing.Point(3, 0);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(197, 24);
		txtName.TabIndex = 25;
		txtName.Text = "Jorge Lemus Stripsent";
		panel2.BackColor = System.Drawing.Color.White;
		panel2.Controls.Add(label11);
		panel2.Controls.Add(label9);
		panel2.Controls.Add(label6);
		panel2.Controls.Add(label5);
		panel2.Controls.Add(button1);
		panel2.Controls.Add(txt_May);
		panel2.Controls.Add(txtCred);
		panel2.Controls.Add(txt_App);
		panel2.Controls.Add(txtNo_Cl);
		panel2.Location = new System.Drawing.Point(12, 82);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(228, 426);
		panel2.TabIndex = 1;
		label11.AutoSize = true;
		label11.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label11.ForeColor = System.Drawing.SystemColors.ControlDark;
		label11.Location = new System.Drawing.Point(20, 271);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(124, 25);
		label11.TabIndex = 14;
		label11.Text = "Precio Mayor";
		label9.AutoSize = true;
		label9.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label9.ForeColor = System.Drawing.SystemColors.ControlDark;
		label9.Location = new System.Drawing.Point(22, 195);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(74, 25);
		label9.TabIndex = 13;
		label9.Text = "Credito";
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label6.ForeColor = System.Drawing.SystemColors.ControlDark;
		label6.Location = new System.Drawing.Point(20, 116);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(102, 25);
		label6.TabIndex = 12;
		label6.Text = "Apellido(s)";
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.ForeColor = System.Drawing.SystemColors.ControlDark;
		label5.Location = new System.Drawing.Point(20, 38);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(101, 25);
		label5.TabIndex = 11;
		label5.Text = "Nombre(s)";
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(11, 346);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(204, 67);
		button1.TabIndex = 2;
		button1.Text = "Seleccionar Cliente (F2)";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		txt_May.AutoSize = true;
		txt_May.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txt_May.Location = new System.Drawing.Point(24, 302);
		txt_May.Name = "txt_May";
		txt_May.Size = new System.Drawing.Size(0, 25);
		txt_May.TabIndex = 10;
		txtCred.AutoSize = true;
		txtCred.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtCred.Location = new System.Drawing.Point(24, 230);
		txtCred.Name = "txtCred";
		txtCred.Size = new System.Drawing.Size(0, 25);
		txtCred.TabIndex = 9;
		txt_App.AutoSize = true;
		txt_App.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txt_App.Location = new System.Drawing.Point(24, 153);
		txt_App.Name = "txt_App";
		txt_App.Size = new System.Drawing.Size(0, 25);
		txt_App.TabIndex = 8;
		txtNo_Cl.AutoSize = true;
		txtNo_Cl.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtNo_Cl.Location = new System.Drawing.Point(24, 72);
		txtNo_Cl.Name = "txtNo_Cl";
		txtNo_Cl.Size = new System.Drawing.Size(0, 25);
		txtNo_Cl.TabIndex = 3;
		panel3.BackColor = System.Drawing.Color.White;
		panel3.Controls.Add(Disponibilidad);
		panel3.Controls.Add(label14);
		panel3.Controls.Add(txtPrecio);
		panel3.Controls.Add(picb1);
		panel3.Controls.Add(label1);
		panel3.Controls.Add(txtNombre_P);
		panel3.Location = new System.Drawing.Point(12, 514);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(228, 237);
		panel3.TabIndex = 2;
		Disponibilidad.AutoSize = true;
		Disponibilidad.Font = new System.Drawing.Font("Segoe UI Historic", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Disponibilidad.ForeColor = System.Drawing.Color.Green;
		Disponibilidad.Location = new System.Drawing.Point(65, 194);
		Disponibilidad.Name = "Disponibilidad";
		Disponibilidad.Size = new System.Drawing.Size(0, 30);
		Disponibilidad.TabIndex = 4;
		label14.AutoSize = true;
		label14.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label14.ForeColor = System.Drawing.SystemColors.ControlDark;
		label14.Location = new System.Drawing.Point(18, 201);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(52, 21);
		label14.TabIndex = 4;
		label14.Text = "Status";
		txtPrecio.AutoSize = true;
		txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtPrecio.ForeColor = System.Drawing.Color.Green;
		txtPrecio.Location = new System.Drawing.Point(79, 157);
		txtPrecio.Name = "txtPrecio";
		txtPrecio.Size = new System.Drawing.Size(58, 33);
		txtPrecio.TabIndex = 3;
		txtPrecio.Text = "0.0";
		picb1.Location = new System.Drawing.Point(50, 3);
		picb1.Name = "picb1";
		picb1.Size = new System.Drawing.Size(135, 116);
		picb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		picb1.TabIndex = 0;
		picb1.TabStop = false;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label1.ForeColor = System.Drawing.Color.Green;
		label1.Location = new System.Drawing.Point(55, 156);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(32, 33);
		label1.TabIndex = 2;
		label1.Text = "$";
		txtNombre_P.AutoSize = true;
		txtNombre_P.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtNombre_P.Location = new System.Drawing.Point(17, 122);
		txtNombre_P.Name = "txtNombre_P";
		txtNombre_P.Size = new System.Drawing.Size(208, 30);
		txtNombre_P.TabIndex = 1;
		txtNombre_P.Text = "Nombre de Producto";
		panel7.BackColor = System.Drawing.Color.White;
		panel7.Controls.Add(txtCod);
		panel7.Controls.Add(dgvV);
		panel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		panel7.Location = new System.Drawing.Point(246, 82);
		panel7.Name = "panel7";
		panel7.Size = new System.Drawing.Size(942, 426);
		panel7.TabIndex = 6;
		txtCod.Location = new System.Drawing.Point(144, 32);
		txtCod.Name = "txtCod";
		txtCod.Size = new System.Drawing.Size(388, 31);
		txtCod.TabIndex = 1;
		txtCod.Text = "Ingresa El codigo";
		txtCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		txtCod.Enter += new System.EventHandler(txtCod_Enter);
		txtCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCod_KeyPress);
		dgvV.AllowUserToAddRows = false;
		dgvV.AllowUserToDeleteRows = false;
		dgvV.AllowUserToOrderColumns = true;
		dgvV.BackgroundColor = System.Drawing.Color.White;
		dgvV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgvV.Location = new System.Drawing.Point(0, 72);
		dgvV.Name = "dgvV";
		dgvV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
		dgvV.Size = new System.Drawing.Size(942, 351);
		dgvV.TabIndex = 0;
		dgvV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgvV_CellContentClick);
		dgvV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(dgvV_CellValueChanged);
		dgvV.KeyUp += new System.Windows.Forms.KeyEventHandler(dgvV_KeyUp);
		panel9.BackColor = System.Drawing.Color.White;
		panel9.Controls.Add(ticket);
		panel9.Controls.Add(label10);
		panel9.Location = new System.Drawing.Point(1191, 82);
		panel9.Name = "panel9";
		panel9.Size = new System.Drawing.Size(183, 177);
		panel9.TabIndex = 8;
		ticket.AutoSize = true;
		ticket.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		ticket.Location = new System.Drawing.Point(33, 89);
		ticket.Name = "ticket";
		ticket.Size = new System.Drawing.Size(25, 25);
		ticket.TabIndex = 1;
		ticket.Text = "0";
		label10.AutoSize = true;
		label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label10.Location = new System.Drawing.Point(33, 33);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(119, 25);
		label10.TabIndex = 0;
		label10.Text = "No. Ticket";
		panel10.BackColor = System.Drawing.Color.White;
		panel10.Controls.Add(label25);
		panel10.Controls.Add(pictureBox3);
		panel10.Controls.Add(label24);
		panel10.Controls.Add(pictureBox2);
		panel10.Controls.Add(label21);
		panel10.Controls.Add(pictureBox1);
		panel10.Controls.Add(button15);
		panel10.Location = new System.Drawing.Point(1191, 265);
		panel10.Name = "panel10";
		panel10.Size = new System.Drawing.Size(183, 468);
		panel10.TabIndex = 9;
		label24.AutoSize = true;
		label24.Location = new System.Drawing.Point(45, 217);
		label24.Name = "label24";
		label24.Size = new System.Drawing.Size(97, 13);
		label24.TabIndex = 5;
		label24.Text = "Agregar Promocion";
		pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox2.Image = BLUPOINT.Properties.Resources.promociones;
		pictureBox2.Location = new System.Drawing.Point(58, 141);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(72, 70);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 4;
		pictureBox2.TabStop = false;
		pictureBox2.Click += new System.EventHandler(pictureBox2_Click);
		label21.AutoSize = true;
		label21.Location = new System.Drawing.Point(35, 100);
		label21.Name = "label21";
		label21.Size = new System.Drawing.Size(128, 13);
		label21.TabIndex = 3;
		label21.Text = "Agregar Poducto Faltante";
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox1.Image = BLUPOINT.Properties.Resources.caja;
		pictureBox1.Location = new System.Drawing.Point(59, 22);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(69, 67);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 2;
		pictureBox1.TabStop = false;
		pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		button15.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
		button15.FlatAppearance.BorderSize = 0;
		button15.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
		button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		button15.ForeColor = System.Drawing.Color.White;
		button15.Location = new System.Drawing.Point(3, 379);
		button15.Name = "button15";
		button15.Size = new System.Drawing.Size(177, 81);
		button15.TabIndex = 1;
		button15.Text = "Pagar (F5)";
		button15.UseVisualStyleBackColor = false;
		button15.Click += new System.EventHandler(button15_Click);
		panel8.BackColor = System.Drawing.Color.White;
		panel8.Controls.Add(label20);
		panel8.Controls.Add(label17);
		panel8.Controls.Add(label16);
		panel8.Controls.Add(txtmetodopago);
		panel8.Controls.Add(label15);
		panel8.Controls.Add(label13);
		panel8.Controls.Add(txtdes);
		panel8.Controls.Add(label12);
		panel8.Controls.Add(txttotal);
		panel8.Controls.Add(label8);
		panel8.Controls.Add(label7);
		panel8.Controls.Add(txtcambio);
		panel8.Controls.Add(txtRecipe);
		panel8.Controls.Add(txtsubtotal);
		panel8.Controls.Add(label3);
		panel8.Controls.Add(label2);
		panel8.Controls.Add(label4);
		panel8.Location = new System.Drawing.Point(246, 514);
		panel8.Name = "panel8";
		panel8.Size = new System.Drawing.Size(942, 219);
		panel8.TabIndex = 10;
		label20.AutoSize = true;
		label20.BackColor = System.Drawing.Color.White;
		label20.Font = new System.Drawing.Font("Segoe UI", 21.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label20.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
		label20.Location = new System.Drawing.Point(193, 149);
		label20.Name = "label20";
		label20.Size = new System.Drawing.Size(33, 40);
		label20.TabIndex = 18;
		label20.Text = "$";
		label17.AutoSize = true;
		label17.Font = new System.Drawing.Font("Segoe UI", 21.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label17.Location = new System.Drawing.Point(192, 79);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(33, 40);
		label17.TabIndex = 17;
		label17.Text = "$";
		label16.AutoSize = true;
		label16.Font = new System.Drawing.Font("Segoe UI", 21.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label16.Location = new System.Drawing.Point(193, 9);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(33, 40);
		label16.TabIndex = 16;
		label16.Text = "$";
		txtmetodopago.AutoSize = true;
		txtmetodopago.Font = new System.Drawing.Font("Segoe UI", 21.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtmetodopago.Location = new System.Drawing.Point(351, 54);
		txtmetodopago.Name = "txtmetodopago";
		txtmetodopago.Size = new System.Drawing.Size(245, 40);
		txtmetodopago.TabIndex = 15;
		txtmetodopago.Text = "Metodo de Pago";
		label15.AutoSize = true;
		label15.Font = new System.Drawing.Font("Segoe UI", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label15.Location = new System.Drawing.Point(363, 9);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(208, 45);
		label15.TabIndex = 14;
		label15.Text = "Tipo de Pago";
		label15.Click += new System.EventHandler(label15_Click);
		label13.AutoSize = true;
		label13.Font = new System.Drawing.Font("Segoe UI", 36f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label13.Location = new System.Drawing.Point(371, 154);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(56, 65);
		label13.TabIndex = 13;
		label13.Text = "$";
		txtdes.AutoSize = true;
		txtdes.BackColor = System.Drawing.Color.White;
		txtdes.Font = new System.Drawing.Font("Segoe UI", 21.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtdes.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
		txtdes.Location = new System.Drawing.Point(219, 152);
		txtdes.Name = "txtdes";
		txtdes.Size = new System.Drawing.Size(55, 40);
		txtdes.TabIndex = 12;
		txtdes.Text = "0.0";
		label12.AutoSize = true;
		label12.Font = new System.Drawing.Font("Segoe UI", 21.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label12.Location = new System.Drawing.Point(3, 150);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(151, 40);
		label12.TabIndex = 11;
		label12.Text = "Descuento";
		txttotal.AutoSize = true;
		txttotal.Font = new System.Drawing.Font("Segoe UI", 50f, System.Drawing.FontStyle.Bold);
		txttotal.Location = new System.Drawing.Point(652, 110);
		txttotal.Name = "txttotal";
		txttotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		txttotal.Size = new System.Drawing.Size(134, 89);
		txttotal.TabIndex = 8;
		txttotal.Text = "0.0";
		label8.AutoSize = true;
		label8.Font = new System.Drawing.Font("Segoe UI", 50f, System.Drawing.FontStyle.Bold);
		label8.Location = new System.Drawing.Point(592, 112);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(77, 89);
		label8.TabIndex = 7;
		label8.Text = "$";
		label7.AutoSize = true;
		label7.Font = new System.Drawing.Font("Segoe UI", 48f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label7.Location = new System.Drawing.Point(675, 24);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(231, 86);
		label7.TabIndex = 6;
		label7.Text = "TOTAL";
		txtcambio.AutoSize = true;
		txtcambio.BackColor = System.Drawing.Color.White;
		txtcambio.Font = new System.Drawing.Font("Segoe UI", 36f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txtcambio.ForeColor = System.Drawing.Color.Black;
		txtcambio.Location = new System.Drawing.Point(442, 154);
		txtcambio.Name = "txtcambio";
		txtcambio.Size = new System.Drawing.Size(97, 65);
		txtcambio.TabIndex = 5;
		txtcambio.Text = "0.0";
		txtRecipe.AutoSize = true;
		txtRecipe.Font = new System.Drawing.Font("Segoe UI", 21.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtRecipe.Location = new System.Drawing.Point(219, 79);
		txtRecipe.Name = "txtRecipe";
		txtRecipe.Size = new System.Drawing.Size(55, 40);
		txtRecipe.TabIndex = 4;
		txtRecipe.Text = "0.0";
		txtsubtotal.AutoSize = true;
		txtsubtotal.Font = new System.Drawing.Font("Segoe UI", 21.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtsubtotal.Location = new System.Drawing.Point(219, 9);
		txtsubtotal.Name = "txtsubtotal";
		txtsubtotal.Size = new System.Drawing.Size(55, 40);
		txtsubtotal.TabIndex = 3;
		txtsubtotal.Text = "0.0";
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 21.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(399, 122);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(116, 40);
		label3.TabIndex = 2;
		label3.Text = "Cambio";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 21.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(3, 75);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(195, 40);
		label2.TabIndex = 1;
		label2.Text = "Total Recibido";
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 21.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(3, 9);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(124, 40);
		label4.TabIndex = 0;
		label4.Text = "Subtotal";
		label25.AutoSize = true;
		label25.Location = new System.Drawing.Point(48, 334);
		label25.Name = "label25";
		label25.Size = new System.Drawing.Size(89, 13);
		label25.TabIndex = 7;
		label25.Text = "Eliminar Producto";
		pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
		pictureBox3.Image = (System.Drawing.Image)resources.GetObject("pictureBox3.Image");
		pictureBox3.Location = new System.Drawing.Point(59, 258);
		pictureBox3.Name = "pictureBox3";
		pictureBox3.Size = new System.Drawing.Size(72, 70);
		pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox3.TabIndex = 6;
		pictureBox3.TabStop = false;
		pictureBox3.Click += new System.EventHandler(pictureBox3_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.SystemColors.ControlDark;
		base.ClientSize = new System.Drawing.Size(1386, 745);
		base.Controls.Add(panel8);
		base.Controls.Add(panel10);
		base.Controls.Add(panel9);
		base.Controls.Add(panel7);
		base.Controls.Add(panel3);
		base.Controls.Add(panel2);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Venta";
		Text = "Venta";
		base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Venta_KeyUp);
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
		panel16.ResumeLayout(false);
		panel16.PerformLayout();
		((System.ComponentModel.ISupportInitialize)image_user).EndInit();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)picb1).EndInit();
		panel7.ResumeLayout(false);
		panel7.PerformLayout();
		((System.ComponentModel.ISupportInitialize)dgvV).EndInit();
		panel9.ResumeLayout(false);
		panel9.PerformLayout();
		panel10.ResumeLayout(false);
		panel10.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		panel8.ResumeLayout(false);
		panel8.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
		ResumeLayout(false);
	}
}

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

// BLUPOINT.Ver_productos
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT.Source;

public class Ver_productos : Form
{
	private Productos prod = new Productos();

	private IContainer components = null;

	private DataGridView dgvprod;

	private Button button1;

	public Ver_productos()
	{
		InitializeComponent();
		dgvprod.DataSource = prod.ProdFaltantes();
	}

	private void button1_Click(object sender, EventArgs e)
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
		dgvprod = new System.Windows.Forms.DataGridView();
		button1 = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)dgvprod).BeginInit();
		SuspendLayout();
		dgvprod.BackgroundColor = System.Drawing.Color.White;
		dgvprod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgvprod.GridColor = System.Drawing.Color.White;
		dgvprod.Location = new System.Drawing.Point(1, 2);
		dgvprod.Name = "dgvprod";
		dgvprod.Size = new System.Drawing.Size(694, 315);
		dgvprod.TabIndex = 0;
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(216, 323);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(194, 46);
		button1.TabIndex = 1;
		button1.Text = "Aceptar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(696, 366);
		base.Controls.Add(button1);
		base.Controls.Add(dgvprod);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Ver_productos";
		Text = "Ver_productos";
		((System.ComponentModel.ISupportInitialize)dgvprod).EndInit();
		ResumeLayout(false);
	}
}

// BLUPOINT.Visualizar_entrada
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class Visualizar_entrada : Form
{
	private IContainer components = null;

	private TextBox txtconcepto;

	private Label label1;

	private Label label2;

	private TextBox txttipo_p;

	private Label label3;

	private Label label4;

	private Label txttotal;

	private Button button1;

	private Label label6;

	private Label txtfecha;

	private Label label8;

	private Label txtname;

	public Visualizar_entrada(string concepto, string tipo_p, string fecha, string nombre, string total)
	{
		InitializeComponent();
		txtconcepto.Text = concepto;
		txtfecha.Text = fecha;
		txtname.Text = nombre;
		txttipo_p.Text = tipo_p;
		txttotal.Text = total;
	}

	private void button1_Click(object sender, EventArgs e)
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
		txtconcepto = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		txttipo_p = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		txttotal = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		label6 = new System.Windows.Forms.Label();
		txtfecha = new System.Windows.Forms.Label();
		label8 = new System.Windows.Forms.Label();
		txtname = new System.Windows.Forms.Label();
		SuspendLayout();
		txtconcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtconcepto.Location = new System.Drawing.Point(58, 75);
		txtconcepto.Name = "txtconcepto";
		txtconcepto.Size = new System.Drawing.Size(355, 31);
		txtconcepto.TabIndex = 0;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(53, 42);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(102, 30);
		label1.TabIndex = 1;
		label1.Text = "Concepto";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(53, 147);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(134, 30);
		label2.TabIndex = 3;
		label2.Text = "Tipo de Pago";
		txttipo_p.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttipo_p.Location = new System.Drawing.Point(58, 180);
		txttipo_p.Name = "txttipo_p";
		txttipo_p.Size = new System.Drawing.Size(355, 31);
		txttipo_p.TabIndex = 2;
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(187, 377);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(57, 30);
		label3.TabIndex = 4;
		label3.Text = "Total";
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(152, 407);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(43, 50);
		label4.TabIndex = 5;
		label4.Text = "$";
		txttotal.AutoSize = true;
		txttotal.Font = new System.Drawing.Font("Segoe UI", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txttotal.Location = new System.Drawing.Point(193, 407);
		txttotal.Name = "txttotal";
		txttotal.Size = new System.Drawing.Size(74, 50);
		txttotal.TabIndex = 6;
		txttotal.Text = "0.0";
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(128, 474);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(162, 56);
		button1.TabIndex = 7;
		button1.Text = "Aceptar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label6.Location = new System.Drawing.Point(53, 251);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(73, 30);
		label6.TabIndex = 8;
		label6.Text = "Fecha ";
		txtfecha.AutoSize = true;
		txtfecha.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtfecha.Location = new System.Drawing.Point(53, 292);
		txtfecha.Name = "txtfecha";
		txtfecha.Size = new System.Drawing.Size(106, 30);
		txtfecha.TabIndex = 9;
		txtfecha.Text = "12/1/2021";
		label8.AutoSize = true;
		label8.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label8.Location = new System.Drawing.Point(214, 251);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(216, 30);
		label8.TabIndex = 10;
		label8.Text = "Nombre de empleado";
		txtname.AutoSize = true;
		txtname.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtname.Location = new System.Drawing.Point(215, 292);
		txtname.Name = "txtname";
		txtname.Size = new System.Drawing.Size(200, 21);
		txtname.TabIndex = 11;
		txtname.Text = "Alan Jesus Guzman Aguirre";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(442, 542);
		base.Controls.Add(txtname);
		base.Controls.Add(label8);
		base.Controls.Add(txtfecha);
		base.Controls.Add(label6);
		base.Controls.Add(button1);
		base.Controls.Add(txttotal);
		base.Controls.Add(label4);
		base.Controls.Add(label3);
		base.Controls.Add(label2);
		base.Controls.Add(txttipo_p);
		base.Controls.Add(label1);
		base.Controls.Add(txtconcepto);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Visualizar_entrada";
		Text = "Visualizar Entrada";
		ResumeLayout(false);
		PerformLayout();
	}
}

// BLUPOINT.Visualizar_Ofertas
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Source;

public class Visualizar_Ofertas : Form
{
	private Productos prod = new Productos();

	private IContainer components = null;

	private DataGridView DGV;

	private TextBox textBox1;

	private Button button1;

	private Label label1;

	public Visualizar_Ofertas(string nombre)
	{
		InitializeComponent();
		prod.Codigo = nombre;
		DGV.DataSource = prod.CargarOfertas2();
		DGV.Columns[0].Width = 250;
	}

	private void button1_Click(object sender, EventArgs e)
	{
	}

	private void button1_Click_1(object sender, EventArgs e)
	{
		Venta venta = base.Owner as Venta;
		venta.LoadDatatobox(DGV.CurrentRow.Cells["OFERTAS"].Value.ToString());
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
		DGV = new System.Windows.Forms.DataGridView();
		textBox1 = new System.Windows.Forms.TextBox();
		button1 = new System.Windows.Forms.Button();
		label1 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)DGV).BeginInit();
		SuspendLayout();
		DGV.AllowUserToAddRows = false;
		DGV.AllowUserToDeleteRows = false;
		DGV.BackgroundColor = System.Drawing.Color.White;
		DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV.Location = new System.Drawing.Point(23, 15);
		DGV.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
		DGV.Name = "DGV";
		DGV.Size = new System.Drawing.Size(359, 398);
		DGV.TabIndex = 0;
		textBox1.Location = new System.Drawing.Point(416, 144);
		textBox1.Name = "textBox1";
		textBox1.Size = new System.Drawing.Size(259, 31);
		textBox1.TabIndex = 2;
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(447, 215);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(205, 54);
		button1.TabIndex = 3;
		button1.Text = "Aceptar (F3)";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click_1);
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(411, 116);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(282, 25);
		label1.TabIndex = 4;
		label1.Text = "Cantidad de Promociones";
		base.AutoScaleDimensions = new System.Drawing.SizeF(13f, 25f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(699, 467);
		base.Controls.Add(label1);
		base.Controls.Add(button1);
		base.Controls.Add(textBox1);
		base.Controls.Add(DGV);
		Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		base.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
		base.Name = "Visualizar_Ofertas";
		Text = "Visualizar_Ofertas";
		((System.ComponentModel.ISupportInitialize)DGV).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}

// BLUPOINT.Visualizar_Salidas
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class Visualizar_Salidas : Form
{
	private IContainer components = null;

	private Label txtname;

	private Label label8;

	private Label txtfecha;

	private Label label6;

	private Label txttotal;

	private Label label4;

	private Label label3;

	private Label label1;

	private TextBox txtconcepto;

	private Button button1;

	public Visualizar_Salidas(string concepto, string fecha, string nombre, string total)
	{
		InitializeComponent();
		txtconcepto.Text = concepto;
		txtfecha.Text = fecha;
		txtname.Text = nombre;
		txttotal.Text = total;
	}

	private void button1_Click(object sender, EventArgs e)
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
		txtname = new System.Windows.Forms.Label();
		label8 = new System.Windows.Forms.Label();
		txtfecha = new System.Windows.Forms.Label();
		label6 = new System.Windows.Forms.Label();
		txttotal = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		txtconcepto = new System.Windows.Forms.TextBox();
		button1 = new System.Windows.Forms.Button();
		SuspendLayout();
		txtname.AutoSize = true;
		txtname.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtname.Location = new System.Drawing.Point(198, 193);
		txtname.Name = "txtname";
		txtname.Size = new System.Drawing.Size(200, 21);
		txtname.TabIndex = 22;
		txtname.Text = "Alan Jesus Guzman Aguirre";
		label8.AutoSize = true;
		label8.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label8.Location = new System.Drawing.Point(197, 152);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(216, 30);
		label8.TabIndex = 21;
		label8.Text = "Nombre de empleado";
		txtfecha.AutoSize = true;
		txtfecha.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtfecha.Location = new System.Drawing.Point(36, 193);
		txtfecha.Name = "txtfecha";
		txtfecha.Size = new System.Drawing.Size(106, 30);
		txtfecha.TabIndex = 20;
		txtfecha.Text = "12/1/2021";
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label6.Location = new System.Drawing.Point(36, 152);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(73, 30);
		label6.TabIndex = 19;
		label6.Text = "Fecha ";
		txttotal.AutoSize = true;
		txttotal.Font = new System.Drawing.Font("Segoe UI", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txttotal.Location = new System.Drawing.Point(176, 308);
		txttotal.Name = "txttotal";
		txttotal.Size = new System.Drawing.Size(74, 50);
		txttotal.TabIndex = 18;
		txttotal.Text = "0.0";
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(135, 308);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(43, 50);
		label4.TabIndex = 17;
		label4.Text = "$";
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(170, 278);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(57, 30);
		label3.TabIndex = 16;
		label3.Text = "Total";
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(38, 41);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(102, 30);
		label1.TabIndex = 13;
		label1.Text = "Concepto";
		txtconcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtconcepto.Location = new System.Drawing.Point(43, 74);
		txtconcepto.Name = "txtconcepto";
		txtconcepto.Size = new System.Drawing.Size(355, 31);
		txtconcepto.TabIndex = 12;
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(122, 382);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(162, 56);
		button1.TabIndex = 23;
		button1.Text = "Aceptar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(442, 450);
		base.Controls.Add(button1);
		base.Controls.Add(txtname);
		base.Controls.Add(label8);
		base.Controls.Add(txtfecha);
		base.Controls.Add(label6);
		base.Controls.Add(txttotal);
		base.Controls.Add(label4);
		base.Controls.Add(label3);
		base.Controls.Add(label1);
		base.Controls.Add(txtconcepto);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Visualizar_Salidas";
		Text = "Visualizar_Salidas";
		ResumeLayout(false);
		PerformLayout();
	}
}
