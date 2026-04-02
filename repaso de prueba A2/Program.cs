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
        DateTime[] fechavencimiento = new DateTime[cantidad];
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
                        Console.WriteLine("Ingrese nombre del producto"+" "+ (i + 1)+" "+ "que desea agregar");
                        listaproductos[i] = Console.ReadLine();
                        ids[i] = i + 1;
                        precios[i] = azar.Next(500, 5001) / 100.0;
                        categoria[i] = "Sin clasificación";
                        DateTime hoy = DateTime.Now;
                        int diasxtras = azar.Next(30, 366);
                        fechavencimiento[i] = hoy.AddDays(diasxtras);
                    }
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    break;

                case 2:
                    //.Clear limpia el menú al ejecutarse la acción y se observa únicamente lo que se verá en la acción que se seleccione.
                    Console.Clear();
                    Console.WriteLine("\t------LISTA DE PRODUCTOS------");
                    Console.WriteLine("-/IDs/-\t-/Nombre/-\t-/Precios/-\t-/Categoría/-\t-/fecha de vencimiento/-");
                    for (int i = 0; i < cantidad; i++)
                    {
                        Console.WriteLine($"{ids[i]}\t°{listaproductos[i]}\t\t${precios[i]:N2}\t\t|{categoria[i]}|\t\t||{fechavencimiento[i].ToString("dd/MM/yyyy")}||");

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
                    bool productosencontrados = false;
                    for (int i = 0;i < cantidad; i++)
                    {
                        if (precios[i] > 20)
                        {
                            Console.WriteLine($"{ids[i]}\t°{listaproductos[i]}\t${precios[i]:N2}\t|{categoria[i]}|");
                            productosencontrados = true;
                        }
                    }
                    if (!productosencontrados)
                    {
                        Console.WriteLine("No se encontraron productos que superen los $20");
                    }
                   Console.ReadKey ();
                    break;


                case 5:
                    Console.Clear();
                    Console.WriteLine("\t------PRODUCTOS DE MENOR PRECIO------");
                    Console.WriteLine("-/IDs/-\t-/Nombre/-\t-/Precios/-\t-/Categoría/-");
                    bool productosencontradosmenor = false;
                    for (int i = 0; i < cantidad; i++)
                    {
                        if (precios[i] <= 20)
                        {
                            Console.WriteLine($"{ids[i]}\t°{listaproductos[i]}\t${precios[i]:N2}\t|{categoria[i]}|");
                            productosencontradosmenor = true;
                        }
                    }
                    if (!productosencontradosmenor)
                    {
                        Console.WriteLine("No se encontraron productos que sean menores a los $20");
                    }
                    Console.ReadKey();
                    break;

                case 6:
                    Console.Clear();
                    Console.WriteLine("------PRODUCTOS PRONTOS A VENCER------");
                    Console.WriteLine("\t---ID\t°PRODUCTOS\t/FECHA DE VENCIMIENTO/---");
                    DateTime fechaactual = DateTime.Now;
                    bool fecha_de_vencimiento = false;
                    for (int i = 0; i < cantidad; i++)
                    {
                        TimeSpan fecha = fechavencimiento[i] - fechaactual;
                        if (fecha.Days <= 60 && fecha.Days >= 0)
                        {
                            Console.WriteLine($"{ids[i]}\t°{listaproductos[i]}\t\t||{fechavencimiento[i].ToString("dd/MM/yyyy")}||");
                            fecha_de_vencimiento = true;
                        }
                    }
                    if (!fecha_de_vencimiento)
                    {
                        Console.WriteLine("No se encontraron productos próximos a vencer");
                    }
                    Console.ReadKey();
                    break;

                case 7:
                    Console.Clear();
                    Console.WriteLine("------BUSCAR PRODUCTOS------");
                    Console.WriteLine("Ingrese el nombre, ID o categoría del producto");
                    string buscar = Console.ReadLine();
                    bool encontrado = false;
                    for (int i = 0;i < cantidad;i++)
                        if (listaproductos[i] ==buscar)
                        {
                            Console.WriteLine($"{ids[i]}\t°{listaproductos[i]}\t|{categoria[i]}|");
                            encontrado = true;
                        }
                    else if (ids[i].ToString() == buscar)// .ToString convierte los valores como int o double a string.
                        {

                            Console.WriteLine($"{ids[i]}\t°{listaproductos[i]}\t|{categoria[i]}|");
                            encontrado=true;
                        }
                    else if (categoria[i] == buscar)
                        {
                            Console.WriteLine($"{ids[i]}\t°{listaproductos[i]}\t|{categoria[i]}|");
                            encontrado = true;
                        }
                    if (!encontrado)
                    {
                        Console.WriteLine("El producto no se encuentra en el sistema.");
                    }
                    Console.ReadKey();
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
//práctica de prueba prora I 

