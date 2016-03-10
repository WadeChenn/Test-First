using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeDataAndDoc
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFileName = "defaultInput.txt";
            string outputFileName = "defaultOutput.txt";
            string Data_ = "data.txt";
            string Template_ = "template.txt";
            string Result_ = "result.txt";
            if (args.Length == 2)
            {
                inputFileName = args[0];
                outputFileName = args[1];
            }
            Console.WriteLine();

            using (StreamReader DataFile = new StreamReader(Data_))
            using (StreamReader TemplateFile = new StreamReader(Template_))
            using (StreamWriter ResultFile = new StreamWriter(Result_))
            {
                string line_Data; //test
                string line_Temp;
                while((line_Data = DataFile.ReadLine()) != null)
                {
                    string outputLine = "***" + line_Data;
                    Console.WriteLine("Write line: " + outputLine);
                    //ResultFile.WriteLine(outputLine);
                }
                while ((line_Temp = TemplateFile.ReadLine()) != null)
                {
                    string outputLine2 = "***" + line_Temp;
                    Console.WriteLine("Write line: " + outputLine2);
                    //ResultFile.WriteLine(outputLine);
                }
            }
            //string str_ = "123陳燁煒";
            //Console.WriteLine(str_);
        }
    }
}
