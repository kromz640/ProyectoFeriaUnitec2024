namespace AppCliente
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnVerRegistros;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnVerRegistros = new Button();
            btnAbout = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.HighlightText;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(47, 36);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(697, 467);
            dataGridView1.TabIndex = 0;
            // 
            // btnVerRegistros
            // 
            btnVerRegistros.Location = new Point(773, 36);
            btnVerRegistros.Margin = new Padding(4, 3, 4, 3);
            btnVerRegistros.Name = "btnVerRegistros";
            btnVerRegistros.Size = new Size(97, 33);
            btnVerRegistros.TabIndex = 1;
            btnVerRegistros.Text = "Ver Registros";
            btnVerRegistros.UseVisualStyleBackColor = true;
            btnVerRegistros.Click += btnVerRegistros_Click;
            // 
            // btnAbout
            // 
            btnAbout.Location = new Point(773, 99);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(97, 33);
            btnAbout.TabIndex = 2;
            btnAbout.Text = "About...";
            btnAbout.UseVisualStyleBackColor = true;
            btnAbout.Click += btnAbout_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(773, 165);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(97, 33);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(924, 538);
            Controls.Add(btnSalir);
            Controls.Add(btnAbout);
            Controls.Add(btnVerRegistros);
            Controls.Add(dataGridView1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Estacion Climatica";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        private Button btnAbout;
        private Button btnSalir;
    }
}
