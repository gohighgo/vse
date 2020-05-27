using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace vce
{
    public struct Question
    {
       public string QuestionToAnswer { get; set; }
       public string False1Answer { get; set; }
        public string False2Answer { get; set; }
        public  string CorrectAnswer { get; set; }
        public Question(string q, string a1, string a2, string trueA)
        {
            QuestionToAnswer = q;
            False1Answer = a1;
            False2Answer = a2;
            CorrectAnswer = trueA;
        }
    }
    public class VceTest
    {
        string ExamName;
        public static int testlength { get; set; }
        public Question[] qtest = new Question[testlength];
        public VceTest()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("C:/Users/Admin/source/repos/vce/vce/XMLMaybeTest.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                // получаем атрибут name
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("testlength");
                    if (attr != null)
                        testlength = Convert.ToInt32(attr.Value);
                }
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("examname");
                    if (attr != null)
                        ExamName =attr.Value;
                }
                for (int i = 0; i < testlength; i++)
                {

                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        XmlNode attr = xnode.Attributes.GetNamedItem("quest");
                        if (attr != null && Convert.ToInt32(attr.Value) == i)
                            if (childnode.Name == "question")
                            {
                                qtest[i].QuestionToAnswer = childnode.InnerText;
                            }
                        // если узел age
                        if (childnode.Name == "falseanswer1")
                        {
                            qtest[i].False1Answer = childnode.InnerText;
                        }
                        if (childnode.Name == "falseanswer2")
                        {
                            qtest[i].False2Answer = childnode.InnerText;
                        }

                    }
                }
            }

        }
    }
}
