using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using System.Xml;

namespace WFAReadyXML
{
    public class Connection
    {
        private string nit;

        public string Nit
        {
            get { return nit; }
            set { nit = value; }
        }
        private string numberInvoice;

        public string NumberInvoice
        {
            get { return numberInvoice; }
            set { numberInvoice = value; }
        }
        private string dateTime;

        public string DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }
        private string pathZip;

        public string PathZip
        {
            get { return pathZip; }
            set { pathZip = value; }
        }
        private string usuario = ConfigurationManager.AppSettings[Constants.USER_WEBSERVICE_DIAN];

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        private string password = ConfigurationManager.AppSettings[Constants.PASSWORD_WEBSERVICE_DIAN];

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string urlWS = ConfigurationManager.AppSettings[Constants.URL_WEBSERVICE_DIAN];

        public string UrlWS
        {
            get { return urlWS; }
            set { urlWS = value; }
        }
        private string response = "";

        public Connection() { }

        public string Send()
        {
            string pathJavaExe = ConfigurationManager.AppSettings[Constants.PATH_JAVA_EXE];
            string commandExecuteJava = ConfigurationManager.AppSettings[Constants.COMMAND_EXECUTE_JAVA_SEND];
            string workingDirectory = ConfigurationManager.AppSettings[Constants.WORKING_DIRECTORY];
            int timeOut = int.Parse(ConfigurationManager.AppSettings[Constants.TIMEOUT]);

            int exitCode = ExecProcess.ExecuteProcess(pathJavaExe,
                                            commandExecuteJava + GetParameters(),
                                            workingDirectory,
                                            timeOut,
                                            out response);

            return response;
        }

        /*
            * @param1 nit
            * @param2 ninvoice
            * @param3 datetime
            * @param4 pathZip
            * @param5 user
            * @param6 password
            * @param7 urlWS
        */
        private string GetParameters() 
        {
            return "\"" + Nit + "\" \"" + NumberInvoice + "\" \"" + DateTime + "\" \"" + PathZip + "\" \"" + Usuario + "\" \"" + Password + "\" \"" + UrlWS + "\"";
        }

        public static void setParameters(Connection c, string pathXML, int typeDoc)
        {
            FileInfo file = new FileInfo(pathXML);
            c.PathZip = ZipXML.createZipName(file);

            XmlDocument doc = new XmlDocument();
            doc.Load(file.FullName);
            XmlNamespaceManager xmlnsMgr = CommonMethods.getNamespacesManager(doc);

            switch (typeDoc)
            {
                case Constants.INVOICE_STRING_FIRMA_ID:
                    c.Nit = doc.SelectSingleNode(Constants.XPATH_NIT_INVOICE, xmlnsMgr).InnerText;
                    c.DateTime = doc.SelectSingleNode(Constants.XPATH_DATE_INVOICE, xmlnsMgr).InnerText
                        + "_" + doc.SelectSingleNode(Constants.XPATH_HOUR_INVOICE, xmlnsMgr).InnerText;
                    c.NumberInvoice = doc.SelectSingleNode(Constants.XPATH_NUMBER_INVOICE, xmlnsMgr).InnerText;
                    break;
                case Constants.DEBITNOTE_STRING_FIRMA_ID:
                    c.Nit = doc.SelectSingleNode(Constants.XPATH_NIT_DEBITNOTE, xmlnsMgr).InnerText;
                    c.DateTime = doc.SelectSingleNode(Constants.XPATH_DATE_DEBITNOTE, xmlnsMgr).InnerText
                        + "_" + doc.SelectSingleNode(Constants.XPATH_HOUR_DEBITNOTE, xmlnsMgr).InnerText;
                    c.NumberInvoice = doc.SelectSingleNode(Constants.XPATH_NUMBER_DEBITNOTE, xmlnsMgr).InnerText;
                    break;
                case Constants.CREDITNOTE_STRING_FIRMA_ID:
                    c.Nit = doc.SelectSingleNode(Constants.XPATH_NIT_CREDITNOTE, xmlnsMgr).InnerText;
                    c.DateTime = doc.SelectSingleNode(Constants.XPATH_DATE_CREDITNOTE, xmlnsMgr).InnerText
                        + "_" + doc.SelectSingleNode(Constants.XPATH_HOUR_CREDITNOTE, xmlnsMgr).InnerText;
                    c.NumberInvoice = doc.SelectSingleNode(Constants.XPATH_NUMBER_CREDITNOTE, xmlnsMgr).InnerText;
                    break;

                default:
                    break;
            }
        }
    }
}
