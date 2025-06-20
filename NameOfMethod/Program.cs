using System.IO;
using System.Text.RegularExpressions;
using System.Text.Json;

namespace NameOfMethod
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string dataDir = Directory.GetCurrentDirectory();
            if (!Directory.Exists(dataDir))
            {
                Console.WriteLine($"Directory not found: {dataDir}");
                return;
            }

            foreach (var filePath in Directory.EnumerateFiles(dataDir, "*.json", SearchOption.AllDirectories))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    using var doc = JsonDocument.Parse(json);
                    if (doc.RootElement.TryGetProperty("name", out var nameProp))
                    {
                        string name = nameProp.GetString() ?? "";
                        string sanitized = FileNameHelper.SanitizeFileName(name);
                        string dir = Path.GetDirectoryName(filePath)!;
                        string newFileName = sanitized + Path.GetExtension(filePath);
                        string newPath = Path.Combine(dir, newFileName);
                        if (!filePath.Equals(newPath, StringComparison.OrdinalIgnoreCase))
                        {
                            if (File.Exists(newPath))
                            {
                                Console.WriteLine($"Target file already exists: {newPath}");
                            }
                            else
                            {
                                File.Move(filePath, newPath);
                                Console.WriteLine($"Renamed: {filePath} -> {newPath}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing {filePath}: {ex.Message}");
                }
            }
        }
    }

    public static class FileNameHelper
    {
        public static string SanitizeFileName(string name)
        {
            // Remove leading apostrophes
            name = name.TrimStart('\'');

            // Replace invalid characters with underscore
            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string pattern = $"[{invalidChars}]";
            string safeName = Regex.Replace(name, pattern, "_");

            // Optional: remove trailing dollar sign or periods/spaces
            safeName = safeName.TrimEnd('.', ' ', '$');

            return safeName;
        }
    }
}
