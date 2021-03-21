using System;
using System.Collections.Generic;

namespace Ps4_Pkg_Sender.Exceptions {
    public class RPIErrorThrownException : Exception {

        private static Dictionary<long, Ps4ErrorCode> ErrorCodesDictionary = new Dictionary<long, Ps4ErrorCode>();

        static RPIErrorThrownException() {
            ErrorCodesDictionary.Add(0x80990019, Ps4ErrorCode.SCE_BGFT_ERROR_TASK_NOENT);
            ErrorCodesDictionary.Add(0x80990004, Ps4ErrorCode.SCE_BGFT_ERROR_INVALID_ARGUMENT);
            ErrorCodesDictionary.Add(0x80990015, Ps4ErrorCode.SCE_BGFT_ERROR_TASK_DUPLICATED);
            ErrorCodesDictionary.Add(0x80020016, Ps4ErrorCode.SCE_KERNEL_ERROR_EINVAL);
        }

        public enum Ps4ErrorCode {
            SCE_BGFT_ERROR_TASK_NOENT,
            SCE_BGFT_ERROR_INVALID_ARGUMENT,
            SCE_BGFT_ERROR_TASK_DUPLICATED,
            SCE_KERNEL_ERROR_EINVAL,
            UNKNOWN
        }

        public long ErrorCode { get; internal set; }
        
        public Ps4ErrorCode StatusCode { get; internal set; }

        public RPIErrorThrownException(long errorCode) : base(GetMessage(errorCode)) {
            this.ErrorCode = errorCode;
            this.StatusCode = GetErrorCode(errorCode);
        }
        
        private static string GetMessage(long errorCode) {
            try {
                return GetErrorCode(errorCode).ToString();
            } catch {
                return "unkown error code";
            }
        }

        private static Ps4ErrorCode GetErrorCode(long errorCode) {
            try {
                return ErrorCodesDictionary[errorCode];
            } catch {
                return Ps4ErrorCode.UNKNOWN;
            }
        }
        
    }
}
