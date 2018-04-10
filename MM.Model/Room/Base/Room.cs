using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MM.Model
{
    [Serializable]
    [XmlInclude(typeof(DoubleRoom))]
    [XmlInclude(typeof(GuestRoom))]
    [XmlInclude(typeof(KingRoom))]
    [XmlInclude(typeof(QueenRoom))]
    [XmlInclude(typeof(SingleRoom))]
    [XmlInclude(typeof(SuiteRoom))]
    public abstract class Room
    {
        private string roomID;
        private int roomNumber;

        public string RoomID { get => roomID; set => roomID = value; }
        public int RoomNumber { get => roomNumber; set => roomNumber = value; }

    }
}
