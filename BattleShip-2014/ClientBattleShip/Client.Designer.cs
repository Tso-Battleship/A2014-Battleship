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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.main_panel = new System.Windows.Forms.Panel();
            this.place_panel = new System.Windows.Forms.Panel();
            this.patrolBoat_button = new System.Windows.Forms.Button();
            this.destroyer_button = new System.Windows.Forms.Button();
            this.submarine_button = new System.Windows.Forms.Button();
            this.battleship_button = new System.Windows.Forms.Button();
            this.aircraftCarrier_button = new System.Windows.Forms.Button();
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
            this.connect_panel.Controls.Add(this.textBox2);
            this.connect_panel.Controls.Add(this.textBox1);
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
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(169, 108);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(210, 23);
            this.textBox2.TabIndex = 1;
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
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.place_panel.Controls.Add(this.patrolBoat_button);
            this.place_panel.Controls.Add(this.destroyer_button);
            this.place_panel.Controls.Add(this.submarine_button);
            this.place_panel.Controls.Add(this.battleship_button);
            this.place_panel.Controls.Add(this.aircraftCarrier_button);
            this.place_panel.Location = new System.Drawing.Point(4, 3);
            this.place_panel.Name = "place_panel";
            this.place_panel.Size = new System.Drawing.Size(609, 215);
            this.place_panel.TabIndex = 7;
            this.place_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormClick);
            // 
            // patrolBoat_button
            // 
            this.patrolBoat_button.FlatAppearance.BorderSize = 0;
            this.patrolBoat_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.patrolBoat_button.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patrolBoat_button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.patrolBoat_button.Location = new System.Drawing.Point(18, 167);
            this.patrolBoat_button.Name = "patrolBoat_button";
            this.patrolBoat_button.Size = new System.Drawing.Size(178, 32);
            this.patrolBoat_button.TabIndex = 15;
            this.patrolBoat_button.Tag = "4";
            this.patrolBoat_button.Text = "Patrol boat [2]";
            this.patrolBoat_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.patrolBoat_button.UseVisualStyleBackColor = true;
            this.patrolBoat_button.Click += new System.EventHandler(this.place_ship_buttons);
            // 
            // destroyer_button
            // 
            this.destroyer_button.FlatAppearance.BorderSize = 0;
            this.destroyer_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.destroyer_button.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destroyer_button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.destroyer_button.Location = new System.Drawing.Point(18, 129);
            this.destroyer_button.Name = "destroyer_button";
            this.destroyer_button.Size = new System.Drawing.Size(178, 32);
            this.destroyer_button.TabIndex = 14;
            this.destroyer_button.Tag = "3";
            this.destroyer_button.Text = "Destroyer [3]";
            this.destroyer_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.destroyer_button.UseVisualStyleBackColor = true;
            this.destroyer_button.Click += new System.EventHandler(this.place_ship_buttons);
            // 
            // submarine_button
            // 
            this.submarine_button.FlatAppearance.BorderSize = 0;
            this.submarine_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submarine_button.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submarine_button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.submarine_button.Location = new System.Drawing.Point(18, 91);
            this.submarine_button.Name = "submarine_button";
            this.submarine_button.Size = new System.Drawing.Size(178, 32);
            this.submarine_button.TabIndex = 13;
            this.submarine_button.Tag = "2";
            this.submarine_button.Text = "Submarine [3]";
            this.submarine_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submarine_button.UseVisualStyleBackColor = true;
            this.submarine_button.Click += new System.EventHandler(this.place_ship_buttons);
            // 
            // battleship_button
            // 
            this.battleship_button.FlatAppearance.BorderSize = 0;
            this.battleship_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.battleship_button.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.battleship_button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.battleship_button.Location = new System.Drawing.Point(18, 53);
            this.battleship_button.Name = "battleship_button";
            this.battleship_button.Size = new System.Drawing.Size(178, 32);
            this.battleship_button.TabIndex = 12;
            this.battleship_button.Tag = "1";
            this.battleship_button.Text = "Battleship [4]";
            this.battleship_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.battleship_button.UseVisualStyleBackColor = true;
            this.battleship_button.Click += new System.EventHandler(this.place_ship_buttons);
            // 
            // aircraftCarrier_button
            // 
            this.aircraftCarrier_button.FlatAppearance.BorderSize = 0;
            this.aircraftCarrier_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aircraftCarrier_button.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aircraftCarrier_button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.aircraftCarrier_button.Location = new System.Drawing.Point(18, 15);
            this.aircraftCarrier_button.Name = "aircraftCarrier_button";
            this.aircraftCarrier_button.Size = new System.Drawing.Size(178, 32);
            this.aircraftCarrier_button.TabIndex = 11;
            this.aircraftCarrier_button.Tag = "0";
            this.aircraftCarrier_button.Text = "Aircraft carrier [5]";
            this.aircraftCarrier_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aircraftCarrier_button.UseVisualStyleBackColor = true;
            this.aircraftCarrier_button.Click += new System.EventHandler(this.place_ship_buttons);
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
            this.p2_board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormClick);
            // 
            // info_panel
            // 
            this.info_panel.Controls.Add(this.label1);
            this.info_panel.Controls.Add(this.label2);
            this.info_panel.Controls.Add(this.label3);
            this.info_panel.Location = new System.Drawing.Point(618, 3);
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
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
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
        private System.Windows.Forms.Button patrolBoat_button;
        private System.Windows.Forms.Button destroyer_button;
        private System.Windows.Forms.Button submarine_button;
        private System.Windows.Forms.Button battleship_button;
        private System.Windows.Forms.Button aircraftCarrier_button;
    }
}

