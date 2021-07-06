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
