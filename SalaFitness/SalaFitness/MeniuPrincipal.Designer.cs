
namespace SalaFitness
{
    partial class MeniuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeniuPrincipal));
            this.buttonAbonament = new System.Windows.Forms.Button();
            this.buttonPersoana = new System.Windows.Forms.Button();
            this.buttonSala = new System.Windows.Forms.Button();
            this.buttonCategorie = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAbonament
            // 
            this.buttonAbonament.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAbonament.Location = new System.Drawing.Point(87, 87);
            this.buttonAbonament.Name = "buttonAbonament";
            this.buttonAbonament.Size = new System.Drawing.Size(118, 23);
            this.buttonAbonament.TabIndex = 0;
            this.buttonAbonament.Text = "Abonament";
            this.buttonAbonament.UseVisualStyleBackColor = true;
            this.buttonAbonament.Click += new System.EventHandler(this.buttonAbonament_Click);
            // 
            // buttonPersoana
            // 
            this.buttonPersoana.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPersoana.Location = new System.Drawing.Point(87, 116);
            this.buttonPersoana.Name = "buttonPersoana";
            this.buttonPersoana.Size = new System.Drawing.Size(118, 23);
            this.buttonPersoana.TabIndex = 1;
            this.buttonPersoana.Text = "Persoana";
            this.buttonPersoana.UseVisualStyleBackColor = true;
            this.buttonPersoana.Click += new System.EventHandler(this.buttonPersoana_Click);
            // 
            // buttonSala
            // 
            this.buttonSala.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSala.Location = new System.Drawing.Point(87, 145);
            this.buttonSala.Name = "buttonSala";
            this.buttonSala.Size = new System.Drawing.Size(118, 23);
            this.buttonSala.TabIndex = 2;
            this.buttonSala.Text = "Sala";
            this.buttonSala.UseVisualStyleBackColor = true;
            this.buttonSala.Click += new System.EventHandler(this.buttonSala_Click);
            // 
            // buttonCategorie
            // 
            this.buttonCategorie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCategorie.Location = new System.Drawing.Point(87, 174);
            this.buttonCategorie.Name = "buttonCategorie";
            this.buttonCategorie.Size = new System.Drawing.Size(118, 23);
            this.buttonCategorie.TabIndex = 3;
            this.buttonCategorie.Text = "Categorie";
            this.buttonCategorie.UseVisualStyleBackColor = true;
            this.buttonCategorie.Click += new System.EventHandler(this.buttonCategorie_Click);
            // 
            // MeniuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(311, 300);
            this.Controls.Add(this.buttonCategorie);
            this.Controls.Add(this.buttonSala);
            this.Controls.Add(this.buttonPersoana);
            this.Controls.Add(this.buttonAbonament);
            this.Name = "MeniuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MeniuPrincipal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAbonament;
        private System.Windows.Forms.Button buttonPersoana;
        private System.Windows.Forms.Button buttonSala;
        private System.Windows.Forms.Button buttonCategorie;
    }
}