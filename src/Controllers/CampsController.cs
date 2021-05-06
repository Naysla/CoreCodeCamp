using AutoMapper;
using CoreCodeCamp.Data;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCodeCamp.Controllers
{
    //enrutar
    [Route("api/[controller]")]
    public class CampsController: ControllerBase
    {
        private readonly ICampRepository _repository;
        private readonly IMapper _mapper;


        //Contructor
        public CampsController(ICampRepository repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CampModel[]>> Get()
        {
            //if (false) return NotFound("Se presentó un error");
            // if (false) return BadRequest("Se presentó un error");
            //llamar el repositorio                        

            try
            {
                var results = await _repository.GetAllCampsAsync();               

                return _mapper.Map<CampModel[]>(results);
            }
            catch (Exception)
            {
                // return BadRequest("Fallo en la base de datos");
                //para devolver el error cuando la respuesta es 500
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error en la base de datos");
            }
            
        }
        [HttpGet("{moniker}")]
        public async Task<ActionResult<CampModel>> Get(string moniker)
        {
            try
            {
                var result = await _repository.GetCampAsync(moniker);

                if (result == null) return NotFound();

                return _mapper.Map<CampModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error en la base de datos");
            }
        }
    }
}
