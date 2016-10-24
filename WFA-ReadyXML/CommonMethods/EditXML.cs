using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Configuration;

namespace WFAReadyXML
{
    class EditXML
    {
        public static void editFile(FileInfo archivo, int typeDoc)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(archivo.FullName);
            string type = "";

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

            XmlNamespaceManager xmlnsMgr = CommonMethods.getNamespacesManager(doc);
            string urn = "http://www.dian.gov.co/contratos/facturaelectronica/v1/Structures";
            string cbc = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2";

            XmlNode rootDE = doc.SelectSingleNode("/fe:" + type + "/ext:UBLExtensions/ext:UBLExtension[1]/ext:ExtensionContent/sts:DianExtensions", xmlnsMgr);
            XmlNode rootIC;


            if (ConfigurationManager.AppSettings[Constants.SET_INVOICE_CONTROL] == Constants.FLAG_OK)
            {
                if (rootDE.SelectSingleNode("sts:InvoiceControl", xmlnsMgr) != null)
                {
                    rootIC = rootDE.SelectSingleNode("sts:InvoiceControl", xmlnsMgr);
                }
                else
                {
                    rootIC = doc.CreateElement("sts", "InvoiceControl", urn);
                    rootDE.PrependChild(rootIC);
                }



                if (rootDE.SelectSingleNode("sts:InvoiceControl/sts:InvoiceAuthorization", xmlnsMgr) != null)
                {
                    rootDE.SelectSingleNode("sts:InvoiceControl/sts:InvoiceAuthorization", xmlnsMgr).InnerText = 
                        ConfigurationManager.AppSettings[Constants.INVOICE_AUTHORIZATION];
                }
                else 
                {
                    XmlElement InvoiceAuthorization = doc.CreateElement("sts", "InvoiceAuthorization", urn);
                    InvoiceAuthorization.InnerText = ConfigurationManager.AppSettings[Constants.INVOICE_AUTHORIZATION];
                    rootIC.AppendChild(InvoiceAuthorization);
                }

                if (rootDE.SelectSingleNode("sts:InvoiceControl/sts:AuthorizationPeriod", xmlnsMgr) != null)
                {
                    rootDE.SelectSingleNode("sts:InvoiceControl/sts:AuthorizationPeriod/cbc:StartDate", xmlnsMgr).InnerText =
                        ConfigurationManager.AppSettings[Constants.START_DATE];
                    rootDE.SelectSingleNode("sts:InvoiceControl/sts:AuthorizationPeriod/cbc:EndDate", xmlnsMgr).InnerText =
                        ConfigurationManager.AppSettings[Constants.END_DATE];
                }
                else
                {
                    XmlElement AuthorizationPeriod = doc.CreateElement("sts", "AuthorizationPeriod", urn);
                    XmlElement StartDate = doc.CreateElement("cbc", "StartDate", cbc);
                    StartDate.InnerText = ConfigurationManager.AppSettings[Constants.START_DATE];
                    XmlElement EndDate = doc.CreateElement("cbc", "EndDate", cbc);
                    EndDate.InnerText = ConfigurationManager.AppSettings[Constants.END_DATE];
                    AuthorizationPeriod.AppendChild(StartDate);
                    AuthorizationPeriod.AppendChild(EndDate);
                    rootIC.AppendChild(AuthorizationPeriod);
                }

                if (rootDE.SelectSingleNode("sts:InvoiceControl/sts:AuthorizedInvoices", xmlnsMgr) != null)
                {
                    if (ConfigurationManager.AppSettings[Constants.PREFIX] != "")
                        rootDE.SelectSingleNode("sts:InvoiceControl/sts:AuthorizedInvoices/sts:Prefix", xmlnsMgr).InnerText =
                            ConfigurationManager.AppSettings[Constants.PREFIX];
                    rootDE.SelectSingleNode("sts:InvoiceControl/sts:AuthorizedInvoices/sts:From", xmlnsMgr).InnerText =
                        ConfigurationManager.AppSettings[Constants.FROM];
                    rootDE.SelectSingleNode("sts:InvoiceControl/sts:AuthorizedInvoices/sts:To", xmlnsMgr).InnerText =
                        ConfigurationManager.AppSettings[Constants.TO];
                }
                else
                {
                    XmlElement AuthorizedInvoices = doc.CreateElement("sts", "AuthorizedInvoices", urn);
                    XmlElement Prefix = doc.CreateElement("sts", "Prefix", urn);
                    if (ConfigurationManager.AppSettings[Constants.PREFIX] != "")
                        Prefix.InnerText = ConfigurationManager.AppSettings[Constants.PREFIX];
                    XmlElement From = doc.CreateElement("sts", "From", urn);
                    From.InnerText = ConfigurationManager.AppSettings[Constants.FROM];
                    XmlElement To = doc.CreateElement("sts", "To", urn);
                    To.InnerText = ConfigurationManager.AppSettings[Constants.TO];
                    AuthorizedInvoices.AppendChild(Prefix);
                    AuthorizedInvoices.AppendChild(From);
                    AuthorizedInvoices.AppendChild(To);
                    rootIC.AppendChild(AuthorizedInvoices);
                }
            }

