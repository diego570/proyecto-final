// BLUPOINT.Det_Box_Us
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class Det_Box_Us : Form
{
	private IContainer components = null;

	private Button Aceptar;

	private Label label3;

	private TextBox txtfecha;

	private Label label1;

	private TextBox txtentrada;

	private Label label2;

	private TextBox txtconcept;

	public Det_Box_Us(string fecha, string hora, string concep)
	{
		InitializeComponent();
		txtfecha.Text = fecha;
		txtconcept.Text = concep;
		txtentrada.Text = hora;
	}

	private void Aceptar_Click(object sender, EventArgs e)
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
		Aceptar = new System.Windows.Forms.Button();
		label3 = new System.Windows.Forms.Label();
		txtfecha = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		txtentrada = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		txtconcept = new System.Windows.Forms.TextBox();
		SuspendLayout();
		Aceptar.BackColor = System.Drawing.Color.SteelBlue;
		Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		Aceptar.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Aceptar.ForeColor = System.Drawing.Color.White;
		Aceptar.Location = new System.Drawing.Point(43, 295);
		Aceptar.Name = "Aceptar";
		Aceptar.Size = new System.Drawing.Size(189, 51);
		Aceptar.TabIndex = 13;
		Aceptar.Text = "Aceptar";
		Aceptar.UseVisualStyleBackColor = false;
		Aceptar.Click += new System.EventHandler(Aceptar_Click);
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(40, 26);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(61, 25);
		label3.TabIndex = 12;
		label3.Text = "Fecha";
		txtfecha.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtfecha.Location = new System.Drawing.Point(43, 54);
		txtfecha.Name = "txtfecha";
		txtfecha.Size = new System.Drawing.Size(191, 33);
		txtfecha.TabIndex = 11;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(40, 109);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(158, 25);
		label1.TabIndex = 8;
		label1.Text = "Hora de Apertura";
		txtentrada.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtentrada.Location = new System.Drawing.Point(43, 137);
		txtentrada.Name = "txtentrada";
		txtentrada.Size = new System.Drawing.Size(191, 33);
		txtentrada.TabIndex = 7;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(40, 204);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(98, 25);
		label2.TabIndex = 15;
		label2.Text = "Concepto ";
		txtconcept.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtconcept.Location = new System.Drawing.Point(43, 232);
		txtconcept.Name = "txtconcept";
		txtconcept.Size = new System.Drawing.Size(191, 33);
		txtconcept.TabIndex = 14;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(294, 358);
		base.Controls.Add(label2);
		base.Controls.Add(txtconcept);
		base.Controls.Add(Aceptar);
		base.Controls.Add(label3);
		base.Controls.Add(txtfecha);
		base.Controls.Add(label1);
		base.Controls.Add(txtentrada);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "Det_Box_Us";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Det_Box_Us";
		ResumeLayout(false);
		PerformLayout();
	}
}
