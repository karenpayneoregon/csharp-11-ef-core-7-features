using System.Drawing;
#pragma warning disable CA1416

namespace BogusExtendedApp.Classes;

public static class ImageExtensions
{
    public static Bitmap ByteToImage(this byte[] sender)
    {
        MemoryStream mStream = new();
        byte[] bytes = sender;
        mStream.Write(bytes, 0, Convert.ToInt32(bytes.Length));
        Bitmap bm = new(mStream, false);
        mStream.Dispose();
        return bm;
    }
}