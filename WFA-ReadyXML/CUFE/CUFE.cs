using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;

namespace WFAReadyXML
{
    class CUFE
    {

        private static void addUUID(string pathXML, int typeDoc)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(pathXML);
            XmlNamespaceManager xmlnsMgr = CommonMethods.getNamespacesManager(doc);

            string type = getTypeDoc(typeDoc);

            XmlNode root = doc.SelectSingleNode("/fe:" + type, xmlnsMgr);

            if (doc.SelectNodes("/fe:" + type + "/cbc:UUID", xmlnsMgr).Count < 1)
            {
                XmlNode childRef = doc.SelectSingleNode("/fe:" + type + "/cbc:ID", xmlnsMgr);

                //Create a new node.
                XmlElement elem = doc.CreateElement("cbc", "UUID", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                elem.SetAttribute("schemeAgencyID", "195");
                elem.SetAttribute("schemeAgencyName", "CO, DIAN (Direccion de Impuestos y Aduanas Nacionales)");
                //Add the node to the document.
                root.InsertAfter(elem, childRef);

                CommonMethods.saveXML(doc, pathXML);
            }

        }

        private static string getTypeDoc(int typeDoc)
        {
            string type;
            switch (typeDoc)
            {
                case Constants.INVOICE_STRING_FIRMA_ID:
                    type = "Invoice";
                    break;
                case Constants.CREDITNOTE_STRING_FIRMA_ID:
                    type = "CreditNote";
                    break;
                case Constants.DEBITNOTE_STRING_FIRMA_ID:
                    type = "DebitNote";
                    break;
                default:
                    type = "Invoice";
                    break;
            }

            return type;
        }

        public static int AddingCUFEXML(FileInfo file, int typeDoc) 
        {
            try
            {
                addUUID(file.FullName, typeDoc);

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(file.FullName);
                var xmlnsMgr = CommonMethods.getNamespacesManager(xmlDocument);
                XmlNode nodeR = xmlDocument.SelectSingleNode("/fe:" + getTypeDoc(typeDoc), xmlnsMgr);


                string NumAdq = getNumAdq(nodeR, xmlnsMgr);
                string NumFac = getNumFac(nodeR, xmlnsMgr);
                string FecFac = getFecFac(nodeR, xmlnsMgr);
                string ValFac = getValFac(nodeR, xmlnsMgr);
                string CodImp1 = getCodImp1(nodeR, xmlnsMgr);
                string ValImp1 = getValImp1(nodeR, xmlnsMgr);
                string CodImp2 = getCodImp2(nodeR, xmlnsMgr);
                string ValImp2 = getValImp2(nodeR, xmlnsMgr);
                string CodImp3 = getCodImp3(nodeR, xmlnsMgr);
                string ValImp3 = getValImp3(nodeR, xmlnsMgr);
                string ValImp = getValImp(nodeR, xmlnsMgr);
                string NitOFE = getNitOFE(nodeR, xmlnsMgr);
                string TipAdq = getTypeAdq(nodeR, xmlnsMgr);
                string ClTec = getClTec(nodeR, xmlnsMgr);

                string CUFE = CalculateCUFE(NumFac, FecFac, ValFac, CodImp1, ValImp1,
                                            CodImp2, ValImp2, CodImp3, ValImp3, ValImp,
                                            NitOFE, TipAdq, NumAdq, ClTec);

                setCUFEXML(nodeR, xmlnsMgr, CUFE);

                CommonMethods.saveXML(xmlDocument, file.FullName);

                return Constants.PROCESS_CORE_COD_OK_CUFE;
            }
            catch(Exception e){ return Constants.PROCESS_CORE_COD_ERROR_CUFE; }

        }

        private class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding { get { return Encoding.UTF8; } }
        }

        private static void setCUFEXML(XmlNode nodeR, XmlNamespaceManager xmlnsMgr, string CUFE)
        {
            nodeR.SelectSingleNode(Constants.XPATH_CUFE, xmlnsMgr).InnerText = CUFE;
        }

        private static string getNumFac(XmlNode nodeR, XmlNamespaceManager xmlnsMgr)
        {
            return nodeR.SelectSingleNode(Constants.XPATH_NUMBER, xmlnsMgr).InnerText;
       }

        private static string getClTec(XmlNode nodeR, XmlNamespaceManager xmlnsMgr)
        {
            return ConfigurationManager.AppSettings[Constants.KEY_TECHNICAL];
        }

        private static string getNumAdq(XmlNode nodeR, XmlNamespaceManager xmlnsMgr)
        {
            return nodeR.SelectSingleNode(Constants.XPATH_ADQ, xmlnsMgr).InnerText;
        }

