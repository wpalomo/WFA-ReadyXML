using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace WFAReadyXML
{
    public static class Constants
    {
        public const string OVERWRITE_DOCUMENTS_DIRECTORY = "OVERWRITE_DOCUMENTS_DIRECTORY";
        public const string FLAG_OK = "1";

        public const int INVOICE_STRING_FIRMA_ID = 1;
        public const int CREDITNOTE_STRING_FIRMA_ID = 2;
        public const int DEBITNOTE_STRING_FIRMA_ID = 3;

        public const string INVOICE_STRING_FIRMA = "/fe:Invoice/ext:UBLExtensions/ext:UBLExtension[2]/ext:ExtensionContent";
        public const string CREDITNOTE_STRING_FIRMA = "/fe:CreditNote/ext:UBLExtensions/ext:UBLExtension[2]/ext:ExtensionContent";
        public const string DEBITNOTE_STRING_FIRMA = "/fe:DebitNote/ext:UBLExtensions/ext:UBLExtension[2]/ext:ExtensionContent";
        public const string VALUE_DEFAULT = "0.00";
        public const string VALUE_COD_ONE_DEFAULT = "01";
        public const string VALUE_COD_TWO_DEFAULT = "02";
        public const string VALUE_COD_THREE_DEFAULT = "03";

        public const string XPATH_EXTCONT_SIGN_INVOICE = "/fe:Invoice/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent";
        public const string XPATH_UBL_EXTENSIONS_INVOICE = "/fe:Invoice/ext:UBLExtensions";

        public const string XPATH_EXTCONT_SIGN_CREDITNOTE = "/fe:CreditNote/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent";
        public const string XPATH_UBL_EXTENSIONS_CREDITNOTE = "/fe:CreditNote/ext:UBLExtensions";

        public const string XPATH_EXTCONT_SIGN_DEBITNOTE = "/fe:DebitNote/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent";
        public const string XPATH_UBL_EXTENSIONS_DEBITNOTE = "/fe:DebitNote/ext:UBLExtensions";

        //XPATH xml type invoice
        public const string XPATH_CUFE_INVOICE = "/fe:Invoice/cbc:UUID";
        public const string XPATH_NIT_INVOICE = "/fe:Invoice/fe:AccountingSupplierParty/fe:Party/cac:PartyIdentification/cbc:ID";
        public const string XPATH_ADQ_INVOICE = "fe:Invoice/fe:AccountingCustomerParty/fe:Party/cac:PartyIdentification/cbc:ID";
        public const string XPATH_NUMBER_INVOICE = "/fe:Invoice/cbc:ID";
        public const string XPATH_DATE_INVOICE = "/fe:Invoice/cbc:IssueDate";
        public const string XPATH_HOUR_INVOICE = "/fe:Invoice/cbc:IssueTime";
        public const string XPATH_SIGN_INVOICE = "/fe:Invoice/ext:UBLExtensions/ext:UBLExtension[2]/ext:ExtensionContent/ds:Signature";
        public const string XPATH_PAYABLE_AMOUNT_INVOICE = "/fe:Invoice/fe:LegalMonetaryTotal/cbc:PayableAmount";
        public const string XPATH_LINE_EXTENSION_AMOUNT_INVOICE = "/fe:Invoice/fe:LegalMonetaryTotal/cbc:LineExtensionAmount";
        public const string XPATH_TAX_AMOUNT_ONE_INVOICE = "/fe:Invoice/fe:TaxTotal[1]/fe:TaxSubtotal/cbc:TaxAmount";
        public const string XPATH_TAX_CATEGORY_ONE_INVOICE = "/fe:Invoice/fe:TaxTotal[1]/fe:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:ID";
        public const string XPATH_TAX_AMOUNT_TWO_INVOICE = "/fe:Invoice/fe:TaxTotal[2]/fe:TaxSubtotal/cbc:TaxAmount";
        public const string XPATH_TAX_CATEGORY_TWO_INVOICE = "/fe:Invoice/fe:TaxTotal[2]/fe:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:ID";
        public const string XPATH_TAX_AMOUNT_THREE_INVOICE = "/fe:Invoice/fe:TaxTotal[3]/fe:TaxSubtotal/cbc:TaxAmount";
        public const string XPATH_TAX_CATEGORY_THREE_INVOICE = "/fe:Invoice/fe:TaxTotal[3]/fe:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:ID";
        public const string XPATH_ISSUE_DATE_INVOICE = "fe:Invoice/cbc:IssueDate";
        public const string XPATH_ISSUE_TIME_INVOICE = "fe:Invoice/cbc:IssueTime";
        public const string XPATH_TYPE_ADQ_INVOICE = "/fe:Invoice/fe:AccountingCustomerParty/fe:Party/cac:PartyIdentification/cbc:ID/@schemeID";

        //XPATH xml type note debit
        public const string XPATH_NIT_DEBITNOTE = "/fe:DebitNote/fe:AccountingSupplierParty/fe:Party/cac:PartyIdentification/cbc:ID";
        public const string XPATH_NUMBER_DEBITNOTE = "/fe:DebitNote/cbc:ID";
        public const string XPATH_DATE_DEBITNOTE = "/fe:DebitNote/cbc:IssueDate";
        public const string XPATH_HOUR_DEBITNOTE = "/fe:DebitNote/cbc:IssueTime";
        public const string XPATH_SIGN_DEBITNOTE = "/fe:DebitNote/ext:UBLExtensions/ext:UBLExtension[2]/ext:ExtensionContent/ds:Signature";

        //XPATH xml type note credit
        public const string XPATH_NIT_CREDITNOTE = "/fe:CreditNote/fe:AccountingSupplierParty/fe:Party/cac:PartyIdentification/cbc:ID";
        public const string XPATH_NUMBER_CREDITNOTE = "/fe:CreditNote/cbc:ID";
        public const string XPATH_DATE_CREDITNOTE = "/fe:CreditNote/cbc:IssueDate";
        public const string XPATH_HOUR_CREDITNOTE = "/fe:CreditNote/cbc:IssueTime";
        public const string XPATH_SIGN_CREDITNOTE = "/fe:CreditNote/ext:UBLExtensions/ext:UBLExtension[2]/ext:ExtensionContent/ds:Signature";


        //XPATH xml type generic
        public const string XPATH_CUFE = "cbc:UUID";
        public const string XPATH_NIT = "fe:AccountingSupplierParty/fe:Party/cac:PartyIdentification/cbc:ID";
        public const string XPATH_ADQ = "fe:AccountingCustomerParty/fe:Party/cac:PartyIdentification/cbc:ID";
        public const string XPATH_NUMBER = "cbc:ID";
        public const string XPATH_DATE = "cbc:IssueDate";
        public const string XPATH_HOUR = "cbc:IssueTime";
        public const string XPATH_SIGN = "ext:UBLExtensions/ext:UBLExtension[2]/ext:ExtensionContent/ds:Signature";
        public const string XPATH_PAYABLE_AMOUNT = "fe:LegalMonetaryTotal/cbc:PayableAmount";
        public const string XPATH_LINE_EXTENSION_AMOUNT = "fe:LegalMonetaryTotal/cbc:LineExtensionAmount";
        public const string XPATH_TAX_AMOUNT_ONE = "fe:TaxTotal[1]/fe:TaxSubtotal/cbc:TaxAmount";
        public const string XPATH_TAX_CATEGORY_ONE = "fe:TaxTotal[1]/fe:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:ID";
        public const string XPATH_TAX_AMOUNT_TWO = "fe:TaxTotal[2]/fe:TaxSubtotal/cbc:TaxAmount";
        public const string XPATH_TAX_CATEGORY_TWO = "fe:TaxTotal[2]/fe:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:ID";
        public const string XPATH_TAX_AMOUNT_THREE = "fe:TaxTotal[3]/fe:TaxSubtotal/cbc:TaxAmount";
        public const string XPATH_TAX_CATEGORY_THREE = "fe:TaxTotal[3]/fe:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:ID";
        public const string XPATH_ISSUE_DATE = "cbc:IssueDate";
        public const string XPATH_ISSUE_TIME = "cbc:IssueTime";
        public const string XPATH_TYPE_ADQ = "fe:AccountingCustomerParty/fe:Party/cac:PartyIdentification/cbc:ID/@schemeID";



        //Add to web.config
        public const string URL_WEBSERVICE_DIAN = "URL_WEBSERVICE_DIAN";
        public const string USER_WEBSERVICE_DIAN = "USER_WEBSERVICE_DIAN";
        public const string PASSWORD_WEBSERVICE_DIAN = "PASSWORD_WEBSERVICE_DIAN";
        public const string SAVE_EXTRACT_DOCUMENTS_DIRECTORY = "SAVE_EXTRACT_DOCUMENTS_DIRECTORY";
        public const string PATH_JAVA_EXE = "PATH_JAVA_EXE";
        public const string COMMAND_EXECUTE_JAVA_SEND = "COMMAND_EXECUTE_JAVA_SEND";
        public const string COMMAND_EXECUTE_JAVA_SIGN = "COMMAND_EXECUTE_JAVA_SIGN";
        public const string WORKING_DIRECTORY = "WORKING_DIRECTORY";
        public const string TIMEOUT = "TIMEOUT";
        public const string SAVE_DOCUMENTS_DIRECTORY = "SAVE_DOCUMENTS_DIRECTORY";
        public const string CLAIMED_ROL_SIGN = "CLAIMED_ROL_SIGN";

        public const string IDENTIFICATION_CODE = "IDENTIFICATION_CODE";
        public const string INVOICE_AUTHORIZATION = "INVOICE_AUTHORIZATION";
        public const string START_DATE = "START_DATE";
        public const string END_DATE = "END_DATE";
        public const string FROM = "FROM";
        public const string TO = "TO";
        public const string PREFIX = "PREFIX";
        public const string PROVIDER_ID = "PROVIDER_ID";
        public const string SOFTWARE_ID = "SOFTWARE_ID";
        public const string SOFTWARE_SECURITY_CODE = "SOFTWARE_SECURITY_CODE";
        public const string KEY_TECHNICAL = "KEY_TECHNICAL";
        public const string DOC_DATE = "DOC_DATE";
        public const string DOC_TIME = "DOC_TIME";
        public const string ID_INIT_AUTOINCR = "ID_INIT_AUTOINCR";

        public const string SET_DATETIME = "SET_DATETIME";
        public const string ID_AUTOINCR = "ID_AUTOINCR";
        public const string SET_IDENTIFICATION_CODE = "SET_IDENTIFICATION_CODE";
        public const string SET_INVOICE_CONTROL = "SET_INVOICE_CONTROL";
        public const string SET_INVOICE_SOURCE = "SET_INVOICE_SOURCE";
        public const string SET_SOFTWARE_PROVIDER = "SET_SOFTWARE_PROVIDER";
        public const string SET_SOFTWARE_SECURITY_CODE = "SET_SOFTWARE_SECURITY_CODE";

        public const string PROCESS_CORE_OK = "Proceso finalizado correctamente";
        public const string PROCESS_CORE_ERROR_MSG = "Error en proceso";
        public const string PROCESS_CORE_ERROR_FIRMA_MSG = "Error en proceso de Firma";
        public const string PROCESS_CORE_ERROR_ZIP_MSG = "Error en proceso de Compresión";
        public const string PROCESS_CORE_ERROR_CUFE_MSG = "Error en proceso de CUFE";
        public const string PROCESS_SEND_STRING_ERROR_MSG = "Se ha producido un error al intentar enviar un documento";
        public const string PROCESS_CORE_ERROR_PARAM_MSG = "Chequee parametros ingresados";
        public const string PROCESS_ERROR_NOT_ZIP_MSG = "Se debe zipear archivo";
        public const string PROCESS_TYPE_EXT_ERROR_MGS = "Error en extencion de archivo, para proceso debe ser .XML";
        public const int PROCESS_CORE_COD_OK = 0;
        public const int PROCESS_CORE_COD_ERROR = 1;
        public const int PROCESS_CORE_COD_OK_FIRMA = 0;
        public const int PROCESS_CORE_COD_ERROR_FIRMA = 2;
        public const int PROCESS_CORE_COD_OK_ZIP = 0;
        public const int PROCESS_CORE_COD_ERROR_ZIP = 3;
        public const int PROCESS_CORE_COD_OK_CUFE = 0;
        public const int PROCESS_CORE_COD_ERROR_CUFE = 4;
        public const int PROCESS_CORE_COD_ERROR_PARAM = 5;

        public const string PROCESS_SEND_STRING_ERROR = "";
        public const int PROCESS_SEND_COD_ERROR = 6;

        public const int PROCESS_TYPE_EXT_ERROR = 7;
        //Const for form
        public const string MSG_FORM_OK = "Aviso";
        public const string MSG_FORM_ERROR = "Error";

        //Const filter files
        public const string FILTER_FILE_PROCESS = "All files ( *.xml, *.zip ) | *.xml;*.zip";
        public const string FILTER_FILE_XML = "*.xml";

        public static int INIT_AUTOINCR = int.Parse(ConfigurationManager.AppSettings[ID_INIT_AUTOINCR]);
    }
}
