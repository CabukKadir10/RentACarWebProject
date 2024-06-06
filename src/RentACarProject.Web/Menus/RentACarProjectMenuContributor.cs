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
           new ApplicationMenuItem(
                name: "Menu:Cars",
                displayName: l["Menu:Cars"],
                icon: "fa fa-cars",
                url: "/Cars"
            ).RequirePermissions(RentACarProjectPermissions.Car.Default)
       );

        context.Menu.AddItem(
           new ApplicationMenuItem(
                name: "Menu:Brand",
                displayName: l["Menu:Brand"],
                icon: "fa fa-brands",
                url: "/Brand"
            ).RequirePermissions(RentACarProjectPermissions.Brand.Default)
       );

        context.Menu.AddItem(
           new ApplicationMenuItem(
                name: "Menu:Color",
                displayName: l["Menu:Color"],
                icon: "fa fa-colors",
                url: "/Color"
            ).RequirePermissions(RentACarProjectPermissions.Color.Default)
       );

        context.Menu.AddItem(
           new ApplicationMenuItem(
                name: "Menu:Model",
                displayName: l["Menu:Model"],
                icon: "fa fa-models",
                url: "/Model"
            ).RequirePermissions(RentACarProjectPermissions.Model.Default)
       );

        context.Menu.AddItem(
           new ApplicationMenuItem(
                name: "Menu:Fuel",
                displayName: l["Menu:Fuel"],
                icon: "fa fa-fuels",
                url: "/Fuel"
            ).RequirePermissions(RentACarProjectPermissions.Fuel.Default)
       );

        context.Menu.AddItem(
           new ApplicationMenuItem(
                name: "Menu:Transmission",
                displayName: l["Menu:Transmission"],
                icon: "fa fa-transmissions",
                url: "/Transmission"
            ).RequirePermissions(RentACarProjectPermissions.Transmission.Default)
       );

        context.Menu.AddItem(
           new ApplicationMenuItem(
                name: "Menu:Rental",
                displayName: l["Menu:Rental"],
                icon: "fa fa-rentals",
                url: "/Rental"
            ).RequirePermissions(RentACarProjectPermissions.Rental.Default)
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
