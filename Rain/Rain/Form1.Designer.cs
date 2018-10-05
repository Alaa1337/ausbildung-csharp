namespace Rain
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.statss = new System.Windows.Forms.Label();
            this.score = new System.Windows.Forms.Label();
            this.easteregg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // statss
            // 
            this.statss.AutoSize = true;
            this.statss.BackColor = System.Drawing.Color.Transparent;
            this.statss.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statss.Location = new System.Drawing.Point(651, 428);
            this.statss.Name = "statss";
            this.statss.Size = new System.Drawing.Size(35, 14);
            this.statss.TabIndex = 1;
            this.statss.Text = "stats";
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.BackColor = System.Drawing.Color.Transparent;
            this.score.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score.Location = new System.Drawing.Point(560, 428);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(39, 14);
            this.score.TabIndex = 1;
            this.score.Text = "score";
            // 
            // easteregg
            // 
            this.easteregg.AutoSize = true;
            this.easteregg.BackColor = System.Drawing.Color.Transparent;
            this.easteregg.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easteregg.Location = new System.Drawing.Point(343, 428);
            this.easteregg.Name = "easteregg";
            this.easteregg.Size = new System.Drawing.Size(0, 14);
            this.easteregg.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(779, 450);
            this.Controls.Add(this.easteregg);
            this.Controls.Add(this.score);
            this.Controls.Add(this.statss);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statss;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label easteregg;
    }
}

