using CvBerkaySezer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvBerkaySezer.Areas.Admin.Functions
{
    public static class DropdownListItems
    {
        public static IEnumerable<SelectListItem> GetServiceProvider()
        {
            ServiceProviderRepository db = new ServiceProviderRepository();
            IEnumerable<SelectListItem> services = new SelectList(db.List(x => x.IsDeleted == false), "Id", "Name");
            return services;
        }
    }
}