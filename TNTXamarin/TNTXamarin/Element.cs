using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNTXamarin
{
    class Element
    {
        public string Name { get; set;}

        public string Data { get; set; }

        public string Url { get; set; }

        public Element()
        {
            Name = "";
            Data = "";
            Url = "";
        }

        public List<string> processForImages()
        {
            List<string> images = new List<string>();
            int i = 0;
            while (true)
            {
                i = Data.IndexOf("<img", i);
                if (i < Data.Length && i != -1)
                {
                    i = Data.IndexOf("src=\"",i);
                    if (i < Data.Length)
                    {
                        int end = Data.IndexOf("\"", (i + 5));
                        images.Add(Data.Substring((i + 5), (end- (i + 5))));
                    }
                }
                else
                {
                    break;
                }
            }
            return images;
        }

    }
}
