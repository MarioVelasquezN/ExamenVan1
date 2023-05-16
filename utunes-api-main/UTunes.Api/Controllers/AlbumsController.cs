using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UTunes.Api.DataTransferObjects;
using UTunes.Core.Entities;
using UTunes.Core.Interfaces;

namespace UTunes.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumsController : UTunesBaseController
{
    private readonly IAlbumService albumService;
    private readonly ISongService songService;
    private readonly IMapper mapper;

    public AlbumsController(
            IAlbumService albumService,
            ISongService songService,
            IMapper mapper)
    {
        this.albumService = albumService;
        this.songService = songService;
        this.mapper = mapper;
    }
    /// <summary>
    /// Agrega un Album a la base de datos
    /// </summary>
    /// <param name="albumToAdd"> Nombre del Album a agregar</param>
    /// <returns>El album agregado</returns>
    [HttpPost]
    public async Task<IActionResult> AddAlbumAsync([FromBody]AddAlbumDataTranferObject albumToAdd)
    {
        var result = await this.albumService.AddAsync(new Core.Entities.Album
        {
            Name = albumToAdd.Name
        });
        return result.Succeeded ? Ok(result.Result) : GetErrorResult<Core.Entities.Album>(result);
    }
    /// <summary>
    /// Retirna la lista de albums
    /// </summary>
    /// <returns>Lista de Akbums</returns>
    [HttpGet]
    public async Task<IActionResult> GetAlbumsAsync()
    {
        var result = await this.albumService.GetAllAsync();
        var songs = this.mapper.Map<IList<AlbumDetailDataTransferObject>>(result.Result);
        return result.Succeeded ? Ok(songs) : GetErrorResult<IReadOnlyList<Core.Entities.Album>>(result);
    }

    /// <summary>
    /// Muestra la lista de Album por Canciones
    /// </summary>
    /// <param name="albumId">El Id del album</param>
    /// <returns></returns>
    [HttpGet]
    [Route("{albumId}/songs")]
    public async Task<IActionResult> GetSongsByAlbumAsync([FromBody]int albumId)
    {
        var result = await this.songService.GetByAlbum(albumId);
        var songs = this.mapper.Map<IList<SongDetailDataTransferObject>>(result.Result);
        return result.Succeeded ? Ok(songs) : GetErrorResult<IReadOnlyList<Core.Entities.Song>>(result);


    }
}

