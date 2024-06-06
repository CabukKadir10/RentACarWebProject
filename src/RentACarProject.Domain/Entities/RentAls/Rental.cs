using RentACarProject.Entities.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace RentACarProject.Entities.RentAls
{
    public class Rental : Entity<int>
    {
        public Rental()
        {

        }
        public Rental(int id, int carId, DateTime? rentDate, DateTime? returnDate, int totalPrice) : this()
        {
            Id = id;
            CarId = carId;
            RentDate = rentDate;
            ReturnDate = returnDate;
            TotalPrice = totalPrice;
        }
        public int CarId { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int TotalPrice { get; set; }

        public virtual Car Car { get; set; }  // Navigation property


    }
}
