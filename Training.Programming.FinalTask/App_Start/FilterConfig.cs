﻿using System.Web;
using System.Web.Mvc;

namespace Training.Programming.FinalTask
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
