// BLUPOINT.Rep_Venta
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using BLUPOINT.Source;

public class Rep_Venta : Form
{
	private Ventas ven = new Ventas();

	private string filtro;

	private string ids;

	private IContainer components = null;

	private Panel panel1;

	private DataGridView dgv1;

	private Label label1;

	private Panel panel2;

	private Label txtcant;

	private Label label2;

	private Label txttipo_e;

	private PictureBox image_user;

	private Label label18;

	private Label txtName;

	private Panel panel3;

	private DateTimePicker txtDate;

	private ComboBox cbfilter;

	private Panel panel4;

	private Label label5;

	private Label txttotal;

	private Label label4;

	public Rep_Venta(string id, string nombre, string ruta, string cargo)
	{
		InitializeComponent();
		txtName.Text = nombre;
		txttipo_e.Text = cargo;
		ids = id;
		if (ruta == "")
		{
			image_user.Image = Resources.picture;
		}
		else
		{
			image_user.Image = Image.FromFile(ruta);
		}
		txtDate.Visible = false;
		Loads();
		CountVentas();
	}

	private void CountVentas()
	{
		int num = 0;
		double num2 = 0.0;
		foreach (DataGridViewRow item in (IEnumerable)dgv1.Rows)
		{
			num++;
			num2 += Convert.ToDouble(item.Cells["Total"].Value);
		}
		txttotal.Text = num2.ToString();
		txtcant.Text = num.ToString();
	}

	private void Loads()
	{
		ven.Nombre_E = txtName.Text;
		DateTime now = DateTime.Now;
		ven.Fecha = now.ToString("dd/MMMM/yyyy");
		dgv1.DataSource = ven.GET("Normal");
	}

	private void cbfilter_TextChanged(object sender, EventArgs e)
	{
		if (cbfilter.Text == "DIA")
		{
			txtDate.Visible = true;
			filtro = "Dia";
		}
		if (cbfilter.Text == "MES")
		{
			txtDate.Visible = true;
			filtro = "Mes";
		}
		if (cbfilter.Text == "AÑO")
		{
			txtDate.Visible = true;
			filtro = "Año";
		}
	}

