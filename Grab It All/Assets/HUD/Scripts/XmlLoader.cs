using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

public class XmlLoader : MonoBehaviour
{
    public TextAsset xmlRawFile;
    public List<Objetivos> ListaObjetivos = new List<Objetivos>();
    // Start is called before the first frame update
    void Start()
    {
        string data = xmlRawFile.text;
        parseXmlFile(data);
        printList();
    }

  void parseXmlFile(string xmlData)
    {
      
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(xmlData));

        string xmlPathPattern = "//Objetivos/Objetivo";
        XmlNodeList myNodeLists = xmlDoc.SelectNodes(xmlPathPattern);
        foreach(XmlNode node in myNodeLists)
        {
         
            XmlNode tipo = node.FirstChild;
            switch (tipo.InnerXml.ToString())
            {
                case "Dinero":
                
                    XmlNode Mensaje = tipo.NextSibling;
                    XmlNode Cantidad = Mensaje.NextSibling;
                    int i;
                    i = XmlConvert.ToInt32(Cantidad.InnerText);
                    ListaObjetivos.Add(new Dinero(i,tipo.InnerXml.ToString(),Mensaje.InnerXml.ToString()));
                    break;
                case "Posicion":
                 
                    Mensaje = tipo.NextSibling;
                    XmlNode minX = Mensaje.NextSibling;
                    XmlNode minZ = minX.NextSibling;
                    XmlNode maxX = minZ.NextSibling;
                    XmlNode maxZ = maxX.NextSibling;
                    int x, z, X, Z;
                    x = XmlConvert.ToInt32(minX.InnerText);
                    z = XmlConvert.ToInt32(minZ.InnerText);
                    X = XmlConvert.ToInt32(maxX.InnerText);
                    Z = XmlConvert.ToInt32(maxZ.InnerText);
                    ListaObjetivos.Add(new Posicion(x,X,z,Z, tipo.InnerXml.ToString(), Mensaje.InnerXml.ToString()));
                    break;
                case "Cantidad":
                    
                    Mensaje = tipo.NextSibling;
                    XmlNode id = Mensaje.NextSibling;
                    XmlNode cantidad = id.NextSibling;
                    int c;
                    i = XmlConvert.ToInt32(id.InnerText);
                    c = XmlConvert.ToInt32(cantidad.InnerText);
                    ListaObjetivos.Add(new Cantidad(i, c, tipo.InnerXml.ToString(), Mensaje.InnerXml.ToString()));
                    break;
                case "Clave":
                 
                    Mensaje = tipo.NextSibling;

                    id = Mensaje.NextSibling;
                    i = XmlConvert.ToInt32(id.InnerText);
                    ListaObjetivos.Add(new Clave(i, tipo.InnerXml.ToString(), Mensaje.InnerXml.ToString()));

                    break;
                case "Menus":

                    Mensaje = tipo.NextSibling;

                    XmlNode mensajeAdd = Mensaje.NextSibling;
                    XmlNode tipoInput = mensajeAdd.NextSibling;
                    ListaObjetivos.Add(new Menus(tipo.InnerXml.ToString(), Mensaje.InnerXml.ToString(), mensajeAdd.InnerXml.ToString(), tipoInput.InnerXml.ToString()));//string t, string m, string m2, string I

                    break;


            }
           
          
          
          
            
          
           
          
        }
    }

  void printList()
  {
       foreach(Objetivos t in ListaObjetivos)
        {
         
        }

  }
}