            if (ConfigurationManager.AppSettings[Constants.SET_IDENTIFICATION_CODE] == Constants.FLAG_OK)
            {
                if (rootDE.SelectSingleNode("sts:InvoiceSource", xmlnsMgr) != null)
                {
                    rootDE.SelectSingleNode("sts:InvoiceSource/cbc:IdentificationCode", xmlnsMgr).InnerText =
                        ConfigurationManager.AppSettings[Constants.IDENTIFICATION_CODE];
                }
                else
                {
                    XmlNode InvoiceSource = doc.CreateElement("sts", "InvoiceSource", urn);
                    XmlElement IdentificationCode = doc.CreateElement("sts", "IdentificationCode", urn);
                    IdentificationCode.InnerText = ConfigurationManager.AppSettings[Constants.IDENTIFICATION_CODE];
                    IdentificationCode.SetAttribute("listAgencyID", "6");
                    IdentificationCode.SetAttribute("listAgencyName", "United Nations Economic Commission for Europe");
                    IdentificationCode.SetAttribute("listSchemeURI", "urn:oasis:names:specification:ubl:codelist:gc:CountryIdentificationCode-2.0");
                    InvoiceSource.AppendChild((XmlNode)IdentificationCode);
                    rootDE.AppendChild((XmlNode)InvoiceSource);
                }
            }

            if (ConfigurationManager.AppSettings[Constants.SET_SOFTWARE_PROVIDER] == Constants.FLAG_OK)
            {
                if (rootDE.SelectSingleNode("sts:SoftwareProvider", xmlnsMgr) != null)
                {
                    rootDE.SelectSingleNode("sts:SoftwareProvider/sts:ProviderID", xmlnsMgr).InnerText =
                        ConfigurationManager.AppSettings[Constants.PROVIDER_ID];
                    rootDE.SelectSingleNode("sts:SoftwareProvider/sts:SoftwareID", xmlnsMgr).InnerText =
                        ConfigurationManager.AppSettings[Constants.SOFTWARE_ID];
                }
                else
                {
                    XmlNode SoftwareProvider = doc.CreateElement("sts", "SoftwareProvider", urn);
                    XmlElement ProviderID = doc.CreateElement("sts", "ProviderID", urn);
                    ProviderID.InnerText = ConfigurationManager.AppSettings[Constants.PROVIDER_ID];
                    ProviderID.SetAttribute("schemeAgencyID", "195");
                    ProviderID.SetAttribute("schemeAgencyName", "CO, DIAN (Direccion de Impuestos y Aduanas Nacionales)");
                    XmlElement SoftwareID = doc.CreateElement("sts", "SoftwareID", urn);
                    SoftwareID.InnerText = ConfigurationManager.AppSettings[Constants.SOFTWARE_ID];
                    SoftwareID.SetAttribute("schemeAgencyID", "195");
                    SoftwareID.SetAttribute("schemeAgencyName", "CO, DIAN (Direccion de Impuestos y Aduanas Nacionales)");
                    SoftwareProvider.AppendChild((XmlNode)ProviderID);
                    SoftwareProvider.AppendChild((XmlNode)SoftwareID);
                    rootDE.AppendChild((XmlNode)SoftwareProvider);
                }
            }

            if (ConfigurationManager.AppSettings[Constants.SET_SOFTWARE_SECURITY_CODE] == Constants.FLAG_OK)
            {
                if (rootDE.SelectSingleNode("sts:SoftwareSecurityCode", xmlnsMgr) != null)
                {
                    rootDE.SelectSingleNode("sts:SoftwareSecurityCode", xmlnsMgr).InnerText =
                        ConfigurationManager.AppSettings[Constants.SOFTWARE_SECURITY_CODE];
                }
                else
                {
                    XmlElement SoftwareSecurityCode = doc.CreateElement("sts", "SoftwareSecurityCode", urn);
                    SoftwareSecurityCode.InnerText = ConfigurationManager.AppSettings[Constants.SOFTWARE_SECURITY_CODE];
                    SoftwareSecurityCode.SetAttribute("schemeAgencyID", "195");
                    SoftwareSecurityCode.SetAttribute("schemeAgencyName", "CO, DIAN (Direccion de Impuestos y Aduanas Nacionales)");
                    rootDE.AppendChild((XmlNode)SoftwareSecurityCode);
                }
            }

            if (ConfigurationManager.AppSettings[Constants.ID_AUTOINCR] == Constants.FLAG_OK)
            {
                XmlNode ID = doc.SelectSingleNode("/fe:" + type + "/cbc:ID", xmlnsMgr);
                string prefix = ConfigurationManager.AppSettings[Constants.PREFIX];
                ID.InnerText = prefix + Convert.ToString(Constants.INIT_AUTOINCR++);
            }

            if (ConfigurationManager.AppSettings[Constants.SET_DATETIME] == Constants.FLAG_OK)
            {
                XmlNode IssueDate = doc.SelectSingleNode("/fe:" + type + "/cbc:IssueDate", xmlnsMgr);
                IssueDate.InnerText = ConfigurationManager.AppSettings[Constants.DOC_DATE];
                XmlNode IssueTime = doc.SelectSingleNode("/fe:" + type + "/cbc:IssueTime", xmlnsMgr);
                IssueTime.InnerText = ConfigurationManager.AppSettings[Constants.DOC_TIME];
            }

            CommonMethods.saveXML(doc, archivo.FullName);
        }
    }
}
