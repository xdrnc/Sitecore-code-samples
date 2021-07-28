using System;
using System.IO;
using Sitecore;
using Sitecore.Sites;
using Sitecore.IO;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Fields;

public partial class alexTest : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void testEndSession_Click(object sender, EventArgs e)
    {
        Session.Abandon();
    }

    protected void checkMediaCacheFolder_Click(object sender, EventArgs e)
    {
        //input from textBox1.Text
        Database database = Sitecore.Configuration.Factory.GetDatabase("web");

        //convert item to mediaitem
        Sitecore.Data.Items.MediaItem mediaItem = database.GetItem(textBox1.Text);

        if (mediaItem != null)
        {
            //Media ID
            string mediaId = string.Empty;
            ID iD = null;

            if (!string.IsNullOrEmpty(mediaItem.FilePath))
            {
                string filePath = mediaItem.FilePath.ToLowerInvariant();
                if (Settings.Media.CacheFileMediaByModifiedDate)
                {
                    iD = MainUtil.GetMD5Hash(filePath + File.GetLastWriteTimeUtc(FileUtil.MapPath(filePath)));
                }
                else
                {
                    iD = MainUtil.GetMD5Hash(filePath);
                }
            }
            else
            {
                Field field = mediaItem.InnerItem.Fields["blob"];
                if (field != null && MainUtil.IsID(field.Value))
                {
                    iD = Sitecore.Data.ID.Parse(field.Value);
                }
            }

            mediaId = (iD == (Sitecore.Data.ID)null) ? string.Empty : iD.ToShortID().ToString().ToLowerInvariant();

            string rootFolder = string.Empty;

            SiteContext site = Sitecore.Context.Site;

            if (site != null)
            {
                rootFolder = site.MediaCachePath;
            }
            else
            {
                rootFolder = FileUtil.MakePath(Settings.Media.CacheFolder, mediaItem.Database.Name);
            }

            string subFolder = ((byte)mediaId.GetHashCode()).ToString();

            string cacheFolderPath = FileUtil.MakePath(rootFolder, subFolder);

            //record file path
            labelOutput.Text = FileUtil.MakePath(cacheFolderPath, mediaId + ".ini");
        }
    }
    
}