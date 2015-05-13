using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Modelo;
using System.Xml;
using System.Web.Hosting;
using System.IO;
using System.Xml.Linq;


namespace App.Datos
{
    public class PersonasRepositories
    {
        private static List<Cuentas> data = new List<Cuentas>();

        public List<Cuentas> getCuentas()
        {
            // Creamos la lista genérica de Personas
            List<Cuentas> lista = new List<Cuentas>();
            // Obtenemos la ruta de archivo XML
            string ruta = HttpContext.Current.Server.MapPath("/Datos/Cuentas.xml");

            XDocument doc = XDocument.Load(ruta);

            var people = from p in doc.Descendants("Cuentas") select p;

            foreach (XElement p in people.Elements("Cuentas"))
            {
                Cuentas person = new Cuentas(
                                                  p.Element("ID").Value,
                                                  p.Element("Nombres").Value,
                                                  p.Element("Apellidos").Value,
                                                  p.Element("EmailP").Value,
                                                  p.Element("EmailW").Value,
                                                  p.Element("TelefonoP").Value,
                                                  p.Element("TelefonoW").Value

                                              );
                lista.Add(person);

            }


            return lista;
        }

        public void add(Cuentas p)
        {
            data.Add(p);
            WriteXML(data);

        }

        private void WriteXML(List<Cuentas> list)
        {
            XmlTextWriter xmlwriter = new XmlTextWriter(HttpContext.Current.Server.MapPath("/Datos/Agenda.xml"), System.Text.Encoding.UTF8);

            //Inicio XML Documento
            xmlwriter.WriteStartDocument(true);
            xmlwriter.Formatting = Formatting.Indented;
            xmlwriter.Indentation = 2;

            //ROOT Element
            xmlwriter.WriteStartElement("Cuentas");
            //Call create nodes method
            foreach (Cuentas p in list)
            {
                xmlwriter.WriteStartElement("Persona");
                xmlwriter.WriteElementString("ID", p.Id);
                xmlwriter.WriteElementString("Nombres", p.Nombres);
                xmlwriter.WriteElementString("Apellidos", p.Apellidos);
                xmlwriter.WriteElementString("EmailP", p.EmailP);
                xmlwriter.WriteElementString("EmailW", p.EmailW);
                xmlwriter.WriteElementString("TelefonoP", p.TelefonoP);
                xmlwriter.WriteElementString("TelefonoW", p.TelefonoW);
                xmlwriter.WriteEndElement();
            }

            xmlwriter.WriteEndElement();

            //End XML Document
            xmlwriter.WriteEndDocument();

            //Close Write
            xmlwriter.Close();
        }

    }
}