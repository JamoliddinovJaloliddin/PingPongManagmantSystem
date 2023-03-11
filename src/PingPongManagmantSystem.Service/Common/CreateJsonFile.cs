namespace PingPongManagmantSystem.Service.Common
{
    public static class CreateJsonFile
    {
        public static void CreateAsync(string text)
        {
            string path = "files/file.json";
            File.WriteAllText(path, text);
        }
    }
}
