﻿using System.Text;

namespace DirectoryTraversal
{
    using System;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = @"D:\Softuni - software engineering\AdvancedJanuary2024";
          //  string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            SortedDictionary<string, List<FileInfo>> extensionsFiles = new();

            string [] fileNames = Directory.GetFiles(inputFolderPath);

            foreach (var fileName in fileNames)
            {
                FileInfo fileInfo = new(fileName);

                if (!extensionsFiles.ContainsKey(fileName))
                {
                    extensionsFiles.Add(fileInfo.Extension, new List<FileInfo>());
                }
                extensionsFiles[fileInfo.Extension].Add(fileInfo);

            }

            StringBuilder sb = new StringBuilder();

            foreach (var extensionFiles in extensionsFiles.OrderByDescending(ef=>ef.Value.Count))
            {
                sb.AppendLine(extensionFiles.Key);

                foreach (var file in extensionFiles.Value.OrderBy(f=>f.Length))
                {
                    sb.AppendLine($"--{file.Name} - {(double)file.Length / 1024:F3}kb");
                }
            }


            return sb.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + reportFileName;
            
            
            File.WriteAllText(filePath, textContent);

        }
    }
}