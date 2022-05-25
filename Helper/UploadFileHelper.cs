using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templet.BLL.Helper
{
   public static class UploadFileHelper
    {
        public static string SaveFile(IFormFile FileUrl,string FolderName)
        {
            try
            {
                string FolderPath = Directory.GetCurrentDirectory() + FolderName;
                string FileName = Guid.NewGuid() + Path.GetFileName(FileUrl.FileName);
                string FinalPath = Path.Combine(FolderPath, FileName);
                using (var Stream = new FileStream(FinalPath, FileMode.Create))
                {
                    FileUrl.CopyTo(Stream);
                }

                return FileName;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
           
        }

        public static string FileRemove( string FileName, string FolderPath)
        {
            try
            {
                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory() , "wwwroot", FolderPath,  FileName)))
                {
                    File.Delete(Path.Combine(Directory.GetCurrentDirectory() , "wwwroot", FolderPath,  FileName));
                }

                return "Removed";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
