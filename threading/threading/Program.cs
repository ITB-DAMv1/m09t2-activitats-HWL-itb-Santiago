using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace threading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Mostrar el menú principal
            while (true)
            {
                Console.Clear();
                Console.WriteLine("****************************");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Ver procesos en ejecución");
                Console.WriteLine("2. Ver los hilos de un proceso");
                Console.WriteLine("3. Carrera de camellos");
                Console.WriteLine("4. Salir");
                Console.WriteLine("****************************");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ShowProcesses();
                        break;
                    case "2":
                        ShowProcessThreads();
                        break;
                    case "3":
                        CamelRace();
                        break;
                    case "4":
                        Console.WriteLine("¡Adiós!");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para intentar nuevamente.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Muestra los procesos en ejecución
        public static void ShowProcesses()
        {
            string path = @"..\..\..\Process.txt";
            Process[] currentProcesses = Process.GetProcesses();
            Console.WriteLine("Procesos actuales\n========================================");
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (Process process in currentProcesses)
                {
                    string name = process.ProcessName;
                    int pid = process.Id;
                    Console.WriteLine($"{name,-40} {pid}");
                    sw.WriteLine($"{name,-40} {pid}");
                }
            }
            Console.WriteLine("========================================");
            Console.WriteLine("Procesos guardados en Process.txt");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // Muestra los hilos de un proceso específico
        public static void ShowProcessThreads()
        {
            Console.WriteLine("Ingrese el PID del proceso que desee: ");
            int programPID = int.Parse(Console.ReadLine());

            try
            {
                Process currentProcess = Process.GetProcessById(programPID);
                if (currentProcess != null)
                {
                    ProcessThreadCollection threads = currentProcess.Threads;
                    Console.WriteLine($"Cantidad de hilos : {threads.Count}");
                    foreach (ProcessThread thread in threads)
                    {
                        Console.WriteLine($"ID: {thread.Id} - Inicio: {thread.StartTime} - Prioridad: {thread.CurrentPriority}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // Simula la carrera de camellos
        public static void CamelRace()
        {
            Thread[] threads = new Thread[5];
            List<string> winList = new List<string>();
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                int camellNumber = i + 1;
                int minPause = random.Next(500, 1500);
                int maxPause = random.Next(1500, 3000);
                threads[i] = new Thread(() => CamelCount(camellNumber, minPause, maxPause, winList));
            }

            foreach (Thread thread in threads)
            {
                thread.Start();
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            // Mostrar los ganadores de la carrera
            Console.WriteLine("\nGuanyadors de la carrera:");
            foreach (var winner in winList)
            {
                Console.WriteLine(winner);
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // Función para simular la carrera de camellos
        public static void CamelCount(int camellNumber, int minPause, int maxPause, List<string> winList)
        {
            Random random = new Random();
            for (int i = 0; i < 101; i++)
            {
                int camellCount = i;
                int randomRest = random.Next(minPause, maxPause);
                Console.WriteLine($"Camell #{camellNumber} - Ha llegado al {camellCount}%");
                Thread.Sleep(randomRest);

                if (camellCount == 100)
                {
                    lock (winList)
                    {
                        winList.Add($"Camell #{camellNumber}! - Position {winList.Count + 1}");
                    }
                }
            }
        }
    }
}
