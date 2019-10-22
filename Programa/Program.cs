using System;
using System.Collections.Generic;
using Modelo;
using System.Linq;
using System.Text;

namespace Programa
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Equipo> equipos = LigaDAO.Instance.Equipos;
            List<Jugador> jugadores = LigaDAO.Instance.Jugadores;
            List<Partido> partidos = LigaDAO.Instance.Partidos;

            //exercici 01- Calentando motores
            Console.WriteLine("Equipos: ");
            equipos.ForEach(Console.WriteLine);

            Console.WriteLine("\nJugadores: ");
            jugadores.ForEach(Console.WriteLine);

            Console.WriteLine("\nPartidos: ");
            partidos.ForEach(Console.WriteLine);

            //Exercici 02- A por el Mago
            //Jugadores del Regal Barcelona
            Console.WriteLine("\n\nJugadores del Regal Barcelona");
            equipos.Where((e) => e.Nombre == "Regal Barcelona").First().Jugadores.
                OrderBy((e) => e.FechaAlta).ToList().ForEach(Console.WriteLine);

            //Ordena por apellidos
            Console.WriteLine("\n\nOrdena apellidos jugador Gran Canaria");
            equipos.Where((e) => e.Nombre == "Gran Canaria").First().Jugadores
                .OrderBy((e) => e.Apellido).ToList().ForEach(Console.WriteLine);

            //Nombre jugador 
            Console.WriteLine("\n\nJugador mas alto");
            Jugador jugadorMasAlto = jugadores.OrderByDescending((e) => e.Altura).First();
            Console.WriteLine("Nombre: " + jugadorMasAlto.Nombre + jugadorMasAlto.Apellido + " Equipo: "
                + jugadorMasAlto.Equipo.Nombre);

            //Pivots
            Console.WriteLine("\n\nPivots:");
            jugadores.Where((e) => e.Posicion == "Pivot").ToList()
                .ForEach(Console.WriteLine);

            //Ejercicio 3- El castillo y el rei

            // equipo que tiene el jugador que mas cobra
            Console.WriteLine("\n\nEquipo con el jugador más caro");
            Console.WriteLine(jugadores.OrderByDescending((e) => e.Salario).First().Equipo.Nombre);

            //jugadores de mas de 2 metros
            Console.WriteLine("\n\nJugadores mas de dos metros");
            jugadores.Where((e) => e.Altura > 2).ToList().ForEach(Console.WriteLine);

            //jugadores capitanes
            Console.WriteLine("\n\nCpitanes");
            jugadores.Where((e) => e.Capitan != null && e.Capitan.Id == e.Id)
                .ToList().ForEach(Console.WriteLine);


            //Ejercicio 4- Por la princesa lo que sea!!

            //Lista de Strings
            Console.WriteLine("\n\nLista jugadores");
            List<string> listaJugadores = new List<string>();
            jugadores.ForEach((e) => listaJugadores.Add("Nombre: " + e.Nombre + e.Apellido 
                + " Equipo: " + e.Equipo.Nombre));
            listaJugadores.ForEach(Console.WriteLine);

            //Equipo que mas partidos ha ganado
            Console.WriteLine("\n\nEquipo que más partidos ha ganado");
            Dictionary <Equipo, int> mapaVictorias = new Dictionary<Equipo, int>();
            partidos.ForEach((e) => 
            {
                String[] resultados = e.Resultado.Split("-");
                if (Int32.Parse(resultados[0]) > Int32.Parse(resultados[1]))
                {
                    try
                    {
                        mapaVictorias.Add(e.Local, 1);
                    }
                    catch (ArgumentException)
                    {
                        mapaVictorias.ToDictionary(x => x.Key, y => y.Value + 1);
                    }
                }
                else if (Int32.Parse(resultados[0]) < Int32.Parse(resultados[1]))
                {
                    try
                    {
                        mapaVictorias.Add(e.Visitante, 1);
                    }
                    catch (ArgumentException)
                    {
                        mapaVictorias.ToDictionary(x => x.Key, y => y.Value + 1);
                    }
                }
            });
            int max = mapaVictorias.Max((e) => e.Value);
            Console.WriteLine(mapaVictorias.Where((e) => e.Value == max).Select((e) => e.Key).First().ToString());

            //Ejercicio 5 A matar al Dragon con la espada XML bendecida por la princesa Alexa




            Console.ReadLine();

        }
    }
}
