// BLUPOINT.Licencia
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;

public class Licencia : Form
{
	private IContainer components = null;

	private TextBox textBox1;

	private Label label1;

	private Panel panel1;

	private Label label2;

	private Label lblresponse;

	public Licencia()
	{
		InitializeComponent();
	}

	private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			if (Licenciaa(textBox1.Text) == 1)
			{
				Step_2 step_ = new Step_2();
				step_.Show();
				Close();
			}
			else
			{
				lblresponse.ForeColor = Color.Red;
				lblresponse.Text = "Codigo Invalido, intenta nuevamente";
			}
		}
	}

	private int Licenciaa(string campo)
	{
		return campo switch
		{
			"XBSZ-DDFR-Z65G-NM8F" => 1, 
			"P8UH-ZD7R-L379-AB89" => 1, 
			"SSJH-LLMK-ÑOPA-SSDE" => 1, 
			"FJHY-76YH-PCF6-77XH" => 1, 
			"FFNU-DPXS-36G5-Y76G" => 1, 
			_ => 0, 
		};
	}

	private void textBox1_TextChanged(object sender, EventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Licencia));
		textBox1 = new System.Windows.Forms.TextBox();
		label1 = new System.Windows.Forms.Label();
		panel1 = new System.Windows.Forms.Panel();
		label2 = new System.Windows.Forms.Label();
		lblresponse = new System.Windows.Forms.Label();
		panel1.SuspendLayout();
		SuspendLayout();
		textBox1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		textBox1.Location = new System.Drawing.Point(113, 191);
		textBox1.Name = "textBox1";
		textBox1.Size = new System.Drawing.Size(524, 35);
		textBox1.TabIndex = 0;
		textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
		textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(108, 158);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(287, 30);
		label1.TabIndex = 1;
		label1.Text = "Introduce la clave del sistema";
		panel1.BackColor = System.Drawing.Color.Navy;
		panel1.Controls.Add(label2);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(781, 66);
		panel1.TabIndex = 2;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 27.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.ForeColor = System.Drawing.Color.White;
		label2.Location = new System.Drawing.Point(142, 9);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(485, 50);
		label2.TabIndex = 3;
		label2.Text = "ACTIVACION DE PRODUCTO";
		lblresponse.AutoSize = true;
		lblresponse.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblresponse.Location = new System.Drawing.Point(245, 239);
		lblresponse.Name = "lblresponse";
		lblresponse.Size = new System.Drawing.Size(0, 30);
		lblresponse.TabIndex = 3;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(781, 377);
		base.Controls.Add(lblresponse);
		base.Controls.Add(panel1);
		base.Controls.Add(label1);
		base.Controls.Add(textBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Licencia";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Licencia";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}
}
