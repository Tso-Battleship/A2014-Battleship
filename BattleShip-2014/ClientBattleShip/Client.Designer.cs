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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.connect_panel = new System.Windows.Forms.Panel();
            this.titreBattleship_label = new System.Windows.Forms.Label();
            this.connecterServeur_button = new System.Windows.Forms.Button();
            this.adresseServeur_label = new System.Windows.Forms.Label();
            this.nomJoueur_Label = new System.Windows.Forms.Label();
            this.adresseIP_TB = new System.Windows.Forms.TextBox();
            this.nomJoueur_TB = new System.Windows.Forms.TextBox();
            this.main_panel = new System.Windows.Forms.Panel();
            this.place_panel = new System.Windows.Forms.Panel();
            this.piece5_button = new System.Windows.Forms.Button();
            this.piece4_button = new System.Windows.Forms.Button();
            this.piece3_button = new System.Windows.Forms.Button();
            this.piece2_button = new System.Windows.Forms.Button();
            this.piece1_button = new System.Windows.Forms.Button();
            this.p2_board = new System.Windows.Forms.PictureBox();
            this.info_panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.p1_board = new System.Windows.Forms.PictureBox();
            this.minimize_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.connect_panel.SuspendLayout();
            this.main_panel.SuspendLayout();
            this.place_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p2_board)).BeginInit();
            this.info_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p1_board)).BeginInit();
            this.SuspendLayout();
            // 
            // connect_panel
            // 
            this.connect_panel.Controls.Add(this.titreBattleship_label);
            this.connect_panel.Controls.Add(this.connecterServeur_button);
            this.connect_panel.Controls.Add(this.adresseServeur_label);
            this.connect_panel.Controls.Add(this.nomJoueur_Label);
            this.connect_panel.Controls.Add(this.adresseIP_TB);
            this.connect_panel.Controls.Add(this.nomJoueur_TB);
            this.connect_panel.Location = new System.Drawing.Point(618, 3);
            this.connect_panel.Name = "connect_panel";
            this.connect_panel.Size = new System.Drawing.Size(398, 215);
            this.connect_panel.TabIndex = 0;
            // 
            // titreBattleship_label
            // 
            this.titreBattleship_label.AutoSize = true;
            this.titreBattleship_label.Font = new System.Drawing.Font("Trebuchet MS", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titreBattleship_label.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.titreBattleship_label.Location = new System.Drawing.Point(26, 9);
            this.titreBattleship_label.Name = "titreBattleship_label";
            this.titreBattleship_label.Size = new System.Drawing.Size(353, 46);
            this.titreBattleship_label.TabIndex = 5;
            this.titreBattleship_label.Text = "BattleShip TSO 2014";
            // 
            // connecterServeur_button
            // 
            this.connecterServeur_button.BackColor = System.Drawing.Color.SlateGray;
            this.connecterServeur_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.connecterServeur_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connecterServeur_button.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connecterServeur_button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.connecterServeur_button.Location = new System.Drawing.Point(96, 152);
            this.connecterServeur_button.Name = "connecterServeur_button";
            this.connecterServeur_button.Size = new System.Drawing.Size(210, 37);
            this.connecterServeur_button.TabIndex = 4;
            this.connecterServeur_button.Text = "Connecter";
            this.connecterServeur_button.UseVisualStyleBackColor = false;
            this.connecterServeur_button.Click += new System.EventHandler(this.connecterServeur_button_Click);
            // 
            // adresseServeur_label
            // 
            this.adresseServeur_label.AutoSize = true;
            this.adresseServeur_label.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adresseServeur_label.ForeColor = System.Drawing.Color.WhiteSmoke;
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
            this.nomJoueur_Label.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.nomJoueur_Label.Location = new System.Drawing.Point(1, 79);
            this.nomJoueur_Label.Name = "nomJoueur_Label";
            this.nomJoueur_Label.Size = new System.Drawing.Size(110, 24);
            this.nomJoueur_Label.TabIndex = 2;
            this.nomJoueur_Label.Text = "Nom Joueur";
            // 
            // adresseIP_TB
            // 
            this.adresseIP_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.adresseIP_TB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.adresseIP_TB.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adresseIP_TB.Location = new System.Drawing.Point(169, 108);
            this.adresseIP_TB.Name = "adresseIP_TB";
            this.adresseIP_TB.Size = new System.Drawing.Size(210, 23);
            this.adresseIP_TB.TabIndex = 1;
            this.adresseIP_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nomJoueur_TB
            // 
            this.nomJoueur_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nomJoueur_TB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nomJoueur_TB.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomJoueur_TB.Location = new System.Drawing.Point(169, 79);
            this.nomJoueur_TB.Name = "nomJoueur_TB";
            this.nomJoueur_TB.Size = new System.Drawing.Size(210, 23);
            this.nomJoueur_TB.TabIndex = 0;
            this.nomJoueur_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // main_panel
            // 
            this.main_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.main_panel.Controls.Add(this.place_panel);
            this.main_panel.Controls.Add(this.p2_board);
            this.main_panel.Controls.Add(this.info_panel);
            this.main_panel.Controls.Add(this.p1_board);
            this.main_panel.Controls.Add(this.connect_panel);
            this.main_panel.Location = new System.Drawing.Point(11, 47);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(1022, 732);
            this.main_panel.TabIndex = 3;
            this.main_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormClick);
            // 
            // place_panel
            // 
            this.place_panel.Controls.Add(this.piece5_button);
            this.place_panel.Controls.Add(this.piece4_button);
            this.place_panel.Controls.Add(this.piece3_button);
            this.place_panel.Controls.Add(this.piece2_button);
            this.place_panel.Controls.Add(this.piece1_button);
            this.place_panel.Location = new System.Drawing.Point(4, 3);
            this.place_panel.Name = "place_panel";
            this.place_panel.Size = new System.Drawing.Size(609, 215);
            this.place_panel.TabIndex = 7;
            this.place_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormClick);
            // 
            // piece5_button
            // 
            this.piece5_button.FlatAppearance.BorderSize = 0;
            this.piece5_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.piece5_button.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.piece5_button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.piece5_button.Location = new System.Drawing.Point(18, 167);
            this.piece5_button.Name = "piece5_button";
            this.piece5_button.Size = new System.Drawing.Size(178, 32);
            this.piece5_button.TabIndex = 15;
            this.piece5_button.Tag = "4";
            this.piece5_button.Text = "Patrol boat [2]";
            this.piece5_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.piece5_button.UseVisualStyleBackColor = true;
            this.piece5_button.Click += new System.EventHandler(this.place_ship_buttons);
            // 
            // piece4_button
            // 
            this.piece4_button.FlatAppearance.BorderSize = 0;
            this.piece4_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.piece4_button.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.piece4_button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.piece4_button.Location = new System.Drawing.Point(18, 129);
            this.piece4_button.Name = "piece4_button";
            this.piece4_button.Size = new System.Drawing.Size(178, 32);
            this.piece4_button.TabIndex = 14;
            this.piece4_button.Tag = "3";
            this.piece4_button.Text = "Destroyer [3]";
            this.piece4_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.piece4_button.UseVisualStyleBackColor = true;
            this.piece4_button.Click += new System.EventHandler(this.place_ship_buttons);
            // 
            // piece3_button
            // 
            this.piece3_button.FlatAppearance.BorderSize = 0;
            this.piece3_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.piece3_button.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.piece3_button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.piece3_button.Location = new System.Drawing.Point(18, 91);
            this.piece3_button.Name = "piece3_button";
            this.piece3_button.Size = new System.Drawing.Size(178, 32);
            this.piece3_button.TabIndex = 13;
            this.piece3_button.Tag = "2";
            this.piece3_button.Text = "Submarine [3]";
            this.piece3_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.piece3_button.UseVisualStyleBackColor = true;
            this.piece3_button.Click += new System.EventHandler(this.place_ship_buttons);
            // 
            // piece2_button
            // 
            this.piece2_button.FlatAppearance.BorderSize = 0;
            this.piece2_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.piece2_button.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.piece2_button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.piece2_button.Location = new System.Drawing.Point(18, 53);
            this.piece2_button.Name = "piece2_button";
            this.piece2_button.Size = new System.Drawing.Size(178, 32);
            this.piece2_button.TabIndex = 12;
            this.piece2_button.Tag = "1";
            this.piece2_button.Text = "Battleship [4]";
            this.piece2_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.piece2_button.UseVisualStyleBackColor = true;
            this.piece2_button.Click += new System.EventHandler(this.place_ship_buttons);
            // 
            // piece1_button
            // 
            this.piece1_button.FlatAppearance.BorderSize = 0;
            this.piece1_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.piece1_button.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.piece1_button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.piece1_button.Location = new System.Drawing.Point(18, 15);
            this.piece1_button.Name = "piece1_button";
            this.piece1_button.Size = new System.Drawing.Size(178, 32);
            this.piece1_button.TabIndex = 11;
            this.piece1_button.Tag = "0";
            this.piece1_button.Text = "Aircraft carrier [5]";
            this.piece1_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.piece1_button.UseVisualStyleBackColor = true;
            this.piece1_button.Click += new System.EventHandler(this.place_ship_buttons);
            // 
            // p2_board
            // 
            this.p2_board.ErrorImage = null;
            this.p2_board.Image = ((System.Drawing.Image)(resources.GetObject("p2_board.Image")));
            this.p2_board.InitialImage = null;
            this.p2_board.Location = new System.Drawing.Point(512, 229);
            this.p2_board.Name = "p2_board";
            this.p2_board.Size = new System.Drawing.Size(504, 504);
            this.p2_board.TabIndex = 7;
            this.p2_board.TabStop = false;
            this.p2_board.Paint += new System.Windows.Forms.PaintEventHandler(this.p2_board_Paint);
            this.p2_board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormClick);
            // 
            // info_panel
            // 
            this.info_panel.Controls.Add(this.label1);
            this.info_panel.Controls.Add(this.label2);
            this.info_panel.Controls.Add(this.label3);
            this.info_panel.Location = new System.Drawing.Point(615, 3);
            this.info_panel.Name = "info_panel";
            this.info_panel.Size = new System.Drawing.Size(398, 215);
            this.info_panel.TabIndex = 6;
            this.info_panel.Visible = false;
            this.info_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(30, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Player 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(30, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Player 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(30, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Connecté: 127.0.0.1";
            // 
            // p1_board
            // 
            this.p1_board.ErrorImage = null;
            this.p1_board.Image = ((System.Drawing.Image)(resources.GetObject("p1_board.Image")));
            this.p1_board.InitialImage = null;
            this.p1_board.Location = new System.Drawing.Point(4, 229);
            this.p1_board.Name = "p1_board";
            this.p1_board.Size = new System.Drawing.Size(504, 504);
            this.p1_board.TabIndex = 1;
            this.p1_board.TabStop = false;
            this.p1_board.Paint += new System.Windows.Forms.PaintEventHandler(this.p1_board_Paint);
            this.p1_board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormClick);
            // 
            // minimize_button
            // 
            this.minimize_button.BackColor = System.Drawing.Color.SlateGray;
            this.minimize_button.FlatAppearance.BorderSize = 0;
            this.minimize_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize_button.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimize_button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.minimize_button.Location = new System.Drawing.Point(948, 12);
            this.minimize_button.Name = "minimize_button";
            this.minimize_button.Size = new System.Drawing.Size(38, 29);
            this.minimize_button.TabIndex = 2;
            this.minimize_button.Text = "_";
            this.minimize_button.UseVisualStyleBackColor = false;
            this.minimize_button.Click += new System.EventHandler(this.minimize_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.BackColor = System.Drawing.Color.SlateGray;
            this.exit_button.FlatAppearance.BorderSize = 0;
            this.exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_button.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.exit_button.Location = new System.Drawing.Point(992, 12);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(38, 29);
            this.exit_button.TabIndex = 4;
            this.exit_button.Text = "X";
            this.exit_button.UseVisualStyleBackColor = false;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1043, 791);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.main_panel);
            this.Controls.Add(this.minimize_button);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battleship TSO 2014 - Client";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Activated += new System.EventHandler(this.Client_Activated);
            this.Load += new System.EventHandler(this.Client_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormClick);
            this.connect_panel.ResumeLayout(false);
            this.connect_panel.PerformLayout();
            this.main_panel.ResumeLayout(false);
            this.place_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p2_board)).EndInit();
            this.info_panel.ResumeLayout(false);
            this.info_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p1_board)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel connect_panel;
        private System.Windows.Forms.TextBox adresseIP_TB;
        private System.Windows.Forms.TextBox nomJoueur_TB;
        private System.Windows.Forms.Label titreBattleship_label;
        private System.Windows.Forms.Button connecterServeur_button;
        private System.Windows.Forms.Label adresseServeur_label;
        private System.Windows.Forms.Label nomJoueur_Label;
        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.Button minimize_button;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.PictureBox p1_board;
        private System.Windows.Forms.Panel info_panel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox p2_board;
        private System.Windows.Forms.Panel place_panel;
        private System.Windows.Forms.Button piece5_button;
        private System.Windows.Forms.Button piece4_button;
        private System.Windows.Forms.Button piece3_button;
        private System.Windows.Forms.Button piece2_button;
        private System.Windows.Forms.Button piece1_button;
    }
}

