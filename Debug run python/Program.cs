using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
                 ____       _                   ____              
                |  _ \  ___| |__  _   _  __ _  |  _ \ _   _ _ __  
                | | | |/ _ \ '_ \| | | |/ _` | | |_) | | | | '_ \ 
                | |_| |  __/ |_) | |_| | (_| | |  _ <| |_| | | | |
                |____/ \___|_.__/ \__,_|\__, | |_| \_\\__,_|_| |_|
                                        |___/          
                                             ____        _   _                 
                                            |  _ \ _   _| |_| |__   ___  _ __  
                                            | |_) | | | | __| '_ \ / _ \| '_ \ 
                                            |  __/| |_| | |_| | | | (_) | | | |
                                            |_|    \__, |\__|_| |_|\___/|_| |_|
                                                   |___/       
                    Version : BETA 3.7      BY : Ismaelxd74     github : https://github.com/ismaelhtmljs
                                        Repositorio del programa : #
            ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Para salir coloque 'exit' ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[1]Depurar");
            Console.WriteLine("[2]Ver Archivos");
            Console.WriteLine("[3]Moverse de Escritorio");
            Console.WriteLine("[4]Abrir vscode");
            Console.WriteLine("[5]Crear Proyecto");
            string respuesta = Console.ReadLine();
            
            // Condicion para las opciones
            if (respuesta == "1")
            {
                Console.WriteLine("Coloque el nombre de su archivo : ");
                string nombre_archivo = Console.ReadLine();
                
                // verificar si el archivo lleva la extencion '.py
                if (!nombre_archivo.EndsWith(".py"))
                {
                    nombre_archivo += ".py";
                }

                // verificar si el archivo existe
                if (File.Exists(nombre_archivo))
                {
                    string Depurar_comand = $"python {nombre_archivo}";
                    Ejecutor(Depurar_comand);
                    Limpiador();
                }
                
                else
                {
                    notFound_llamada();
                    Limpiador();
                }
            }

            else if (respuesta == "2")
            {
                Ver_archivos();
                Limpiador();
            }

            else if(respuesta == "3")
            {
                CD_directio();
            }

            else if (respuesta == "4")
            {
                string Abrir_vscode = "code . ";
                Ejecutor(Abrir_vscode);
                Limpiador();
            }

            else if (respuesta == "5")
            {
                Crear_proyecto();
                Limpiador();
            }

            else if (respuesta == "exit")
            {
                Environment.Exit(0);
            }

            else
            {
                Error_llamada();
                Limpiador();
            }
        }
    }
    // funciones 

    static void Ejecutor(string comando)
    {
        ProcessStartInfo processStartInfo= new ProcessStartInfo()
        {
            FileName = "cmd.exe",
            Arguments = $"/C {comando}",
            UseShellExecute = true,
            CreateNoWindow = true,
        };
        Process.Start(processStartInfo);
    }

    static void Limpiador()
    {
        Console.WriteLine("Presione cualquier tecla para continuar");
        Console.ReadKey();
        Console.Clear();
    }

    static void Ver_archivos()
    {
        string directorio = Directory.GetCurrentDirectory();
        string[] archivos = Directory.GetFileSystemEntries(directorio);
        foreach (string archivo in archivos)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(archivo);
        }
    }

    static void CD_directio()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("EJEMPLO : C:/Ruta/de/su/archivo");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Coloque la ruta en la que desea moverse");
        string ruta = Console.ReadLine();
        ruta = ruta.Replace("/", "\\");

        // verificar si la ruta existe
        if (Directory.Exists(ruta))
        {
            Directory.SetCurrentDirectory(ruta);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Ahora estas en la ruta : {Directory.GetCurrentDirectory()}");
            Limpiador();
        }

        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("El directorio no existe. Asegúrate de que la ruta sea correcta.");
            Console.ForegroundColor = ConsoleColor.Green;
            Limpiador();
        }
    }

    static void notFound_llamada()
    {
        Error_Clase error_Clase = new Error_Clase();
        Error_Clase.notFound();
    }

    static void Error_llamada()
    {
        Error_Clase error_Clase = new Error_Clase();
        Error_Clase.Error_mensaje();
    }

    static void Crear_proyecto()
    {
        Console.WriteLine("Coloque el nombre de su carpeta");
        string Nombre_carpeta_crear = Console.ReadLine();
        Console.WriteLine("Coloque el nombre de su archivo");
        string Nombre_archivo = Console.ReadLine();

        // combinar y luego verificar
        string ruta_carpeta = Path.Combine(Directory.GetCurrentDirectory(), Nombre_carpeta_crear);

        if (!Directory.Exists(ruta_carpeta))
        {
            Directory.CreateDirectory(ruta_carpeta);
        }
        else
        {
            Console.WriteLine("La carpeta ya esta creada, intenta otra vez");
        }

        string archivo_ruta = Path.Combine(ruta_carpeta, $"{Nombre_archivo}.py");
        if (!Directory.Exists(archivo_ruta))
        {
            File.Create(archivo_ruta).Close();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Se ha creado el archivo {Nombre_archivo} dentro de la carpeta {Nombre_carpeta_crear}.");
        }
        else
        {
            Console.WriteLine("El archivo ya existe en esa ubicación.");
        }
    }
}

class Error_Clase
{
    public static void Error_mensaje()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("ERROR : No tenemos esa opcion en el programa");
    }

    public static void notFound()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("ERROR 404 : No se logro encontrar el archivo deseado");
    }
}
