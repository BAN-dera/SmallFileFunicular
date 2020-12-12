namespace Client
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SendPanel = new System.Windows.Forms.Panel();
            this.txtReceiverID = new System.Windows.Forms.TextBox();
            this.labelUserReceiverID = new System.Windows.Forms.Label();
            this.buttonSendFile = new System.Windows.Forms.Button();
            this.buttonChoseFile = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.fileSendLabel = new System.Windows.Forms.Label();
            this.SendPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendPanel
            // 
            this.SendPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.SendPanel.Controls.Add(this.txtReceiverID);
            this.SendPanel.Controls.Add(this.labelUserReceiverID);
            this.SendPanel.Controls.Add(this.buttonSendFile);
            this.SendPanel.Controls.Add(this.buttonChoseFile);
            this.SendPanel.Controls.Add(this.txtFilePath);
            this.SendPanel.Controls.Add(this.fileSendLabel);
            this.SendPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SendPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(48)))), ((int)(((byte)(49)))));
            this.SendPanel.Location = new System.Drawing.Point(0, 0);
            this.SendPanel.Name = "SendPanel";
            this.SendPanel.Size = new System.Drawing.Size(365, 76);
            this.SendPanel.TabIndex = 0;
            // 
            // txtReceiverID
            // 
            this.txtReceiverID.Location = new System.Drawing.Point(108, 48);
            this.txtReceiverID.Name = "txtReceiverID";
            this.txtReceiverID.Size = new System.Drawing.Size(189, 23);
            this.txtReceiverID.TabIndex = 5;
            // 
            // labelUserReceiverID
            // 
            this.labelUserReceiverID.AutoSize = true;
            this.labelUserReceiverID.Location = new System.Drawing.Point(3, 51);
            this.labelUserReceiverID.Name = "labelUserReceiverID";
            this.labelUserReceiverID.Size = new System.Drawing.Size(99, 18);
            this.labelUserReceiverID.TabIndex = 4;
            this.labelUserReceiverID.Text = "Receiver name:";
            // 
            // buttonSendFile
            // 
            this.buttonSendFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendFile.Location = new System.Drawing.Point(303, 44);
            this.buttonSendFile.Name = "buttonSendFile";
            this.buttonSendFile.Size = new System.Drawing.Size(56, 32);
            this.buttonSendFile.TabIndex = 3;
            this.buttonSendFile.Text = "Send";
            this.buttonSendFile.UseVisualStyleBackColor = true;
            this.buttonSendFile.Click += new System.EventHandler(this.buttonSendFile_Click);
            // 
            // buttonChoseFile
            // 
            this.buttonChoseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChoseFile.Location = new System.Drawing.Point(303, 0);
            this.buttonChoseFile.Name = "buttonChoseFile";
            this.buttonChoseFile.Size = new System.Drawing.Size(56, 32);
            this.buttonChoseFile.TabIndex = 2;
            this.buttonChoseFile.Text = "Chose";
            this.buttonChoseFile.UseVisualStyleBackColor = true;
            this.buttonChoseFile.Click += new System.EventHandler(this.buttonChoseFile_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(43, 6);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(254, 23);
            this.txtFilePath.TabIndex = 1;
            // 
            // fileSendLabel
            // 
            this.fileSendLabel.AutoSize = true;
            this.fileSendLabel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileSendLabel.Location = new System.Drawing.Point(3, 9);
            this.fileSendLabel.Name = "fileSendLabel";
            this.fileSendLabel.Size = new System.Drawing.Size(34, 18);
            this.fileSendLabel.TabIndex = 0;
            this.fileSendLabel.Text = "File:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.ClientSize = new System.Drawing.Size(362, 76);
            this.Controls.Add(this.SendPanel);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(378, 115);
            this.MinimumSize = new System.Drawing.Size(378, 115);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmallFileFunicular";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SendPanel.ResumeLayout(false);
            this.SendPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SendPanel;
        private System.Windows.Forms.TextBox txtReceiverID;
        private System.Windows.Forms.Label labelUserReceiverID;
        private System.Windows.Forms.Button buttonSendFile;
        private System.Windows.Forms.Button buttonChoseFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label fileSendLabel;
    }
}

