namespace P01.Stream_Progress
{
    public class Music : StreamProgressInfo
    {
        //private string artist;
        //private string album;

        //public Music(string artist, string album, int length, int bytesSent)
        //{
        //    this.artist = artist;
        //    this.album = album;
        //    this.Length = length;
        //    this.BytesSent = bytesSent;
        //}

        //public int Length { get; set; }

        //public int BytesSent { get; set; }
        public Music(string artist, string album, int length, int bytesSent) : base(length, bytesSent)
        {
            Artist = artist;
            Album = album;
        }
        public string Artist { get; set; }
        public string Album { get; set; }
    }
}
