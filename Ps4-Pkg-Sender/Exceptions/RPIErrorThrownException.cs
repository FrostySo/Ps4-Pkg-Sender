using System;
using System.Collections.Generic;

namespace Ps4_Pkg_Sender.Exceptions {
    public class RPIErrorThrownException : Exception {

        private static Dictionary<long, string> ErrorCodesDictionary = new Dictionary<long, string>();

        static RPIErrorThrownException() {
            ErrorCodesDictionary.Add(0x80990019, "SCE_BGFT_ERROR_TASK_NOENT");
            ErrorCodesDictionary.Add(0x80990004, "SCE_BGFT_ERROR_INVALID_ARGUMENT");
            ErrorCodesDictionary.Add(0x80990015, "SCE_BGFT_ERROR_TASK_DUPLICATED");
            ErrorCodesDictionary.Add(0x80020016, "SCE_KERNEL_ERROR_EINVAL");
        }

        public long ErrorCode { get; internal set; }
        public RPIErrorThrownException(long errorCode) : base(GetMessage(errorCode)) {
            this.ErrorCode = errorCode;
        }
        
        private static string GetMessage(long errorCode) {
            try {
                return ErrorCodesDictionary[errorCode];
            } catch {
                return "unkown error code";
            }
        }
        
    }
}
