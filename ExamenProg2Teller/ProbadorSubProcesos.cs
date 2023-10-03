using System;
using System.Threading;

namespace ExamenProg2Teller
{
    public class ProbadorSubProcesos
    {
        public static void Main()
        {
            // Creación de los 3 Sub Procesos
            Thread proc1 = new Thread(Proceso);
            Thread proc2 = new Thread(Proceso);
            Thread proc3 = new Thread(Proceso);

            // Comienzan los sub Procesos
            proc1.Start("Primer Proceso");
            proc2.Start("Segundo Proceso");
            proc3.Start("Tercer Proceso");

            // Ejecutar durante el tiempo determinado
            DateTime cronometro = DateTime.Now.AddSeconds(15);

            while(DateTime.Now < cronometro)
            {
                // Espera cada 7 segundos, es el intervalo
                Thread.Sleep(7000);
                VerEstado(proc1);
                VerEstado(proc2);
                VerEstado(proc3);
            }

            Console.WriteLine("Programación Finalizada.");
        }

        public static void VerEstado(Thread thread)
        {
            Console.WriteLine($"{DateTime.Now}: Estado de {thread.Name}: {thread.ThreadState}");
        }

        public static void Proceso(Object Nombre)
        {
            Random rand = new Random();
            while (true)
            {
                Console.WriteLine($"{DateTime.Now}: Estado de {Nombre} activado.");
                // Esperar entre uno y cinco segundos
                Thread.Sleep((int)rand.Next(1000,5000));
            }
        }
    }
}