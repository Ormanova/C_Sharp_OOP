namespace P01.Stream_Progress
{
    public class StreamProgressInfo : IStream
    {
        

        // If we want to stream a music file, we can't
        public StreamProgressInfo(int length, int bytesSent)
        {
            Length = length;
            BytesSent = bytesSent;
        }


        public int Length { get; private set; }

        public int BytesSent { get; private set; }

        public int CalculateCurrentPercent()
        {
            return (this.BytesSent * 100) / this.Length;
        }
    }
}
