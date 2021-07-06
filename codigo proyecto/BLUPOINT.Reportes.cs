// BLUPOINT.Reportes
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class Reportes : Form
{
	private IContainer components = null;

	private Panel panel1;

	private Label label1;

	private PictureBox pictureBox1;

	private PictureBox pictureBox2;

	private PictureBox pictureBox3;

	public Reportes()
	{
		InitializeComponent();
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
		panel1 = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		pictureBox3 = new System.Windows.Forms.PictureBox();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.SteelBlue;
		panel1.Controls.Add(label1);
		panel1.Dock = System.Windows.Forms.DockStyle.Top;
		panel1.Location = new System.Drawing.Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(901, 64);
		panel1.TabIndex = 0;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 26.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label1.ForeColor = System.Drawing.Color.White;
		label1.Location = new System.Drawing.Point(393, 9);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(193, 47);
		label1.TabIndex = 0;
		label1.Text = "REPORTES";
		pictureBox1.Location = new System.Drawing.Point(65, 116);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(228, 249);
		pictureBox1.TabIndex = 1;
		pictureBox1.TabStop = false;
		pictureBox2.Location = new System.Drawing.Point(336, 116);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(228, 249);
		pictureBox2.TabIndex = 2;
		pictureBox2.TabStop = false;
		pictureBox3.Location = new System.Drawing.Point(637, 116);
		pictureBox3.Name = "pictureBox3";
		pictureBox3.Size = new System.Drawing.Size(228, 249);
		pictureBox3.TabIndex = 3;
		pictureBox3.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(901, 507);
		base.Controls.Add(pictureBox3);
		base.Controls.Add(pictureBox2);
		base.Controls.Add(pictureBox1);
		base.Controls.Add(panel1);
		base.Name = "Reportes";
		Text = "Reportes";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
		ResumeLayout(false);
	}
}
