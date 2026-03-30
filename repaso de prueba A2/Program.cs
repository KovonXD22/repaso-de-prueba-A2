using System.Collections;
using System.Globalization;
class practicakevin
{
    public static void Main(string[] args)
    {
        int cantidad = 20;
        string[] listaproductos = new string[cantidad];
        string[] categoria = new string[cantidad];
        double[] precios = new double[cantidad];
        int[] ids = new int[cantidad];
        int option = 0;
        Random azar = new Random();

        Console.WriteLine("------MENÚ------");
        ArrayList menu = new ArrayList { "1. Agregar productos", "2. Mostrar todos los productos", "3. Calcular promedio de los precios", "4. Mostrar producto con mayor precio", "5. Mostrar producto con menor precio", "6. Mostrar productos próximos a vencer", "7. Buscar productos por nombre, ID y categoría", "8. Salir" };
        do
        {
            Console.Clear();
            foreach (string m in menu)
                Console.WriteLine(m);
            option = int.Parse(Console.ReadLine());
            switch (option)
            {

                case 1:
                    Console.Clear();
                    Console.WriteLine("\t------AGREGAR PRODUCTOS------");
                    for (int i = 0; i < cantidad; i++)
                    {
                        Console.WriteLine("Ingrese nombre del producto" + (i + 1) + "que desea agregar");
                        listaproductos[i] = Console.ReadLine();
                        ids[i] = i + 1;
                        precios[i] = azar.Next(500, 5001) / 100.0;
                        categoria[i] = "Sin clasificación";
                    }
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    break;

                case 2:
                    //.Clear limpia el menú al ejecutarse la acción y se observa únicamente lo que se verá en la acción que se seleccione.
                    Console.Clear();
                    Console.WriteLine("\t------LISTA DE PRODUCTOS------");
                    Console.WriteLine("-/IDs/-\t-/Nombre/-\t-/Precios/-\t-/Categoría/-");
                    for (int i = 0; i < cantidad; i++)
                    {
                        Console.WriteLine($"{ids[i]}\t°{listaproductos[i]}\t${precios[i]:N2}\t|{categoria[i]}|");

                    }
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();// Hace una pausa a todo el sistema para poder ver detenidamente lo que está en el caso. Se reactiva al presionar cualquier tecla.
                    break;



                case 3:
                    Console.Clear() ;
                    double promedio = calcularpromedio(precios);
                    Console.WriteLine("\t------PROMEDIO DE PRECIOS------");
                    Console.WriteLine($"El promedio de los {precios.Length} precios es de ${promedio}");
                    Console.ReadKey();
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("\t------PRODUCTOS DE MAYOR PRECIO------");
                    Console.WriteLine("-/IDs/-\t-/Nombre/-\t-/Precios/-\t-/Categoría/-");
                    for (int i = 0;i < cantidad; i++)
                    {
                        if (precios[i] > 20)
                        {
                            Console.WriteLine($"{ids[i]}\t°{listaproductos[i]}\t${precios[i]:N2}\t|{categoria[i]}|");
                        }
                        else
                        {
                            Console.WriteLine("No hay productos de mayor precio");
                        }

                    }
                   
                    break;
                   


                case 8:
                    Console.WriteLine("Saliendo del sistema");
                    break;


            }


        } while (option != 8);

    }
    static double calcularpromedio(double[] valor)

    {
        double suma = 0; 
        foreach (int n in valor)
        {
            suma += n;

        }
        return suma / valor.Length;

    }
}

