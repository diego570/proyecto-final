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
