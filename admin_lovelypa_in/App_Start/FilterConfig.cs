﻿using System.Web;
using System.Web.Mvc;

namespace admin_lovelypa_in
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
