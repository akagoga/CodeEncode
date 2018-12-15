using System;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;

namespace CodeEncode
{
    class Program
    {
        static void Main(string[] args)
        {
            DocClass doc = new DocClass();
            string path = @"C:\Users\Dmitriy\Desktop\C# Source\CodeEncode\CodeEncode\File1.docx";

            doc.DocOpen(path);
            
            Console.WriteLine("Пожалуйста, введите название алгоритма:");
            Console.WriteLine("1 - алгоритм AES");
            Console.WriteLine("2 - алгоритм RSA");
            Console.WriteLine("3 - алгоритм md5");

            string algorythmCode = Console.ReadLine();

            if (algorythmCode != "2")
            {
                Console.WriteLine("Пожалуйста, выберите режим");
                Console.WriteLine("1 - зашифровать данные файла");
                Console.WriteLine("2 - расшифровать данные файла");
                Console.WriteLine("3 - шифрование + расшифровка данных");
            }

            string mode = Console.ReadLine();

            switch (algorythmCode)
            {
                case "1":
                    switch (mode)
                    {
                        case "1":
                            Console.WriteLine("Пожалуйста введите пароль");
                            string password1 = Console.ReadLine();

                            //Берем текст из документа
                            Console.WriteLine("Текст файла:");
                            string plaintext1 = doc.ReadText();
                            doc.PrintText();
                            Console.WriteLine("");

                            Console.WriteLine("Ваш зашифрованный файл:");
                            string encryptedstring1 = AES.Encrypt(plaintext1, password1);
                            doc.ChangeText(encryptedstring1);
                            doc.PrintText();
                            Console.WriteLine("");

                            break;

                        case "2":

                            Console.WriteLine("Пожалуйста введите пароль");
                            string password2 = Console.ReadLine();

                            //Берем текст из документа
                            Console.WriteLine("Ваш зашифрованный файл:");
                            string plaintext2 = doc.ReadText();
                            doc.PrintText();
                            Console.WriteLine("");

                            Console.WriteLine("Ваш расшифрованный файл:");
                            string codedText2 = doc.ReadText();
                            string decryptedstring2 = AES.Decrypt(codedText2, password2);
                            doc.ChangeText(decryptedstring2);
                            doc.PrintText();
                            Console.WriteLine("");

                            break;

                        case "3":

                            Console.WriteLine("Пожалуйста введите пароль");
                            string password3 = Console.ReadLine();

                            //Берем текст из документа
                            Console.WriteLine("Текст файла:");
                            string plaintext3 = doc.ReadText();
                            doc.PrintText();
                            Console.WriteLine("");

                            Console.WriteLine("Ваш зашифрованный файл:");

                            Stopwatch sw = Stopwatch.StartNew();
                            string encryptedstring3 = AES.Encrypt(plaintext3, password3);
                            sw.Stop();
                            Console.WriteLine("Время кодирования: {0}ms", sw.Elapsed.TotalMilliseconds);

                            doc.ChangeText(encryptedstring3);
                            doc.PrintText();
                            Console.WriteLine("");


                            Console.WriteLine("Ваш расшифрованный файл:");
                            string codedText3 = doc.ReadText();

                            Stopwatch sw1 = Stopwatch.StartNew();
                            string decryptedstring3 = AES.Decrypt(codedText3, password3);
                            sw1.Stop();
                            Console.WriteLine("Время декодирования: {0}ms", sw1.Elapsed.TotalMilliseconds);

                            doc.ChangeText(decryptedstring3);
                            doc.PrintText();
                            Console.WriteLine("");

                            break;
                    }
                    break;

                case "2":

                    Console.WriteLine("Текст файла:");
                    string plaintext = doc.ReadText();
                    doc.PrintText();
                    Console.WriteLine("");
                    UTF8Encoding ByteConverter = new UTF8Encoding();

                    byte[] dataToEncrypt = ByteConverter.GetBytes(plaintext);
                    byte[] encryptedData;
                    byte[] decryptedData;

                    //Create a new instance of RSACryptoServiceProvider to generate
                    //public and private key data.
                    using (RSACryptoServiceProvider RSA1 = new RSACryptoServiceProvider())
                    {

                        //Pass the data to ENCRYPT, the public key information 
                        //(using RSACryptoServiceProvider.ExportParameters(false),
                        //and a boolean flag specifying no OAEP padding
                        Stopwatch sw = Stopwatch.StartNew();
                        encryptedData = RSA.RSAEncrypt(dataToEncrypt, RSA1.ExportParameters(false), false);
                        sw.Stop();
                        Console.WriteLine("Время кодирования: {0}ms", sw.Elapsed.TotalMilliseconds);

                        Console.WriteLine("Ваш зашифрованный файл:");
                        string utf8encryptedtext = ByteConverter.GetString(encryptedData);
                        doc.ChangeText(utf8encryptedtext);
                        doc.PrintText();
                        Console.WriteLine("");

                        //Pass the data to DECRYPT, the private key information 
                        //(using RSACryptoServiceProvider.ExportParameters(true),
                        //and a boolean flag specifying no OAEP padding.
                        Stopwatch sw1 = Stopwatch.StartNew();
                        decryptedData = RSA.RSADecrypt(encryptedData, RSA1.ExportParameters(true), false);
                        sw1.Stop();
                        Console.WriteLine("Время декодирования: {0}ms", sw1.Elapsed.TotalMilliseconds);

                        Console.WriteLine("Ваш расшифрованный файл:");
                        doc.ChangeText(ByteConverter.GetString(decryptedData));
                        doc.PrintText();
                        Console.WriteLine("");
                    }

                    break;

                case "3":
                    switch (mode)
                    {
                        case "1":
                            Console.WriteLine("Пожалуйста введите пароль");
                            string password1 = Console.ReadLine();

                            //Берем текст из документа
                            Console.WriteLine("Текст файла:");
                            string plaintext1 = doc.ReadText();
                            doc.PrintText();
                            Console.WriteLine("");

                            Console.WriteLine("Ваш зашифрованный файл:");
                            string encryptedstring1 = HashEncryption.Encrypt(plaintext1, password1);
                            doc.ChangeText(encryptedstring1);
                            doc.PrintText();
                            Console.WriteLine("");

                            break;

                        case "2":

                            Console.WriteLine("Пожалуйста введите пароль");
                            string password2 = Console.ReadLine();
                            //Берем текст из документа
                            Console.WriteLine("Ваш зашифрованный файл:");
                            string plaintext2 = doc.ReadText();
                            doc.PrintText();
                            Console.WriteLine("");

                            Console.WriteLine("Ваш расшифрованный файл:");
                            string codedText2 = doc.ReadText();
                            string decryptedstring2 = HashEncryption.Decrypt(codedText2, password2);
                            doc.ChangeText(decryptedstring2);
                            doc.PrintText();
                            Console.WriteLine("");

                            break;

                        case "3":

                            Console.WriteLine("Пожалуйста введите пароль");
                            string password3 = Console.ReadLine();

                            //Берем текст из документа
                            Console.WriteLine("Текст файла:");
                            string plaintext3 = doc.ReadText();
                            doc.PrintText();
                            Console.WriteLine("");

                            Console.WriteLine("Ваш зашифрованный файл:");

                            Stopwatch sw = Stopwatch.StartNew();
                            string encryptedstring3 = HashEncryption.Encrypt(plaintext3, password3);
                            sw.Stop();
                            Console.WriteLine("Время кодирования: {0}ms", sw.Elapsed.TotalMilliseconds);

                            doc.ChangeText(encryptedstring3);
                            doc.PrintText();
                            Console.WriteLine("");

                            Console.WriteLine("Ваш расшифрованный файл:");
                            string codedText3 = doc.ReadText();

                            Stopwatch sw1 = Stopwatch.StartNew();
                            string decryptedstring3 = HashEncryption.Decrypt(codedText3, password3);
                            sw1.Stop();
                            Console.WriteLine("Время декодирования: {0}ms", sw1.Elapsed.TotalMilliseconds);

                            doc.ChangeText(decryptedstring3);
                            doc.PrintText();
                            Console.WriteLine("");

                            break;
                    }
                    break;
            }

            doc.DocClose(path);
            Console.WriteLine("Нажмите любую клавишу для выхода ...");
            Console.ReadLine();
        }
    }
}
