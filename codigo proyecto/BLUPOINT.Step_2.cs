// BLUPOINT.Step_2
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BLUPOINT;
using BLUPOINT.Properties;
using MySql.Data.MySqlClient;

public class Step_2 : Form
{
	private string MyConString = "SERVER=localhost;DATABASE=test;UID=root;PASSWORD=blupoint01;";

	private IContainer components = null;

	private PictureBox pictureBox1;

	private Label label1;

	private Label label2;

	private Button button1;

	private ProgressBar progressBar1;

	private Timer timer1;

	public Step_2()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		CrearDB();
		CrearTablas();
	}

	private void CrearDB()
	{
		try
		{
			MySqlConnection mySqlConnection = new MySqlConnection(MyConString);
			MySqlCommand mySqlCommand = new MySqlCommand("CREATE DATABASE IF NOT EXISTS blupoint;", mySqlConnection);
			mySqlConnection.Open();
			mySqlCommand.ExecuteNonQuery();
			mySqlConnection.Close();
		}
		catch
		{
			errodbalert errodbalert2 = new errodbalert();
			errodbalert2.ShowDialog();
		}
	}

	private void CrearTablas()
	{
		MySqlConnection mySqlConnection = new MySqlConnection(MyConString);
		MySqlCommand mySqlCommand = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`abono`;CREATE TABLE  `blupoint`.`abono` (`idAbono` int(10) unsigned NOT NULL AUTO_INCREMENT,`id_credito` varchar(45) NOT NULL DEFAULT '',`Abono` varchar(45) NOT NULL DEFAULT '',`Fecha` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY(`idAbono`)) ENGINE = InnoDB AUTO_INCREMENT = 9 DEFAULT CHARSET = latin1; ", mySqlConnection);
		MySqlCommand mySqlCommand2 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`asistencia`;CREATE TABLE  `blupoint`.`asistencia` (`idAsistencia` int(10) unsigned NOT NULL AUTO_INCREMENT,`Id_Us` varchar(45) NOT NULL DEFAULT '',`Hora_In` varchar(45) NOT NULL DEFAULT '',`Turno` varchar(45) NOT NULL DEFAULT '',`Hora_fin` varchar(45) NOT NULL DEFAULT '',`Fecha` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idAsistencia`)) ENGINE=InnoDB AUTO_INCREMENT=90 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand3 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`caja`;CREATE TABLE  `blupoint`.`caja` (`idCaja` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre_Caja` varchar(45) NOT NULL DEFAULT '',`Cantidad` varchar(45) NOT NULL DEFAULT '',`Defaults` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idCaja`)) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand4 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`cliente`;CREATE TABLE  `blupoint`.`cliente` (`idCliente` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre` varchar(45) NOT NULL DEFAULT '',`Apellidos` varchar(45) NOT NULL DEFAULT '',`Fecha_Nac` varchar(45) NOT NULL DEFAULT '',`Calle` varchar(45) NOT NULL DEFAULT '',`Colonia` varchar(45) NOT NULL DEFAULT '',`No_Ex` varchar(45) NOT NULL DEFAULT '',`Clave_U` varchar(45) NOT NULL DEFAULT '',`Mayorista` varchar(45) NOT NULL DEFAULT '',`Credito` varchar(45) NOT NULL DEFAULT '',`Telefono` varchar(45) NOT NULL DEFAULT '',`Correo` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idCliente`)) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand5 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`corte_caja`;CREATE TABLE  `blupoint`.`corte_caja` (`idCorte_Caja` int(10) unsigned NOT NULL AUTO_INCREMENT,`id_Caja` varchar(45) NOT NULL DEFAULT '',`Usuario` varchar(45) NOT NULL DEFAULT '',`Contado` varchar(45) NOT NULL DEFAULT '',`Calculado` varchar(45) NOT NULL DEFAULT '',`Diferencia` varchar(45) NOT NULL DEFAULT '',`Retirado` varchar(45) NOT NULL DEFAULT '',`Fecha` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idCorte_Caja`)) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand6 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`credito`;CREATE TABLE  `blupoint`.`credito` (`idCredito` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre_U` varchar(45) NOT NULL DEFAULT '',`Total_Pago` varchar(45) NOT NULL DEFAULT '',`Fecha_Pago` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idCredito`)) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;", mySqlConnection);
		MySqlCommand mySqlCommand7 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`empleado`;CREATE TABLE  `blupoint`.`empleado` (`idEmpleado` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre` varchar(450) NOT NULL DEFAULT '',`Apellidos` varchar(450) NOT NULL DEFAULT '',`Fecha_N` varchar(450) NOT NULL DEFAULT '',`Tipo_Emp` varchar(45) NOT NULL DEFAULT '',`Pass` varchar(45) NOT NULL DEFAULT '',`Clave` varchar(45) NOT NULL DEFAULT '',`Imagen` varchar(4500) NOT NULL DEFAULT '',`Cliente` varchar(45) NOT NULL DEFAULT '',`Producto` varchar(45) NOT NULL DEFAULT '',`Usuario` varchar(45) NOT NULL DEFAULT '',`Caja` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idEmpleado`)) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand8 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`entradas`;CREATE TABLE  `blupoint`.`entradas` (`idEntradas` int(10) unsigned NOT NULL AUTO_INCREMENT,`Cantidad` varchar(45) NOT NULL DEFAULT '',`Fecha` varchar(45) NOT NULL DEFAULT '',`Nombre_E` varchar(45) NOT NULL DEFAULT '',`Tipo_E` varchar(45) NOT NULL DEFAULT '',`id_caja` varchar(45) NOT NULL DEFAULT '',`Concepto` varchar(45) NOT NULL DEFAULT '',`Tipo_Pago` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idEntradas`)) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand9 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`producto`;CREATE TABLE  `blupoint`.`producto` (`idProducto` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre_P` varchar(450) NOT NULL DEFAULT '',`Precio` varchar(45) NOT NULL DEFAULT '',`IVA` varchar(45) NOT NULL DEFAULT '',`Descuento` varchar(45) NOT NULL DEFAULT '',`Imagen` varchar(4500) NOT NULL DEFAULT '',`Codigo` varchar(450) NOT NULL DEFAULT '',`Cantidad` varchar(45) NOT NULL DEFAULT '',`Codigo_Alterno` varchar(45) NOT NULL DEFAULT '',`Fecha_reg` varchar(45) NOT NULL DEFAULT '',`Fecha_cad` varchar(45) NOT NULL DEFAULT '',`Proveedor` varchar(45) NOT NULL DEFAULT '',`Mayoreo` varchar(45) NOT NULL DEFAULT '',`Maximos` varchar(45) NOT NULL DEFAULT '',`Minimos` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idProducto`)) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand10 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`proveedor`;CREATE TABLE  `blupoint`.`proveedor` (`idProveedor` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre` varchar(45) NOT NULL DEFAULT '',`Mail` varchar(45) NOT NULL DEFAULT '',`Telefono` varchar(45) NOT NULL DEFAULT '',`Fecha` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idProveedor`)) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand11 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`salidas`;CREATE TABLE  `blupoint`.`salidas` (`idSalidas` int(10) unsigned NOT NULL AUTO_INCREMENT,`Cantidad` varchar(45) NOT NULL DEFAULT '',`Fecha` varchar(45) NOT NULL DEFAULT '',`Usuario` varchar(45) NOT NULL DEFAULT '',`Tipo_E` varchar(45) NOT NULL DEFAULT '',`id_caja` varchar(45) NOT NULL DEFAULT '',`Concepto` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idSalidas`)) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand12 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`venta`;CREATE TABLE  `blupoint`.`venta` (`idVenta` int(10) unsigned NOT NULL DEFAULT '0',`Nombre_U` varchar(45) NOT NULL DEFAULT '',`Fecha` varchar(45) NOT NULL DEFAULT '',`Nombre_C` varchar(45) NOT NULL DEFAULT '',`Apellido_C` varchar(45) NOT NULL DEFAULT '',`Total` varchar(45) NOT NULL DEFAULT '',`Subtotal` varchar(45) NOT NULL DEFAULT '',`Efectivo` varchar(45) NOT NULL DEFAULT '',`Cambio` varchar(45) NOT NULL DEFAULT '',`Descuento_Total` varchar(45) NOT NULL DEFAULT '',`Tipo_Pago` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idVenta`)) ENGINE=InnoDB DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand13 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`venta_detalle`; CREATE TABLE  `blupoint`.`venta_detalle` (`idVenta_Detalle` int(10) unsigned NOT NULL AUTO_INCREMENT,`Id_Venta` varchar(45) NOT NULL DEFAULT '',`Nombre_Prod` varchar(45) NOT NULL DEFAULT '',`Cantidad` varchar(45) NOT NULL DEFAULT '',`Precio` varchar(45) NOT NULL DEFAULT '',`Iva` varchar(45) NOT NULL DEFAULT '',`Descuento` varchar(45) NOT NULL DEFAULT '',`Codigo` varchar(45) NOT NULL DEFAULT '',`Importe` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY(`idVenta_Detalle`)) ENGINE = InnoDB AUTO_INCREMENT = 45 DEFAULT CHARSET = utf8; ", mySqlConnection);
		MySqlCommand mySqlCommand14 = new MySqlCommand("CREATE TABLE `blupoint`.`Config_Log` (`idConfig_Log` INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,`Tipo` VARCHAR(45) NOT NULL DEFAULT '',PRIMARY KEY(`idConfig_Log`))ENGINE = InnoDB;", mySqlConnection);
		MySqlCommand mySqlCommand15 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`negocio`;CREATE TABLE  `blupoint`.`negocio` (`idNegocio` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre_N` varchar(45) NOT NULL DEFAULT '',`Calle` varchar(45) NOT NULL DEFAULT '',`Colonia` varchar(45) NOT NULL DEFAULT '',`Numero_Ext` varchar(45) NOT NULL DEFAULT '',`CP` varchar(45) NOT NULL DEFAULT '',`Telefono` varchar(45) NOT NULL DEFAULT '',`Correo` varchar(45) NOT NULL DEFAULT '',`Municipio` varchar(45) NOT NULL DEFAULT '',`Estado` varchar(45) NOT NULL DEFAULT '',`Nombre_Fiscal` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idNegocio`)) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand16 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`caja_open`;CREATE TABLE  `blupoint`.`caja_open` (`idCaja_Open` int(10) unsigned NOT NULL AUTO_INCREMENT,`Id_Caja` varchar(45) NOT NULL DEFAULT '',`Tipo_Consumo` varchar(45) NOT NULL DEFAULT '',`open` varchar(45) NOT NULL DEFAULT '',`Fecha` varchar(45) NOT NULL DEFAULT '',`Nombre_Us` varchar(45) NOT NULL DEFAULT '',`Tipo_E` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idCaja_Open`)) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand17 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`oferta`;CREATE TABLE  `blupoint`.`oferta` (`idOferta` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre_Offer` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idOferta`)) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;", mySqlConnection);
		MySqlCommand mySqlCommand18 = new MySqlCommand("DROP TABLE IF EXISTS `blupoint`.`oferta_detalle`;CREATE TABLE  `blupoint`.`oferta_detalle` (`idOferta_Detalle` int(10) unsigned NOT NULL AUTO_INCREMENT,`Nombre_Ofer` varchar(45) NOT NULL DEFAULT '',`Nombre_P` varchar(45) NOT NULL DEFAULT '',`Cantidad` varchar(45) NOT NULL DEFAULT '',`Precio` varchar(45) NOT NULL DEFAULT '',`IVA` varchar(45) NOT NULL DEFAULT '',`Imagen` varchar(450) NOT NULL DEFAULT '',`Codigo` varchar(45) NOT NULL DEFAULT '',`Codigo_Alterno` varchar(45) NOT NULL DEFAULT '',`Proveedor` varchar(45) NOT NULL DEFAULT '',PRIMARY KEY (`idOferta_Detalle`)) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;", mySqlConnection);
		mySqlConnection.Open();
		progressBar1.Visible = true;
		progressBar1.Enabled = true;
		if (mySqlCommand.ExecuteNonQuery() == 0)
		{
			progressBar1.Value = 5;
			if (mySqlCommand2.ExecuteNonQuery() == 0)
			{
				progressBar1.Value = 10;
				if (mySqlCommand3.ExecuteNonQuery() == 0)
				{
					progressBar1.Value = 15;
					if (mySqlCommand4.ExecuteNonQuery() == 0)
					{
						progressBar1.Value = 20;
						if (mySqlCommand5.ExecuteNonQuery() == 0)
						{
							progressBar1.Value = 25;
							if (mySqlCommand6.ExecuteNonQuery() == 0)
							{
								progressBar1.Value = 30;
								if (mySqlCommand7.ExecuteNonQuery() == 0)
								{
									progressBar1.Value = 35;
									if (mySqlCommand8.ExecuteNonQuery() == 0)
									{
										progressBar1.Value = 40;
										if (mySqlCommand9.ExecuteNonQuery() == 0)
										{
											progressBar1.Value = 45;
											if (mySqlCommand10.ExecuteNonQuery() == 0)
											{
												progressBar1.Value = 50;
												if (mySqlCommand11.ExecuteNonQuery() == 0)
												{
													progressBar1.Value = 55;
													if (mySqlCommand12.ExecuteNonQuery() == 0)
													{
														progressBar1.Value = 60;
														if (mySqlCommand13.ExecuteNonQuery() == 0)
														{
															progressBar1.Value = 65;
															if (mySqlCommand14.ExecuteNonQuery() == 0)
															{
																progressBar1.Value = 70;
																if (mySqlCommand15.ExecuteNonQuery() == 0)
																{
																	progressBar1.Value = 82;
																	if (mySqlCommand16.ExecuteNonQuery() == 0)
																	{
																		progressBar1.Value = 95;
																		if (mySqlCommand17.ExecuteNonQuery() == 0)
																		{
																			progressBar1.Value = 100;
																			if (mySqlCommand18.ExecuteNonQuery() == 0 && progressBar1.Value == 100)
																			{
																				MessageBox.Show("Base de datos creada");
																				Step_3 step_ = new Step_3();
																				step_.Show();
																				Close();
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		mySqlConnection.Close();
	}

	private void tabla1()
	{
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		progressBar1.Visible = true;
		progressBar1.Enabled = true;
		if (progressBar1.Value < 100)
		{
			progressBar1.Value++;
		}
		else
		{
			timer1.Stop();
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
		components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLUPOINT.Step_2));
		pictureBox1 = new System.Windows.Forms.PictureBox();
		label1 = new System.Windows.Forms.Label();
		label2 = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		progressBar1 = new System.Windows.Forms.ProgressBar();
		timer1 = new System.Windows.Forms.Timer(components);
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		SuspendLayout();
		pictureBox1.Image = BLUPOINT.Properties.Resources.verificacion;
		pictureBox1.Location = new System.Drawing.Point(290, 12);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(187, 205);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		pictureBox1.TabIndex = 0;
		pictureBox1.TabStop = false;
		label1.AutoSize = true;
		label1.Font = new System.Drawing.Font("Segoe UI", 21.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label1.Location = new System.Drawing.Point(12, 277);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(240, 40);
		label1.TabIndex = 1;
		label1.Text = "INSTALAR DATOS";
		label2.AutoSize = true;
		label2.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		label2.Location = new System.Drawing.Point(12, 330);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(725, 42);
		label2.TabIndex = 2;
		label2.Text = "Haremos las configuraciones Principales e instalaremos la base de datos, una vez completada la accion, \r\nrealizaras el registro del usuario administrador y podras configurar tu punto de venta.";
		button1.BackColor = System.Drawing.Color.Navy;
		button1.Cursor = System.Windows.Forms.Cursors.Hand;
		button1.FlatAppearance.BorderSize = 0;
		button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
		button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		button1.ForeColor = System.Drawing.Color.White;
		button1.Location = new System.Drawing.Point(318, 395);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(205, 43);
		button1.TabIndex = 10;
		button1.Text = "Aceptar e Instalar";
		button1.UseVisualStyleBackColor = false;
		button1.Click += new System.EventHandler(button1_Click);
		progressBar1.Enabled = false;
		progressBar1.Location = new System.Drawing.Point(183, 233);
		progressBar1.Name = "progressBar1";
		progressBar1.Size = new System.Drawing.Size(377, 23);
		progressBar1.TabIndex = 11;
		progressBar1.Visible = false;
		timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(800, 450);
		base.Controls.Add(progressBar1);
		base.Controls.Add(button1);
		base.Controls.Add(label2);
		base.Controls.Add(label1);
		base.Controls.Add(pictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "Step_2";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "Step_2";
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
