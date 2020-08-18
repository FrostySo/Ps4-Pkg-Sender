using Ps4_Pkg_Sender.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ps4_Pkg_Sender.Exceptions {
    public class SkipItemException : Exception {
        public TaskType TaskType { get; internal set; }
        public SkipItemException(TaskType taskType) {
            this.TaskType = taskType;
        }

        public SkipItemException(TaskType taskType, string message):base(message){
            this.TaskType = taskType;
        }
    }
}
