using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using WFAReadyXML;
using System.Configuration;

namespace WFAReadyXML
{
    class CommonMethods
    {
        
        private const string PREFIX = "face_";
        private const string KEY_INVOICE = "f";
        private const string KEY_CREDITNOTE = "c";
        private const string KEY_DEBITNOTE = "d";

        public static string createXMLName(FileInfo file, int typeDoc)
        {
            string nit = "";
            string nInvoice = "";
            string keyDoc = "";

            XmlDocument doc = new XmlDocument();
            doc.Load(file.FullName);

            Dictionary<string, string> namespaces =
                new Dictionary<string, string> { {"fe", "http://www.dian.gov.co/contratos/facturaelectronica/v1"},
                                                 {"ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2"},
                                                 {"cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"},
                                                 {"cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"}};

            XmlNamespaceManager xmlnsMgr = new XmlNamespaceManager(doc.NameTable);
            foreach (var item in namespaces)
            {
                xmlnsMgr.AddNamespace(item.Key, item.Value);
            }

            switch (typeDoc) 
            {
                case Constants.INVOICE_STRING_FIRMA_ID:
                    nit = transformNIT(doc.SelectSingleNode(Constants.XPATH_NIT_INVOICE, xmlnsMgr).InnerText);
                    nInvoice = transformNINVOICE(doc.SelectSingleNode(Constants.XPATH_NUMBER_INVOICE, xmlnsMgr).InnerText);
                    keyDoc = KEY_INVOICE;
                    break;
                case Constants.CREDITNOTE_STRING_FIRMA_ID:
                    nit = transformNIT(doc.SelectSingleNode(Constants.XPATH_NIT_CREDITNOTE, xmlnsMgr).InnerText);
                    nInvoice = transformNINVOICE(doc.SelectSingleNode(Constants.XPATH_NUMBER_CREDITNOTE, xmlnsMgr).InnerText);
                    keyDoc = KEY_CREDITNOTE;
                    break;
                case Constants.DEBITNOTE_STRING_FIRMA_ID:
                    nit = transformNIT(doc.SelectSingleNode(Constants.XPATH_NIT_DEBITNOTE, xmlnsMgr).InnerText);
                    nInvoice = transformNINVOICE(doc.SelectSingleNode(Constants.XPATH_NUMBER_DEBITNOTE, xmlnsMgr).InnerText);
                    keyDoc = KEY_DEBITNOTE;
                    break;
                default:
                    break;
            }

            return transformNAME(nit, nInvoice, keyDoc);
        }

        private static string transformNAME(string nit, string nInvoice, string keyDoc)
        {
            return PREFIX + keyDoc + nit + nInvoice;
        }

        private static string transformNINVOICE(string p)
        {
            string nInvoiceTemp = int.Parse(p).ToString("X");
            string nInvoice = "";
            for (int i = nInvoiceTemp.Length; i < 10; i++)
            {
                nInvoice += "0";
            }
            nInvoice += nInvoiceTemp;

            return nInvoice;
        }

        private static string transformNIT(string p)
        {
            string nit = "";
            for (int i = p.Length; i < 10; i++) 
            {
                nit += "0";
            }
            return nit += p;
        }

        public static string newXML(string pathXML, int typeDoc)
        {
            string pathXMLSave = "";
            string saveDirectory = ConfigurationManager.AppSettings[Constants.SAVE_DOCUMENTS_DIRECTORY];

            FileInfo fileXML = new FileInfo(pathXML);
            XmlDocument xDoc = new XmlDocument();

            pathXMLSave = saveDirectory + "\\" + CommonMethods.createXMLName(fileXML, typeDoc) + ".xml";
            xDoc.Load(pathXML);
            if (!(File.Exists(pathXMLSave)))
                xDoc.Save(pathXMLSave);
            
            return pathXMLSave;
        }

        public static XmlNamespaceManager getNamespacesManager(XmlDocument doc) 
        {
            Dictionary<string, string> namespaces =
            new Dictionary<string, string> { {"fe", "http://www.dian.gov.co/contratos/facturaelectronica/v1"},
                                                 {"ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2"},
                                                 {"cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"},
                                                 {"cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"},
                                                 {"ds", "http://www.w3.org/2000/09/xmldsig#"}};

            XmlNamespaceManager xmlnsMgr = new XmlNamespaceManager(doc.NameTable);
            foreach (var item in namespaces)
            {
                xmlnsMgr.AddNamespace(item.Key, item.Value);
            }
            return xmlnsMgr;
        }
    }
}
