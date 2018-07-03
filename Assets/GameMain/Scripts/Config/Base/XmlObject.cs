using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Reflection;
#if UNITY_EDITOR
using UnityEditor;
#endif


namespace GameMain
{
    public enum DataKeyType
    {
        Id,
        Instance,
        Pos
    }

    [Serializable]
    public abstract class XmlObject
    {
        public const string ROOTNAME = "RECORDS";
        public const string ELEMNAME = "RECORD";
        public const string NODENAME = "Item";
        public const string TYPENAME = "Type";
        public const string KEYNAME = "Key";

        public abstract void Write(TextWriter os);

        public abstract void Read(XmlNode os);

        public static string ReadAttribute(XmlNode node, string attribute)
        {
            try
            {
                if (node != null && node.Attributes != null && node.Attributes[attribute] != null)
                {
                    return node.Attributes[attribute].Value;
                }
            }
            catch (Exception innerException)
            {
                throw new Exception(string.Format("attribute:{0} not exist", attribute), innerException);
            }
            return string.Empty;
        }

        public static string GetKey(XmlNode parent)
        {
            return ReadAttribute(parent, KEYNAME);
        }

        public static List<XmlNode> GetChilds(XmlNode parent)
        {
            List<XmlNode> list = new List<XmlNode>();
            if (parent != null)
            {
                list.AddRange(
                    from XmlNode sub in parent.ChildNodes
                    where sub.NodeType == XmlNodeType.Element
                    select sub);
            }
            return list;
        }

        public static string ReadContent(XmlNode node)
        {
            return node.InnerText;
        }

        public static bool ReadBool(XmlNode node)
        {
            string text = XmlObject.ReadContent(node).ToLower();
            if (text == "true")
            {
                return true;
            }
            if (text == "false")
            {
                return false;
            }
            return false;
        }

        public static int ReadInt(XmlNode node)
        {
            return int.Parse(node.InnerText);
        }

        public static long ReadLong(XmlNode node)
        {
            return long.Parse(node.InnerText);
        }

        public static float ReadFloat(XmlNode node)
        {
            return float.Parse(node.InnerText);
        }

        public static string ReadString(XmlNode node)
        {
            return node.InnerText;
        }

        public static Vector3 ReadVector3(XmlNode node)
        {
            return GlobalTools.ToVector3(node.InnerText, true);
        }

        public static T ReadObject<T>(XmlNode node) where T : XmlObject
        {
            string fullTypeName = typeof (T).ToString();
            try
            {
                Type classType = Type.GetType(fullTypeName, true);
                object v = Activator.CreateInstance(classType);
                T result = (T) v;
                result.Read(node);
                return result;
            }
            catch
            {
                Debug.LogError("XmlElement is null:" + fullTypeName);
                return null;
            }
        }

        public static T ReadDynamicObject<T>(XmlNode node) where T : XmlObject
        {
            string typeName = XmlObject.ReadAttribute(node, TYPENAME);
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }
            string fullTypeName = typeof (T).Namespace + "." + typeName;
            try
            {
                Type classType = Type.GetType(fullTypeName, true);
                object v = Activator.CreateInstance(classType);
                T result = (T) v;
                result.Read(node);
                return result;
            }
            catch
            {
                Debug.LogError("XmlElement is null:" + fullTypeName);
                return null;
            }
        }

        public static void WriteDynamicObject(TextWriter os, string name, XmlObject x)
        {
            os.WriteLine("<{0} {1}=\"{2}\">", name, TYPENAME, x.GetType().ToString());
            x.Write(os);
            os.WriteLine("</{0}>", name);
        }

        public static void WriteDynamicObject<T>(TextWriter os, string name, List<T> x) where T : XmlObject
        {
            os.WriteLine("<{0}>", name);
            x.ForEach(delegate(T v)
            {
                XmlObject.WriteDynamicObject(os, NODENAME, v);
            });
            os.WriteLine("</{0}>", name);
        }

        public static void Write(TextWriter os, string name, bool x)
        {
            os.WriteLine("<{0}>{1}</{0}>", name, x);
        }

