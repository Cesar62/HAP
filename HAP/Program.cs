using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HAP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text;
            CrearToken crearToken = new CrearToken();
            while (true)
            {
                Console.Write("html a avalonia: ");
                text = Console.ReadLine() ?? "";
                
                crearToken.Detectar(text);
                crearToken.MostrarTokens();
                crearToken.LimpiaLista();
            }
        }
    }
}