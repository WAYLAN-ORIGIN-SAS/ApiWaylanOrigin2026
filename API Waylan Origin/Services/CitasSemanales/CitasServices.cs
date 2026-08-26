using API_Waylan_Origin.Data;
using API_Waylan_Origin.DTOs.CitaSemanal;
using API_Waylan_Origin.Interfaces.CitasSemanales;
using API_Waylan_Origin.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Waylan_Origin.Services.CitasSemanales
{
    public class CitasServices : ICitasService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public CitasServices(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<CitaSemanalGetDto> GetCita()
        {
            var cita = await _appDbContext.CitasSemanales.FirstOrDefaultAsync();

            if (cita == null)
                 return new CitaSemanalGetDto();


            return _mapper.Map<CitaSemanalGetDto>(cita);
        }

        public async Task<bool> UpdateCita(CitaSemanalUpdateDto citaSemanalUpdateDto)
        {
            var cita = await _appDbContext.CitasSemanales.FirstOrDefaultAsync();

            if(cita == null)
            {
                //si es la primera vez que se utiliza, se crea la cita
                var nuevaCita = _mapper.Map<CitaSemanal>(citaSemanalUpdateDto);
                await _appDbContext.CitasSemanales.AddAsync(nuevaCita);
            }
            else
            {
                // Si el registro ya existe, actualizamos sus campos
                _mapper.Map(citaSemanalUpdateDto, cita);
            }

            await _appDbContext.SaveChangesAsync();
            return true;
        }

    }
}
