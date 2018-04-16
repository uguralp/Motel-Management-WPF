using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MM.Model
{
    public enum RoomTypeName
    {
        Guest,
        Single,
        Double,
        Twin,
        Adjoining,
        Suite,
        King,
        Queen
    }

    [Serializable]
    [XmlInclude(typeof(DoubleRoom))]
    [XmlInclude(typeof(GuestRoom))]
    [XmlInclude(typeof(KingRoom))]
    [XmlInclude(typeof(QueenRoom))]
    [XmlInclude(typeof(SingleRoom))]
    [XmlInclude(typeof(SuiteRoom))]
    public abstract class RoomType
    {
        private int roomTypeID;
        private string roomTypeName;
        private List<Room> rooms;

        public int RoomTypeID { get => roomTypeID; set => roomTypeID = value; }
        public string RoomTypeName { get => roomTypeName; set => roomTypeName = value; }
        public List<Room> Rooms { get => rooms; set => rooms = value; }

        public abstract void Laundry();
        public abstract void DryCleaning();
        public abstract void Fitness();
    }
}
