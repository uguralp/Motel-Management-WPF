## Guideline for the Motel Management

This guideline was prepared by following the rules on the rubric.

**Class Diagram:**

![Image of Class Diagram](https://i.imgur.com/yGhZ2MY.png)

*Figure 1: Class Diagram for the Motel Management*

The class diagram shows the fields, properties, methods and events of the classes in the Motel Management application. The classes were implemented and associated properly in the application.

**Overview:**

The purpose of the Motel Management System is to allow booking rooms for the customers and list them all. The system allows the user to register, update and delete the all information of the bookings. Operations were designed well for the Motel Management System.

**Main Page:**

![Image of the main page](https://i.imgur.com/RwANwwb.png)

*Figure 2: Main Page of the Application*

This is the main page of the application. It has two sections. The section on the top is for adding new customers. The other section on the bottom shows the information list for the customers in the datagrid.

**Adding Data:**

After giving the right inputs, the user clicks "register" to save the data. If the data is wrong, the user can't save the data and get an error.

**Selecting Data:**

Firstly, the user needs to select the existing data from the datagrid. After selecting one of the rows, information appears on the top section of the app.

![Image of the main page](https://i.imgur.com/C6WHTxe.png)

*Figure 3: Select the row to edit, update and delete.*

**Updating Data:**

After selecting the data, the user clicks the update button and then they can edit and update the data.

**Deleting Data:**

After selecting the data, the user clicks the delete button and then they can delete the data.

**Saving Data:**

After selecting the data, the user clicks the update button and then they can save the data. The data saves in an XML file properly by using the serialization.

**Searching Data:**

LINQ was implemented for the search feature. The user can search for the following values: First Name, Last Name, Address, Phone Number, Room Type, Room Number, check in date and check out date.


![Image of the main page](https://i.imgur.com/He4NzEG.png)

*Figure 4: Example for the search.*

**Error Handlings:**

Error handlings were implemented based on the rubric. Converters and validation rules work properly in the input fields. Additionally, the user can't book the room if it has already booked.

![Image of the main page](https://i.imgur.com/J7GRamd.png)

*Figure 5: Application gets error when there is no value in the fields.*

![Image of the main page](https://i.imgur.com/T2xXZqT.png)

*Figure 6: Application gets an error when the fields are filled wrong.*

![Image of the main page](https://i.imgur.com/aUFIvt1.png)

*Figure 7: IsCheckedOut feature on the datagrid.*

Each record (reservation) has its IsCheckedOut Boolean value. If the record's IsCheckedOut value on the row is true, the background of the row of the record changes to the red color.

## NOTE: 
This project was made for the C# Software Development class as a final project.
