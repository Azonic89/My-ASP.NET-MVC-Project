﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace CarSystem.Web.Models.Manage
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
    }
}