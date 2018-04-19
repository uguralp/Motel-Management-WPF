using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace MM.Model
{
    /// <summary>
    /// Reservation
    /// </summary>
    [Serializable]
    public class Reservation : IDisposable, IDataErrorInfo, INotifyPropertyChanged
    {
        private Guid reservationID;
        private Guest guest;
        private int numberOfAdult;
        private int numberOfChild;
        private string checkIn;
        private string checkOut;        
        private decimal totalPrice;
        private string service;
        private int numberOfDay;
        private RoomType roomType;
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Reservation
        /// </summary>
        public Reservation()
        {
            CheckIn = DateTime.Today.ToLongDateString();
            CheckOut = DateTime.Today.ToLongDateString();
            NumberOfDay = 0;
            TotalPrice = 0;
            reservationID = Guid.NewGuid();
            Guest = new Guest();

            Room firstGuestRoom = new Room() { IsCheckedOut = false, RoomNumber = 101 };
            List<Room> listGuestRoom = new List<Room>();
            listGuestRoom.Add(firstGuestRoom);

            RoomType = new GuestRoom() { RoomTypeName = RoomTypeName.Guest.ToString(),  Rooms = listGuestRoom };
        }

        /// <summary>
        /// Reservation
        /// </summary>
        /// <param name="numberOfAdult"></param>
        /// <param name="numberOfChild"></param>
        /// <param name="checkIn"></param>
        /// <param name="checkOut"></param>
        public Reservation(int numberOfAdult, int numberOfChild, string checkIn, string checkOut)
        {
            this.numberOfAdult = numberOfAdult;
            this.numberOfChild = numberOfChild;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
        }

        /// <summary>
        /// ReservationID
        /// </summary>
        public Guid ReservationID { get => reservationID; set => reservationID = value; }

        /// <summary>
        /// NumberOfAdult
        /// </summary>
        public int NumberOfAdult
        {
            get
            {
                return numberOfAdult;
            }
            set
            {
                numberOfAdult = value;
                RaisePropertyChanged("NumberOfAdult");
            }
        }

        /// <summary>
        /// NumberOfChild
        /// </summary>
        public int NumberOfChild
        {
            get
            {
                return numberOfChild;
            }
            set
            {
                numberOfChild = value;
                RaisePropertyChanged("NumberOfChild");
            }
        }

        /// <summary>
        /// CheckIn
        /// </summary>
        public string CheckIn
        {
            get
            {
                return checkIn;
            }
            set
            {
                checkIn = value;
                NotifyPropertyChanged("CheckIn");
                NotifyPropertyChanged("CheckOut");
            }            
        }

        /// <summary>
        /// CheckOut
        /// </summary>
        public string CheckOut
        {
            get
            {
                return checkOut;
            }
            set
            {
                checkOut = value;
                NotifyPropertyChanged("CheckIn");
                NotifyPropertyChanged("CheckOut");
            }
        }

        /// <summary>
        /// Guest
        /// </summary>
        public Guest Guest { get => guest; set => guest = value; }

        /// <summary>
        /// Error
        /// </summary>
        public string Error => throw new NotImplementedException();

        /// <summary>
        /// RoomType
        /// </summary>
        public RoomType RoomType
        {
            get
            {
                return roomType;
            }
            set
            {
                roomType = value;
            }
        }
        
        /// <summary>
        /// TotalPrice
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = value;
            }
        }

        /// <summary>
        /// Service
        /// </summary>
        public string Service { get => service; set => service = value; }

        /// <summary>
        /// NumberOfDay
        /// </summary>
        public int NumberOfDay
        {
            get
            {
                return numberOfDay;                
            }
            set
            {
                numberOfDay = value;                
            }
        }

        /// <summary>
        /// IsValidCheckInCheckOut
        /// </summary>
        /// <returns></returns>
        private bool IsValidCheckInCheckOut()
        {
            bool compareResult = true;

            if (checkIn != null && checkOut != null)
            {
                CultureInfo enUS = new CultureInfo("en-US");
                DateTime checkInValue, checkOutValue;

                checkInValue = DateTime.Parse(checkIn, new CultureInfo("en-CA"));
                checkOutValue = DateTime.Parse(checkOut, new CultureInfo("en-CA"));

                compareResult = checkOutValue >= checkInValue;
            }

            return compareResult;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// this
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "CheckIn" && !IsValidCheckInCheckOut())
                    result = "Check in must be before Check out";
                else if (columnName == "CheckOut" && !IsValidCheckInCheckOut())
                    result = "Check out must be after Check in";

                return result;
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        
    }
}
