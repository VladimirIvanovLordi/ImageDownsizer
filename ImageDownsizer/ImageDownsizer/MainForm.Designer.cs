namespace ImageDownsizer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnDownsizeNonParallel = new Button();
            btnDownsizeParallel = new Button();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            pbSelectedImage = new PictureBox();
            btnSelectImage = new Button();
            lblPictureBoxInfo = new Label();
            tbDownsizingFactorInput = new TextBox();
            lblDownsizingInputPrompt = new Label();
            lblPercentForTextFox = new Label();
            lblNonParallelTime = new Label();
            lblParallelTime = new Label();
            btnSaveDownsizedImage = new Button();
            ((System.ComponentModel.ISupportInitialize)pbSelectedImage).BeginInit();
            SuspendLayout();
            // 
            // btnDownsizeNonParallel
            // 
            btnDownsizeNonParallel.Location = new Point(544, 268);
            btnDownsizeNonParallel.Name = "btnDownsizeNonParallel";
            btnDownsizeNonParallel.Size = new Size(92, 44);
            btnDownsizeNonParallel.TabIndex = 0;
            btnDownsizeNonParallel.Text = "Downsize Non-Parallelly";
            btnDownsizeNonParallel.UseVisualStyleBackColor = true;
            btnDownsizeNonParallel.Click += btnDownsizeNonParallel_Click;
            // 
            // btnDownsizeParallel
            // 
            btnDownsizeParallel.Location = new Point(696, 268);
            btnDownsizeParallel.Name = "btnDownsizeParallel";
            btnDownsizeParallel.Size = new Size(92, 44);
            btnDownsizeParallel.TabIndex = 1;
            btnDownsizeParallel.Text = "Downsize Parallelly";
            btnDownsizeParallel.UseVisualStyleBackColor = true;
            btnDownsizeParallel.Click += btnDownsizeParallel_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Bitmap Supported (*.PNG;*.JPG;*.JPEG;*.BMP)|*.png;*.jpg;*.jpeg;*.bmp|All Files (*.*)|*.*";
            openFileDialog.Title = "Load Image";
            // 
            // saveFileDialog
            // 
            saveFileDialog.Filter = "Bitmap Supported (*.PNG;*.JPG;*.JPEG;*.BMP)|*.png;*.jpg;*.jpeg;*.bmp|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save Image";
            // 
            // pbSelectedImage
            // 
            pbSelectedImage.BorderStyle = BorderStyle.FixedSingle;
            pbSelectedImage.Location = new Point(12, 12);
            pbSelectedImage.Name = "pbSelectedImage";
            pbSelectedImage.Size = new Size(525, 426);
            pbSelectedImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSelectedImage.TabIndex = 2;
            pbSelectedImage.TabStop = false;
            // 
            // btnSelectImage
            // 
            btnSelectImage.Location = new Point(543, 12);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(92, 44);
            btnSelectImage.TabIndex = 3;
            btnSelectImage.Text = "Select Image";
            btnSelectImage.UseVisualStyleBackColor = true;
            btnSelectImage.Click += btnSelectImage_Click;
            // 
            // lblPictureBoxInfo
            // 
            lblPictureBoxInfo.AutoSize = true;
            lblPictureBoxInfo.Location = new Point(544, 69);
            lblPictureBoxInfo.Name = "lblPictureBoxInfo";
            lblPictureBoxInfo.Size = new Size(142, 15);
            lblPictureBoxInfo.TabIndex = 4;
            lblPictureBoxInfo.Text = "Picture box size - 525, 426";
            // 
            // tbDownsizingFactorInput
            // 
            tbDownsizingFactorInput.Location = new Point(544, 180);
            tbDownsizingFactorInput.Name = "tbDownsizingFactorInput";
            tbDownsizingFactorInput.Size = new Size(92, 23);
            tbDownsizingFactorInput.TabIndex = 5;
            tbDownsizingFactorInput.TextAlign = HorizontalAlignment.Right;
            tbDownsizingFactorInput.KeyPress += tbDownsizingFactor_KeyPress;
            // 
            // lblDownsizingInputPrompt
            // 
            lblDownsizingInputPrompt.AutoSize = true;
            lblDownsizingInputPrompt.Location = new Point(544, 162);
            lblDownsizingInputPrompt.Name = "lblDownsizingInputPrompt";
            lblDownsizingInputPrompt.Size = new Size(91, 15);
            lblDownsizingInputPrompt.TabIndex = 6;
            lblDownsizingInputPrompt.Text = "Enter a number:";
            // 
            // lblPercentForTextFox
            // 
            lblPercentForTextFox.AutoSize = true;
            lblPercentForTextFox.BackColor = Color.Transparent;
            lblPercentForTextFox.Location = new Point(637, 183);
            lblPercentForTextFox.Name = "lblPercentForTextFox";
            lblPercentForTextFox.Size = new Size(17, 15);
            lblPercentForTextFox.TabIndex = 7;
            lblPercentForTextFox.Text = "%";
            // 
            // lblNonParallelTime
            // 
            lblNonParallelTime.AutoSize = true;
            lblNonParallelTime.Location = new Point(557, 315);
            lblNonParallelTime.Name = "lblNonParallelTime";
            lblNonParallelTime.Size = new Size(63, 15);
            lblNonParallelTime.TabIndex = 8;
            lblNonParallelTime.Text = "time taken";
            lblNonParallelTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblParallelTime
            // 
            lblParallelTime.AutoSize = true;
            lblParallelTime.Location = new Point(708, 315);
            lblParallelTime.Name = "lblParallelTime";
            lblParallelTime.Size = new Size(63, 15);
            lblParallelTime.TabIndex = 9;
            lblParallelTime.Text = "time taken";
            lblParallelTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSaveDownsizedImage
            // 
            btnSaveDownsizedImage.Location = new Point(615, 354);
            btnSaveDownsizedImage.Name = "btnSaveDownsizedImage";
            btnSaveDownsizedImage.Size = new Size(92, 56);
            btnSaveDownsizedImage.TabIndex = 10;
            btnSaveDownsizedImage.Text = "Save Downsized Image";
            btnSaveDownsizedImage.UseVisualStyleBackColor = true;
            btnSaveDownsizedImage.Click += btnSaveDownsizedImage_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSaveDownsizedImage);
            Controls.Add(lblParallelTime);
            Controls.Add(lblNonParallelTime);
            Controls.Add(lblPercentForTextFox);
            Controls.Add(lblDownsizingInputPrompt);
            Controls.Add(tbDownsizingFactorInput);
            Controls.Add(lblPictureBoxInfo);
            Controls.Add(btnSelectImage);
            Controls.Add(pbSelectedImage);
            Controls.Add(btnDownsizeParallel);
            Controls.Add(btnDownsizeNonParallel);
            Name = "MainForm";
            Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)pbSelectedImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDownsizeNonParallel;
        private Button btnDownsizeParallel;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private PictureBox pbSelectedImage;
        private Button btnSelectImage;
        private Label lblPictureBoxInfo;
        private TextBox tbDownsizingFactorInput;
        private Label lblDownsizingInputPrompt;
        private Label lblPercentForTextFox;
        private Label lblNonParallelTime;
        private Label lblParallelTime;
        private Button btnSaveDownsizedImage;
    }
}
