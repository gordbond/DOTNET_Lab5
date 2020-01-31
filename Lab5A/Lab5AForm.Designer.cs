namespace Lab5A
{
    partial class Lab5AForm
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
            this.components = new System.ComponentModel.Container();
            this.colourButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.bucketTimer = new System.Windows.Forms.Timer(this.components);
            this.flowTrackBar = new System.Windows.Forms.TrackBar();
            this.faucetPictureBox = new System.Windows.Forms.PictureBox();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.WaterColorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.flowTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faucetPictureBox)).BeginInit();
            this.controlPanel.SuspendLayout();
            this.drawingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // colourButton
            // 
            this.colourButton.Location = new System.Drawing.Point(68, 23);
            this.colourButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.colourButton.Name = "colourButton";
            this.colourButton.Size = new System.Drawing.Size(210, 63);
            this.colourButton.TabIndex = 0;
            this.colourButton.Text = "Colour";
            this.colourButton.UseVisualStyleBackColor = true;
            this.colourButton.Click += new System.EventHandler(this.ColourButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(372, 23);
            this.closeButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(210, 63);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // bucketTimer
            // 
            this.bucketTimer.Interval = 1000;
            this.bucketTimer.Tick += new System.EventHandler(this.BucketTimer_Tick);
            // 
            // flowTrackBar
            // 
            this.flowTrackBar.Location = new System.Drawing.Point(50, 137);
            this.flowTrackBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.flowTrackBar.Name = "flowTrackBar";
            this.flowTrackBar.Size = new System.Drawing.Size(270, 90);
            this.flowTrackBar.TabIndex = 2;
            this.flowTrackBar.Scroll += new System.EventHandler(this.FlowTrackBar_Scroll);
            // 
            // faucetPictureBox
            // 
            this.faucetPictureBox.Image = global::Lab5A.Properties.Resources.Faucet;
            this.faucetPictureBox.Location = new System.Drawing.Point(68, 54);
            this.faucetPictureBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.faucetPictureBox.Name = "faucetPictureBox";
            this.faucetPictureBox.Size = new System.Drawing.Size(210, 121);
            this.faucetPictureBox.TabIndex = 3;
            this.faucetPictureBox.TabStop = false;
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.colourButton);
            this.controlPanel.Controls.Add(this.flowTrackBar);
            this.controlPanel.Controls.Add(this.closeButton);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(768, 229);
            this.controlPanel.TabIndex = 5;
            // 
            // drawingPanel
            // 
            this.drawingPanel.Controls.Add(this.faucetPictureBox);
            this.drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel.Location = new System.Drawing.Point(0, 229);
            this.drawingPanel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(768, 677);
            this.drawingPanel.TabIndex = 6;
            // 
            // WaterColorDialog
            // 
            this.WaterColorDialog.Color = System.Drawing.Color.Aquamarine;
            // 
            // Lab5AForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(768, 906);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.controlPanel);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Lab5AForm";
            this.Text = "A Drop in the Bucket";
            this.Load += new System.EventHandler(this.Lab5AForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flowTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faucetPictureBox)).EndInit();
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.drawingPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button colourButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Timer bucketTimer;
        private System.Windows.Forms.TrackBar flowTrackBar;
        private System.Windows.Forms.PictureBox faucetPictureBox;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.ColorDialog WaterColorDialog;
    }
}

