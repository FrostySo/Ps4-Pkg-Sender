using Ps4_Pkg_Sender.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ps4_Pkg_Sender.Services {
    public class FileRenameService : Service {
        public override string Name => "File renaming service";

        public Queue<Models.FileRenameInfo> FileRenameQueue { get; private set; } =  new Queue<Models.FileRenameInfo>();

        public bool HasPendingItems() {
            return FileRenameQueue.Count > 0;
        }

        protected override void ServiceAction() {
            if(HasPendingItems()) {
                var renameInfo = FileRenameQueue.Dequeue();
                if(renameInfo != null){
                    var pathName = System.IO.Path.GetFileName(renameInfo.CurrentPath);
                    if(pathName != renameInfo.WantedName) {
                        try {
                            File.Move(renameInfo.CurrentPath, $"{Path.GetDirectoryName(renameInfo.CurrentPath)}\\{renameInfo.WantedName}");
                        } catch (UnauthorizedAccessException e) {
                            //handle it, maybe one day >_>
                        }catch(FileNotFoundException e) {
                            //for future handles, if needed
                        }
                    }
                };
            }
        }

        public bool Rename(FileRenameInfo renameInfo) {
            var pathName = System.IO.Path.GetFileName(renameInfo.CurrentPath);
            if (pathName != renameInfo.WantedName) {
                try {
                    var newNamePath = $"{Path.GetDirectoryName(renameInfo.CurrentPath)}\\{renameInfo.WantedName}";
                    File.Move(renameInfo.CurrentPath, newNamePath);
                    //flip them for later
                    //so we can rename them back to original
                    var tempWantedName = renameInfo.WantedName;
                    renameInfo.WantedName = renameInfo.CurrentName;
                    renameInfo.CurrentName = tempWantedName;
                    renameInfo.CurrentPath = newNamePath;
                    return true;
                }catch {
                    return false;
                }
            } else {
                return true;
            }
        }
    }
}
