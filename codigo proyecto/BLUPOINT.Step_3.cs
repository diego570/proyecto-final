// BLUPOINT.Step_3
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Config;
using BLUPOINT.Properties;
using MySql.Data.MySqlClient;

public class Step_3 : Form
{
	private IContainer components = null;

	private Panel panel1;

	private Panel panel3;

	private Panel panel2;

	private Label label1;

	private PictureBox pictureBox2;

	private PictureBox pictureBox1;

	private Panel panel6;

	private Label label5;

	private Panel panel5;

	private Label label4;

	private Panel panel4;

	private Label label2;

	private Label label3;

	private ToolTip toolTip1;

	public Step_3()
	{
		InitializeComponent();
	}

	private void panel2_Paint(object sender, PaintEventArgs e)
	{
	}

	private void Insertar(string tipo)
	{
		DB dB = new DB();
		dB.Conexion().Open();
		MySqlCommand mySqlCommand = new MySqlCommand();
		mySqlCommand.CommandType = CommandType.Text;
		mySqlCommand.CommandText = "INSERT INTO config_log(Tipo)VALUES(@tip)";
		mySqlCommand.Parameters.AddWithValue("tip", tipo);
		if (dB.ExeNonQuery(mySqlCommand) == 1)
		{
			Registro1 registro = new Registro1(tipo);
			registro.Show();
			Hide();
		}
	}

	private void panel3_Paint(object sender, PaintEventArgs e)
	{
	}

	private void panel2_MouseClick(object sender, MouseEventArgs e)
	{
		Insertar("1");
	}

	private void panel3_MouseClick(object sender, MouseEventArgs e)
	{
	}

	private void panel3_MouseClick_1(object sender, MouseEventArgs e)
	{
		Insertar("2");
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
		components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Step_3));
		panel1 = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
		panel3 = new System.Windows.Forms.Panel();
		panel6 = new System.Windows.Forms.Panel();
		label5 = new System.Windows.Forms.Label();
		panel5 = new System.Windows.Forms.Panel();
		label4 = new System.Windows.Forms.Label();
		panel4 = new System.Windows.Forms.Panel();
		label2 = new System.Windows.Forms.Label();
		pictureBox2 = new System.Windows.Forms.PictureBox();
		panel2 = new System.Windows.Forms.Panel();
		label3 = new System.Windows.Forms.Label();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		toolTip1 = new System.Windows.Forms.ToolTip(components);
		panel1.SuspendLayout();
		panel3.SuspendLayout();
		panel6.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(label1);
		panel1.Controls.Add(panel3);
		panel1.Controls.Add(panel2);
		panel1.Location = new System.Drawing.Point(12, 12);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(764, 437);
		panel1.TabIndex = 0;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 20.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(215, 0);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(431, 37);
		label1.TabIndex = 2;
		label1.Text = "SELECCIONA UNA VISTA DE INICIO";
		panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel3.Controls.Add(panel6);
		panel3.Controls.Add(panel5);
		panel3.Controls.Add(label4);
		panel3.Controls.Add(panel4);
		panel3.Controls.Add(label2);
		panel3.Controls.Add(pictureBox2);
		panel3.Cursor = System.Windows.Forms.Cursors.Hand;
		panel3.Location = new System.Drawing.Point(404, 76);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(342, 332);
		panel3.TabIndex = 1;
		toolTip1.SetToolTip(panel3, "En esta vista, es mas familiarizado con los sistemas convencionales, introduces el nombre del empleado y su contraseña el sistema en automatico detectara quien es y dara acceso al panel principal.");
		panel3.Paint += new System.Windows.Forms.PaintEventHandler(panel3_Paint);
		panel3.MouseClick += new System.Windows.Forms.MouseEventHandler(panel3_MouseClick_1);
		panel6.BackColor = System.Drawing.Color.Navy;
		panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel6.Controls.Add(label5);
		panel6.Location = new System.Drawing.Point(54, 287);
		panel6.Name = "panel6";
		panel6.Size = new System.Drawing.Size(232, 30);
		panel6.TabIndex = 12;
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.ForeColor = System.Drawing.Color.White;
		label5.Location = new System.Drawing.Point(67, 5);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(96, 20);
		label5.TabIndex = 13;
		label5.Text = "Iniciar Sesion";
		panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel5.Location = new System.Drawing.Point(54, 239);
		panel5.Name = "panel5";
		panel5.Size = new System.Drawing.Size(232, 30);
		panel5.TabIndex = 11;
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label4.Location = new System.Drawing.Point(50, 216);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(83, 20);
		label4.TabIndex = 10;
		label4.Text = "Contraseña";
		panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel4.Location = new System.Drawing.Point(54, 176);
		panel4.Name = "panel4";
		panel4.Size = new System.Drawing.Size(232, 30);
		panel4.TabIndex = 9;
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(50, 153);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(139, 20);
		label2.TabIndex = 8;
		label2.Text = "Nombre de Usuario";
		pictureBox2.Image = BLUPOINT.Properties.Resources.spoint;
		pictureBox2.Location = new System.Drawing.Point(40, 26);
		pictureBox2.Name = "pictureBox2";
		pictureBox2.Size = new System.Drawing.Size(265, 103);
		pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox2.TabIndex = 7;
		pictureBox2.TabStop = false;
		panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		panel2.Controls.Add(label3);
		panel2.Controls.Add(pictureBox1);
		panel2.Cursor = System.Windows.Forms.Cursors.Hand;
		panel2.Location = new System.Drawing.Point(24, 76);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(342, 332);
		panel2.TabIndex = 0;
		toolTip1.SetToolTip(panel2, "En esta vista solo se escanea el codigo de barras del usuario y da acceso al sistema con sus privilegios en automatico");
		panel2.Paint += new System.Windows.Forms.PaintEventHandler(panel2_Paint);
		panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(panel2_MouseClick);
		label3.AutoSize = true;
		label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		label3.Location = new System.Drawing.Point(43, 186);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(244, 20);
		label3.TabIndex = 7;
		label3.Text = "Escanea tu Codigo de Barras";
		pictureBox1.Image = BLUPOINT.Properties.Resources.spoint;
		pictureBox1.Location = new System.Drawing.Point(31, 26);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(265, 103);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 6;
		pictureBox1.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(779, 450);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Step_3";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Step_3";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		panel6.ResumeLayout(false);
		panel6.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
	}
}
