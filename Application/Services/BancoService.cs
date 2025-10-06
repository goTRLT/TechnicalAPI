using Application.Interfaces;
using AutoMapper;
using Domain.DTOs;
using Domain.Entity;
using Domain.Interfaces;

namespace Application.Services
{
    public class BancoService : IBancoService
    {
        private readonly IBancoRepository _bancoRepository;
        private readonly IMapper _mapper;

        public BancoService(IBancoRepository bancoRepository, IMapper mapper)
        {
            _bancoRepository = bancoRepository;
            _mapper = mapper;
        }

        public async Task<List<BancoDto>> FindAll()
        {
            var all = new List<BancoDto>();
            var bancos = await _bancoRepository.FindAll();
            foreach (var banco in bancos)
            {
                all.Add(_mapper.Map<BancoDto>(banco));
            }
            return all;
        }

        public async Task<BancoDto> FindByCode(int code)
        {
            var banco = await _bancoRepository.FindByCode(code);
            return _mapper.Map<BancoDto>(banco);
        }

        public async Task<bool> Create(BancoDto bancoDto)
        {
            var bancoMap = _mapper.Map<Banco>(bancoDto);
            var success = await _bancoRepository.Create(bancoMap);
            return success;
        }

        public async Task<BancoDto> FindById(int id)
        {
            var banco = await _bancoRepository.FindById(id);
            return _mapper.Map<BancoDto>(banco);
        }
    }
}