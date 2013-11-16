using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore
{
    /**
    * My implementation of a linked list for videos. Each videoList has a reference
    * to the first and last node of the list.
    * @author Jose Andres Rosario
    */
    class videoList
    {
        private Video first;
        private Video last;

        /**
        * constructor for a new video list
        * initialize the first and last video variable to null
        */
        public videoList()
        {
            first = null;
            last = null;
        }

        /**
        * @return true if the first reference variable is null;
        */
        public bool isEmpty()
        {
            return first == null;
        }

        /**
        * searches the list via the film's reference ID, and if found returns the 
        * Video object. Null otherwise.
        * @param filmReference the ID of the film in question
        * @return Video object if found
        */
        public Video search(int filmReference)
        {
            if (!isEmpty())
            {
                Video current = first;
                while (current != null)
                {
                    if (current.getReference() == filmReference)
                        return current;
                    current = current.nextVideo;
                }
            }
            return null;
        }

        /**
        * searches the list via the film's film name, and if found returns the 
        * Video object. Null otherwise.
        * @param v the name of the film in question
        * @return video object if found
        */
        public Video search(String v)
        {
            if (!isEmpty())
            {
                Video current = first;
                while (current != null)
                {
                    if ((current.getMovieName()).Equals(v, StringComparison.OrdinalIgnoreCase))
                        return current;
                    current = current.nextVideo;
                }
            }
            return null;
        }
        /**
        * if the film is not already in the list, will add the video object to the 
        * front of the list and return true. Return false otherwise.
        * @param v the Video object that will be inserted
        * @return true if inserted
        */
        public bool insertFirst(Video v)
        {
            if (search(v.getReference()) != null)
                return false;
            if (isEmpty())
            {
                first = v;
                last = v;
                return true;
            }
            v.nextVideo = first;
            first = v;
            return true;
        }

        /**
        * if the film is not already in the list, will add the video object to the 
        * back of the list and return true. Return false otherwise.
        * @param v the Video object that will be inserted
        * @return true if inserted
        */
        public bool insertLast(Video v)
        {
            if (search(v.getReference()) != null)
                return false;
            if (isEmpty())
            {
                first = v;
                last = v;
                return true;
            }
            last.nextVideo = v;
            last = v;
            return true;
        }
        /**
        * if the film is already in the list, will remove the video object from the 
        * list using the film's corresponding video object, and return true. 
        * Return false otherwise.
        * @param v the Video object that will be removed
        * @return true if it has been removed
        */
        public bool deleteVideo(Video v)
        {
            bool found = false;
            if (isEmpty() || search(v.getReference()) == null)
                return found;
            else
            {
                if (v.getReference() == first.getReference())
                {
                    first = first.nextVideo;
                    found = true;
                    return found;
                }
                else
                {
                    Video trail = first;
                    Video current = first.nextVideo;
                    while (current != null && !found)
                    {
                        if (current.getReference() == v.getReference())
                            found = true;
                        else
                        {
                            trail = current;
                            current = current.nextVideo;
                        }
                    }
                    if (found)
                    {
                        trail.nextVideo = current.nextVideo;
                        if (last == current)
                        {
                            last = trail;
                        }
                        return found;
                    }
                }
            }
            return found;
        }

        /**
        * if the film is already in the list, will remove the video object from the
        * list using the film's reference ID, and return true. 
        * Return false otherwise.
        * @param filmReference the reference ID of the film to be deleted
        * @return true if the film has been removed
        */
        public bool deleteVideo(int filmReference)
        {
            bool found = false;
            if (isEmpty() || search(filmReference) == null)
                return found;
            else
            {
                if (filmReference == first.getReference())
                {
                    first = first.nextVideo;
                    found = true;
                    return found;
                }
                else
                {
                    Video trail = first;
                    Video current = first.nextVideo;
                    while (current != null && !found)
                    {
                        if (current.getReference() == filmReference)
                            found = true;
                        else
                        {
                            trail = current;
                            current = current.nextVideo;
                        }
                    }
                    if (found)
                    {
                        trail.nextVideo = current.nextVideo;
                        if (last == current)
                        {
                            last = trail;
                        }
                        return found;
                    }
                }
            }
            return found;
        }

        /**
        * Prints each video and their details in the list
        */
        public void print()
        {
            Video current = first;
            while (current != null)
            {
                current.printVideo();
                current = current.nextVideo;
            }
        }

        /**
        * prints each video's name in the list
        */
        public void printTitles()
        {
            Video current = first;
            while (current != null)
            {
                current.printVideoTitie();
                current = current.nextVideo;
            }
        }

        /**
        * If the video is in the list, the film will be returned and removed from 
        * the list. It will also return true, false otherwise.
        * @param v the Video file that will be checked in
        * @return 
        */
        public bool videoCheckIn (Video v) 
        {
            Video temp = search(v.getReference());
            if (temp != null) {
                Console.WriteLine("We have rented this video to you");            
                if (temp.returnVideo()) {
                    return deleteVideo (temp.getReference());
                }
                else
                    return false;
            }
            Console.WriteLine("We have not rented this video to you");   
            return false;
        }

        /**
        * If the video is not in the list, the film will be checked out and added 
        * to the list. It will also return true, false otherwise.
        * @param v the Video file that will be checked in
        * @return true if the film is returned and inventory reflects it
        */
        public bool videoCheckOut (Video v) 
        {
            Video temp = search(v.getReference());
            if (temp == null) {
                Console.WriteLine("You don't currently have this video rented out");      
                if (v.rentVideo()) {
                    return insertFirst (v);
                }
                else
                    return false;
            }
            Console.WriteLine("You currently have this video rented out");      
            return false;
        }

        /**
        * Using the Video addStock method, and if the film exists, the store can 
        * add inventory to the film using its reference ID.
        * @param reference the film ID
        * @param add how many tapes you want to add of the film
        * @return true if the film is in inventory and it is reflective of this 
        * change
        */
        public bool addStock(int reference, int add)
        {
            Video v = search(reference);
            if (v != null)
            {
                v.addStock(add);
                return true;
            }
            return false;
        }

        /**
        * Using the Video addStock method, and if the film exists, the store can 
        * add inventory to the film using its name.
        * @param name the name of the film
        * @param add how many tapes you want to add of the film
        * @return true if the film is in inventory and it is reflective of this 
        * change
        */
        public bool addStock(String name, int add)
        {
            Video v = search(name);
            if (v != null)
            {
                v.addStock(add);
                return true;
            }
            return false;
        }

        /**
        * Using the Video setStock method, and if the film exists, the store can 
        * outright change the inventory to the film using its ID.
        * @param reference the film ID
        * @param set the new number of tapes of the film in inventory
        * @return true if the film is in inventory and it is reflective of this 
        * change
        */
        public bool setStock(int reference, int set)
        {
            Video v = search(reference);
            if (v != null)
            {
                v.setStock(set);
                return true;
            }
            return false;
        }

        /**
        * Using the Video setStock method, and if the film exists, the store can 
        * outright change the inventory to the film using its name.
        * @param reference the name of the film
        * @param set the new number of tapes of the film in inventory
        * @return true if the film is in inventory and it is reflective of this 
        * change
        */
        public bool setStock(String reference, int set)
        {
            Video v = search(reference);
            if (v != null)
            {
                v.setStock(set);
                return true;
            }
            return false;
        }
    }
}
