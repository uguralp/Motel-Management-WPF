using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MM.Model;
using MM.Utilities;

namespace MM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region PROPERTIES

        private List<RoomType> roomTypes;
        private Reservation currentReservation;
        private ReservationList reservationList;

        /// <summary>
        /// RoomTypes
        /// </summary>
        public List<RoomType> RoomTypes { get => roomTypes; set => roomTypes = value; }

        /// <summary>
        /// ReservationList
        /// </summary>
        public ReservationList ReservationList { get => reservationList; set => reservationList = value; }

        /// <summary>
        /// CurrentReservation
        /// </summary>
        public Reservation CurrentReservation { get => currentReservation; set => currentReservation = value; }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region METHODS

        #region BINDING DATA FOR ALL CONTROLS 

        /// <summary>
        /// Init
        /// </summary>
        private void Init()
        {
            // Initialize variable holding the current reservations
            CurrentReservation = new Reservation();

            // Initialize list of reservations
            ReservationList = new ReservationList();

            // Read data from XML
            ReadDataFromXML();

            // Display XML data to grid
            DisplayListToGrid();

            // Init data for list of room types and room numbers
            InitRoomData();                       

            // Enable/Disable UPDATE, DELETE, SAVE buttons
            EnableButtonWhenRegister();

            Clear();

            // Set data context
            DataContext = this;

        }

        #endregion

        #region INITIALIZE DATA FOR SCREEN

        /// <summary>
        /// InitRoomType
        /// </summary>
        private void InitRoomData()
        {
            roomTypes = new List<RoomType>();

            // Create rooms type Guest
            RoomType roomTypeGuest = new GuestRoom();
            roomTypeGuest.RoomTypeName = RoomTypeName.Guest.ToString();

            roomTypeGuest.Rooms.Add(new Room() { RoomNumber = 101 });
            roomTypeGuest.Rooms.Add(new Room() { RoomNumber = 102 });
            roomTypeGuest.Rooms.Add(new Room() { RoomNumber = 103 });
            roomTypeGuest.Rooms.Add(new Room() { RoomNumber = 104 });
            roomTypes.Add(roomTypeGuest);

            // Create rooms type Single
            RoomType roomTypeSingle = new SingleRoom();
            roomTypeSingle.RoomTypeName = RoomTypeName.Single.ToString();

            roomTypeSingle.Rooms.Add(new Room() { RoomNumber = 201 });
            roomTypeSingle.Rooms.Add(new Room() { RoomNumber = 202 });
            roomTypeSingle.Rooms.Add(new Room() { RoomNumber = 203 });
            roomTypeSingle.Rooms.Add(new Room() { RoomNumber = 204 });
            roomTypes.Add(roomTypeSingle);

            // Create rooms type Double
            RoomType roomTypeDouble = new DoubleRoom();
            roomTypeDouble.RoomTypeName = RoomTypeName.Double.ToString();

            roomTypeDouble.Rooms.Add(new Room() { RoomNumber = 301 });
            roomTypeDouble.Rooms.Add(new Room() { RoomNumber = 302 });
            roomTypeDouble.Rooms.Add(new Room() { RoomNumber = 303 });
            roomTypeDouble.Rooms.Add(new Room() { RoomNumber = 304 });
            roomTypes.Add(roomTypeDouble);

            // Create rooms type Suite
            RoomType roomTypeSuite = new SuiteRoom();
            roomTypeSuite.RoomTypeName = RoomTypeName.Suite.ToString();

            roomTypeSuite.Rooms.Add(new Room() { RoomNumber = 401 });
            roomTypeSuite.Rooms.Add(new Room() { RoomNumber = 402 });
            roomTypeSuite.Rooms.Add(new Room() { RoomNumber = 403 });
            roomTypeSuite.Rooms.Add(new Room() { RoomNumber = 404 });
            roomTypes.Add(roomTypeSuite);
        }

        /// <summary>
        /// Clear
        /// </summary>
        private void Clear()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtNumOfAdult.Text = string.Empty;
            txtNumOfChild.Text = string.Empty;
            lblSearchResult.Content = string.Empty;
            cboCheckIn.Text = DateTime.Now.ToShortDateString();
            cboCheckOut.Text = DateTime.Now.ToShortDateString();
            chkIsCheckedOut.IsChecked = false;
            txtFirstName.Focus();
        }

        #endregion

        #region VALIDATION

        /// <summary>
        /// ForceValidation
        /// </summary>
        private void ForceValidation()
        {
            txtFirstName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtLastName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtAddress.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtPhoneNumber.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtNumOfAdult.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtNumOfChild.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            cboCheckIn.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
            cboCheckOut.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
        }

        #endregion

        #region READ/WRITE XML AND DISPLAY TO GRID

        /// <summary>
        /// ReadDataFromXML
        /// </summary>
        private void ReadDataFromXML()
        {
            Utilities.XMLController.ReadXML(ref this.reservationList);
        }

        /// <summary>
        /// DisplayXMLToGrid
        /// </summary>
        private void DisplayListToGrid(string textToFilter = "", bool isSearchAll = true)
        {
            if (reservationList != null)
            {
                int searchFound = 0;

                textToFilter = textToFilter.ToLower().Trim();

                var query = from reservation in reservationList.Reservations
                            where
                            (
                                (
                                    textToFilter != ""
                                    &&
                                    (
                                        reservation.Guest.FirstName.ToLower().Contains(textToFilter)
                                            || reservation.Guest.LastName.ToLower().Contains(textToFilter)
                                            || reservation.Guest.Address.ToLower().Contains(textToFilter)
                                            || reservation.Guest.PhoneNumber.Contains(textToFilter)
                                            || reservation.NumberOfAdult.Equals(textToFilter)
                                            || reservation.NumberOfChild.Equals(textToFilter)
                                            || reservation.RoomType.RoomTypeName.ToLower().Contains(textToFilter)
                                            || reservation.RoomType.Rooms.First().RoomNumber.ToString() == textToFilter
                                            || reservation.CheckIn.Equals(textToFilter)
                                            || reservation.CheckOut.Equals(textToFilter)
                                    )
                                )
                                ||
                                (
                                    isSearchAll == true
                                )
                            )
                            select reservation;

                grdReservation.ItemsSource = query.ToList();
                searchFound = query.ToList().Count;

                if (!isSearchAll)
                {
                    if (searchFound > 0)
                    {
                        lblSearchResult.Content = "There are " + searchFound + " records has been found";
                    }
                    else
                    {
                        lblSearchResult.Content = "There are no records";
                    }
                }                
            }
            else
            {
                lblSearchResult.Content = "No data";
            }
        }

        #endregion

        #region ENABLE/DISABLE BUTTONS

        /// <summary>
        /// EnableButtonWhenRegister
        /// </summary>
        private void EnableButtonWhenRegister()
        {
            btnRegister.IsEnabled = true;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            ToggleInputControls(true);
        }

        /// <summary>
        /// EnableButtonWhenUpdate
        /// </summary>
        private void EnableButtonWhenUpdate()
        {
            btnRegister.IsEnabled = false;
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = true;
            ToggleInputControls(false);
        }

        /// <summary>
        /// ToggleInputControls
        /// </summary>
        /// <param name="isTurnOn"></param>
        private void ToggleInputControls(bool isTurnOn)
        {
            HeaderInput.IsEnabled = isTurnOn;
        }

        #endregion

        #region CHECK RESERVED ROOM

        /// <summary>
        /// IsRerservedRoom
        /// </summary>
        /// <param name="roomNumberToCheck"></param>
        /// <returns></returns>
        private bool IsRerservedRoom(int roomNumberToCheck)
        {
            //var query = ReservationList.Reservations.Where(p => p.Room.RoomNumber == roomNumberToCheck && (p.Room.IsCheckedOut == false));
            var query = ReservationList.Reservations.Where(p => p.RoomType.Rooms.FirstOrDefault().RoomNumber == roomNumberToCheck && (p.RoomType.Rooms.FirstOrDefault().IsCheckedOut == false));
            return (query.Count() > 0);
        }

        #endregion

        #region PROCESS INPUT DATA

        /// <summary>
        /// GetDataInput
        /// </summary>
        /// <param name="currentReservation"></param>
        /// <returns></returns>
        private Reservation GetDataInput(Reservation currentReservation)
        {
            int roomNumber = ((Room)cboRoomNumber.SelectedValue).RoomNumber;
            string roomTypeName = string.Empty;
            Guest tempGuest = null;
            RoomType tempRoomType = null;
            List<Room> tempListRooms = new List<Room>();
            Room tempRoom = null;
            DateTime dateCheckIn, dateCheckOut;

            tempGuest = new Guest()
            {
                FirstName = txtFirstName.Text
                                                ,
                LastName = txtLastName.Text
                                                ,
                Address = txtAddress.Text
                                                ,
                PhoneNumber = txtPhoneNumber.Text
            };
            currentReservation.Guest = tempGuest;

            currentReservation.CheckIn = DateTime.Parse(cboCheckIn.Text).ToShortDateString();
            currentReservation.CheckOut = DateTime.Parse(cboCheckOut.Text).ToShortDateString();
            currentReservation.NumberOfAdult = int.Parse(txtNumOfAdult.Text);
            currentReservation.NumberOfChild = int.Parse(txtNumOfChild.Text);

            tempRoom = new Room()
            {
                IsCheckedOut = (bool)chkIsCheckedOut.IsChecked,
                RoomNumber = roomNumber
            };
            tempListRooms.Add(tempRoom);

            roomTypeName = ((RoomType)lstRoomType.SelectedValue).RoomTypeName;
            if (roomTypeName == RoomTypeName.Guest.ToString())
            {
                tempRoomType = new GuestRoom(RoomTypeName.Guest.ToString(), tempListRooms);
            }
            else if (roomTypeName == RoomTypeName.Single.ToString())
            {
                tempRoomType = new SingleRoom(RoomTypeName.Single.ToString(), tempListRooms);
            }
            else if (roomTypeName == RoomTypeName.Double.ToString())
            {
                tempRoomType = new DoubleRoom(RoomTypeName.Double.ToString(), tempListRooms);
            }
            else if (roomTypeName == RoomTypeName.Suite.ToString())
            {
                tempRoomType = new SuiteRoom(RoomTypeName.Suite.ToString(), tempListRooms);
            }
            currentReservation.RoomType = tempRoomType;

            dateCheckIn = DateTime.Parse(cboCheckIn.Text);
            dateCheckOut = DateTime.Parse(cboCheckOut.Text);

            if (dateCheckOut == dateCheckIn)
            {
                currentReservation.NumberOfDay = 1;
            }
            else if (dateCheckOut > dateCheckIn)
            {
                currentReservation.NumberOfDay = (int)(dateCheckOut - dateCheckIn).TotalDays;
            }

            currentReservation.TotalPrice = tempRoomType.Price * currentReservation.NumberOfDay;

            currentReservation.Service = tempRoomType.Service() + ", " + tempRoomType.ExtraService();
            return currentReservation;
        }

        #endregion

        #endregion

        #region EVENTS

        /// <summary>
        /// Window_Loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Window_Loaded error \n" + ex.Message, 
                                    this.Title, 
                                    MessageBoxButton.OK, 
                                    MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// btnRegister_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            bool isInvalid = false;
            int roomNumber = 0;

            try
            {
                ForceValidation();

                isInvalid = Validation.GetHasError(txtFirstName)
                            || Validation.GetHasError(txtLastName)
                            || Validation.GetHasError(txtAddress)
                            || Validation.GetHasError(txtPhoneNumber)
                            || Validation.GetHasError(txtNumOfAdult)
                            || Validation.GetHasError(txtNumOfChild)
                            || Validation.GetHasError(cboCheckIn)
                            || Validation.GetHasError(cboCheckOut)
                    ;

                if (!isInvalid)
                {
                    roomNumber = ((Room)cboRoomNumber.SelectedValue).RoomNumber;

                    if (!IsRerservedRoom(roomNumber))
                    {
                        Reservation newReservation = new Reservation();
                        newReservation = GetDataInput(newReservation);
                        ReservationList.Reservations.Add(newReservation);
                        XMLController.WriteToXML(ReservationList);
                        grdReservation.ItemsSource = ReservationList.Reservations;
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Room is already booked!\nPlease select another room.",
                                    this.Title,
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                                    }                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnRegister_Click Error \n" + ex.Message, 
                    this.Title, 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// btnSave_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool isInvalid = false;
            int roomNumber = 0;
            int oldRoomNumber = 0;
            bool isAlreadyReservedRoom = false;

            try
            {
                ForceValidation();

                isInvalid = Validation.GetHasError(txtFirstName)
                            || Validation.GetHasError(txtLastName)
                            || Validation.GetHasError(txtAddress)
                            || Validation.GetHasError(txtPhoneNumber)
                            || Validation.GetHasError(txtNumOfAdult)
                            || Validation.GetHasError(txtNumOfChild)
                            || Validation.GetHasError(cboCheckIn)
                            || Validation.GetHasError(cboCheckOut)
                    ;

                if (!isInvalid)
                {                    
                    Reservation selectedReservation = ReservationList.Reservations.FirstOrDefault(i => i.ReservationID == CurrentReservation.ReservationID);
                    if (selectedReservation != null)
                    {
                        roomNumber = ((Room)cboRoomNumber.SelectedValue).RoomNumber;
                        oldRoomNumber = selectedReservation.RoomType.Rooms.FirstOrDefault().RoomNumber;

                        isAlreadyReservedRoom = (roomNumber == oldRoomNumber) ? false : IsRerservedRoom(roomNumber);

                        if (!isAlreadyReservedRoom)
                        {
                            selectedReservation = GetDataInput(selectedReservation);
                            XMLController.WriteToXML(ReservationList);
                            grdReservation.ItemsSource = ReservationList.Reservations;
                            grdReservation.Items.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Room is already booked!\nPlease select another room.",
                                        this.Title,
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnSave_Click Error \n" + ex.Message, this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// grdReservation_SelectionChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdReservation_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                try
                {
                    EnableButtonWhenUpdate();

                    CurrentReservation = grdReservation.SelectedItem as Reservation;

                    if (CurrentReservation != null)
                    {
                        RoomType reservedRoomType = roomTypes.First(r => r.RoomTypeName.ToString().Equals(CurrentReservation.RoomType.RoomTypeName));
                        Room reservedRoom = reservedRoomType.Rooms.First(r => r.RoomNumber == CurrentReservation.RoomType.Rooms.FirstOrDefault().RoomNumber);

                        txtFirstName.Text = CurrentReservation.Guest.FirstName;
                        txtLastName.Text = CurrentReservation.Guest.LastName;
                        txtAddress.Text = CurrentReservation.Guest.Address;
                        txtPhoneNumber.Text = CurrentReservation.Guest.PhoneNumber;
                        txtNumOfAdult.Text = CurrentReservation.NumberOfAdult.ToString();
                        txtNumOfChild.Text = CurrentReservation.NumberOfChild.ToString();
                        lstRoomType.SelectedItem = reservedRoomType;
                        cboRoomNumber.SelectedItem = reservedRoom;
                        cboCheckIn.Text = CurrentReservation.CheckIn.ToString();
                        cboCheckOut.Text = CurrentReservation.CheckOut.ToString();
                        chkIsCheckedOut.IsChecked = CurrentReservation.RoomType.Rooms.FirstOrDefault().IsCheckedOut;

                        // Validate again to clear all previous errors
                        ForceValidation();
                    }                
                }
                catch (Exception ex)
                {
                    MessageBox.Show("grdReservation_SelectionChanged Error \n" + ex.Message, 
                        this.Title, 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Exclamation);
                }
            }

        /// <summary>
        /// btnCancel_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                grdReservation.UnselectAll();
                EnableButtonWhenRegister();
                Clear();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnCancel_Click Error \n" + ex.Message, this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// updateClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                btnRegister.IsEnabled = false;
                btnUpdate.IsEnabled = false;
                btnDelete.IsEnabled = false;
                btnSave.IsEnabled = true;
                btnCancel.IsEnabled = true;
                ToggleInputControls(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("updateClicked Error \n" + ex.Message, this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// deleteClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteClicked(object sender, RoutedEventArgs e)
        {
                try
            {
                if (MessageBox.Show("Do you really want to delete the selected reservation?"
                    , this.Title
                    , MessageBoxButton.YesNo
                    , MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    
                    ReservationList.Remove(CurrentReservation);
                    XMLController.WriteToXML(ReservationList);
                    grdReservation.ItemsSource = ReservationList.Reservations;
                    grdReservation.Items.Refresh();

                    btnCancel_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("deleteClicked Error \n" + ex.Message, this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// btnSearch_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DisplayListToGrid(txtSearch.Text, false);
                DataContext = this;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnSearch_Click Error \n" + ex.Message, this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// btnDisplay_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DisplayListToGrid();
                btnCancel_Click(sender, e);                
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnDisplay_Click Error \n" + ex.Message, this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        #endregion


    }
}
