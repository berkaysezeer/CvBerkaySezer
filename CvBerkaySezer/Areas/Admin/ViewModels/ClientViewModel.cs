using CvBerkaySezer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CvBerkaySezer.Areas.Admin.ViewModels
{
    public class ClientViewModel
    {
        public ICollection<Hosting> Hostings { get; set; }
        public Client Client { get; set; }
    }
}