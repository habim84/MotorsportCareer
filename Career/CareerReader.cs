using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportCareer.Career
{

    class CareerReader
    {
        private string filename;
        private string dirName;
        private DirectoryInfo directoryInfo;

        private class CareerSave
        {
            public List<SeriesNode> nodes;

            public CareerSave(List<SeriesNode> n)
            {
                this.nodes = n;
            }
        }

        public CareerReader(string filename)
        {
            this.filename = filename;
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.dirName = $@"{docPath}\MotorsportCareer";
            this.directoryInfo = Directory.CreateDirectory(this.dirName);
        }

        public CareerReader()
        {
            this.filename = "";
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.dirName = $@"{docPath}\MotorsportCareer";
            this.directoryInfo = Directory.CreateDirectory(this.dirName);
        }


        public void SaveCareer(List<SeriesNode> nodes)
        {
            CareerSave newSave = new CareerSave(nodes);
            string jsonString = JsonConvert.SerializeObject(newSave);
            File.WriteAllText($@"{this.directoryInfo.FullName}/{this.filename}.json", jsonString);
        }

        public List<SeriesNode> LoadCareer()
        {
            string jsonString = File.ReadAllText($@"{this.directoryInfo.FullName}/{this.filename}.json");
            JsonTextReader reader = new JsonTextReader(new StringReader(jsonString));
            List<SeriesNode> seriesNodes = new List<SeriesNode>();
            int[] checkFlag = { 0, 0, 0 };
            string[] currentNode = { "", "", "" };
            while(reader.Read())
            {
                if (reader.Value != null)
                {
                    if (reader.TokenType.Equals("PropertyName"))
                    {
                        if (reader.Value.Equals("SeriesName"))
                        {
                            checkFlag[0] = 1;
                            checkFlag[1] = 0;
                            checkFlag[2] = 0;
                        } else if (reader.Value.Equals("GameName"))
                        {
                            checkFlag[0] = 0;
                            checkFlag[1] = 1;
                            checkFlag[2] = 0;
                        } else if(reader.Value.Equals("LicenseName"))
                        {
                            checkFlag[0] = 0;
                            checkFlag[1] = 0;
                            checkFlag[2] = 1;
                        }
                    } else if (reader.TokenType.Equals("String"))
                    {
                        if (checkFlag.Contains(1))
                        {
                            currentNode[Array.IndexOf(checkFlag, 1)] = reader.Value.ToString();
                        }
                    }
                    
                } else
                {
                    if (reader.TokenType.Equals("EndObject") && checkFlag.Contains(1))
                    {
                        for (int i = 0; i < checkFlag.Length;i++)
                        {
                            checkFlag[i] = 0;
                        }
                        SeriesNode newNode = new SeriesNode(currentNode[0], currentNode[1], currentNode[2]);
                        seriesNodes.Add(newNode);
                    }
                }
            }
            return seriesNodes;
        }

    }
}
