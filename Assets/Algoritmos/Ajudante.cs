using System.IO;
using System.Xml.Serialization;

public static class Ajudante {

    public static string Serializar<T> (this T paraSerializar) {
        XmlSerializer xml = new XmlSerializer (typeof (T));
        StringWriter escritor = new StringWriter ();
        xml.Serialize (escritor, paraSerializar);
        return escritor.ToString ();
    }

    public static T Desserializar<T> (this string paraDesserializar) {
        XmlSerializer xml = new XmlSerializer (typeof (T));
        StringReader leitor = new StringReader (paraDesserializar);
        return (T) xml.Deserialize (leitor);
    }

}