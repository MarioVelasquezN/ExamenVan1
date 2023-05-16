using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTunes.Core.Entities;

namespace UTunes.Core.Interfaces
{
    public interface IAlbumService
    {
        Task<OperationResult<Album>> AddAsync(Album album);

        Task<OperationResult<IReadOnlyList<Album>>> GetAllAsync();
    }
}
