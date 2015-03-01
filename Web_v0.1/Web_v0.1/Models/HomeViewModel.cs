using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_v0._1.Models
{
    public class HomeViewModel
    {
        public AccountModel Account { get; set; }
        public List<PostModel> Posts { get; set; }
    }
}