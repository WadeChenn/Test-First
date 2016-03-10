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
            //string inputFileName = "defaultInput.txt";
            //string outputFileName = "defaultOutput.txt";
            string Data_ = "";
            string Template_ = "";
            string Result_ = "";
            if (args.Length == 6)//如果輸入6個參數,判斷輸入的參數分別文檔分別為什麼
            {
                for (int i = 0; i < 6; i++)
                {
                    switch (args[i])
                    {
                        case "-i":
                            Data_ = args[i+1];
                            break;
                        case "-r":
                            Result_ = args[i+1];
                            break;
                        case "-t":
                            Template_ = args[i + 1];
                            break;

                    }

                }
            }
            Console.WriteLine();

            using (StreamReader DataFile = new StreamReader(Data_))//讀出data.txt文件
            using (StreamReader TemplateFile = new StreamReader(Template_))//讀出template.txt文件
            using (StreamWriter ResultFile = new StreamWriter(Result_))//寫入result.txt文件
            {
                char [,] 中文姓名=new char[10,10];
                char [,] 身份證字號=new char[10,10];
                char [,] 年數=new char[10,10];
                string line_Data; //data.txt
                string line_Temp;//template.txt
                string line_Result;//resault.txt

                List<char> Data_List;
                List<char> Template_List;
                List<char> Result_List;
                int n = 0;
                while (((line_Data = DataFile.ReadLine()) != null) )//讀出data.txt
                {
                    if (line_Data == "中文姓名身份證字號年數")
                        continue;
                    string outputLine =line_Data;
                    char[] Data_str = line_Data.ToCharArray();//字符串轉換為一個char型數組
                    //Console.WriteLine("***"+outputLine);
                    //for (int i = 0; i < Data_str.Length;i++ )
                    //Console.Write(Data_str[i]);//測試輸出最後一個字符

                    //******提取變量******
                    年數[n,0] = Data_str[Data_str.Length - 2];
                    年數[n,1] = Data_str[Data_str.Length - 1];
                    //Console.WriteLine(年數[n]);
                    for(int i=7;i>0;i--)
                    身份證字號[n,i] =Data_str[Data_str.Length-2-i];
                    //Console.WriteLine(身份證字號[n]);
                    for(int i=0;i<Data_str.Length-9;i++)
                    中文姓名[n,i]=Data_str[i];
                    //Console.WriteLine(中文姓名[n]);

                    n++;
                    Data_List = line_Data.ToList();

                   //nsole.Write(Data_List[0]);//test
                }
                string str0;
                n = 0;
                for (int k = 0; k < 3; k++)
                {
                    while ((line_Temp = TemplateFile.ReadLine()) != null)//讀出template.txt
                    {
                        string outputLine2 = line_Temp;
                        //Console.WriteLine(outputLine2);
                        Template_List = line_Temp.ToList();
                        // Console.Write(Template_List[0]);//test

                        // Console.Write(中文姓名.GetLength(0));
                        //*****處理字符串*****
                        Result_List = Template_List;//將Template字符串保存到Result字符串中.
                        for (int i = 0; i < Result_List.Count(); i++)
                        {
                            if (Result_List[i] == '$')
                            {
                                switch (Result_List[i + 2])
                                {
                                    case '中':
                                        Result_List.RemoveRange(i, 7);
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (中文姓名[n, j] != '\0')
                                                Result_List.Insert(i + j, 中文姓名[n, j]);//將姓名插入list中

                                        }
                                        break;
                                    case '身':
                                        Result_List.RemoveRange(i, 8);
                                        for (int j = 0; j < 10; j++)
                                        {
                                            if (身份證字號[n, j] != '\0')
                                                Result_List.Insert(i + j, 身份證字號[n, j]);//將身份證號碼插入list中

                                        }


                                        break;
                                    case '年':
                                        Result_List.RemoveRange(i, 5);
                                        for (int j = 0; j < 2; j++)
                                        {
                                            if (年數[0, j] != '\0')
                                                Result_List.Insert(i + j, 年數[n, j]);//將年數插入到list中

                                        }


                                        break;
                                }

                            }
                        }

                        for (int i = 0; i < Result_List.Count(); i++)
                        {
                            Console.Write(Result_List[i]);
                            ResultFile.Write(Result_List[i]);//輸出到result.txt文件
                        }
                        Console.WriteLine();
                        ResultFile.WriteLine();
                       
                    }
                    TemplateFile.BaseStream.Seek(0, SeekOrigin.Begin);
                    //StreamReader.
                    n++;
                }
            }
            //string str_ = "123陳燁煒";
            //Console.WriteLine(str_);
        }
    }
}
/*
 ${中文姓名}先生(身份證字號${身份證字號})為
本校專任教師，聘期${年數}
                         此聘
                                   校長*/
