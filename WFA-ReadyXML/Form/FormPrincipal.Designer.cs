namespace WFAReadyXML
{
    partial class FormPrincipal
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.cbxFirma = new System.Windows.Forms.CheckBox();
            this.cbxCUFE = new System.Windows.Forms.CheckBox();
            this.cbxZIP = new System.Windows.Forms.CheckBox();
            this.txtPathXML = new System.Windows.Forms.TextBox();
            this.btnOFD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbTipoDoc = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 349);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(376, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.Honeydew;
            this.btnIniciar.Location = new System.Drawing.Point(177, 254);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(188, 58);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "Procesar";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // cbxFirma
            // 
            this.cbxFirma.AutoSize = true;
            this.cbxFirma.Location = new System.Drawing.Point(21, 26);
            this.cbxFirma.Name = "cbxFirma";
            this.cbxFirma.Size = new System.Drawing.Size(54, 17);
            this.cbxFirma.TabIndex = 2;
            this.cbxFirma.Text = "Firmar";
            this.cbxFirma.UseVisualStyleBackColor = true;
            // 
            // cbxCUFE
            // 
            this.cbxCUFE.AutoSize = true;
            this.cbxCUFE.Location = new System.Drawing.Point(21, 49);
            this.cbxCUFE.Name = "cbxCUFE";
            this.cbxCUFE.Size = new System.Drawing.Size(54, 17);
            this.cbxCUFE.TabIndex = 3;
            this.cbxCUFE.Text = "CUFE";
            this.cbxCUFE.UseVisualStyleBackColor = true;
            // 
            // cbxZIP
            // 
            this.cbxZIP.AutoSize = true;
            this.cbxZIP.Checked = true;
            this.cbxZIP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxZIP.Enabled = false;
            this.cbxZIP.Location = new System.Drawing.Point(21, 72);
            this.cbxZIP.Name = "cbxZIP";
            this.cbxZIP.Size = new System.Drawing.Size(71, 17);
            this.cbxZIP.TabIndex = 4;
            this.cbxZIP.Text = "Crear ZIP";
            this.cbxZIP.UseVisualStyleBackColor = true;
            this.cbxZIP.CheckedChanged += new System.EventHandler(this.cbxZIP_CheckedChanged);
            // 
            // txtPathXML
            // 
            this.txtPathXML.Location = new System.Drawing.Point(12, 80);
            this.txtPathXML.Name = "txtPathXML";
            this.txtPathXML.Size = new System.Drawing.Size(353, 20);
            this.txtPathXML.TabIndex = 5;
            // 
            // btnOFD
            // 
            this.btnOFD.Location = new System.Drawing.Point(333, 106);
            this.btnOFD.Name = "btnOFD";
            this.btnOFD.Size = new System.Drawing.Size(32, 23);
            this.btnOFD.TabIndex = 6;
            this.btnOFD.Text = "...";
            this.btnOFD.UseVisualStyleBackColor = true;
            this.btnOFD.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Envio Documentos";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Seleccionar Archivo";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button2.Location = new System.Drawing.Point(177, 212);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 37);
            this.button2.TabIndex = 10;
            this.button2.Text = "Procesar / Enviar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxFirma);
            this.groupBox3.Controls.Add(this.cbxCUFE);
            this.groupBox3.Controls.Add(this.cbxZIP);
            this.groupBox3.Location = new System.Drawing.Point(12, 206);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(100, 106);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Procesos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbTipoDoc);
            this.groupBox2.Location = new System.Drawing.Point(12, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 52);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Documento";
            // 
            // cbTipoDoc
            // 
            this.cbTipoDoc.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDoc.FormattingEnabled = true;
            this.cbTipoDoc.Location = new System.Drawing.Point(7, 19);
            this.cbTipoDoc.Name = "cbTipoDoc";
            this.cbTipoDoc.Size = new System.Drawing.Size(340, 21);
            this.cbTipoDoc.TabIndex = 0;
            this.cbTipoDoc.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(376, 371);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOFD);
            this.Controls.Add(this.txtPathXML);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar ZIP para enviar a la DIAN";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.CheckBox cbxFirma;
        private System.Windows.Forms.CheckBox cbxCUFE;
        private System.Windows.Forms.CheckBox cbxZIP;
        private System.Windows.Forms.TextBox txtPathXML;
        private System.Windows.Forms.Button btnOFD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbTipoDoc;
    }
}