using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MotorsportCareer.Career
{
    public enum CareerGame
    {
        AssettoCorsa,
        Rfactor2,
        RichardBurnsRally,
        Rfactor
    }
    public class MCareer
    {
        private string CareerName;
        private string CareerId;
        private CareerGame CareerGame;
        private bool CompleteFlag;

        public MCareer(string name, CareerGame game)
        {
            this.CareerName = name;
            this.CareerGame = game;
            this.CareerId = GetHashString(CareerName + DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
            this.CompleteFlag = false;
            /*this.CompleteFlag = this.CheckProgress()*/;
        }

        public string GetCareerName()
        {
            return this.CareerName;
        }

        public CareerGame GetGame()
        {
            return this.CareerGame;
        }

        private bool CheckProgress()
        {
            
            return false;
        }
        
        private void LoadJsonFile()
        {
            string filename = String.Format("{0}-{1}.json");
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                List<string> items = JsonConvert.DeserializeObject<List<string>>(json);
                
            }
        }

        private static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        private static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

        
    }
}