        public static void Write(TextWriter os, string name, int x)
        {
            os.WriteLine("<{0}>{1}</{0}>", name, x);
        }

        public static void Write(TextWriter os, string name, long x)
        {
            os.WriteLine("<{0}>{1}</{0}>", name, x);
        }

        public static void Write(TextWriter os, string name, float x)
        {
            os.WriteLine("<{0}>{1}</{0}>", name, x);
        }

        public static void Write(TextWriter os, string name, string x)
        {
            os.WriteLine("<{0}>{1}</{0}>", name, new XText(x).ToString());
        }

        public static void Write(TextWriter os, string name, Vector3 x)
        {
            string s = GlobalTools.Format("({0},{1},{2})", x.x.ToString("0.00"), x.y.ToString("0.00"), x.z.ToString("0.00"));
            os.WriteLine("<{0}>{1}</{0}>", name, s);
        }

        public static void Write(TextWriter os, string name, XmlObject x)
        {
            if (x == null)
            {
                return;
            }
            os.WriteLine("<{0} Type=\"{1}\">", name, x.GetType().Name);
            x.Write(os);
            os.WriteLine("</{0}>", name);
        }

        public static void Write<V>(TextWriter os, string name, List<V> x)
        {
            if (x.Count == 0)
            {
                return;
            }
            os.WriteLine("<{0}>", name);
            x.ForEach(delegate(V v)
            {
                XmlObject.Write(os, NODENAME, v);
            });
            os.WriteLine("</{0}>", name);
        }

        public static void Write<V>(TextWriter os, string name, HashSet<V> x)
        {
            os.WriteLine("<{0}>", name);
            foreach (V current in x)
            {
                XmlObject.Write(os, NODENAME, current);
            }
            os.WriteLine("</{0}>", name);
        }

        public static void Write<K, V>(TextWriter os, KeyValuePair<K, V> x)
        {
            string key = x.Key.ToString();
            if (x.Value is XmlObject)
            {
                XmlObject v = x.Value as XmlObject;
                string pName = x.GetType().Name;
                os.WriteLine("<{0}  {1}=\"{2}\">", pName, KEYNAME, key);
                v.Write(os);
                os.WriteLine("</{0}>", pName);
            }
            else
            {
                os.WriteLine("<{0}  {1}=\"{2}\">{3}</{0}>", NODENAME, KEYNAME, key, x.Value);
            }
        }

        public static void Write<K, V>(TextWriter os, string name, Dictionary<K, V> x)
        {
            os.WriteLine("<{0}>", name);
            foreach (KeyValuePair<K, V> current in x)
            {
                Write(os, current);
            }
            os.WriteLine("</{0}>", name);
        }

