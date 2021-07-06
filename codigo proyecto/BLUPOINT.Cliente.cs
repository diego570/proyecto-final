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
