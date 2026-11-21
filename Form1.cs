using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace newprojs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "new_project";
        }
        public static void Mains(string[] argv)
        {
            string f1 = "<Solution>\r\n  <Project Path=\"$1.csproj\" />\r\n</Solution>\r\n";
            string f2 = "<Project Sdk=\"Microsoft.NET.Sdk\">\r\n\r\n    <PropertyGroup>\r\n        <TargetFramework>net6.0</TargetFramework>\r\n        <!--<RuntimeIdentifier>cosmos</RuntimeIdentifier>-->\r\n        <Platform>cosmos</Platform>\r\n        <SupportsX86Intrinsics>false</SupportsX86Intrinsics>\r\n        <SelfContained>True</SelfContained>\r\n    </PropertyGroup>\r\n\r\n    <PropertyGroup>\r\n        <EnableGDB>False</EnableGDB>\r\n        <StartCosmosGDB>False</StartCosmosGDB>\r\n        <VisualStudioDebugPort>Pipe: Cosmos\\Serial</VisualStudioDebugPort>\r\n        <CosmosDebugPort>Serial: COM1</CosmosDebugPort>\r\n        <Launch>VMware</Launch>\r\n        <Profile>VMware</Profile>\r\n        <Description>Use VMware Player or Workstation to deploy and debug.</Description>\r\n        <PxeInterface>192.168.0.8</PxeInterface>\r\n        <DebugEnabled>False</DebugEnabled>\r\n    </PropertyGroup>\r\n\r\n    <ItemGroup>\r\n        <PackageReference Include=\"Cosmos.Build\" Version=\"0-*\" NoWarn=\"NU1604\" />\r\n        <PackageReference Include=\"Cosmos.Debug.Kernel\" Version=\"0-*\" NoWarn=\"NU1604\" />\r\n        <PackageReference Include=\"Cosmos.System2\" Version=\"0-*\" NoWarn=\"NU1604\" />\r\n    </ItemGroup>\r\n\r\n</Project>\r\n";
            string f3 = "using System;\r\nusing System.Collections.Generic;\r\nusing System.Text;\r\nusing Sys = Cosmos.System;\r\n\r\nnamespace $1\r\n{\r\n    public class Kernel : Sys.Kernel\r\n    {\r\n\r\n        protected override void BeforeRun()\r\n        {\r\n            Console.WriteLine(\"Cosmos booted successfully. Type a line of text to get it echoed back.\");\r\n        }\r\n\r\n        protected override void Run()\r\n        {\r\n            Console.BackgroundColor = ConsoleColor.White;\r\n            Console.ForegroundColor = ConsoleColor.Black;\r\n            Console.Clear();\r\n\r\n            Console.Write(\"Input: \");\r\n            var input = Console.ReadLine();\r\n            Console.Write(\"Text typed: \");\r\n            Console.WriteLine(input);\r\n            input = Console.ReadLine();\r\n        }\r\n    }\r\n}\r\n";
            
            if (argv.Length < 1) return;
            f1 = f1.Replace("$1", argv[0]);
            f3 = f3.Replace("$1", argv[0]);
            Directory.CreateDirectory(argv[0]);
            File.WriteAllText(argv[0] + "\\" + argv[0] + ".slnx", f1);
            File.WriteAllText(argv[0] + "\\" + argv[0] + ".csproj", f2);
            File.WriteAllText(argv[0] + "\\" + "Kernel.cs", f3);
            return;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] s= new string[1];
            s[0] = textBox1.Text.ToString();
            Mains(s);
        }
    }
}
