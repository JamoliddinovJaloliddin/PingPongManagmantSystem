using CG.Web.MegaApiClient;

namespace PingPongManagmantSystem.Service.Common
{
    public static class SendGoogle
    {
        public static void SendFileGoogle()
        {
            try
            {
                MegaApiClient client = new MegaApiClient();

                client.Login("saparbaevazulaykho18@gmail.com", "GoodLuck18041388");
                IEnumerable<INode> nodes = client.GetNodes();

                INode root = nodes.Single(x => x.Type ==NodeType.Root);
                INode myFolder = client.CreateFolder($"{DateTime.Now.ToString("dd/MM/yyyy")}", root);

                string Hello = "Hello word";

                INode myFile = client.UploadFile(@"../../../../../database/database.db", myFolder);
                Uri downloadLinkImage = client.GetDownloadLink(myFile);
                client.Logout();
            }
            catch
            {
                
            }
        }
    }
}



//    INode myFile = client.UploadFile(@"../../../../../database/fresh-market.db", myFolder);
//    Uri downloadLinkImage = client.GetDownloadLink(myFile);

//    MessageBox.Show("Added successfully!");
//    client.Logout();

