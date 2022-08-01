using System;
using System.Collections.Generic;

namespace CALCULATOR
{
    class Program
    {
        static string MODE = "SIMPLE";

        static void Main()
        {
            Console.Title = "Calculator";
            Console.Clear();

            print(">>Warning: this program is not recommended for multi-operation equations\n>>Type 'HELP' to open the help menu");
            while(true){
                print(">>", 'n');
                string? input = Console.ReadLine();

                if(input != null && input != ""){
                    double? output = process(input);

                    if(output != null){
                        print(">>" + output);
                    }
                }
            }
        }
        
        static double? process(string input)
        {
            if(input == "HELP"){
                print(">>HELP MENU\n>>  MAIN COMMANDS:\n>>    CMDMODE : DISPLAY CURRENT COMMAND MODE\n>>      0 = SIMPLE\n>>      1 = COMMAND-BASED\n>>    CMDMODE S (DEFAULT) : SET COMMAND MODE TO SIMPLE\n>>    CMDMODE C : SET COMMAND MODE TO COMMAND-BASED\n>>  AVAILABLE OPERATORS:\n>>    '+' : ADDITION\n>>    '-' : SUBSTACTION\n>>    '*' : MULTIPLICATION\n>>    '/' : DIVISION\n>>    '^' : POWER\n>>    '%' : REMAINDER\n>>  COLOR OPTIONS:\n>>    WHITE\n>>    BLACK\n>>    RED\n>>    GREEN\n>>    BLUE\n>>    YELLOW\n>>    PINK\n>>    CYAN\n>>  EXAMPLES:\n>>    CALCULATIONS (REMOVE PREFIX 'OP ' IF ON SIMPLE MODE) : OP 1+2\n>>    TEXT COLOR CHANGES (COMMAND-BASED MODE ONLY) : COLOR YELLOW\n>>    BACKGROUND COLOR CHANGES (COMMAND-BASED MODE ONLY) : COLORBG WHITE\n>>    CLEAR CONSOLE : CLEAR");
                return null;
            } else if(input == "CLEAR"){
                Console.Clear();
                return null;
            }else if(input.StartsWith("CMDMODE ")){
                if(input[input.Length - 1] == 'S')
                    MODE = "SIMPLE";
                else if(input[input.Length - 1] == 'C')
                    MODE = "COMMAND";
                return null;
            } else if(input == "CMDMODE")
                return (MODE == "SIMPLE") ? 0 : 1;

            if(MODE == "COMMAND"){
                switch (input)
                {
                    case "COLOR WHITE": Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "COLOR BLACK": Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case "COLOR RED": Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "COLOR GREEN": Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "COLOR BLUE": Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case "COLOR YELLOW": Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case "COLOR PINK": Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case "COLOR CYAN": Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "COLORBG WHITE": Console.BackgroundColor = ConsoleColor.White;
                        break;
                    case "COLORBG BLACK": Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    case "COLORBG RED": Console.BackgroundColor = ConsoleColor.Red;
                        break;
                    case "COLORBG GREEN": Console.BackgroundColor = ConsoleColor.Green;
                        break;
                    case "COLORBG BLUE": Console.BackgroundColor = ConsoleColor.Blue;
                        break;
                    case "COLORBG YELLOW": Console.BackgroundColor = ConsoleColor.Yellow;
                        break;
                    case "COLORBG PINK": Console.BackgroundColor = ConsoleColor.Magenta;
                        break;
                    case "COLORBG CYAN": Console.BackgroundColor = ConsoleColor.Cyan;
                        break;
                }

                if(!input.StartsWith("OP ")){
                    Console.Clear();
                    return null;
                }
                else{
                    string newStr = "";
                    for (int i = 3; i < input.Length; i++)
                        newStr += input[i];
                    input = newStr;
                }
            }

            input += 'x';
            List<string> format = new List<string>();
            string part = "";
            foreach (char i in input)
            {
                try{
                    int t = int.Parse(i.ToString());
                    part += i;
                } catch{
                    if(i == '.')
                        part += i;
                    else{
                        if(part != ""){
                            format.Add(part);
                            part = "";
                        }

                        format.Add(i.ToString());
                    }
                }
            }

            double? a = null;
            double? b = null;
            string func = "";
            for (int i = 0; i < format.Count; i++){
                string item = format[i];
                try{
                    if(a == null)
                        a = double.Parse(item);
                    else if(b == null)
                        b = double.Parse(item);
                }catch{
                    func = item;
                }

                if(a != null && b != null && func != ""){
                    switch (func)
                    {
                        case "+": a += b;
                            break;
                        case "-": a -= b;
                            break;
                        case "*": a *= b;
                            break;
                        case "/": a /= b;
                            break;
                        case "%": a %= b;
                            break;
                        case "^": a = Math.Pow((double)a, (double)b);
                            break;
                    }
                    b = null;
                    func = "";
                }
            }

            return a;
        }

        static void print(object output, char mode = 'l')
        {
            if(mode == 'l')
                Console.WriteLine(output);
            else
                Console.Write(output);
        }
    }
}