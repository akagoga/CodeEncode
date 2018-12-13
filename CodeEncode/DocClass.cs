using System;
using Word = Microsoft.Office.Interop.Word;

namespace CodeEncode
{
    class DocClass
    {

        public Word.Application app;

        public Word.Document doc;

        public Word.Range wordrange;

        public DocClass()
        {
            doc = null;
            wordrange = null;
        }

        /**
         * Метод открытия файла
         */
        public void DocOpen(string source)
        {
            app = new Word.Application
            {
                UserName = "Система нормоконтроля"
            };
            doc = app.Documents.Open(source);
            doc.Activate();
        }
        /**
         * Метод закрытия файла
         */
        public void DocClose(string source)
        {
            doc.Close();
            doc = null;
            app.Quit();
            app = null;
        }






        /**
         * Метод возвращает текст документа
         */
        public string ReadText()
        {
            string text = "";
            object start = doc.Content.Start;
            object end = doc.Content.End;
            text = doc.Range(ref start, ref end).Text;
            return text;
        }

        /**
         * Метод изменяет текст документа
         */
        public void ChangeText(string newText)
        {
            object start = doc.Content.Start;
            object end = doc.Content.End;
            doc.Range(ref start, ref end).Text = newText;
        }



        /**
         * Метод выводит на экран текст
         */
        public void PrintText()
        {
            for (int i = 1; i <= doc.Paragraphs.Count; i++)
            {
                string parText = doc.Paragraphs[i].Range.Text;
                Console.WriteLine(parText);
            }
        }
    }
}
