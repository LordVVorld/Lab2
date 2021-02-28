using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;
using System.Security.Principal;
using System.IO;

namespace Лаб2
{
    class Programm
    {
        static void Main(string[] args)
        {
            Document.Instance.DataСollection();
            Document.Instance.DataOutput();
            Console.ReadKey();
        }
    }

    public class Document
    {
        private static Document instance;
        public string name, author, keyWords, theme, adress;
        public Document()
        { }

        public static Document Instance
        {
            get
            {
                if (instance == null) instance = new Document();
                return instance;
            }
        }

        public virtual void DataСollection()
        {
            Console.WriteLine("Введите тему документа: ");
            theme = Console.ReadLine();
            Console.WriteLine("Введите ключевые слова документа: ");
            keyWords = Console.ReadLine();
            Console.WriteLine("Введите путь к документу: ");
            adress = Console.ReadLine();
            FileInfo fileInfo = new FileInfo(adress);
            FileSecurity fileSecurity = fileInfo.GetAccessControl();
            IdentityReference identityReference = fileSecurity.GetOwner(typeof(NTAccount));
            author = identityReference.Value;
            name = Path.GetFileName(adress);
        }

        public virtual void DataOutput()
        {
            Console.WriteLine("Имя документа: " + name);
            Console.WriteLine("Автор документа: " + author);
            Console.WriteLine("Ключевые слова документа: " + keyWords);
            Console.WriteLine("Тема документа: " + theme);
            Console.WriteLine("Путь к документу: " + adress);
        }
    }

    public class MSWord: Document
    {
        public MSWord()
        { }
        public override void DataСollection()
        {
            keyWords = Console.ReadLine();
            theme = Console.ReadLine();
            adress = Console.ReadLine();
            FileInfo fileInfo = new FileInfo(adress);
            FileSecurity fileSecurity = fileInfo.GetAccessControl();
            IdentityReference identityReference = fileSecurity.GetOwner(typeof(NTAccount));
            author = identityReference.Value;
            name = Path.GetFileName(adress);
        }
    }
    public class PDF: Document
    {
        private PDF()
        { }
    }
    public class MSExcel: Document
    {
        private MSExcel()
        { }
    }
    public class TXT : Document
    {
        private TXT()
        { }
    }
    public class HTML : Document
    {
        private HTML()
        { }
    }
}