	private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\r')
		{
			return;
		}
		if (filtro == "Dia")
		{
			ven.Nombre_E = txtName.Text;
			if (txtDate.Value.Day.ToString().Length >= 2)
			{
				ven.Fecha = txtDate.Value.Day + "/" + Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			}
			else
			{
				ven.Fecha = "0" + txtDate.Value.Day + "/" + Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			}
			dgv1.DataSource = ven.GET("Dia");
		}
		else if (filtro == "Mes")
		{
			ven.Nombre_E = txtName.Text;
			ven.Fecha = Selectdate(txtDate.Value.Month.ToString()) + "/" + txtDate.Value.Year;
			dgv1.DataSource = ven.GET("Mes");
		}
		else if (filtro == "Año")
		{
			ven.Nombre_E = txtName.Text;
			ven.Fecha = txtDate.Value.Year.ToString();
			dgv1.DataSource = ven.GET("Año");
		}
		CountVentas();
	}

	private void button1_Click(object sender, EventArgs e)
	{
	}

	private string Selectdate(string mont)
	{
		return mont switch
		{
			"1" => "Enero", 
			"2" => "Febrero", 
			"3" => "Marzo", 
			"4" => "Abril", 
			"5" => "Mayo", 
			"6" => "Junio", 
			"7" => "Julio", 
			"8" => "Agosto", 
			"9" => "Septiembre", 
			"10" => "Octubre", 
			"11" => "Noviembre", 
			"12" => "Diciembre", 
			_ => "", 
		};
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Rep_Venta));
		panel1 = new System.Windows.Forms.Panel();
		label1 = new System.Windows.Forms.Label();
		dgv1 = new System.Windows.Forms.DataGridView();
		panel2 = new System.Windows.Forms.Panel();
		label5 = new System.Windows.Forms.Label();
		txttotal = new System.Windows.Forms.Label();
		label4 = new System.Windows.Forms.Label();
		txtcant = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		txttipo_e = new System.Windows.Forms.Label();
		image_user = new System.Windows.Forms.PictureBox();
		label18 = new System.Windows.Forms.Label();
		txtName = new System.Windows.Forms.Label();
		panel3 = new System.Windows.Forms.Panel();
		txtDate = new System.Windows.Forms.DateTimePicker();
		cbfilter = new System.Windows.Forms.ComboBox();
		panel4 = new System.Windows.Forms.Panel();
		panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)dgv1).BeginInit();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)image_user).BeginInit();
		panel3.SuspendLayout();
		SuspendLayout();
		panel1.BackColor = System.Drawing.Color.White;
		panel1.Controls.Add(label1);
		panel1.Controls.Add(dgv1);
		panel1.Location = new System.Drawing.Point(12, 12);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(421, 434);
		panel1.TabIndex = 0;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(71, 12);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(247, 25);
		label1.TabIndex = 1;
		label1.Text = "VENTAS POR USUARIO";
		dgv1.AllowUserToAddRows = false;
		dgv1.AllowUserToDeleteRows = false;
		dgv1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
		dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgv1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
		dgv1.Location = new System.Drawing.Point(3, 55);
		dgv1.Name = "dgv1";
		dgv1.Size = new System.Drawing.Size(415, 371);
		dgv1.TabIndex = 0;
		panel2.BackColor = System.Drawing.Color.White;
		panel2.Controls.Add(label5);
		panel2.Controls.Add(txttotal);
		panel2.Controls.Add(label4);
		panel2.Controls.Add(txtcant);
		panel2.Controls.Add(label2);
		panel2.Controls.Add(txttipo_e);
		panel2.Controls.Add(image_user);
		panel2.Controls.Add(label18);
		panel2.Controls.Add(txtName);
		panel2.Location = new System.Drawing.Point(465, 15);
		panel2.Name = "panel2";
		panel2.Size = new System.Drawing.Size(423, 259);
		panel2.TabIndex = 1;
		label5.AutoSize = true;
		label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label5.ForeColor = System.Drawing.Color.Teal;
		label5.Location = new System.Drawing.Point(248, 215);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(36, 39);
		label5.TabIndex = 37;
		label5.Text = "$";
		txttotal.AutoSize = true;
		txttotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttotal.ForeColor = System.Drawing.Color.Teal;
		txttotal.Location = new System.Drawing.Point(277, 215);
		txttotal.Name = "txttotal";
		txttotal.Size = new System.Drawing.Size(36, 39);
		txttotal.TabIndex = 36;
		txttotal.Text = "0";
		label4.AutoSize = true;
		label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
		label4.Location = new System.Drawing.Point(256, 188);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(160, 24);
		label4.TabIndex = 35;
		label4.Text = "Cantidad Vendida";
		txtcant.AutoSize = true;
		txtcant.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtcant.ForeColor = System.Drawing.Color.Teal;
		txtcant.Location = new System.Drawing.Point(305, 117);
		txtcant.Name = "txtcant";
		txtcant.Size = new System.Drawing.Size(36, 39);
		txtcant.TabIndex = 34;
		txtcant.Text = "0";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
		label2.Location = new System.Drawing.Point(256, 93);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(134, 24);
		label2.TabIndex = 33;
		label2.Text = "Ventas Totales";
		txttipo_e.AutoSize = true;
		txttipo_e.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txttipo_e.Location = new System.Drawing.Point(323, 34);
		txttipo_e.Name = "txttipo_e";
		txttipo_e.Size = new System.Drawing.Size(65, 24);
		txttipo_e.TabIndex = 32;
		txttipo_e.Text = "Cajero";
		image_user.Image = (System.Drawing.Image)resources.GetObject("image_user.Image");
		image_user.Location = new System.Drawing.Point(13, 3);
		image_user.Name = "image_user";
		image_user.Size = new System.Drawing.Size(229, 209);
		image_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		image_user.TabIndex = 29;
		image_user.TabStop = false;
		label18.AutoSize = true;
		label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label18.ForeColor = System.Drawing.SystemColors.AppWorkspace;
		label18.Location = new System.Drawing.Point(256, 34);
		label18.Name = "label18";
		label18.Size = new System.Drawing.Size(61, 24);
		label18.TabIndex = 31;
		label18.Text = "Cargo";
		txtName.AutoSize = true;
		txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtName.Location = new System.Drawing.Point(9, 215);
		txtName.Name = "txtName";
		txtName.Size = new System.Drawing.Size(197, 24);
		txtName.TabIndex = 30;
		txtName.Text = "Jorge Lemus Stripsent";
		panel3.BackColor = System.Drawing.Color.White;
		panel3.Controls.Add(txtDate);
		panel3.Controls.Add(cbfilter);
		panel3.Location = new System.Drawing.Point(465, 280);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(423, 81);
		panel3.TabIndex = 2;
		txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		txtDate.Location = new System.Drawing.Point(13, 52);
		txtDate.Name = "txtDate";
		txtDate.Size = new System.Drawing.Size(391, 26);
		txtDate.TabIndex = 7;
		txtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDate_KeyPress);
		cbfilter.BackColor = System.Drawing.Color.White;
		cbfilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		cbfilter.ForeColor = System.Drawing.Color.Black;
		cbfilter.FormattingEnabled = true;
		cbfilter.Items.AddRange(new object[3] { "DIA", "MES", "AÑO" });
		cbfilter.Location = new System.Drawing.Point(3, 3);
		cbfilter.Name = "cbfilter";
		cbfilter.Size = new System.Drawing.Size(401, 33);
		cbfilter.TabIndex = 5;
		cbfilter.Text = "FILTRAR";
		cbfilter.TextChanged += new System.EventHandler(cbfilter_TextChanged);
		panel4.BackColor = System.Drawing.Color.White;
		panel4.Location = new System.Drawing.Point(467, 369);
		panel4.Name = "panel4";
		panel4.Size = new System.Drawing.Size(420, 68);
		panel4.TabIndex = 3;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(900, 450);
		base.Controls.Add(panel4);
		base.Controls.Add(panel3);
		base.Controls.Add(panel2);
		base.Controls.Add(panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "Rep_Venta";
		Text = "Reporte Venta por Usuario";
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)dgv1).EndInit();
		panel2.ResumeLayout(false);
		panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)image_user).EndInit();
		panel3.ResumeLayout(false);
		ResumeLayout(false);
	}
}
