using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sistema.BackEnd.Models;
using Sistema.BackEnd.Models.Dtos;
using Sistema.BackEnd.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema.BackEnd.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        public ICategoriaService CategoriaService { get; }
        private readonly ILogger<CategoriaController> _logger;
        private readonly IMapper _mapper;

        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaService categoriaService, IMapper mapper)
        {

            _logger = logger;
            CategoriaService = categoriaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaDto>> Get()
        {
            var categorias = await CategoriaService.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoriaDto>>(categorias);
        }

        [HttpGet("{id:int}")]
        public async Task<CategoriaDto> Get(int id)
        {
            var categoriaEntity = await CategoriaService.GetByIdAsync(id);
            return _mapper.Map<CategoriaDto>(categoriaEntity);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CategoriaDto categoriaDto)
        {
            var Entity = _mapper.Map<Categoria>(categoriaDto);


            await CategoriaService.InsertAsync(Entity);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, CategoriaDto categoriaDto)
        {
            var Entity = await CategoriaService.GetByIdAsync(id);

            if (Entity == null)
            {
                return NotFound();
            }

            Entity = _mapper.Map<Categoria>(categoriaDto);

            await CategoriaService.UpdateAsync(Entity);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Entity = await CategoriaService.GetByIdAsync(id);

            if (Entity == null)
            {
                return NotFound();
            }

            await CategoriaService.DeleteAsync(Entity.Id);
            return NoContent();
        }
    }
}
