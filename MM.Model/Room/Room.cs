using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MM.Model;

namespace MM.Model
{
    

    public class Room
    {
        private int roomID;
        private int roomNumber;

        public int RoomID { get => roomID; set => roomID = value; }
        public int RoomNumber { get => roomNumber; set => roomNumber = value; }

        public Room() { }

        public Room(int RoomID, int RoomNumber)
        {
            this.RoomID = RoomID;
            this.RoomNumber = RoomNumber;
        }
    }


}
