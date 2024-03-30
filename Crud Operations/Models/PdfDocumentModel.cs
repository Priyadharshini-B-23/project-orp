using System.ComponentModel.DataAnnotations;

namespace Crud_Operations.Models
{
    public class PdfDocumentModel
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FIelData { get; set; }
        public DateTime UploadDate { get; set; }
        public int JobSeekerID { get; set; }

    }
}
