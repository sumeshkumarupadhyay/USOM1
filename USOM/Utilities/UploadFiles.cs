using System;
using System.IO;
using System.Web;

namespace USOM
{
	public static class FileHandler
    {
        public static string UploadFile(string folderPath, HttpPostedFileBase file)
        {
            string fname = $"{Guid.NewGuid()}_{file.FileName}";
            //Check Directory exists else create one
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Get the complete folder path and store the file inside it.  
            string uploadFileName = string.Format("{0}", fname);

            fname = Path.Combine(folderPath, fname);

            if (!File.Exists(fname))
            {
                file.SaveAs(fname);
            }

            return uploadFileName;
        }

        public static void DeleteFile(string FileToDelete)
        {
            if (File.Exists(FileToDelete))
            {
                File.Delete(FileToDelete);
            }
        }
    }
}