using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM.Model;

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

    public class RoomType
    {
        private int roomTypeID;
        private RoomTypeName roomTypeName;
        private List<Room> rooms;

        public int RoomTypeID { get => roomTypeID; set => roomTypeID = value; }
        public RoomTypeName RoomTypeName { get => roomTypeName; set => roomTypeName = value; }
        public List<Room> Rooms { get => rooms; set => rooms = value; }

        public RoomType()
        {
            Rooms = new List<Room>();
        }

        public RoomType(int RoomTypeID, RoomTypeName RoomTypeName, List<Room> Rooms)
        {
            this.RoomTypeID = RoomTypeID;
            this.RoomTypeName = RoomTypeName;
            this.Rooms = Rooms;
        }
    }


}
