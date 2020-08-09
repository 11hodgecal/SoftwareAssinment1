using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_libary_system
{
    class Program
    {
        static void Main(string[] args)
        {
            //initializes the admin class
            Admin Admin = new Admin("administrator", "Admin", "admin");
            //initializes the admin customers list
            Admin.customers = new List<customer> { new customer(0, "Billy", "Jones"), new customer(1, "Milly", "Thornberry"), new customer(2, "Jeffrey", "Hendrickson") };
            //initializes the admin customers Books
            Admin.Books = new List<Books> { new Books(0, "Malice", "John", "Gwynne"), new Books(1, "The prose Edda", "Snorri", "Sturluson"), new Books(2, "The Brain", "David", "Eagleman"), new Books(3, "Ghosts of Ascalon", "Matt", "Forbeck") };
            
            void LogIn() //logs a user in
            {
                int isuserright = 0;//show if user is wrong
                int ispassright = 0;// show if pass is wrong
                int FIsAdmin = 0;//check if user is an admin in the while loop
                int LogCur = 0;
                int LogMax = 3;
                int LogCD = 3;

                while (LogMax > LogCur) //while within the ammount of attemts allowed
                {

                    //for user
                    LogCur++;//add one to log current
                    LogCD--;// add one to log count down
                    Console.Clear();
                    Console.WriteLine("please enter your username and password:");
                    Console.WriteLine();
                    Console.WriteLine("Username:");
                    string Username = Console.ReadLine();//user input = Username
                    Console.WriteLine("Password:");
                    string Password = Console.ReadLine();//user input = password
                    Console.WriteLine();


                    
                        //if the details where right

                    if (Admin.Username == Username) // if userinput = username add 1 to is right
                    {
                            
                        ispassright++;
                        if (Admin.password == Password)// if userinput = password add 1 to is right
                        {
                            ispassright++;
                            if (ispassright == 2) //if isright equals 2 login
                            {

                                    LogCur = 4;

                            }

                        }

                    }
                    if (Admin.password == Password) // if password is right
                    {

                        isuserright++;
                        if (Admin.Username == Username) // if uname is right
                        {
                            isuserright++;
                            if (isuserright == 2) // log in
                            {
                                LogCur = 4;
                            }

                        }
                         

                    }  
                    
                    if (isuserright == 1)//if only userright equals 1 show error
                    {
                        Console.WriteLine("Attempts remaining: {0}",LogCD);
                        Console.WriteLine("Your Username is Invalid");
                        Console.ReadLine();
                    }
                    else if (ispassright == 1)//if only passright equals 1 show error
                    {
                        Console.WriteLine("Attempts remaining: {0}",LogCD);
                        Console.WriteLine("Your password was Invalid");
                        Console.ReadLine();
                    }
                    else if (isuserright == 0)// if both of them are wrong show error
                    {
                        Console.WriteLine("Attempts remaining: {0}",LogCD);
                        Console.WriteLine("Both your username and Password are invalid");
                        Console.ReadLine();
                    }
                }

            

                if (LogCur == LogMax)//show user is locked if passed the maximum attempts
                {
                    Console.Clear();
                    Console.WriteLine("To unlock please exit and come back later");
                }
                if (LogCur == 4)// if eqals 4 log in
                {
                    
                    Mainmenu();
                    
                }
            
            }//log in function

            void Mainmenu() 
            {
                //welcomes admin
                Console.WriteLine("Welcome Admin");
                //shows all of the customers of the libary
                Console.WriteLine("======================================================");
                Console.WriteLine("These are The Members:");
                Console.WriteLine("======================================================");
                for(int x = 0; x < Admin.customers.Count; x++) 
                {
                    Console.WriteLine("/// ID:{0} /// name:{1} /// Last First name:{2} ///",Admin.customers[x].customerID, Admin.customers[x].FName, Admin.customers[x].Secondname);

                }
                Console.WriteLine("======================================================");

                Console.WriteLine();
                Console.WriteLine();
                //shows all of the books of the libary
                Console.WriteLine("======================================================");
                Console.WriteLine("These are the Books in the libary:");
                Console.WriteLine("======================================================");
                for (int x = 0; x < Admin.Books.Count; x++) 
                {
                    if (Admin.Books[x].isloaned == 0) //if book not loaned show 
                    {
                        Console.WriteLine("///Book ID:{0} /// BookName: {1} /// Author name:{2} /// Author Last name:{3} ///", Admin.Books[x].ID, Admin.Books[x].BookName, Admin.Books[x].authorFN, Admin.Books[x].autherLN);
                    }
                }

                Console.WriteLine("======================================================");
                Console.WriteLine();

                //shows all of the books of that have been loaned and to who
                Console.WriteLine("======================================================");
                Console.WriteLine("These are the Books that have been Loaned:");
                Console.WriteLine("======================================================");
                for (int x = 0; x < Admin.Books.Count; x++)
                {
                    if (Admin.Books[x].isloaned == 1)//if book loaned show 
                    {
                        Console.WriteLine("///Book ID:{0} /// BookName: {1} /// Author name:{2} /// Author Last name:{3} /// )", Admin.Books[x].ID, Admin.Books[x].BookName, Admin.Books[x].authorFN, Admin.Books[x].autherLN);
                        Console.WriteLine("loaned to : Customer id {0}({1} {2})", Admin.Books[x].ThereID, Admin.Books[x].loaniesfname, Admin.Books[x].loaniesLname);
                        Console.WriteLine();
                    }
                }

                Console.WriteLine("======================================================");

                //user selection

                Console.WriteLine("To add a book: 1");
                Console.WriteLine("To add a member: 2");
                Console.WriteLine("To loan a book: 3");
                Console.WriteLine("To retrived a book: 4");
                Console.WriteLine("To exit press enter");
                Console.WriteLine("please select");
                string userinput = Console.ReadLine();//user input
                if (userinput == "")// if the user has entered nothing do nothing
                {
                    //do nothing
                }
                else if (userinput == "1") //if userinput equals 1 use addbook fuctions
                {
                    Admin.AddBook();
                    Console.Clear();
                    Mainmenu();

                }
                else if (userinput == "2") //if userinput equals 2 use addmember fuctions
                {
                    Admin.AddMember();
                    Console.Clear();
                    Mainmenu();
                }
                else if (userinput == "3") //if userinput equals 3 use loanbook fuctions
                {
                    Admin.LoanBook();
                    Console.Clear();
                    Mainmenu();
                }
                else if (userinput == "4")//if userinput equals 4 use retrive functions
                {
                    Admin.RetrivedBook();
                    Console.Clear();
                    Mainmenu();
                }
                else if (int.Parse(userinput) < 4) //if the user input more then 4 go back to the main menu
                {
                    Console.Clear();
                    Mainmenu();
                }
                

            }//mainmenu function
            LogIn();
            
        }
    }
}
