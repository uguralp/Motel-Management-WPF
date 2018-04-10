using System;
using System.IO;
using System.Xml.Serialization;
using MM.Model;

namespace MM.Utilities
{
    public static class XMLController
    {

        public static void ReadXML(string xmlFileName, ref ReservationList reservationList)
        {
            try
            {
                if (File.Exists(xmlFileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ReservationList));
                    StreamReader reader = new StreamReader(xmlFileName);
                    reservationList = (ReservationList)serializer.Deserialize(reader);
                    reader.Close();
                }
                else
                {
                    // Create xml file
                    TextWriter writer = new StreamWriter(xmlFileName);
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void WriteToXML(string xmlFileName, ReservationList reservationList)
        {
            XmlSerializer serializer = null;
            TextWriter writer = null;

            try
            {
                serializer = new XmlSerializer(typeof(ReservationList));
                writer = new StreamWriter(xmlFileName);
                serializer.Serialize(writer, reservationList);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                writer.Flush();
                writer.Close();
            }
        }

    }
}
