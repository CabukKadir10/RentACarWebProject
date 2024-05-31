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
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RentACarProjectResource>(name);
    }
}
