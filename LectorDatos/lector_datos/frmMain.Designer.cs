namespace lectorDatos
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            btnSalir = new Button();
            btnAbout = new Button();
            btnInicio = new Button();
            pictureBoxProfile = new PictureBox();
            panelContent = new Panel();
            label1 = new Label();
            btnAppCliente = new Button();
            btnDetenerArduino = new Button();
            btnConexionArduino = new Button();
            btnStop = new Button();
            btnIniciar = new Button();
            panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).BeginInit();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.Blue;
            panelSidebar.Controls.Add(btnSalir);
            panelSidebar.Controls.Add(btnAbout);
            panelSidebar.Controls.Add(btnInicio);
            panelSidebar.Controls.Add(pictureBoxProfile);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(4, 3, 4, 3);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(233, 579);
            panelSidebar.TabIndex = 0;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Transparent;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            btnSalir.ForeColor = Color.Yellow;
            btnSalir.Location = new Point(0, 292);
            btnSalir.Margin = new Padding(4, 3, 4, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(233, 46);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += button1_Click;
            // 
            // btnAbout
            // 
            btnAbout.BackColor = Color.Transparent;
            btnAbout.FlatAppearance.BorderSize = 0;
            btnAbout.FlatStyle = FlatStyle.Flat;
            btnAbout.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            btnAbout.ForeColor = Color.Yellow;
            btnAbout.Location = new Point(0, 231);
            btnAbout.Margin = new Padding(4, 3, 4, 3);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(233, 46);
            btnAbout.TabIndex = 3;
            btnAbout.Text = "ABOUT...";
            btnAbout.UseVisualStyleBackColor = false;
            btnAbout.Click += btnSalir_Click;
            // 
            // btnInicio
            // 
            btnInicio.BackColor = Color.Transparent;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            btnInicio.ForeColor = Color.Yellow;
            btnInicio.Location = new Point(0, 173);
            btnInicio.Margin = new Padding(4, 3, 4, 3);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(233, 46);
            btnInicio.TabIndex = 2;
            btnInicio.Text = "INICIO";
            btnInicio.UseVisualStyleBackColor = false;
            btnInicio.Click += btnInicio_Click;
            // 
            // pictureBoxProfile
            // 
            pictureBoxProfile.BackColor = Color.White;
            pictureBoxProfile.BackgroundImage = lector_datos.Properties.Resources.icon_admin;
            pictureBoxProfile.Image = lector_datos.Properties.Resources.icon_admin;
            pictureBoxProfile.InitialImage = lector_datos.Properties.Resources.icon_admin;
            pictureBoxProfile.Location = new Point(58, 35);
            pictureBoxProfile.Margin = new Padding(4, 3, 4, 3);
            pictureBoxProfile.Name = "pictureBoxProfile";
            pictureBoxProfile.Size = new Size(117, 115);
            pictureBoxProfile.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProfile.TabIndex = 0;
            pictureBoxProfile.TabStop = false;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.Yellow;
            panelContent.Controls.Add(label1);
            panelContent.Controls.Add(btnAppCliente);
            panelContent.Controls.Add(btnDetenerArduino);
            panelContent.Controls.Add(btnConexionArduino);
            panelContent.Controls.Add(btnStop);
            panelContent.Controls.Add(btnIniciar);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(233, 0);
            panelContent.Margin = new Padding(4, 3, 4, 3);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(750, 579);
            panelContent.TabIndex = 1;
            panelContent.Paint += panelContent_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(191, 22);
            label1.Name = "label1";
            label1.Size = new Size(319, 36);
            label1.TabIndex = 8;
            label1.Text = "PANEL DE CONTROL";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // btnAppCliente
            // 
            btnAppCliente.BackgroundImage = lector_datos.Properties.Resources.weather_forecast_monitor;
            btnAppCliente.BackgroundImageLayout = ImageLayout.Stretch;
            btnAppCliente.FlatAppearance.BorderColor = Color.Black;
            btnAppCliente.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            btnAppCliente.ForeColor = Color.MediumSpringGreen;
            btnAppCliente.Location = new Point(497, 87);
            btnAppCliente.Name = "btnAppCliente";
            btnAppCliente.Size = new Size(174, 215);
            btnAppCliente.TabIndex = 7;
            btnAppCliente.Text = "ABRIR APLICACION CLIENTE";
            btnAppCliente.UseVisualStyleBackColor = true;
            btnAppCliente.Click += btnAppCliente_Click;
            // 
            // btnDetenerArduino
            // 
            btnDetenerArduino.BackgroundImage = lector_datos.Properties.Resources.arduino_board_with_laptop_new;
            btnDetenerArduino.BackgroundImageLayout = ImageLayout.Stretch;
            btnDetenerArduino.FlatAppearance.BorderColor = Color.Black;
            btnDetenerArduino.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            btnDetenerArduino.ForeColor = Color.MediumSpringGreen;
            btnDetenerArduino.Location = new Point(270, 334);
            btnDetenerArduino.Name = "btnDetenerArduino";
            btnDetenerArduino.Size = new Size(174, 215);
            btnDetenerArduino.TabIndex = 5;
            btnDetenerArduino.Text = "DETENER ARDUINO";
            btnDetenerArduino.UseVisualStyleBackColor = true;
            btnDetenerArduino.Click += btnDetenerArduino_Click;
            // 
            // btnConexionArduino
            // 
            btnConexionArduino.BackgroundImage = lector_datos.Properties.Resources.arduino_board;
            btnConexionArduino.BackgroundImageLayout = ImageLayout.Stretch;
            btnConexionArduino.FlatAppearance.BorderColor = Color.Black;
            btnConexionArduino.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            btnConexionArduino.ForeColor = Color.MediumSpringGreen;
            btnConexionArduino.Location = new Point(55, 334);
            btnConexionArduino.Name = "btnConexionArduino";
            btnConexionArduino.Size = new Size(174, 215);
            btnConexionArduino.TabIndex = 2;
            btnConexionArduino.Text = "VERIFICAR CONEXION ARDUINO";
            btnConexionArduino.UseVisualStyleBackColor = true;
            btnConexionArduino.Click += btnConexionArduino_Click;
            // 
            // btnStop
            // 
            btnStop.BackgroundImage = lector_datos.Properties.Resources.computer_server_office;
            btnStop.BackgroundImageLayout = ImageLayout.Stretch;
            btnStop.FlatAppearance.BorderColor = Color.Black;
            btnStop.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            btnStop.ForeColor = Color.MediumSpringGreen;
            btnStop.Location = new Point(270, 87);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(174, 215);
            btnStop.TabIndex = 3;
            btnStop.Text = "DETENER SERVICIO";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnIniciar
            // 
            btnIniciar.BackColor = Color.Transparent;
            btnIniciar.BackgroundImage = lector_datos.Properties.Resources.computer_server_office;
            btnIniciar.BackgroundImageLayout = ImageLayout.Stretch;
            btnIniciar.FlatAppearance.BorderColor = Color.Black;
            btnIniciar.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciar.ForeColor = Color.MediumSpringGreen;
            btnIniciar.Location = new Point(55, 87);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(174, 218);
            btnIniciar.TabIndex = 4;
            btnIniciar.Text = "INICIAR SERVICIO";
            btnIniciar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIniciar.UseVisualStyleBackColor = false;
            btnIniciar.Click += button3_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 579);
            Controls.Add(panelContent);
            Controls.Add(panelSidebar);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmMain";
            Text = "Dashboard";
            panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Panel panelContent;
        private Button btnAppCliente;
        private Button btnDetenerArduino;
        private Button btnConexionArduino;
        private Button btnStop;
        private Button btnIniciar;
        private Label label1;
        private Button btnSalir;
    }
}
