using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WFAReadyXML
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            this.txtPathXML.Enabled = false;

            loadCB();
        }

        private void loadCB()
        {
            var ds = new Dictionary<string, int>(){
            {"Factura", Constants.INVOICE_STRING_FIRMA_ID},
            {"Nota de Credito", Constants.CREDITNOTE_STRING_FIRMA_ID},
            {"Nota de Debito", Constants.DEBITNOTE_STRING_FIRMA_ID}};
            cbTipoDoc.DataSource = new BindingSource(ds, null); //This line is causing the error
            cbTipoDoc.DisplayMember = "Key";
            cbTipoDoc.ValueMember = "Value";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XML|*.xml";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPathXML.Text = openFileDialog1.FileName;
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (!(txtPathXML.Text.Length <= 0))
            {

                string message = Core.iniciarProcesoZip(
                    cbxFirma.Checked,
                    cbxCUFE.Checked,
                    cbxZIP.Checked,
                    txtPathXML.Text,
                    (int)cbTipoDoc.SelectedValue);

                MessageBox.Show(message,
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign
                    );

                this.statusStrip1.Text = "asd";
            }
            else
            {
                MessageBox.Show("Chequee parametros ingresados",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign
                    );
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!(txtPathXML.Text.Length <= 0))
            {
                string message = Core.iniciarProcesoZip(
                    cbxFirma.Checked,
                    cbxCUFE.Checked,
                    cbxZIP.Checked,
                    txtPathXML.Text,
                    (int)cbTipoDoc.SelectedValue);

                MessageBox.Show(message,
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign
                    );

                if (cbxZIP.Checked)
                {
                    string messageZIP = Core.enviarZIP(txtPathXML.Text, (int)cbTipoDoc.SelectedValue);
                    MessageBox.Show(messageZIP,
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign
                        );
                }
                else
                {
                    MessageBox.Show("Se debe zipear archivo",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign
                        );
                }
            }
            else
            {
                MessageBox.Show("Chequee parametros ingresados",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign
                    );
            }

        }

        private void cbxZIP_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
