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
            lblError.Text = string.Empty;

            if (Uri.TryCreate(txtUrl.Text, UriKind.RelativeOrAbsolute, out url))
            {
                try
                {
                    pbFav.Image = Favicon.GetFromUrl(url).Icon;
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }                
            }
        }        

        private void btnGetAsyc_Click(object sender, EventArgs e)
        {
            Uri url;

            pbFav.Image = null;
            lblError.Text = string.Empty;

            _favicon.GetFromUrlAsyncCompleted += _favicon_GetFromUriAsyncCompleted;
                 

            if (Uri.TryCreate(txtUrl.Text, UriKind.RelativeOrAbsolute, out url))
            {
                _favicon.GetFromUrlAsync(url);
            }            
        }

        private void _favicon_GetFromUriAsyncCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                lblError.Invoke((MethodInvoker)(() =>
                {
                    lblError.Text = e.Error.Message;
                }
                ));                
            }
            else
            {
                pbFav.Image = _favicon.Icon;
            }
        }

        #endregion
    }
}
