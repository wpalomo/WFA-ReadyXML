using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace WFAReadyXML
{
    public static class Core
    {
        public static string iniciarProcesoZip(
            bool firma, 
            bool cufe, 
            bool zip,
            string pathXML,
            int typeDoc)
        {
            string pathXMLNew = CommonMethods.newXML(pathXML, typeDoc);
            FileInfo file = new FileInfo(pathXMLNew);

            if (cufe) 
            {
                CUFE.AddingCUFEXML(file, typeDoc);
            }

            if (firma) 
            {
                SignXML.signJAVA(file.FullName, file.FullName);
            }

            if (zip)
            {
                ZipXML.CreateZIP(ZipXML.createZipName(file), file.FullName, file.DirectoryName);
            }

            return "Proceso finalizado correctamente";
        }


        public static string enviarZIP(string pathXML, int typeDoc) 
        {
            string pathXMLNew = CommonMethods.newXML(pathXML, typeDoc);

            Connection c = new Connection();
            Connection.setParameters(c, pathXMLNew, typeDoc);

            return c.Send();
        }
    }
}
