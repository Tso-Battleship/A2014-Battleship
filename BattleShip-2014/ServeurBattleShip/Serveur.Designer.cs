﻿namespace BattleShip_2014
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
            this.tbX1 = new System.Windows.Forms.TextBox();
            this.tbY1 = new System.Windows.Forms.TextBox();
            this.tbX2 = new System.Windows.Forms.TextBox();
            this.tbY2 = new System.Windows.Forms.TextBox();
            this.lX1 = new System.Windows.Forms.Label();
            this.lY1 = new System.Windows.Forms.Label();
            this.lX2 = new System.Windows.Forms.Label();
            this.lY2 = new System.Windows.Forms.Label();
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
            this.lbReception.Location = new System.Drawing.Point(31, 157);
            this.lbReception.Name = "lbReception";
            this.lbReception.Size = new System.Drawing.Size(348, 160);
            this.lbReception.TabIndex = 2;
            // 
            // lbEnvoie
            // 
            this.lbEnvoie.FormattingEnabled = true;
            this.lbEnvoie.Location = new System.Drawing.Point(31, 333);
            this.lbEnvoie.Name = "lbEnvoie";
            this.lbEnvoie.Size = new System.Drawing.Size(348, 173);
            this.lbEnvoie.TabIndex = 3;
            // 
            // lbReception2
            // 
            this.lbReception2.FormattingEnabled = true;
            this.lbReception2.Location = new System.Drawing.Point(406, 157);
            this.lbReception2.Name = "lbReception2";
            this.lbReception2.Size = new System.Drawing.Size(353, 160);
            this.lbReception2.TabIndex = 4;
            // 
            // lbEnvoie2
            // 
            this.lbEnvoie2.FormattingEnabled = true;
            this.lbEnvoie2.Location = new System.Drawing.Point(406, 333);
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
            this.btDeconnection1.Click += new System.EventHandler(this.btDeconnection1_Click);
            // 
            // btTir1
            // 
            this.btTir1.Location = new System.Drawing.Point(31, 54);
            this.btTir1.Name = "btTir1";
            this.btTir1.Size = new System.Drawing.Size(90, 23);
            this.btTir1.TabIndex = 8;
            this.btTir1.Text = "Tir";
            this.btTir1.UseVisualStyleBackColor = true;
            this.btTir1.Click += new System.EventHandler(this.btTir1_Click);
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
            this.btEnvoiePiece2.Click += new System.EventHandler(this.btEnvoiePiece2_Click);
            // 
            // btTir2
            // 
            this.btTir2.Location = new System.Drawing.Point(406, 54);
            this.btTir2.Name = "btTir2";
            this.btTir2.Size = new System.Drawing.Size(90, 23);
            this.btTir2.TabIndex = 12;
            this.btTir2.Text = "Tir";
            this.btTir2.UseVisualStyleBackColor = true;
            this.btTir2.Click += new System.EventHandler(this.btTir2_Click);
            // 
            // btDeconnection2
            // 
            this.btDeconnection2.Location = new System.Drawing.Point(502, 25);
            this.btDeconnection2.Name = "btDeconnection2";
            this.btDeconnection2.Size = new System.Drawing.Size(100, 23);
            this.btDeconnection2.TabIndex = 11;
            this.btDeconnection2.Text = "deconnection";
            this.btDeconnection2.UseVisualStyleBackColor = true;
            this.btDeconnection2.Click += new System.EventHandler(this.btDeconnection2_Click);
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
            // tbX1
            // 
            this.tbX1.Location = new System.Drawing.Point(46, 108);
            this.tbX1.Name = "tbX1";
            this.tbX1.Size = new System.Drawing.Size(44, 20);
            this.tbX1.TabIndex = 14;
            this.tbX1.Text = "1";
            this.tbX1.TextChanged += new System.EventHandler(this.tbX1_TextChanged);
            // 
            // tbY1
            // 
            this.tbY1.Location = new System.Drawing.Point(146, 108);
            this.tbY1.Name = "tbY1";
            this.tbY1.Size = new System.Drawing.Size(43, 20);
            this.tbY1.TabIndex = 15;
            this.tbY1.Text = "1";
            this.tbY1.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // tbX2
            // 
            this.tbX2.Location = new System.Drawing.Point(424, 108);
            this.tbX2.Name = "tbX2";
            this.tbX2.Size = new System.Drawing.Size(43, 20);
            this.tbX2.TabIndex = 16;
            this.tbX2.Text = "1";
            // 
            // tbY2
            // 
            this.tbY2.Location = new System.Drawing.Point(530, 108);
            this.tbY2.Name = "tbY2";
            this.tbY2.Size = new System.Drawing.Size(44, 20);
            this.tbY2.TabIndex = 17;
            this.tbY2.Text = "1";
            // 
            // lX1
            // 
            this.lX1.AutoSize = true;
            this.lX1.Location = new System.Drawing.Point(61, 89);
            this.lX1.Name = "lX1";
            this.lX1.Size = new System.Drawing.Size(14, 13);
            this.lX1.TabIndex = 18;
            this.lX1.Text = "X";
            this.lX1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lY1
            // 
            this.lY1.AutoSize = true;
            this.lY1.Location = new System.Drawing.Point(161, 89);
            this.lY1.Name = "lY1";
            this.lY1.Size = new System.Drawing.Size(14, 13);
            this.lY1.TabIndex = 19;
            this.lY1.Text = "Y";
            // 
            // lX2
            // 
            this.lX2.AutoSize = true;
            this.lX2.Location = new System.Drawing.Point(437, 89);
            this.lX2.Name = "lX2";
            this.lX2.Size = new System.Drawing.Size(14, 13);
            this.lX2.TabIndex = 20;
            this.lX2.Text = "X";
            // 
            // lY2
            // 
            this.lY2.AutoSize = true;
            this.lY2.Location = new System.Drawing.Point(545, 89);
            this.lY2.Name = "lY2";
            this.lY2.Size = new System.Drawing.Size(14, 13);
            this.lY2.TabIndex = 21;
            this.lY2.Text = "Y";
            // 
            // Serveur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 567);
            this.Controls.Add(this.lY2);
            this.Controls.Add(this.lX2);
            this.Controls.Add(this.lY1);
            this.Controls.Add(this.lX1);
            this.Controls.Add(this.tbY2);
            this.Controls.Add(this.tbX2);
            this.Controls.Add(this.tbY1);
            this.Controls.Add(this.tbX1);
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
        private System.Windows.Forms.TextBox tbX1;
        private System.Windows.Forms.TextBox tbY1;
        private System.Windows.Forms.TextBox tbX2;
        private System.Windows.Forms.TextBox tbY2;
        private System.Windows.Forms.Label lX1;
        private System.Windows.Forms.Label lY1;
        private System.Windows.Forms.Label lX2;
        private System.Windows.Forms.Label lY2;
    }
}

