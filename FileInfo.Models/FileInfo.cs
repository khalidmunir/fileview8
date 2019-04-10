using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileView.Models
{
    [Table(name: "FileInfo")]
    public class FileInfo
    {
        [Key]
        public long Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Volume { get; set; }
        public int Size { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public DateTime AccessTime { get; set; }
        public string MD5 { get; set; }
        public string SecurityClassification { get; set; }
        public string BusinessClassification { get; set; }
        public string Extension { get; set; }
        public string MimeType { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee {get; set;}
    }
}