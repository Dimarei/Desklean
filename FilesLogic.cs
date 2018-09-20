using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desklean
{
    public interface IFileLogic
    {
        bool IsDirectory(string source);
        void MoveFile(string sourceFileName, string destFileName);
        void MoveDirectory(string sourceDirName, string destDirName);
        bool DirExists(string path);
        bool FileExists(string path);
        string[] SplitPath(string path, char symbol);
        string GetExtention(string path);
        void IsReadOnly(string path);

    }
    public class FilesLogic : IFileLogic
    {
        public void IsReadOnly(string path)
        {
            FileAttributes attributes = File.GetAttributes(path);

            if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly);
                File.SetAttributes(path, attributes);
            }

        }

        private FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }

        public string GetExtention(string path)
        {
            string[] array = SplitPath(path, '.');
            string extention = array[array.Length - 1];
            return extention;
        }
        public string[] SplitPath(string path, char symbol)
        {
            string[] array = path.Split(symbol);
            return array;
        }
        public bool FileExists(string path)
        {
            bool fileExists = File.Exists(path);
            return fileExists;
        }
        public bool DirExists(string path)
        {
            bool dirExists = Directory.Exists(path);
            return dirExists;
        }

        public bool IsDirectory(string source)
        {
            FileAttributes attributes = File.GetAttributes(source);
            bool isDirectory = (attributes & FileAttributes.Directory) == FileAttributes.Directory;
            return isDirectory;
        }

        public void MoveFile(string sourceFileName, string destFileName)
        {
            string inicialTarget = destFileName;
            int cont = 0;

            do
            {
                if (File.Exists(destFileName) || Directory.Exists(destFileName))
                {
                    // throw new System.IO.IOException("Target file already exists."); 

                    int targetLength = inicialTarget.Length;
                    string[] pArray = inicialTarget.Split('.');
                    int expansionLength = pArray[pArray.Length - 1].Length;

                    destFileName = inicialTarget.Remove(targetLength - expansionLength - 1) + cont + "." + pArray[pArray.Length - 1];
                    cont++;
                }
                else
                {
                    break;
                }
            } while (true);

            File.Move(sourceFileName, destFileName);
        }

        public void MoveDirectory(string sourceDirName, string destDirName)
        {
            string inicialTarget = destDirName;
            int cont = 0;

            if (!Directory.Exists(sourceDirName))
            {
                throw new System.IO.DirectoryNotFoundException("Source directory couldn't be found.");
            }

            do
            {
                if (Directory.Exists(destDirName) || File.Exists(destDirName))
                {
                    destDirName = inicialTarget + cont;
                    cont++;
                }
                else
                {
                    break;
                }
            } while (true);

            DirectoryInfo sourceDirNameInfo = Directory.CreateDirectory(sourceDirName);
            DirectoryInfo destDirNameInfo = Directory.CreateDirectory(destDirName);

            if (sourceDirNameInfo.FullName == destDirNameInfo.FullName)
            {
                throw new System.IO.IOException("Source and target directories are the same.");
            }

            Stack<DirectoryInfo> sourceDirectories = new Stack<DirectoryInfo>();
            sourceDirectories.Push(sourceDirNameInfo);

            Stack<DirectoryInfo> targetDirectories = new Stack<DirectoryInfo>();
            targetDirectories.Push(destDirNameInfo);

            while (sourceDirectories.Count > 0)
            {
                DirectoryInfo sourceDirectory = sourceDirectories.Pop();
                DirectoryInfo targetDirectory = targetDirectories.Pop();

                foreach (FileInfo file in sourceDirectory.GetFiles())
                {
                    IsReadOnly(file.FullName);
                    file.CopyTo(Path.Combine(targetDirectory.FullName, file.Name), overwrite: true);
                }

                foreach (DirectoryInfo subDirectory in sourceDirectory.GetDirectories())
                {
                    sourceDirectories.Push(subDirectory);
                    targetDirectories.Push(targetDirectory.CreateSubdirectory(subDirectory.Name));
                }
            }

            sourceDirNameInfo.Delete(true);
        }
    }
}
