﻿using System;
using System.IO;
using System.Xml.Serialization;
using MM.Model;

namespace MM.Utilities
{
    public static class XMLController
    {

        public static void ReadXML(ref ReservationList reservationList)
        {
            try
            {
                if (File.Exists(Common.XML_FILE_NAME))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ReservationList));
                    StreamReader reader = new StreamReader(Common.XML_FILE_NAME);
                    reservationList = (ReservationList)serializer.Deserialize(reader);
                    reader.Close();
                }
                else
                {
                    // Create xml file
                    TextWriter writer = new StreamWriter(Common.XML_FILE_NAME);
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void WriteToXML(ReservationList reservationList)
        {
            XmlSerializer serializer = null;
            TextWriter writer = null;

            try
            {
                serializer = new XmlSerializer(typeof(ReservationList));
                writer = new StreamWriter(Common.XML_FILE_NAME);
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