        private static string getTypeAdq(XmlNode nodeR, XmlNamespaceManager xmlnsMgr)
        {
            return nodeR.SelectSingleNode(Constants.XPATH_TYPE_ADQ, xmlnsMgr).InnerText;
        }

        private static string getNitOFE(XmlNode nodeR, XmlNamespaceManager xmlnsMgr)
        {
            return nodeR.SelectSingleNode(Constants.XPATH_NIT, xmlnsMgr).InnerText;
        }

        private static string getValImp(XmlNode nodeR, XmlNamespaceManager xmlnsMgr)
        {
            try
            {
                return nodeR.SelectSingleNode(Constants.XPATH_PAYABLE_AMOUNT, xmlnsMgr).InnerText;
            }
            catch { return Constants.VALUE_DEFAULT; }
        }

        private static string getValImp3(XmlNode nodeR, XmlNamespaceManager xmlnsMgr)
        {
            try
            {
                return nodeR.SelectSingleNode(Constants.XPATH_TAX_AMOUNT_THREE, xmlnsMgr).InnerText;
            }
            catch { return Constants.VALUE_DEFAULT; }
        }

        private static string getCodImp3(XmlNode nodeR, XmlNamespaceManager xmlnsMgr)
        {
            try
            {
                return nodeR.SelectSingleNode(Constants.XPATH_TAX_CATEGORY_THREE, xmlnsMgr).InnerText;
            }
            catch { return Constants.VALUE_COD_THREE_DEFAULT; }
        }

        private static string getValImp2(XmlNode nodeR, XmlNamespaceManager xmlnsMgr)
        {
            try
            {
                return nodeR.SelectSingleNode(Constants.XPATH_TAX_AMOUNT_TWO, xmlnsMgr).InnerText;
            }
            catch { return Constants.VALUE_DEFAULT; }
        }

        private static string getCodImp2(XmlNode nodeR, XmlNamespaceManager xmlnsMgr)
        {
            try
            {
                return nodeR.SelectSingleNode(Constants.XPATH_TAX_CATEGORY_TWO, xmlnsMgr).InnerText;
            }
            catch { return Constants.VALUE_COD_TWO_DEFAULT; }
        }

        private static string getValImp1(XmlNode nodeR, XmlNamespaceManager xmlnsMgr)
        {
            try
            {
                return nodeR.SelectSingleNode(Constants.XPATH_TAX_AMOUNT_ONE, xmlnsMgr).InnerText;
            }
            catch { return Constants.VALUE_DEFAULT; }
        }

        private static string getCodImp1(XmlNode nodeR, XmlNamespaceManager xmlnsMgr)
        {
            try
            {
                return nodeR.SelectSingleNode(Constants.XPATH_TAX_CATEGORY_ONE, xmlnsMgr).InnerText;
            }
            catch { return Constants.VALUE_COD_ONE_DEFAULT; }
        }

        private static string getValFac(XmlNode nodeR, XmlNamespaceManager xmlnsMgr)
        {
            try
            {
                return nodeR.SelectSingleNode(Constants.XPATH_LINE_EXTENSION_AMOUNT, xmlnsMgr).InnerText;
            }
            catch { return Constants.VALUE_DEFAULT; }
        }

        private static string getFecFac(XmlNode nodeR, XmlNamespaceManager xmlnsMgr)
        {
            string date = nodeR.SelectSingleNode(Constants.XPATH_ISSUE_DATE, xmlnsMgr).InnerText;
            string time = nodeR.SelectSingleNode(Constants.XPATH_ISSUE_TIME, xmlnsMgr).InnerText;
            string datetime = date + time;
            string ret = "";
            foreach (char c in datetime)
            {
                if (c != ':' && c != '-')
                    ret += c;
            }
            return ret;
        }

        private static string CalculateCUFE(string NumFac, string FecFac, string ValFac, string CodImp1, string ValImp1,
                                            string CodImp2, string ValImp2, string CodImp3, string ValImp3, string ValImp,
                                            string NitOFE, string TipAdq, string NumAdq, string ClTec)
        {
            string CUFE = NumFac + FecFac + ValFac + CodImp1 + ValImp1 + CodImp2 + ValImp2 + CodImp3 + ValImp3 + ValImp +
                            NitOFE + TipAdq + NumAdq + ClTec;

            return SHA1HashStringForUTF8String(CUFE);
        }

        public static string SHA1HashStringForUTF8String(string s)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(s);

            var sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);

            return HexStringFromBytes(hashBytes);
        }

        private static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }

    }
}
