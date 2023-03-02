namespace rakoona.models.dtos.Request
{
    public class FileDetailsRequest
    {
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public string FileType { get; set; }
    }
}
