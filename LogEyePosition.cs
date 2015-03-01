namespace LogEyePosition
{
    using EyeXFramework;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Tobii.EyeX.Framework;
    using System.Linq;

    public static class Program
    {
        public static string fname = "eyeposition.txt";

        public static void Main(string[] args)
        {
            using (var eyeXHost = new EyeXHost())
            {
                using (var lightlyFilteredGazeDataStream = eyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered))
                {
                    eyeXHost.Start();
                    System.IO.StreamWriter file = new System.IO.StreamWriter(fname, true);
                    EventHandler<GazePointEventArgs> listener = (s, e) => {
                        file.WriteLine(DateTime.Now.ToString("o")+"\t"+e.X+"\t"+e.Y);
                    };
                    lightlyFilteredGazeDataStream.Next += listener;
                    Console.WriteLine("logging to " + fname + ", press enter to exit");
                    Console.ReadLine();
                    lightlyFilteredGazeDataStream.Next -= listener;
                    file.Flush();
                    file.Close();
                }
            }
            
        }
    }
}
