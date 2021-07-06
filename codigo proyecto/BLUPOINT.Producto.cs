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
