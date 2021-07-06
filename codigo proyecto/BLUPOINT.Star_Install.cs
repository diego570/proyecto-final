// BLUPOINT.Star_Install
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;

public class Star_Install : Form
{
	private IContainer components = null;

	private Panel panel1;

	private Label label1;

	private PictureBox pictureBox1;

	private Label label2;

	private Button button1;

	private Button button2;

	public Star_Install()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Step_1 step_ = new Step_1();
		step_.Show();
		Hide();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		if (MessageBox.Show("Seguro que deseas Cancelar??", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			Application.Exit();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Star_Install));
		panel1 = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label2 = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		button2 = new System.Windows.Forms.Button();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.Navy;
		panel1.Controls.Add(label1);
		panel1.Location = new System.Drawing.Point(1, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(725, 63);
		panel1.TabIndex = 7;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 27.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.ForeColor = System.Drawing.Color.White;
		label1.Location = new System.Drawing.Point(154, 9);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(486, 50);
		label1.TabIndex = 0;
		label1.Text = "PROCESO DE INSTALACION ";
		pictureBox1.Image = BLUPOINT.Properties.Resources.spoint;
		pictureBox1.Location = new System.Drawing.Point(164, 81);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(444, 162);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 8;
		pictureBox1.TabStop = false;
		label2.AutoSize = true;
		label2.BackColor = System.Drawing.Color.White;
		label2.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.ForeColor = System.Drawing.Color.Black;
		label2.Location = new System.Drawing.Point(-2, 434);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(257, 17);
		label2.TabIndex = 1;
		label2.Text = "El proceso de instalacion configurara todo";
		button1.BackColor = System.Drawing.Color.Navy;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(302, 271);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(171, 43);
		button1.TabIndex = 9;
		button1.Text = "Instalar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		button2.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
		button2.Cursor = System.Windows.Forms.Cursors.Hand;
		button2.FlatAppearance.BorderSize = 0;
		button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
		button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button2.ForeColor = System.Drawing.Color.White;
		button2.Location = new System.Drawing.Point(302, 335);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(171, 43);
		button2.TabIndex = 10;
		button2.Text = "Cancelar";
		button2.UseVisualStyleBackColor = false;
		button2.Click += new System.EventHandler(button2_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(726, 450);
		base.Controls.Add(button2);
		base.Controls.Add(button1);
		base.Controls.Add(label2);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(panel1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Star_Install";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "BLUPOINT INSTALL";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
