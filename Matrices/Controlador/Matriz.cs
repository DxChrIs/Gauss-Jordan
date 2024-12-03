using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices.Controlador
{
    internal class Matriz
    {
        private double[,] matriz; //Matriz bidimensional, asi se declara de manera dinamica
        private int dimensiones;

        public Matriz(int dimensiones)
        {
            this.dimensiones = dimensiones;
            matriz = new double[dimensiones, dimensiones + 1]; // Se le suma uno a las dimensiones para incluir la parte de resultado de la matriz
        }

        public void LlenarMatriz()
        {
            for (int fila = 0; fila < dimensiones; fila++)
            {
                for (int columna = 0; columna < dimensiones + 1; columna++)
                {
                    Console.Write($"Ingrese el valor para la posición [{fila + 1},{columna + 1}]: ");
                    matriz[fila, columna] = double.Parse(Console.ReadLine());
                }
            }
        }

        public void MostrarMatriz()
        {
            Console.WriteLine("\nMatriz ingresada:");
            Console.WriteLine(new string('-', (dimensiones + 1) * 9));
            for (int i = 0; i < dimensiones; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < dimensiones + 1; j++)
                {
                    Console.Write($"{matriz[i, j],7} ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine(new string('-', (dimensiones + 1) * 9));
        }

        public double Determinante()
        {
            double[,] matrizCuadrada = ObtenerMatrizCuadrada();
            return DeterminantePorCofactores(matrizCuadrada);
        }

        private double[,] ObtenerMatrizCuadrada()
        {
            double[,] matrizCuadrada = new double[dimensiones, dimensiones];
            for (int i = 0; i < dimensiones; i++)
            {
                for (int j = 0; j < dimensiones; j++)
                {
                    matrizCuadrada[i, j] = matriz[i, j];
                }
            }
            return matrizCuadrada;
        }

        private double DeterminantePorCofactores(double[,] matriz)
        {
            int n = matriz.GetLength(0);
            if (n == 2)
            {
                return matriz[0, 0] * matriz[1, 1] - matriz[0, 1] * matriz[1, 0];
            }

            double det = 0;
            for (int col = 0; col < n; col++)
            {
                double[,] submatriz = CrearSubmatriz(matriz, 0, col);
                det += Math.Pow(-1, col) * matriz[0, col] * DeterminantePorCofactores(submatriz);
            }
            return det;
        }

        private double[,] CrearSubmatriz(double[,] matriz, int fila, int columna)
        {
            int n = matriz.GetLength(0);
            double[,] submatriz = new double[n - 1, n - 1];
            int subFila = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == fila) continue;
                int subColumna = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == columna) continue;
                    submatriz[subFila, subColumna] = matriz[i, j];
                    subColumna++;
                }
                subFila++;
            }
            return submatriz;
        }

        public void ResolverGaussJordan()
        {
            for (int i = 0; i < dimensiones; i++)
            {
                double pivote = matriz[i, i];
                for (int j = 0; j < dimensiones + 1; j++)
                {
                    matriz[i, j] /= pivote;
                }
                for (int k = 0; k < dimensiones; k++)
                {
                    if (k == i) continue;
                    double factor = matriz[k, i];
                    for (int j = 0; j < dimensiones + 1; j++)
                    {
                        matriz[k, j] -= factor * matriz[i, j];
                    }
                }
            }
        }

        public void MostrarResultados()
        {
            string[] variables = { "x", "y", "z", "w", "v", "u", "n", "m", "f", "g" };

            Console.WriteLine("\nResultados:");
            Console.WriteLine("----------------------------");
            for (int i = 0; i < dimensiones; i++)
            {
                Console.WriteLine($"{variables[i]} = {matriz[i, dimensiones]}");
            }
            Console.WriteLine("----------------------------");
        }
    }
}
