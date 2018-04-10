using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Model
{
    
    //public enum RoomNumber
    //{
    //    Room_101,
    //    Room_102,
    //    Room_103,
    //    Room_104,
    //    Room_201,
    //    Room_202,
    //    Room_203,
    //    Room_204,
    //    Room_301,
    //    Room_302,
    //    Room_303,
    //    Room_304
    //}

    public abstract class Room
    {
        private string roomID;
        private int roomNumber;

        public string RoomID { get => roomID; set => roomID = value; }
        public int RoomNumber { get => roomNumber; set => roomNumber = value; }

    }
}
