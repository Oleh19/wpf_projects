using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandsStart.Commands
{
    class MyCommands
    {
        public static RoutedCommand Exit { get; set; }

        public static RoutedCommand Reset { get; set; }

        public static RoutedCommand Help { get; set; }

        static MyCommands()
        {
            Exit = new RoutedCommand("Exit", typeof(MyCommands));
            Reset = new RoutedCommand("Reset", typeof(MyCommands));
            Help = new RoutedCommand("Help", typeof(MyCommands));
        }
    }
}
