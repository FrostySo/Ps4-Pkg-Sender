namespace Ps4_Pkg_Sender.Utilities {
    //A fake, simple logger with no logger levels
    //The lazy way
    public static class Logger {


        public enum Type {
            StandardOutput,
            StandardError,
            DebugOutput
        }
        public static readonly bool DebugOutput = true;

        public static void WriteLine(string message, Type outputType) {

            if (!DebugOutput && outputType != Type.DebugOutput) {
                return;
            }

            switch (outputType) {
                case Type.DebugOutput:
                System.Diagnostics.Debug.WriteLine(message);
                break;
                case Type.StandardOutput:
                System.Console.WriteLine(message);
                break;

                case Type.StandardError:
                System.Console.Error.WriteLine(message);
                break;
            }
        }
    }
}
