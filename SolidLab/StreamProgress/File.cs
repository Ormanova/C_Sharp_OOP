namespace P01.Stream_Progress
{
    public class File : StreamProgressInfo
    {
        //private string name;

        //public File(string name, int length, int bytesSent)
        //{
        //    this.name = name;
        //    this.Length = length;
        //    this.BytesSent = bytesSent;
        //}

        //public int Length { get; set; }

        //public int BytesSent { get; set; }
        public File(int length, int bytesSent, string name) : base(length, bytesSent)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
