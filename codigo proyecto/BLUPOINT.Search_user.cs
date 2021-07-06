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
