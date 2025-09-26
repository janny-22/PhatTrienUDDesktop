using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace XMLCau2
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            using (XmlWriter  writer = XmlWriter.Create("books_1.xml")) 

            {
                String pi = "type=\"text/xsl\"href=\"books_1.xsl\"";
                writer.WriteProcessingInstruction("xml-stylesheet", pi);
                writer.WriteDocType("catalog", null, null, "<!ENTITY h\"hardcover\">");
                writer.WriteComment("This is a book sample XML");
                writer.WriteStartElement("book");
                writer.WriteAttributeString("ISBN", "9831123212");
                writer.WriteElementString("author", "Mahesh Chand");
                writer.WriteElementString("title", "Visual C# Programming");
                writer.WriteElementString("price", "44.95");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
            }
        }
        private static void SaveToXMLFile(List<Book> books)
        {
            var serializer = new XmlSerializer(typeof(List<Book>));
            using (var writer = new StreamWriter("book_1.xml"))
            {
                serializer.Serialize(writer, books,null);
                writer.Close();
            }
        }
    }
}
