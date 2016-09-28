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

        private static void addUUID(string pathXML)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(pathXML);
            XmlNamespaceManager xmlnsMgr = CommonMethods.getNamespacesManager(doc);

            XmlNode root = doc.SelectSingleNode("/fe:Invoice", xmlnsMgr);

            if (doc.SelectNodes("/fe:Invoice/cbc:UUID", xmlnsMgr).Count < 1)
            {
                XmlNode childRef = doc.SelectSingleNode("/fe:Invoice/cbc:ID", xmlnsMgr);

                //Create a new node.
                XmlElement elem = doc.CreateElement("cbc", "UUID", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                elem.SetAttribute("schemeAgencyID", "195");
                elem.SetAttribute("schemeAgencyName", "CO, DIAN (Direccion de Impuestos y Aduanas Nacionales)");
                //Add the node to the document.
                root.InsertAfter(elem, childRef);

                doc.Save(pathXML);
            }

        }

        public static void AddingCUFEXML(FileInfo file, int typeDoc) 
        {
            addUUID(file.FullName);

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(file.FullName);


            var nsm = CommonMethods.getNamespacesManager(xmlDocument);

            string NumAdq = getNumAdq(xmlDocument, nsm, typeDoc);
            string NumFac = getNumFac(xmlDocument, nsm, typeDoc);
            string FecFac = getFecFac(xmlDocument, nsm, typeDoc);
            string ValFac = getValFac(xmlDocument, nsm, typeDoc);
            string CodImp1 = getCodImp1(xmlDocument, nsm, typeDoc);
            string ValImp1 = getValImp1(xmlDocument, nsm, typeDoc);
            string CodImp2 = getCodImp2(xmlDocument, nsm, typeDoc);
            string ValImp2 = getValImp2(xmlDocument, nsm, typeDoc);
            string CodImp3 = getCodImp3(xmlDocument, nsm, typeDoc);
            string ValImp3 = getValImp3(xmlDocument, nsm, typeDoc);
            string ValImp = getValImp(xmlDocument, nsm, typeDoc);
            string NitOFE = getNitOFE(xmlDocument, nsm, typeDoc);
            string TipAdq = getTypeAdq(xmlDocument, nsm, typeDoc);
            string ClTec = getClTec(xmlDocument, nsm, typeDoc);

            string CUFE = CalculateCUFE(NumFac, FecFac, ValFac, CodImp1, ValImp1,
                                        CodImp2, ValImp2, CodImp3, ValImp3, ValImp,
                                        NitOFE, TipAdq, NumAdq, ClTec);

            setCUFEXML(xmlDocument, nsm, CUFE, typeDoc);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(file.FullName, settings))
            {
                xmlDocument.Save(writer);
            }

        }

        private class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding { get { return Encoding.UTF8; } }
        }

        private static void setCUFEXML(XmlDocument xmlDocument, XmlNamespaceManager nsm, string CUFE, int typeDoc)
        {
            xmlDocument.SelectSingleNode(Constants.XPATH_CUFE_INVOICE, nsm).InnerText = CUFE;
        }

        private static string getNumFac(XmlDocument xmlDocument, XmlNamespaceManager nsm, int typeDoc)
        {
            return xmlDocument.SelectSingleNode(Constants.XPATH_NUMBER_INVOICE, nsm).InnerText;
       }

        private static string getClTec(XmlDocument xmlDocument, XmlNamespaceManager nsm, int typeDoc)
        {
            return ConfigurationManager.AppSettings[Constants.KEY_TECHNICAL];
        }

        private static string getNumAdq(XmlDocument xmlDocument, XmlNamespaceManager nsm, int typeDoc)
        {
            return xmlDocument.SelectSingleNode(Constants.XPATH_ADQ_INVOICE, nsm).InnerText;
        }

        private static string getTypeAdq(XmlDocument xmlDocument, XmlNamespaceManager nsm, int typeDoc)
        {
            return xmlDocument.SelectSingleNode(Constants.XPATH_TYPE_ADQ_INVOICE, nsm).InnerText;
        }

        private static string getNitOFE(XmlDocument xmlDocument, XmlNamespaceManager nsm, int typeDoc)
        {
            return xmlDocument.SelectSingleNode(Constants.XPATH_NIT_INVOICE, nsm).InnerText;
        }

        private static string getValImp(XmlDocument xmlDocument, XmlNamespaceManager nsm, int typeDoc)
        {
            try
            {
                return xmlDocument.SelectSingleNode(Constants.XPATH_PAYABLE_AMOUNT_INVOICE, nsm).InnerText;
            }
            catch { return Constants.VALUE_DEFAULT; }
        }

        private static string getValImp3(XmlDocument xmlDocument, XmlNamespaceManager nsm, int typeDoc)
        {
            try
            {
                return xmlDocument.SelectSingleNode(Constants.XPATH_TAX_AMOUNT_THREE_INVOICE, nsm).InnerText;
            }
            catch { return Constants.VALUE_DEFAULT; }
        }

        private static string getCodImp3(XmlDocument xmlDocument, XmlNamespaceManager nsm, int typeDoc)
        {
            try
            {
                return xmlDocument.SelectSingleNode(Constants.XPATH_TAX_CATEGORY_THREE_INVOICE, nsm).InnerText;
            }
            catch { return Constants.VALUE_COD_THREE_DEFAULT; }
        }

        private static string getValImp2(XmlDocument xmlDocument, XmlNamespaceManager nsm, int typeDoc)
        {
            try
            {
                return xmlDocument.SelectSingleNode(Constants.XPATH_TAX_AMOUNT_TWO_INVOICE, nsm).InnerText;
            }
            catch { return Constants.VALUE_DEFAULT; }
        }

        private static string getCodImp2(XmlDocument xmlDocument, XmlNamespaceManager nsm, int typeDoc)
        {
            try
            {
                return xmlDocument.SelectSingleNode(Constants.XPATH_TAX_CATEGORY_TWO_INVOICE, nsm).InnerText;
            }
            catch { return Constants.VALUE_COD_TWO_DEFAULT; }
        }

        private static string getValImp1(XmlDocument xmlDocument, XmlNamespaceManager nsm, int typeDoc)
        {
            try
            {
                return xmlDocument.SelectSingleNode(Constants.XPATH_TAX_AMOUNT_ONE_INVOICE, nsm).InnerText;
            }
            catch { return Constants.VALUE_DEFAULT; }
        }

        private static string getCodImp1(XmlDocument xmlDocument, XmlNamespaceManager nsm, int typeDoc)
        {
            try
            {
                return xmlDocument.SelectSingleNode(Constants.XPATH_TAX_CATEGORY_ONE_INVOICE, nsm).InnerText;
            }
            catch { return Constants.VALUE_COD_ONE_DEFAULT; }
        }

        private static string getValFac(XmlDocument xmlDocument, XmlNamespaceManager nsm, int typeDoc)
        {
            try
            {
                return xmlDocument.SelectSingleNode(Constants.XPATH_LINE_EXTENSION_AMOUNT_INVOICE, nsm).InnerText;
            }
            catch { return Constants.VALUE_DEFAULT; }
        }

        private static string getFecFac(XmlDocument xmlDocument, XmlNamespaceManager nsm, int typeDoc)
        {
            string date = xmlDocument.SelectSingleNode(Constants.XPATH_ISSUE_DATE_INVOICE, nsm).InnerText;
            string time = xmlDocument.SelectSingleNode(Constants.XPATH_ISSUE_TIME_INVOICE, nsm).InnerText;
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
