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
