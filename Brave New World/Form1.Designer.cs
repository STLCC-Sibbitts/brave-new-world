namespace ClassProject
{
    partial class Form1
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
            this.picboxDrawing = new System.Windows.Forms.PictureBox();
            this.btnDraw = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picboxDrawing)).BeginInit();
            this.SuspendLayout();
            // 
            // picboxDrawing
            // 
            this.picboxDrawing.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picboxDrawing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picboxDrawing.Location = new System.Drawing.Point(0, 0);
            this.picboxDrawing.Name = "picboxDrawing";
            this.picboxDrawing.Size = new System.Drawing.Size(625, 486);
            this.picboxDrawing.TabIndex = 0;
            this.picboxDrawing.TabStop = false;
            this.picboxDrawing.Click += new System.EventHandler(this.picboxDrawing_Click);
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(631, 71);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(101, 23);
            this.btnDraw.TabIndex = 1;
            this.btnDraw.Text = "Magic!!!";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(761, 498);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.picboxDrawing);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picboxDrawing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       
        private System.Windows.Forms.PictureBox picboxDrawing;
        private System.Windows.Forms.Button btnDraw;



    }
}

