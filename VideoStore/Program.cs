using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VideoStore
{
    /**
    * A class used to hold two linked list. One is for the movie inventory and the 
    * other is for the membership list. The membership list uses the LinkedList 
    * package in Java, while the movie inventory used my implementation of a 
    * linked list.
    * 
    * @author Jose Andres Rosario
    */
    class Global
    {
        public static videoList inventory = new videoList();
        public static LinkedList<Customer> members = new LinkedList<Customer>();
    }

    class Program
    {
        /**
        * Prints out the options you have as the user of the program
        * Accepts no parameters
        */
        public static void menu () 
        {
            Console.WriteLine("Welcome to Blockbuster: ");
            Console.WriteLine("(1) Check whether we carries a particular video");
            Console.WriteLine("(2) Check out a video");
            Console.WriteLine("(3) Check in a video");
            Console.WriteLine("(4) Check whether a video is in stock");
            Console.WriteLine("(5) Print only the titles of the videos we carry");
            Console.WriteLine("(6) Print all the details of the titles we carry");
            Console.WriteLine("(7) Check your account with your ID");
            Console.WriteLine("(9) Exit");
        }

        /**
        * Used after inputting all the members in the input file to manually add 
        * an additional member.
        */
        public static void manuallyAddMember () 
        {
            String first;
            String last;
            long ID = 0;
            bool correct = false;
            
            do {
                Console.Write ("First name: ");
                first = Console.ReadLine();
                first = Regex.Replace(first,"[^A-Za-z]", "");
                if (String.IsNullOrEmpty(first))
                    Console.WriteLine ("Invalid first name");
                else
                    correct = true;
            } while (!correct);
            
            correct = false;
            
            do {
                Console.Write ("Last name: ");
                last = Console.ReadLine();
                last = Regex.Replace(last, "[^A-Za-z]", "");
                if (String.IsNullOrEmpty(last)) 
                    Console.WriteLine ("Invalid last name");
                else
                    correct = true;
            } while (!correct);
            
            correct = false;
            
            do {
                Console.Write ("Membership ID (10 digits): ");
                String t = Console.ReadLine().Trim();
                t = Regex.Replace(t, "[^0-9]", "");
                if (String.IsNullOrEmpty(t) || t.Length != 10)
                    Console.WriteLine("Invalid ID");
                else {
                    ID = Convert.ToInt64(t);
                    correct = true;
                }                    
            } while (!correct);

            Global.members.AddLast(new Customer (first, last, ID));
        }

        /**
        * Used after inputting all the movies in the input file to manually add 
        * an additional film.
        */
        public static void manuallyAddMovie () 
        {
            String film;
            int year = 0;
            int reference = 0;
            int stock = 0;
            bool correct = false;
            
            do {
                Console.Write ("Film name: ");
                film = Console.ReadLine();
                if (String.IsNullOrEmpty(film))
                    Console.WriteLine ("Invalid film name");
                else
                    correct = true;
            } while (!correct);
            
            correct = false;
            
            do {
                Console.Write ("Year: ");
                String t = Console.ReadLine().Trim();
                t = Regex.Replace(t, "[^0-9]", "");
                if (String.IsNullOrEmpty(t) || t.Length != 4) {
                    Console.WriteLine("Invalid year");
                    continue;
                }
                year = Convert.ToInt32(t);
                // the oldest surviving film in existence was released in 1888
                if (year < 1888) 
                    Console.WriteLine ("Invalid year");
                else
                    correct = true;
            } while (!correct);
            
            correct = false;
            
            do {
                Console.Write ("Film ID (6 digits): ");
                String t = Console.ReadLine().Trim();
                t = Regex.Replace(t, "[^0-9]", "");
                if (String.IsNullOrEmpty(t) || t.Length != 6) {
                    Console.WriteLine ("Invalid ID");
                }
                else {
                    reference = Convert.ToInt32(t);
                    correct = true;
                }   
            } while (!correct);
            
            correct = false;
            
            do {
                Console.Write ("Stock (Minimum 1): ");
                String t = Console.ReadLine().Trim();
                t = Regex.Replace(t, "[^0-9]", "");
                if (String.IsNullOrEmpty(t))
                    Console.WriteLine ("Invalid inventory");
                else {
                    stock = Convert.ToInt32(t);
                    if (stock < 1)
                        Console.WriteLine ("Invalid inventory");
                    else
                        correct = true;
                }
            } while (!correct);
            
            Global.inventory.insertFirst(new Video (film, year, reference, stock));
        }

        /**
        * Places all member info from the input file into the global membership 
        * linked list
        * @param input the stream reader that will be used to read in the file as 
        * defined by the argument
        */
        public static void createMembershipList (System.IO.StreamReader input)
        {
            // while the file can be read, each line of information is read
            // and is used to create a new customer
            String line;
            while ((line = input.ReadLine()) != null) 
            {
                String[] c = line.Split(',');
                long t = Convert.ToInt64(c[2].Trim());
                Global.members.AddLast(new Customer(c[0], c[1], t));
            }
        }

        /**
        * Places all movies info from the input file into the global inventory 
        * linked list while the file is still good. Which constructor to use 
        * depends on the amount of info given in the file.
        * @param input the stream reader that will be used to read in the file as 
        * defined by the argument
        */
        public static void createVideoList (System.IO.StreamReader input) 
        {
            // while the file can be read, each line of information is read
            // and is used to create a new video
            String line;
            while ((line = input.ReadLine()) != null) 
            { 
                String[] c = line.Split(',');
                if (c.Length == 3) 
                {
                    int t1 = Convert.ToInt32(c[1].Trim());
                    int t2 = Convert.ToInt32(c[2].Trim());
                    Global.inventory.insertFirst(new Video (c[0], t1, t2));
                }
                
                else if (c.Length == 4) 
                {
                    int t1 = Convert.ToInt32(c[1].Trim());
                    int t2 = Convert.ToInt32(c[2].Trim());
                    int t3 = Convert.ToInt32(c[3].Trim());
                    Global.inventory.insertFirst(new Video (c[0], t1, t2, t3));
                }
            }        
        }

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid amount of arguments");
                return;
            }

            System.IO.StreamReader input = new System.IO.StreamReader(args[0]);
            String text;
            createMembershipList(input);

            /**
             * Allows for the user to add in as many additional members as they see 
             * fit. Beyond this point, you cannot add new members.
             */
            do
            {
                Console.Write("Would you like to manually add a member (y/n)? ");
                text = Console.ReadLine();

                if (text.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    manuallyAddMember();
                }

            } while (text.Equals("y", StringComparison.OrdinalIgnoreCase));

            /**
             * Prints out the member list.
             */
            for (int z = 0; z < Global.members.Count; z++)
                (Global.members.ElementAt(z)).print();
            Console.WriteLine();

            input = new System.IO.StreamReader(args[1]);
            createVideoList(input);

            /**
             * Allows for the user to add in as many additional films as they see 
             * fit. Beyond this point, you cannot add new movies.
             */
            do
            {
                Console.Write("Would you like to manually add a film (y/n)? ");
                text = Console.ReadLine();

                if (text.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    manuallyAddMovie();
                }
            } while (text.Equals("y", StringComparison.OrdinalIgnoreCase));

            /**
             * Prints out the film list.
             */
            Global.inventory.print();
            Console.WriteLine();

            int choice = 9;
            do
            {
                menu();
                Console.Write("Enter your choice: ");
                String temp = Console.ReadLine();
                temp = temp.Trim();
                temp = Regex.Replace(temp, "[^0-9]", "");
                choice = Convert.ToInt32(temp);

                switch (choice)
                {
                    case 1:
                        Console.Write("What is the name of the movie: ");
                        String i = Console.ReadLine();
                        Video v = Global.inventory.search(i);
                        // if film is in the store's inventory, v will not be null
                        if (v != null)
                            Console.WriteLine("We carry " + i);
                        else
                            Console.WriteLine("We don't carry " + i);
                        break;
                    case 2:
                        Console.WriteLine("What is your 6-digit ID: ");
                        i = Console.ReadLine();
                        bool isCustomer = false;
                        for (int j = 0; j < Global.members.Count; j++)
                        {
                            // if we found a match between the members and the given 
                            // id
                            if ((Global.members.ElementAt(j)).getMembershipNumber() == Convert.ToInt64(i))
                            {
                                isCustomer = true;
                                Console.Write("What is the name of the movie: ");
                                i = Console.ReadLine();
                                (Global.members.ElementAt(j)).rentVideo(i);
                                j = Global.members.Count;
                            }
                        }
                        if (!isCustomer)
                            Console.WriteLine("You may not be a member of Blockbuster oryour entry is invalid");
                        break;
                    case 3:
                        Console.Write("What is your 6-digit ID: ");
                        i = Console.ReadLine();
                        isCustomer = false;
                        for (int j = 0; j < Global.members.Count; j++)
                        {
                            // if we found a match between the members and the given 
                            // id
                            if ((Global.members.ElementAt(j)).getMembershipNumber() == Convert.ToInt64(i))
                            {
                                isCustomer = true;
                                Console.Write("What is the name of the movie: ");
                                i = Console.ReadLine();
                                (Global.members.ElementAt(j)).returnVideo(i);
                                j = Global.members.Count;
                            }
                        }
                        if (!isCustomer)
                            Console.WriteLine("You may not be a member of Blockbuster oryour entry is invalid");
                        break;
                    case 4:
                        Console.Write("Enter the title: ");
                        String name = Console.ReadLine();
                        v = Global.inventory.search(name);
                        // if film is in the store's inventory, v will not be null
                        if (v != null)
                        {
                            if (v.isAvailable())
                                Console.WriteLine(v.getMovieName() + " is in stock.");
                            else
                                Console.WriteLine(v.getMovieName() + " is not in stock.");
                        }
                        else
                            Console.WriteLine("We don't carry " + name + ".");
                        break;
                    case 5:
                        // print the titles in the store
                        Global.inventory.printTitles();
                        break;
                    case 6:
                        // print the titles and their details in the store
                        Global.inventory.print();
                        break;
                    case 7:
                        // output the information in a valid account
                        Console.Write("What is your 6-digit ID: ");
                        i = Console.ReadLine();
                        isCustomer = false;
                        for (int j = 0; j < Global.members.Count; j++)
                        {
                            if ((Global.members.ElementAt(j)).getMembershipNumber() == Convert.ToInt64(i))
                            {
                                isCustomer = true;
                                (Global.members.ElementAt(j)).print();
                                (Global.members.ElementAt(j)).printRentedVideos();
                                j = Global.members.Count;
                            }
                        }
                        if (!isCustomer)
                            Console.WriteLine("You may not be a member of Blockbuster oryour entry is invalid");
                        break;
                    case 9:
                        Console.WriteLine("Thank you for shopping at Blockbuster");
                        break;
                    default:
                        Console.WriteLine("Invalid entry\n");
                        break;

                }
                Console.WriteLine();
            } while (choice != 9);
        }
    }
}
