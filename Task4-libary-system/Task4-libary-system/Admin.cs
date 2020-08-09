using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_libary_system
{
    class Admin
    {
        string name;//admin name
        public string Username;//admins username
        public string password;//admins password
        public List<customer> customers = new List<customer>();//customers
        public List<Books> Books = new List<Books>(); //books in libary
        //constructor
        public Admin(string Name, string username, string pass)
        {
            this.name = Name;
            this.Username = username;
            this.password = pass;
        }
        public void AddBook() 
        {
            int newid = this.Books.Count + 1;// the new books ID
            Console.Clear();
            Console.WriteLine("Enter the Books Name:");
            string bookinput = Console.ReadLine(); //the new books name
            Console.Clear();
            Console.WriteLine("Enter the Authors First Name");
            string AFNameinput = Console.ReadLine();//The authors first name
            Console.Clear();
            Console.WriteLine("Enter the Authors Last Name");
            string ASInput = Console.ReadLine();//the authors lastname
            //adds a new book then sets the values
            this.Books.Add(new Books(newid, bookinput, AFNameinput, ASInput));
            
        }//add a book
        public void AddMember()
        {
            int newid = this.customers.Count + 1;//new ID
            Console.Clear();
            Console.WriteLine("Enter the Members First Name");
            string AFNameinput = Console.ReadLine();//user inputs the new name
            Console.Clear();
            Console.WriteLine("Enter the Members Last Name");
            string ASInput = Console.ReadLine();//the user inputs the new last name
            //sets the nalues to a new customer
            this.customers.Add(new customer(newid, AFNameinput, ASInput));

        }//add a member
        public void LoanBook() 
        {
            int isbook = 0;// boolean to show the input is the book
            int isuser = 0;// boolean to show the input is the user
            Console.WriteLine("Type the id of the book you want to loan");
            string userselect = Console.ReadLine();//users choice
            for(int x = 0; x < Books.Count; x++) 
            {   //if user input equals the book id it is the book
                if (int.Parse(userselect) == this.Books[x].ID) 
                {
                    isbook = 1;
                }
            }
            if(isbook == 1) //if the book was found.
            {
                Console.WriteLine("Type the id of the customer using the book:");
                string userselectuser = Console.ReadLine();//user puts in there choice

                for (int x = 0; x < Books.Count; x++)
                {
                    if (this.Books[x].isloaned == 0)
                    {//if user input equals the user id it is the user
                        isuser = 1;
                    }
                }
                if (isuser == 1)//if the user was found
                {
                    if (this.Books[int.Parse(userselect)].istaken == 0)
                    {//if the user is not taken set is taken the assign the book to the user
                        this.Books[int.Parse(userselect)].isloaned = 1;
                        this.Books[int.Parse(userselect)].ThereID = this.Books[int.Parse(userselect)].ThereID + this.customers[int.Parse(userselectuser)].customerID;
                        this.Books[int.Parse(userselect)].loaniesfname = this.Books[int.Parse(userselect)].loaniesfname + this.customers[int.Parse(userselectuser)].FName;
                        this.Books[int.Parse(userselect)].loaniesLname = this.Books[int.Parse(userselect)].loaniesLname + this.customers[int.Parse(userselectuser)].Secondname;
                        this.Books[int.Parse(userselect)].istaken = 1;

                    }
                    else if (this.Books[int.Parse(userselect)].istaken == 1) 
                    {//if it is taken show error
                        Console.WriteLine("This book has been loaned to somone else press enter to go back");
                        Console.ReadLine();
                    }
                }
                else if (isuser == 0)
                {//if user is not found show error
                    Console.WriteLine("invalid input");
                    Console.ReadLine();
                }
            }
            else if (isbook == 0)
            {//if is not book show error
                Console.WriteLine("Invalid input");
                Console.ReadLine();
            }
            
        }//loaned a book
        public void RetrivedBook()
        {
            int isbook = 0;// found book
            
            Console.WriteLine("Type the id of the book you want to return");
            string userselect = Console.ReadLine();//userinput
            for (int x = 0; x < Books.Count; x++)
            {
                if (int.Parse(userselect) == this.Books[x].ID)
                {// if the userinput = book id
                    isbook = 1;// book found
                }
            }
            if (isbook == 1)
            {//if user input is book


                if (this.Books[int.Parse(userselect)].istaken == 1)
                {//if book id is taken null all relations with the customer
                    this.Books[int.Parse(userselect)].isloaned = 0;
                    this.Books[int.Parse(userselect)].ThereID = null;
                    this.Books[int.Parse(userselect)].loaniesfname = null;
                    this.Books[int.Parse(userselect)].loaniesLname = null;
                    this.Books[int.Parse(userselect)].istaken = 0;
                }
                else if (this.Books[int.Parse(userselect)].istaken == 0)
                {// if the book is not taken show error
                    Console.WriteLine("Invalid Input sice book is not taken");
                    Console.ReadLine();
                }
            }
        }//recive book
    }
}
