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
            openFileDialog1.Filter = Constants.FILTER_FILE_PROCESS;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPathXML.Text = openFileDialog1.FileName;
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            int codProc = 0;
            if (!(txtPathXML.Text.Length <= 0))
            {
                FileInfo f = new FileInfo(txtPathXML.Text);
                if (f.Extension != ".xml")
                {
                    printMsg(Constants.PROCESS_TYPE_EXT_ERROR);
                }
                else
                {
                    codProc = Core.IniciarProcesoZip(
                        cbxFirma.Checked,
                        cbxCUFE.Checked,
                        cbxZIP.Checked,
                        txtPathXML.Text,
                        (int)cbTipoDoc.SelectedValue,
                        "0");

                    printMsg(codProc);
                }
            }
            else
            {
                printMsg(Constants.PROCESS_CORE_COD_ERROR_PARAM);
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
                FileInfo f = new FileInfo(txtPathXML.Text);
                if (f.Extension != ".xml")
                {
                    int codProc = Core.ProcesoEnvioZIP(
                        cbxFirma.Checked,
                        cbxCUFE.Checked,
                        cbxZIP.Checked,
                        txtPathXML.Text,
                        (int)cbTipoDoc.SelectedValue);

                    printMsg(codProc);
                }
                else
                {
                    int codProc = Core.IniciarProcesoZip(
                        cbxFirma.Checked,
                        cbxCUFE.Checked,
                        cbxZIP.Checked,
                        txtPathXML.Text,
                        (int)cbTipoDoc.SelectedValue,
                        "0");

                    printMsg(codProc);

                    if (cbxZIP.Checked)
                    {
                        string messageZIP = Core.EnviarZIP(txtPathXML.Text, (int)cbTipoDoc.SelectedValue);
                        printMsg(messageZIP, Constants.PROCESS_CORE_COD_OK);
                    }
                    else
                    {
                        printMsg(Constants.PROCESS_ERROR_NOT_ZIP_MSG, Constants.PROCESS_CORE_COD_ERROR);
                    }
                }
            }
            else
            {
                printMsg(Constants.PROCESS_CORE_COD_ERROR_PARAM);
            }
        }

        private void printMsg(string msg, int codProc) 
        {
            if (codProc == Constants.PROCESS_CORE_COD_OK)
                MessageBox.Show(msg,
                    Constants.MSG_FORM_OK,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign
                    );

            if (codProc == Constants.PROCESS_CORE_COD_ERROR)
                MessageBox.Show(msg,
                            Constants.MSG_FORM_ERROR,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign
                            );

        }
        private void printMsg(int codProc)
        {
            if (codProc == Constants.PROCESS_CORE_COD_OK)
            {
                MessageBox.Show(Constants.PROCESS_CORE_OK,
                        Constants.MSG_FORM_OK,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign
                        );
            }
            else {
                string msg = "";
                switch (codProc) 
                {
                    case Constants.PROCESS_CORE_COD_ERROR_CUFE:
                        msg = Constants.PROCESS_CORE_ERROR_CUFE_MSG;
                        break;
                    case Constants.PROCESS_CORE_COD_ERROR_FIRMA:
                        msg = Constants.PROCESS_CORE_ERROR_FIRMA_MSG;
                        break;
                    case Constants.PROCESS_CORE_COD_ERROR_ZIP:
                        msg = Constants.PROCESS_CORE_ERROR_ZIP_MSG;
                        break;
                    case Constants.PROCESS_CORE_COD_ERROR_PARAM:
                        msg = Constants.PROCESS_CORE_ERROR_PARAM_MSG;
                        break;
                    case Constants.PROCESS_SEND_COD_ERROR:
                        msg = Constants.PROCESS_SEND_STRING_ERROR_MSG;
                        break;
                    case Constants.PROCESS_TYPE_EXT_ERROR:
                        msg = Constants.PROCESS_TYPE_EXT_ERROR_MGS;
                        break;
                    default:
                        msg = Constants.PROCESS_CORE_ERROR_MSG;
                        break;
                }
                MessageBox.Show(msg,
                    Constants.MSG_FORM_ERROR,
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
