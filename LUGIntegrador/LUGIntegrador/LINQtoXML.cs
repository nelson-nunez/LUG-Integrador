using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Convocatoria = BE.Convocatoria;

namespace LUGIntegrador
{
    public class LINQtoXML<Convocatoria> : IXmlOperable<Convocatoria>
    {
        private readonly string filePath;

        public LINQtoXML(string filePath)
        {
            this.filePath = filePath;
        }

        public bool Existe(Convocatoria item)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(filePath);
                var query = from element in xmlDoc.Descendants(typeof(Convocatoria).Name)
                            where element.Attribute("ID").Value == ((dynamic)item).Id.ToString()
                            select element;
                return query.Any();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la existencia en el archivo XML.", ex);
            }
        }

        public bool CrearArchivo(List<Convocatoria> lista)
        {
            try
            {
                XDocument xmlDoc = new XDocument(
                    new XDeclaration("1.0", "UTF-8", "yes"),
                    new XComment("Registro de Convocatorias."));

                XElement root = new XElement("Convocatorias");

                foreach (var convocatoria in lista)
                {
                    XElement element = new XElement("Convocatoria",
                        new XAttribute("ID", convocatoria.Id.ToString()),
                        new XElement("Posicion", convocatoria.Posicion),
                        new XElement("Confirmacion", convocatoria.Confirmacion),
                        new XElement("Fecha", convocatoria.Fecha),
                        new XElement("Duracion", convocatoria.Duracion.ToString()),
                        new XElement("Ubicacion", convocatoria.Ubicacion),
                        new XElement("JugadorId", convocatoria.JugadorId),
                        new XElement("PartidoId", convocatoria.PartidoId));

                    root.Add(element);
                }

                xmlDoc.Add(root);
                xmlDoc.Save(filePath);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el archivo XML de Convocatorias.", ex);
            }
        }

        public List<Convocatoria> LeerArchivo()
        {
            try
            {
                var consulta =
                    from element in XElement.Load(filePath).Elements("Convocatoria")
                    select new Convocatoria
                    {
                        Id = Convert.ToInt64(element.Attribute("ID").Value),
                        Posicion = element.Element("Posicion").Value,
                        Confirmacion = Convert.ToBoolean(element.Element("Confirmacion").Value),
                        Fecha = Convert.ToDateTime(element.Element("Fecha").Value),
                        Duracion = TimeSpan.Parse(element.Element("Duracion").Value),
                        Ubicacion = element.Element("Ubicacion").Value,
                        JugadorId = Convert.ToInt64(element.Element("JugadorId").Value),
                        PartidoId = Convert.ToInt64(element.Element("PartidoId").Value)
                    };

                return consulta.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer el archivo XML de Convocatorias.", ex);
            }
        }

        public void AgregarLinea(Convocatoria convocatoria)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(filePath);

                XElement element = new XElement("Convocatoria",
                    new XAttribute("ID", convocatoria.Id.ToString()),
                    new XElement("Posicion", convocatoria.Posicion),
                    new XElement("Confirmacion", convocatoria.Confirmacion),
                    new XElement("Fecha", convocatoria.Fecha),
                    new XElement("Duracion", convocatoria.Duracion.ToString()),
                    new XElement("Ubicacion", convocatoria.Ubicacion),
                    new XElement("JugadorId", convocatoria.JugadorId),
                    new XElement("PartidoId", convocatoria.PartidoId));

                xmlDoc.Element("Convocatorias").Add(element);

                xmlDoc.Save(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar una línea al archivo XML de Convocatorias.", ex);
            }
        }

        public void BorrarLinea(Convocatoria convocatoria)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(filePath);

                var query = from element in xmlDoc.Descendants("Convocatoria")
                            where element.Attribute("ID").Value == convocatoria.Id.ToString()
                            select element;

                query.Remove();
                xmlDoc.Save(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al borrar una línea del archivo XML de Convocatorias.", ex);
            }
        }
    }
}
