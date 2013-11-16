using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore
{
    /**
    * A class representative of a customer. Each customer will hold their first 
    * and last name, as well as their membership ID number. In addition, each 
    * customer is given their own videoList linked list that represented the 
    * rentals they are currently holding on to.
    * 
    * @author Jose Andres Rosario
    */
    class Customer
    {
        private String FirstName;
        private String LastName;
        private long membershipNumber;
        private videoList rentedVideos;

        /**
        * constructor of the Customer
        * each customer has their own video list representative of their current 
        * videos
        * @param fN first name
        * @param lN last name
        * @param num 10-digit ID
        */
        public Customer(String fN, String lN, long num)
        {
            FirstName = fN;
            LastName = lN;
            membershipNumber = num;
            rentedVideos = new videoList();
        }

        /**
        * @return String of first name
        */
        public String getFirstName()
        {
            return FirstName;
        }

        /**
        * @return String of last name
        */
        public String getLastName()
        {
            return LastName;
        }

        /**
        * @return String of full name (first name and last name)
        */
        public String getFullName()
        {
            return FirstName + " " + LastName;
        }

        /**
        * @param first the new first name of the member
        */
        public void setFirstName(String first)
        {
            FirstName = first;
        }

        /**
        * @param last the new last name of the member
        */
        public void setLastName(String last)
        {
            LastName = last;
        }

        /**
        * @param first the new first name of the member
        * @param last the new last name of the member
        */
        public void setFullName(String first, String last)
        {
            FirstName = first;
            LastName = last;
        }

        /**
         * @return long of the customer's membership ID
         */
        public long getMembershipNumber()
        {
            return membershipNumber;
        }

        /**
        * @param num the new ID for the member
        */
        public void setMembershipNumber(long num)
        {
            membershipNumber = num;
        }

        /**
        * prints out the titles of the movies that the customer is currently 
        * renting
        */
        public void printRentedVideos()
        {
            rentedVideos.printTitles();
        }

        /**
        * print all of members of the Customer class (excluding rentedList)
        */
        public void print () 
        {
            Console.WriteLine(FirstName + " " + LastName + "\t" + membershipNumber);
        }

        /**
        * rents a video using a String parameter
        * first searches the store inventory to see if the film is in the database
        * if the film exists in the database, calls videoCheckout
        * @param reference the name of the film
        * @return true if the film can and has been rented and your account and 
        * inventory is reflective of it
        */
        public bool rentVideo (String reference) 
        {
            Video v = Global.inventory.search(reference);
            if (v != null) {
                Console.WriteLine("We have this video in our inventory");
                if (rentedVideos.videoCheckOut(v)) {
                    Console.WriteLine("We hope you enjoy " + v.getMovieName());
                    return true;
                }        
                else
                    return false;
            }
            Console.WriteLine("We don't have this video in our inventory");
            return false;
        }

        /**
        * rents a video using a int parameter
        * first searches the store inventory to see if the film is in the database
        * if the film exists in the database, calls videoCheckout
        * @param reference the ID of the film in question
        * @return true if the film can and has been rented and your account and 
        * inventory is reflective of it
        */
        public bool rentVideo (int reference) 
        {
            Video v = Global.inventory.search(reference);
            if (v != null) {
                Console.WriteLine("We have this video in our inventory");
                if (rentedVideos.videoCheckOut(v)) {
                    Console.WriteLine("We hope you enjoy " + v.getMovieName());
                    return true;
                }
                else
                    return false;
            }
            Console.WriteLine("We don't have this video in our inventory");
            return false;
        }

        /**
        * returns a video using a String parameter
        * first searches the store inventory to see if the film is in the database
        * if the film exists in the database, calls videoCheckin
        * @param reference the name of the film
        * @return true if the film can and has been returned and your account and 
        * inventory is reflective of it
        */
        public bool returnVideo (String reference) 
        {
            Video v = Global.inventory.search(reference);
            if (v != null) {
                Console.WriteLine("We have this video in our inventory");
                if (rentedVideos.videoCheckIn(v)) {
                    Console.WriteLine("Thank you for returning " + v.getMovieName());
                    return true;
                }
                else
                    return false;
            }
            Console.WriteLine("We don't have this video in our inventory");
            return false;
        }

        /**
        * returns a video using a int parameter
        * first searches the store inventory to see if the film is in the database
        * if the film exists in the database, calls videoCheckin
        * @param reference the ID of the film in question
        * @return true if the film can and has been returned and your account and 
        * inventory is reflective of it
        */
        public bool returnVideo (int reference) 
        {
            Video v = Global.inventory.search(reference);
            if (v != null) {
                Console.WriteLine("We have this video in our inventory");
                if (rentedVideos.videoCheckIn(v)) {
                    Console.WriteLine("Thank you for returning " + v.getMovieName());
                    return true;
                }
                else
                    return false;
            }
            Console.WriteLine("We don't have this video in our inventory");
            return false;
        }
    }
}
