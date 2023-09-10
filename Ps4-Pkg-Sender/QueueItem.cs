using Newtonsoft.Json;
using Ps4_Pkg_Sender.Enums;
using Ps4_Pkg_Sender.Extensions;
using Ps4_Pkg_Sender.Models;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender {
    public class QueueItem : System.IComparable<QueueItem>{

        public ListViewItem ListViewItem { get; }

        public TaskType TaskType { get; set; }

        public Models.FileRenameInfo FileRenameInfo { get; set; }

        public QueueItemInfo Info { get; private set; } = new QueueItemInfo();

        private ListView _listView;
        public QueueItem(ListViewItem listViewItem, ListView listView, Ps4.PkgInfo pkgInfo) {
            this.ListViewItem = listViewItem;
            this.TaskType = TaskType.Queued;
            Info.PkgInfo = pkgInfo;
            this._listView = listView;
        }

        public QueueItem(ListViewItem listViewItem,Ps4.PkgInfo pkgInfo) {
            this.ListViewItem = listViewItem;
            this.TaskType = TaskType.Queued;
            Info.PkgInfo = pkgInfo;
        }

        public QueueItem(ListViewItem listViewItem, ListView listView, QueueItemInfo queueItemInfo) {
            this.ListViewItem = listViewItem;
            Info = queueItemInfo;
            this.TaskType = TaskType.Queued;
            this._listView = listView;
        }

        public void UpdateType(Enums.PkgType pkgType) {
            if(_listView != null) {
                UpdateType(pkgType, _listView);
            }
        }

        public void UpdateType(Enums.PkgType pkgType,ListView listView) {

            listView.InvokeIfRequired(() => ListViewItem.SubItems[2].Text = pkgType.ToDisplayText());
            Info.PkgInfo.Type = pkgType;
        }

        public void UpdateTask(TaskType taskType) {
            if(_listView != null) {
                UpdateTask(taskType, null, _listView);
            }
        }

        public void UpdateTask(TaskType taskType, ListView listView) {
            UpdateTask(taskType, null, listView);
        }

        public void UpdateTask(TaskType taskType, string text, ListView listView) {
            var str = $"{taskType.ToString()}";
            if (!string.IsNullOrEmpty(text)) {
                str += $" - {text}";
            }
            listView.InvokeIfRequired(() => ListViewItem.SubItems[3].Text = str);
            this.TaskType = taskType;
        }

        public int CompareTo(QueueItem other) {
            return Info.PkgInfo.CompareTo(other.Info.PkgInfo);
        }
    }
}
