using System;

namespace MM.Model
{
    [Serializable]
    public class Reservation
    {
        private Guest guest;
        private int numberOfAdult;
        private int numberOfChild;
        private string roomType;
        private Room room;
        private DateTime? checkIn;
        private DateTime? checkOut;       
        
        public Reservation()
        {
            Guest = new Guest();
        }

        public Reservation(int numberOfAdult, int numberOfChild, DateTime checkIn, DateTime checkOut)
        {
            this.numberOfAdult = numberOfAdult;
            this.numberOfChild = numberOfChild;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
        }

        public int NumberOfAdult { get => numberOfAdult; set => numberOfAdult = value; }
        public int NumberOfChild { get => numberOfChild; set => numberOfChild = value; }
        public DateTime? CheckIn { get => checkIn; set => checkIn = value; }
        public DateTime? CheckOut { get => checkOut; set => checkOut = value; }
        public Guest Guest { get => guest; set => guest = value; }
        public string RoomType { get => roomType; set => roomType = value; }
        public Room Room { get => room; set => room = value; }
    }


}
