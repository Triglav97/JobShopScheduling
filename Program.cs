using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace test_wf{
    static class Program{
        static string text = "1;2;3;4";
        static string[] words = text.Split(';');
        [STAThread]
        static void Main(){
            for(int i=0; i<words.Length;i++){
                Console.WriteLine(words[i]+words.Length);
            }
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
