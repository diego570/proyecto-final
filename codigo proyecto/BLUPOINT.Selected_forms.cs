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
