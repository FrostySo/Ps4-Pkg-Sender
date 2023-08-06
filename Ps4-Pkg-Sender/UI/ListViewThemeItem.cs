using System.Collections.Generic;
using System.Drawing;

namespace Ps4_Pkg_Sender.UI {
    public class ListViewThemeItem : ThemeItem {
        public const string ColFontColorStr = "ColumnFontColor";
        public const string ColBackColorStr = "ColumnBackColor";
        public const string ColLinesColorStr = "ColumnLinesColor";
        public const string FontStr = "Font";
        public ListViewThemeItem() : base("ListViews", 
            new KeyValuePair<string, object>("BackColor", Color.FromArgb(30, 30, 30)),
            new KeyValuePair<string, object>("ForeColor", Color.White)) {
            Values.Add(ColFontColorStr, Color.White);
            Values.Add(ColBackColorStr, Color.FromArgb(30,30, 30, 30));
            Values.Add(ColLinesColorStr, Color.Gray);
            Values.Add(FontStr, new Font("Microsoft Sans Serif",11.25f,FontStyle.Regular));
        }

        public Font Font => Values[FontStr] as Font;
        public Color ColumnFontColor => (Color)Values[ColFontColorStr];
        public Color ColumnBackColor => (Color)Values[ColBackColorStr];
        public Color ColumnLinesColor => (Color)Values[ColLinesColorStr];
    }
}
