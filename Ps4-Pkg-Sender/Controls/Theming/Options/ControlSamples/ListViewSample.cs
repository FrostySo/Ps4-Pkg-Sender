using Ps4_Pkg_Sender.Controls.Theming.Options.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender.Controls.Theming.Options.ControlSamples {
    public class ListViewSample : IControlSample, IDisposable {
        public Color ForeColor { get { return _foreColor; } set { _foreColor = value; _listView.ForeColor = value; } }
        public Color BackColor { get { return _backColor; } set { _backColor = value; _listView.BackColor = value; } }
        public Font Font { get { return _font; } set { _font = value; _listView.Font = _font; } }

        CustomListView _listView;
        private Color _foreColor;
        private Color _backColor;
        private Font _font;
        public ListViewSample() {
            var s = new UI.ListViewThemeItem();
            
            _listView = new CustomListView() {
                ColumnBackColor = s.ColumnBackColor,
                ForeColor = s.ForeColor,
                BackColor = s.BackColor,
                ColumnLinesColor = s.ColumnLinesColor,
                ColumnFontColor = s.ColumnFontColor,
                Dock = DockStyle.Fill,
                View = View.Details,
                HeaderStyle = ColumnHeaderStyle.Nonclickable,
                AllowColumnReorder = false,
                FullRowSelect = true,
            };
            _listView.ColumnWidthChanging += _listView_ColumnWidthChanging;

            _listView.Columns.Add("Title",145);
            _listView.Columns.Add("Status",143);
            var item = new ListViewItem("Ratchet and Clank");
            item.SubItems.Add("Queued");
            _listView.Items.AddRange(new ListViewItem[]{
                CreateRow("Ratchet and Clank","Queued"),
                CreateRow("God of War","Sending"),
                CreateRow("Little Big Planet 3","Sent"),
            });
        }

        private ListViewItem CreateRow(string title, string status) {
            var item = new ListViewItem(title);
            item.SubItems.Add(status);

            return item;
        }

        private void _listView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e) {
            e.NewWidth = this._listView.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        public void Dispose() {
            _font?.Dispose();
            _listView?.Dispose();
        }

        public Control GetSampleControl() {
            return _listView;
        }
    }
}