        public static void Write(TextWriter os, string name, object x)
        {
            if (x == null)
            {
                return;
            }
            if (x is bool)
            {
                XmlObject.Write(os, name, (bool) x);
            }
            else
            {
                if (x is int)
                {
                    XmlObject.Write(os, name, (int) x);
                }
                else
                {
                    if (x is long)
                    {
                        XmlObject.Write(os, name, (long) x);
                    }
                    else
                    {
                        if (x is float)
                        {
                            XmlObject.Write(os, name, (float) x);
                        }
                        else
                        {
                            if (x is string)
                            {
                                XmlObject.Write(os, name, (string) x);
                            }
                            else
                            {
                                if (x is Vector3)
                                {
                                    XmlObject.Write(os, name, (Vector3) x);
                                }
                                else
                                {
                                    if (!(x is XmlObject))
                                    {
                                        throw new Exception("unknown marshal type;" + x.GetType());
                                    }
                                    XmlObject.Write(os, name, (XmlObject) x);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Load(string file)
        {
            XmlDocument xmlDocument = new XmlDocument();
            TextAsset pAsset = GameEntry.Resource.LoadAssetSync(file) as TextAsset;
            if (pAsset == null)
            {
                return;
            }
            xmlDocument.LoadXml(pAsset.text);
            this.Read(xmlDocument.DocumentElement);
            GameEntry.Resource.UnloadAsset(pAsset);
        }

        public void EditorLoad(string file)
        {
#if UNITY_EDITOR

            XmlDocument xmlDocument = new XmlDocument();
            TextAsset pAsset = AssetDatabase.LoadMainAssetAtPath(file) as TextAsset;
            if (pAsset == null)
            {
                return;
            }
            xmlDocument.LoadXml(pAsset.text);
            this.Read(xmlDocument.DocumentElement);
            Resources.UnloadAsset(pAsset);
#endif
        }

        public void Save(string file)
        {
            StringWriter stringWriter = new StringWriter();
            XmlObject.Write(stringWriter, "Root", this);
            File.WriteAllText(file, stringWriter.ToString());
        }

        public static V LoadSingleConfig<V>(string file) where V : XmlObject
        {
            List<V> list = new List<V>();
            XmlObject.LoadConfig<V>(list, file);
            if (list.Count != 1)
            {
                throw new Exception(string.Format("SingleConfig type:{0} file:{1} size != 1", typeof (V).FullName, file));
            }
            return list[0];
        }

        public static void SaveSingleConfig<V>(V x, string file) where V : XmlObject
        {
            XmlObject.SaveConfig<V>(new List<V>
            {
                x
            }, file);
        }

        public static void LoadConfig<V>(List<V> x, string file) where V : XmlObject
        {
            XmlDocument xmlDocument = new XmlDocument();
            TextAsset pAsset = GameEntry.Resource.LoadAssetSync(file) as TextAsset;
            if (pAsset == null)
            {
                return;
            }
            xmlDocument.LoadXml(pAsset.text);
            foreach (XmlNode current in XmlObject.GetChilds(xmlDocument.DocumentElement))
            {
                V data = XmlObject.ReadObject<V>(current);
                x.Add(data);
            }
        }

        public static void SaveConfig<V>(List<V> x, string file) where V : XmlObject
        {
            StringWriter stringWriter = new StringWriter();
            XmlObject.Write<V>(stringWriter, "Root", x);
            File.WriteAllText(file, stringWriter.ToString());
        }

        public static void SaveConfig<K, V>(Dictionary<K, V> x, string file) where V : XmlObject
        {
            XmlObject.SaveConfig<V>(x.Values.ToList<V>(), file);
        }

        public static XmlDocument LoadDocument(string path)
        {
            return LoadDocument(path, ROOTNAME);
        }

        public static XmlDocument LoadDocument(string path, string rootElementName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(path))
            {
                xmlDoc.Load(path);
            }
            else
            {
                FileStream fs = File.Create(path);
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                XmlNode root = xmlDoc.CreateElement(rootElementName);
                xmlDoc.AppendChild(xmlDeclaration);
                xmlDoc.AppendChild(root);
                fs.Close();
                fs.Dispose();
                xmlDoc.Save(path);
            }
            return xmlDoc;
        }

        public static XmlNodeList GetXmlNodeList(string path)
        {
            XmlDocument xmlDoc = LoadDocument(path);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode(ROOTNAME).ChildNodes;
            return nodeList;
        }

        public static void Append(string path, int key, object obj, DataKeyType keyType)
        {
            XmlDocument xmlDoc = LoadDocument(path);
            FileStream fs = File.OpenRead(path);

            if (fs == null)
            {
                return;
            }

            XmlNode xmlNode = xmlDoc.SelectSingleNode(ROOTNAME);
            XmlElement em = xmlDoc.CreateElement(ELEMNAME);
            xmlNode.AppendChild(em);

            em.SetAttribute(keyType.ToString(), key.ToString());
            Save(em, obj);
            fs.Close();
            fs.Dispose();
            xmlDoc.Save(path);
        }

        public static void Update(string path, int key, object obj, DataKeyType keyType)
        {
            XmlDocument xmlDoc = LoadDocument(path);
            FileStream fs = File.OpenRead(path);
            if (fs == null)
            {
                return;
            }
            XmlNodeList xmlNodeList = xmlDoc.SelectSingleNode(ROOTNAME).ChildNodes;
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                XmlElement xe = xmlNodeList.Item(i) as XmlElement;
                if (xe == null)
                    continue;
                string id = xe.GetAttribute(keyType.ToString());
                if (id.ToInt32() == key)
                {
                    Save(xe, obj);
                    break;
                }
            }
            fs.Close();
            fs.Dispose();
            xmlDoc.Save(path);
        }

        public static void Delete(string path, int key, DataKeyType keyType)
        {
            XmlDocument xmlDoc = LoadDocument(path);
            FileStream fs = File.OpenRead(path);
            if (fs == null)
            {
                return;
            }
            XmlNodeList xmlNodeList = xmlDoc.SelectSingleNode(ROOTNAME).ChildNodes;
            XmlElement xe = null;
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                xe = xmlNodeList.Item(i) as XmlElement;
                if (xe == null)
                    continue;
                string id = xe.GetAttribute(keyType.ToString());
                if (int.Parse(id) == key)
                {
                    XmlNode node = xmlDoc.SelectSingleNode(ROOTNAME);
                    node.RemoveChild(xe);
                    break;
                }
            }
            fs.Close();
            fs.Dispose();
            xmlDoc.Save(path);
        }

        public static bool ClearAll(string path)
        {
            XmlDocument xmlDoc = LoadDocument(path);
            FileStream fs = File.OpenRead(path);
            if (fs == null)
            {
                return false;
            }
            XmlNode node = xmlDoc.SelectSingleNode(ROOTNAME);
            node.RemoveAll();
            fs.Close();
            fs.Dispose();
            xmlDoc.Save(path);
            return true;
        }

        public static void InsertAll<T>(string path, Dictionary<int, T> dict, DataKeyType keyType)
        {
            XmlDocument xmlDoc = LoadDocument(path);
            FileStream fs = File.OpenRead(path);
            if (fs == null) return;
            if (dict == null) return;
            XmlNode xmlNode = xmlDoc.SelectSingleNode(ROOTNAME);
            Dictionary<int, T>.Enumerator em = dict.GetEnumerator();
            while (em.MoveNext())
            {
                XmlElement xe = xmlDoc.CreateElement(ELEMNAME);
                xmlNode.AppendChild(xe);
                int key = em.Current.Key;
                T obj = em.Current.Value;
                xe.SetAttribute(keyType.ToString(), key.ToString());
                Save<T>(xe, obj);
            }
            em.Dispose();
            fs.Close();
            fs.Dispose();
            xmlDoc.Save(path);
        }

        public static void Save<T>(XmlElement xe, T obj)
        {
            if (xe == null || obj == null)
            {
                return;
            }
            FieldInfo[] fields = obj.GetType().GetFields();
            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo field = fields[i];
                string fieldName = field.Name;
                object val = field.GetValue(obj);
                string fieldValue = (val == null) ? string.Empty : val.ToString();
                xe.SetAttribute(fieldName, fieldValue);
            }
        }

        public static Int32 ReadInt32(XmlElement xe, string key)
        {
            if (xe == null)
            {
                return 0;
            }
            int v = 0;
            for (int i = 0; i < xe.Attributes.Count; i++)
            {
                string k = xe.Attributes[i].Name;
                XmlAttribute attr = xe.Attributes[i];
                if (attr.Name == key)
                {
                    int.TryParse(attr.Value, out v);
                    break;

                }
            }
            return v;
        }

        public static Vector3 ReadVector3(XmlElement xe, string key)
        {
            Vector3 v = Vector3.zero;
            if (xe == null)
            {
                return v;
            }
            for (int i = 0; i < xe.Attributes.Count; i++)
            {
                string k = xe.Attributes[i].Name;
                XmlAttribute attr = xe.Attributes[i];
                if (attr.Name == key)
                {
                    v = GlobalTools.ToVector3(attr.Value, true);
                    break;

                }
            }
            return v;
        }

        public static float ReadFloat(XmlElement xe, string key)
        {
            if (xe == null)
            {
                return 0;
            }
            float v = 0;
            for (int i = 0; i < xe.Attributes.Count; i++)
            {
                string k = xe.Attributes[i].Name;
                XmlAttribute attr = xe.Attributes[i];
                if (attr.Name == key)
                {
                    float.TryParse(attr.Value, out v);
                    break;

                }
            }
            return v;
        }
    }

}
