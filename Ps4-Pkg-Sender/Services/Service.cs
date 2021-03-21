using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ps4_Pkg_Sender.Services {
  public abstract class Service {
        public abstract string Name { get; }

        protected CancellationTokenSource cancellationToken = new CancellationTokenSource();

        public bool IsRunning { get; private set; } = false;

        public bool RunSyncThread { get; set; } = true;

        protected int SleepDelay = 1000;
        public virtual void StartService() {

            if (RunSyncThread) {
                var thread = new Thread(() => {
                    ServiceThread();
                });
                thread.IsBackground = true;
                thread.Start();
            }

            IsRunning = true;
            Console.WriteLine($"Starting service: {Name}");
        }

        public virtual void StopService() {
            Console.WriteLine($"Stopping service: {Name}");
            IsRunning = false;
            cancellationToken.Cancel();
        }

        protected abstract void ServiceAction();

        public virtual void OnServiceStop() {

        }

        public void ServiceThread() {
            while (!cancellationToken.IsCancellationRequested) {
                try {
                    ServiceAction();
                    Thread.Sleep(SleepDelay);
                } catch (Exception e) {
                    Console.WriteLine($"{Name} service: {e.StackTrace.ToString()}");
                }
            }
        }
    }
}
