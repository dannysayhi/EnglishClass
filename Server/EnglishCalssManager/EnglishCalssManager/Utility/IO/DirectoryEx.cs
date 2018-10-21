using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOISystem.Utility.IO
{
    public class DirectoryEx
    {
        //參考路徑範例 D:\COG_AOI_Data\20130725
        public static string[] DeleteOverdueDirectory(string path, string dateTimeFormate, int saveDays, string[] exceptionDirectory)
        {
            string[] directories = null;
            List<string> deletedDirectories = new List<string>();
            List<string> saveDirectories = new List<string>();
            directories = Directory.GetDirectories(path);
            List<string> directoryList = directories.ToList();
            for (int i = 0; i < saveDays; i++)
            {
                string saveDayString = DateTime.Now.AddDays(i * -1).ToString("yyyyMMdd");
                int count = directoryList.Count;
                for (int j = count - 1; j >= 0; j--)
                {
                    string dateString = directoryList[j].Split('\\').Last();
                    if (dateString.Contains(saveDayString))
                    {
                        saveDirectories.Add(directoryList[j]);
                        directoryList.RemoveAt(j);
                    }
                }
            }
            for (int i = 0; i < exceptionDirectory.Length; i++)
            {
                exceptionDirectory[i] = path + "\\" + exceptionDirectory[i];
            }
            saveDirectories.AddRange(exceptionDirectory);

            foreach (string directory in directories)
            {
                if (!saveDirectories.Contains(directory))
                {
                    DirectoryInfo di = new DirectoryInfo(directory);
                    di.Delete(true);
                    deletedDirectories.Add(directory);
                }
            }
            return deletedDirectories.ToArray();
        }
    }
}
