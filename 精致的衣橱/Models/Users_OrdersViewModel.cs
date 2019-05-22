using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace 精致的衣橱.Models
{
    public class Users_OrdersViewModel
    {
        public IEnumerable<Users> users;
        public IEnumerable<Address> address;
        public IEnumerable<Orders> orders;
    }
}