using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WFAReadyXML
{
    public static class Constants
    {
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
        public const string XPATH_SIGN = "/fe:Invoice/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent";
        public const string XPATH_UBL_EXTENSIONS = "/fe:Invoice/ext:UBLExtensions";

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

        //Add to web.config
        public const string URL_WEBSERVICE_DIAN = "URL_WEBSERVICE_DIAN";
        public const string USER_WEBSERVICE_DIAN = "USER_WEBSERVICE_DIAN";
        public const string PASSWORD_WEBSERVICE_DIAN = "PASSWORD_WEBSERVICE_DIAN";

        public const string PATH_JAVA_EXE = "PATH_JAVA_EXE";
        public const string COMMAND_EXECUTE_JAVA_SEND = "COMMAND_EXECUTE_JAVA_SEND";
        public const string COMMAND_EXECUTE_JAVA_SIGN = "COMMAND_EXECUTE_JAVA_SIGN";
        public const string WORKING_DIRECTORY = "WORKING_DIRECTORY";
        public const string TIMEOUT = "TIMEOUT";
        public const string SAVE_DOCUMENTS_DIRECTORY = "SAVE_DOCUMENTS_DIRECTORY";
        public const string CLAIMED_ROL_SIGN = "CLAIMED_ROL_SIGN";
        public const string KEY_TECHNICAL = "KEY_TECHNICAL";
    }
}
