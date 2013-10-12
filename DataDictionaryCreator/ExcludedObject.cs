using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.SqlServer.Management.Smo;

namespace DataDictionaryCreator
{
    public class ExcludedObjectList : List<ExcludedObject>
    {
        // empty--just needed to give a name to the List.        
    }

    [XmlRoot("ExcludedObject")]
    public class ExcludedObject
    {
        public ExcludedObject() { }
        public ExcludedObject(Table table) 
        { 
            Server = table.Parent.Parent.Name;
            Database = table.Parent.Name;
            Type = DatabaseObjectTypes.Table.ToString();
            Name = table.ToString();
        }

        [XmlAttribute("Server")]
        public string Server { get; set; }
        [XmlAttribute("Database")]
        public string Database { get; set; }
        [XmlAttribute("Type")]
        public string Type { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }


        public static bool operator ==(ExcludedObject obj1, ExcludedObject obj2)
        {
            return obj1.Server == obj2.Server && obj1.Database == obj2.Database && obj1.Type == obj2.Type && obj1.Name == obj2.Name;
        }

        public static bool operator !=(ExcludedObject obj1, ExcludedObject obj2)
        {
            return !(obj1 == obj2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ExcludedObject))
            {
                return false;
            }

            return this == (ExcludedObject)obj;
        }

        public override int GetHashCode()
        {
            //17 and 37 are arbitrary--37 is chosen because it is prime.
            //int result = 17;
            //result = 37 * result + Server.GetHashCode();
            //result = 37 * result + Database.GetHashCode();
            //result = 37 * result + Type.GetHashCode();
            //result = 37 * result + Name.GetHashCode();

            return Server.GetHashCode() ^ Database.GetHashCode() ^ Type.GetHashCode() ^ Name.GetHashCode();
        }
    }
}
