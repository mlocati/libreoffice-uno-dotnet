namespace ConsoleDotNetFramework
{
    internal class Program
    {
        private static int Main()
        {
            string programPath = GetProgramPath();

            System.Environment.SetEnvironmentVariable(
                "UNO_PATH",
                programPath,
                System.EnvironmentVariableTarget.Process
            );
            System.Environment.SetEnvironmentVariable(
                "URE_BOOTSTRAP",
                $"vnd.sun.star.pathname:{System.IO.Path.Combine(programPath, "fundamental.ini")}",
                System.EnvironmentVariableTarget.Process
            );
            System.Environment.SetEnvironmentVariable(
                "PATH",
                $"{programPath}{System.IO.Path.PathSeparator}{System.Environment.GetEnvironmentVariable("PATH")}",
                System.EnvironmentVariableTarget.Process
            );
            try
            {
                uno.util.Bootstrap.defaultBootstrap_InitialComponentContext();
                System.Console.Out.WriteLine("OK!");
                return 0;
            }
            catch (System.Exception x)
            {
                System.Console.Error.WriteLine(x.GetType().FullName);
                System.Console.Error.WriteLine(x.Message);
                System.Console.Error.WriteLine(x.StackTrace);
                return 1;
            }
        }

        private static string GetProgramPath()
        {
            var programPath = Microsoft.Win32.Registry.GetValue(Microsoft.Win32.Registry.LocalMachine.Name + @"\SOFTWARE\LibreOffice\UNO\InstallPath", "", null) as string;
            if (string.IsNullOrEmpty(programPath))
            {
                throw new System.Exception("Failed to detect the program path");
            }
            return programPath;
        }
    }
}