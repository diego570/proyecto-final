// BLUPOINT.Codigo_Barras_Prod
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BarcodeLib;

public class Codigo_Barras_Prod : Form
{
	private bool pregunta;

	private IContainer components = null;

	private Panel pnlresult;

	private TextBox txtname;

	private Button button1;

	private PrintDocument printDocument1;

	private CheckBox checkBox1;

	public Codigo_Barras_Prod()
	{
		InitializeComponent();
		pregunta = false;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			Barcode barcode = new Barcode();
			barcode.IncludeLabel = true;
			pnlresult.BackgroundImage = barcode.Encode(TYPE.CODE128, txtname.Text, Color.Black, Color.White, 200, 100);
			if (!pregunta)
			{
				if (MessageBox.Show("Deseas Imprimir la etiqueta??", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Print();
				}
			}
			else
			{
				Print();
			}
		}
		catch
		{
			MessageBox.Show("Ha ocurrido un problema, contacta con el soporte tecnico");
		}
	}

	private void Print()
	{
		printDocument1 = new PrintDocument();
		PrinterSettings printerSettings = new PrinterSettings();
		printDocument1.PrinterSettings = printerSettings;
		printDocument1.PrintPage += Imprimir;
		printDocument1.Print();
	}

	private void Imprimir(object sender, PrintPageEventArgs e)
	{
		int num = 20;
		Image backgroundImage = pnlresult.BackgroundImage;
		e.Graphics.DrawImage(backgroundImage, new Rectangle(0, num += 20, 200, 80));
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox1.Checked)
		{
			pregunta = true;
		}
		else
		{
			pregunta = false;
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
		pnlresult = new System.Windows.Forms.Panel();
		txtname = new System.Windows.Forms.TextBox();
		button1 = new System.Windows.Forms.Button();
		printDocument1 = new System.Drawing.Printing.PrintDocument();
		checkBox1 = new System.Windows.Forms.CheckBox();
		SuspendLayout();
		pnlresult.BackColor = System.Drawing.Color.White;
		pnlresult.Location = new System.Drawing.Point(82, 36);
		pnlresult.Name = "pnlresult";
		pnlresult.Size = new System.Drawing.Size(200, 100);
		pnlresult.TabIndex = 0;
		txtname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtname.Location = new System.Drawing.Point(22, 142);
		txtname.Name = "txtname";
		txtname.Size = new System.Drawing.Size(293, 31);
		txtname.TabIndex = 1;
		button1.BackColor = System.Drawing.Color.SteelBlue;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(109, 179);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(124, 51);
		button1.TabIndex = 2;
		button1.Text = "Generar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		checkBox1.AutoSize = true;
		checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		checkBox1.Location = new System.Drawing.Point(2, 4);
		checkBox1.Name = "checkBox1";
		checkBox1.Size = new System.Drawing.Size(147, 24);
		checkBox1.TabIndex = 3;
		checkBox1.Text = "Siempre Imprimir";
		checkBox1.UseVisualStyleBackColor = true;
		checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(345, 225);
		base.Controls.Add(checkBox1);
		base.Controls.Add(button1);
		base.Controls.Add(txtname);
		base.Controls.Add(pnlresult);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Codigo_Barras_Prod";
		Text = "Codigo_Barras_Prod";
		ResumeLayout(false);
		PerformLayout();
	}
}
