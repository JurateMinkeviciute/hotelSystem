using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms_Hotel_System
{
    class ManageMessage
    {
        // For Login's Form
        public String errorLoginUsername = "Enter Your Username to Login";
        public String errorLoginPassword = "Enter Your Password to Login";
        public String errorLoginIncorrect = "Incorrect Username or Password. Try it again";

        // For Client's Form
        public String errorRequiredFlieds = "Required fields - First & Last name, phone number";
        public String addedClient = "Inserted New Client Successfuly";
        public String errorNotAdded = "ERROR - Client Not Inserted";
        public String errorId = "ID is Not Number. Please, check it";
        public String updatedClient = "Updated Client Successfuly";
        public String errorNotUpdate = "ERROR - Client Not Updated";
        public String deletedClient = "Deleted Client Successfuly";
        public String errorNotDeleted = "ERROR - Client Not Deleted";

        //For Room's Form
        public String errorRoomNumber = "Room Number is Not Number. Please, check room number";
        public String errorRoomRequiredFields = "Required Fields - Room Type, Phone and Free";
        public String addedRoom = "Room Added Successfully";
        public String errorNotAddedRoom = "Room Not added";
        public String editedRoom = "Room Edited Successfully";
        public String errorNotEditRoom = "Room Not Edit";
        public String deletedRoom = "Deleted Room Successfully";
        public String errorNotDeleteRoom = "ERROR - Room Not Deleted";

        //For Reservation's Form
        public String invalidDateIn = "The Date In Must Be = or > To Today Date ";
        public String invalidDateOut = "The Date Out Must Be > To Date In";
        public String errorClientId = "Client Id is Not Number. Please, check it";
        public String errorReservRequired = "Required fields - Client Id, Room Type and dates: Date In and Date Out";
        public String addedReserv = "Added New Reservation Successfuly";
        public String errorNotAddReservation = "Reservation Not Added";
        public String errorReservRequiredFields = "Required fields - Reservation Id, Client Id, Room number and dates: Date In and Date Out";
        public String errorReservIds = "Reservation Id & Client Id are Not Numbers. Please, check it";
        public String updatedReserv = "Updated Reservation Successfuly";
        public String errorReservUpdate = "ERROR - Client can't update";
        public String errorReservId = "Reservation Id is not number. Please, check it";
        public String errorDeletedReserv = "Deleted Reservation Successfuly";
        public String errorNotDeleteReserv = "Error - Reservation Not Deleted";

    }
}
