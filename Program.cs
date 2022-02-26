using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Expresiones_regulares
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Expresiones regulares");
            Console.WriteLine("Ingrese la clave: ");
            string CLAVE = Console.ReadLine();
            Console.WriteLine("Ingrese el texto: ");
            string TEXTO = Console.ReadLine();

            Regex buscador = new Regex(CLAVE);
            var match = buscador.Match(TEXTO);
            var match2 = buscador.Match(TEXTO);
            GroupCollection group = match.Groups;
            Console.WriteLine("\nCoincidencias:");
            List<posiciones> posicionesT = new List<posiciones>();
            List<posiciones> posicionesG = new List<posiciones>();
            Random r = new Random();
            int[] colores = { 1, 3, 8, 2, 5, 4, 6, 9, 13, 12 };
            int backC = r.Next(0, colores.Length), foreC = 14;
            //GUARDA E IMPRIME COINCIDENCIAS
            while (match.Success)
            {

                Console.WriteLine("{0} - {1} : {2}", TEXTO.Substring(match.Index, match.Length), match.Index + 1, match.Index + match.Length);
                posicionesT.Add(new posiciones() { INDEX = match.Index, LENGTH = match.Length });
                match = match.NextMatch();
            }
            for (int i = 0; i < TEXTO.Length; i++)
            {
                bool Validacion = false;
                if (!Validacion)
                {

                    foreach (var item in posicionesT)
                    {
                        if (item.INDEX == i)
                        {
                            Console.BackgroundColor = (ConsoleColor)colores[backC];
                            Console.ForegroundColor = (ConsoleColor)foreC;
                            Console.Write("{0}", TEXTO.Substring(item.INDEX, item.LENGTH));
                            i = i + item.LENGTH - 1;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Validacion = true;
                        }
                    }
                }
                else
                {

                }
                if (!Validacion)
                {
                    Console.Write("{0}", TEXTO.Substring(i, 1));
                }


            }
            //GUARDA E IMPRIME LOS GRUPOS
            Console.WriteLine("\n");
            Console.WriteLine("\nGrupos:");
            while (match2.Success)
            {
                backC = r.Next(0, colores.Length);
                for (int i = 1; i < 100; i++)
                {
                        Group g = match2.Groups[i];
                        CaptureCollection cc = g.Captures;
                        for (int j = 0; j < cc.Count; j++)
                        {
                            Capture c = cc[j];
                            posicionesG.Add(new posiciones() { INDEX = c.Index, LENGTH = c.Length, GRUPO = i });
                        Console.BackgroundColor = (ConsoleColor)colores[backC];
                        Console.ForegroundColor = (ConsoleColor)foreC;
                        if (cc.Count > 0)
                                Console.WriteLine("{0} - {1} : {2}", TEXTO.Substring(c.Index, c.Length), c.Index + 1, c.Index + c.Length);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }
               match2 = match2.NextMatch();
            }


            for (int i = 0; i < TEXTO.Length; i++)
            {
                bool Validacion = false;
                if (group.Count > 1)
                {
                    foreach (var gr in posicionesG)
                    {
                        if (gr.INDEX == i)
                        {
                            Console.BackgroundColor = (ConsoleColor)colores[gr.GRUPO];
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("{0}", TEXTO.Substring(gr.INDEX, gr.LENGTH));
                            i = i + gr.LENGTH - 1;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Validacion = true;
                        }
                    }
                }
                if (!Validacion)
                {
                    Console.Write("{0}", TEXTO.Substring(i, 1));
                }
            }
            Console.ReadLine();
        }
    }
    class posiciones
    {
        public int INDEX { get; set; }
        public int LENGTH { get; set; }
        public int GRUPO { get; set; }
    }
}
