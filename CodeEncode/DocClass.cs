using System;
using Word = Microsoft.Office.Interop.Word;

namespace ProjectWord
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
                UserName = "Система Шифрования"
            };
            doc = app.Documents.Open(source);
            doc.Activate();
        }
        /**
         * Метод закрытия файла
         */
        public void DocClose()
        {
            doc.Close();
            doc = null;
            Console.Read();
        }



       // object text = "Ошибка";
        /**
         * Метод создает примечание
         */
        public void AddComment(Word.Range Range, object text)
        {
            doc.Comments.Add(Range, ref text);
            Console.WriteLine("Все изменилось comments");
        }





        /**
         * Метод возвращает количество страниц
         */
        public int CountOfPages()
        {
            Word.WdStatistic stat = Word.WdStatistic.wdStatisticPages;
            int Count = doc.ComputeStatistics(stat, Type.Missing);
            return Count;
        }
        /**
         * Метод выводит на экран текст
         */
        public string ReadText()
        {
            string text = "";
            for (int i = 1; i < doc.Paragraphs.Count; i++)
            {
                string parText = doc.Paragraphs[i].Range.Text;
                text += parText;
            }
            return text;
        }
    }
}
