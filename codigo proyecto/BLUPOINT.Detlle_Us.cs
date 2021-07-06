// BLUPOINT.Detlle_Us
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class Detlle_Us : Form
{
	private IContainer components = null;

	private TextBox txtentrada;

	private Label label1;

	private Label label2;

	private TextBox txtsalida;

	private Label label3;

	private TextBox txtfecha;

	private Button Aceptar;

	public Detlle_Us(string fecha, string h_e, string h_f)
	{
		InitializeComponent();
		base.KeyPreview = true;
		base.KeyDown += Detlle_Us_KeyUp;
		Inicio(fecha, h_e, h_f);
	}

	private void Inicio(string f, string h_e, string h_f)
	{
		txtfecha.Text = f;
		txtentrada.Text = h_e;
		txtsalida.Text = h_f;
	}

	private void Aceptar_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void Detlle_Us_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			Close();
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
		txtentrada = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		txtsalida = new System.Windows.Forms.TextBox();
		label3 = new System.Windows.Forms.Label();
		txtfecha = new System.Windows.Forms.TextBox();
		Aceptar = new System.Windows.Forms.Button();
		SuspendLayout();
		txtentrada.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtentrada.Location = new System.Drawing.Point(19, 182);
		txtentrada.Name = "txtentrada";
		txtentrada.Size = new System.Drawing.Size(191, 33);
		txtentrada.TabIndex = 0;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(16, 154);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(149, 25);
		label1.TabIndex = 1;
		label1.Text = "Hora de Entrada";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(16, 266);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(135, 25);
		label2.TabIndex = 3;
		label2.Text = "Hora de Salida";
		txtsalida.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtsalida.Location = new System.Drawing.Point(19, 294);
		txtsalida.Name = "txtsalida";
		txtsalida.Size = new System.Drawing.Size(191, 33);
		txtsalida.TabIndex = 2;
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(16, 30);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(61, 25);
		label3.TabIndex = 5;
		label3.Text = "Fecha";
		txtfecha.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtfecha.Location = new System.Drawing.Point(19, 58);
		txtfecha.Name = "txtfecha";
		txtfecha.Size = new System.Drawing.Size(191, 33);
		txtfecha.TabIndex = 4;
		Aceptar.BackColor = System.Drawing.Color.SteelBlue;
		Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		Aceptar.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Aceptar.ForeColor = System.Drawing.Color.White;
		Aceptar.Location = new System.Drawing.Point(81, 398);
		Aceptar.Name = "Aceptar";
		Aceptar.Size = new System.Drawing.Size(129, 40);
		Aceptar.TabIndex = 6;
		Aceptar.Text = "Aceptar";
		Aceptar.UseVisualStyleBackColor = false;
		Aceptar.Click += new System.EventHandler(Aceptar_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(322, 450);
		base.Controls.Add(Aceptar);
		base.Controls.Add(label3);
		base.Controls.Add(txtfecha);
		base.Controls.Add(label2);
		base.Controls.Add(txtsalida);
		base.Controls.Add(label1);
		base.Controls.Add(txtentrada);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "Detlle_Us";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Detlle_Us";
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(Detlle_Us_KeyUp);
		ResumeLayout(false);
		PerformLayout();
	}
}
