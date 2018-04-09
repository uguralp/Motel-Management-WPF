using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model
{
    public enum RoomType {
        Guest_Room,
        Single_Room,
        Double_Room,
        Twin_Room,
        Adjoining_Room,
        Suite_Room,
        King_Bedroom,
        Queen_Bedroom
    }

    class Room
    {
        private string roomID;
        private int roomNumber;

        public string RoomID { get => roomID; set => roomID = value; }
        public int RoomNumber { get => roomNumber; set => roomNumber = value; }

    }
}
