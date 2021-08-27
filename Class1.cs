using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Serialization
{
    class Program 
    {
        static void Main(string[] args)
        {
            Player p = new Player()
            {
                FirstName = "Coki",
                LastName = "Ciko",
                Level = "22",
                Score = "2089"
            };
            string filePath = "data.save";
            dataSerializer ds = new dataSerializer();
            Player player = null;

            ds.BinarySerialize(p, filePath);

            player = ds.BinaryDeserialize(filePath) as Player;

            Console.WriteLine(player.FirstName);
            Console.WriteLine(player.LastName);
            Console.WriteLine(player.Level);
            Console.WriteLine(player.Score);

            Console.ReadLine();
        }
    }

    [Serializable]
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Level { get; set; }
        public int Score { get; set; }
        public void Print()
        {
            Console.WriteLine("Player Data");
            Console.Write("Name : " + FirstName + LastName);
            Console.Write("Level : " + Level);
            Console.Write("Score : " + Score);
        }
    }

    class dataSerializer
    {
        public void BinarySerialize(object data, string filePath)
        {
            FileStream fileS;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath)) File.Delete(filePath);
            fileS = File.Create(filePath);
            bf.Serialize(fileS, data);
            fileS.Close();
            Console.WriteLine("Serialize is success");
        }

        public object BinaryDeserialize(string filePath)
        {
            object obj = null;

            FileStream fileS;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                fileS = File.OpenRead(filePath);
                obj = bf.Deserialize(fileS);
                fileS.Close();
            }
            //Console.WriteLine(" " + obj.FirstName );

        }
    }

}
