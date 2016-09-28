using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WFAReadyXML
{
    public class ExecProcess
    {
        ///<summary>
        /// Executes a process and waits for it to end. 
        ///</summary>
        ///<param name="cmd">Full Path of process to execute.</param>
        ///<param name="cmdParams">Command Line params of process</param>
        ///<param name="workingDirectory">Process' working directory</param>
        ///<param name="timeout">Time to wait for process to end</param>
        ///<param name="stdOutput">Redirected standard output of process</param>
        ///<returns>Process exit code</returns>
        public static int ExecuteProcess(string cmd, string cmdParams, string workingDirectory, int timeout, out string stdOutput)
        {
            using (Process process = Process.Start(new ProcessStartInfo(cmd, cmdParams)))
            {
                process.StartInfo.WorkingDirectory = workingDirectory;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                stdOutput = process.StandardOutput.ReadToEnd();
                process.WaitForExit(timeout);

                return process.ExitCode;
            }
        }
    }
}
