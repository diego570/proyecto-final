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
