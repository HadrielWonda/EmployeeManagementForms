using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Baumax.Environment;
using Baumax.Environment.Interfaces;

namespace Baumax.Client
{
    class ZipCache
    {
        public static void SaveData()
        {/*
            string path = System.Windows.Forms.Application.UserAppDataPath + @"\Baumax\Baumax.Client\";
            string user = ClientEnvironment.AuthorizationService.GetCurrentUser().LoginName;
            using (FileStream stream = new FileStream( string.Concat(path, user, ".baumax"), 
                FileMode.Create))
                using (GZipStream gzstream = new GZipStream(stream, CompressionMode.Compress, true))
                {
                    (ClientEnvironment.CountryService as IStreamingService).SaveToStream(gzstream);
                    (ClientEnvironment.RegionService as IStreamingService).SaveToStream(gzstream);
                    (ClientEnvironment.StoreService as IStreamingService).SaveToStream(gzstream);
                    (ClientEnvironment.WorldService as IStreamingService).SaveToStream(gzstream);
                    (ClientEnvironment.HWGRService as IStreamingService).SaveToStream(gzstream);
                    (ClientEnvironment.WGRService as IStreamingService).SaveToStream(gzstream);
                }*/
        }
   
        public static void LoadData()
        {
            /*string path = System.Windows.Forms.Application.UserAppDataPath + @"\Baumax\Baumax.Client\";
            string user = ClientEnvironment.AuthorizationService.GetCurrentUser().LoginName;

            using (FileStream stream = new FileStream( string.Concat(path,user,".baumax"), 
                FileMode.Open))
            {
                stream.Position = 0;
                using (GZipStream gzstream = new GZipStream(stream, CompressionMode.Decompress))
                {
                    (ClientEnvironment.CountryService as IStreamingService).RestoreFromStream(gzstream);
                    (ClientEnvironment.RegionService as IStreamingService).RestoreFromStream(gzstream);
                    (ClientEnvironment.StoreService as IStreamingService).RestoreFromStream(gzstream);
                    (ClientEnvironment.WorldService as IStreamingService).RestoreFromStream(gzstream);
                    (ClientEnvironment.HWGRService as IStreamingService).RestoreFromStream(gzstream);
                    (ClientEnvironment.WGRService as IStreamingService).RestoreFromStream(gzstream);
                }
            }*/
        }
    }
}
