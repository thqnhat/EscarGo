﻿using System.Web.Mvc;

namespace EscarGo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute
            {
                View = "Error"
            }, 1);
        }
    }
}
