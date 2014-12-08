namespace BattleShip_2014
{
    partial class Serveur
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
            this.lJoueur1 = new System.Windows.Forms.Label();
            this.lJoueur2 = new System.Windows.Forms.Label();
            this.lbReception = new System.Windows.Forms.ListBox();
            this.lbEnvoie = new System.Windows.Forms.ListBox();
            this.lbReception2 = new System.Windows.Forms.ListBox();
            this.lbEnvoie2 = new System.Windows.Forms.ListBox();
            this.btConnection1 = new System.Windows.Forms.Button();
            this.btDeconnection1 = new System.Windows.Forms.Button();
            this.btTir1 = new System.Windows.Forms.Button();
            this.btEnvoiePiece1 = new System.Windows.Forms.Button();
            this.btEnvoiePiece2 = new System.Windows.Forms.Button();
            this.btTir2 = new System.Windows.Forms.Button();
            this.btDeconnection2 = new System.Windows.Forms.Button();
            this.btConnection2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lJoueur1
            // 
            this.lJoueur1.AutoSize = true;
            this.lJoueur1.Location = new System.Drawing.Point(28, 9);
            this.lJoueur1.Name = "lJoueur1";
            this.lJoueur1.Size = new System.Drawing.Size(126, 13);
            this.lJoueur1.TabIndex = 0;
            this.lJoueur1.Text = "Joueur 1 : non connecter";
            // 
            // lJoueur2
            // 
            this.lJoueur2.AutoSize = true;
            this.lJoueur2.Location = new System.Drawing.Point(403, 9);
            this.lJoueur2.Name = "lJoueur2";
            this.lJoueur2.Size = new System.Drawing.Size(126, 13);
            this.lJoueur2.TabIndex = 1;
            this.lJoueur2.Text = "Joueur 2 : non connecter";
            // 
            // lbReception
            // 
            this.lbReception.FormattingEnabled = true;
            this.lbReception.Location = new System.Drawing.Point(31, 79);
            this.lbReception.Name = "lbReception";
            this.lbReception.Size = new System.Drawing.Size(348, 160);
            this.lbReception.TabIndex = 2;
            // 
            // lbEnvoie
            // 
            this.lbEnvoie.FormattingEnabled = true;
            this.lbEnvoie.Location = new System.Drawing.Point(31, 245);
            this.lbEnvoie.Name = "lbEnvoie";
            this.lbEnvoie.Size = new System.Drawing.Size(348, 173);
            this.lbEnvoie.TabIndex = 3;
            // 
            // lbReception2
            // 
            this.lbReception2.FormattingEnabled = true;
            this.lbReception2.Location = new System.Drawing.Point(406, 79);
            this.lbReception2.Name = "lbReception2";
            this.lbReception2.Size = new System.Drawing.Size(353, 160);
            this.lbReception2.TabIndex = 4;
            // 
            // lbEnvoie2
            // 
            this.lbEnvoie2.FormattingEnabled = true;
            this.lbEnvoie2.Location = new System.Drawing.Point(406, 245);
            this.lbEnvoie2.Name = "lbEnvoie2";
            this.lbEnvoie2.Size = new System.Drawing.Size(353, 173);
            this.lbEnvoie2.TabIndex = 5;
            // 
            // btConnection1
            // 
            this.btConnection1.Location = new System.Drawing.Point(31, 25);
            this.btConnection1.Name = "btConnection1";
            this.btConnection1.Size = new System.Drawing.Size(90, 23);
            this.btConnection1.TabIndex = 6;
            this.btConnection1.Text = "Connection";
            this.btConnection1.UseVisualStyleBackColor = true;
            this.btConnection1.Click += new System.EventHandler(this.btConnection1_Click);
            // 
            // btDeconnection1
            // 
            this.btDeconnection1.Location = new System.Drawing.Point(127, 25);
            this.btDeconnection1.Name = "btDeconnection1";
            this.btDeconnection1.Size = new System.Drawing.Size(100, 23);
            this.btDeconnection1.TabIndex = 7;
            this.btDeconnection1.Text = "deconnection";
            this.btDeconnection1.UseVisualStyleBackColor = true;
            // 
            // btTir1
            // 
            this.btTir1.Location = new System.Drawing.Point(31, 54);
            this.btTir1.Name = "btTir1";
            this.btTir1.Size = new System.Drawing.Size(90, 23);
            this.btTir1.TabIndex = 8;
            this.btTir1.Text = "Tir";
            this.btTir1.UseVisualStyleBackColor = true;
            // 
            // btEnvoiePiece1
            // 
            this.btEnvoiePiece1.Location = new System.Drawing.Point(127, 54);
            this.btEnvoiePiece1.Name = "btEnvoiePiece1";
            this.btEnvoiePiece1.Size = new System.Drawing.Size(100, 23);
            this.btEnvoiePiece1.TabIndex = 9;
            this.btEnvoiePiece1.Text = "Envoie Piece";
            this.btEnvoiePiece1.UseVisualStyleBackColor = true;
            this.btEnvoiePiece1.Click += new System.EventHandler(this.btEnvoiePiece1_Click);
            // 
            // btEnvoiePiece2
            // 
            this.btEnvoiePiece2.Location = new System.Drawing.Point(502, 54);
            this.btEnvoiePiece2.Name = "btEnvoiePiece2";
            this.btEnvoiePiece2.Size = new System.Drawing.Size(100, 23);
            this.btEnvoiePiece2.TabIndex = 13;
            this.btEnvoiePiece2.Text = "Envoie Piece";
            this.btEnvoiePiece2.UseVisualStyleBackColor = true;
            // 
            // btTir2
            // 
            this.btTir2.Location = new System.Drawing.Point(406, 54);
            this.btTir2.Name = "btTir2";
            this.btTir2.Size = new System.Drawing.Size(90, 23);
            this.btTir2.TabIndex = 12;
            this.btTir2.Text = "Tir";
            this.btTir2.UseVisualStyleBackColor = true;
            // 
            // btDeconnection2
            // 
            this.btDeconnection2.Location = new System.Drawing.Point(502, 25);
            this.btDeconnection2.Name = "btDeconnection2";
            this.btDeconnection2.Size = new System.Drawing.Size(100, 23);
            this.btDeconnection2.TabIndex = 11;
            this.btDeconnection2.Text = "deconnection";
            this.btDeconnection2.UseVisualStyleBackColor = true;
            // 
            // btConnection2
            // 
            this.btConnection2.Location = new System.Drawing.Point(406, 25);
            this.btConnection2.Name = "btConnection2";
            this.btConnection2.Size = new System.Drawing.Size(90, 23);
            this.btConnection2.TabIndex = 10;
            this.btConnection2.Text = "Connection";
            this.btConnection2.UseVisualStyleBackColor = true;
            this.btConnection2.Click += new System.EventHandler(this.btConnection2_Click);
            // 
            // Serveur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 567);
            this.Controls.Add(this.btEnvoiePiece2);
            this.Controls.Add(this.btTir2);
            this.Controls.Add(this.btDeconnection2);
            this.Controls.Add(this.btConnection2);
            this.Controls.Add(this.btEnvoiePiece1);
            this.Controls.Add(this.btTir1);
            this.Controls.Add(this.btDeconnection1);
            this.Controls.Add(this.btConnection1);
            this.Controls.Add(this.lbEnvoie2);
            this.Controls.Add(this.lbReception2);
            this.Controls.Add(this.lbEnvoie);
            this.Controls.Add(this.lbReception);
            this.Controls.Add(this.lJoueur2);
            this.Controls.Add(this.lJoueur1);
            this.Name = "Serveur";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lJoueur1;
        private System.Windows.Forms.Label lJoueur2;
        private System.Windows.Forms.ListBox lbReception;
        private System.Windows.Forms.ListBox lbEnvoie;
        private System.Windows.Forms.ListBox lbReception2;
        private System.Windows.Forms.ListBox lbEnvoie2;
        private System.Windows.Forms.Button btConnection1;
        private System.Windows.Forms.Button btDeconnection1;
        private System.Windows.Forms.Button btTir1;
        private System.Windows.Forms.Button btEnvoiePiece1;
        private System.Windows.Forms.Button btEnvoiePiece2;
        private System.Windows.Forms.Button btTir2;
        private System.Windows.Forms.Button btDeconnection2;
        private System.Windows.Forms.Button btConnection2;
    }
}

