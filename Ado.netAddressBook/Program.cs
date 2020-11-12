using System;

namespace AddressBookADO.net
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to address book problem ADO.net");
            /// Creating an object of AddressBookRepo class
            AddressBookRepo addressBookRepo = new AddressBookRepo();
            //UC1
            //addressBookRepo.EnsureDataBaseConnection();
            //UC2
            //addressBookRepo.GetAllEntries();
            //UC3
            AddressBookModel model = new AddressBookModel();
            model.FirstName = "rahul";
            model.LastName = "vats";
            model.Address = "fatwua";
            model.City = "chapra";
            model.State = "bihar";
            model.Zip = 281051;
            model.PhoneNo = 5485200789;
            model.Email = "rahul@gmail.com";
            model.AddressBookName = "nikhil";
            model.ContactType = "Friends";
            Console.WriteLine(addressBookRepo.AddContact(model) ? "Record inserted successfully " : "Failed");

            //UC4
            //addressBookRepo.UpdateContact("nikhil");
            //UC5
            //addressBookRepo.DeleteContact("neha");
            //UC6
            //addressBookRepo.GetPersonByCityOrState();
            //UC7
            ///Calling the GetSizeByCity method
            //addressBookRepo.GetSizeByCity("kolkata");
            //UC7-Calling the GetSizeByState method
            //addressBookRepo.GetSizeByState("westBengal");
        }
    }
}