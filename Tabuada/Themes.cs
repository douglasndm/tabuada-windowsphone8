using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tabuada.Class
{
    public class Themes
    {
        public String ThemeName { get; set; }
        public Color BackgroundColor { get; set; }
        public Color ForegroundColor { get; set; }

        public SolidColorBrush Foreground
        {
            get
            { return new SolidColorBrush(ForegroundColor); }
        }
        public SolidColorBrush Background
        {
            get
            { return new SolidColorBrush(BackgroundColor); }
        }
    }

    public class ThemeCollection : List { }
}
