namespace Net4
{
    partial class PUBLICNEWS
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelType = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelContent = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelType.ForeColor = System.Drawing.Color.Cyan;
            this.labelType.Location = new System.Drawing.Point(425, 35);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(115, 17);
            this.labelType.TabIndex = 1;
            this.labelType.Text = "CẬP NHẬT GAME";
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(424, 60);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(299, 63);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "CẬP NHẬT GAME LIÊN MINH HUYỀN THOẠI";
            // 
            // labelContent
            // 
            this.labelContent.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContent.ForeColor = System.Drawing.Color.White;
            this.labelContent.Location = new System.Drawing.Point(423, 135);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(299, 148);
            this.labelContent.TabIndex = 3;
            this.labelContent.Text = "Cập nhật lối chơi, meta game, cân bằng các vị tướng và nhiều trang bị mới. Chỉnh " +
    "sửa tính năng và fix lỗi";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Net4.Properties.Resources.Patch_notes_13_8_Banners;
            this.pictureBox1.Location = new System.Drawing.Point(3, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(415, 274);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.ForeColor = System.Drawing.Color.White;
            this.labelDate.Location = new System.Drawing.Point(426, 15);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(69, 17);
            this.labelDate.TabIndex = 4;
            this.labelDate.Text = "26/4/2023";
            // 
            // PUBLICNEWS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelContent);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PUBLICNEWS";
            this.Size = new System.Drawing.Size(726, 300);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label labelType;
        public System.Windows.Forms.Label labelTitle;
        public System.Windows.Forms.Label labelContent;
        public System.Windows.Forms.Label labelDate;
        public System.Windows.Forms.PictureBox pictureBox1;
    }
}
