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
