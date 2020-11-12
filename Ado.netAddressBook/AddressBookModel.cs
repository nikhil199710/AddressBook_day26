using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookADO.net
{
    class AddressBookModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public long PhoneNo { get; set; }
        public string Email { get; set; }
        public string AddressBookName { get; set; }
        public string ContactType { get; set; }
    }
}

