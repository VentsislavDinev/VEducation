using Abp.Application.Navigation;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VEducation.Web.App_Start
{
    public class VEducationSocialNavigationProvider : NavigationProvider
    {
        /// <summary>
        /// The set navigation.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void SetNavigation(INavigationProviderContext context)
        {
            var menu = new MenuDefinition("socialMenu", new LocalizableString("HomeMenus", "Social"));
                       menu.AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("Home", "Social"),
                        url: "/",
                        icon: "fa fa-home"))
                        //.AddItem(
                        //    new MenuItemDefinition(
                        //        "Tenants",
                        //        L("Tenants"),
                        //        url: "#tenants",
                        //        icon: "fa fa-globe",
                        //        requiredPermissionName: "Tenant"))
                        .AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", "Social"),
                        url: "/Home/about",
                        icon: "fa fa-info"))
                        .AddItem(
                            new MenuItemDefinition(
                                       "Contact",
                                       new LocalizableString("Contact", "Social"),
                                       url: "/Home/Contact",
                                       icon: "fa fa-info"))
               .AddItem(
                            new MenuItemDefinition(
                                       "Events",
                                       new LocalizableString("Events", "Social"),
                                       url: "/Events/Index",
                                       icon: "fa fa-info"))
                                       .AddItem(
                            new MenuItemDefinition(
                                       "Courses",
                                       new LocalizableString("Courses", "Social"),
                                       url: "/Courses/Index",
                                       icon: "fa fa-info"));

            context.Manager.Menus.Add("Social", menu);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, "Social");
        }
    }
}