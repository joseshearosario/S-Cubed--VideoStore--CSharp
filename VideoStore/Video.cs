using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore
{
    /**
    * A class representative of a video. Each video will hold their title, release 
    * year, as well as their reference ID number. In addition, this is where each 
    * title's inventory is kept. Any changes to the number in circulation and in 
    * stock will occur on a Video object.
    * 
    * @author Jose Andres Rosario
    */
    class Video
    {
        private String movieName;
        private int releaseYear;
        private int referenceNumber;
        private int inStock;
        private int inCirculation;
        public Video nextVideo;

        /**
        * a video constructor
        * default stock is 1
        * @param name the name of the film
        * @param year the release year
        * @param reference a numerical id for the film
        */
        public Video(String name, int year, int reference)
        {
            movieName = name;
            releaseYear = year;
            referenceNumber = reference;
            inStock = 1;
            inCirculation = 0;
            nextVideo = null;
        }

        /**
        * a video constructor
        * option to set inventory > 1 (determined in main)
        * @param name the name of the film
        * @param year the release year
        * @param reference a numerical id for the film
        * @param inventory starting stock
        */
        public Video(String name, int year, int reference, int inventory)
        {
            movieName = name;
            releaseYear = year;
            referenceNumber = reference;
            inStock = inventory;
            inCirculation = 0;
            nextVideo = null;
        }

        /**
         * @return String of film name
        */
        public String getMovieName()
        {
            return movieName;
        }

        /**
        * Change/set the film name using a String parameter
        * @param name the new film name
        */
        public void setMovieName(String name)
        {
            movieName = name;
        }

        /**
        * @return integer of the release year
        */
        public int getReleaseYear()
        {
            return releaseYear;
        }

        /**
        * Change/set the film release year using an integer parameter
        * @param year the new release year of the film
        */
        public void setReleaseYear(int year)
        {
            releaseYear = year;
        }

        /**     
        * @return integer of the film's reference ID
        */
        public int getReference()
        {
            return referenceNumber;
        }

        /**
        * Change/set the film's reference ID using an integer parameter
        * @param reference the new reference ID of the film
        */
        public void setReference(int reference)
        {
            referenceNumber = reference;
        }

        /**
        * @return true if there are any copies of the film in stock
        */
        public bool isAvailable()
        {
            return getStock() > 0;
        }

        /**
        * @return integer of how many are currently in stock
        */
        public int getStock()
        {
            return inStock;
        }

        /**
        * Change/set the amount of copies of this film is in stock using an integer 
        * parameter
        * @param stock the new amount of copies of the film
        */
        public void setStock(int stock)
        {
            inStock = stock;
        }

        /**
        * @return String of first name
        */
        public int getCirculation()
        {
            return inCirculation;
        }

        /**
        * prints to detail all the details of the film itself
        */
        public void printVideo () 
        {
            Console.WriteLine(getMovieName() + "\t" + getReleaseYear() + "\t" + getReference() + "\t" + getStock() + "\t" + getCirculation());
        }

        /**
        * only prints the name of the film
        */
        public void printVideoTitie () 
        {
            Console.WriteLine(getMovieName());
        }

        /**
        * if there is any copies of the film available, the amount in stock will 
        * decrement by 1 and the amount in circulation will increment by 1, then 
        * return true. Return false otherwise.
        * 
        * @return true if there are videos available to rent and the records are 
        * changed to reflect this new rental
        */
        public bool rentVideo() 
        {
            if (isAvailable()) {
                inStock = inStock - 1;
                inCirculation = inCirculation + 1;
                Console.WriteLine("Our records now reflect your rental");
                return true;
            }
            Console.WriteLine("There are no available copies of this video");
            return false;
        }

        /**
        * When called, and there are films in circulation, this will increase the 
        * amount of copies in stock by 1 and decrease the number in circulation by 
        * 1, then return true. Otherwise, return false.
        * 
        * @return true if there are tapes in circulation and one is being returned
        */
        public bool returnVideo() 
        {
            if (inCirculation < 1) {
                Console.WriteLine("Our records indicate that we have none of these vides in circulation");
                return false;
            }
            inCirculation = inCirculation - 1;
            inStock = inStock + 1;
            Console.WriteLine("Our records now reflect your return");
            return true;
        }

        /**
        * decrements the amount in stock by one and returns true if possible
        * @return true if you can remove one tape
        */
        public bool removeStock()
        {
            if (isAvailable())
            {
                inStock = inStock - 1;
                return true;
            }
            return false;
        }

        /**
        * decrements the amount in stock by a given amount in the parameter and 
        * returns true if possible
        * 
        * @param i the amount you wish to remove from the collection
        * @return true if you can remove the tapes
        */
        public bool removeStock(int i)
        {
            if (i <= getStock())
            {
                inStock = inStock - i;
                return true;
            }
            return false;
        }

        /**
        * increments the number of copies in stock by the given parameter
        * @param i the amount you wish to add to the video
        */
        public void addStock(int i)
        {
            inStock = inStock + i;
        }

        /**
        * increments the number of copies in stock by one
        */
        public void addStock()
        {
            inStock = inStock + 1;
        }
    }
}