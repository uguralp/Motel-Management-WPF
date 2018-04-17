﻿using System;

namespace MM.Model
{
    [Serializable]
    public class Reservation
    {
        private Guid reservationID;
        private Guest guest;
        private int numberOfAdult;
        private int numberOfChild;
        private string roomType;
        private int roomNumber;
        private DateTime? checkIn;
        private DateTime? checkOut;       
        
        public Reservation()
        {
            reservationID = Guid.NewGuid();
            Guest = new Guest();
        }

        public Reservation(int numberOfAdult, int numberOfChild, DateTime checkIn, DateTime checkOut)
        {
            this.numberOfAdult = numberOfAdult;
            this.numberOfChild = numberOfChild;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
        }

        public Guid ReservationID { get => reservationID; set => reservationID = value; }
        public int NumberOfAdult { get => numberOfAdult; set => numberOfAdult = value; }
        public int NumberOfChild { get => numberOfChild; set => numberOfChild = value; }
        public DateTime? CheckIn { get => checkIn; set => checkIn = value; }
        public DateTime? CheckOut { get => checkOut; set => checkOut = value; }
        public Guest Guest { get => guest; set => guest = value; }
        public string RoomType { get => roomType; set => roomType = value; }
        public int RoomNumber { get => roomNumber; set => roomNumber = value; }
    }


}
