using AutoMapper;
using RentACarProject.Brands.Dtos;
using RentACarProject.Cars.Dtos;
using RentACarProject.Colors.Dtos;
using RentACarProject.Entities.Brands;
using RentACarProject.Entities.Cars;
using RentACarProject.Entities.Colors;
using RentACarProject.Entities.Fuels;
using RentACarProject.Entities.Models;
using RentACarProject.Entities.RentAls;
using RentACarProject.Entities.Transmissions;
using RentACarProject.Fuels.Dtos;
using RentACarProject.Models.Dtos;
using RentACarProject.Rentals.Dtos;
using RentACarProject.Transmissions.Dtos;

namespace RentACarProject;

public class RentACarProjectApplicationAutoMapperProfile : Profile
{
    public RentACarProjectApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Brand, UpdatedBrandDto>().ReverseMap();
        CreateMap<Brand, BrandDto>().ReverseMap();
        CreateMap<Brand, CreatedBrandDto>().ReverseMap();

        CreateMap<Car, CarDto>().ReverseMap();
        CreateMap<Car, CreatedCarDto>().ReverseMap();
        CreateMap<Car, UpdatedCarDto>().ReverseMap();

        CreateMap<Color, ColorDto>().ReverseMap();
        CreateMap<Color, CreatedColorDto>().ReverseMap();
        CreateMap<Color, UpdatedColorDto>().ReverseMap();

        CreateMap<Fuel, FuelDto>().ReverseMap();
        CreateMap<Fuel, CreatedFuelDto>().ReverseMap();
        CreateMap<Fuel, UpdatedFuelDto>().ReverseMap();

        CreateMap<Model, ModelDto>().ReverseMap();
        CreateMap<Model, CreatedModelDto>().ReverseMap();
        CreateMap<Model, UpdatedModelDto>().ReverseMap();

        CreateMap<Rental, RentalDto>().ReverseMap();
        CreateMap<Rental, CreatedRentalDto>().ReverseMap();
        CreateMap<Rental, UpdatedRentalDto>().ReverseMap();

        CreateMap<Transmission, TransmissionDto>().ReverseMap();
        CreateMap<Transmission, CreatedTransmissionDto>().ReverseMap();
        CreateMap<Transmission, UpdatedTransmissionDto>().ReverseMap();

    }
}
