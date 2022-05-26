using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            System.Console.WriteLine("Escolha uma opção:");
            System.Console.WriteLine("------------------");
            System.Console.WriteLine("1 - Abrir arquivo");
            System.Console.WriteLine("2 - Criar arquivo");
            System.Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: Exit(); break;
                case 1: OpenFile(); break;
                case 2: CreateFile(); break;
                default: Menu(); break;
            }
        }

        static void Exit()
        {
            System.Environment.Exit(0);
        }

        static void OpenFile()
        {
            Console.Clear();
            System.Console.WriteLine("Digite o caminho do arquivo:");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                System.Console.WriteLine(text);
            }

            System.Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void CreateFile()
        {
            Console.Clear();
            System.Console.WriteLine("Digite seu texto abaixo (ESC para sair");
            System.Console.WriteLine("------------------------");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            SaveFile(text);
        }

        static void SaveFile(string text)
        {
            Console.Clear();
            System.Console.WriteLine("Qual o caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            System.Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}