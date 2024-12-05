using Matrices.Controlador;

bool continuar = true;

while (continuar)
{
    Console.Write("\n-----------------> Ingrese la dimensión de la matriz (2-10) <-----------------\n");
    int dimensiones = int.Parse(Console.ReadLine());
    if (dimensiones < 2 || dimensiones > 10)
    {
        Console.WriteLine("\n%-----> ERROR: La dimensión debe estar entre 2 y 10 <-----%");
        continue;
    }

    Matriz sistema = new Matriz(dimensiones);

    sistema.LlenarMatriz();
    sistema.MostrarMatriz();

    double determinante = sistema.Determinante();
    Console.WriteLine($"\n-----------------> Determinante de la matriz: {determinante} <-----------------\n");

    if (determinante == 0)
    {
        Console.WriteLine("\n%----->El sistema no tiene solución única porque el determinante es cero <-----%");
        continue;
    }

    sistema.ResolverGaussJordan();
    Console.WriteLine("\n-----------------> Matriz resultante tras aplicar Gauss-Jordan <-----------------");
    sistema.MostrarMatriz();

    sistema.MostrarResultados();

    
    Console.Write("\n-----------------> ¿Desea resolver otro sistema de ecuaciones? (y/n) <-----------------\n");
    string respuesta = Console.ReadLine().ToLower();

    if (respuesta != "y")
    {
        continuar = false;
    }
}
Console.WriteLine("\n---------------------------------------------------\nGracias por usar el sistema. ¡Hasta luego!\n---------------------------------------------------");

/*
 Prueba
3
2
1
-1
8
-3
-1
2
-11
-2
1
2
-3




--------
5
2
-1
4
1
-1
7
-1
3
-2
-1
2
1
5
1
3
-4
1
33
3
-2
-2
-2
3
24
-4
-1
-5
3
-4
-49

Matrices soluciones:
3
2
3
-1
5
1
-1
2
4
3
1
1
7

7
1
1
1
1
1
1
1
7
2
3
-1
1
-2
1
3
10
-1
4
2
-1
1
-1
2
-2
3
-1
1
2
1
1
1
8
1
2
3
1
-1
1
-3
6
2
1
1
-2
1
3
-1
5
-1
3
2
4
-1
-2
2
4

4
1
1
1
1
1
2
2
2
2
3
1
-1
1
-1
0
2
3
2
1
2

*/