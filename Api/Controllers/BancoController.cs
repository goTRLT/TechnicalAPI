using Application.Interfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
    {
    /// <summary>
    /// Controller that manages Bancos.
    /// Provides endpoints to register, retrieve all, and retrieve by code.
    /// </summary>
    [ApiController]
    [Route("api/bancos")]
    public class BancoController : ControllerBase
        {
        private readonly IBancoService _bancoService;

        /// <summary>
        /// Initializes a new <see cref="BancoController"/> class.
        /// </summary>
        /// <param name="bancoService">Service for Banco operations.</param>
        public BancoController(IBancoService bancoService)
            {
            _bancoService = bancoService;
            }

        /// <summary>
        /// Get all Bancos.
        /// </summary>
        /// <returns>List of BancoDto objects.</returns>
        [HttpGet("all")]
        public async Task<ActionResult<List<BancoDto>>> GetAll()
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bancos = await _bancoService.FindAll();
            return Ok(bancos);
            }

        /// <summary>
        /// Get one Banco by the Banco code.
        /// </summary>
        /// <param name="code">The code of the Banco.</param>
        /// <returns>The BancoDto object if found; otherwise, NotFound.</returns>
        [HttpGet("{code}")]
        public async Task<ActionResult<BancoDto>> Get(int code)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var banco = await _bancoService.FindByCode(code);
            if (banco == null)
                return NotFound();
            return Ok(banco);
            }

        /// <summary>
        /// Registers a new Banco.
        /// </summary>
        /// <param name="bancoDto">The BancoDto to register.</param>
        /// <returns>Created result if successful; otherwise, BadRequest.</returns>
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] BancoDto bancoDto)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _bancoService.Create(bancoDto);
            if (!success)
                return BadRequest("Could not create Banco.");

            return CreatedAtAction(nameof(Get), new { code = bancoDto.Code }, bancoDto);
            }
        }
    }
