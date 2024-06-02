using System.Threading.Tasks;
using RentACarProject.Localization;
using RentACarProject.MultiTenancy;
using RentACarProject.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace RentACarProject.Web.Menus;

public class RentACarProjectMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<RentACarProjectResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                RentACarProjectMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.AddItem(
       new ApplicationMenuItem("Menu:Cars", l["Menu:Cars"], icon: "fa fa-newspaper-o")
       .RequirePermissions(RentACarProjectPermissions.Car.Default)
           .AddItem(new ApplicationMenuItem(
               name: "Menu:CarList",
               displayName: l["Menu:CarList"],
               icon: "fa fa-list",
               url: "/Cars/Index")
           .RequirePermissions(RentACarProjectPermissions.Car.List)
           )
           .AddItem(new ApplicationMenuItem(
               name: "Menu:CarsAdd",
               displayName: l["Menu:CarsAdd"],
               icon: "fa fa-plus",
               url: "/Cars/Add")
           .RequirePermissions(RentACarProjectPermissions.Car.Create)
           )
      );


        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        return Task.CompletedTask;
    }
}
