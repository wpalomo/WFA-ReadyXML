using System;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;
using System.Collections.Generic;
using System.Configuration;

namespace WFAReadyXML
{
    public class SignXML
    {
        private static void addUBLExtension(string pathXML, int typeDoc)
        {
            XmlDocument doc = new XmlDocument();
            XmlNodeList xelc;
            XmlNode root;
            doc.Load(pathXML);

            XmlNamespaceManager xmlnsMgr = CommonMethods.getNamespacesManager(doc);

            switch (typeDoc) 
            {
                case Constants.INVOICE_STRING_FIRMA_ID:
                    root = doc.SelectSingleNode(Constants.XPATH_UBL_EXTENSIONS_INVOICE, xmlnsMgr);
                    xelc = doc.SelectNodes(Constants.XPATH_EXTCONT_SIGN_INVOICE, xmlnsMgr);
                    break;
                case Constants.CREDITNOTE_STRING_FIRMA_ID:
                    root = doc.SelectSingleNode(Constants.XPATH_UBL_EXTENSIONS_CREDITNOTE, xmlnsMgr);
                    xelc = doc.SelectNodes(Constants.XPATH_EXTCONT_SIGN_CREDITNOTE, xmlnsMgr);
                    break;
                case Constants.DEBITNOTE_STRING_FIRMA_ID:
                    root = doc.SelectSingleNode(Constants.XPATH_UBL_EXTENSIONS_DEBITNOTE, xmlnsMgr);
                    xelc = doc.SelectNodes(Constants.XPATH_EXTCONT_SIGN_DEBITNOTE, xmlnsMgr);
                    break;
                default: //default is invoice
                    root = doc.SelectSingleNode(Constants.XPATH_UBL_EXTENSIONS_INVOICE, xmlnsMgr);
                    xelc = doc.SelectNodes(Constants.XPATH_EXTCONT_SIGN_INVOICE, xmlnsMgr);
                    break;
            }

            if (xelc.Count < 2)
            {
                //Create a new node.
                XmlNode elem = doc.CreateElement("ext", "UBLExtension", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
                XmlNode elem1 = doc.CreateElement("ext", "ExtensionContent", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");

                //Add the node to the document.
                elem.AppendChild(elem1);
                root.AppendChild(elem);

                CommonMethods.saveXML(doc, pathXML);
            }

        }

        public static int signJAVA(string pathXML, string pathXMLSave, int typeDoc) 
        {
            int exitCode = 0;

            if (documentNotSign(pathXML, typeDoc))
            {
                string response = "";
                string pathJavaExe = ConfigurationManager.AppSettings[Constants.PATH_JAVA_EXE];
                string commandExecuteJava = ConfigurationManager.AppSettings[Constants.COMMAND_EXECUTE_JAVA_SIGN];
                string workingDirectory = ConfigurationManager.AppSettings[Constants.WORKING_DIRECTORY];
                int timeOut = int.Parse(ConfigurationManager.AppSettings[Constants.TIMEOUT]);

                exitCode = ExecProcess.ExecuteProcess(pathJavaExe,
                                                commandExecuteJava + GetParameters(pathXML, pathXMLSave),
                                                workingDirectory,
                                                timeOut,
                                                out response);
                return exitCode;
            }
            return exitCode;
        }

        private static bool checkNotSign(string pathXML)
        {
            bool check = true;

            XmlDocument doc = new XmlDocument();
            doc.Load(pathXML);
            XmlNamespaceManager xmlnsMgr = CommonMethods.getNamespacesManager(doc);
            if (doc.SelectNodes(Constants.XPATH_SIGN_INVOICE, xmlnsMgr).Count > 0)
                check = false;
            if (doc.SelectNodes(Constants.XPATH_SIGN_CREDITNOTE, xmlnsMgr).Count > 0)
                check = false;
            if (doc.SelectNodes(Constants.XPATH_SIGN_DEBITNOTE, xmlnsMgr).Count > 0)
                check = false;

            return check;
        }

        private static bool documentNotSign(string pathXML, int typeDoc)
        {
            addUBLExtension(pathXML, typeDoc);
            return checkNotSign(pathXML);
        }

        private static string GetParameters(string pathXML, string pathXMLSave)
        {
            string rol = ConfigurationManager.AppSettings[Constants.CLAIMED_ROL_SIGN];
            return "\"" + pathXML + "\" \"" + pathXMLSave + "\" \"" + rol + "\"";
        }

    }
}
