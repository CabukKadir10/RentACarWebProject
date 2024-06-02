using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NUglify.JavaScript.Syntax;
using RentACarProject.Cars;
using RentACarProject.Cars.Dtos;
using RentACarProject.Permissions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace RentACarProject.Web.Pages.Cars
{
    [Authorize(RentACarProjectPermissions.Car.Create)]
    public class AddModel : PageModel
    {
        private readonly CarAppService _carAppService;

        public AddModel(CarAppService carAppService)
        {
            _carAppService = carAppService;
        }

        [BindProperty]
        public CreatedCarDto CreatedCarDto { get; set; }
        public void OnGet()
        {
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            var tagResult = await _carAppService.CreateAsync(CreatedCarDto);
            return new JsonResult(tagResult);
        }
    }
}
