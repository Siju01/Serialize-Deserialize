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
                Level = 22,
                Score = 2089,
                Coin = 28900
            };
            string filePath = "data.save";
            dataSerializer ds = new dataSerializer();
            Player player = null;

            ds.BinarySerialize(p, filePath);

            player = ds.BinaryDeserialize(filePath) as Player;

            Console.WriteLine("First Name : " + player.FirstName);
            Console.WriteLine("Last Name : " + player.LastName);
            Console.WriteLine("Level : " + player.Level);
            Console.WriteLine("Score : " + player.Score);
            Console.WriteLine("Coin : " + player.Coin);

            Console.ReadLine();
        }
    }

    [Serializable]
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Level { get; set; }
        public int Score { get; set; }
        public int Coin { get; set; }

        /*public void Print()
        {
            Console.WriteLine("Player Data");
            Console.Write("Name : " + FirstName + LastName);
            Console.Write("Level : " + Level);
            Console.Write("Score : " + Score);
        }*/
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

            return (obj);
        }
    }

}
