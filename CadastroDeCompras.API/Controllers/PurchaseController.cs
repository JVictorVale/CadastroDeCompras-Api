using CadastroDeCompras.Application.DTOs;
using CadastroDeCompras.Application.Services;
using CadastroDeCompras.Application.Services.Interface;
using CadastroDeCompras.Domain.Repositories;
using CadastroDeCompras.Domain.Validation;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeCompras.API.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PurchaseDTO purchaseDTO)
        {
            try
            {
                var result = await _purchaseService.CreateAsync(purchaseDTO);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }
        }
    }
}