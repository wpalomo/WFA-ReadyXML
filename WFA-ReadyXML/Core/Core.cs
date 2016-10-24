using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Configuration;

namespace WFAReadyXML
{
    public static class Core
    {
        public static int IniciarProcesoZip(
            bool firma, 
            bool cufe, 
            bool zip,
            string pathXML,
            int typeDoc,
            string flag_masivo)
        {
            if (flag_masivo != Constants.FLAG_OK)
                EditXML.editFile(new FileInfo(pathXML), typeDoc);

            string pathXMLNew = CommonMethods.newXML(pathXML, typeDoc);
            FileInfo file = new FileInfo(pathXMLNew);

            if (cufe) 
            {
                if (CUFE.AddingCUFEXML(file, typeDoc) != Constants.PROCESS_CORE_COD_OK)
                    return Constants.PROCESS_CORE_COD_ERROR_CUFE;
            }

            if (firma) 
            {
                if (SignXML.signJAVA(file.FullName, file.FullName, typeDoc) != 0)
                    return Constants.PROCESS_CORE_COD_ERROR_FIRMA;
            }

            if (zip)
                {
                if (ZipXML.CreateZIP(ZipXML.createZipName(file), file.FullName, file.DirectoryName) != 0)
                    return Constants.PROCESS_CORE_COD_ERROR_ZIP;
            }

            return Constants.PROCESS_CORE_COD_OK;
        }


        public static string EnviarZIP(string pathXML, int typeDoc) 
        {
            string pathXMLNew = CommonMethods.createSaveXMLName(pathXML, typeDoc);

            Connection c = new Connection();
            Connection.setParameters(c, pathXMLNew, typeDoc);

            return c.Send();
        }

        public static int ProcesoEnvioZIP(
            bool firma,
            bool cufe,
            bool zip, 
            string pathZIP, 
            int typeDoc) 
        {
            try
            {
                int fError = 0;
                string eError = "";
                ZipXML.unZip(pathZIP);

                string directory = ConfigurationManager.AppSettings[Constants.SAVE_EXTRACT_DOCUMENTS_DIRECTORY];
                FileInfo[] archivos = new DirectoryInfo(directory).GetFiles(Constants.FILTER_FILE_XML);
                
                foreach (FileInfo archivo in archivos)
                {
                    EditXML.editFile(archivo, typeDoc);

                    fError = IniciarProcesoZip(firma, cufe, zip, archivo.FullName, typeDoc, Constants.FLAG_OK);
                    if (fError != Constants.PROCESS_CORE_COD_OK)
                        return fError;

                    eError = EnviarZIP(archivo.FullName, typeDoc);
                    archivo.Delete();

                    if (eError == Constants.PROCESS_SEND_STRING_ERROR)
                        return Constants.PROCESS_SEND_COD_ERROR;
                }

                return Constants.PROCESS_CORE_COD_OK;
            }
            catch (Exception e) { return Constants.PROCESS_CORE_COD_ERROR; }

        }
    }
}
