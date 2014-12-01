namespace BattleShip_2014
{
    partial class Client
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.titreBattleship_label = new System.Windows.Forms.Label();
            this.connecterServeur_button = new System.Windows.Forms.Button();
            this.adresseServeur_label = new System.Windows.Forms.Label();
            this.nomJoueur_Label = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.minimize_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.titreBattleship_label);
            this.panel1.Controls.Add(this.connecterServeur_button);
            this.panel1.Controls.Add(this.adresseServeur_label);
            this.panel1.Controls.Add(this.nomJoueur_Label);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(282, 208);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 204);
            this.panel1.TabIndex = 0;
            // 
            // titreBattleship_label
            // 
            this.titreBattleship_label.AutoSize = true;
            this.titreBattleship_label.Font = new System.Drawing.Font("Trebuchet MS", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titreBattleship_label.Location = new System.Drawing.Point(26, 9);
            this.titreBattleship_label.Name = "titreBattleship_label";
            this.titreBattleship_label.Size = new System.Drawing.Size(353, 46);
            this.titreBattleship_label.TabIndex = 5;
            this.titreBattleship_label.Text = "BattleShip TSO 2014";
            // 
            // connecterServeur_button
            // 
            this.connecterServeur_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.connecterServeur_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connecterServeur_button.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connecterServeur_button.Location = new System.Drawing.Point(96, 152);
            this.connecterServeur_button.Name = "connecterServeur_button";
            this.connecterServeur_button.Size = new System.Drawing.Size(210, 37);
            this.connecterServeur_button.TabIndex = 4;
            this.connecterServeur_button.Text = "Connecter";
            this.connecterServeur_button.UseVisualStyleBackColor = false;
            // 
            // adresseServeur_label
            // 
            this.adresseServeur_label.AutoSize = true;
            this.adresseServeur_label.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adresseServeur_label.Location = new System.Drawing.Point(1, 103);
            this.adresseServeur_label.Name = "adresseServeur_label";
            this.adresseServeur_label.Size = new System.Drawing.Size(142, 24);
            this.adresseServeur_label.TabIndex = 3;
            this.adresseServeur_label.Text = "Adresse serveur";
            // 
            // nomJoueur_Label
            // 
            this.nomJoueur_Label.AutoSize = true;
            this.nomJoueur_Label.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomJoueur_Label.Location = new System.Drawing.Point(1, 79);
            this.nomJoueur_Label.Name = "nomJoueur_Label";
            this.nomJoueur_Label.Size = new System.Drawing.Size(110, 24);
            this.nomJoueur_Label.TabIndex = 2;
            this.nomJoueur_Label.Text = "Nom Joueur";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(169, 108);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(210, 23);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "127.0.0.1";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(169, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Votre Nom";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(8, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1022, 732);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // minimize_button
            // 
            this.minimize_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize_button.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimize_button.Location = new System.Drawing.Point(948, 12);
            this.minimize_button.Name = "minimize_button";
            this.minimize_button.Size = new System.Drawing.Size(38, 29);
            this.minimize_button.TabIndex = 2;
            this.minimize_button.Text = "_";
            this.minimize_button.UseVisualStyleBackColor = true;
            // 
            // exit_button
            // 
            this.exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_button.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_button.Location = new System.Drawing.Point(992, 12);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(38, 29);
            this.exit_button.TabIndex = 4;
            this.exit_button.Text = "X";
            this.exit_button.UseVisualStyleBackColor = true;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1043, 791);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.minimize_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Client";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label titreBattleship_label;
        private System.Windows.Forms.Button connecterServeur_button;
        private System.Windows.Forms.Label adresseServeur_label;
        private System.Windows.Forms.Label nomJoueur_Label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button minimize_button;
        private System.Windows.Forms.Button exit_button;
    }
}

