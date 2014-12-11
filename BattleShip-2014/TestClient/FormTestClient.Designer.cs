namespace BattleShip_2014
{
    partial class FormTestClient
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
            this.textBoxRecoi = new System.Windows.Forms.TextBox();
            this.buttonRecoi = new System.Windows.Forms.Button();
            this.buttonEnvoie = new System.Windows.Forms.Button();
            this.textBoxEnvoie = new System.Windows.Forms.TextBox();
            this.connecterServeur_button = new System.Windows.Forms.Button();
            this.tbAddresseIp = new System.Windows.Forms.TextBox();
            this.bDeconnection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxRecoi
            // 
            this.textBoxRecoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxRecoi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxRecoi.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRecoi.Location = new System.Drawing.Point(166, 260);
            this.textBoxRecoi.Name = "textBoxRecoi";
            this.textBoxRecoi.Size = new System.Drawing.Size(210, 23);
            this.textBoxRecoi.TabIndex = 10;
            this.textBoxRecoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonRecoi
            // 
            this.buttonRecoi.Location = new System.Drawing.Point(229, 231);
            this.buttonRecoi.Name = "buttonRecoi";
            this.buttonRecoi.Size = new System.Drawing.Size(75, 23);
            this.buttonRecoi.TabIndex = 9;
            this.buttonRecoi.Text = "recoi";
            this.buttonRecoi.UseVisualStyleBackColor = true;
            this.buttonRecoi.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonEnvoie
            // 
            this.buttonEnvoie.Location = new System.Drawing.Point(229, 142);
            this.buttonEnvoie.Name = "buttonEnvoie";
            this.buttonEnvoie.Size = new System.Drawing.Size(75, 23);
            this.buttonEnvoie.TabIndex = 8;
            this.buttonEnvoie.Text = "envoie";
            this.buttonEnvoie.UseVisualStyleBackColor = true;
            this.buttonEnvoie.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxEnvoie
            // 
            this.textBoxEnvoie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxEnvoie.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEnvoie.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEnvoie.Location = new System.Drawing.Point(166, 171);
            this.textBoxEnvoie.Name = "textBoxEnvoie";
            this.textBoxEnvoie.Size = new System.Drawing.Size(210, 23);
            this.textBoxEnvoie.TabIndex = 7;
            this.textBoxEnvoie.Text = "Texte";
            this.textBoxEnvoie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // connecterServeur_button
            // 
            this.connecterServeur_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.connecterServeur_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connecterServeur_button.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connecterServeur_button.Location = new System.Drawing.Point(166, 52);
            this.connecterServeur_button.Name = "connecterServeur_button";
            this.connecterServeur_button.Size = new System.Drawing.Size(210, 37);
            this.connecterServeur_button.TabIndex = 11;
            this.connecterServeur_button.Text = "Connecter";
            this.connecterServeur_button.UseVisualStyleBackColor = false;
            this.connecterServeur_button.Click += new System.EventHandler(this.connecterServeur_button_Click);
            // 
            // tbAddresseIp
            // 
            this.tbAddresseIp.Location = new System.Drawing.Point(166, 96);
            this.tbAddresseIp.Name = "tbAddresseIp";
            this.tbAddresseIp.Size = new System.Drawing.Size(210, 20);
            this.tbAddresseIp.TabIndex = 12;
            // 
            // bDeconnection
            // 
            this.bDeconnection.Location = new System.Drawing.Point(220, 298);
            this.bDeconnection.Name = "bDeconnection";
            this.bDeconnection.Size = new System.Drawing.Size(90, 23);
            this.bDeconnection.TabIndex = 13;
            this.bDeconnection.Text = "déconnection";
            this.bDeconnection.UseVisualStyleBackColor = true;
            this.bDeconnection.Click += new System.EventHandler(this.bDeconnection_Click);
            // 
            // FormTestClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 425);
            this.Controls.Add(this.bDeconnection);
            this.Controls.Add(this.tbAddresseIp);
            this.Controls.Add(this.connecterServeur_button);
            this.Controls.Add(this.textBoxRecoi);
            this.Controls.Add(this.buttonRecoi);
            this.Controls.Add(this.buttonEnvoie);
            this.Controls.Add(this.textBoxEnvoie);
            this.Name = "FormTestClient";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTestClient_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxRecoi;
        private System.Windows.Forms.Button buttonRecoi;
        private System.Windows.Forms.Button buttonEnvoie;
        private System.Windows.Forms.TextBox textBoxEnvoie;
        private System.Windows.Forms.Button connecterServeur_button;
        private System.Windows.Forms.TextBox tbAddresseIp;
        private System.Windows.Forms.Button bDeconnection;
    }
}

