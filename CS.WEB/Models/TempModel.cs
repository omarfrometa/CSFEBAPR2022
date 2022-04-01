using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS.WEB.Models
{
    public class TempModel
    {
        public List<BO.User> Users { get; set; }
        public List<BO.Country> Countries { get; set; }
    }
}