using Ps4_Pkg_Sender.Enums;
using Ps4_Pkg_Sender.Extensions;
using Ps4_Pkg_Sender.Ps4;
using System.Windows.Forms;

namespace Ps4_Pkg_Sender {
    public class QueueItem : System.IComparable<QueueItem>{
        public ListViewItem ListViewItem { get; }
        public TaskType TaskType { get; set; }

        public PkgInfo PkgInfo { get; set; }

        public bool Uninstall { get; set; }

        public Models.FileRenameInfo FileRenameInfo { get; set; }
            this.ListViewItem = listViewItem;
            this.TaskType = TaskType.Queued;
            this.PkgInfo = pkgInfo;
        }

        public void UpdateType(Enums.PkgType pkgType,ListView listView) {
            listView.InvokeIfRequired(() => ListViewItem.SubItems[2].Text = pkgType.ToString());
            this.PkgInfo.Type = pkgType;
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
            return this.PkgInfo.CompareTo(other.PkgInfo);
        }
    }
}
