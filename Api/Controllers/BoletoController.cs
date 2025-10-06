using Application.Interfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
    {
    /// <summary>
    /// Controller that manages Boletos.
    /// Provides endpoints to register and get by Id.
    /// </summary>
    [ApiController]
    [Route("api/boletos")]
    public class BoletoController : ControllerBase
        {
        private readonly IBoletoService _boletoService;
        private readonly IBancoService _bancoService;

        /// <summary>
        /// Initializes a new <see cref="BoletoController"/> class.
        /// </summary>
        /// <param name="boletoService">Service for Boleto operations.</param>
        /// <param name="bancoService">Service for Banco operations.</param>
        public BoletoController(IBoletoService boletoService, IBancoService bancoService)
            {
            _boletoService = boletoService;
            _bancoService = bancoService;
            }

        /// <summary>
        /// Get a Boleto by the Boleto Id.
        /// Applies interest if DueDate is past the search date.
        /// </summary>
        /// <param name="id">The Boleto Id.</param>
        /// <returns>The BoletoDto object if found; otherwise, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BoletoDto>> Get(int id)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var boleto = await _boletoService.Find(id);
            if (boleto.Id == 0)
                return NotFound($"Boleto with id {id} not found.");

            if (DateTime.UtcNow.Date > boleto.DueDate.Date)
                {
                var banco = await _bancoService.FindById(boleto.BancoId);
                if (banco != null)
                    boleto.Amount = boleto.Amount + (boleto.Amount * (banco.InterestPercent / 100));
                }

            return Ok(boleto);
            }

        /// <summary>
        /// Registers a new Boleto.
        /// </summary>
        /// <param name="boletoDto">The BoletoDto to register.</param>
        /// <returns>Created result if successful; otherwise, BadRequest.</returns>
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] BoletoDto boletoDto)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (boletoDto.PayorName.ToLower() == boletoDto.PayeeName.ToLower())
                return BadRequest("Payor and Payee cannot be the same.");

            var banco = await _bancoService.FindById(boletoDto.BancoId);
            if (banco == null)
                return BadRequest($"Banco with id {boletoDto.BancoId} does not exist.");

            string? sanitizedCpfCnpj = boletoDto.PayorCpfCnpj == null ? null : new string(boletoDto.PayorCpfCnpj.Where(char.IsDigit).ToArray());

            var payorDocs = await _boletoService.FindPayorDocs(boletoDto.PayorCpfCnpj, boletoDto.PayorName);

            if (payorDocs != null)
                {
                string? payorDocsCpfCnpj = payorDocs.PayorCpfCnpj == null
                    ? null
                    : new string(payorDocs.PayorCpfCnpj.Where(char.IsDigit).ToArray());

                string? inputCpfCnpj = sanitizedCpfCnpj;

                if ((payorDocsCpfCnpj == inputCpfCnpj && payorDocs.PayorName != boletoDto.PayorName) ||
                    (payorDocsCpfCnpj != inputCpfCnpj && payorDocs.PayorName == boletoDto.PayorName))
                    return BadRequest("CPF and CPNJ documents are unique to a single Payor.");
                }

            var createdBoleto = await _boletoService.CreateAndReturn(boletoDto);
            if (createdBoleto == null)
                return BadRequest("Could not create Boleto.");

            return CreatedAtAction(nameof(Get), new { id = createdBoleto.Id }, createdBoleto);
            }
        }
    }
