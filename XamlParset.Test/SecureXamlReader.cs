using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xaml;
using System.Xml;

namespace XamlParser.Test
{
    public class SecureXamlReader
    {
        public SecureXamlReader()
        {
        }

        public static object Parse(string xaml)
        {
            using var stringReader = new StringReader(xaml);
            using var xmlReader = XmlReader.Create(stringReader, new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Prohibit,
                XmlResolver = null, 
                MaxCharactersFromEntities = 0,
                MaxCharactersInDocument = 100000
            });

            var context = new XamlSchemaContext();
            var xamlReader = new XamlXmlReader(xmlReader, context);
            var writer = new XamlObjectWriter(context);

            while (xamlReader.Read())
            {
                if (ShouldFilterNode(xamlReader.NodeType, xamlReader))
                {
                    MessageBox.Show("Dangerous type detected!");
                    return null;
                }

                writer.WriteNode(xamlReader);
            }

            return writer.Result;
        }

        private static bool ShouldFilterNode(XamlNodeType nodeType, XamlReader reader)
        {
            return
                nodeType == XamlNodeType.StartObject &&
                reader.Type?.UnderlyingType is Type objType && IsDangerousType(objType);
        }

        private static bool IsDangerousType(Type type)
        {
            var dangerousTypes = new[]
            {
                typeof(System.Windows.Data.ObjectDataProvider)
            };

            return dangerousTypes.Any(dangerous =>
                dangerous.IsAssignableFrom(type) || type.IsAssignableFrom(dangerous));
        }
    }
}
