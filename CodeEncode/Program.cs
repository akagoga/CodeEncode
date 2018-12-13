using System;

namespace CodeEncode
{
    class Program
    {
        //http://qaru.site/questions/13770/encrypting-decrypting-a-string-in-c

        static void Main(string[] args)
        {
            DocClass doc = new DocClass();
            string path = @"C:\Users\Dmitriy\Desktop\C# Source\CodeEncode\CodeEncode\File1.docx";

            doc.DocOpen(path);

            //doc.ChangeText(newText);

            
            Console.WriteLine("Пожалуйста, введите название алгоритма:");
            Console.WriteLine("1 - алгоритм ...");
            Console.WriteLine("2 - алгоритм ...");
            Console.WriteLine("3 - алгоритм ...");

            string algorythmCode = Console.ReadLine();

            switch (algorythmCode)
            {
                case "1":                
                        Console.WriteLine("Пожалуйста введите пароль");
                        string password = Console.ReadLine();



                        //Берем текст из документа
                        Console.WriteLine("Текст файла:");
                        string plaintext = doc.ReadText();
                        doc.PrintText();
                        Console.WriteLine("");

                        Console.WriteLine("Ваш зашифрованный файл:");
                        string encryptedstring = StringCipher.Encrypt(plaintext, password);
                        doc.ChangeText(encryptedstring);
                        doc.PrintText();
                        Console.WriteLine("");


                        Console.WriteLine("Ваш расшифрованный файл:");
                        string codedText = doc.ReadText();
                        string decryptedstring = StringCipher.Decrypt(codedText, password);
                        doc.ChangeText(decryptedstring);
                        doc.PrintText();
                        Console.WriteLine("");
                    break;

            }








            doc.DocClose(path);
            Console.WriteLine("Нажмите любую клавишу для выхода ...");
            Console.ReadLine();
        }
    }
}
