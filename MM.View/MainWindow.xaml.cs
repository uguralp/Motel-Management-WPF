using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MM.Model;
using MM.Utilities;

namespace MM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region VARIABLES

        public RoomTypes roomTypes;
        
        #endregion

        #region PROPERTIES

        private ReservationList reservationList;
        public ReservationList ReservationList { get => reservationList; set => reservationList = value; }

        #endregion

        #region CONSTRUCTOR

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region METHODS

        #region BINDING DATA FOR ALL CONTROLS 

        private void Init()
        {
            InitRoomType();

            ReservationList = new ReservationList();

            DataContext = roomTypes;
        }

        #endregion

        #region INITIALIZE DATA

        private void InitRoomType()
        {
            roomTypes = new RoomTypes();

            // Create rooms type Guest
            RoomType roomTypeGuest = new RoomType();
            roomTypeGuest.RoomTypeID = 1;
            roomTypeGuest.RoomTypeName = RoomTypeName.Guest;

            roomTypeGuest.Rooms.Add(new GuestRoom() { RoomID = "11", RoomNumber = 101 });
            roomTypeGuest.Rooms.Add(new GuestRoom() { RoomID = "12", RoomNumber = 102 });
            roomTypeGuest.Rooms.Add(new GuestRoom() { RoomID = "13", RoomNumber = 103 });
            roomTypeGuest.Rooms.Add(new GuestRoom() { RoomID = "13", RoomNumber = 104 });
            roomTypes.Add(roomTypeGuest);

            // Create rooms type Single
            RoomType roomTypeSingle = new RoomType();
            roomTypeSingle.RoomTypeID = 2;
            roomTypeSingle.RoomTypeName = RoomTypeName.Single;

            roomTypeSingle.Rooms.Add(new SingleRoom() { RoomID = "21", RoomNumber = 201 });
            roomTypeSingle.Rooms.Add(new SingleRoom() { RoomID = "22", RoomNumber = 202 });
            roomTypeSingle.Rooms.Add(new SingleRoom() { RoomID = "23", RoomNumber = 203 });
            roomTypeSingle.Rooms.Add(new SingleRoom() { RoomID = "23", RoomNumber = 204 });
            roomTypes.Add(roomTypeSingle);

            // Create rooms type Double
            RoomType roomTypeDouble = new RoomType();
            roomTypeDouble.RoomTypeID = 3;
            roomTypeDouble.RoomTypeName = RoomTypeName.Double;

            roomTypeDouble.Rooms.Add(new DoubleRoom() { RoomID = "31", RoomNumber = 301 });
            roomTypeDouble.Rooms.Add(new DoubleRoom() { RoomID = "32", RoomNumber = 302 });
            roomTypeDouble.Rooms.Add(new DoubleRoom() { RoomID = "33", RoomNumber = 303 });
            roomTypeDouble.Rooms.Add(new DoubleRoom() { RoomID = "33", RoomNumber = 304 });
            roomTypes.Add(roomTypeDouble);

            // Create rooms type Suite
            RoomType roomTypeSuite = new RoomType();
            roomTypeSuite.RoomTypeID = 4;
            roomTypeSuite.RoomTypeName = RoomTypeName.Suite;

            roomTypeSuite.Rooms.Add(new SuiteRoom() { RoomID = "41", RoomNumber = 401 });
            roomTypeSuite.Rooms.Add(new SuiteRoom() { RoomID = "42", RoomNumber = 402 });
            roomTypeSuite.Rooms.Add(new SuiteRoom() { RoomID = "43", RoomNumber = 403 });
            roomTypeSuite.Rooms.Add(new SuiteRoom() { RoomID = "43", RoomNumber = 404 });
            roomTypes.Add(roomTypeSuite);

            // Create rooms type King
            RoomType roomTypeKing = new RoomType();
            roomTypeKing.RoomTypeID = 5;
            roomTypeKing.RoomTypeName = RoomTypeName.King;

            roomTypeKing.Rooms.Add(new KingRoom() { RoomID = "51", RoomNumber = 501 });
            roomTypeKing.Rooms.Add(new KingRoom() { RoomID = "52", RoomNumber = 502 });
            roomTypeKing.Rooms.Add(new KingRoom() { RoomID = "53", RoomNumber = 503 });
            roomTypeKing.Rooms.Add(new KingRoom() { RoomID = "53", RoomNumber = 504 });
            roomTypes.Add(roomTypeKing);

            // Create rooms type Queen
            RoomType roomTypeQueen = new RoomType();
            roomTypeQueen.RoomTypeID = 6;
            roomTypeQueen.RoomTypeName = RoomTypeName.Queen;

            roomTypeQueen.Rooms.Add(new QueenRoom() { RoomID = "61", RoomNumber = 601 });
            roomTypeQueen.Rooms.Add(new QueenRoom() { RoomID = "62", RoomNumber = 602 });
            roomTypeQueen.Rooms.Add(new QueenRoom() { RoomID = "63", RoomNumber = 603 });
            roomTypeQueen.Rooms.Add(new QueenRoom() { RoomID = "63", RoomNumber = 604 });
            roomTypes.Add(roomTypeQueen);

        }

        #endregion

        #endregion

        #region EVENTS

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();

            txtFirstName.Focus();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Reservation reservation = new Reservation();

            reservation.Guest = new Guest() { FirstName = txtFirstName.Text
                                                , LastName = txtLastName.Text
                                                , Address = txtAddress.Text
                                                , PhoneNumber = txtPhoneNumber.Text
                                            };

            reservation.NumberOfAdult = int.Parse(txtNumOfAdult.Text);
            reservation.NumberOfChild = int.Parse(txtNumOfChild.Text);
            reservation.RoomType = ((RoomType)lstRoomType.SelectedValue).RoomTypeName.ToString();
            reservation.Room = ((Room)cboRoomNumber.SelectedValue);


            reservation.CheckIn = DateTime.Parse(cboCheckIn.Text);
            reservation.CheckOut = DateTime.Parse(cboCheckOut.Text);

            ReservationList.Add(reservation);
            XMLController.WriteToXML(Common.XML_FILE_NAME, ReservationList);
            grdReservation.ItemsSource = ReservationList.Reservations;


        }

        #endregion




    }
}
