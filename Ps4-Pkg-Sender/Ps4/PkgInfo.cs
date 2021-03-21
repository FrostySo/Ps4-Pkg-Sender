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

        //public string[] PkgFiles { get; set; }
        public string[] PatchSegments { get; set; }

        private string NameFromFile(string filePath) {
            return System.IO.Path.GetFileName(filePath);
        }

        public string[] GetFilePaths() {
            var filePathList = new List<string>();
            filePathList.Add(NameFromFile(FilePath));
            if (PatchSegments != null) {
                filePathList.AddRange(PatchSegments);
            }
            return filePathList.ToArray();
        }

        private static readonly SortedList<PkgType, int> PriorityOrder = new SortedList<PkgType, int>{
            {PkgType.Game,0},
            {PkgType.Patch,1},
            {PkgType.Additional_Content,2},
            {PkgType.Addon_Theme,3},
            {PkgType.Unknown,4 }
        };


        public int CompareTo(PkgInfo other) {
            return Comparer<int>.Default.Compare(PriorityOrder[this.Type], PriorityOrder[other.Type]);
        }

        public int Compare(PkgInfo x, PkgInfo y) {
            return Comparer<int>.Default.Compare(PriorityOrder[x.Type], PriorityOrder[y.Type]);
        }

        public override int GetHashCode() {
            var hashCode = -783403272;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TitleID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ContentID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Version);
            return hashCode;
        }
    }
}
