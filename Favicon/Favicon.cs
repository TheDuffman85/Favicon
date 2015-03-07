using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TheDuffman85.Tools
{
    /// <summary>
    /// This class provides the favicon of a given url.
    /// </summary>
    public class Favicon
    {
        #region Delegate

        public delegate void GetFromUrlAsyncCompletedEventHandler(object sender, EventArgs e);

        #endregion

        #region Events

        public event GetFromUrlAsyncCompletedEventHandler GetFromUrlAsyncCompleted;

        #endregion

        #region Variables

        private Image _icon;
        private object _tag;
        
        #endregion

        #region Properties

        /// <summary>
        /// The favicon of the given url. Use GetFromUrl or GetFromUrlAsync to fill this property.
        /// </summary>
        public Image Icon
        {
            get { return _icon; }
        }
        
        /// <summary>
        /// Gets or sets the object that contains supplemental data.
        /// </summary>
        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Standard constructor.
        /// </summary>
        public Favicon()
        {
        }

        private Favicon(Image icon)
        {
            _icon = icon;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the favicon from a given url.
        /// </summary>
        /// <param name="url">The url to get the favicon from.</param>
        /// <returns>Favicon</returns>
        public static Favicon GetFromUrl(Uri url)
        {
            Favicon favicon = new Favicon();

            favicon._icon = favicon.GetIcon(url);

            return favicon;            
        }

        /// <summary>
        /// Gets the favicon asynchronously from a given url.
        /// </summary>
        /// <param name="url">The url to get the favicon from.</param>
        /// <returns>Favicon</returns>
        public void GetFromUrlAsync(Uri url)
        {
            new Task(() =>
            {
                this._icon = GetIcon(url);

                if (GetFromUrlAsyncCompleted != null)
                {
                    GetFromUrlAsyncCompleted(this, new EventArgs());
                }
            }
            ).Start();            
        }

        #endregion

        #region Private Methods

        private Image GetIcon(Uri url)
        {
            Image icon = null;

            icon = DownloadFavicon(url, "/favicon.ico");

            if (icon == null)
            {
                string iconUrl = ExtractFavIconUrl(url);

                if (iconUrl != null)
                {
                    icon = DownloadFavicon(url, iconUrl);
                }
            }

            return icon;
        }

        private WebClient GetWebClient()
        {            
            WebClient client = new WebClient();

            IWebProxy wp = WebRequest.DefaultWebProxy;
            wp.Credentials = CredentialCache.DefaultCredentials;
            client.Proxy = wp;

            return client;                        
        }
                
        private string ExtractFavIconUrl(Uri url)
        {
            WebClient client = GetWebClient();
            string iconUrl = null;

            try
            {
                string html = client.DownloadString(url);

                Match match;

                // Link
                foreach (Match m in Regex.Matches(html, "<link[^>]*[\\/]?>", RegexOptions.IgnoreCase))
                {
                    string tag = m.Value;

                    match = Regex.Match(tag, "rel=\"icon\"|rel=\"shortcut icon\"|rel=\"apple-touch-icon\"|rel=\"apple-touch-icon-precomposed\"", RegexOptions.IgnoreCase);

                    if (match.Success)
                    {
                        match = Regex.Match(tag, "href=\"([^\"]*)\"", RegexOptions.IgnoreCase);

                        if (match.Success)
                        {
                            return match.Groups[1].Value;
                        }
                    }
                }

                // Meta
                foreach (Match m in Regex.Matches(html, "<meta[^>]*[\\/]?>", RegexOptions.IgnoreCase))
                {
                    string tag = m.Value;

                    match = Regex.Match(tag, "itemprop=\"image\"", RegexOptions.IgnoreCase);

                    if (match.Success)
                    {
                        match = Regex.Match(tag, "content=\"([^\"]*)\"", RegexOptions.IgnoreCase);

                        if (match.Success)
                        {
                            return match.Groups[1].Value;
                        }
                    }
                }
            }
            catch
            {
            }

            return iconUrl;            
        }

        private Image DownloadFavicon(Uri baseUrl, string iconUrl)
        {         
            Image icon = null;
            WebClient client = GetWebClient();

            try
            {
                // Download fav icon
                if (!string.IsNullOrEmpty(iconUrl))
                {
                    Uri faviconUrl;

                    if (Uri.TryCreate(iconUrl, UriKind.RelativeOrAbsolute, out faviconUrl))
                    {
                        if (!faviconUrl.IsAbsoluteUri)
                        {
                            faviconUrl = new Uri(baseUrl, iconUrl);
                        }

                        Stream dataStream = client.OpenRead(faviconUrl);
                        icon = Image.FromStream(dataStream);
                    }
                }
            }
            catch
            {
            }

            return icon;            
        }

        #endregion
    }
}
