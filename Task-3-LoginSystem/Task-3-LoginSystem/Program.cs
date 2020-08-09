using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_LoginSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var isadmin = new List<int> { 1, 0, 0, 0 };//is the account a admin
            var username = new List <string> {"JOHNSM22738", "JANEDO98786", "BRYNW56655", "NESSAJ25255" };//usernames
            var password = new List<string> { "D7y6a", "i&acN", "GgjN6", "3KsyX" };//passwords
            var firstname = new List<string> { "John", "Jane", "Bryn", "Nessa" };//firstnames
            var lastname = new List<string> { "Smith", "Doe", "Williams", "Jenkins"};//lastnames
            var ID = new List<int> { };
            int LogMax = 3;// max log in attemptes
            int LogCur = 0;//current log in attempts 
            int LogCD = 3;// how many attempts left
            string user = "";//who is the user
            int num = 0;
            bool userlock = false;//shows whether a computer is locked 

            for (int x = 0; x < username.Count; x++) // assines 0 to admin and with the users the numbers go up by one as they are added
            {
                if (isadmin[x] == 1) 
                {
                    ID.Add(0); 
                }
                if (isadmin[x] == 0)
                {
                    num++;
                    ID.Add(num);
                }
               
                
            }



            void LogIn() //logs a user in
            {
                int isuserright = 0;//show if user is wrong
                int ispassright = 0;// show if pass is wrong
                int FIsAdmin = 0;//check if user is an admin in the while loop
                LogCur = 0;
                user = "";
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


                    for (int x = 0; x < username.Count; x++)
                    {
                        //if the details where right

                        if (username[x] == Username) // if userinput = username add 1 to is right
                        {
                            user = Username;//checks which user is logged in
                            ispassright++;
                            if (password[x] == Password)// if userinput = password add 1 to is right
                            {
                                ispassright++;
                                if (ispassright == 2) //if isright equals 2 login
                                {

                                    LogCur = 4;
                                    if (isadmin[x] == 1) //checks if the user is a admin
                                    {

                                        FIsAdmin = 1;

                                    }
                                    else // checks if user is a normal user
                                    {

                                        FIsAdmin = 0;
                                    }

                                }

                            }

                        }
                        if (password[x] == Password) // if password is right
                        {

                            isuserright++;
                            if (username[x] == Username) // if uname is right
                            {
                                isuserright++;
                                if (isuserright == 2) // log in
                                {
                                    LogCur = 4;
                                }

                            }

                        }
                    }

                    //what do do if details are wrong
                    if (isuserright == 1) // if username show user error and the attempts they have left
                    {
                        Console.WriteLine("You have entered your Username wrong");
                        if (LogCD > 1)
                        {
                            Console.WriteLine("remaining Attempts: {0}", LogCD);
                        }
                        Console.WriteLine();
                        Console.ReadLine();
                    }
                    else if (ispassright == 1) // if password is wrong show error
                    {
                        Console.WriteLine("you have entered your Password wrong");
                        if (LogCD > 0)
                        {
                            Console.WriteLine("remaining Attempts: {0}", LogCD);
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ReadLine();
                    }
                    else if (ispassright == 0)// if both are wrong show wrong
                    {
                        Console.WriteLine("you entered both your password and Username wrong");
                        if (LogCD > 0)
                        {
                            Console.WriteLine("remaining Attempts: {0}", LogCD);
                        }
                        Console.WriteLine();
                        Console.ReadLine();
                    }



                }
                
                
                if (LogCur == 4)
                {
                    foreach (int x in isadmin)
                        if (FIsAdmin == 1) //if the user is a admin log in as admin
                        {
                            Console.Clear();
                            HiAdmin();
                            break;

                        }
                        else if (FIsAdmin == 0) // if user is user log in as user
                        {
                            Console.Clear();
                            HiUser();
                            break;
                        }
                    
                }
                else if (LogCur == LogMax) //tells the user they are out of attempts
                {
                    userlock = true;//userlock is true
                    Console.WriteLine("You are out of attempts restart or get a admin to log in to unlock you...");
                    Console.WriteLine("To login as admin type: 1");
                    Console.WriteLine("Exit: Enter");
                    string Userinput = Console.ReadLine();
                    if (Userinput == "1") //if user input equals 1 log in as only admin
                    {
                        isuserright = 0;//show if user is wrong
                        ispassright = 0;// show if pass is wrong
                        LogCur = 0;
                        user = "";
                        // same as the previous login method but it only works for the admin
                        while (LogMax > LogCur) //while within the ammount of attemts allowed
                        {

                            //for user
                            LogCur++;//add one to log current
                            LogCD--;// add one to log count down
                            Console.Clear();
                            Console.WriteLine("To log in as admin please enter your username and password:");
                            Console.WriteLine();
                            Console.WriteLine("Username:");
                            string Username = Console.ReadLine();//user input = Username
                            Console.WriteLine("Password:");
                            string Password = Console.ReadLine();//user input = password
                            Console.WriteLine();



                            for (int x = 0; x < username.Count; x++)
                            {
                                //if the details where right

                                if (username[0] == Username) // if userinput = username add 1 to is right
                                {
                                    user = Username;//checks which user is logged in
                                    ispassright++;
                                    if (password[0] == Password)// if userinput = password add 1 to is right
                                    {
                                        ispassright++;
                                        if (ispassright == 2) //if isright equals 2 login
                                        {

                                            LogCur = 4;
                                            if (isadmin[x] == 1) //checks if the user is a admin
                                            {

                                                FIsAdmin = 1;

                                            }

                                        }

                                    }

                                }
                                if (password[0] == Password) // if password is right
                                {

                                    isuserright++;
                                    if (username[0] == Username) // if uname is right
                                    {
                                        isuserright++;
                                        if (isuserright == 2) // log in
                                        {
                                            LogCur = 4;
                                        }

                                    }

                                }
                            }

                            //what do do if details are wrong
                            if (isuserright == 1) // if username show user error and the attempts they have left
                            {
                                Console.WriteLine("You have entered your Username wrong");
                                Console.WriteLine();
                                Console.ReadLine();
                            }
                            else if (ispassright == 1) // if password is wrong show error
                            {
                                Console.WriteLine("you have entered your Password wrong");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.ReadLine();
                            }
                            else if (ispassright == 0)// if both are wrong show wrong
                            {
                                Console.WriteLine("you entered both your password and Username wrong");
                                Console.WriteLine();
                                Console.ReadLine();
                            }



                        }// same as the previous login method


                        if (LogCur == 4)
                        {
                            foreach (int x in isadmin)
                                if (FIsAdmin == 1) //if the user is a admin log in as admin
                                {
                                    Console.Clear();
                                    HiAdmin();
                                    break;

                                }

                        }

                    }
                }
            }

            void HiAdmin() //what admins see's
            {
                void ChangeDetails()//change users details
                {
                    Console.WriteLine("enter the id of the User you want to change");
                    string UserinputID = Console.ReadLine();
                    if (UserinputID == "0")//goes back to the main menu and show error
                    {
                        Console.WriteLine("Invalid Input");
                        Console.ReadLine();
                        Mainmenu();
                    }
                    else if (int.Parse(UserinputID) > ID.Max())//goes back to the main menu and show error
                    {
                        Console.WriteLine("Invalid Input");
                        Console.ReadLine();
                    }
                    //stores all infomation assosiated with the id
                    string[] userinfoarray = { username[int.Parse(UserinputID)], password[int.Parse(UserinputID)], firstname[int.Parse(UserinputID)], lastname[int.Parse(UserinputID)] };
                    //shows user the choices
                    Console.WriteLine("What details do you want to change:");
                    Console.WriteLine("Username: 1");
                    Console.WriteLine("Password: 2");
                    Console.WriteLine("Firstname: 3");
                    Console.WriteLine("Lastname: 4");
                    string Userinput = Console.ReadLine();
                    if (Userinput == "0") //goes back to the main menu
                    {
                        Mainmenu();
                    }
                    if (Userinput == "1") // lets admin change the username
                    {
                        for (int x = 0; x < ID.Count; x++) 
                        {
                            if (Userinput == "")//shows error goes back to admin menu
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid Input press enter to continue");
                                Console.ReadLine();
                            }
                            else if (username[x] == userinfoarray[0]) //if user name equals user info
                            {
                                Console.Clear();
                                Console.WriteLine("New Username:");
                                Userinput = Console.ReadLine();//the new username
                                username[x] = Userinput; // sets the new username
                            }
                        }
                    }
                    if (Userinput == "2")// lets admin change the password
                    {
                        for (int x = 0; x < ID.Count; x++)
                        {
                            if (Userinput == "")//shows error goes back to admin menu
                            {
                                
                                Console.Clear();
                                Console.WriteLine("Invalid Input press enter to continue");
                                Console.ReadLine();
                            }
                            else if (password[x] == userinfoarray[1])//if password equals user info
                            {
                                Console.Clear();
                                Console.WriteLine("New Username:");
                                Userinput = Console.ReadLine();//the new password
                                password[x] = Userinput;// sets the new password
                            }
                        }
                    }
                    if (Userinput == "3")// lets admin change the first name
                    {
                        for (int x = 0; x < ID.Count; x++)
                        {
                            if (Userinput == "")//shows error goes back to admin menu
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid Input press enter to continue");
                                Console.ReadLine();
                            }
                            else if (firstname[x] == userinfoarray[2])//if firstname equals user info
                            {
                                Console.Clear();
                                Console.WriteLine("New Username:");
                                Userinput = Console.ReadLine();//the new fname
                                firstname[x] = Userinput;// sets the new fname
                            }
                        }
                    }
                    if (Userinput == "4")// lets admin change the second name
                    {
                        for (int x = 0; x < ID.Count; x++)
                        {
                            if (Userinput == "")//shows error goes back to admin menu
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid Input press enter to continue");
                                Console.ReadLine();
                            }
                            else if (lastname[x] == userinfoarray[3])//if lastname equals user info
                            {
                                Console.Clear();
                                Console.WriteLine("New Username:");
                                Userinput = Console.ReadLine();//the new Sname
                                lastname[x] = Userinput;// sets the new Sname
                            }
                        }
                    }
                    

                    Mainmenu();                        
                    
                }
                void AddnRemove()// add or remove a user
                {
                    void ADD() //add user
                    {
                        
                        //new users username 
                        Console.WriteLine("Please enter the new users Username");
                        string Userinput = Console.ReadLine();
                        username.Add(Userinput);
                        Console.Clear();
                        //new users password
                        Console.WriteLine("Please enter the new users password");
                        Userinput = Console.ReadLine();
                        password.Add(Userinput);
                        Console.Clear();
                        //new users firstname
                        Console.WriteLine("Please enter the new users Firstname");
                        Userinput = Console.ReadLine();
                        firstname.Add(Userinput);
                        Console.Clear();
                        //new users lastname
                        Console.WriteLine("Please enter the new users Lastname");
                        Userinput = Console.ReadLine();
                        lastname.Add(Userinput);
                        Console.Clear();
                        //add non admin status
                        isadmin.Add(0);
                        num++;
                        ID.Add(num);
                        
                        Console.Clear();
                        //return to main menu
                        Mainmenu();
                    }
                    void Remove()
                    {
                        Console.WriteLine("Please enter the ID of the User you want to remove");
                        string Userinput = Console.ReadLine();//user sets userinput
                        Console.WriteLine("press enter to confirm");//confirms the total deletion
                        Console.ReadLine();
                        
                        if (Userinput == "0")//goes back to the main menu and show error
                        {
                            Console.WriteLine("Invalid Input");
                            Console.ReadLine();
                        }
                        else if (int.Parse(Userinput) > ID.Max())//goes back to the main menu and show error
                        {
                            Console.WriteLine("Invalid Input");
                            Console.ReadLine();
                        }
                       


                        for (int x = 0; x < ID.Count; x++) //goes throu the id to look for which one non admin is assosiated with that id.
                        {
                            if (isadmin[x] == 0)
                            {
                                
                                if (ID[x] == int.Parse(Userinput))
                                {
                                    //deletes all infomation on the selected ID
                                    username.Remove(username[x]);
                                    password.Remove(password[x]);
                                    firstname.Remove(firstname[x]);
                                    lastname.Remove(lastname[x]);
                                    isadmin.Remove(isadmin[x]);
                                    ID.Remove(ID[x]);
                                }
                               
                                
                            }
                            
                        }
                        

                            Mainmenu();
                    }
                    Console.WriteLine("do you want to add or remove a user:");
                    Console.WriteLine("Add: 1");
                    Console.WriteLine("Remove: 2");
                    string userinput = Console.ReadLine();
                    if (userinput == "1")// if user input == 2 allow admin to use add&remove function 
                    {
                        ADD();
                    }
                    if (userinput == "2")// if user input == 2 allow admin to use change details function 
                    {

                        Remove();
                    }



                }
                void Mainmenu()
                {
                    Console.Clear();//clears console
                    if (userlock == false)//if normal login
                    {
                        for (int x = 0; x < username.Count; x++)
                        {
                            if (username[x] == user)//if username matches the user show a welcome message
                            {
                                Console.WriteLine("Welcome Admin, {0} {1}", firstname[x], lastname[x]);
                                Console.WriteLine();
                                Console.WriteLine("These are your users");
                            }
                            if (isadmin[x] == 0)// displays a user table
                            {
                                Console.WriteLine("/// ID:{0} ///Username: {1} /// Password: {2} /// Firstname: {3} /// Lastname: {4}", ID[x], username[x], password[x], firstname[x], lastname[x]);
                                Console.WriteLine();

                            }


                        }
                        //user choice
                        Console.WriteLine("what do you want to do next:");
                        Console.WriteLine();
                        Console.WriteLine("To add or remove a user: 1");
                        Console.WriteLine("To Update a users informaton: 2");
                        Console.WriteLine("To Log Out: 3");
                        Console.WriteLine("To exit: press enter");
                        string Userinput = Console.ReadLine();
                        if (Userinput == "1")// if user input == 2 allow admin to use add&remove function 
                        {
                            AddnRemove();
                        }
                        if (Userinput == "2")// if user input == 2 allow admin to use change details function 
                        {
                            ChangeDetails();
                        }
                        if (Userinput == "3")
                        {
                            LogIn();
                        }
                    }
                    else if (userlock == true) //not a full login the user cannot see the other logins while the admin is loging in
                    {
                        Console.WriteLine("Welcome Admin This computer is locked press 1 to unlock");
                        Console.WriteLine();
                        Console.WriteLine("To Unlock computer: 1");
                        Console.WriteLine("To exit: press enter");
                        string Userinput = Console.ReadLine();//user input
                        if (Userinput == "1")// if user input == 1 unlock computer
                        {
                            userlock = false;
                            LogIn();

                        }
                    }
                }
                
                Mainmenu();
                
            }
            
            void HiUser()//#What users see when they log in
            {
                for (int x = 0; x < username.Count; x++)
                {
                    if (username[x] == user)//if username matches the user show a welcome message including there status
                    {
                        Console.WriteLine("Welcome, {0} {1}", firstname[x], lastname[x]);
                    }
                }

                Console.WriteLine("press enter to Logout");
                Console.ReadLine();
                LogIn();
                
                
            }

            LogIn();
        }
    }
}
