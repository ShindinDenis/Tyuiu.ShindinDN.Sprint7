namespace Tyuiu.ShindinDN.Sprint7.Project.V7
{
    partial class FormInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInfo));
            textBoxInfoHelp_SDN = new TextBox();
            pictureBoxInfo_SDN = new PictureBox();
            textBoxInfo_SDN = new TextBox();
            buttonClose_SDN = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxInfo_SDN).BeginInit();
            SuspendLayout();
            // 
            // textBoxInfoHelp_SDN
            // 
            textBoxInfoHelp_SDN.BackColor = SystemColors.Control;
            textBoxInfoHelp_SDN.BorderStyle = BorderStyle.None;
            textBoxInfoHelp_SDN.Font = new Font("Segoe UI", 12F);
            textBoxInfoHelp_SDN.Location = new Point(8, 9);
            textBoxInfoHelp_SDN.Margin = new Padding(3, 2, 3, 2);
            textBoxInfoHelp_SDN.Multiline = true;
            textBoxInfoHelp_SDN.Name = "textBoxInfoHelp_SDN";
            textBoxInfoHelp_SDN.ReadOnly = true;
            textBoxInfoHelp_SDN.Size = new Size(564, 182);
            textBoxInfoHelp_SDN.TabIndex = 0;
            textBoxInfoHelp_SDN.TabStop = false;
            textBoxInfoHelp_SDN.Text = resources.GetString("textBoxInfoHelp_SDN.Text");
            // 
            // pictureBoxInfo_SDN
            // 
            pictureBoxInfo_SDN.BackgroundImage = Properties.Resources.photo_2024_12_25_03_45_42;
            pictureBoxInfo_SDN.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxInfo_SDN.Location = new Point(8, 195);
            pictureBoxInfo_SDN.Margin = new Padding(3, 2, 3, 2);
            pictureBoxInfo_SDN.Name = "pictureBoxInfo_SDN";
            pictureBoxInfo_SDN.Size = new Size(165, 160);
            pictureBoxInfo_SDN.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxInfo_SDN.TabIndex = 1;
            pictureBoxInfo_SDN.TabStop = false;
            // 
            // textBoxInfo_SDN
            // 
            textBoxInfo_SDN.BackColor = SystemColors.Control;
            textBoxInfo_SDN.BorderStyle = BorderStyle.None;
            textBoxInfo_SDN.Location = new Point(205, 195);
            textBoxInfo_SDN.Margin = new Padding(3, 2, 3, 2);
            textBoxInfo_SDN.Multiline = true;
            textBoxInfo_SDN.Name = "textBoxInfo_SDN";
            textBoxInfo_SDN.ReadOnly = true;
            textBoxInfo_SDN.Size = new Size(368, 108);
            textBoxInfo_SDN.TabIndex = 2;
            textBoxInfo_SDN.TabStop = false;
            textBoxInfo_SDN.Text = "Разработчик: Шиндин Д.Н\r\nГруппа: ИСТНб-24-1";
            // 
            // buttonClose_SDN
            // 
            buttonClose_SDN.Location = new Point(330, 314);
            buttonClose_SDN.Margin = new Padding(3, 2, 3, 2);
            buttonClose_SDN.Name = "buttonClose_SDN";
            buttonClose_SDN.Size = new Size(112, 33);
            buttonClose_SDN.TabIndex = 3;
            buttonClose_SDN.Text = "Закрыть";
            buttonClose_SDN.UseVisualStyleBackColor = true;
            buttonClose_SDN.Click += buttonClose_SDN_Click;
            // 
            // FormInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 364);
            Controls.Add(buttonClose_SDN);
            Controls.Add(textBoxInfo_SDN);
            Controls.Add(pictureBoxInfo_SDN);
            Controls.Add(textBoxInfoHelp_SDN);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormInfo";
            Text = "О программе ";
            ((System.ComponentModel.ISupportInitialize)pictureBoxInfo_SDN).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxInfoHelp_SDN;
        private PictureBox pictureBoxInfo_SDN;
        private TextBox textBoxInfo_SDN;
        private Button buttonClose_SDN;
    }
}