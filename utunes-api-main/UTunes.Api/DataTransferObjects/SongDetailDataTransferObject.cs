namespace UTunes.Api.DataTransferObjects
{
    public class SongDetailDataTransferObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Artist { get; set; }
        public int AlbumId { get; set; }
    }
}
