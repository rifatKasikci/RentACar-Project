using System.IO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Utilities.Helpers
{
    public class FileHelper : IFileHelper
    {

        private static string _currentDirectory = Environment.CurrentDirectory + @"\wwwroot";
        private static string _folderName = @"\images\";


        public void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public IResult CheckFileExists(IFormFile file)
        {
            if (file.Length > 0 && file !=null)
            {
                return new SuccessResult();
            }
            return new ErrorResult("File not found");
        }

        public IResult CheckFileTypeValid(string type)
        {
            if (type != ".png" && type != ".jpeg" && type != ".jpg")
            {
               return new ErrorResult("File type is invalid");
            }
            
            return new SuccessResult();
        }

        public void CreateFile(string directory, IFormFile file)
        {
            using (FileStream fileStream = File.Create(directory))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
        }

        public IResult Delete(string path)
        {
            DeleteOldFile(_currentDirectory + path);
            return new SuccessResult();
        }

        public void DeleteOldFile(string directory)
        {
            if (File.Exists(directory))
            {
                File.Delete(directory);
            }
        }

        public IResult Update(IFormFile file, string imagePath)
        {
            var fileExist = CheckFileExists(file);
            if (fileExist.Message != null)
            {
                return new ErrorResult(fileExist.Message);
            }
            var type = Path.GetFileName(file.FileName);
            var checkFileType = CheckFileTypeValid(type);
            var createRandomName = Guid.NewGuid().ToString();


            if (checkFileType.Message != null)
            {
                return new ErrorResult(checkFileType.Message);
            }

            DeleteOldFile(_currentDirectory + imagePath);
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName + createRandomName + type, file);
            return new SuccessResult(_folderName + createRandomName + type);
        }

        public IResult Upload(IFormFile file)
        {
            var fileExist = CheckFileExists(file);
            if (fileExist.Message != null)
            {
                return new ErrorResult(fileExist.Message);
            }
            var type = Path.GetExtension(file.FileName);
            var checkFileType = CheckFileTypeValid(type);
            var createRandomName = Guid.NewGuid().ToString();


            if (checkFileType.Message != null )
            {
                return new ErrorResult(checkFileType.Message);
            }

            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName + createRandomName + type, file);
            return new SuccessResult(createRandomName + type);

            

        }
    }
}
