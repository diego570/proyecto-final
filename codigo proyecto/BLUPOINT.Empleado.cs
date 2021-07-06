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
