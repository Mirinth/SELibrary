using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeopleClass
{
    public class Patron
    {
        const int MAX_ADULT = 6;
        const int MAX_CHILD = 3;

        private PATRONTYPE pType;
        private string pName;
        private int pAge;
        private List<Media> mediaCheckoutOut;

        //Constructor For Patron
        public Patron(string name, int age, PATRONTYPE type)
        {
            pName = name;
            pAge = age;
            pType = type;
            mediaCheckoutOut = new List<Media>;
        }

        //Delete Media To Patron
        public void CheckInBook(Media checkIn)
        {
            
        }

        //Add Media to Patron
        public void CheckOutBook(Media checkout)
        {
            //Check Age and Amount
        }
    }

    public enum PATRONTYPE { ADULT, CHILD};
}
