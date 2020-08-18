namespace Ps4_Pkg_Sender.Ps4 {
    public class DataTrasmittedProgress {
        public DataTrasmittedProgress(long lengthTotal, long transferredTotal, long restSecTotal) {
            this.LengthTotal = lengthTotal;
            this.TotalTransmitted= transferredTotal;
            this.SecondsLeft = restSecTotal;
        }

        public long SecondsLeft { get; set; }
        public long TotalTransmitted { get; set; }
        public long LengthTotal { get; set; }

        public int GetPercentageComplete() {
            return (int)((100f / LengthTotal) * TotalTransmitted);
        }

        public bool ExceedsTotalLength() {
            if(LengthTotal == 0) {
                return false;
            }
            return TotalTransmitted >= LengthTotal;
        }
    }
}
