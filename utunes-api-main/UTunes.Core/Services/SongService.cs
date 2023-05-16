using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTunes.Core.Entities;
using UTunes.Core.Interfaces;

namespace UTunes.Core.Services
{
    public class SongService : ISongService
    {
        private readonly IRepository<Song> songRepository;

        public SongService(IRepository<Song> songRepository)
        {
            this.songRepository = songRepository;
        }

        public async Task<OperationResult<Song>> AddAsync(Song song)
        {
            if (string.IsNullOrEmpty(song.Name))
            {
                return new OperationResult<Song>(new Error
                {
                    Code = ErrorCode.InternalError,
                    Message = "Name is a required field to add a song"
                });
            }

            var entity = await this.songRepository.AddAsync(song);
            await this.songRepository.CommitAsync();
            return new OperationResult<Song>(entity);
        }

        public async Task<OperationResult<IReadOnlyList<Song>>> GetByAlbum(int albumId)
        {
            if (albumId < 0)
            {
                return (await this.songRepository.AllAsync()).ToList();
            }
            return this.songRepository.Filter(x => x.Id == albumId).ToList();
        }

        public OperationResult<Song> GetById(int id)
        {
            var song = this.songRepository.GetById(id);
            if (song == null)
            {
                return new OperationResult<Song>(new Error
                {
                    Code = ErrorCode.NotFound,
                    Message = "Name is a required field to add a Album"
                });
            }
            return song;
        }
    }
}
