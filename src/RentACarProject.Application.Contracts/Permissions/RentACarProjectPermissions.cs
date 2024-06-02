﻿using static RentACarProject.Permissions.RentACarProjectPermissions;

namespace RentACarProject.Permissions;

public static class RentACarProjectPermissions
{
    public const string GroupName = "RentACarProject";

    public const string GroupName_Car = "CarsPermissions";
    public const string GroupName_Brand = "BrandPermission";
    public const string GroupName_Color = "ColorPermission";
    public const string GroupName_Fuel = "FuelPermission";
    public const string GroupName_Model = "ModelPermission";
    public const string GroupName_Transmission = "TransmissionPermissions";

    public static class Car
    {
        public const string Default = GroupName_Car + ".Car";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string Get = Default + ".Get";
        public const string List = Default + ".List";
    }

    public static class Brand
    {
        public const string Default = GroupName_Brand + ".Brand";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string Get = Default + ".Get";
        public const string List = Default + ".List";
    }

    public static class Color
    {
        public const string Default = GroupName_Color + ".Color";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string Get = Default + ".Get";
        public const string List = Default + ".List";
    }

    public static class Fuel
    {
        public const string Default = GroupName_Fuel + ".Fuel";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string Get = Default + ".Get";
        public const string List = Default + ".List";
    }

    public static class Model
    {
        public const string Default = GroupName_Model + ".Model";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string Get = Default + ".Get";
        public const string List = Default + ".List";
    }

    public static class Transmission
    {
        public const string Default = GroupName_Transmission + ".Transmission";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string Get = Default + ".Get";
        public const string List = Default + ".List";
    }
}
