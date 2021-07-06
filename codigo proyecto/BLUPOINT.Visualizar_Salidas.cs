// BLUPOINT.Visualizar_Salidas
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class Visualizar_Salidas : Form
{
	private IContainer components = null;

	private Label txtname;

	private Label label8;

	private Label txtfecha;

	private Label label6;

	private Label txttotal;

	private Label label4;

	private Label label3;

	private Label label1;

	private TextBox txtconcepto;

	private Button button1;

	public Visualizar_Salidas(string concepto, string fecha, string nombre, string total)
	{
		InitializeComponent();
		txtconcepto.Text = concepto;
		txtfecha.Text = fecha;
		txtname.Text = nombre;
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
		txtname = new System.Windows.Forms.Label();
		label8 = new System.Windows.Forms.Label();
		txtfecha = new System.Windows.Forms.Label();
		label6 = new System.Windows.Forms.Label();
		txttotal = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		txtconcepto = new System.Windows.Forms.TextBox();
		button1 = new System.Windows.Forms.Button();
		SuspendLayout();
		txtname.AutoSize = true;
		txtname.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtname.Location = new System.Drawing.Point(198, 193);
		txtname.Name = "txtname";
		txtname.Size = new System.Drawing.Size(200, 21);
		txtname.TabIndex = 22;
		txtname.Text = "Alan Jesus Guzman Aguirre";
		label8.AutoSize = true;
		label8.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label8.Location = new System.Drawing.Point(197, 152);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(216, 30);
		label8.TabIndex = 21;
		label8.Text = "Nombre de empleado";
		txtfecha.AutoSize = true;
		txtfecha.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtfecha.Location = new System.Drawing.Point(36, 193);
		txtfecha.Name = "txtfecha";
		txtfecha.Size = new System.Drawing.Size(106, 30);
		txtfecha.TabIndex = 20;
		txtfecha.Text = "12/1/2021";
		label6.AutoSize = true;
		label6.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label6.Location = new System.Drawing.Point(36, 152);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(73, 30);
		label6.TabIndex = 19;
		label6.Text = "Fecha ";
		txttotal.AutoSize = true;
		txttotal.Font = new System.Drawing.Font("Segoe UI", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		txttotal.Location = new System.Drawing.Point(176, 308);
		txttotal.Name = "txttotal";
		txttotal.Size = new System.Drawing.Size(74, 50);
		txttotal.TabIndex = 18;
		txttotal.Text = "0.0";
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(135, 308);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(43, 50);
		label4.TabIndex = 17;
		label4.Text = "$";
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(170, 278);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(57, 30);
		label3.TabIndex = 16;
		label3.Text = "Total";
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(38, 41);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(102, 30);
		label1.TabIndex = 13;
		label1.Text = "Concepto";
		txtconcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtconcepto.Location = new System.Drawing.Point(43, 74);
		txtconcepto.Name = "txtconcepto";
		txtconcepto.Size = new System.Drawing.Size(355, 31);
		txtconcepto.TabIndex = 12;
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(122, 382);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(162, 56);
		button1.TabIndex = 23;
		button1.Text = "Aceptar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(442, 450);
		base.Controls.Add(button1);
		base.Controls.Add(txtname);
		base.Controls.Add(label8);
		base.Controls.Add(txtfecha);
		base.Controls.Add(label6);
		base.Controls.Add(txttotal);
		base.Controls.Add(label4);
		base.Controls.Add(label3);
		base.Controls.Add(label1);
		base.Controls.Add(txtconcepto);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Visualizar_Salidas";
		Text = "Visualizar_Salidas";
		ResumeLayout(false);
		PerformLayout();
	}
}
