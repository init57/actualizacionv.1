using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opciones;
            Console.Clear();
            do
            {
                Console.WriteLine($"\n");
                Console.WriteLine(" Menú de opciones   ");
                Console.WriteLine(" 1.registrar alumnos");
                Console.WriteLine(" 2.mostrar lista de alumnos ");
                Console.WriteLine(" 3.alumnos registrados");              
                Console.WriteLine(" 4.ordenar codigos");
                Console.WriteLine(" 5.ordenar alumnos");
                Console.WriteLine(" 6.busqueda por codigo");
                Console.WriteLine(" 7.busqueda por nombre");
                Console.WriteLine("     5.salir   ");

                opciones = int.Parse(Console.ReadLine());
                switch (opciones)
                {
                    case 1:
                        Opciones.registrate();
                        break;
                    case 2:
                        Opciones.Mostrar();
                        break;
                    case 3:
                        Opciones.ContarAlumno();
                        break;
                    case 4:
                        Opciones.OrdenarPorInsercionCodigo();                      
                        break;
                    case 5:
                        Opciones.OrdenarPorSeleccionNombre();
                        break;
                    case 6:

                            Console.WriteLine("Ingrese el código a buscar (ej: N1234P):");
                            string codigobuscado = Console.ReadLine();

                            int resultado =
                                Opciones.buscarCodigo(codigobuscado);

                            if (resultado != -1)
                            {
                                Console.WriteLine(
                                $"El código {codigobuscado} se encuentra en la posición {resultado}.");
                            }
                            else
                            {
                                Console.WriteLine(
                                $"El código {codigobuscado} no se encontró en la lista.");
                            }

                            break;
                    case 7:

                        Console.WriteLine("Ingrese nombre a buscar:");
                        string nombreBuscado = Console.ReadLine();

                        int result =
                            Opciones.BuscarNombreBinario(nombreBuscado);

                        if (result != -1)
                        {
                            Console.WriteLine(
                            $"El alumno {nombreBuscado} se encuentra en la posición {result}.");
                        }
                        else
                        {
                            Console.WriteLine(
                            $"El alumno {nombreBuscado} no se encontró.");
                        }

                        break;

                }
            } while (opciones != 8);

        }

    }
}
