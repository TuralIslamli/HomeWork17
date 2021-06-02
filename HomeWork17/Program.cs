using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork17
{

        class Client
        {
            private string passportNumber;
            private int id;
            private double payment;
            
            public string Passportnumber
            {
                get { return passportNumber; }
                set { passportNumber = value; }
            }
            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            public double Payment
            {
                get { return payment; }
                set { payment = value; }
            }
           public Client(int id, string passportNumber, double payment)
            {
                Id = id;
                Passportnumber = passportNumber;
                Payment = payment;
            }
            public void GetDisplay()
            {
                Console.WriteLine($"Id:{id}; Passportnumber:{passportNumber}; Payment:{payment}.");
            }
        }
    class Program
    {
        static void Main(string[] args)
        {
            string folder = @"C:\TuralFolder";
            List<Client> clientList = new List<Client>();
            clientList.Add(new Client(001, "AZE12345678", 22.30));
            clientList.Add(new Client(025, "AZE87652134", 50.00));
            clientList.Add(new Client(034, "AZE87652134", 12.35));
            DirectoryInfo test = new DirectoryInfo(folder);
            if (!test.Exists)
            {
                test.Create();
            }
            using (StreamWriter fileCreate = new StreamWriter($"{folder}/TuralFile.txt", false, System.Text.Encoding.Default))
            {
                fileCreate.WriteLine($"{clientList[0].Id}, {clientList[0].Passportnumber}, {clientList[0].Payment}\n{clientList[1].Id}, {clientList[1].Passportnumber}, {clientList[1].Payment},\n{clientList[2].Id}, {clientList[2].Passportnumber}, {clientList[2].Payment}");
            }
            using (StreamReader fileRead =new StreamReader($"{folder}/TuralFile.txt"))
            {
                Console.WriteLine(fileRead.ReadToEnd());
            }
                bool temp = true;
            while (temp)
            {
                Console.WriteLine("Укажите Id клиента, у которого хотите изменить сумму:");
                int userChoise = Num();
                for (int i = 0; i < clientList.Count; i++)
                {
                    if (clientList[i].Id == userChoise)
                    {
                        Console.WriteLine("Укажите новую сумму:");
                        int newPayment =Num();
                        clientList[i].Payment = newPayment;
                        temp = false;
                    }
                }
                if (temp==true)
                {
                    Console.WriteLine("Клиент с таким Id нет, укажите верно!");
                }
            }
            using (StreamWriter newFileCreate = new StreamWriter($"{folder}/NewTuralFile.txt", false, System.Text.Encoding.Default))
            {
                newFileCreate.WriteLine($"{clientList[0].Id}, {clientList[0].Passportnumber}, {clientList[0].Payment}\n{clientList[1].Id}, {clientList[1].Passportnumber}, {clientList[1].Payment},\n{clientList[2].Id}, {clientList[2].Passportnumber}, {clientList[2].Payment}");
            }
            using (StreamReader newFileRead = new StreamReader($"{folder}/NewTuralFile.txt"))
            {
                Console.WriteLine(newFileRead.ReadToEnd());
            }

            Console.ReadKey();
        }
        static int Num()
        {
            int num = 0;
            for (; ; )
            {
                string read1 = Console.ReadLine();

                int.TryParse(read1, out num);
                if (num < 0)
                {
                    Console.WriteLine("Не правильно, укажите правильную информацию.");
                }
                else
                {
                    break;
                }
            }
            return num;

        }
    }
}
