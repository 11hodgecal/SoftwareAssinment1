using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_libary_system
{
    class Books
    {
        public int ID;//book ID
        public string BookName;//book name
        public string authorFN;//author first name
        public string autherLN;//auther last name

        //if it is loaned
        public int isloaned = 0;// is the book loaned
        public int istaken = 0;//is taken by somone
        public string ThereID;//there ID
        public string loaniesfname;//firstname
        public string loaniesLname;//lastname
        //constructor
        public Books(int id, string Bname, string fName, string LastN)
        {
            this.ID = id;
            this.BookName = Bname;
            this.authorFN = fName;
            this.autherLN = LastN;
           
        }
    }
}
