using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;
using System.Threading.Tasks;
using FileView.Models;
using FileView.Repositories;

namespace FileView.Api.Controllers
{
    public class FileInfoController : ApiController
    {
        private readonly IFileInfo _fileInfoManager;

        public FileInfoController(IFileInfo fileInfoManager)
        {
            _fileInfoManager = fileInfoManager;
        }

        // GET api/<controller>/5
        public async Task<IHttpActionResult> Get(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var fileInfo = await _fileInfoManager.GetFileInfoAsync(id, cancellationToken);

            if (fileInfo == null)
                return NotFound();

            return Ok<FileInfo>(fileInfo);
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Post([FromBody]FileInfo fileInfo, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var id = await _fileInfoManager.InsertFileInfoAsync(fileInfo, cancellationToken);
                return Ok<long>(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/FileInfo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FileInfo/5
        public void Delete(int id)
        {
        }
    }
}
