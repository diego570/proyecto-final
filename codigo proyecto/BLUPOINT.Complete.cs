// BLUPOINT.Complete
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;

public class Complete : Form
{
	private string tipos;

	private IContainer components = null;

	private PictureBox pictureBox1;

	private Label label1;

	private Button button1;

	private Label label2;

	public Complete(string tipo)
	{
		InitializeComponent();
		tipos = tipo;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		if (tipos == "1")
		{
			Login login = new Login();
			Hide();
			login.Show();
		}
		else
		{
			Login_2 login_ = new Login_2();
			Hide();
			login_.Show();
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
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label1 = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		label2 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		pictureBox1.Image = BLUPOINT.Properties.Resources._240_F_303721767_iNO49Cr0bPrcZT9eIuTr0VUa5QXuK1es;
		pictureBox1.Location = new System.Drawing.Point(255, 12);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(237, 230);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 0;
		pictureBox1.TabStop = false;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 36f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
		label1.Location = new System.Drawing.Point(207, 206);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(333, 65);
		label1.TabIndex = 1;
		label1.Text = "COMPLETADO";
		button1.BackColor = System.Drawing.Color.Navy;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(271, 363);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(171, 43);
		button1.TabIndex = 11;
		button1.Text = "Continuar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.ForeColor = System.Drawing.Color.Black;
		label2.Location = new System.Drawing.Point(59, 339);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(647, 21);
		label2.TabIndex = 12;
		label2.Text = "Se ha completado la configuracion del sistema. Da click en continuar para acceder al sistema";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(745, 418);
		base.Controls.Add(label2);
		base.Controls.Add(button1);
		base.Controls.Add(label1);
		base.Controls.Add(pictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "Complete";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Complete";
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
