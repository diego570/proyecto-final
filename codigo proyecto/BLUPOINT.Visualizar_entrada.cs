// BLUPOINT.Visualizar_entrada
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class Visualizar_entrada : Form
{
	private IContainer components = null;

	private TextBox txtconcepto;

	private Label label1;

	private Label label2;

	private TextBox txttipo_p;

	private Label label3;

	private Label label4;

	private Label txttotal;

	private Button button1;

	private Label label6;

	private Label txtfecha;

	private Label label8;

	private Label txtname;

	public Visualizar_entrada(string concepto, string tipo_p, string fecha, string nombre, string total)
	{
		InitializeComponent();
		txtconcepto.Text = concepto;
		txtfecha.Text = fecha;
		txtname.Text = nombre;
		txttipo_p.Text = tipo_p;
		txttotal.Text = total;
	}

	private void button1_Click(object sender, EventArgs e)
	{
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
		txtconcepto = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		txttipo_p = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		txttotal = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		label6 = new System.Windows.Forms.Label();
		txtfecha = new System.Windows.Forms.Label();
		label8 = new System.Windows.Forms.Label();
		txtname = new System.Windows.Forms.Label();
		SuspendLayout();
		txtconcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtconcepto.Location = new System.Drawing.Point(58, 75);
		txtconcepto.Name = "txtconcepto";
		txtconcepto.Size = new System.Drawing.Size(355, 31);
		txtconcepto.TabIndex = 0;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(53, 42);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(102, 30);
		label1.TabIndex = 1;
		label1.Text = "Concepto";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(53, 147);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(134, 30);
		label2.TabIndex = 3;
		label2.Text = "Tipo de Pago";
		txttipo_p.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttipo_p.Location = new System.Drawing.Point(58, 180);
		txttipo_p.Name = "txttipo_p";
		txttipo_p.Size = new System.Drawing.Size(355, 31);
		txttipo_p.TabIndex = 2;
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(187, 377);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(57, 30);
		label3.TabIndex = 4;
		label3.Text = "Total";
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(152, 407);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(43, 50);
		label4.TabIndex = 5;
		label4.Text = "$";
		txttotal.AutoSize = true;
		txttotal.Font = new System.Drawing.Font("Segoe UI", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txttotal.Location = new System.Drawing.Point(193, 407);
		txttotal.Name = "txttotal";
		txttotal.Size = new System.Drawing.Size(74, 50);
		txttotal.TabIndex = 6;
		txttotal.Text = "0.0";
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(128, 474);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(162, 56);
		button1.TabIndex = 7;
		button1.Text = "Aceptar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label6.Location = new System.Drawing.Point(53, 251);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(73, 30);
		label6.TabIndex = 8;
		label6.Text = "Fecha ";
		txtfecha.AutoSize = true;
		txtfecha.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtfecha.Location = new System.Drawing.Point(53, 292);
		txtfecha.Name = "txtfecha";
		txtfecha.Size = new System.Drawing.Size(106, 30);
		txtfecha.TabIndex = 9;
		txtfecha.Text = "12/1/2021";
		label8.AutoSize = true;
		label8.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label8.Location = new System.Drawing.Point(214, 251);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(216, 30);
		label8.TabIndex = 10;
		label8.Text = "Nombre de empleado";
		txtname.AutoSize = true;
		txtname.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtname.Location = new System.Drawing.Point(215, 292);
		txtname.Name = "txtname";
		txtname.Size = new System.Drawing.Size(200, 21);
		txtname.TabIndex = 11;
		txtname.Text = "Alan Jesus Guzman Aguirre";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(442, 542);
		base.Controls.Add(txtname);
		base.Controls.Add(label8);
		base.Controls.Add(txtfecha);
		base.Controls.Add(label6);
		base.Controls.Add(button1);
		base.Controls.Add(txttotal);
		base.Controls.Add(label4);
		base.Controls.Add(label3);
		base.Controls.Add(label2);
		base.Controls.Add(txttipo_p);
		base.Controls.Add(label1);
		base.Controls.Add(txtconcepto);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Visualizar_entrada";
		Text = "Visualizar Entrada";
		ResumeLayout(false);
		PerformLayout();
	}
}
