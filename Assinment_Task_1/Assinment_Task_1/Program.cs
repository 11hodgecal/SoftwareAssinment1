using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assinment_Task_1
{
        class Program
        {
            
        static void Main(string[] args)
        {

            int[] coachID = { 1, 2, 3, 4, 5 };// sets the coach ID
            int[] BSeats = { 0, 0, 0, 0, 0 };// sets up the booked seats
            int[] POASeats = { 0, 0, 0, 0, 0 }; // sets up the pay on arival seats
            int[] Totalseats = { 0, 0, 0, 0, 0 };// sets up the total seats
            int[] finalSeats = { 0, 0, 0, 0, 0 }; //have a sorted version of current variable to compare values to original
            int maximumseats = 52;// maximum ammout of seats each coach has
            int remainingseats = 52;//to show the remaining seats

            
            void Startup()
            {
                Console.Clear();
                
                //tells the user what they are entering information for
                
                for (int i = 0; i < BSeats.Length; i++)//add values to each of the coaches
                {
                    remainingseats = maximumseats;//resets remaining seats
                    Console.Clear();
                    Console.WriteLine("please enter the details for the 5 coaches each coach has a maximum of 52 seats");
                    Console.WriteLine("please enter the amount of booked seats for coach {0}:",coachID[i]);
                    string Userinput = Console.ReadLine();//user input
                    if (Userinput == "")
                    {
                        Console.WriteLine("Invalid input press enter to start again since you entered nothing");
                        Console.ReadLine();
                        Startup();
                    }
                    else if (int.Parse(Userinput) > remainingseats) //if userinput has inputted a number above remaining seats show error and restart
                    {
                        Console.WriteLine("Invalid input press enter to start again since it has exceded the ammount of seats");
                        Console.ReadLine();
                        Startup();
                    }
                    
                    BSeats[i] = int.Parse(Userinput);//bseats equals user input
                    Console.WriteLine();
                    Console.WriteLine();

                    Console.WriteLine("please enter the amount of pay on arrival seats for coach {0}:", coachID[i]);

                    remainingseats = remainingseats - BSeats[i];//remaining seats = what seats are left after the booked seats
                    Console.WriteLine("There are {0} seats left",remainingseats);//shows the user the amount of seats left
                    Userinput = Console.ReadLine();//userinput
                    if (remainingseats < int.Parse(Userinput))// if user input is more then remaining seats show error and restart
                    {
                        Console.WriteLine("Invalid input press enter to start again since it has exceded the ammount of seats");
                        Console.ReadLine();
                        Startup();
                    }
                    else if (Userinput == "")
                    {
                        Console.WriteLine("Invalid input press enter to start again since you entered nothing");
                        Console.ReadLine();
                        Startup();
                    }
                    else if (remainingseats >= int.Parse(Userinput))// if remaining seats is less than user input
                    {
                        POASeats[i] = int.Parse(Userinput);//pay on arrival seats equals userinput.
                        Console.WriteLine();
                        Console.WriteLine();
                    }



                    Totalseats[i] = BSeats[i] + POASeats[i];// fills the total seats with values
                    finalSeats[i] = Totalseats[i];// fills the final seats with values
                    
                }

                
                
                menuBrowser();//goes to the main menu
            }

            

            //main Menu
            void menuBrowser(){
                
                //For the User to read
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("What Information do you need to know about the Coaches:");
                Console.WriteLine();
                Console.WriteLine("All Information - 1");
                Console.WriteLine();
                Console.WriteLine("The least to most busy Coach - 2");
                Console.WriteLine();
                Console.WriteLine("The least to most booked Coach - 3");
                Console.WriteLine();
                Console.WriteLine("The least to most Pay on arrival Coach - 4");
                Console.WriteLine();
                Console.WriteLine("To change the values type 5 - 5");
                Console.WriteLine();
                Console.WriteLine("Exit - press enter");
                Console.WriteLine();

                string input = Console.ReadLine();//user input

                Console.WriteLine();

                //userchoice
                if (input == "1")
                {

                    Console.Clear();//clears the console
                    DisplayAll();//displays all information

                }
                if (input == "2")
                {

                    Console.Clear();//clears the console
                    DisplayPopulariy();//displays popularity

                }
                if (input == "3")
                {
                    Console.Clear();//clears the console
                    DisplayBookpop();//displays most booked

                }
                if (input == "4")
                {
                    Console.Clear();//clears the console
                    DisplayPOAPOP();//displays most pay on arrival

                }
                if (input == "5")//allows the user to input new values
                {
                    Console.Clear();//clears the console
                    Startup();//displays most pay on arrival

                }
            }

            //Menu1-all information
            void DisplayAll()
            {
                Console.WriteLine("Total Number of passengers on each coach:");
                Console.WriteLine();
                Console.WriteLine("Coach ID / Booked Seats / Pay on Arrival/ Total used Seats/");



                for (int i = 0; i < Totalseats.Length; i++) // displays the ingformation
                {


                    Console.WriteLine("Coach {0}  /       {1}      /       {2}       /     {3}     /", coachID[i], BSeats[i], POASeats[i], Totalseats[i]);//outputs all information


                }


                Console.WriteLine("press enter to continue");
                Console.ReadLine();
                menuBrowser();

            }












            //Menu2- least to most busy.
            void DisplayPopulariy()
            {
                int[] popularityarray = { 1,2,3,4,5};
                Array.Sort(finalSeats,coachID);// sorts finalSeats by finalseats
                

                
                Console.WriteLine("");
                Console.WriteLine("The Coaches have been ordered from the least to the most busiest:");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Least busy:");
                Console.WriteLine("__________________________________________________________");
                for (int i = 0; i < Totalseats.Length; i++)//display all infomation
                {
                    
                            Console.WriteLine("coach: {0} /// Total Seats:{1}",coachID[i],finalSeats[i]);
                            Console.WriteLine();
                      
                }
                Console.WriteLine("__________________________________________________________");
                Console.WriteLine("");
                Console.WriteLine("Most busy:");
                Console.WriteLine("press enter to continue");
                Console.ReadLine();
                menuBrowser();

            }






            //menu 3- to show the least to most booked coach
            void DisplayBookpop()
            {

                int[] Finalbseats = { 0, 0, 0, 0, 0 };//have a sorted version of current variable to compare values to original


                for (int i = 0; i < BSeats.Length; i++)
                {


                    Finalbseats[i] = BSeats[i];// fills the final seats with values


                }


                Array.Sort(Finalbseats,coachID);// sorts ID by Bseats

                Console.WriteLine("");
                Console.WriteLine("The Coaches have been ordered from the least to the most Booked:");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Least Booked:");
                Console.WriteLine("__________________________________________________________");
                for (int i = 0; i < Totalseats.Length; i++)//if 
                {
                    
                            Console.WriteLine("coach: {0} /// Total Seats:{1}",coachID[i],Finalbseats[i]);
                            Console.WriteLine();
                      
                }
                Console.WriteLine("__________________________________________________________");
                Console.WriteLine("");
                Console.WriteLine("Most Booked:");
                Console.WriteLine("");
                Console.WriteLine("press enter to continue");
                Console.ReadLine();
                menuBrowser();
            }

            //Menu 4 - Displays the least to the most pay on arrival
            void DisplayPOAPOP()
            {

                int[] FinalPOAseats = { 0, 0, 0, 0, 0 };// have a sorted version of current variable to compare values to original



                for (int i = 0; i < BSeats.Length; i++)
                {


                    FinalPOAseats[i] = POASeats[i];// fills the final seats with values


                }


                Array.Sort(FinalPOAseats,coachID);// sorts ID by POAseats

                Console.WriteLine("");
                Console.WriteLine("The Coaches have been ordered from the least to the most Pay on arrival:");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Least Pay on Arrival:");
                Console.WriteLine("__________________________________________________________");
                for (int i = 0; i < Totalseats.Length; i++)//if 
                {
                    
                            Console.WriteLine("coach: {0} /// Total Seats:{1}",coachID[i],FinalPOAseats[i]);
                            Console.WriteLine();
                      
                }
                Console.WriteLine("__________________________________________________________");

                Console.WriteLine("");
                Console.WriteLine("Most pay on arrival:");
                Console.WriteLine("");
                Console.WriteLine("press enter to continue");
                Console.ReadLine();
                menuBrowser();
            }


            Startup();
            
            

           
           
            



        }
    }
}
