using Ps4_Pkg_Sender.Enums;
using System.Collections.Generic;

namespace Ps4_Pkg_Sender.Ps4 {
    public class PkgInfo : System.IComparable<PkgInfo>, IComparer<PkgInfo>{

        public string Title { get; set; }
        public PkgType Type { get; set; }
        public string TitleID { get; set; }

        public string ContentID { get; set; }

        public string Version { get; set; }

        public string FilePath { get; set; }

        public string[] PkgFiles { get; set; }

        private static readonly SortedList<PkgType, int> PriorityOrder = new SortedList<PkgType, int>{
            {PkgType.Game,0},
            {PkgType.Patch,1},
            {PkgType.Additional_Content,2},
            {PkgType.Addon_Theme,3},
        };

        public int CompareTo(PkgInfo other) {
            return Comparer<int>.Default.Compare(PriorityOrder[this.Type], PriorityOrder[other.Type]);
        }

        public int Compare(PkgInfo x, PkgInfo y) {
            return Comparer<int>.Default.Compare(PriorityOrder[x.Type], PriorityOrder[y.Type]);
        }
    }
}
