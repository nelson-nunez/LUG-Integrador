using Abstraccion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Convocatoria = BE.Convocatoria;

namespace LUGIntegrador
{
    public class LINQtoXML : IXmlOperable<Convocatoria>
    {
        private readonly string filePath;

        public LINQtoXML()
        {
            filePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Convocatorias.XML");
        }

        public bool Existe(Convocatoria item)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(filePath);
                var query = from element in xmlDoc.Descendants(nameof(Convocatoria))
                            where element.Attribute("ID").Value == item.Id.ToString()
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
                    new XComment("Registro de Convocatorias."),
                    new XElement("Convocatorias",
                        lista.Select(convocatoria =>
                            new XElement("Convocatoria",
                                new XAttribute("ID", convocatoria.Id.ToString()),
                                new XElement("Posicion", convocatoria.Posicion),
                                new XElement("Confirmacion", convocatoria.Confirmacion),
                                new XElement("Fecha", convocatoria.Fecha),
                                new XElement("Duracion", convocatoria.Duracion.ToString()),
                                new XElement("Ubicacion", convocatoria.Ubicacion),
                                new XElement("JugadorId", convocatoria.Jugador?.Id),
                                new XElement("PartidoId", convocatoria.Partido?.Id)
                            )
                        )
                    )
                );

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
                XDocument xmlDoc = XDocument.Load(filePath);
                var consulta =
                    from element in xmlDoc.Descendants("Convocatoria")
                    select new Convocatoria(
                        Convert.ToInt64(element.Attribute("ID").Value),
                        element.Element("Posicion").Value,
                        Convert.ToBoolean(element.Element("Confirmacion").Value),
                        Convert.ToDateTime(element.Element("Fecha").Value),
                        TimeSpan.Parse(element.Element("Duracion").Value),
                        element.Element("Ubicacion").Value,
                        null, // Assuming you will set Jugador and Partido objects later
                        null
                    );

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
                    new XElement("JugadorId", convocatoria.Jugador?.Id),
                    new XElement("PartidoId", convocatoria.Partido?.Id));

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
