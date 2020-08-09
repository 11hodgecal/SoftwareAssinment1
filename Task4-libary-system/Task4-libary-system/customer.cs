using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_libary_system
{
    class customer
    {
        public int customerID;//customer id
        public string FName;//customer firstname
        public string Secondname;//customer second name
        //constructor
        public customer(int ID,string fName,string SName) 
        {

            this.customerID = ID;
            this.FName = fName;
            this.Secondname = SName;
        }
    }
}
