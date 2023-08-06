using Ps4_Pkg_Sender.Enums;

namespace Ps4_Pkg_Sender.Ps4 {
    public class PkgTransferProgress {
        public TransferStatus TransferStatus { get; set; }
        public DataTrasmittedProgress DataTrasmittedProgress { get; set; }
        public long TimeLeft { get; set; } = -1;
    }
}
