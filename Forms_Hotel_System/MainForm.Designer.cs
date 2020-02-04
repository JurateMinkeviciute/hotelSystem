namespace Forms_Hotel_System
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.manageClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRoomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageReservationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnManageClients = new System.Windows.Forms.Button();
            this.btnManageRooms = new System.Windows.Forms.Button();
            this.btnManageReverv = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageClientsToolStripMenuItem,
            this.manageRoomsToolStripMenuItem,
            this.manageReservationsToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(932, 28);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // manageClientsToolStripMenuItem
            // 
            this.manageClientsToolStripMenuItem.Name = "manageClientsToolStripMenuItem";
            this.manageClientsToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.manageClientsToolStripMenuItem.Text = "Manage Clients";
            this.manageClientsToolStripMenuItem.Click += new System.EventHandler(this.manageClientsToolStripMenuItem_Click);
            // 
            // manageRoomsToolStripMenuItem
            // 
            this.manageRoomsToolStripMenuItem.Name = "manageRoomsToolStripMenuItem";
            this.manageRoomsToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.manageRoomsToolStripMenuItem.Text = "Manage Rooms";
            this.manageRoomsToolStripMenuItem.Click += new System.EventHandler(this.manageRoomsToolStripMenuItem_Click);
            // 
            // manageReservationsToolStripMenuItem
            // 
            this.manageReservationsToolStripMenuItem.Name = "manageReservationsToolStripMenuItem";
            this.manageReservationsToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.manageReservationsToolStripMenuItem.Text = "Manage Reservations";
            this.manageReservationsToolStripMenuItem.Click += new System.EventHandler(this.manageReservationsToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(929, 66);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(274, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hotel Control Pannel";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnManageClients
            // 
            this.btnManageClients.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnManageClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btnManageClients.Location = new System.Drawing.Point(54, 127);
            this.btnManageClients.Name = "btnManageClients";
            this.btnManageClients.Size = new System.Drawing.Size(300, 70);
            this.btnManageClients.TabIndex = 0;
            this.btnManageClients.Text = "Manage Clients";
            this.btnManageClients.UseVisualStyleBackColor = false;
            this.btnManageClients.Click += new System.EventHandler(this.btnManageClients_Click);
            // 
            // btnManageRooms
            // 
            this.btnManageRooms.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnManageRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btnManageRooms.Location = new System.Drawing.Point(437, 127);
            this.btnManageRooms.Name = "btnManageRooms";
            this.btnManageRooms.Size = new System.Drawing.Size(300, 70);
            this.btnManageRooms.TabIndex = 21;
            this.btnManageRooms.Text = "Manage Rooms";
            this.btnManageRooms.UseVisualStyleBackColor = false;
            this.btnManageRooms.Click += new System.EventHandler(this.btnManageRooms_Click);
            // 
            // btnManageReverv
            // 
            this.btnManageReverv.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnManageReverv.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btnManageReverv.Location = new System.Drawing.Point(161, 257);
            this.btnManageReverv.Name = "btnManageReverv";
            this.btnManageReverv.Size = new System.Drawing.Size(430, 70);
            this.btnManageReverv.TabIndex = 22;
            this.btnManageReverv.Text = "Manage Revervations";
            this.btnManageReverv.UseVisualStyleBackColor = false;
            this.btnManageReverv.Click += new System.EventHandler(this.btnManageReverv_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.btnManageRooms);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnManageReverv);
            this.panel1.Controls.Add(this.btnManageClients);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 425);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(645, 174);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 248);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 453);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip2);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem manageClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageRoomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageReservationsToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManageClients;
        private System.Windows.Forms.Button btnManageRooms;
        private System.Windows.Forms.Button btnManageReverv;
        private System.Windows.Forms.Panel panel1;
    }
}