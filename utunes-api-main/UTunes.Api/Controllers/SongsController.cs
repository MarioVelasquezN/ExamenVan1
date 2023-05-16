using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UTunes.Api.DataTransferObjects;
using UTunes.Core.Interfaces;

namespace UTunes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : UTunesBaseController
    {
        private readonly ISongService songService;
        private readonly IAlbumService albumService;
        private readonly IMapper mapper;

        public SongsController(ISongService songService,
            IAlbumService albumService,
            IMapper mapper)
        {
            this.songService = songService;
            this.albumService = albumService;
            this.mapper = mapper;

        }
       /// <summary>
       /// Crea una Cancion
       /// </summary>
       /// <param name="songToAdd">Es la Cancion por agregar</param>
       /// <returns>Retorna la cancion que se agrego a la base de datos</returns>
       [HttpPost]
       public async Task<IActionResult> AddSongAsync(AddSongDataTransferObject songToAdd)
        {
            var result = await this.songService.AddAsync(this.mapper.Map<Core.Entities.Song>(songToAdd));
            var addedSong = this.mapper.Map<SongDetailDataTransferObject>(result.Result);
            return result.Succeeded ? Ok(addedSong) : GetErrorResult<Core.Entities.Song>(result);
        }


        /// <summary>
        /// Obtiene las Canciones por Id
        /// </summary>
        /// <param name="id">Es el Id de la cancion</param>
        /// <returns>Retorna la Cancion</returns>
        [HttpGet("{id}")]
        public IActionResult GetSongeById(int id)
        {
            var result = this.songService.GetById(id);
            var song = this.mapper.Map<SongDetailDataTransferObject>(result.Result);
            return result.Succeeded ? Ok(song) : GetErrorResult<Core.Entities.Song>(result);
        }
    }
}
