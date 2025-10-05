using Application.Interfaces;
using AutoMapper;
using Domain.DTOs;
using Domain.Entity;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BoletoService : IBoletoService
    {
        private readonly IBoletoRepository _boletoRepository;
        private readonly IBancoRepository _bancoRepository;
        private readonly IMapper _mapper;

        public BoletoService(IBoletoRepository boletoRepository, IBancoRepository bancoRepository, IMapper mapper)
        {
            _boletoRepository = boletoRepository;
            _bancoRepository = bancoRepository;
            _mapper = mapper;
        }

        public async Task<BoletoDto> Find(int id)
        {
            var boleto = await _boletoRepository.Find(id);
            return _mapper.Map<BoletoDto>(boleto);
        }

        public async Task<bool> Create(BoletoDto boletoDto)
        {
            var boletoMap = _mapper.Map<Boleto>(boletoDto);
            var success = await _boletoRepository.Create(boletoMap);
            return success;
        }
    }
}

