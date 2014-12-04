namespace BattleShip_2014
{
    partial class FormServeur
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbReception = new System.Windows.Forms.TextBox();
            this.bReception = new System.Windows.Forms.Button();
            this.bEnvoie = new System.Windows.Forms.Button();
            this.tbEnvoie = new System.Windows.Forms.TextBox();
            this.bNumClient = new System.Windows.Forms.Button();
            this.tbNumClient = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbReception
            // 
            this.tbReception.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbReception.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbReception.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbReception.Location = new System.Drawing.Point(22, 145);
            this.tbReception.Name = "tbReception";
            this.tbReception.Size = new System.Drawing.Size(210, 23);
            this.tbReception.TabIndex = 15;
            this.tbReception.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bReception
            // 
            this.bReception.Location = new System.Drawing.Point(85, 116);
            this.bReception.Name = "bReception";
            this.bReception.Size = new System.Drawing.Size(75, 23);
            this.bReception.TabIndex = 14;
            this.bReception.Text = "recoi";
            this.bReception.UseVisualStyleBackColor = true;
            this.bReception.Click += new System.EventHandler(this.bReception_Click);
            // 
            // bEnvoie
            // 
            this.bEnvoie.Location = new System.Drawing.Point(85, 27);
            this.bEnvoie.Name = "bEnvoie";
            this.bEnvoie.Size = new System.Drawing.Size(75, 23);
            this.bEnvoie.TabIndex = 13;
            this.bEnvoie.Text = "envoie";
            this.bEnvoie.UseVisualStyleBackColor = true;
            this.bEnvoie.Click += new System.EventHandler(this.bEnvoie_Click);
            // 
            // tbEnvoie
            // 
            this.tbEnvoie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbEnvoie.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbEnvoie.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEnvoie.Location = new System.Drawing.Point(22, 56);
            this.tbEnvoie.Name = "tbEnvoie";
            this.tbEnvoie.Size = new System.Drawing.Size(210, 23);
            this.tbEnvoie.TabIndex = 12;
            this.tbEnvoie.Text = "Texte";
            this.tbEnvoie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bNumClient
            // 
            this.bNumClient.Location = new System.Drawing.Point(85, 184);
            this.bNumClient.Name = "bNumClient";
            this.bNumClient.Size = new System.Drawing.Size(75, 23);
            this.bNumClient.TabIndex = 17;
            this.bNumClient.Text = "n. client";
            this.bNumClient.UseVisualStyleBackColor = true;
            this.bNumClient.Click += new System.EventHandler(this.bNumClient_Click);
            // 
            // tbNumClient
            // 
            this.tbNumClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbNumClient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNumClient.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumClient.Location = new System.Drawing.Point(22, 222);
            this.tbNumClient.Name = "tbNumClient";
            this.tbNumClient.Size = new System.Drawing.Size(210, 23);
            this.tbNumClient.TabIndex = 18;
            this.tbNumClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormServeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 324);
            this.Controls.Add(this.tbNumClient);
            this.Controls.Add(this.bNumClient);
            this.Controls.Add(this.tbReception);
            this.Controls.Add(this.bReception);
            this.Controls.Add(this.bEnvoie);
            this.Controls.Add(this.tbEnvoie);
            this.Name = "FormServeur";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbReception;
        private System.Windows.Forms.Button bReception;
        private System.Windows.Forms.Button bEnvoie;
        private System.Windows.Forms.TextBox tbEnvoie;
        private System.Windows.Forms.Button bNumClient;
        private System.Windows.Forms.TextBox tbNumClient;
    }
}

