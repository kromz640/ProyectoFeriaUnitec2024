using System;
using System.Drawing;
using System.Windows.Forms;

namespace lectorDatos
{
    public class frmAbout : Form
    {
        private Label titleLabel;
        private Label namesLabel;
        private Label projectLabel;
        private Button btnAceptar;

        public frmAbout()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.titleLabel = new Label();
            this.namesLabel = new Label();
            this.projectLabel = new Label();
            this.btnAceptar = new Button();

            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.titleLabel.Location = new Point(50, 20);
            this.titleLabel.Size = new Size(400, 24);
            this.titleLabel.Text = "Proyecto Feria Científica Junio 2024";
            this.titleLabel.ForeColor = Color.FromArgb(0, 51, 102);

            // 
            // namesLabel
            // 
            this.namesLabel.AutoSize = true;
            this.namesLabel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.namesLabel.Location = new Point(50, 60);
            this.namesLabel.Size = new Size(400, 18);
            this.namesLabel.Text = "Rolando Roque Kuan\nLeslie Urbina Martinez\nJorge Luis Rivera Zuniga\nGersan Enrique Colindres Centeno\nFernando Jose Chavez Rodriguez";
            this.namesLabel.ForeColor = Color.FromArgb(0, 102, 204);

            // 
            // projectLabel
            // 
            this.projectLabel.AutoSize = true;
            this.projectLabel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.projectLabel.Location = new Point(50, 120);
            this.projectLabel.Size = new Size(400, 18);
            this.projectLabel.Text = "Estación de Clima";
            this.projectLabel.ForeColor = Color.FromArgb(0, 51, 102);

            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new Point(150, 160);
            this.btnAceptar.Size = new Size(100, 30);
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.BackColor = Color.FromArgb(0, 102, 204);
            this.btnAceptar.ForeColor = Color.White;
            this.btnAceptar.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnAceptar.Click += new EventHandler(this.BtnAceptar_Click);

            // 
            // frmAbout
            // 
            this.ClientSize = new Size(400, 220);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.namesLabel);
            this.Controls.Add(this.projectLabel);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Acerca de";
            this.BackColor = Color.White;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
