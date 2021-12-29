using AutoMapper;
using Hotel_Astitou_Backend.Domain.Services;
using Hotel_Astitou_Backend.Model;
using Hotel_Astitou_Backend.Ressource;
using MantaxHotel.Domaine.Service.Communication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [Route("guarantor")]
    public class GuarantorController : AuthorizeController
    {
        private readonly IGuarantorService guarantorService;
        private readonly IMapper mapper;
        public GuarantorController(IGuarantorService guarantorService, IMapper mapper)
        {
            this.guarantorService = guarantorService;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GuarantorResource>), 200)]
        public async Task<IEnumerable<GuarantorResource>> ListGuarantor()
        {
            var guarantor = await guarantorService.ListAsync();

            return mapper.Map<IEnumerable<Guarantor>, IEnumerable<GuarantorResource>>(guarantor);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GuarantorResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 404)]
        public async Task<IActionResult> FindById(int id)
        {
            var guarantorResponse = await guarantorService.FindByIdAsync(id);

            if (!guarantorResponse.Success)
                return BadRequest(new ErrorResource(guarantorResponse.Message));

            return Ok(mapper.Map<Guarantor, GuarantorResource>(guarantorResponse.Resource));
        }
        [HttpPost("CreateGuarantor")]
        public async Task<GuarantorResponse> NewGuarantor(
            [FromQuery(Name = "gender")] string gender,
            [FromQuery(Name = "name")] string name,
            [FromQuery(Name = "firstname")] string firstname,
            [FromQuery(Name = "adress")] string adress,
            [FromQuery(Name = "city")] string city,
            [FromQuery(Name = "country")] string country,
            [FromQuery(Name = "email")] string email,
            [FromQuery(Name = "postalCode")] string postalCode,
            [FromQuery(Name = "phoneNumber")] string phoneNumber,
            [FromQuery(Name = "lodgerId")] string lodgerId)
        {
            NewGuarantorResource newGuarantor = new NewGuarantorResource(gender, name, firstname, adress, city, country, email,Int32.Parse(postalCode), Int32.Parse(phoneNumber), Int32.Parse(lodgerId));
            var guarantor = mapper.Map<NewGuarantorResource, Guarantor>(newGuarantor);
            return await guarantorService.SaveAsync(guarantor);

        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(
            [FromQuery(Name = "id")] string id,
            [FromQuery(Name = "gender")] string gender,
            [FromQuery(Name = "name")] string name,
            [FromQuery(Name = "firstname")] string firstname,
            [FromQuery(Name = "adress")] string adress,
            [FromQuery(Name = "city")] string city,
            [FromQuery(Name = "country")] string country,
            [FromQuery(Name = "email")] string email,
            [FromQuery(Name = "postalCode")] string postalCode,
            [FromQuery(Name = "phoneNumber")] string phoneNumber,
            [FromQuery(Name = "lodgerId")] string lodgerId)
        {
            NewGuarantorResource newGuarantor = new NewGuarantorResource(gender, name, firstname, adress, city, country, email, Int32.Parse(postalCode), Int32.Parse(phoneNumber), Int32.Parse(lodgerId));
            var guarantor = mapper.Map<NewGuarantorResource, Guarantor>(newGuarantor);
            var result = await guarantorService.UpdateAsync(Int32.Parse(id), guarantor);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var guarantorgResource = mapper.Map<Guarantor, GuarantorResource>(result.Resource);
            return Ok(guarantorgResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await guarantorService.DeleteAsync(id);

            if (!result.Success) return BadRequest(new ErrorResource(result.Message));

            var guarantorResource = mapper.Map<Guarantor, GuarantorResource>(result.Resource);
            return Ok(guarantorResource);
        }
    }
}
