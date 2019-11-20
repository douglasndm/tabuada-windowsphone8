using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Tabuada.Tiles
{
    public partial class DefaultTileTemplate : UserControl
    {
        public DefaultTileTemplate()
        {
            InitializeComponent();   
        }

        public void CreateTile()
        {
            WriteableBitmap wb = new WriteableBitmap(691, 336);
            DefaultTileTemplate dft = new DefaultTileTemplate();
            dft.Width = 691;
            dft.Height = 336;
            dft.Arrange(new Rect(0, 0, 691, 336));

            wb.Render(dft, new CompositeTransform());
            wb.Invalidate();

            using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream("/Shared/ShellContent/wideTile.jpg", System.IO.FileMode.Create, IsolatedStorageFile.GetUserStoreForApplication()))
            {
                wb.SaveJpeg(isfs, 691, 336, 0, 100);
            }
        }

        public void GoToHome()
        {
        }
    }
}
