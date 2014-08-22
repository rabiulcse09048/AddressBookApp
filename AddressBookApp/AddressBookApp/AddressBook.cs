using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AddressBookApp
{
    public class AddressBook
    {
        private List<Address> addressList = new List<Address>();
        private List<Address> selectedAddressList = new List<Address>(); 
        public bool AddAddress(Address anAddress)
        {
            bool check = false;
            if (DoesThisAddressExist(anAddress))
            {
                check = true;
            }
            else
            {
                addressList.Add(anAddress);
            }
            return check;
        }

        public List<Address> GetAllAddress()
        {
            return addressList;
        }

        private bool DoesThisAddressExist(Address address)
        {
            foreach (Address anAddress in addressList)
            {
                if (anAddress.Email == address.Email)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckEmailAddress(string email)
        {
            bool check = false;
            int noOfOccurenceOfAtTheRateOf = email.Count(x=>x=='@');
            int noOfOccuraceOfDot = email.Count(x => x == '.');


            if (noOfOccurenceOfAtTheRateOf == 1&&noOfOccuraceOfDot>=1)
            {
                check = true;
            }

            else
            {
                check = false;
            }

            return check;
        }

        public List<Address>  GetSelectedFirstName(string msg)
        {

            selectedAddressList = addressList.Where(u => u.FirstName.StartsWith(msg)).ToList();
            return selectedAddressList;
        }

        public List<Address> GetSelectedLastName(string msg)
        {

            selectedAddressList = addressList.Where(u => u.LastName.StartsWith(msg)).ToList();
            return selectedAddressList;
        }
        public List<Address> GetSelectedEmail(string msg)
        {

            selectedAddressList = addressList.Where(u => u.Email.StartsWith(msg)).ToList();
            return selectedAddressList;
        }

        public List<Address> GetSelectedPhoneNo(string msg)
        {

            selectedAddressList = addressList.Where(u => u.PhoneNo.StartsWith(msg)).ToList();
            return selectedAddressList;
        }

        public int GetIndexOfSectedAddress(string emailAddress)
        {
            int n = -1;

            foreach(Address anAddress in addressList )
            {
                if (anAddress.Email == emailAddress)
                {
                    n = addressList.IndexOf(anAddress);
                    break;
                }
            }
            return n;
        }

        public void  UpdateAddress(int index,string firstName,string lastName,string email,string phoneNo)
        {
            addressList[index].FirstName = firstName;
            addressList[index].LastName = lastName;
            addressList[index].Email = email;
            addressList[index].PhoneNo = phoneNo;
           
        }

    }
}
