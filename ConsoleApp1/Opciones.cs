using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Opciones
    {
        public static ListaAlumnos cabezon = null;
        public static Random random = new Random();

        public static void registrate()
        {
            ListaAlumnos nuevo = new ListaAlumnos();
            Console.WriteLine($"\n Ingresa tus nombres y apellidos: ");
            nuevo.Nombres = Console.ReadLine();

            Console.WriteLine($"\nIngresa tu edad: ");
            nuevo.edad = int.Parse(Console.ReadLine());
            nuevo.Codigo = "N"+ random.Next(1000, 10000) + "P";


            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"\nNombre del curso {i + 1}: ");
                nuevo.notas[i, 0] = Console.ReadLine();

                int valor1 = -1;
                while (valor1 < 0 || valor1 > 20)
                {
                    Console.Write("Nota 1 (0-20): ");
                    string entrada = Console.ReadLine();
                    valor1 = int.Parse(entrada);

                    if (valor1 >= 0 && valor1 <= 20)
                    {
                        nuevo.notas[i, 1] = entrada;
                    }
                    else
                    {
                        Console.WriteLine("¡Error! La nota debe estar entre 0 y 20.");
                    }
                }

                int valor2 = -1;
                while (valor2 < 0 || valor2 > 20)
                {
                    Console.Write("Nota 2 (0-20): ");
                    string entrada = Console.ReadLine();
                    valor2 = int.Parse(entrada);

                    if (valor2 >= 0 && valor2 <= 20)
                    {
                        nuevo.notas[i, 2] = entrada;
                    }
                    else
                    {
                        Console.WriteLine("¡Error! La nota debe estar entre 0 y 20.");
                    }
                }
            }

            if (cabezon == null)
            {
                cabezon = nuevo;
            }
            else
            {
                ListaAlumnos temp = cabezon;
                while (temp.siguiente != null)
                {
                    temp = temp.siguiente;
                }
                temp.siguiente = nuevo;
            }
            Console.WriteLine("Alumno registrado con exito!!");


        }
        public static void Mostrar()
        {
            ListaAlumnos temp = cabezon;
            while (temp != null)
            {
                Console.WriteLine($"  Codigo:              {temp.Codigo}");
                Console.WriteLine($"  Nombres y Apellidos: {temp.Nombres}");
                Console.WriteLine($"  Edad:                {temp.edad}");
                Console.WriteLine($"  Correo:              {temp.Codigo}@upn.pe ");
                Console.WriteLine();
                Console.WriteLine("Cursos               Nota 1        Nota 2");
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine($"{temp.notas[i, 0],-20}\t{temp.notas[i, 1],-8}\t{temp.notas[i, 2],-8}");
                }
                temp = temp.siguiente;
            }
        }
        public static void ContarAlumno()
        {
            int contador = 0;
            ListaAlumnos temp = cabezon;
            while (temp != null)
            {
                contador++;
                temp = temp.siguiente;
            }
            Console.WriteLine(" Total de alumnos registrados:" + contador);
            Console.WriteLine();
        }
        public static void OrdenarPorSeleccionNombre()
        {
            if (cabezon == null)
                return;

            ListaAlumnos actual = cabezon;

            while (actual != null)
            {
                ListaAlumnos menor = actual;
                ListaAlumnos temp = actual.siguiente;

                // Buscar el menor nombre
                while (temp != null)
                {
                    if (string.Compare(
                        temp.Nombres,
                        menor.Nombres,
                        StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        menor = temp;
                    }

                    temp = temp.siguiente;
                }

                // Intercambiar datos entre nodos
                if (menor != actual)
                {
                    IntercambiarDatos(actual, menor);
                }

                actual = actual.siguiente;
            }

            Console.WriteLine("Lista ordenada por nombres (Selección).");
        }
        public static void IntercambiarDatos(ListaAlumnos a, ListaAlumnos b)
        {
            // Código
            string tempCodigo = a.Codigo;
            a.Codigo = b.Codigo;
            b.Codigo = tempCodigo;

            // Nombres
            string tempNombre = a.Nombres;
            a.Nombres = b.Nombres;
            b.Nombres = tempNombre;

            // Edad
            int tempEdad = a.edad;
            a.edad = b.edad;
            b.edad = tempEdad;

            // Notas
            string[,] tempNotas = a.notas;
            a.notas = b.notas;
            b.notas = tempNotas;
        }
        public static int ExtraerNumero(string codigo)
        {
            
            string num = codigo.Substring(1, 4);
            return int.Parse(num);
        }

        public static void OrdenarPorInsercionCodigo()
        {
            if (cabezon == null || cabezon.siguiente == null)
                return;

            ListaAlumnos ordenada = null;
            ListaAlumnos actual = cabezon;

            while (actual != null)
            {
                ListaAlumnos siguiente = actual.siguiente;

                
                if (ordenada == null ||
                    ExtraerNumero(actual.Codigo) <
                    ExtraerNumero(ordenada.Codigo))
                {
                    actual.siguiente = ordenada;
                    ordenada = actual;
                }
                else
                {
                    ListaAlumnos temp = ordenada;

                    while (temp.siguiente != null && ExtraerNumero(temp.siguiente.Codigo) < ExtraerNumero(actual.Codigo))
                        
                    {
                        temp = temp.siguiente;
                    }

                    actual.siguiente = temp.siguiente;
                    temp.siguiente = actual;
                }

                actual = siguiente;
            }

            cabezon = ordenada;

            Console.WriteLine("Lista ordenada por código (Inserción).");
        }



        public static int buscarCodigo(string CodigoBuscado)
        {
            
            int longitud = 0;
            ListaAlumnos temp = cabezon;

            while (temp != null)
            {
                longitud++;
                temp = temp.siguiente;
            }

            if (longitud == 0)
                return -1;

            
            int[] arreglo = new int[longitud];

            ListaAlumnos actual = cabezon;
            int index = 0;

            
            while (actual != null)
            {
                string num = actual.Codigo.Substring(1, 4);
                arreglo[index] = int.Parse(num);

                actual = actual.siguiente;
                index++;
            }

            
            string buscarNum =
                CodigoBuscado.Substring(1, 4);

            int CodigoNum =
                int.Parse(buscarNum);

            int izquierdo = 0;
            int derecho = longitud - 1;

            while (izquierdo <= derecho)
            {
                int medio = (izquierdo + derecho) / 2;

                if (arreglo[medio] == CodigoNum)
                {
                    return medio;
                }
                else if (arreglo[medio] < CodigoNum)
                {
                    izquierdo = medio + 1;
                }
                else
                {
                    derecho = medio - 1;
                }
            }

            return -1;
        }
        public static int BuscarNombreBinario(string nombreBuscado)
        {
            if (cabezon == null)
                return -1;

            // Contar nodos
            int longitud = 0;
            ListaAlumnos temp = cabezon;

            while (temp != null)
            {
                longitud++;
                temp = temp.siguiente;
            }

            // Pasar nombres a arreglo
            string[] arreglo = new string[longitud];

            ListaAlumnos actual = cabezon;
            int index = 0;

            while (actual != null)
            {
                arreglo[index] = actual.Nombres;
                actual = actual.siguiente;
                index++;
            }

            int izquierdo = 0;
            int derecho = longitud - 1;

            while (izquierdo <= derecho)
            {
                int medio = (izquierdo + derecho) / 2;

                int comparacion =
                    string.Compare(
                        arreglo[medio],
                        nombreBuscado,
                        StringComparison.OrdinalIgnoreCase);

                if (comparacion == 0)
                {
                    return medio;
                }
                else if (comparacion < 0)
                {
                    izquierdo = medio + 1;
                }
                else
                {
                    derecho = medio - 1;
                }
            }

            return -1;
        }

    }
}
