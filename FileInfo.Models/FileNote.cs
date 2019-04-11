using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileInfo.Models
{
    class FileNote
    {
        [Key]
        public int Id { get; set; }
        public DateTime NoteDate { get; set; }
        public string Note { get; set; }



    }
}
