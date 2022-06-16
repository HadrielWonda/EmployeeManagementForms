using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace Baumax.Contract.ZLib
{
    public static class ZRoutines
    {
        public static IZEntity ZipObject(object o)
        {
            IZEntity result = new ZEntity();
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, o);
                ms.Position = 0;
                result.Type = o.GetType();
                using (MemoryStream resultStream = new MemoryStream())
                {
                    using (GZipStream gZipStream = new GZipStream(resultStream, CompressionMode.Compress, true))
                    {
                        byte[] buffer = ms.ToArray();
                        gZipStream.Write(buffer, 0, buffer.Length);
                        gZipStream.Close();
                        result.Size = buffer.Length;
                    }
                    result.Data = resultStream.ToArray();
                }
                ms.Close();
            }
            return result;
        }

        public static object UnzipObject(IZEntity z)
        {
            object result = null;
            using (MemoryStream zipStream = new MemoryStream(z.Data))
            {
                zipStream.Position = 0;
                using (GZipStream gZipStream = new GZipStream(zipStream, CompressionMode.Decompress))
                {
                    byte[] buffer = new byte[z.Size];
                    gZipStream.Read(buffer, 0, z.Size);
                    using (MemoryStream ms = new MemoryStream(buffer))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        ms.Position = 0;
                        result = bf.Deserialize(ms);
                    }
                    if (result.GetType() != z.Type)
                    {
                        throw new InvalidCastException("Decompressed stream does not correspond to source type");
                    }
                    gZipStream.Close();
                }
                zipStream.Close();
            }
            return result;
        }
    }
}