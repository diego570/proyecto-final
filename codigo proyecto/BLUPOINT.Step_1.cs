// BLUPOINT.Step_1
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;

public class Step_1 : Form
{
	private IContainer components = null;

	private PictureBox pictureBox1;

	private Label label1;

	private Label label2;

	private Button button1;

	public Step_1()
	{
		InitializeComponent();
	}

	private void Step_1_FormClosing(object sender, FormClosingEventArgs e)
	{
		Application.Exit();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Licencia licencia = new Licencia();
		licencia.Show();
		Hide();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Step_1));
		label1 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(12, 327);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(193, 30);
		label1.TabIndex = 1;
		label1.Text = "AHORA MAS FACIL";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(12, 357);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(718, 34);
		label2.TabIndex = 2;
		label2.Text = resources.GetString("label2.Text");
		button1.BackColor = System.Drawing.Color.Navy;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(616, 407);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(171, 43);
		button1.TabIndex = 10;
		button1.Text = "Continuar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		pictureBox1.Image = BLUPOINT.Properties.Resources.img_1;
		pictureBox1.Location = new System.Drawing.Point(2, 2);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(773, 313);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 0;
		pictureBox1.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(787, 450);
		base.Controls.Add(button1);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.Controls.Add(pictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Step_1";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Instalar";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Step_1_FormClosing);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
