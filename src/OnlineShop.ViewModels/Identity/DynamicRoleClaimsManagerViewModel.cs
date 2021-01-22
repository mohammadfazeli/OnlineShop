﻿using System.Collections.Generic;
using OnlineShop.Entities.Identity;
using DNTCommon.Web.Core;

namespace OnlineShop.ViewModels.Admin
{
    public class DynamicRoleClaimsManagerViewModel
    {
        public string[] ActionIds { set; get; }

        public int RoleId { set; get; }

        public Role RoleIncludeRoleClaims { set; get; }

        public ICollection<MvcControllerViewModel> SecuredControllerActions { set; get; }
    }
}