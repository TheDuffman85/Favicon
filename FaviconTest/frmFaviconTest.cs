using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TheDuffman85.Tools;

namespace FaviconTest
{
    public partial class frmFaviconTest : Form
    {
        #region Variables

        Favicon _favicon = new Favicon();

        #endregion

        #region Constructor

        public frmFaviconTest()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventhandler

        private void btnGet_Click(object sender, EventArgs e)
        {
            Uri url;

            pbFav.Image = null;

            if (Uri.TryCreate(txtUrl.Text, UriKind.RelativeOrAbsolute, out url))
            {
                pbFav.Image = Favicon.GetFromUrl(url).Icon;
            }
        }        

        private void btnGetAsyc_Click(object sender, EventArgs e)
        {
            Uri url;

            pbFav.Image = null;

            _favicon.GetFromUrlAsyncCompleted += _favicon_GetFromUriAsyncCompleted;
                 

            if (Uri.TryCreate(txtUrl.Text, UriKind.RelativeOrAbsolute, out url))
            {
                _favicon.GetFromUrlAsync(url);
            }            
        }

        private void _favicon_GetFromUriAsyncCompleted(object sender, EventArgs e)
        {
            pbFav.Image = _favicon.Icon;
        }

        #endregion
    }
}
