using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using WBrowser;


namespace EveJimaIGB.Bookmarks
{
    public class Favorites
    {
        public static string favXml = @"Browser\favorits.xml";

        public void Show(TreeView favTreeView, ImageList imgList, ContextMenuStrip linkContextMenu, ContextMenuStrip favContextMenu)
        {
            var myXml = new XmlDocument();

            if (File.Exists(favXml))
            {
                myXml.Load(favXml);

                foreach (XmlElement el in myXml.DocumentElement.ChildNodes)
                {
                    var node = new TreeNode(el.InnerText, FavoritIconIndex(el.GetAttribute("url"), imgList), FavoritIconIndex(el.GetAttribute("url"), imgList))
                    {
                        ToolTipText = el.GetAttribute("url"),
                        Name = el.GetAttribute("url"),
                        ContextMenuStrip = favContextMenu
                    };
                    favTreeView.Nodes.Add(node);
                }
            }
        }

        public void AddFavorit(string url, string name, TreeView favTreeView, ImageList imgList, ContextMenuStrip favContextMenu)
        {
            var myXml = new XmlDocument();
            var el = myXml.CreateElement("favorit");
            el.SetAttribute("url", url);
            el.InnerText = name;
            if (!File.Exists(favXml))
            {
                var root = myXml.CreateElement("favorites");
                myXml.AppendChild(root);
                root.AppendChild(el);
            }
            else
            {
                myXml.Load(favXml);
                myXml.DocumentElement.AppendChild(el);
            }

            var node = new TreeNode(el.InnerText, FavoritIconIndex(el.GetAttribute("url"), imgList), FavoritIconIndex(el.GetAttribute("url"), imgList))
            {
                ToolTipText = el.GetAttribute("url"),
                Name = el.GetAttribute("url"),
                ContextMenuStrip = favContextMenu
            };
            favTreeView.Nodes.Add(node);
            
            myXml.Save(favXml);
        }

        public void RenameFavorit(string url, string name, TreeView favTreeView)
        {
            var rl = new RenameLink(name);

            if (rl.ShowDialog() == DialogResult.OK)
            {
                var myXml = new XmlDocument();
                myXml.Load(favXml);
                foreach (XmlElement x in myXml.DocumentElement.ChildNodes)
                {
                    if (x.InnerText.Equals(name))
                    {
                        x.InnerText = rl.newName.Text;
                        break;
                    }
                }
                favTreeView.Nodes[url].Text = rl.newName.Text;
                myXml.Save(favXml);
            }
            rl.Close();
        }

        public void DeleteFavorit(string url, string name, TreeView favTreeView)
        {
            favTreeView.SelectedNode.Remove();

            var myXml = new XmlDocument();
            myXml.Load(favXml);
            var root = myXml.DocumentElement;
            foreach (XmlElement x in root.ChildNodes)
            {
                if (x.GetAttribute("url").Equals(url))
                {
                    root.RemoveChild(x);
                    break;
                }
            }

            myXml.Save(favXml);
        }

        private static int FavoritIconIndex(string url, ImageList imgList)
        {
            try
            {
                var key = new Uri(url);

                if (!imgList.Images.ContainsKey(key.Host))
                {
                    imgList.Images.Add(key.Host, DownloadFavoritIcon(url, "link.png"));
                }

                return imgList.Images.IndexOfKey(key.Host);
            }
            catch(Exception e)
            {
                return 0;
            }
            
        }

        public static Image DownloadFavoritIcon(string u, string file)
        {
            try
            {
                var url = new Uri(u);
                var iconurl = "http://" + url.Host + "/favicon.ico";

                var request = WebRequest.Create(iconurl);
                var response = request.GetResponse();
                var s = response.GetResponseStream();

                return Image.FromStream(s);
            }
            catch
            {
                return null;
            }
        }
    }
}
