// BLUPOINT.alert_success
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT.Properties;

public class alert_success : Form
{
	private IContainer components = null;

	private PictureBox pictureBox1;

	private Button button1;

	private Label Mesa;

	private Label label1;

	public alert_success(string mensaje)
	{
		InitializeComponent();
		Mesa.Text = mensaje;
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
		pictureBox1 = new System.Windows.Forms.PictureBox();
		button1 = new System.Windows.Forms.Button();
		Mesa = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		pictureBox1.Image = BLUPOINT.Properties.Resources.success;
		pictureBox1.Location = new System.Drawing.Point(122, 40);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(122, 120);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 0;
		pictureBox1.TabStop = false;
		button1.BackColor = System.Drawing.Color.FromArgb(54, 185, 219);
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(96, 284);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(166, 42);
		button1.TabIndex = 4;
		button1.Text = "Aceptar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		Mesa.AutoSize = true;
		Mesa.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		Mesa.Location = new System.Drawing.Point(68, 226);
		Mesa.Name = "Mesa";
		Mesa.Size = new System.Drawing.Size(202, 30);
		Mesa.TabIndex = 6;
		Mesa.Text = "Ha ocurrido un error";
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 26.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(65, 163);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(244, 47);
		label1.TabIndex = 5;
		label1.Text = "¡Completado!";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(400, 332);
		base.Controls.Add(Mesa);
		base.Controls.Add(label1);
		base.Controls.Add(button1);
		base.Controls.Add(pictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "alert_success";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "alert_success";
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
