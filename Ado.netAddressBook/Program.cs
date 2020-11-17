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
            addressBookRepo.EnsureDataBaseConnection();
            
        }
    }
}
