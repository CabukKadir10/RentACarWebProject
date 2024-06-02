using RentACarProject.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace RentACarProject.Permissions;

public class RentACarProjectPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(RentACarProjectPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(RentACarProjectPermissions.MyPermission1, L("Permission:MyPermission1"));
        var cargroup = context.AddGroup(RentACarProjectPermissions.GroupName_Car, L("CarPermission"));
        var brandgroup = context.AddGroup(RentACarProjectPermissions.GroupName_Brand, L("BrandPermission"));
        var colorgroup = context.AddGroup(RentACarProjectPermissions.GroupName_Color, L("ColorPermission"));
        var fuelgroup = context.AddGroup(RentACarProjectPermissions.GroupName_Fuel, L("FuelPermission"));
        var modelgroup = context.AddGroup(RentACarProjectPermissions.GroupName_Model, L("ModelPermission"));
        var transmissiongroup = context.AddGroup(RentACarProjectPermissions.GroupName_Transmission, L("TransmissionPermission"));



        Define_Car_Group(cargroup);
        Define_Fuel_Group(fuelgroup);
        Define_Transmission_Group(transmissiongroup);
        Define_Model_Group(modelgroup);
        Define_Color_Group(colorgroup);
        Define_Brand_Group(brandgroup);
    }

    private void Define_Transmission_Group(PermissionGroupDefinition definition)
    {
        var transmissionPermissions = definition.AddPermission(RentACarProjectPermissions.Transmission.Default, L("TransmissionManagment"));
        transmissionPermissions.AddChild(RentACarProjectPermissions.Transmission.Create, L("Create"));
        transmissionPermissions.AddChild(RentACarProjectPermissions.Transmission.Update, L("Update"));
        transmissionPermissions.AddChild(RentACarProjectPermissions.Transmission.Delete, L("Delete"));
        transmissionPermissions.AddChild(RentACarProjectPermissions.Transmission.Get, L("Get"));
        transmissionPermissions.AddChild(RentACarProjectPermissions.Transmission.List, L("List"));
    }
    private void Define_Model_Group(PermissionGroupDefinition definition)
    {
        var modelPermissions = definition.AddPermission(RentACarProjectPermissions.Model.Default, L("CarManagment"));
        modelPermissions.AddChild(RentACarProjectPermissions.Model.Create, L("Create"));
        modelPermissions.AddChild(RentACarProjectPermissions.Model.Update, L("Update"));
        modelPermissions.AddChild(RentACarProjectPermissions.Model.Delete, L("Delete"));
        modelPermissions.AddChild(RentACarProjectPermissions.Model.Get, L("Get"));
        modelPermissions.AddChild(RentACarProjectPermissions.Model.List, L("List"));
    }
    private void Define_Fuel_Group(PermissionGroupDefinition definition)
    {
        var fuelPermission = definition.AddPermission(RentACarProjectPermissions.Fuel.Default, L("FuelManagment"));
        fuelPermission.AddChild(RentACarProjectPermissions.Fuel.Create, L("Create"));
        fuelPermission.AddChild(RentACarProjectPermissions.Fuel.Update, L("Update"));
        fuelPermission.AddChild(RentACarProjectPermissions.Fuel.Delete, L("Delete"));
        fuelPermission.AddChild(RentACarProjectPermissions.Fuel.Get, L("Get"));
        fuelPermission.AddChild(RentACarProjectPermissions.Fuel.List, L("List"));
    }
    private void Define_Color_Group(PermissionGroupDefinition definition)
    {
        var colorPermission = definition.AddPermission(RentACarProjectPermissions.Color.Default, L("ColorManagment"));
        colorPermission.AddChild(RentACarProjectPermissions.Color.Create, L("Create"));
        colorPermission.AddChild(RentACarProjectPermissions.Color.Update, L("Update"));
        colorPermission.AddChild(RentACarProjectPermissions.Color.Delete, L("Delete"));
        colorPermission.AddChild(RentACarProjectPermissions.Color.Get, L("Get"));
        colorPermission.AddChild(RentACarProjectPermissions.Color.List, L("List"));
    }
    private void Define_Brand_Group(PermissionGroupDefinition definition)
    {
        var brandPermissions = definition.AddPermission(RentACarProjectPermissions.Brand.Default, L("BrandManagment"));
        brandPermissions.AddChild(RentACarProjectPermissions.Brand.Create, L("Create"));
        brandPermissions.AddChild(RentACarProjectPermissions.Brand.Update, L("Update"));
        brandPermissions.AddChild(RentACarProjectPermissions.Brand.Delete, L("Delete"));
        brandPermissions.AddChild(RentACarProjectPermissions.Brand.Get, L("Get"));
        brandPermissions.AddChild(RentACarProjectPermissions.Brand.List, L("List"));
    }

    private void Define_Car_Group(PermissionGroupDefinition definition)
    {
        var carPermissions = definition.AddPermission(RentACarProjectPermissions.Car.Default, L("CarManagment"));
        carPermissions.AddChild(RentACarProjectPermissions.Car.Create, L("Create"));
        carPermissions.AddChild(RentACarProjectPermissions.Car.Update, L("Update"));
        carPermissions.AddChild(RentACarProjectPermissions.Car.Delete, L("Delete"));
        carPermissions.AddChild(RentACarProjectPermissions.Car.Get, L("Get"));
        carPermissions.AddChild(RentACarProjectPermissions.Car.List, L("List"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RentACarProjectResource>(name);
    }
}
