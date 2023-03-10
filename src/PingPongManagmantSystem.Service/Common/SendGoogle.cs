using CG.Web.MegaApiClient;

namespace PingPongManagmantSystem.Service.Common
{
    public static class SendGoogle
    {
        public static async Task<bool> SendFileGoogle(string statistic)
        {
            try
            {
                MegaApiClient client = new MegaApiClient();

                client.Login("saparbaevazulaykho18@gmail.com", "GoodLuck18041388");
                IEnumerable<INode> nodes = client.GetNodes();

                INode root = nodes.Single(x => x.Type == NodeType.Root);
                INode myFolder = await client.CreateFolderAsync($"{statistic}   {DateTime.Now.ToString("dd/MM/yyyy")}", root);

                INode myFile = await client.UploadFileAsync(@"files/file.json", myFolder);
                Uri downloadLinkImage = client.GetDownloadLink(myFile);
                client.Logout();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
