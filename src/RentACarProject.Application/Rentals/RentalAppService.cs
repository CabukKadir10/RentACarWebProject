using RentACarProject.Entities.Cars;
using RentACarProject.Entities.Models;
using RentACarProject.Entities.RentAls;
using RentACarProject.Rentals.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace RentACarProject.Rentals
{
    public class RentalAppService : CrudAppService<Rental, RentalDto, int, PagedAndSortedResultRequestDto, CreatedRentalDto, UpdatedRentalDto>, IRentalAppService
    {
        private readonly ICarRepository _carRepository;
        private readonly IModelRepository _modelRepository;
        public RentalAppService(IRepository<Rental, int> repository, ICarRepository carRepository, IModelRepository modelRepository) : base(repository)
        {
            _carRepository = carRepository;
            _modelRepository = modelRepository;
        }

        public override async Task<RentalDto> CreateAsync(CreatedRentalDto input)
        {
            await CheckCreatePolicyAsync().ConfigureAwait(continueOnCapturedContext: false);

            // Aracı ve modeli almak
            var car = await _carRepository.GetAsync(input.CarId);

            if (car.CarState == Enums.CarState.Maintenance)
                throw new UserFriendlyException("Araç şuan bakımda lütfen başka araç seçiniz");

            if (car.CarState == Enums.CarState.Rented)
                throw new UserFriendlyException("Araç şuan kiralık lütfen başka araç seçiniz");

            var model = await _modelRepository.GetAsync(car.ModelId);

            // Kiralama süresini hesaplama
            if (input.RentDate == null || input.ReturnDate == null || input.ReturnDate <= input.RentDate)
            {
                throw new ArgumentException("Geçersiz kiralama tarihleri");
            }

            int rentalDays = (input.ReturnDate.Value - input.RentDate.Value).Days;

            // Toplam fiyatı hesaplama
            int totalPrice = (int)(rentalDays * model.DailyPrice);

            // Rental entity oluşturma
            Rental entity = new Rental
            {
                CarId = input.CarId,
                RentDate = input.RentDate,
                ReturnDate = input.ReturnDate,
                TotalPrice = totalPrice
            };

            TryToSetTenantId(entity);
            await Repository.InsertAsync(entity, autoSave: true).ConfigureAwait(continueOnCapturedContext: false);

            return await MapToGetOutputDtoAsync(entity).ConfigureAwait(continueOnCapturedContext: false);
        }


        public override async Task<RentalDto> UpdateAsync(int id, UpdatedRentalDto input)
        {
            await CheckUpdatePolicyAsync().ConfigureAwait(continueOnCapturedContext: false);

            // Güncellenen kiralama bilgilerini getirme
            var rental = await Repository.GetAsync(id);

            // Aracı ve modeli almak
            var car = await _carRepository.GetAsync(rental.CarId);
            if (car.CarState == Enums.CarState.Maintenance)
                throw new UserFriendlyException("Araç şuan bakımda lütfen başka araç seçiniz");

            if (car.CarState == Enums.CarState.Rented)
                throw new UserFriendlyException("Araç şuan kiralık lütfen başka araç seçiniz");
            var model = await _modelRepository.GetAsync(car.ModelId);

            // Kiralama süresini hesaplama
            if (input.RentDate == null || input.ReturnDate == null || input.ReturnDate <= input.RentDate)
            {
                throw new ArgumentException("Geçersiz kiralama tarihleri");
            }

            int rentalDays = (input.ReturnDate.Value - input.RentDate.Value).Days;

            // Toplam fiyatı hesaplama
            int totalPrice = (int)(rentalDays * model.DailyPrice);

            // Rental entity güncelleme
            rental.CarId = input.CarId;
            rental.RentDate = input.RentDate;
            rental.ReturnDate = input.ReturnDate;
            rental.TotalPrice = totalPrice;

            await Repository.UpdateAsync(rental, autoSave: true).ConfigureAwait(continueOnCapturedContext: false);

            return await MapToGetOutputDtoAsync(rental).ConfigureAwait(continueOnCapturedContext: false);
        }


        public override Task<RentalDto> GetAsync(int id)
        {
            return base.GetAsync(id);
        }

        public override Task<PagedResultDto<RentalDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }

        public override Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }
    }
}
