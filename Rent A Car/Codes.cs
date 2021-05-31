using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car
{
    class Codes
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string usertype { get; set; }

        public int CarsID { get; set; }
        public string ReqNo { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Available { get; set; }
        public string Price { get; set; }

        public int CustID { get; set; }
        public string Cust_TC { get; set; }
        public string CustName { get; set; }
        public string CustSurName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }

        public int RentID { get; set; }
        public DateTime Rent_Date { get; set; }
        public DateTime Return_Date { get; set; }
        public string Fee { get; set; }

        public int ReturnID { get; set; }
        public int Delay { get; set; }
        public int Fine  { get; set; }

    }
}
