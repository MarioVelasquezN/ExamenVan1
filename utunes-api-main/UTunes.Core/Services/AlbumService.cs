using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTunes.Core.Entities;
using UTunes.Core.Interfaces;

namespace UTunes.Core.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IRepository<Album> _albumRepository;

        public AlbumService(IRepository<Album> albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<OperationResult<Album>> AddAsync(Album album)
        {
            if (string.IsNullOrEmpty(album.Name))
            {
                return new OperationResult<Album>(new Error
                {
                    Code = ErrorCode.InternalError,
                    Message = "Name is a required field to add a category"
                });
            }
            var entity = await this._albumRepository.AddAsync(album);
            await this._albumRepository.CommitAsync();
            return new OperationResult<Album>(entity);
        }

        public async Task<OperationResult<IReadOnlyList<Album>>> GetAllAsync()=>(await this._albumRepository.AllAsync()).ToList();
    }
}
