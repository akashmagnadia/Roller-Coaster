using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerCoaster
{
    public class node
    {
        public node next;
        //following will store information about the group
        public int adults;
        public int children;
        public int bribedTimes;
        public String groupName;

        public node(int adults, int children, int bribedTimes, String groupName)
        {
            this.next = null;
            this.adults = adults;
            this.children = children;
            this.bribedTimes = bribedTimes;
            this.groupName = groupName;
        }
    }

    //this linked list is basically queue
    public class LinkedList
    {
        private node head;

        public LinkedList()
        {
            this.head = null;
        }

        //enqueue
        public void InsertAtEnd(int adults, int children, String groupName) //enqueue
        {
            int bribedTimes = 0;
            node temp = new node(adults, children, bribedTimes, groupName);

            if (this.head == null)
            {
                this.head = temp;
                Console.WriteLine("Adding the group '" + groupName + "' to the queue");
                printGroup(temp);
                return;
            }

            node traverser = this.head;
            while (traverser.next != null)
            {
                traverser = traverser.next;
            }
            traverser.next = temp;

            Console.WriteLine("Adding the group '" + groupName + "' to the queue");
            printGroup(temp);
        }

       

        public void removeGroupForRide(int seatCapacity)
        {
            int seatOccupied = 0;
            int seatRemaining = seatCapacity - seatOccupied;
            node tempHead = this.head;
            int currentPeople = 0;
            String currentGroup = "";

            currentGroup = tempHead.groupName;
            currentPeople = tempHead.adults + tempHead.children;
            seatRemaining = seatCapacity - seatOccupied;

            while ((seatRemaining > 0) && (tempHead != null)) //redundancy for fail-safe
            {
                if (seatRemaining >= currentPeople)
                {
                    seatOccupied += currentPeople;
                    removeGroup(currentGroup, true);
                    tempHead = this.head;
                } else
                {
                    tempHead = tempHead.next;
                }

                if (tempHead == null)
                {
                    break;
                }

                currentGroup = tempHead.groupName;
                currentPeople = tempHead.adults + tempHead.children;
                seatRemaining = seatCapacity - seatOccupied;
            }
        }

        //remove the group from the queue
        public void removeGroup(String name, bool forRide)
        {
            if (this.head.groupName == name)
            {
                node temp2 = this.head;
                this.head = this.head.next;
                if (forRide)
                {
                    Console.WriteLine("The group '" + temp2.groupName + "' is going for a ride on the Roller Coaster");
                    printGroup(temp2);
                }
                else
                {
                    Console.WriteLine("Successfully removed '" + name + "' from the queue");
                }

                return;
            }

            node temp = this.head;
            while (temp.next != null)
            {
                if (temp.groupName == name)
                {
                    temp.next = temp.next.next;
                }
                temp = temp.next;
            }

            if (forRide)
            {
                Console.WriteLine("The group '" + temp.groupName + "' is going for a ride on the Roller Coaster");
                printGroup(temp);
            }
            else
            {
                Console.WriteLine("Successfully removed '" + name + "' from the queue");
            }
        }

        //check to see if the name exist in the queue
        public bool groupNameExist(String name)
        {
            node temp = this.head;
            while (temp != null)
            {
                if (temp.groupName == name)
                {
                    return true;
                }
                temp = temp.next;
            }
            return false;
        }

        public void printGroup(node temp)
        {
            Console.Write("The group '" + temp.groupName + "' consist of " + temp.adults);
            if (temp.adults > 1)
            {
                Console.Write(" adults");
            }
            else
            {
                Console.Write(" adult");
            }

            if (temp.children == 0)
            {
                //do nothing
                Console.WriteLine(".");
            }
            else if (temp.children == 1)
            {
                Console.WriteLine(" and " + temp.children + " child.");
            }
            else
            {
                Console.WriteLine(" and " + temp.children + " children.");
            }

            Console.WriteLine("");
        }

        //display all the information
        public void displayAllGroupInfo()
        {
            if (this.head == null)
            {
                Console.WriteLine("There is no group waiting in the line for the Roller Coaster");
            }

            Console.WriteLine("");
            Console.WriteLine("Information about groups that are waiting in line for the Roller Coaster:");

            node temp = this.head;
            int count = 1;

            while (temp != null)
            {
                Console.WriteLine(count + ") Group Name: " + temp.groupName);
                Console.WriteLine("   Adult(s): " + temp.adults);
                Console.WriteLine("   Child(ren): " + temp.children);

                if (temp.bribedTimes > 0)
                {
                    if (temp.bribedTimes == 1)
                    {
                        Console.WriteLine("   Bribed the worker one time.");
                    } else
                    {
                        Console.WriteLine("   Bribed the worker " + temp.bribedTimes + " times.");
                    }
                }
                Console.WriteLine("");
                temp = temp.next;
                count++;
            }
        }

        //keep track how many times the group has bribed the worker
        public void incrementBribeTimes(String groupName)
        {
            if (this.head.groupName == groupName)
            {
                Console.WriteLine("Can not move '" + groupName + "' up the line, since it is first in the line");
                Console.WriteLine("");
                return;
            }

            node temp = this.head;
            while (temp != null)
            {
                if (temp.groupName == groupName)
                {
                    temp.bribedTimes++;
                    bribeMove(groupName);
                }
                temp = temp.next;
            }
        }

        //move the group up the line
        public void bribeMove(String name)
        {
            node temp = this.head;
            if (temp.next.groupName == name)
            {
                this.head = temp.next;
                node tempLast = this.head.next;
                temp.next = tempLast;
                head.next = temp;

                Console.WriteLine("The worker accepted the bribe from the group '" + name + "'.");
                Console.WriteLine("");
                return;
            }
            
            while (temp.next.next != null)
            {
                if (temp.next.next.groupName == name)
                {
                    node tempMid = temp.next;
                    node targetNode = tempMid.next;
                    tempMid.next = tempMid.next.next;

                    targetNode.next = tempMid;
                    temp.next = targetNode;

                    Console.WriteLine("The worker accepted the bribe from the group '" + name + "'.");
                    Console.WriteLine("");
                    return;
                }
                temp = temp.next;
            }

            Console.WriteLine("The worker did not accepted the bribe from the group '" + name + "'.");
            Console.WriteLine("");
        }
    }

    class Program
    {
        public static void Main()
        {
            LinkedList queue = new LinkedList();
            int seatCapacity = 20;
            int seatOccupied = 0;

            displayRulesAndCommands();
            processCommand(queue, seatCapacity, seatOccupied);
        }

        public static void processCommand(LinkedList myList, int seatCapacity, int seatOccupied)
        {
            String originalInput = "";
            String initialCommand = "";
            int indexCommand;

            while (true)
            {
                Console.WriteLine("Enter 'exit' to exit the program or 'help' to display commands and rules");
                Console.Write("Your command: ");
                originalInput = Console.ReadLine();

                indexCommand = originalInput.IndexOf(' '); //-1 if not found

                if (indexCommand != -1)
                {
                    initialCommand = originalInput.Substring(0, indexCommand);
                }

                if ((originalInput == "h") || (originalInput == "help") || (originalInput == "HELP"))
                {
                    displayRulesAndCommands();
                }
                else if ((originalInput == "e") || (originalInput == "exit"))
                {
                    displayQueue(myList);
                    Console.WriteLine("Exiting the program");
                    break;
                }
                else if ((originalInput == "d") || (originalInput == "display"))
                {
                    displayQueue(myList);
                }
                else if (originalInput == "ride")
                {
                    ride(myList, seatCapacity, ref seatOccupied);
                }
                else if (indexCommand == -1)
                {
                    //try again message
                    Console.WriteLine("Invalid command. Please Try again.");
                    Console.WriteLine("");
                }
                else if (initialCommand == "b")
                {
                    String inputGroupname = originalInput.Substring(2);
                    inputGroupname = inputGroupname.Replace(" ", ""); //remove blank space
                    BribeGroup(inputGroupname, myList);
                }
                else if (initialCommand == "r")
                {
                    String inputGroupname = originalInput.Substring(2);
                    inputGroupname = inputGroupname.Replace(" ", ""); //remove blank space
                    RemoveGroup(inputGroupname, myList);
                }
                else if (initialCommand == "m")
                {
                    String tempCommand = originalInput;
                    tempCommand = tempCommand.Substring(2);

                    int emptyIndex;
                    emptyIndex = tempCommand.IndexOf(' '); //-1 if not found
                    if (emptyIndex == -1)
                    {
                        Console.WriteLine("Invalid command. Please Try again."); //try again message
                        Console.WriteLine("");
                    }

                    String groupName = tempCommand.Substring(0, emptyIndex);


                    //read in adults int value
                    emptyIndex = tempCommand.IndexOf(' '); //-1 if not found
                    if (emptyIndex == -1)
                    {
                        Console.WriteLine("Invalid command. Please Try again."); //try again message
                        Console.WriteLine("");
                    }

                    tempCommand = tempCommand.Substring(emptyIndex + 1);

                    emptyIndex = tempCommand.IndexOf(' '); //-1 if not found. To get adults value
                    int adults = 0;
                    strToInt(tempCommand.Substring(0, emptyIndex), ref adults);

                    if (adults == -1)
                    {
                        Console.WriteLine("Invalid adult value. Please Try again."); //try again message
                        //Console.WriteLine("");
                    }


                    //read in children int value
                    emptyIndex = tempCommand.IndexOf(' '); //-1 if not found
                    if (emptyIndex == -1)
                    {
                        Console.WriteLine("Invalid command. Please Try again."); //try again message
                        Console.WriteLine("");
                    }

                    tempCommand = tempCommand.Substring(emptyIndex + 1);

                    int children = 0;
                    strToInt(tempCommand.Substring(0), ref children);

                    if (children == -1)
                    {
                        Console.WriteLine("Invalid children value. Please Try again."); //try again message
                        //Console.WriteLine("");
                    }

                    makeGroup(adults, children, groupName, myList);
                }
                else
                {
                    Console.WriteLine("Invalid command. Please Try again."); //try again message
                    Console.WriteLine("");
                }
            }
        }

        public static void displayRulesAndCommands()
        {
            Console.WriteLine("Setup: The Roller Coaster has capacity of 20.");
            Console.WriteLine("       There are 10 carts and each cart has two seats");
            Console.WriteLine("");
            Console.WriteLine("Rules: A child must always be accompnied by an adult from the same group when on the Roller Coaster");
            Console.WriteLine("       There can't be more children then adults in a group when entering the queue.");
            Console.WriteLine("       You can not bribe if you are first in the line");
            Console.WriteLine("       The group can not be no more than 20 people");
            Console.WriteLine("       This Roller Coaster will try to get as many people on board as possible");
            Console.WriteLine("       An adult from one group may be sitting with an adult from another group to maximize efficiency.");
            Console.WriteLine("");
            Console.WriteLine("Commands: Enter h or help to display commands and rules");
            Console.WriteLine("          Enter e or exit to exit the program");
            Console.WriteLine("          Enter d or display to display the queue");
            Console.WriteLine("          Enter b <groupname> to bribe and move in front of the group ahead of you");
            Console.WriteLine("          Enter r <groupname> to remove the group from queue");
            Console.WriteLine("          Enter m <groupname> <adults> <Children> to make group");
            Console.WriteLine("          Enter ride to fill Roller Coaster with riders.");
            Console.WriteLine("");
        }

        public static void displayQueue(LinkedList myList)
        {
            myList.displayAllGroupInfo();
        }

        public static void makeGroup(int adults, int children, String groupName, LinkedList myList)
        {
            int numPeople = adults + children;
            //verify that the group limit is less than 20
            if (numPeople > 20)
            {
                Console.WriteLine("The group can not have more than 20 riders");
                Console.WriteLine("");
                return;
            }

            //verify that there are no more children than adults in the group
            if (adults < children)
            {
                Console.WriteLine("There can not be more children than adults to accompny them on the rollarcoaster.");
                Console.WriteLine("It is about safety issue. Sorry for the inconvenience");
                Console.WriteLine("");
                return;
            }

            if (myList.groupNameExist(groupName))
            {
                Console.WriteLine("A group with this name already exists. Please try again");
                Console.WriteLine("");
                return;
            }

            if (adults < 0)
            {
                Console.WriteLine("Please enter a positive integer for adults");
                Console.WriteLine("");
            }

            if (children < 0)
            {
                Console.WriteLine("Please enter a positive integer for children");
                Console.WriteLine("");
            }

            myList.InsertAtEnd(adults, children, groupName);
        }

        public static void RemoveGroup(String groupName, LinkedList myList)
        {
            if (!(myList.groupNameExist(groupName)))
            {
                Console.WriteLine("There is no group registered under the name of " + groupName + ". Please try again");
                Console.WriteLine("");
                return;
            }

            myList.removeGroup(groupName, false);
        }

        public static void BribeGroup(String groupName, LinkedList myList)
        {
            if (!(myList.groupNameExist(groupName)))
            {
                Console.WriteLine("There is no group registered under the name of " + groupName + ". Please try again");
                Console.WriteLine("");
                return;
            }

            myList.incrementBribeTimes(groupName);
        }

        public static void ride(LinkedList myList, int seatCapacity, ref int seatOccupied)
        {
            myList.removeGroupForRide(seatCapacity);
        }

        public static void strToInt(String inputString, ref int num)
        {
            string intString = inputString;
            int i = 0;
            if (!Int32.TryParse(intString, out i))
            {
                i = -1;
            }
            num = i;
        }
    }
}
