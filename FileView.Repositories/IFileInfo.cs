using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using FileView.Models;

namespace FileView.Repositories
{
    public interface IFileInfo : IDisposable
    {
        Task<FileInfo> GetFileInfoAsync(long Id, CancellationToken cancellationToken = default(CancellationToken));
        Task<long> InsertFileInfoAsync(FileInfo fileInfo, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAllFileInfoAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
