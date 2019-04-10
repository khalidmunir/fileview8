using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using FileView.Models;

namespace FileView.Repositories
{
    public class FileInfoManager : IFileInfo
    {
        private readonly DataContext _dataContext;

        public FileInfoManager()
        {
            _dataContext = new DataContext();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public async Task<FileInfo> GetFileInfoAsync(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _dataContext.FileInfos.FindAsync(cancellationToken, id);
        }

        public async Task<long> InsertFileInfoAsync(FileInfo fileInfo, CancellationToken cancellationToken = default(CancellationToken))
        {
            _dataContext.FileInfos.Add(fileInfo);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return fileInfo.Id;
        }

        public async Task DeleteAllFileInfoAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var fileInfos = _dataContext.FileInfos;
            _dataContext.FileInfos.RemoveRange(fileInfos);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }

    }
}
