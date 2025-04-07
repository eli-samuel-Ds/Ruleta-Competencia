using System; //Clase que contiene los comandos de C#
using System.IO; //Clase de manejo de archivos
using System.Threading; //Clase para pausar el programa
using NAudio.Wave;//Manejo de audio
using System.Diagnostics;
using System.Net;//Cronometro interno

class Program
{
    // Variable global
    static string listaEstudianteFacilitador = @"C:\Users\sreli\Desktop\Clases_Itla\Clases\cuatrimestre_2\fundamentosProgramacion\1 - proyectoCompetencia\ruletaEstudiantes\competenciaRuleta\guardarArchivos\listaEstudianteFacilitador.txt";
    static string listaEstudianteProgramador = @"C:\Users\sreli\Desktop\Clases_Itla\Clases\cuatrimestre_2\fundamentosProgramacion\1 - proyectoCompetencia\ruletaEstudiantes\competenciaRuleta\guardarArchivos\listaEstudianteProgramador.txt";
    static string registroUsuario = @"C:\Users\sreli\Desktop\Clases_Itla\Clases\cuatrimestre_2\fundamentosProgramacion\1 - proyectoCompetencia\ruletaEstudiantes\competenciaRuleta\guardarArchivos\registroUsuario.txt";
    static string personasRuletaLista = @"C:\Users\sreli\Desktop\Clases_Itla\Clases\cuatrimestre_2\fundamentosProgramacion\1 - proyectoCompetencia\ruletaEstudiantes\competenciaRuleta\guardarArchivos\personasRuletaLista.txt";
    static string sugerenciaBuzonArchivo = @"C:\Users\sreli\Desktop\Clases_Itla\Clases\cuatrimestre_2\fundamentosProgramacion\1 - proyectoCompetencia\ruletaEstudiantes\competenciaRuleta\guardarArchivos\sugerenciaBuzon.txt";
    static string copiaSeguridad = @"C:\Users\sreli\Desktop\Clases_Itla\Clases\cuatrimestre_2\fundamentosProgramacion\1 - proyectoCompetencia\ruletaEstudiantes\competenciaRuleta\guardarArchivos\copiaSeguridadLista.txt";

    static WaveOutEvent outputDevice = null!;
    static AudioFileReader audioFile = null!;
    static string filePath = @"C:\Users\sreli\Desktop\Clases_Itla\Clases\cuatrimestre_2\fundamentosProgramacion\1 - proyectoCompetencia\ruletaEstudiantes\competenciaRuleta\musicaProgram\fondoMusic.mp3";
    static string filePath1 = @"C:\Users\sreli\Desktop\Clases_Itla\Clases\cuatrimestre_2\fundamentosProgramacion\1 - proyectoCompetencia\ruletaEstudiantes\competenciaRuleta\musicaProgram\fondoMusic1.mp3";
    static string filePath2 = @"C:\Users\sreli\Desktop\Clases_Itla\Clases\cuatrimestre_2\fundamentosProgramacion\1 - proyectoCompetencia\ruletaEstudiantes\competenciaRuleta\musicaProgram\fondoMusic2.mp3";

    static int cursorLeft = Console.CursorLeft;
    static int cursorTop = Console.CursorTop;
    static bool musicaSIONO = true;
    static bool aparecerCambiarColor = false;

    static void Main()
    {
        //Oculta el curso en la consola
        Console.CursorVisible = false;

        audioFile = new AudioFileReader(filePath);
        outputDevice = new WaveOutEvent();
        outputDevice.Init(audioFile);
        outputDevice.Play();

        eliminarLineasVacias();
        bool registroBucleVerdad = true;
        do
        {
            Console.Clear();
            Console.WriteLine(@"
            
            
            
            
            
            
            
            
            
            
            
            
            
            

                                                            █████████████████████████████████████████████████████████████████
                                                            █▌                                                             ▐█
                                                            █▌ ███████╗███╗   ██╗████████╗██████╗  █████╗ ██████╗  █████╗  ▐█
                                                            █▌ ██╔════╝████╗  ██║╚══██╔══╝██╔══██╗██╔══██╗██╔══██╗██╔══██╗ ▐█
                                                            █▌ █████╗  ██╔██╗ ██║   ██║   ██████╔╝███████║██║  ██║███████║ ▐█
                                                            █▌ ██╔══╝  ██║╚██╗██║   ██║   ██╔══██╗██╔══██║██║  ██║██╔══██║ ▐█
                                                            █▌ ███████╗██║ ╚████║   ██║   ██║  ██║██║  ██║██████╔╝██║  ██║ ▐█
                                                            █▌ ╚══════╝╚═╝  ╚═══╝   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ ╚═╝  ╚═╝ ▐█
                                                            █▌                                                             ▐█
                                                            █████████████████████████████████████████████████████████████████");
            Console.Write("                                                            ██████████ | Digita tu contrasena: ");
            string input = limiteEscribir(3);

            string usarRegistro = "hola";

            if (File.Exists(registroUsuario))
            {
                string[] registro = File.ReadAllLines(registroUsuario);
                for (int i = 0; i < registro.Length; i++)
                {
                    usarRegistro = registro[i];
                }
            }

            else Console.WriteLine(@"















                                                                        ██████████ | El archivos de registro no existe, reinstale el programa de nuevo.");

            if (input == usarRegistro)
            {
                bool tutorialSIONO = true;
                do
                {
                    Console.Clear();
                    Console.SetCursorPosition(70, 20);
                    Console.Write("██████████ | Quiere tomar el tutorial (Si(Y) o No(N))");
                    var key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.Y:
                            Console.Clear();
                            tutorialInicioPrograma();
                            eliminarLineasVacias();
                            tutorialSIONO = false;
                            break;

                        case ConsoleKey.N:
                            tutorialSIONO = false;
                            break;

                        default:
                            continue;
                    }
                } while (tutorialSIONO);


                registroBucleVerdad = false;
                eliminarLineasVacias();
                Console.Clear();

                do
                {
                    Console.Clear();
                    tituloMenuElegir();
                    eliminarLineasVacias();
                    var key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.R:
                            Console.Clear();
                            procesoRuleta();
                            eliminarLineasVacias();
                            break;

                        case ConsoleKey.M:
                            Console.Clear();
                            menuManejoArchivo();
                            eliminarLineasVacias();
                            break;

                        case ConsoleKey.I:
                            Console.Clear();
                            cronometroInternoVisto();
                            eliminarLineasVacias();
                            break;

                        case ConsoleKey.T:
                            Console.Clear();
                            tutorialInicioPrograma();
                            eliminarLineasVacias();
                            break;

                        case ConsoleKey.C:
                            Console.Clear();
                            configuracionesPrograma();
                            eliminarLineasVacias();
                            break;

                        case ConsoleKey.S:
                            Console.Clear();
                            sugerenciaBuzon();
                            eliminarLineasVacias();
                            break;

                        case ConsoleKey.X:
                            Console.Clear();
                            Console.WriteLine(@"
        
        
        
        
        
        
        
                                                ╔────────────────────────────────────────────────────────────────────────────────────────────╗
                                                │                                                                                            │
                                                │                  ██████╗ ██╗   ██╗██╗     ███████╗████████╗ █████╗                         │
                                                │                  ██╔══██╗██║   ██║██║     ██╔════╝╚══██╔══╝██╔══██╗                        │
                                                │                  ██████╔╝██║   ██║██║     █████╗     ██║   ███████║                        │
                                                │                  ██╔══██╗██║   ██║██║     ██╔══╝     ██║   ██╔══██║                        │
                                                │                  ██║  ██║╚██████╔╝███████╗███████╗   ██║   ██║  ██║                        │
                                                │                  ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚══════╝   ╚═╝   ╚═╝  ╚═╝                        │
                                                │                                                                                            │
                                                │  ███████╗███████╗████████╗██╗   ██╗██████╗ ██╗ █████╗ ███╗   ██╗████████╗███████╗███████╗  │
                                                │  ██╔════╝██╔════╝╚══██╔══╝██║   ██║██╔══██╗██║██╔══██╗████╗  ██║╚══██╔══╝██╔════╝██╔════╝  │
                                                │  █████╗  ███████╗   ██║   ██║   ██║██║  ██║██║███████║██╔██╗ ██║   ██║   █████╗  ███████╗  │
                                                │  ██╔══╝  ╚════██║   ██║   ██║   ██║██║  ██║██║██╔══██║██║╚██╗██║   ██║   ██╔══╝  ╚════██║  │
                                                │  ███████╗███████║   ██║   ╚██████╔╝██████╔╝██║██║  ██║██║ ╚████║   ██║   ███████╗███████║  │
                                                │  ╚══════╝╚══════╝   ╚═╝    ╚═════╝ ╚═════╝ ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝  │
                                                │                                                                                            │
                                                ╚────────────────────────────────────────────────────────────────────────────────────────────╝");
                            Console.WriteLine("                                                                           ┌──────────────────────────────────┐\n");
                            Console.WriteLine("                                                                                --------- Menu ---------");
                            Console.WriteLine("                                                                                |- Ruleta ---------- (R)");
                            Console.WriteLine("                                                                                |- Manejo Archivos - (M)");
                            Console.WriteLine("                                                                                |- Cronometro int -- (I)");
                            Console.WriteLine("                                                                                |- Tutorial -------- (T)");
                            Console.WriteLine("                                                                                |- Configuraciones - (C)");
                            Console.WriteLine("                                                                                |- Sugerencias ----- (S)");
                            ConsoleColor currentForegroundColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("                                                                                |- Salir ----------- (X)\n");
                            Console.ForegroundColor = currentForegroundColor;
                            Console.WriteLine("                                                                           └──────────────────────────────────┘\n");

                            Thread.Sleep(500);
                            Console.Clear();

                            for (int i = 0; i < 5; i++)
                            {
                                Console.Clear();
                                Console.SetCursorPosition(90, 25);
                                Console.WriteLine("      O");
                                Console.SetCursorPosition(90, 26);
                                Console.WriteLine(@"     /|\");
                                Console.SetCursorPosition(90, 27);
                                Console.WriteLine(@"    / | \");
                                Console.SetCursorPosition(90, 28);
                                Console.WriteLine(@"   /  |  \");
                                Console.SetCursorPosition(90, 29);
                                Console.WriteLine(@"     / \");
                                Console.SetCursorPosition(90, 30);
                                Console.WriteLine(@"    /   \");
                                Console.SetCursorPosition(90, 31);
                                Console.WriteLine(@"   /     \");
                                Thread.Sleep(300);

                                Console.Clear();
                                Console.SetCursorPosition(90, 23);
                                Console.WriteLine(@"          /");
                                Console.SetCursorPosition(90, 24);
                                Console.WriteLine(@"         /");
                                Console.SetCursorPosition(90, 25);
                                Console.WriteLine(@"      O /");
                                Console.SetCursorPosition(90, 26);
                                Console.WriteLine(@"     /| ");
                                Console.SetCursorPosition(90, 27);
                                Console.WriteLine(@"    / |  ");
                                Console.SetCursorPosition(90, 28);
                                Console.WriteLine(@"   /  |   ");
                                Console.SetCursorPosition(90, 29);
                                Console.WriteLine(@"     / \");
                                Console.SetCursorPosition(90, 30);
                                Console.WriteLine(@"    /   \");
                                Console.SetCursorPosition(90, 31);
                                Console.WriteLine(@"   /     \");
                                Thread.Sleep(300);
                            }
                            Thread.Sleep(300);
                            Console.Clear();
                            Console.WriteLine(@"






                            
                            
                            
                            
                            
                            
                            
                                                                ╔──────────────────────────────────────────────────────────────────╗
                                                                │                                                                  │
                                                                │  ███████╗ █████╗ ██╗     ██╗███████╗███╗   ██╗██████╗  ██████╗   │
                                                                │  ██╔════╝██╔══██╗██║     ██║██╔════╝████╗  ██║██╔══██╗██╔═══██╗  │
                                                                │  ███████╗███████║██║     ██║█████╗  ██╔██╗ ██║██║  ██║██║   ██║  │
                                                                │  ╚════██║██╔══██║██║     ██║██╔══╝  ██║╚██╗██║██║  ██║██║   ██║  │
                                                                │  ███████║██║  ██║███████╗██║███████╗██║ ╚████║██████╔╝╚██████╔╝  │
                                                                │  ╚══════╝╚═╝  ╚═╝╚══════╝╚═╝╚══════╝╚═╝  ╚═══╝╚═════╝  ╚═════╝   │
                                                                │                                                                  │
                                                                ╚──────────────────────────────────────────────────────────────────╝");
                            Thread.Sleep(300);
                            barraCarga(83, 25);
                            Environment.Exit(0);
                            eliminarLineasVacias();
                            break;

                        default:
                            continue;
                    }

                    Console.Clear();
                    tituloMenuElegir();
                } while (true);
            }
            else Console.WriteLine("                                                            ██████████ | Contrasena Incorrecta, Vuelve a intentar.");
            Console.ReadKey();
        } while (registroBucleVerdad);
    }

    // Menú de inicio
    static void tituloMenuElegir()
    {
        Console.WriteLine(@"
        
        
        
        
        
        
        
                                                ╔────────────────────────────────────────────────────────────────────────────────────────────╗
                                                │                                                                                            │
                                                │                  ██████╗ ██╗   ██╗██╗     ███████╗████████╗ █████╗                         │
                                                │                  ██╔══██╗██║   ██║██║     ██╔════╝╚══██╔══╝██╔══██╗                        │
                                                │                  ██████╔╝██║   ██║██║     █████╗     ██║   ███████║                        │
                                                │                  ██╔══██╗██║   ██║██║     ██╔══╝     ██║   ██╔══██║                        │
                                                │                  ██║  ██║╚██████╔╝███████╗███████╗   ██║   ██║  ██║                        │
                                                │                  ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚══════╝   ╚═╝   ╚═╝  ╚═╝                        │
                                                │                                                                                            │
                                                │  ███████╗███████╗████████╗██╗   ██╗██████╗ ██╗ █████╗ ███╗   ██╗████████╗███████╗███████╗  │
                                                │  ██╔════╝██╔════╝╚══██╔══╝██║   ██║██╔══██╗██║██╔══██╗████╗  ██║╚══██╔══╝██╔════╝██╔════╝  │
                                                │  █████╗  ███████╗   ██║   ██║   ██║██║  ██║██║███████║██╔██╗ ██║   ██║   █████╗  ███████╗  │
                                                │  ██╔══╝  ╚════██║   ██║   ██║   ██║██║  ██║██║██╔══██║██║╚██╗██║   ██║   ██╔══╝  ╚════██║  │
                                                │  ███████╗███████║   ██║   ╚██████╔╝██████╔╝██║██║  ██║██║ ╚████║   ██║   ███████╗███████║  │
                                                │  ╚══════╝╚══════╝   ╚═╝    ╚═════╝ ╚═════╝ ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝  │
                                                │                                                                                            │
                                                ╚────────────────────────────────────────────────────────────────────────────────────────────╝");
        Console.WriteLine("                                                                           ┌──────────────────────────────────┐\n");
        Console.WriteLine("                                                                                --------- Menu ---------");
        Console.WriteLine("                                                                                |- Ruleta ---------- (R)");
        Console.WriteLine("                                                                                |- Manejo Archivos - (M)");
        Console.WriteLine("                                                                                |- Cronometro int -- (I)");
        Console.WriteLine("                                                                                |- Tutorial -------- (T)");
        Console.WriteLine("                                                                                |- Configuraciones - (C)");
        Console.WriteLine("                                                                                |- Sugerencias ----- (S)");
        Console.WriteLine("                                                                                |- Salir ----------- (X)\n");
        Console.WriteLine("                                                                           └──────────────────────────────────┘\n");
    }
    // Menú de manejo de archivo
    static void menuManejoArchivo()
    {
        Console.Clear();
        Console.WriteLine(@"
        
        
        
        
        
        
        
                                                ╔────────────────────────────────────────────────────────────────────────────────────────────╗
                                                │                                                                                            │
                                                │                  ██████╗ ██╗   ██╗██╗     ███████╗████████╗ █████╗                         │
                                                │                  ██╔══██╗██║   ██║██║     ██╔════╝╚══██╔══╝██╔══██╗                        │
                                                │                  ██████╔╝██║   ██║██║     █████╗     ██║   ███████║                        │
                                                │                  ██╔══██╗██║   ██║██║     ██╔══╝     ██║   ██╔══██║                        │
                                                │                  ██║  ██║╚██████╔╝███████╗███████╗   ██║   ██║  ██║                        │
                                                │                  ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚══════╝   ╚═╝   ╚═╝  ╚═╝                        │
                                                │                                                                                            │
                                                │  ███████╗███████╗████████╗██╗   ██╗██████╗ ██╗ █████╗ ███╗   ██╗████████╗███████╗███████╗  │
                                                │  ██╔════╝██╔════╝╚══██╔══╝██║   ██║██╔══██╗██║██╔══██╗████╗  ██║╚══██╔══╝██╔════╝██╔════╝  │
                                                │  █████╗  ███████╗   ██║   ██║   ██║██║  ██║██║███████║██╔██╗ ██║   ██║   █████╗  ███████╗  │
                                                │  ██╔══╝  ╚════██║   ██║   ██║   ██║██║  ██║██║██╔══██║██║╚██╗██║   ██║   ██╔══╝  ╚════██║  │
                                                │  ███████╗███████║   ██║   ╚██████╔╝██████╔╝██║██║  ██║██║ ╚████║   ██║   ███████╗███████║  │
                                                │  ╚══════╝╚══════╝   ╚═╝    ╚═════╝ ╚═════╝ ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝  │
                                                │                                                                                            │
                                                ╚────────────────────────────────────────────────────────────────────────────────────────────╝");
        Console.WriteLine("                                                                           ┌──────────────────────────────────┐\n");
        Console.WriteLine("                                                                                --------- Menu ---------");
        Console.WriteLine("                                                                                |- Ruleta ---------- (R)");
        ConsoleColor currentForegroundColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("                                                                                |- Manejo Archivos - (M)");
        Console.ResetColor();
        Console.ForegroundColor = currentForegroundColor;
        Console.WriteLine("                                                                                |- Cronometro int -- (I)");
        Console.WriteLine("                                                                                |- Tutorial -------- (T)");
        Console.WriteLine("                                                                                |- Configuraciones - (C)");
        Console.WriteLine("                                                                                |- Sugerencias ----- (S)");
        Console.WriteLine("                                                                                |- Salir ----------- (X)\n");
        Console.WriteLine("                                                                           └──────────────────────────────────┘\n");

        Thread.Sleep(500);
        Console.Clear();

        eliminarLineasVacias();
        bool manejoArchivo = true;
        do
        {
            Console.Clear();
            Console.WriteLine(@"     
            
            
            



            
                                                                
                                                                ╔──────────────────────────────────────────────────────────────╗
                                                                │                                                              │
                                                                │    ███╗   ███╗ █████╗ ███╗   ██╗███████╗     ██╗ ██████╗     │
                                                                │    ████╗ ████║██╔══██╗████╗  ██║██╔════╝     ██║██╔═══██╗    │
                                                                │    ██╔████╔██║███████║██╔██╗ ██║█████╗       ██║██║   ██║    │
                                                                │    ██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══╝  ██   ██║██║   ██║    │
                                                                │    ██║ ╚═╝ ██║██║  ██║██║ ╚████║███████╗╚█████╔╝╚██████╔╝    │
                                                                │    ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚══════╝ ╚════╝  ╚═════╝     │
                                                                │     █████╗ ██████╗  ██████╗██╗  ██╗██╗██╗   ██╗ ██████╗      │
                                                                │    ██╔══██╗██╔══██╗██╔════╝██║  ██║██║██║   ██║██╔═══██╗     │
                                                                │    ███████║██████╔╝██║     ███████║██║██║   ██║██║   ██║     │
                                                                │    ██╔══██║██╔══██╗██║     ██╔══██║██║╚██╗ ██╔╝██║   ██║     │
                                                                │    ██║  ██║██║  ██║╚██████╗██║  ██║██║ ╚████╔╝ ╚██████╔╝     │
                                                                │    ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═════╝      │
                                                                │                                                              │
                                                                ╚──────────────────────────────────────────────────────────────╝");
            Console.WriteLine("                                                                              ┌───────────────────────────────┐\n");
            Console.WriteLine("                                                                                   --------- Menu ---------");
            Console.WriteLine("                                                                                   |- Mostrar datos --- (M)");
            Console.WriteLine("                                                                                   |- Mostrar Progr --- (R)");
            Console.WriteLine("                                                                                   |- Buscar datos ---- (B)");
            Console.WriteLine("                                                                                   |- Agregar dato ---- (A)");
            Console.WriteLine("                                                                                   |- Eliminar Dato --- (D)");
            Console.WriteLine("                                                                                   |- Eliminar Todos -- (T)");
            Console.WriteLine("                                                                                   |- Rellenar Facili - (F)");
            Console.WriteLine("                                                                                   |- Rellenar Progra - (P)");
            Console.WriteLine("                                                                                   |- Volver ---------- (V)\n");
            Console.WriteLine("                                                                              └───────────────────────────────┘\n");
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.M:
                    Console.Clear();
                    Console.WriteLine(@"     
            
            
            



            
                                                                
                                                                ╔──────────────────────────────────────────────────────────────╗
                                                                │                                                              │
                                                                │    ███╗   ███╗ █████╗ ███╗   ██╗███████╗     ██╗ ██████╗     │
                                                                │    ████╗ ████║██╔══██╗████╗  ██║██╔════╝     ██║██╔═══██╗    │
                                                                │    ██╔████╔██║███████║██╔██╗ ██║█████╗       ██║██║   ██║    │
                                                                │    ██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══╝  ██   ██║██║   ██║    │
                                                                │    ██║ ╚═╝ ██║██║  ██║██║ ╚████║███████╗╚█████╔╝╚██████╔╝    │
                                                                │    ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚══════╝ ╚════╝  ╚═════╝     │
                                                                │     █████╗ ██████╗  ██████╗██╗  ██╗██╗██╗   ██╗ ██████╗      │
                                                                │    ██╔══██╗██╔══██╗██╔════╝██║  ██║██║██║   ██║██╔═══██╗     │
                                                                │    ███████║██████╔╝██║     ███████║██║██║   ██║██║   ██║     │
                                                                │    ██╔══██║██╔══██╗██║     ██╔══██║██║╚██╗ ██╔╝██║   ██║     │
                                                                │    ██║  ██║██║  ██║╚██████╗██║  ██║██║ ╚████╔╝ ╚██████╔╝     │
                                                                │    ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═════╝      │
                                                                │                                                              │
                                                                ╚──────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                              ┌───────────────────────────────┐\n");
                    Console.WriteLine("                                                                                   --------- Menu ---------");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                                   |- Mostrar datos --- (M)");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                                   |- Mostrar Progr --- (R)");
                    Console.WriteLine("                                                                                   |- Buscar datos ---- (B)");
                    Console.WriteLine("                                                                                   |- Agregar dato ---- (A)");
                    Console.WriteLine("                                                                                   |- Eliminar Dato --- (D)");
                    Console.WriteLine("                                                                                   |- Eliminar Todos -- (T)");
                    Console.WriteLine("                                                                                   |- Rellenar Facili - (F)");
                    Console.WriteLine("                                                                                   |- Rellenar Progra - (P)");
                    Console.WriteLine("                                                                                   |- Volver ---------- (V)\n");
                    Console.WriteLine("                                                                              └───────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    mostrarDatos();
                    break;

                case ConsoleKey.R:
                    Console.Clear();
                    Console.WriteLine(@"     
            
            
            



            
                                                                
                                                                ╔──────────────────────────────────────────────────────────────╗
                                                                │                                                              │
                                                                │    ███╗   ███╗ █████╗ ███╗   ██╗███████╗     ██╗ ██████╗     │
                                                                │    ████╗ ████║██╔══██╗████╗  ██║██╔════╝     ██║██╔═══██╗    │
                                                                │    ██╔████╔██║███████║██╔██╗ ██║█████╗       ██║██║   ██║    │
                                                                │    ██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══╝  ██   ██║██║   ██║    │
                                                                │    ██║ ╚═╝ ██║██║  ██║██║ ╚████║███████╗╚█████╔╝╚██████╔╝    │
                                                                │    ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚══════╝ ╚════╝  ╚═════╝     │
                                                                │     █████╗ ██████╗  ██████╗██╗  ██╗██╗██╗   ██╗ ██████╗      │
                                                                │    ██╔══██╗██╔══██╗██╔════╝██║  ██║██║██║   ██║██╔═══██╗     │
                                                                │    ███████║██████╔╝██║     ███████║██║██║   ██║██║   ██║     │
                                                                │    ██╔══██║██╔══██╗██║     ██╔══██║██║╚██╗ ██╔╝██║   ██║     │
                                                                │    ██║  ██║██║  ██║╚██████╗██║  ██║██║ ╚████╔╝ ╚██████╔╝     │
                                                                │    ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═════╝      │
                                                                │                                                              │
                                                                ╚──────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                              ┌───────────────────────────────┐\n");
                    Console.WriteLine("                                                                                   --------- Menu ---------");
                    Console.WriteLine("                                                                                   |- Mostrar datos --- (M)");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                                   |- Mostrar Progr --- (R)");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                                   |- Buscar datos ---- (B)");
                    Console.WriteLine("                                                                                   |- Agregar dato ---- (A)");
                    Console.WriteLine("                                                                                   |- Eliminar Dato --- (D)");
                    Console.WriteLine("                                                                                   |- Eliminar Todos -- (T)");
                    Console.WriteLine("                                                                                   |- Rellenar Facili - (F)");
                    Console.WriteLine("                                                                                   |- Rellenar Progra - (P)");
                    Console.WriteLine("                                                                                   |- Volver ---------- (V)\n");
                    Console.WriteLine("                                                                              └───────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    mostrarProgramas();
                    break;

                case ConsoleKey.B:
                    Console.Clear();
                    Console.WriteLine(@"     
            
            
            



            
                                                                
                                                                ╔──────────────────────────────────────────────────────────────╗
                                                                │                                                              │
                                                                │    ███╗   ███╗ █████╗ ███╗   ██╗███████╗     ██╗ ██████╗     │
                                                                │    ████╗ ████║██╔══██╗████╗  ██║██╔════╝     ██║██╔═══██╗    │
                                                                │    ██╔████╔██║███████║██╔██╗ ██║█████╗       ██║██║   ██║    │
                                                                │    ██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══╝  ██   ██║██║   ██║    │
                                                                │    ██║ ╚═╝ ██║██║  ██║██║ ╚████║███████╗╚█████╔╝╚██████╔╝    │
                                                                │    ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚══════╝ ╚════╝  ╚═════╝     │
                                                                │     █████╗ ██████╗  ██████╗██╗  ██╗██╗██╗   ██╗ ██████╗      │
                                                                │    ██╔══██╗██╔══██╗██╔════╝██║  ██║██║██║   ██║██╔═══██╗     │
                                                                │    ███████║██████╔╝██║     ███████║██║██║   ██║██║   ██║     │
                                                                │    ██╔══██║██╔══██╗██║     ██╔══██║██║╚██╗ ██╔╝██║   ██║     │
                                                                │    ██║  ██║██║  ██║╚██████╗██║  ██║██║ ╚████╔╝ ╚██████╔╝     │
                                                                │    ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═════╝      │
                                                                │                                                              │
                                                                ╚──────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                              ┌───────────────────────────────┐\n");
                    Console.WriteLine("                                                                                   --------- Menu ---------");
                    Console.WriteLine("                                                                                   |- Mostrar datos --- (M)");
                    Console.WriteLine("                                                                                   |- Mostrar Progr --- (R)");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                                   |- Buscar datos ---- (B)");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                                   |- Agregar dato ---- (A)");
                    Console.WriteLine("                                                                                   |- Eliminar Dato --- (D)");
                    Console.WriteLine("                                                                                   |- Eliminar Todos -- (T)");
                    Console.WriteLine("                                                                                   |- Rellenar Facili - (F)");
                    Console.WriteLine("                                                                                   |- Rellenar Progra - (P)");
                    Console.WriteLine("                                                                                   |- Volver ---------- (V)\n");
                    Console.WriteLine("                                                                              └───────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    buscarUsuario();
                    Console.ReadKey();
                    break;

                case ConsoleKey.A:
                    Console.Clear();
                    Console.WriteLine(@"     
            
            
            



            
                                                                
                                                                ╔──────────────────────────────────────────────────────────────╗
                                                                │                                                              │
                                                                │    ███╗   ███╗ █████╗ ███╗   ██╗███████╗     ██╗ ██████╗     │
                                                                │    ████╗ ████║██╔══██╗████╗  ██║██╔════╝     ██║██╔═══██╗    │
                                                                │    ██╔████╔██║███████║██╔██╗ ██║█████╗       ██║██║   ██║    │
                                                                │    ██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══╝  ██   ██║██║   ██║    │
                                                                │    ██║ ╚═╝ ██║██║  ██║██║ ╚████║███████╗╚█████╔╝╚██████╔╝    │
                                                                │    ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚══════╝ ╚════╝  ╚═════╝     │
                                                                │     █████╗ ██████╗  ██████╗██╗  ██╗██╗██╗   ██╗ ██████╗      │
                                                                │    ██╔══██╗██╔══██╗██╔════╝██║  ██║██║██║   ██║██╔═══██╗     │
                                                                │    ███████║██████╔╝██║     ███████║██║██║   ██║██║   ██║     │
                                                                │    ██╔══██║██╔══██╗██║     ██╔══██║██║╚██╗ ██╔╝██║   ██║     │
                                                                │    ██║  ██║██║  ██║╚██████╗██║  ██║██║ ╚████╔╝ ╚██████╔╝     │
                                                                │    ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═════╝      │
                                                                │                                                              │
                                                                ╚──────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                              ┌───────────────────────────────┐\n");
                    Console.WriteLine("                                                                                   --------- Menu ---------");
                    Console.WriteLine("                                                                                   |- Mostrar datos --- (M)");
                    Console.WriteLine("                                                                                   |- Mostrar Progr --- (R)");
                    Console.WriteLine("                                                                                   |- Buscar datos ---- (B)");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                                   |- Agregar dato ---- (A)");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                                   |- Eliminar Dato --- (D)");
                    Console.WriteLine("                                                                                   |- Eliminar Todos -- (T)");
                    Console.WriteLine("                                                                                   |- Rellenar Facili - (F)");
                    Console.WriteLine("                                                                                   |- Rellenar Progra - (P)");
                    Console.WriteLine("                                                                                   |- Volver ---------- (V)\n");
                    Console.WriteLine("                                                                              └───────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    agregarDato();
                    Console.ReadKey();
                    break;

                case ConsoleKey.D:
                    Console.Clear();
                    Console.WriteLine(@"     
            
            
            



            
                                                                
                                                                ╔──────────────────────────────────────────────────────────────╗
                                                                │                                                              │
                                                                │    ███╗   ███╗ █████╗ ███╗   ██╗███████╗     ██╗ ██████╗     │
                                                                │    ████╗ ████║██╔══██╗████╗  ██║██╔════╝     ██║██╔═══██╗    │
                                                                │    ██╔████╔██║███████║██╔██╗ ██║█████╗       ██║██║   ██║    │
                                                                │    ██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══╝  ██   ██║██║   ██║    │
                                                                │    ██║ ╚═╝ ██║██║  ██║██║ ╚████║███████╗╚█████╔╝╚██████╔╝    │
                                                                │    ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚══════╝ ╚════╝  ╚═════╝     │
                                                                │     █████╗ ██████╗  ██████╗██╗  ██╗██╗██╗   ██╗ ██████╗      │
                                                                │    ██╔══██╗██╔══██╗██╔════╝██║  ██║██║██║   ██║██╔═══██╗     │
                                                                │    ███████║██████╔╝██║     ███████║██║██║   ██║██║   ██║     │
                                                                │    ██╔══██║██╔══██╗██║     ██╔══██║██║╚██╗ ██╔╝██║   ██║     │
                                                                │    ██║  ██║██║  ██║╚██████╗██║  ██║██║ ╚████╔╝ ╚██████╔╝     │
                                                                │    ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═════╝      │
                                                                │                                                              │
                                                                ╚──────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                              ┌───────────────────────────────┐\n");
                    Console.WriteLine("                                                                                   --------- Menu ---------");
                    Console.WriteLine("                                                                                   |- Mostrar datos --- (M)");
                    Console.WriteLine("                                                                                   |- Mostrar Progr --- (R)");
                    Console.WriteLine("                                                                                   |- Buscar datos ---- (B)");
                    Console.WriteLine("                                                                                   |- Agregar dato ---- (A)");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                                   |- Eliminar Dato --- (D)");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                                   |- Eliminar Todos -- (T)");
                    Console.WriteLine("                                                                                   |- Rellenar Facili - (F)");
                    Console.WriteLine("                                                                                   |- Rellenar Progra - (P)");
                    Console.WriteLine("                                                                                   |- Volver ---------- (V)\n");
                    Console.WriteLine("                                                                              └───────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    borrarDatoEspecifico();
                    Console.ReadKey();
                    break;

                case ConsoleKey.T:
                    Console.Clear();
                    Console.WriteLine(@"     
            
            
            



            
                                                                
                                                                ╔──────────────────────────────────────────────────────────────╗
                                                                │                                                              │
                                                                │    ███╗   ███╗ █████╗ ███╗   ██╗███████╗     ██╗ ██████╗     │
                                                                │    ████╗ ████║██╔══██╗████╗  ██║██╔════╝     ██║██╔═══██╗    │
                                                                │    ██╔████╔██║███████║██╔██╗ ██║█████╗       ██║██║   ██║    │
                                                                │    ██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══╝  ██   ██║██║   ██║    │
                                                                │    ██║ ╚═╝ ██║██║  ██║██║ ╚████║███████╗╚█████╔╝╚██████╔╝    │
                                                                │    ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚══════╝ ╚════╝  ╚═════╝     │
                                                                │     █████╗ ██████╗  ██████╗██╗  ██╗██╗██╗   ██╗ ██████╗      │
                                                                │    ██╔══██╗██╔══██╗██╔════╝██║  ██║██║██║   ██║██╔═══██╗     │
                                                                │    ███████║██████╔╝██║     ███████║██║██║   ██║██║   ██║     │
                                                                │    ██╔══██║██╔══██╗██║     ██╔══██║██║╚██╗ ██╔╝██║   ██║     │
                                                                │    ██║  ██║██║  ██║╚██████╗██║  ██║██║ ╚████╔╝ ╚██████╔╝     │
                                                                │    ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═════╝      │
                                                                │                                                              │
                                                                ╚──────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                              ┌───────────────────────────────┐\n");
                    Console.WriteLine("                                                                                   --------- Menu ---------");
                    Console.WriteLine("                                                                                   |- Mostrar datos --- (M)");
                    Console.WriteLine("                                                                                   |- Mostrar Progr --- (R)");
                    Console.WriteLine("                                                                                   |- Buscar datos ---- (B)");
                    Console.WriteLine("                                                                                   |- Agregar dato ---- (A)");
                    Console.WriteLine("                                                                                   |- Eliminar Dato --- (D)");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                                   |- Eliminar Todos -- (T)");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                                   |- Rellenar Facili - (F)");
                    Console.WriteLine("                                                                                   |- Rellenar Progra - (P)");
                    Console.WriteLine("                                                                                   |- Volver ---------- (V)\n");
                    Console.WriteLine("                                                                              └───────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    borrarTodosLosDatos();
                    Console.ReadKey();
                    break;

                case ConsoleKey.F:
                    Console.Clear();
                    Console.WriteLine(@"     
            
            
            



            
                                                                
                                                                ╔──────────────────────────────────────────────────────────────╗
                                                                │                                                              │
                                                                │    ███╗   ███╗ █████╗ ███╗   ██╗███████╗     ██╗ ██████╗     │
                                                                │    ████╗ ████║██╔══██╗████╗  ██║██╔════╝     ██║██╔═══██╗    │
                                                                │    ██╔████╔██║███████║██╔██╗ ██║█████╗       ██║██║   ██║    │
                                                                │    ██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══╝  ██   ██║██║   ██║    │
                                                                │    ██║ ╚═╝ ██║██║  ██║██║ ╚████║███████╗╚█████╔╝╚██████╔╝    │
                                                                │    ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚══════╝ ╚════╝  ╚═════╝     │
                                                                │     █████╗ ██████╗  ██████╗██╗  ██╗██╗██╗   ██╗ ██████╗      │
                                                                │    ██╔══██╗██╔══██╗██╔════╝██║  ██║██║██║   ██║██╔═══██╗     │
                                                                │    ███████║██████╔╝██║     ███████║██║██║   ██║██║   ██║     │
                                                                │    ██╔══██║██╔══██╗██║     ██╔══██║██║╚██╗ ██╔╝██║   ██║     │
                                                                │    ██║  ██║██║  ██║╚██████╗██║  ██║██║ ╚████╔╝ ╚██████╔╝     │
                                                                │    ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═════╝      │
                                                                │                                                              │
                                                                ╚──────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                              ┌───────────────────────────────┐\n");
                    Console.WriteLine("                                                                                   --------- Menu ---------");
                    Console.WriteLine("                                                                                   |- Mostrar datos --- (M)");
                    Console.WriteLine("                                                                                   |- Mostrar Progr --- (R)");
                    Console.WriteLine("                                                                                   |- Buscar datos ---- (B)");
                    Console.WriteLine("                                                                                   |- Agregar dato ---- (A)");
                    Console.WriteLine("                                                                                   |- Eliminar Dato --- (D)");
                    Console.WriteLine("                                                                                   |- Eliminar Todos -- (T)");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                                   |- Rellenar Facili - (F)");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                                   |- Rellenar Progra - (P)");
                    Console.WriteLine("                                                                                   |- Volver ---------- (V)\n");
                    Console.WriteLine("                                                                              └───────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    rellenarListas("f");
                    eliminarLineasVacias();
                    break;

                case ConsoleKey.P:
                    Console.Clear();
                    Console.WriteLine(@"     
            
            
            



            
                                                                
                                                                ╔──────────────────────────────────────────────────────────────╗
                                                                │                                                              │
                                                                │    ███╗   ███╗ █████╗ ███╗   ██╗███████╗     ██╗ ██████╗     │
                                                                │    ████╗ ████║██╔══██╗████╗  ██║██╔════╝     ██║██╔═══██╗    │
                                                                │    ██╔████╔██║███████║██╔██╗ ██║█████╗       ██║██║   ██║    │
                                                                │    ██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══╝  ██   ██║██║   ██║    │
                                                                │    ██║ ╚═╝ ██║██║  ██║██║ ╚████║███████╗╚█████╔╝╚██████╔╝    │
                                                                │    ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚══════╝ ╚════╝  ╚═════╝     │
                                                                │     █████╗ ██████╗  ██████╗██╗  ██╗██╗██╗   ██╗ ██████╗      │
                                                                │    ██╔══██╗██╔══██╗██╔════╝██║  ██║██║██║   ██║██╔═══██╗     │
                                                                │    ███████║██████╔╝██║     ███████║██║██║   ██║██║   ██║     │
                                                                │    ██╔══██║██╔══██╗██║     ██╔══██║██║╚██╗ ██╔╝██║   ██║     │
                                                                │    ██║  ██║██║  ██║╚██████╗██║  ██║██║ ╚████╔╝ ╚██████╔╝     │
                                                                │    ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═════╝      │
                                                                │                                                              │
                                                                ╚──────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                              ┌───────────────────────────────┐\n");
                    Console.WriteLine("                                                                                   --------- Menu ---------");
                    Console.WriteLine("                                                                                   |- Mostrar datos --- (M)");
                    Console.WriteLine("                                                                                   |- Mostrar Progr --- (R)");
                    Console.WriteLine("                                                                                   |- Buscar datos ---- (B)");
                    Console.WriteLine("                                                                                   |- Agregar dato ---- (A)");
                    Console.WriteLine("                                                                                   |- Eliminar Dato --- (D)");
                    Console.WriteLine("                                                                                   |- Eliminar Todos -- (T)");
                    Console.WriteLine("                                                                                   |- Rellenar Facili - (F)");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                                   |- Rellenar Progra - (P)");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                                   |- Volver ---------- (V)\n");
                    Console.WriteLine("                                                                              └───────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    rellenarListas("p");
                    eliminarLineasVacias();
                    break;

                case ConsoleKey.V:
                    Console.Clear();
                    Console.WriteLine(@"     
            
            
            



            
                                                                
                                                                ╔──────────────────────────────────────────────────────────────╗
                                                                │                                                              │
                                                                │    ███╗   ███╗ █████╗ ███╗   ██╗███████╗     ██╗ ██████╗     │
                                                                │    ████╗ ████║██╔══██╗████╗  ██║██╔════╝     ██║██╔═══██╗    │
                                                                │    ██╔████╔██║███████║██╔██╗ ██║█████╗       ██║██║   ██║    │
                                                                │    ██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══╝  ██   ██║██║   ██║    │
                                                                │    ██║ ╚═╝ ██║██║  ██║██║ ╚████║███████╗╚█████╔╝╚██████╔╝    │
                                                                │    ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚══════╝ ╚════╝  ╚═════╝     │
                                                                │     █████╗ ██████╗  ██████╗██╗  ██╗██╗██╗   ██╗ ██████╗      │
                                                                │    ██╔══██╗██╔══██╗██╔════╝██║  ██║██║██║   ██║██╔═══██╗     │
                                                                │    ███████║██████╔╝██║     ███████║██║██║   ██║██║   ██║     │
                                                                │    ██╔══██║██╔══██╗██║     ██╔══██║██║╚██╗ ██╔╝██║   ██║     │
                                                                │    ██║  ██║██║  ██║╚██████╗██║  ██║██║ ╚████╔╝ ╚██████╔╝     │
                                                                │    ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═════╝      │
                                                                │                                                              │
                                                                ╚──────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                              ┌───────────────────────────────┐\n");
                    Console.WriteLine("                                                                                   --------- Menu ---------");
                    Console.WriteLine("                                                                                   |- Mostrar datos --- (M)");
                    Console.WriteLine("                                                                                   |- Mostrar Progr --- (R)");
                    Console.WriteLine("                                                                                   |- Buscar datos ---- (B)");
                    Console.WriteLine("                                                                                   |- Agregar dato ---- (A)");
                    Console.WriteLine("                                                                                   |- Eliminar Dato --- (D)");
                    Console.WriteLine("                                                                                   |- Eliminar Todos -- (T)");
                    Console.WriteLine("                                                                                   |- Rellenar Facili - (F)");
                    Console.WriteLine("                                                                                   |- Rellenar Progra - (P)");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                                   |- Volver ---------- (V)\n");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                              └───────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    manejoArchivo = false;
                    tituloMenuElegir();
                    Console.Clear();
                    break;

                default:
                    continue;
            }
            eliminarLineasVacias();
        } while (manejoArchivo);
    }

    static void buscarUsuario()//extras
    {
        Console.CursorVisible = true;
        eliminarLineasVacias();
        string nombreBuscado;
        do
        {
            Console.Clear();
            Console.WriteLine(@"     
            
            
            
            
            
                                                            ╔───────────────────────────────────────────────────────────────────╗
                                                            │                                                                   │
                                                            │       ██████╗ ██╗   ██╗███████╗ ██████╗ █████╗ ██████╗            │
                                                            │       ██╔══██╗██║   ██║██╔════╝██╔════╝██╔══██╗██╔══██╗           │
                                                            │       ██████╔╝██║   ██║███████╗██║     ███████║██████╔╝           │
                                                            │       ██╔══██╗██║   ██║╚════██║██║     ██╔══██║██╔══██╗           │
                                                            │       ██████╔╝╚██████╔╝███████║╚██████╗██║  ██║██║  ██║           │
                                                            │       ╚═════╝  ╚═════╝ ╚══════╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝           │
                                                            │    █████╗ ██╗     ██╗   ██╗███╗   ███╗███╗   ██╗       ██████╗    │
                                                            │   ██╔══██╗██║     ██║   ██║████╗ ████║████╗  ██║      ██╔═══██╗   │
                                                            │   ███████║██║     ██║   ██║██╔████╔██║██╔██╗ ██║█████╗██║   ██║   │
                                                            │   ██╔══██║██║     ██║   ██║██║╚██╔╝██║██║╚██╗██║╚════╝██║   ██║   │
                                                            │   ██║  ██║███████╗╚██████╔╝██║ ╚═╝ ██║██║ ╚████║      ╚██████╔╝   │
                                                            │   ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═══╝       ╚═════╝    │
                                                            │                                                                   │
                                                            ╚───────────────────────────────────────────────────────────────────╝");
            Console.Write("                                                                      ---------[ Ingresa el nombre del estudiante: ");
            nombreBuscado = limiteEscribir(12)!.Trim();//!.Trim() pasa los null y elimina los espacios
            barraCarga(79, 24);

            if (string.IsNullOrEmpty(nombreBuscado))
            {
                Console.WriteLine("\n                                                                 ---------[ Debes de ingresar al menos un letra para buscar.");
                Console.ReadKey();
            }
        } while (string.IsNullOrEmpty(nombreBuscado));

        Console.WriteLine();

        bool encontrado = false;

        if (File.Exists(listaEstudianteFacilitador))
        {
            string[] lineasFacilitador = File.ReadAllLines(listaEstudianteFacilitador);
            for (int i = 0; i < lineasFacilitador.Length; i++)
            {
                if (lineasFacilitador[i].Contains(nombreBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"                                                                    Facilitador - Línea {i + 1}: {lineasFacilitador[i]}");
                    encontrado = true;
                }
            }
        }

        if (File.Exists(listaEstudianteProgramador))
        {
            string[] lineasProgramador = File.ReadAllLines(listaEstudianteProgramador);
            for (int i = 0; i < lineasProgramador.Length; i++)
            {
                if (lineasProgramador[i].Contains(nombreBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"                                                                    Programador - Línea {i + 1}: {lineasProgramador[i]}");
                    encontrado = true;
                }
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("                                                                          ---------[ Estudiante no encontrado.");
        }
        Console.CursorVisible = false;

        Console.WriteLine("\n                                                            ---------[ Siguiente (S)");
        var key = Console.ReadKey(true).Key;
        do
        {
            key = Console.ReadKey(true).Key;
        } while (key != ConsoleKey.S);
    }
    static void mostrarDatos()
    {
        //guardar la info del teclado
        ConsoleKeyInfo key;
        do
        {
            Console.Clear();
            eliminarLineasVacias();
            while (true)
            {
                eliminarLineasVacias();
                if (File.Exists(listaEstudianteFacilitador) && File.Exists(listaEstudianteProgramador))
                {
                    string[] lineasFacilitador = File.ReadAllLines(listaEstudianteFacilitador);
                    string[] lineasProgramador = File.ReadAllLines(listaEstudianteProgramador);
                    int filas = Math.Max(lineasFacilitador.Length, lineasProgramador.Length);

                    Console.WriteLine(@"
                    
                    
                                    ╔───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╗
                                    │                                                                                                                           │
                                    │    ██╗     ██╗███████╗████████╗ █████╗     ██████╗ ███████╗     █████╗ ██╗     ██╗   ██╗███╗   ███╗███╗   ██╗ ██████╗     │
                                    │    ██║     ██║██╔════╝╚══██╔══╝██╔══██╗    ██╔══██╗██╔════╝    ██╔══██╗██║     ██║   ██║████╗ ████║████╗  ██║██╔═══██╗    │
                                    │    ██║     ██║███████╗   ██║   ███████║    ██║  ██║█████╗      ███████║██║     ██║   ██║██╔████╔██║██╔██╗ ██║██║   ██║    │
                                    │    ██║     ██║╚════██║   ██║   ██╔══██║    ██║  ██║██╔══╝      ██╔══██║██║     ██║   ██║██║╚██╔╝██║██║╚██╗██║██║   ██║    │
                                    │    ███████╗██║███████║   ██║   ██║  ██║    ██████╔╝███████╗    ██║  ██║███████╗╚██████╔╝██║ ╚═╝ ██║██║ ╚████║╚██████╔╝    │
                                    │    ╚══════╝╚═╝╚══════╝   ╚═╝   ╚═╝  ╚═╝    ╚═════╝ ╚══════╝    ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═══╝ ╚═════╝     │
                                    │                                                                                                                           │
                                    ╚───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                         Facilitador                                     Programador\n");
                    for (int i = 0; i < filas; i++)
                    {
                        if (i < lineasFacilitador.Length)
                        {
                            Console.Write($"                                                         {i + 1} - {lineasFacilitador[i].PadRight(40)}");
                        }
                        else
                        {
                            Console.Write("                                                                                                     ".PadRight(40));
                        }

                        Console.Write("\t");

                        if (i < lineasProgramador.Length)
                        {
                            Console.Write($"{i + 1} - {lineasProgramador[i]}");
                        }

                        Console.WriteLine();
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Uno o ambos archivos no existen.");
                    Console.ReadKey();
                    break;
                }
            }
            Console.WriteLine("\n                                    ---------[ Salir (S)");
            key = Console.ReadKey(true);
        } while (key.Key != ConsoleKey.S);
    }
    static void agregarDato()
    {
        eliminarLineasVacias();
        bool agregarDato = true;
        do
        {
            Console.Clear();
            Console.WriteLine(@"
            
            
            
            
            
            
                                                            
                                                            
                                                            
                                                            
                                                            
                                                               ╔──────────────────────────────────────────────────────────────╗
                                                               │                                                              │
                                                               │   █████╗  ██████╗ ██████╗ ███████╗ ██████╗  █████╗ ██████╗   │
                                                               │  ██╔══██╗██╔════╝ ██╔══██╗██╔════╝██╔════╝ ██╔══██╗██╔══██╗  │
                                                               │  ███████║██║  ███╗██████╔╝█████╗  ██║  ███╗███████║██████╔╝  │
                                                               │  ██╔══██║██║   ██║██╔══██╗██╔══╝  ██║   ██║██╔══██║██╔══██╗  │
                                                               │  ██║  ██║╚██████╔╝██║  ██║███████╗╚██████╔╝██║  ██║██║  ██║  │
                                                               │  ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝  │
                                                               │              ██████╗  █████╗ ████████╗ ██████╗               │
                                                               │              ██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗              │
                                                               │              ██║  ██║███████║   ██║   ██║   ██║              │
                                                               │              ██║  ██║██╔══██║   ██║   ██║   ██║              │
                                                               │              ██████╔╝██║  ██║   ██║   ╚██████╔╝              │
                                                               │              ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝               │
                                                               │                                                              │
                                                               ╚──────────────────────────────────────────────────────────────╝");
            Console.WriteLine("                                                                           ┌──────────────────────────────────────┐\n");
            Console.WriteLine("                                                                               ------------- Menu -------------");
            Console.WriteLine("                                                                               |- Agregar a Facilitador --- (F)");
            Console.WriteLine("                                                                               |- Agregar a Programador --- (P)");
            Console.WriteLine("                                                                               |- Agregar a las dos ------- (D)");
            Console.WriteLine("                                                                               |- Volver ------------------ (V)\n");
            Console.WriteLine("                                                                           └──────────────────────────────────────┘\n");
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.F:
                    Console.Clear();
                    Console.WriteLine(@"
            
            
            
            
            
            
                                                            
                                                            
                                                            
                                                            
                                                            
                                                               ╔──────────────────────────────────────────────────────────────╗
                                                               │                                                              │
                                                               │   █████╗  ██████╗ ██████╗ ███████╗ ██████╗  █████╗ ██████╗   │
                                                               │  ██╔══██╗██╔════╝ ██╔══██╗██╔════╝██╔════╝ ██╔══██╗██╔══██╗  │
                                                               │  ███████║██║  ███╗██████╔╝█████╗  ██║  ███╗███████║██████╔╝  │
                                                               │  ██╔══██║██║   ██║██╔══██╗██╔══╝  ██║   ██║██╔══██║██╔══██╗  │
                                                               │  ██║  ██║╚██████╔╝██║  ██║███████╗╚██████╔╝██║  ██║██║  ██║  │
                                                               │  ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝  │
                                                               │              ██████╗  █████╗ ████████╗ ██████╗               │
                                                               │              ██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗              │
                                                               │              ██║  ██║███████║   ██║   ██║   ██║              │
                                                               │              ██║  ██║██╔══██║   ██║   ██║   ██║              │
                                                               │              ██████╔╝██║  ██║   ██║   ╚██████╔╝              │
                                                               │              ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝               │
                                                               │                                                              │
                                                               ╚──────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                           ┌──────────────────────────────────────┐\n");
                    Console.WriteLine("                                                                               ------------- Menu -------------");
                    ConsoleColor currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                               |- Agregar a Facilitador --- (F)");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                               |- Agregar a Programador --- (P)");
                    Console.WriteLine("                                                                               |- Agregar a las dos ------- (D)");
                    Console.WriteLine("                                                                               |- Volver ------------------ (V)\n");
                    Console.WriteLine("                                                                           └──────────────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    Console.CursorVisible = true;
                    Console.Clear();
                    Console.WriteLine(@"
                    
                    
                    
                    
                    
                    
                    
                    
                                                        ╔────────────────────────────────────────────────────────────────────────────────────╗
                                                        │                                                                                    │
                                                        │       █████╗  ██████╗ ██████╗ ███████╗ ██████╗  █████╗ ██████╗      █████╗         │
                                                        │      ██╔══██╗██╔════╝ ██╔══██╗██╔════╝██╔════╝ ██╔══██╗██╔══██╗    ██╔══██╗        │
                                                        │      ███████║██║  ███╗██████╔╝█████╗  ██║  ███╗███████║██████╔╝    ███████║        │
                                                        │      ██╔══██║██║   ██║██╔══██╗██╔══╝  ██║   ██║██╔══██║██╔══██╗    ██╔══██║        │
                                                        │      ██║  ██║╚██████╔╝██║  ██║███████╗╚██████╔╝██║  ██║██║  ██║    ██║  ██║        │
                                                        │      ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝    ╚═╝  ╚═╝        │
                                                        │  ███████╗ █████╗  ██████╗██╗██╗     ██╗████████╗ █████╗ ██████╗  ██████╗ ██████╗   │
                                                        │  ██╔════╝██╔══██╗██╔════╝██║██║     ██║╚══██╔══╝██╔══██╗██╔══██╗██╔═══██╗██╔══██╗  │
                                                        │  █████╗  ███████║██║     ██║██║     ██║   ██║   ███████║██║  ██║██║   ██║██████╔╝  │
                                                        │  ██╔══╝  ██╔══██║██║     ██║██║     ██║   ██║   ██╔══██║██║  ██║██║   ██║██╔══██╗  │
                                                        │  ██║     ██║  ██║╚██████╗██║███████╗██║   ██║   ██║  ██║██████╔╝╚██████╔╝██║  ██║  │
                                                        │  ╚═╝     ╚═╝  ╚═╝ ╚═════╝╚═╝╚══════╝╚═╝   ╚═╝   ╚═╝  ╚═╝╚═════╝  ╚═════╝ ╚═╝  ╚═╝  │
                                                        │                                                                                    │
                                                        ╚────────────────────────────────────────────────────────────────────────────────────╝");
                    Console.Write("                                                             ---------[ Ingresa el nuevo dato: ");
                    string dato = limiteEscribir(44);
                    string textoAAnadir = $"{Environment.NewLine}{dato}";
                    File.AppendAllText(listaEstudianteFacilitador, textoAAnadir);
                    barraCarga(83, 27);
                    Console.ReadKey();
                    eliminarLineasVacias();
                    Console.CursorVisible = false;
                    break;

                case ConsoleKey.P:
                    Console.Clear();
                    Console.WriteLine(@"
            
            
            
            
            
            
                                                            
                                                            
                                                            
                                                            
                                                            
                                                               ╔──────────────────────────────────────────────────────────────╗
                                                               │                                                              │
                                                               │   █████╗  ██████╗ ██████╗ ███████╗ ██████╗  █████╗ ██████╗   │
                                                               │  ██╔══██╗██╔════╝ ██╔══██╗██╔════╝██╔════╝ ██╔══██╗██╔══██╗  │
                                                               │  ███████║██║  ███╗██████╔╝█████╗  ██║  ███╗███████║██████╔╝  │
                                                               │  ██╔══██║██║   ██║██╔══██╗██╔══╝  ██║   ██║██╔══██║██╔══██╗  │
                                                               │  ██║  ██║╚██████╔╝██║  ██║███████╗╚██████╔╝██║  ██║██║  ██║  │
                                                               │  ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝  │
                                                               │              ██████╗  █████╗ ████████╗ ██████╗               │
                                                               │              ██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗              │
                                                               │              ██║  ██║███████║   ██║   ██║   ██║              │
                                                               │              ██║  ██║██╔══██║   ██║   ██║   ██║              │
                                                               │              ██████╔╝██║  ██║   ██║   ╚██████╔╝              │
                                                               │              ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝               │
                                                               │                                                              │
                                                               ╚──────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                           ┌──────────────────────────────────────┐\n");
                    Console.WriteLine("                                                                               ------------- Menu -------------");
                    Console.WriteLine("                                                                               |- Agregar a Facilitador --- (F)");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                               |- Agregar a Programador --- (P)");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                               |- Agregar a las dos ------- (D)");
                    Console.WriteLine("                                                                               |- Volver ------------------ (V)\n");
                    Console.WriteLine("                                                                           └──────────────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    Console.CursorVisible = true;
                    Console.Clear();
                    Console.WriteLine(@"   

                    
                    
                    
                    
                    
                    
                    
                                              ╔──────────────────────────────────────────────────────────────────────────────────────────────────╗
                                              │                                                                                                  │
                                              │               █████╗  ██████╗ ██████╗ ███████╗ ██████╗  █████╗ ██████╗      █████╗               │
                                              │              ██╔══██╗██╔════╝ ██╔══██╗██╔════╝██╔════╝ ██╔══██╗██╔══██╗    ██╔══██╗              │
                                              │              ███████║██║  ███╗██████╔╝█████╗  ██║  ███╗███████║██████╔╝    ███████║              │
                                              │              ██╔══██║██║   ██║██╔══██╗██╔══╝  ██║   ██║██╔══██║██╔══██╗    ██╔══██║              │
                                              │              ██║  ██║╚██████╔╝██║  ██║███████╗╚██████╔╝██║  ██║██║  ██║    ██║  ██║              │
                                              │              ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝    ╚═╝  ╚═╝              │
                                              │  ██████╗ ██████╗  ██████╗  ██████╗ ██████╗  █████╗ ███╗   ███╗ █████╗ ██████╗  ██████╗ ██████╗   │
                                              │  ██╔══██╗██╔══██╗██╔═══██╗██╔════╝ ██╔══██╗██╔══██╗████╗ ████║██╔══██╗██╔══██╗██╔═══██╗██╔══██╗  │
                                              │  ██████╔╝██████╔╝██║   ██║██║  ███╗██████╔╝███████║██╔████╔██║███████║██║  ██║██║   ██║██████╔╝  │
                                              │  ██╔═══╝ ██╔══██╗██║   ██║██║   ██║██╔══██╗██╔══██║██║╚██╔╝██║██╔══██║██║  ██║██║   ██║██╔══██╗  │
                                              │  ██║     ██║  ██║╚██████╔╝╚██████╔╝██║  ██║██║  ██║██║ ╚═╝ ██║██║  ██║██████╔╝╚██████╔╝██║  ██║  │
                                              │  ╚═╝     ╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝  ╚═╝╚═════╝  ╚═════╝ ╚═╝  ╚═╝  │
                                              │                                                                                                  │
                                              ╚──────────────────────────────────────────────────────────────────────────────────────────────────╝");
                    Console.Write("                                                             ---------[ Ingresa el nuevo dato: ");
                    dato = limiteEscribir(44);
                    textoAAnadir = $"{Environment.NewLine}{dato}";
                    File.AppendAllText(listaEstudianteProgramador, textoAAnadir);
                    barraCarga(83, 27);
                    Console.ReadKey();
                    eliminarLineasVacias();
                    Console.CursorVisible = false;
                    break;

                case ConsoleKey.D:
                    Console.Clear();
                    Console.WriteLine(@"
            
            
            
            
            
            
                                                            
                                                            
                                                            
                                                            
                                                            
                                                               ╔──────────────────────────────────────────────────────────────╗
                                                               │                                                              │
                                                               │   █████╗  ██████╗ ██████╗ ███████╗ ██████╗  █████╗ ██████╗   │
                                                               │  ██╔══██╗██╔════╝ ██╔══██╗██╔════╝██╔════╝ ██╔══██╗██╔══██╗  │
                                                               │  ███████║██║  ███╗██████╔╝█████╗  ██║  ███╗███████║██████╔╝  │
                                                               │  ██╔══██║██║   ██║██╔══██╗██╔══╝  ██║   ██║██╔══██║██╔══██╗  │
                                                               │  ██║  ██║╚██████╔╝██║  ██║███████╗╚██████╔╝██║  ██║██║  ██║  │
                                                               │  ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝  │
                                                               │              ██████╗  █████╗ ████████╗ ██████╗               │
                                                               │              ██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗              │
                                                               │              ██║  ██║███████║   ██║   ██║   ██║              │
                                                               │              ██║  ██║██╔══██║   ██║   ██║   ██║              │
                                                               │              ██████╔╝██║  ██║   ██║   ╚██████╔╝              │
                                                               │              ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝               │
                                                               │                                                              │
                                                               ╚──────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                           ┌──────────────────────────────────────┐\n");
                    Console.WriteLine("                                                                               ------------- Menu -------------");
                    Console.WriteLine("                                                                               |- Agregar a Facilitador --- (F)");
                    Console.WriteLine("                                                                               |- Agregar a Programador --- (P)");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                               |- Agregar a las dos ------- (D)");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                               |- Volver ------------------ (V)\n");
                    Console.WriteLine("                                                                           └──────────────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    Console.CursorVisible = true;
                    Console.Clear();
                    Console.WriteLine(@" 









                    
                                                            ╔───────────────────────────────────────────────────────────────────╗
                                                            │                                                                   │
                                                            │      █████╗  ██████╗ ██████╗ ███████╗ ██████╗  █████╗ ██████╗     │
                                                            │     ██╔══██╗██╔════╝ ██╔══██╗██╔════╝██╔════╝ ██╔══██╗██╔══██╗    │
                                                            │     ███████║██║  ███╗██████╔╝█████╗  ██║  ███╗███████║██████╔╝    │
                                                            │     ██╔══██║██║   ██║██╔══██╗██╔══╝  ██║   ██║██╔══██║██╔══██╗    │
                                                            │     ██║  ██║╚██████╔╝██║  ██║███████╗╚██████╔╝██║  ██║██║  ██║    │
                                                            │     ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝    │
                                                            │  █████╗     ██╗      █████╗ ███████╗    ██████╗  ██████╗ ███████╗ │
                                                            │ ██╔══██╗    ██║     ██╔══██╗██╔════╝    ██╔══██╗██╔═══██╗██╔════╝ │
                                                            │ ███████║    ██║     ███████║███████╗    ██║  ██║██║   ██║███████╗ │
                                                            │ ██╔══██║    ██║     ██╔══██║╚════██║    ██║  ██║██║   ██║╚════██║ │
                                                            │ ██║  ██║    ███████╗██║  ██║███████║    ██████╔╝╚██████╔╝███████║ │
                                                            │ ╚═╝  ╚═╝    ╚══════╝╚═╝  ╚═╝╚══════╝    ╚═════╝  ╚═════╝ ╚══════╝ │
                                                            │                                                                   │
                                                            ╚───────────────────────────────────────────────────────────────────╝");
                    Console.Write("                                                             ---------[ Ingresa el nuevo dato: ");
                    dato = limiteEscribir(32);
                    textoAAnadir = $"{Environment.NewLine}{dato}";
                    File.AppendAllText(listaEstudianteFacilitador, textoAAnadir);
                    File.AppendAllText(listaEstudianteProgramador, textoAAnadir);
                    barraCarga(80, 29);
                    Console.ReadKey();
                    eliminarLineasVacias();
                    Console.CursorVisible = false;
                    break;

                case ConsoleKey.V:
                    Console.Clear();
                    Console.WriteLine(@"
            
            
            
            
            
            
                                                            
                                                            
                                                            
                                                            
                                                            
                                                               ╔──────────────────────────────────────────────────────────────╗
                                                               │                                                              │
                                                               │   █████╗  ██████╗ ██████╗ ███████╗ ██████╗  █████╗ ██████╗   │
                                                               │  ██╔══██╗██╔════╝ ██╔══██╗██╔════╝██╔════╝ ██╔══██╗██╔══██╗  │
                                                               │  ███████║██║  ███╗██████╔╝█████╗  ██║  ███╗███████║██████╔╝  │
                                                               │  ██╔══██║██║   ██║██╔══██╗██╔══╝  ██║   ██║██╔══██║██╔══██╗  │
                                                               │  ██║  ██║╚██████╔╝██║  ██║███████╗╚██████╔╝██║  ██║██║  ██║  │
                                                               │  ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝  │
                                                               │              ██████╗  █████╗ ████████╗ ██████╗               │
                                                               │              ██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗              │
                                                               │              ██║  ██║███████║   ██║   ██║   ██║              │
                                                               │              ██║  ██║██╔══██║   ██║   ██║   ██║              │
                                                               │              ██████╔╝██║  ██║   ██║   ╚██████╔╝              │
                                                               │              ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝               │
                                                               │                                                              │
                                                               ╚──────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                           ┌──────────────────────────────────────┐\n");
                    Console.WriteLine("                                                                               ------------- Menu -------------");
                    Console.WriteLine("                                                                               |- Agregar a Facilitador --- (F)");
                    Console.WriteLine("                                                                               |- Agregar a Programador --- (P)");
                    Console.WriteLine("                                                                               |- Agregar a las dos ------- (D)");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                               |- Volver ------------------ (V)\n");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                           └──────────────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    eliminarLineasVacias();
                    agregarDato = false;
                    Console.Clear();
                    break;

                default:
                    continue;
            }
        } while (agregarDato);
        Console.CursorVisible = false;
    }
    static void borrarDatoEspecifico()
    {
        eliminarLineasVacias();
        bool borrarDatosEspecificos = true;
        do
        {
            Console.Clear();
            Console.WriteLine(@"   
            
            
            
            
            
            
            
            
            
            
                                                ╔─────────────────────────────────────────────────────────────────────────────────────────╗
                                                │                                                                                         │
                                                │ ██████╗  ██████╗ ██████╗ ██████╗  █████╗ ██████╗     ██████╗  █████╗ ████████╗ ██████╗  │
                                                │ ██╔══██╗██╔═══██╗██╔══██╗██╔══██╗██╔══██╗██╔══██╗    ██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗ │
                                                │ ██████╔╝██║   ██║██████╔╝██████╔╝███████║██████╔╝    ██║  ██║███████║   ██║   ██║   ██║ │
                                                │ ██╔══██╗██║   ██║██╔══██╗██╔══██╗██╔══██║██╔══██╗    ██║  ██║██╔══██║   ██║   ██║   ██║ │
                                                │ ██████╔╝╚██████╔╝██║  ██║██║  ██║██║  ██║██║  ██║    ██████╔╝██║  ██║   ██║   ╚██████╔╝ │
                                                │ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝  │
                                                │         ███████╗███████╗██████╗ ███████╗ ██████╗███████╗██╗ ██████╗ ██████╗             │
                                                │         ██╔════╝██╔════╝██╔══██╗██╔════╝██╔════╝██╔════╝██║██╔════╝██╔═══██╗            │
                                                │         █████╗  ███████╗██████╔╝█████╗  ██║     █████╗  ██║██║     ██║   ██║            │
                                                │         ██╔══╝  ╚════██║██╔═══╝ ██╔══╝  ██║     ██╔══╝  ██║██║     ██║   ██║            │
                                                │         ███████╗███████║██║     ███████╗╚██████╗██║     ██║╚██████╗╚██████╔╝            │
                                                │         ╚══════╝╚══════╝╚═╝     ╚══════╝ ╚═════╝╚═╝     ╚═╝ ╚═════╝ ╚═════╝             │
                                                │                                                                                         │
                                                ╚─────────────────────────────────────────────────────────────────────────────────────────╝");
            Console.WriteLine("                                                                     ┌────────────────────────────────────────────────┐\n");
            Console.WriteLine("                                                                           ----------------- Menu ---------------");
            Console.WriteLine("                                                                           |- Eliminar alumno Facilitador --- (F)");
            Console.WriteLine("                                                                           |- Eliminar alumno Programador --- (P)");
            Console.WriteLine("                                                                           |- Volver ------------------------ (V)\n");
            Console.WriteLine("                                                                     └────────────────────────────────────────────────┘\n");
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.F:
                    Console.Clear();
                    Console.WriteLine(@"   
            
            
            
            
            
            
            
            
            
            
                                                ╔─────────────────────────────────────────────────────────────────────────────────────────╗
                                                │                                                                                         │
                                                │ ██████╗  ██████╗ ██████╗ ██████╗  █████╗ ██████╗     ██████╗  █████╗ ████████╗ ██████╗  │
                                                │ ██╔══██╗██╔═══██╗██╔══██╗██╔══██╗██╔══██╗██╔══██╗    ██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗ │
                                                │ ██████╔╝██║   ██║██████╔╝██████╔╝███████║██████╔╝    ██║  ██║███████║   ██║   ██║   ██║ │
                                                │ ██╔══██╗██║   ██║██╔══██╗██╔══██╗██╔══██║██╔══██╗    ██║  ██║██╔══██║   ██║   ██║   ██║ │
                                                │ ██████╔╝╚██████╔╝██║  ██║██║  ██║██║  ██║██║  ██║    ██████╔╝██║  ██║   ██║   ╚██████╔╝ │
                                                │ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝  │
                                                │         ███████╗███████╗██████╗ ███████╗ ██████╗███████╗██╗ ██████╗ ██████╗             │
                                                │         ██╔════╝██╔════╝██╔══██╗██╔════╝██╔════╝██╔════╝██║██╔════╝██╔═══██╗            │
                                                │         █████╗  ███████╗██████╔╝█████╗  ██║     █████╗  ██║██║     ██║   ██║            │
                                                │         ██╔══╝  ╚════██║██╔═══╝ ██╔══╝  ██║     ██╔══╝  ██║██║     ██║   ██║            │
                                                │         ███████╗███████║██║     ███████╗╚██████╗██║     ██║╚██████╗╚██████╔╝            │
                                                │         ╚══════╝╚══════╝╚═╝     ╚══════╝ ╚═════╝╚═╝     ╚═╝ ╚═════╝ ╚═════╝             │
                                                │                                                                                         │
                                                ╚─────────────────────────────────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                     ┌────────────────────────────────────────────────┐\n");
                    Console.WriteLine("                                                                           ----------------- Menu ---------------");
                    ConsoleColor currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                           |- Eliminar alumno Facilitador --- (F)");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                           |- Eliminar alumno Programador --- (P)");
                    Console.WriteLine("                                                                           |- Volver ------------------------ (V)\n");
                    Console.WriteLine("                                                                     └────────────────────────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    Console.CursorVisible = true;
                    eliminarLineasVacias();
                    Console.Clear();
                    if (File.Exists(listaEstudianteFacilitador))
                    {
                        string[] lineas = File.ReadAllLines(listaEstudianteFacilitador);
                        mostrarDatos();

                        if (lineas.Length == 0)
                        {
                            Console.WriteLine("                                    ---------[ La lista está vacía.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Write("\n                                    ---------[ Ingresa el número para eliminar: ");
                            if (int.TryParse(limiteEscribir(10), out int numero) && numero > 0 && numero <= lineas.Length)
                            {
                                using (StreamWriter escritor = new StreamWriter(listaEstudianteFacilitador))
                                {
                                    for (int i = 0; i < lineas.Length; i++)
                                    {
                                        if (i != numero - 1)
                                        {
                                            escritor.WriteLine(lineas[i]);
                                        }
                                    }
                                }
                                Console.WriteLine("\n                                    ---------[ Dato borrado.");
                            }
                            else
                            {
                                Console.WriteLine("                                    ---------[ Número no válido.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("                                    ---------[ No hay datos para borrar.");
                    }
                    Console.ReadKey();
                    Console.CursorVisible = false;
                    Console.Clear();
                    barraCarga(80, 25);
                    break;

                case ConsoleKey.P:
                    Console.Clear();
                    Console.WriteLine(@"   
            
            
            
            
            
            
            
            
            
            
                                                ╔─────────────────────────────────────────────────────────────────────────────────────────╗
                                                │                                                                                         │
                                                │ ██████╗  ██████╗ ██████╗ ██████╗  █████╗ ██████╗     ██████╗  █████╗ ████████╗ ██████╗  │
                                                │ ██╔══██╗██╔═══██╗██╔══██╗██╔══██╗██╔══██╗██╔══██╗    ██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗ │
                                                │ ██████╔╝██║   ██║██████╔╝██████╔╝███████║██████╔╝    ██║  ██║███████║   ██║   ██║   ██║ │
                                                │ ██╔══██╗██║   ██║██╔══██╗██╔══██╗██╔══██║██╔══██╗    ██║  ██║██╔══██║   ██║   ██║   ██║ │
                                                │ ██████╔╝╚██████╔╝██║  ██║██║  ██║██║  ██║██║  ██║    ██████╔╝██║  ██║   ██║   ╚██████╔╝ │
                                                │ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝  │
                                                │         ███████╗███████╗██████╗ ███████╗ ██████╗███████╗██╗ ██████╗ ██████╗             │
                                                │         ██╔════╝██╔════╝██╔══██╗██╔════╝██╔════╝██╔════╝██║██╔════╝██╔═══██╗            │
                                                │         █████╗  ███████╗██████╔╝█████╗  ██║     █████╗  ██║██║     ██║   ██║            │
                                                │         ██╔══╝  ╚════██║██╔═══╝ ██╔══╝  ██║     ██╔══╝  ██║██║     ██║   ██║            │
                                                │         ███████╗███████║██║     ███████╗╚██████╗██║     ██║╚██████╗╚██████╔╝            │
                                                │         ╚══════╝╚══════╝╚═╝     ╚══════╝ ╚═════╝╚═╝     ╚═╝ ╚═════╝ ╚═════╝             │
                                                │                                                                                         │
                                                ╚─────────────────────────────────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                     ┌────────────────────────────────────────────────┐\n");
                    Console.WriteLine("                                                                           ----------------- Menu ---------------");
                    Console.WriteLine("                                                                           |- Eliminar alumno Facilitador --- (F)");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                           |- Eliminar alumno Programador --- (P)");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                           |- Volver ------------------------ (V)\n");
                    Console.WriteLine("                                                                     └────────────────────────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    Console.CursorVisible = true;
                    eliminarLineasVacias();
                    Console.Clear();
                    if (File.Exists(listaEstudianteProgramador))
                    {
                        string[] lineas = File.ReadAllLines(listaEstudianteProgramador);
                        mostrarDatos();

                        if (lineas.Length == 0)
                        {
                            Console.WriteLine("                                    ---------[ La lista está vacía.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Write("\n                                    ---------[ Ingresa el número para eliminar: ");
                            if (int.TryParse(Console.ReadLine(), out int numero) && numero > 0 && numero <= lineas.Length)
                            {
                                using (StreamWriter escritor = new StreamWriter(listaEstudianteProgramador))
                                {
                                    for (int i = 0; i < lineas.Length; i++)
                                    {
                                        if (i != numero - 1)
                                        {
                                            escritor.WriteLine(lineas[i]);
                                        }
                                    }
                                }
                                Console.WriteLine("\n                                    ---------[ Dato borrado.");
                            }
                            else
                            {
                                Console.WriteLine("                                    ---------[ Número no válido.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("                                    ---------[ No hay datos para borrar.");
                    }
                    Console.ReadKey();
                    Console.CursorVisible = false;
                    Console.Clear();
                    barraCarga(80, 25);
                    break;

                case ConsoleKey.V:
                    Console.Clear();
                    Console.WriteLine(@"   
            
            
            
            
            
            
            
            
            
            
                                                ╔─────────────────────────────────────────────────────────────────────────────────────────╗
                                                │                                                                                         │
                                                │ ██████╗  ██████╗ ██████╗ ██████╗  █████╗ ██████╗     ██████╗  █████╗ ████████╗ ██████╗  │
                                                │ ██╔══██╗██╔═══██╗██╔══██╗██╔══██╗██╔══██╗██╔══██╗    ██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗ │
                                                │ ██████╔╝██║   ██║██████╔╝██████╔╝███████║██████╔╝    ██║  ██║███████║   ██║   ██║   ██║ │
                                                │ ██╔══██╗██║   ██║██╔══██╗██╔══██╗██╔══██║██╔══██╗    ██║  ██║██╔══██║   ██║   ██║   ██║ │
                                                │ ██████╔╝╚██████╔╝██║  ██║██║  ██║██║  ██║██║  ██║    ██████╔╝██║  ██║   ██║   ╚██████╔╝ │
                                                │ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝  │
                                                │         ███████╗███████╗██████╗ ███████╗ ██████╗███████╗██╗ ██████╗ ██████╗             │
                                                │         ██╔════╝██╔════╝██╔══██╗██╔════╝██╔════╝██╔════╝██║██╔════╝██╔═══██╗            │
                                                │         █████╗  ███████╗██████╔╝█████╗  ██║     █████╗  ██║██║     ██║   ██║            │
                                                │         ██╔══╝  ╚════██║██╔═══╝ ██╔══╝  ██║     ██╔══╝  ██║██║     ██║   ██║            │
                                                │         ███████╗███████║██║     ███████╗╚██████╗██║     ██║╚██████╗╚██████╔╝            │
                                                │         ╚══════╝╚══════╝╚═╝     ╚══════╝ ╚═════╝╚═╝     ╚═╝ ╚═════╝ ╚═════╝             │
                                                │                                                                                         │
                                                ╚─────────────────────────────────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                     ┌────────────────────────────────────────────────┐\n");
                    Console.WriteLine("                                                                           ----------------- Menu ---------------");
                    Console.WriteLine("                                                                           |- Eliminar alumno Facilitador --- (F)");
                    Console.WriteLine("                                                                           |- Eliminar alumno Programador --- (P)");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                           |- Volver ------------------------ (V)\n");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                     └────────────────────────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    borrarDatosEspecificos = false;
                    Console.Clear();
                    break;

                default:
                    continue;
            }
        } while (borrarDatosEspecificos);
        Console.CursorVisible = false;
    }
    static void borrarTodosLosDatos()//extra
    {
        bool validKey = true;
        eliminarLineasVacias();
        do
        {
            Console.Clear();
            Console.WriteLine(@"
            
            
            
            
            
            
            
            
                                                ╔──────────────────────────────────────────────────────────────────────────────────────────────────╗
                                                │                                                                                                  │
                                                │ ██████╗  ██████╗ ██████╗ ██████╗  █████╗ ██████╗     ████████╗ ██████╗ ██████╗  ██████╗ ███████╗ │
                                                │ ██╔══██╗██╔═══██╗██╔══██╗██╔══██╗██╔══██╗██╔══██╗    ╚══██╔══╝██╔═══██╗██╔══██╗██╔═══██╗██╔════╝ │
                                                │ ██████╔╝██║   ██║██████╔╝██████╔╝███████║██████╔╝       ██║   ██║   ██║██║  ██║██║   ██║███████╗ │
                                                │ ██╔══██╗██║   ██║██╔══██╗██╔══██╗██╔══██║██╔══██╗       ██║   ██║   ██║██║  ██║██║   ██║╚════██║ │
                                                │ ██████╔╝╚██████╔╝██║  ██║██║  ██║██║  ██║██║  ██║       ██║   ╚██████╔╝██████╔╝╚██████╔╝███████║ │
                                                │ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝       ╚═╝    ╚═════╝ ╚═════╝  ╚═════╝ ╚══════╝ │
                                                │             ██╗      ██████╗ ███████╗    ██████╗  █████╗ ████████╗ ██████╗ ███████╗              │
                                                │             ██║     ██╔═══██╗██╔════╝    ██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗██╔════╝              │
                                                │             ██║     ██║   ██║███████╗    ██║  ██║███████║   ██║   ██║   ██║███████╗              │
                                                │             ██║     ██║   ██║╚════██║    ██║  ██║██╔══██║   ██║   ██║   ██║╚════██║              │
                                                │             ███████╗╚██████╔╝███████║    ██████╔╝██║  ██║   ██║   ╚██████╔╝███████║              │
                                                │             ╚══════╝ ╚═════╝ ╚══════╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚══════╝              │
                                                │                                                                                                  │
                                                ╚──────────────────────────────────────────────────────────────────────────────────────────────────╝");
            Console.WriteLine("                                                                         ┌────────────────────────────────────────────────┐\n");
            Console.WriteLine("                                                                             ----------------- Menu ---------------");
            Console.WriteLine("                                                                             |- Eliminar Archivo Facilitador --- (F)");
            Console.WriteLine("                                                                             |- Eliminar Archivo Programador --- (P)");
            Console.WriteLine("                                                                             |- Volver ------------------------- (V)\n");
            Console.WriteLine("                                                                         └────────────────────────────────────────────────┘\n");

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.F:
                    Console.Clear();
                    Console.WriteLine(@"
            
            
            
            
            
            
            
            
                                                ╔──────────────────────────────────────────────────────────────────────────────────────────────────╗
                                                │                                                                                                  │
                                                │ ██████╗  ██████╗ ██████╗ ██████╗  █████╗ ██████╗     ████████╗ ██████╗ ██████╗  ██████╗ ███████╗ │
                                                │ ██╔══██╗██╔═══██╗██╔══██╗██╔══██╗██╔══██╗██╔══██╗    ╚══██╔══╝██╔═══██╗██╔══██╗██╔═══██╗██╔════╝ │
                                                │ ██████╔╝██║   ██║██████╔╝██████╔╝███████║██████╔╝       ██║   ██║   ██║██║  ██║██║   ██║███████╗ │
                                                │ ██╔══██╗██║   ██║██╔══██╗██╔══██╗██╔══██║██╔══██╗       ██║   ██║   ██║██║  ██║██║   ██║╚════██║ │
                                                │ ██████╔╝╚██████╔╝██║  ██║██║  ██║██║  ██║██║  ██║       ██║   ╚██████╔╝██████╔╝╚██████╔╝███████║ │
                                                │ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝       ╚═╝    ╚═════╝ ╚═════╝  ╚═════╝ ╚══════╝ │
                                                │             ██╗      ██████╗ ███████╗    ██████╗  █████╗ ████████╗ ██████╗ ███████╗              │
                                                │             ██║     ██╔═══██╗██╔════╝    ██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗██╔════╝              │
                                                │             ██║     ██║   ██║███████╗    ██║  ██║███████║   ██║   ██║   ██║███████╗              │
                                                │             ██║     ██║   ██║╚════██║    ██║  ██║██╔══██║   ██║   ██║   ██║╚════██║              │
                                                │             ███████╗╚██████╔╝███████║    ██████╔╝██║  ██║   ██║   ╚██████╔╝███████║              │
                                                │             ╚══════╝ ╚═════╝ ╚══════╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚══════╝              │
                                                │                                                                                                  │
                                                ╚──────────────────────────────────────────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                         ┌────────────────────────────────────────────────┐\n");
                    Console.WriteLine("                                                                             ----------------- Menu ---------------");
                    ConsoleColor currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                             |- Eliminar Archivo Facilitador --- (F)");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                             |- Eliminar Archivo Programador --- (P)");
                    Console.WriteLine("                                                                             |- Volver ------------------------- (V)\n");
                    Console.WriteLine("                                                                         └────────────────────────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    Console.CursorVisible = true;
                    eliminarLineasVacias();
                    if (File.Exists(listaEstudianteFacilitador))
                    {
                        Console.Clear();
                        File.WriteAllText(listaEstudianteFacilitador, string.Empty);
                        barraCarga(80, 25);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition(80, 25);
                        Console.WriteLine("                                    ---------[ No hay datos para borrar.");
                    }
                    validKey = false;
                    Console.ReadKey();
                    Console.CursorVisible = false;
                    break;

                case ConsoleKey.P:
                    Console.Clear();
                    Console.WriteLine(@"
            
            
            
            
            
            
            
            
                                                ╔──────────────────────────────────────────────────────────────────────────────────────────────────╗
                                                │                                                                                                  │
                                                │ ██████╗  ██████╗ ██████╗ ██████╗  █████╗ ██████╗     ████████╗ ██████╗ ██████╗  ██████╗ ███████╗ │
                                                │ ██╔══██╗██╔═══██╗██╔══██╗██╔══██╗██╔══██╗██╔══██╗    ╚══██╔══╝██╔═══██╗██╔══██╗██╔═══██╗██╔════╝ │
                                                │ ██████╔╝██║   ██║██████╔╝██████╔╝███████║██████╔╝       ██║   ██║   ██║██║  ██║██║   ██║███████╗ │
                                                │ ██╔══██╗██║   ██║██╔══██╗██╔══██╗██╔══██║██╔══██╗       ██║   ██║   ██║██║  ██║██║   ██║╚════██║ │
                                                │ ██████╔╝╚██████╔╝██║  ██║██║  ██║██║  ██║██║  ██║       ██║   ╚██████╔╝██████╔╝╚██████╔╝███████║ │
                                                │ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝       ╚═╝    ╚═════╝ ╚═════╝  ╚═════╝ ╚══════╝ │
                                                │             ██╗      ██████╗ ███████╗    ██████╗  █████╗ ████████╗ ██████╗ ███████╗              │
                                                │             ██║     ██╔═══██╗██╔════╝    ██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗██╔════╝              │
                                                │             ██║     ██║   ██║███████╗    ██║  ██║███████║   ██║   ██║   ██║███████╗              │
                                                │             ██║     ██║   ██║╚════██║    ██║  ██║██╔══██║   ██║   ██║   ██║╚════██║              │
                                                │             ███████╗╚██████╔╝███████║    ██████╔╝██║  ██║   ██║   ╚██████╔╝███████║              │
                                                │             ╚══════╝ ╚═════╝ ╚══════╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚══════╝              │
                                                │                                                                                                  │
                                                ╚──────────────────────────────────────────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                         ┌────────────────────────────────────────────────┐\n");
                    Console.WriteLine("                                                                             ----------------- Menu ---------------");
                    Console.WriteLine("                                                                             |- Eliminar Archivo Facilitador --- (F)");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                             |- Eliminar Archivo Programador --- (P)");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                             |- Volver ------------------------- (V)\n");
                    Console.WriteLine("                                                                         └────────────────────────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    Console.CursorVisible = true;
                    eliminarLineasVacias();
                    if (File.Exists(listaEstudianteProgramador))
                    {
                        Console.Clear();
                        File.WriteAllText(listaEstudianteProgramador, string.Empty);
                        barraCarga(80, 25);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition(80, 25);
                        Console.WriteLine("                                    ---------[ No hay datos para borrar.");
                    }
                    validKey = false;
                    Console.ReadKey();
                    Console.CursorVisible = false;
                    break;

                case ConsoleKey.V:
                    Console.Clear();
                    Console.WriteLine(@"
            
            
            
            
            
            
            
            
                                                ╔──────────────────────────────────────────────────────────────────────────────────────────────────╗
                                                │                                                                                                  │
                                                │ ██████╗  ██████╗ ██████╗ ██████╗  █████╗ ██████╗     ████████╗ ██████╗ ██████╗  ██████╗ ███████╗ │
                                                │ ██╔══██╗██╔═══██╗██╔══██╗██╔══██╗██╔══██╗██╔══██╗    ╚══██╔══╝██╔═══██╗██╔══██╗██╔═══██╗██╔════╝ │
                                                │ ██████╔╝██║   ██║██████╔╝██████╔╝███████║██████╔╝       ██║   ██║   ██║██║  ██║██║   ██║███████╗ │
                                                │ ██╔══██╗██║   ██║██╔══██╗██╔══██╗██╔══██║██╔══██╗       ██║   ██║   ██║██║  ██║██║   ██║╚════██║ │
                                                │ ██████╔╝╚██████╔╝██║  ██║██║  ██║██║  ██║██║  ██║       ██║   ╚██████╔╝██████╔╝╚██████╔╝███████║ │
                                                │ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝       ╚═╝    ╚═════╝ ╚═════╝  ╚═════╝ ╚══════╝ │
                                                │             ██╗      ██████╗ ███████╗    ██████╗  █████╗ ████████╗ ██████╗ ███████╗              │
                                                │             ██║     ██╔═══██╗██╔════╝    ██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗██╔════╝              │
                                                │             ██║     ██║   ██║███████╗    ██║  ██║███████║   ██║   ██║   ██║███████╗              │
                                                │             ██║     ██║   ██║╚════██║    ██║  ██║██╔══██║   ██║   ██║   ██║╚════██║              │
                                                │             ███████╗╚██████╔╝███████║    ██████╔╝██║  ██║   ██║   ╚██████╔╝███████║              │
                                                │             ╚══════╝ ╚═════╝ ╚══════╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚══════╝              │
                                                │                                                                                                  │
                                                ╚──────────────────────────────────────────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                         ┌────────────────────────────────────────────────┐\n");
                    Console.WriteLine("                                                                             ----------------- Menu ---------------");
                    Console.WriteLine("                                                                             |- Eliminar Archivo Facilitador --- (F)");
                    Console.WriteLine("                                                                             |- Eliminar Archivo Programador --- (P)");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                             |- Volver ------------------------- (V)\n");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                         └────────────────────────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    validKey = false;
                    Console.Clear();
                    break;

                default:
                    continue;
            }
        } while (validKey);
        Console.CursorVisible = false;
    }
    static void procesoRuleta()
    {
        bool programaPersona = true;
        Console.Clear();
        Console.WriteLine(@"
        
        
        
        
        
        
        
                                                ╔────────────────────────────────────────────────────────────────────────────────────────────╗
                                                │                                                                                            │
                                                │                  ██████╗ ██╗   ██╗██╗     ███████╗████████╗ █████╗                         │
                                                │                  ██╔══██╗██║   ██║██║     ██╔════╝╚══██╔══╝██╔══██╗                        │
                                                │                  ██████╔╝██║   ██║██║     █████╗     ██║   ███████║                        │
                                                │                  ██╔══██╗██║   ██║██║     ██╔══╝     ██║   ██╔══██║                        │
                                                │                  ██║  ██║╚██████╔╝███████╗███████╗   ██║   ██║  ██║                        │
                                                │                  ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚══════╝   ╚═╝   ╚═╝  ╚═╝                        │
                                                │                                                                                            │
                                                │  ███████╗███████╗████████╗██╗   ██╗██████╗ ██╗ █████╗ ███╗   ██╗████████╗███████╗███████╗  │
                                                │  ██╔════╝██╔════╝╚══██╔══╝██║   ██║██╔══██╗██║██╔══██╗████╗  ██║╚══██╔══╝██╔════╝██╔════╝  │
                                                │  █████╗  ███████╗   ██║   ██║   ██║██║  ██║██║███████║██╔██╗ ██║   ██║   █████╗  ███████╗  │
                                                │  ██╔══╝  ╚════██║   ██║   ██║   ██║██║  ██║██║██╔══██║██║╚██╗██║   ██║   ██╔══╝  ╚════██║  │
                                                │  ███████╗███████║   ██║   ╚██████╔╝██████╔╝██║██║  ██║██║ ╚████║   ██║   ███████╗███████║  │
                                                │  ╚══════╝╚══════╝   ╚═╝    ╚═════╝ ╚═════╝ ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝  │
                                                │                                                                                            │
                                                ╚────────────────────────────────────────────────────────────────────────────────────────────╝");
        Console.WriteLine("                                                                           ┌──────────────────────────────────┐\n");
        Console.WriteLine("                                                                                --------- Menu ---------");
        ConsoleColor currentForegroundColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("                                                                                |- Ruleta ---------- (R)");
        Console.ResetColor();
        Console.ForegroundColor = currentForegroundColor;

        Console.WriteLine("                                                                                |- Manejo Archivos - (M)");
        Console.WriteLine("                                                                                |- Cronometro int -- (I)");
        Console.WriteLine("                                                                                |- Tutorial -------- (T)");
        Console.WriteLine("                                                                                |- Configuraciones - (C)");
        Console.WriteLine("                                                                                |- Sugerencias ----- (S)");
        Console.WriteLine("                                                                                |- Salir ----------- (X)\n");
        Console.WriteLine("                                                                           └──────────────────────────────────┘\n");

        Thread.Sleep(500);
        Console.Clear();

        if (!File.Exists(listaEstudianteFacilitador))
        {
            Console.WriteLine($"                     ---------[ El archivo {listaEstudianteFacilitador} no existe.");
            Console.ReadKey();

        }

        if (!File.Exists(listaEstudianteProgramador))
        {
            Console.WriteLine($"                     ---------[ El archivo {listaEstudianteProgramador} no existe.");
            Console.ReadKey();

        }

        string[] lineas = File.ReadAllLines(listaEstudianteFacilitador);
        string[] lineas2 = File.ReadAllLines(listaEstudianteProgramador);

        if (lineas.Length == 0 && lineas2.Length == 0)
        {
            Console.WriteLine("                     ---------[ La lista del facilitador y del programador está vacía.");
            Console.ReadKey();

        }

        else if (lineas.Length == 0)
        {
            Console.WriteLine("                     ---------[ La lista del facilitador está vacía.");
            Console.ReadKey();

        }

        else if (lineas2.Length == 0)
        {
            Console.WriteLine("                     ---------[ La lista de programador está vacía.");
            Console.ReadKey();

        }

        bool salir = true;
        do
        {
            Console.WriteLine(@"
            
            
            
            
            
            
            
            
            
            
            
                        ╔──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╗
                        │                                                                                                                                                  │
                        │  ██████╗ ██╗   ██╗██╗     ███████╗████████╗ █████╗     ███████╗███████╗████████╗██╗   ██╗██████╗ ██╗ █████╗ ███╗   ██╗████████╗███████╗███████╗  │
                        │  ██╔══██╗██║   ██║██║     ██╔════╝╚══██╔══╝██╔══██╗    ██╔════╝██╔════╝╚══██╔══╝██║   ██║██╔══██╗██║██╔══██╗████╗  ██║╚══██╔══╝██╔════╝██╔════╝  │
                        │  ██████╔╝██║   ██║██║     █████╗     ██║   ███████║    █████╗  ███████╗   ██║   ██║   ██║██║  ██║██║███████║██╔██╗ ██║   ██║   █████╗  ███████╗  │
                        │  ██╔══██╗██║   ██║██║     ██╔══╝     ██║   ██╔══██║    ██╔══╝  ╚════██║   ██║   ██║   ██║██║  ██║██║██╔══██║██║╚██╗██║   ██║   ██╔══╝  ╚════██║  │
                        │  ██║  ██║╚██████╔╝███████╗███████╗   ██║   ██║  ██║    ███████╗███████║   ██║   ╚██████╔╝██████╔╝██║██║  ██║██║ ╚████║   ██║   ███████╗███████║  │
                        │  ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚══════╝   ╚═╝   ╚═╝  ╚═╝    ╚══════╝╚══════╝   ╚═╝    ╚═════╝ ╚═════╝ ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝  │
                        │                                                                                                                                                  │
                        ╚──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╝");

            Console.WriteLine();
            int width = 100;

            // elejir usuarios
            Random random = new Random();
            bool sonIguales;
            int indicePersona1 = random.Next(0, lineas.Length);
            int indicePersona2 = random.Next(0, lineas2.Length);

            // busca la personas
            string persona1 = lineas[indicePersona1];
            string persona2 = lineas2[indicePersona2];

            // las iguala
            sonIguales = (persona1 == persona2);
            if (sonIguales == true)
            {
                Console.WriteLine($"                        ---------[ Las personas son iguales. ¿Desea intentarlo de nuevo? (Si(Y) O No(N))");
                bool teclaValida = false;
                while (!teclaValida)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Y)
                    {
                        Console.Clear();
                        teclaValida = true;
                        salir = true;
                    }
                    else if (key == ConsoleKey.N)
                    {
                        return;
                    }
                }
            }
            else
            {
                for (int i = 82; i < width; i++)
                {
                    Console.SetCursorPosition(i, 23);
                    Console.Write("[ * ]");
                    Thread.Sleep(100);
                }
                Thread.Sleep(300);
                Console.SetCursorPosition(35, 25);
                Console.WriteLine($"                        ---------[ Facilitador: {persona1}, índice: {indicePersona1 + 1} ]---------");

                for (int i = 99; i >= 82; i--)
                {
                    Console.SetCursorPosition(i, 27);
                    Console.Write("[ * ]");
                    Thread.Sleep(90);
                }
                Thread.Sleep(300);
                Console.SetCursorPosition(35, 29);
                Console.WriteLine($"                        ---------[ Programador: {persona2}, índice: {indicePersona2 + 1} ]---------");
                Thread.Sleep(300);

                Console.WriteLine("\n                        ---------[ Siguiente (S)");
                ConsoleKey key;
                do
                {
                    key = Console.ReadKey(true).Key;
                } while (key != ConsoleKey.S);

                //el programa de hoy
                if (programaPersona)
                {
                    Console.CursorVisible = true;
                    Console.WriteLine("\n                        ---------[ Que programa se hara hoy?");
                    Console.SetCursorPosition(24, 34);
                    string guardarProgramaHara = limiteEscribir(120);

                    DateTime fechaActual = DateTime.Now;

                    string textoAAnadir = $"------------------------------------------------------------------------------------------{Environment.NewLine}--------[ Se creó: {fechaActual}{Environment.NewLine}-[ Facilitador: {indicePersona1 + 1}. {persona1}{Environment.NewLine}-[ Programador: {indicePersona2 + 1}. {persona2}{Environment.NewLine}//////////////////////////////////////{Environment.NewLine}--------[ El programa del facilitador es:{Environment.NewLine}-[ {guardarProgramaHara}{Environment.NewLine}------------------------------------------------------------------------------------------";
                    File.AppendAllText(personasRuletaLista, textoAAnadir);
                    programaPersona = false;
                    Console.CursorVisible = false;

                    Console.WriteLine("                        ---------[ Guardar (G)");
                    ConsoleKeyInfo key1;
                    do
                    {
                        key1 = Console.ReadKey(true);
                    } while (key1.Key != ConsoleKey.G);

                    Console.WriteLine("\n                        ---------[ Quieres eliminar estos estudiantes (Si(Y) O No(N))?");

                    key1 = Console.ReadKey(true);

                    switch (key1.Key)
                    {
                        case ConsoleKey.Y:
                            int numero = indicePersona1 + 1;

                            if (numero > 0 && numero <= lineas.Length)
                            {
                                using (StreamWriter escritor = new StreamWriter(listaEstudianteFacilitador))
                                {
                                    for (int i = 0; i < lineas.Length; i++)
                                    {
                                        if (i != numero - 1)
                                        {
                                            escritor.WriteLine(lineas[i]);
                                        }
                                    }
                                }
                            }

                            numero = indicePersona2 + 1;
                            if (numero > 0 && numero <= lineas.Length)
                            {
                                using (StreamWriter escritor = new StreamWriter(listaEstudianteProgramador))
                                {
                                    for (int i = 0; i < lineas.Length; i++)
                                    {
                                        if (i != numero - 1)
                                        {
                                            escritor.WriteLine(lineas[i]);
                                        }
                                    }
                                }

                            }

                            break;

                        case ConsoleKey.N:
                            break;

                        default:
                            continue;
                    }
                }
                break;
            }
        } while (salir);
        barraCarga(83, 39);
    }
    static void eliminarLineasVacias()//extas
    {
        if (File.Exists(listaEstudianteFacilitador) || File.Exists(listaEstudianteProgramador) || File.Exists(registroUsuario) || File.Exists(personasRuletaLista) || File.Exists(sugerenciaBuzonArchivo) || File.Exists(copiaSeguridad))
        {
            string[] lines = File.ReadAllLines(listaEstudianteFacilitador);
            string[] lines2 = File.ReadAllLines(listaEstudianteProgramador);
            string[] lines3 = File.ReadAllLines(registroUsuario);
            string[] lines4 = File.ReadAllLines(personasRuletaLista);
            string[] lines5 = File.ReadAllLines(sugerenciaBuzonArchivo);
            string[] lines6 = File.ReadAllLines(copiaSeguridad);

            // 
            string[] noLineasBlanco = new HashSet<string>(lines.Where(line => !string.IsNullOrWhiteSpace(line))).ToArray();
            string[] noLineasBlanco2 = new HashSet<string>(lines2.Where(line => !string.IsNullOrWhiteSpace(line))).ToArray();
            string[] noLineasBlanco3 = new HashSet<string>(lines3.Where(line => !string.IsNullOrWhiteSpace(line))).ToArray();
            string[] noLineasBlanco4 = lines4.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
            string[] noLineasBlanco5 = lines5.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
            string[] noLineasBlanco6 = lines6.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();


            File.WriteAllLines(listaEstudianteFacilitador, noLineasBlanco);
            File.WriteAllLines(listaEstudianteProgramador, noLineasBlanco2);
            File.WriteAllLines(registroUsuario, noLineasBlanco3);
            File.WriteAllLines(personasRuletaLista, noLineasBlanco4);
            File.WriteAllLines(sugerenciaBuzonArchivo, noLineasBlanco5);
            File.WriteAllLines(copiaSeguridad, noLineasBlanco6);
        }
        else
        {
            Console.WriteLine("El archivo no existe.");
        }
    }
    static void tutorialInicioPrograma()//extras
    {

        while (aparecerCambiarColor == true)
        {
            Console.Clear();
            Console.WriteLine(@"
        
        
        
        
        
        
        
                                                ╔────────────────────────────────────────────────────────────────────────────────────────────╗
                                                │                                                                                            │
                                                │                  ██████╗ ██╗   ██╗██╗     ███████╗████████╗ █████╗                         │
                                                │                  ██╔══██╗██║   ██║██║     ██╔════╝╚══██╔══╝██╔══██╗                        │
                                                │                  ██████╔╝██║   ██║██║     █████╗     ██║   ███████║                        │
                                                │                  ██╔══██╗██║   ██║██║     ██╔══╝     ██║   ██╔══██║                        │
                                                │                  ██║  ██║╚██████╔╝███████╗███████╗   ██║   ██║  ██║                        │
                                                │                  ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚══════╝   ╚═╝   ╚═╝  ╚═╝                        │
                                                │                                                                                            │
                                                │  ███████╗███████╗████████╗██╗   ██╗██████╗ ██╗ █████╗ ███╗   ██╗████████╗███████╗███████╗  │
                                                │  ██╔════╝██╔════╝╚══██╔══╝██║   ██║██╔══██╗██║██╔══██╗████╗  ██║╚══██╔══╝██╔════╝██╔════╝  │
                                                │  █████╗  ███████╗   ██║   ██║   ██║██║  ██║██║███████║██╔██╗ ██║   ██║   █████╗  ███████╗  │
                                                │  ██╔══╝  ╚════██║   ██║   ██║   ██║██║  ██║██║██╔══██║██║╚██╗██║   ██║   ██╔══╝  ╚════██║  │
                                                │  ███████╗███████║   ██║   ╚██████╔╝██████╔╝██║██║  ██║██║ ╚████║   ██║   ███████╗███████║  │
                                                │  ╚══════╝╚══════╝   ╚═╝    ╚═════╝ ╚═════╝ ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝  │
                                                │                                                                                            │
                                                ╚────────────────────────────────────────────────────────────────────────────────────────────╝");
            Console.WriteLine("                                                                           ┌──────────────────────────────────┐\n");
            Console.WriteLine("                                                                                --------- Menu ---------");
            Console.WriteLine("                                                                                |- Ruleta ---------- (R)");
            Console.WriteLine("                                                                                |- Manejo Archivos - (M)");
            Console.WriteLine("                                                                                |- Cronometro int -- (I)");
            ConsoleColor currentForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                                                |- Tutorial -------- (T)");
            Console.ResetColor();
            Console.ForegroundColor = currentForegroundColor;
            Console.WriteLine("                                                                                |- Configuraciones - (C)");
            Console.WriteLine("                                                                                |- Sugerencias ----- (S)");
            Console.WriteLine("                                                                                |- Salir ----------- (X)\n");
            Console.WriteLine("                                                                           └──────────────────────────────────┘\n");

            Thread.Sleep(500);
            Console.Clear();
            break;
        }

        aparecerCambiarColor = true;
        Console.Clear();
        Console.WriteLine(@" 
        
        
        
        
        
        
                                                 ████████████████████████████████████████████████████████████████████████████████████████████
                                                 █▌                                                                                        ▐█
                                                 █▌  ██████╗ ██╗███████╗███╗   ██╗██╗   ██╗███████╗███╗   ██╗██╗██████╗  ██████╗ ███████╗  ▐█
                                                 █▌  ██╔══██╗██║██╔════╝████╗  ██║██║   ██║██╔════╝████╗  ██║██║██╔══██╗██╔═══██╗██╔════╝  ▐█
                                                 █▌  ██████╔╝██║█████╗  ██╔██╗ ██║██║   ██║█████╗  ██╔██╗ ██║██║██║  ██║██║   ██║███████╗  ▐█
                                                 █▌  ██╔══██╗██║██╔══╝  ██║╚██╗██║╚██╗ ██╔╝██╔══╝  ██║╚██╗██║██║██║  ██║██║   ██║╚════██║  ▐█
                                                 █▌  ██████╔╝██║███████╗██║ ╚████║ ╚████╔╝ ███████╗██║ ╚████║██║██████╔╝╚██████╔╝███████║  ▐█
                                                 █▌  ╚═════╝ ╚═╝╚══════╝╚═╝  ╚═══╝  ╚═══╝  ╚══════╝╚═╝  ╚═══╝╚═╝╚═════╝  ╚═════╝ ╚══════╝  ▐█
                                                 █▌                                                                                        ▐█
                                                 █▌                                   █████╗ ██╗                                           ▐█
                                                 █▌                                  ██╔══██╗██║                                           ▐█
                                                 █▌                                  ███████║██║                                           ▐█
                                                 █▌                                  ██╔══██║██║                                           ▐█
                                                 █▌                                  ██║  ██║███████╗                                      ▐█
                                                 █▌                                  ╚═╝  ╚═╝╚══════╝                                      ▐█
                                                 █▌                                                                                        ▐█
                                                 █▌              ████████╗██╗   ██╗████████╗ ██████╗ ██████╗ ██╗ █████╗ ██╗                ▐█
                                                 █▌              ╚══██╔══╝██║   ██║╚══██╔══╝██╔═══██╗██╔══██╗██║██╔══██╗██║                ▐█
                                                 █▌                 ██║   ██║   ██║   ██║   ██║   ██║██████╔╝██║███████║██║                ▐█
                                                 █▌                 ██║   ██║   ██║   ██║   ██║   ██║██╔══██╗██║██╔══██║██║                ▐█
                                                 █▌                 ██║   ╚██████╔╝   ██║   ╚██████╔╝██║  ██║██║██║  ██║███████╗           ▐█
                                                 █▌                 ╚═╝    ╚═════╝    ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚═╝╚═╝  ╚═╝╚══════╝           ▐█
                                                 █▌                                                                                        ▐█
                                                 ████████████████████████████████████████████████████████████████████████████████████████████");

        Console.SetCursorPosition(49, 31);
        Console.WriteLine(@"██████████ | En este tutorial aprenderá las funcionalidades básicas del programa para un uso 
                                                 eficiente del mismo.");

        Console.SetCursorPosition(49, 34);
        Console.WriteLine("██████████ | Siguiente (S)");

        ConsoleKey key;
        do
        {
            key = Console.ReadKey(true).Key;
        } while (key != ConsoleKey.S);

        while (musicaSIONO)
        {

            Console.Clear();
            Console.WriteLine(@"
            
            
            
            
            
            
            
            


            
            
            
            
                                                                ███████████████████████████████████████████████████████
                                                                █▌                                                   ▐█
                                                                █▌  ███╗   ███╗██╗   ██╗███████╗██╗ ██████╗ █████╗   ▐█
                                                                █▌  ████╗ ████║██║   ██║██╔════╝██║██╔════╝██╔══██╗  ▐█
                                                                █▌  ██╔████╔██║██║   ██║███████╗██║██║     ███████║  ▐█
                                                                █▌  ██║╚██╔╝██║██║   ██║╚════██║██║██║     ██╔══██║  ▐█
                                                                █▌  ██║ ╚═╝ ██║╚██████╔╝███████║██║╚██████╗██║  ██║  ▐█
                                                                █▌  ╚═╝     ╚═╝ ╚═════╝ ╚══════╝╚═╝ ╚═════╝╚═╝  ╚═╝  ▐█
                                                                █▌                                                   ▐█
                                                                ███████████████████████████████████████████████████████");

            cursorLeft = Console.CursorLeft;
            cursorTop = Console.CursorTop;
            Console.Write(@"                                                                ██████████ | Quieres desativar la musica de fondo 
                                                                             (Si(Y) o No(N))");

            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.Y:
                    outputDevice.Stop();
                    outputDevice.Dispose();
                    audioFile.Dispose();
                    musicaSIONO = false;
                    break;

                case ConsoleKey.N:
                    musicaSIONO = false;
                    break;

                default:
                    continue;
            }

            Console.SetCursorPosition(cursorLeft, cursorTop);
            Console.Write(@"                                                                ██████████ | Puedes activar la música nuevamente en la 
                                                                             configuración.");
            Console.SetCursorPosition(cursorLeft, cursorTop + 2);
            Console.WriteLine("                                                                                                                                                        ");

            Console.WriteLine("                                                                ██████████ | Siguiente (S)");
            key = Console.ReadKey(true).Key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.S);
        }

        Console.Clear();

        Console.WriteLine(@"  
        
        
        
        
        
        
        
        
        
                                                ██████████████████████████████████████████████████████████████████████████████████████████
                                                █▌                                                                                      ▐█
                                                █▌          ████████╗██╗   ██╗████████╗ ██████╗ ██████╗ ██╗ █████╗ ██╗                  ▐█
                                                █▌          ╚══██╔══╝██║   ██║╚══██╔══╝██╔═══██╗██╔══██╗██║██╔══██╗██║                  ▐█
                                                █▌             ██║   ██║   ██║   ██║   ██║   ██║██████╔╝██║███████║██║                  ▐█
                                                █▌             ██║   ██║   ██║   ██║   ██║   ██║██╔══██╗██║██╔══██║██║                  ▐█
                                                █▌             ██║   ╚██████╔╝   ██║   ╚██████╔╝██║  ██║██║██║  ██║███████╗             ▐█
                                                █▌             ╚═╝    ╚═════╝    ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚═╝╚═╝  ╚═╝╚══════╝             ▐█
                                                █▌                                                                                      ▐█
                                                █▌  ███╗   ██╗ █████╗ ██╗   ██╗███████╗ ██████╗  █████╗  ██████╗██╗ ██████╗ ███╗   ██╗  ▐█
                                                █▌  ████╗  ██║██╔══██╗██║   ██║██╔════╝██╔════╝ ██╔══██╗██╔════╝██║██╔═══██╗████╗  ██║  ▐█
                                                █▌  ██╔██╗ ██║███████║██║   ██║█████╗  ██║  ███╗███████║██║     ██║██║   ██║██╔██╗ ██║  ▐█
                                                █▌  ██║╚██╗██║██╔══██║╚██╗ ██╔╝██╔══╝  ██║   ██║██╔══██║██║     ██║██║   ██║██║╚██╗██║  ▐█
                                                █▌  ██║ ╚████║██║  ██║ ╚████╔╝ ███████╗╚██████╔╝██║  ██║╚██████╗██║╚██████╔╝██║ ╚████║  ▐█
                                                █▌  ╚═╝  ╚═══╝╚═╝  ╚═╝  ╚═══╝  ╚══════╝ ╚═════╝ ╚═╝  ╚═╝ ╚═════╝╚═╝ ╚═════╝ ╚═╝  ╚═══╝  ▐█
                                                █▌                                                                                      ▐█
                                                ██████████████████████████████████████████████████████████████████████████████████████████");
        cursorLeft = Console.CursorLeft;
        cursorTop = Console.CursorTop;
        Console.WriteLine(@"                                                ██████████ | Navegar por los menús y seleccionar opciones es fácil: elija la opción 
                                                             deseada para acceder a su funcionalidad.");

        Console.WriteLine("\n                                                ██████████ | Siguiente (S)");
        key = Console.ReadKey(true).Key;
        do
        {
            key = Console.ReadKey(true).Key;
        } while (key != ConsoleKey.S);

        Console.SetCursorPosition(cursorLeft, cursorTop);
        Console.WriteLine("                                                ██████████ | Por ejemplo, si el menú ofrece las siguientes opciones:                                                                                                          ");
        Console.SetCursorPosition(cursorLeft, cursorTop + 1);
        Console.WriteLine("                                                                                                                                         ");
        Console.WriteLine(@"                                                       ┌─────◦(      Ejemplo      )◦─────┐
                                                            --------- Menu ---------
                                                            |- Ejemplo ---------- (F)
                                                            |- Ejemplo ---------- (M)
                                                            |- Ejemplo ---------- (V)
                                                        └───────────────────────────────┘");

        cursorLeft = Console.CursorLeft;
        cursorTop = Console.CursorTop;
        Console.WriteLine("\n                                                ██████████ | Debe presionar 'F' o 'V' según la opción que desee seleccionar.");

        Console.WriteLine("\n                                                ██████████ | Siguiente (S)");
        key = Console.ReadKey(true).Key;
        do
        {
            key = Console.ReadKey(true).Key;
        } while (key != ConsoleKey.S);

        Console.SetCursorPosition(cursorLeft, cursorTop + 1);
        Console.WriteLine("                                                ██████████ | Así podrá moverse a través del programa.                                                                             \n");
        Console.SetCursorPosition(cursorLeft, cursorTop + 2);
        Console.WriteLine("                                                       ");

        Console.WriteLine("                                                ██████████ | Siguiente (S)");
        key = Console.ReadKey(true).Key;
        do
        {
            key = Console.ReadKey(true).Key;
        } while (key != ConsoleKey.S);

        Console.Clear();
        Console.WriteLine(@"
        
        
        
        
        
        
        
        
        
        
                                            ████████████████████████████████████████████████████████████████████████████████████████████████████████
                                            █▌                                                                                                    ▐█
                                            █▌  ██╗   ██╗███████╗██████╗     ██╗   ██╗     ██████╗ █████╗ ███╗   ███╗██████╗ ██╗ █████╗ ██████╗   ▐█
                                            █▌  ██║   ██║██╔════╝██╔══██╗    ╚██╗ ██╔╝    ██╔════╝██╔══██╗████╗ ████║██╔══██╗██║██╔══██╗██╔══██╗  ▐█
                                            █▌  ██║   ██║█████╗  ██████╔╝     ╚████╔╝     ██║     ███████║██╔████╔██║██████╔╝██║███████║██████╔╝  ▐█
                                            █▌  ╚██╗ ██╔╝██╔══╝  ██╔══██╗      ╚██╔╝      ██║     ██╔══██║██║╚██╔╝██║██╔══██╗██║██╔══██║██╔══██╗  ▐█
                                            █▌   ╚████╔╝ ███████╗██║  ██║       ██║       ╚██████╗██║  ██║██║ ╚═╝ ██║██████╔╝██║██║  ██║██║  ██║  ▐█
                                            █▌    ╚═══╝  ╚══════╝╚═╝  ╚═╝       ╚═╝        ╚═════╝╚═╝  ╚═╝╚═╝     ╚═╝╚═════╝ ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝  ▐█
                                            █▌                                                                                                    ▐█
                                            █▌       ██████╗ ██████╗ ███╗   ██╗████████╗██████╗  █████╗ ███████╗███████╗███╗   ██╗ █████╗         ▐█
                                            █▌      ██╔════╝██╔═══██╗████╗  ██║╚══██╔══╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗  ██║██╔══██╗        ▐█
                                            █▌      ██║     ██║   ██║██╔██╗ ██║   ██║   ██████╔╝███████║███████╗█████╗  ██╔██╗ ██║███████║        ▐█
                                            █▌      ██║     ██║   ██║██║╚██╗██║   ██║   ██╔══██╗██╔══██║╚════██║██╔══╝  ██║╚██╗██║██╔══██║        ▐█
                                            █▌      ╚██████╗╚██████╔╝██║ ╚████║   ██║   ██║  ██║██║  ██║███████║███████╗██║ ╚████║██║  ██║        ▐█
                                            █▌       ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝╚══════╝╚═╝  ╚═══╝╚═╝  ╚═╝        ▐█
                                            █▌                                                                                                    ▐█
                                            ████████████████████████████████████████████████████████████████████████████████████████████████████████");

        if (File.Exists(registroUsuario))
        {
            string[] registro = File.ReadAllLines(registroUsuario);
            for (int i = 0; i < registro.Length; i++)
            {
                cursorLeft = Console.CursorLeft;
                cursorTop = Console.CursorTop;
                Console.WriteLine($"                                            ██████████ | La contrasena prederteminada es: ({registro[i]})\n");
            }

            Console.WriteLine("                                            ██████████ | Siguiente (S)");
            key = Console.ReadKey(true).Key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.S);
        }

        else
        {
            Console.WriteLine("                                            ██████████ | No existe el registro de usuario\n");
            Console.WriteLine("                                            ██████████ | Siguiente (S)");
            key = Console.ReadKey(true).Key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.S);
        }


        Console.ReadKey();
        Console.SetCursorPosition(cursorLeft, cursorTop);
        Console.WriteLine("                                            ██████████ | Si desea cambiarla, seleccione la opción correspondiente.                   ");

        Console.SetCursorPosition(cursorLeft, cursorTop + 1);
        Console.WriteLine("                                          ");
        Console.WriteLine("                                            ██████████ | Siguiente (S)");

        Console.SetCursorPosition(cursorLeft, cursorTop + 3);
        Console.WriteLine("                                          ");
        key = Console.ReadKey(true).Key;
        do
        {
            key = Console.ReadKey(true).Key;
        } while (key != ConsoleKey.S);

        Console.SetCursorPosition(cursorLeft, cursorTop);
        Console.Write("                                            ██████████ | Desea cambiar la contraseña (Si(Y) - No(N))                                          ");
        Console.SetCursorPosition(cursorLeft, cursorTop + 2);
        Console.WriteLine("                                                                                      ");
        do
        {
            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.Y:
                    if (File.Exists(registroUsuario)) File.Delete(registroUsuario);
                    do
                    {
                        Console.Clear();
                        Console.WriteLine(@"
                        
                        
                        
                        
                        
                        
                        
                        
                        
                                                ████████████████████████████████████████████████████████████████████████████████████████████
                                                █▌                                                                                        ▐█
                                                █▌                     ███╗   ██╗██╗   ██╗███████╗██╗   ██╗ █████╗                        ▐█
                                                █▌                     ████╗  ██║██║   ██║██╔════╝██║   ██║██╔══██╗                       ▐█
                                                █▌                     ██╔██╗ ██║██║   ██║█████╗  ██║   ██║███████║                       ▐█
                                                █▌                     ██║╚██╗██║██║   ██║██╔══╝  ╚██╗ ██╔╝██╔══██║                       ▐█
                                                █▌                     ██║ ╚████║╚██████╔╝███████╗ ╚████╔╝ ██║  ██║                       ▐█
                                                █▌                     ╚═╝  ╚═══╝ ╚═════╝ ╚══════╝  ╚═══╝  ╚═╝  ╚═╝                       ▐█
                                                █▌                                                                                        ▐█
                                                █▌  ██████╗ ██████╗ ███╗   ██╗████████╗██████╗  █████╗ ███████╗███████╗███╗   ██╗ █████╗  ▐█
                                                █▌ ██╔════╝██╔═══██╗████╗  ██║╚══██╔══╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗  ██║██╔══██╗ ▐█
                                                █▌ ██║     ██║   ██║██╔██╗ ██║   ██║   ██████╔╝███████║███████╗█████╗  ██╔██╗ ██║███████║ ▐█
                                                █▌ ██║     ██║   ██║██║╚██╗██║   ██║   ██╔══██╗██╔══██║╚════██║██╔══╝  ██║╚██╗██║██╔══██║ ▐█
                                                █▌ ╚██████╗╚██████╔╝██║ ╚████║   ██║   ██║  ██║██║  ██║███████║███████╗██║ ╚████║██║  ██║ ▐█
                                                █▌  ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝╚══════╝╚═╝  ╚═══╝╚═╝  ╚═╝ ▐█
                                                █▌                                                                                        ▐█
                                                ████████████████████████████████████████████████████████████████████████████████████████████");

                        Console.Write("                                                ██████████ | Ingrese la nueva contrasena: ");
                        string dato = limiteEscribir(3);

                        if (dato.Length > 0)
                        {
                            string textoAAnadir = $"{Environment.NewLine}{dato}";
                            File.AppendAllText(registroUsuario, textoAAnadir);
                            break;
                        }
                    } while (true);

                    Console.WriteLine("                                                ██████████ | Contrasena anadida.");
                    Console.ReadKey();
                    eliminarLineasVacias();
                    return;

                case ConsoleKey.N:
                    Console.Clear();
                    Console.SetCursorPosition(30, 20);
                    Console.WriteLine("                                                ██████████ | Abriendo el programa.");
                    Thread.Sleep(200);
                    barraCarga(78, 21);
                    eliminarLineasVacias();
                    Console.ReadKey();
                    return;
            }

        } while (true);
    }
    static void configuracionesPrograma()//extras
    {
        Console.Clear();
        Console.WriteLine(@"
        
        
        
        
        
        
        
                                                ╔────────────────────────────────────────────────────────────────────────────────────────────╗
                                                │                                                                                            │
                                                │                  ██████╗ ██╗   ██╗██╗     ███████╗████████╗ █████╗                         │
                                                │                  ██╔══██╗██║   ██║██║     ██╔════╝╚══██╔══╝██╔══██╗                        │
                                                │                  ██████╔╝██║   ██║██║     █████╗     ██║   ███████║                        │
                                                │                  ██╔══██╗██║   ██║██║     ██╔══╝     ██║   ██╔══██║                        │
                                                │                  ██║  ██║╚██████╔╝███████╗███████╗   ██║   ██║  ██║                        │
                                                │                  ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚══════╝   ╚═╝   ╚═╝  ╚═╝                        │
                                                │                                                                                            │
                                                │  ███████╗███████╗████████╗██╗   ██╗██████╗ ██╗ █████╗ ███╗   ██╗████████╗███████╗███████╗  │
                                                │  ██╔════╝██╔════╝╚══██╔══╝██║   ██║██╔══██╗██║██╔══██╗████╗  ██║╚══██╔══╝██╔════╝██╔════╝  │
                                                │  █████╗  ███████╗   ██║   ██║   ██║██║  ██║██║███████║██╔██╗ ██║   ██║   █████╗  ███████╗  │
                                                │  ██╔══╝  ╚════██║   ██║   ██║   ██║██║  ██║██║██╔══██║██║╚██╗██║   ██║   ██╔══╝  ╚════██║  │
                                                │  ███████╗███████║   ██║   ╚██████╔╝██████╔╝██║██║  ██║██║ ╚████║   ██║   ███████╗███████║  │
                                                │  ╚══════╝╚══════╝   ╚═╝    ╚═════╝ ╚═════╝ ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝  │
                                                │                                                                                            │
                                                ╚────────────────────────────────────────────────────────────────────────────────────────────╝");
        Console.WriteLine("                                                                           ┌──────────────────────────────────┐\n");
        Console.WriteLine("                                                                                --------- Menu ---------");
        Console.WriteLine("                                                                                |- Ruleta ---------- (R)");
        Console.WriteLine("                                                                                |- Manejo Archivos - (M)");
        Console.WriteLine("                                                                                |- Cronometro int -- (I)");
        Console.WriteLine("                                                                                |- Tutorial -------- (T)");
        ConsoleColor currentForegroundColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("                                                                                |- Configuraciones - (C)");
        Console.ForegroundColor = currentForegroundColor;
        Console.ForegroundColor = currentForegroundColor;
        Console.ForegroundColor = currentForegroundColor;
        Console.WriteLine("                                                                                |- Sugerencias ----- (S)");
        Console.WriteLine("                                                                                |- Salir ----------- (X)\n");
        Console.WriteLine("                                                                           └──────────────────────────────────┘\n");

        Thread.Sleep(500);
        Console.Clear();

        bool salirBubleConfiguracion = true;
        do
        {
            Console.Clear();
            Console.WriteLine(@"
            
            
            
            
            
            
            
            
            
            
            
            
                                ╔──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╗
                                │                                                                                                                          │
                                │   ██████╗ ██████╗ ███╗   ██╗███████╗██╗ ██████╗ ██╗   ██╗██████╗  █████╗  ██████╗██╗ ██████╗ ███╗   ██╗███████╗███████╗  │
                                │  ██╔════╝██╔═══██╗████╗  ██║██╔════╝██║██╔════╝ ██║   ██║██╔══██╗██╔══██╗██╔════╝██║██╔═══██╗████╗  ██║██╔════╝██╔════╝  │
                                │  ██║     ██║   ██║██╔██╗ ██║█████╗  ██║██║  ███╗██║   ██║██████╔╝███████║██║     ██║██║   ██║██╔██╗ ██║█████╗  ███████╗  │
                                │  ██║     ██║   ██║██║╚██╗██║██╔══╝  ██║██║   ██║██║   ██║██╔══██╗██╔══██║██║     ██║██║   ██║██║╚██╗██║██╔══╝  ╚════██║  │
                                │  ╚██████╗╚██████╔╝██║ ╚████║██║     ██║╚██████╔╝╚██████╔╝██║  ██║██║  ██║╚██████╗██║╚██████╔╝██║ ╚████║███████╗███████║  │
                                │   ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝     ╚═╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝╚══════╝  │
                                │                                                                                                                          │
                                ╚──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╝");
            Console.WriteLine("                                                                         ┌───────────────────────────────┐\n");
            Console.WriteLine("                                                                             --------- Menu ---------");
            Console.WriteLine("                                                                             |- Fuentes --------- (F)");
            Console.WriteLine("                                                                             |- Musica ---------- (M)");
            Console.WriteLine("                                                                             |- Volver ---------- (V)\n");
            Console.WriteLine("                                                                         └───────────────────────────────┘\n");

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.F:
                    Console.Clear();
                    Console.WriteLine(@"
            
            
            
            
            
            
            
            
            
            
            
            
                                ╔──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╗
                                │                                                                                                                          │
                                │   ██████╗ ██████╗ ███╗   ██╗███████╗██╗ ██████╗ ██╗   ██╗██████╗  █████╗  ██████╗██╗ ██████╗ ███╗   ██╗███████╗███████╗  │
                                │  ██╔════╝██╔═══██╗████╗  ██║██╔════╝██║██╔════╝ ██║   ██║██╔══██╗██╔══██╗██╔════╝██║██╔═══██╗████╗  ██║██╔════╝██╔════╝  │
                                │  ██║     ██║   ██║██╔██╗ ██║█████╗  ██║██║  ███╗██║   ██║██████╔╝███████║██║     ██║██║   ██║██╔██╗ ██║█████╗  ███████╗  │
                                │  ██║     ██║   ██║██║╚██╗██║██╔══╝  ██║██║   ██║██║   ██║██╔══██╗██╔══██║██║     ██║██║   ██║██║╚██╗██║██╔══╝  ╚════██║  │
                                │  ╚██████╗╚██████╔╝██║ ╚████║██║     ██║╚██████╔╝╚██████╔╝██║  ██║██║  ██║╚██████╗██║╚██████╔╝██║ ╚████║███████╗███████║  │
                                │   ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝     ╚═╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝╚══════╝  │
                                │                                                                                                                          │
                                ╚──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                         ┌───────────────────────────────┐\n");
                    Console.WriteLine("                                                                             --------- Menu ---------");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                             |- Fuentes --------- (F)");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                             |- Musica ---------- (M)");
                    Console.WriteLine("                                                                             |- Volver ---------- (V)\n");
                    Console.WriteLine("                                                                         └───────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    Console.Clear();
                    bool fuenteFondo = true;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine(@"
                        
                        
                        
                        
                        
                        
                        
                        
                                                            
                                                            
                                                            ╔────────────────────────────────────────────────────────────────╗
                                                            │                                                                │
                                                            │  ███████╗██╗   ██╗███████╗███╗   ██╗████████╗███████╗███████╗  │
                                                            │  ██╔════╝██║   ██║██╔════╝████╗  ██║╚══██╔══╝██╔════╝██╔════╝  │
                                                            │  █████╗  ██║   ██║█████╗  ██╔██╗ ██║   ██║   █████╗  ███████╗  │
                                                            │  ██╔══╝  ██║   ██║██╔══╝  ██║╚██╗██║   ██║   ██╔══╝  ╚════██║  │
                                                            │  ██║     ╚██████╔╝███████╗██║ ╚████║   ██║   ███████╗███████║  │
                                                            │  ╚═╝      ╚═════╝ ╚══════╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝  │
                                                            │                                                                │
                                                            ╚────────────────────────────────────────────────────────────────╝");
                        Console.WriteLine("                                                                        ┌───────────────────────────────────────┐\n");
                        Console.WriteLine("                                                                              --------- Plantillas ---------");
                        Console.WriteLine("                                                                              |- Restablecer todo ------ (R)");
                        Console.WriteLine("                                                                              |- Blanco ---------------- (B)");
                        Console.WriteLine("                                                                              |- Negro ----------------- (N)");
                        Console.WriteLine("                                                                              |- Amarillo -------------- (A)");
                        Console.WriteLine("                                                                              |- Azul ------------------ (Z)");
                        Console.WriteLine("                                                                              |- Verde ----------------- (E)");
                        Console.WriteLine("                                                                              |- Volver ---------------- (V)\n");
                        Console.WriteLine("                                                                        └───────────────────────────────────────┘\n");

                        key = Console.ReadKey(true).Key;

                        switch (key)
                        {
                            case ConsoleKey.R:
                                Console.Clear();
                                Console.WriteLine(@"
                        
                        
                        
                        
                        
                        
                        
                        
                                                            
                                                            
                                                            ╔────────────────────────────────────────────────────────────────╗
                                                            │                                                                │
                                                            │  ███████╗██╗   ██╗███████╗███╗   ██╗████████╗███████╗███████╗  │
                                                            │  ██╔════╝██║   ██║██╔════╝████╗  ██║╚══██╔══╝██╔════╝██╔════╝  │
                                                            │  █████╗  ██║   ██║█████╗  ██╔██╗ ██║   ██║   █████╗  ███████╗  │
                                                            │  ██╔══╝  ██║   ██║██╔══╝  ██║╚██╗██║   ██║   ██╔══╝  ╚════██║  │
                                                            │  ██║     ╚██████╔╝███████╗██║ ╚████║   ██║   ███████╗███████║  │
                                                            │  ╚═╝      ╚═════╝ ╚══════╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝  │
                                                            │                                                                │
                                                            ╚────────────────────────────────────────────────────────────────╝");
                                Console.WriteLine("                                                                        ┌───────────────────────────────────────┐\n");
                                Console.WriteLine("                                                                              --------- Plantillas ---------");
                                currentForegroundColor = Console.ForegroundColor;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("                                                                              |- Restablecer todo ------ (R)");
                                Console.ForegroundColor = currentForegroundColor;
                                Console.WriteLine("                                                                              |- Blanco ---------------- (B)");
                                Console.WriteLine("                                                                              |- Negro ----------------- (N)");
                                Console.WriteLine("                                                                              |- Amarillo -------------- (A)");
                                Console.WriteLine("                                                                              |- Azul ------------------ (Z)");
                                Console.WriteLine("                                                                              |- Verde ----------------- (E)");
                                Console.WriteLine("                                                                              |- Volver ---------------- (V)\n");
                                Console.WriteLine("                                                                        └───────────────────────────────────────┘\n");
                                Thread.Sleep(500);
                                Console.Clear();

                                Console.ResetColor();
                                break;

                            case ConsoleKey.B:
                                Console.Clear();
                                Console.WriteLine(@"
                        
                        
                        
                        
                        
                        
                        
                        
                                                            
                                                            
                                                            ╔────────────────────────────────────────────────────────────────╗
                                                            │                                                                │
                                                            │  ███████╗██╗   ██╗███████╗███╗   ██╗████████╗███████╗███████╗  │
                                                            │  ██╔════╝██║   ██║██╔════╝████╗  ██║╚══██╔══╝██╔════╝██╔════╝  │
                                                            │  █████╗  ██║   ██║█████╗  ██╔██╗ ██║   ██║   █████╗  ███████╗  │
                                                            │  ██╔══╝  ██║   ██║██╔══╝  ██║╚██╗██║   ██║   ██╔══╝  ╚════██║  │
                                                            │  ██║     ╚██████╔╝███████╗██║ ╚████║   ██║   ███████╗███████║  │
                                                            │  ╚═╝      ╚═════╝ ╚══════╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝  │
                                                            │                                                                │
                                                            ╚────────────────────────────────────────────────────────────────╝");
                                Console.WriteLine("                                                                        ┌───────────────────────────────────────┐\n");
                                Console.WriteLine("                                                                              --------- Plantillas ---------");
                                Console.WriteLine("                                                                              |- Restablecer todo ------ (R)");
                                currentForegroundColor = Console.ForegroundColor;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("                                                                              |- Blanco ---------------- (B)");
                                Console.ForegroundColor = currentForegroundColor;
                                Console.WriteLine("                                                                              |- Negro ----------------- (N)");
                                Console.WriteLine("                                                                              |- Amarillo -------------- (A)");
                                Console.WriteLine("                                                                              |- Azul ------------------ (Z)");
                                Console.WriteLine("                                                                              |- Verde ----------------- (E)");
                                Console.WriteLine("                                                                              |- Volver ---------------- (V)\n");
                                Console.WriteLine("                                                                        └───────────────────────────────────────┘\n");
                                Thread.Sleep(500);
                                Console.Clear();

                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;

                            case ConsoleKey.N:
                                Console.Clear();
                                Console.WriteLine(@"
                        
                        
                        
                        
                        
                        
                        
                        
                                                            
                                                            
                                                            ╔────────────────────────────────────────────────────────────────╗
                                                            │                                                                │
                                                            │  ███████╗██╗   ██╗███████╗███╗   ██╗████████╗███████╗███████╗  │
                                                            │  ██╔════╝██║   ██║██╔════╝████╗  ██║╚══██╔══╝██╔════╝██╔════╝  │
                                                            │  █████╗  ██║   ██║█████╗  ██╔██╗ ██║   ██║   █████╗  ███████╗  │
                                                            │  ██╔══╝  ██║   ██║██╔══╝  ██║╚██╗██║   ██║   ██╔══╝  ╚════██║  │
                                                            │  ██║     ╚██████╔╝███████╗██║ ╚████║   ██║   ███████╗███████║  │
                                                            │  ╚═╝      ╚═════╝ ╚══════╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝  │
                                                            │                                                                │
                                                            ╚────────────────────────────────────────────────────────────────╝");
                                Console.WriteLine("                                                                        ┌───────────────────────────────────────┐\n");
                                Console.WriteLine("                                                                              --------- Plantillas ---------");
                                Console.WriteLine("                                                                              |- Restablecer todo ------ (R)");
                                Console.WriteLine("                                                                              |- Blanco ---------------- (B)");
                                currentForegroundColor = Console.ForegroundColor;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("                                                                              |- Negro ----------------- (N)");
                                Console.ForegroundColor = currentForegroundColor;
                                Console.WriteLine("                                                                              |- Amarillo -------------- (A)");
                                Console.WriteLine("                                                                              |- Azul ------------------ (Z)");
                                Console.WriteLine("                                                                              |- Verde ----------------- (E)");
                                Console.WriteLine("                                                                              |- Volver ---------------- (V)\n");
                                Console.WriteLine("                                                                        └───────────────────────────────────────┘\n");
                                Thread.Sleep(500);
                                Console.Clear();

                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                break;

                            case ConsoleKey.A:
                                Console.Clear();
                                Console.WriteLine(@"
                        
                        
                        
                        
                        
                        
                        
                        
                                                            
                                                            
                                                            ╔────────────────────────────────────────────────────────────────╗
                                                            │                                                                │
                                                            │  ███████╗██╗   ██╗███████╗███╗   ██╗████████╗███████╗███████╗  │
                                                            │  ██╔════╝██║   ██║██╔════╝████╗  ██║╚══██╔══╝██╔════╝██╔════╝  │
                                                            │  █████╗  ██║   ██║█████╗  ██╔██╗ ██║   ██║   █████╗  ███████╗  │
                                                            │  ██╔══╝  ██║   ██║██╔══╝  ██║╚██╗██║   ██║   ██╔══╝  ╚════██║  │
                                                            │  ██║     ╚██████╔╝███████╗██║ ╚████║   ██║   ███████╗███████║  │
                                                            │  ╚═╝      ╚═════╝ ╚══════╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝  │
                                                            │                                                                │
                                                            ╚────────────────────────────────────────────────────────────────╝");
                                Console.WriteLine("                                                                        ┌───────────────────────────────────────┐\n");
                                Console.WriteLine("                                                                              --------- Plantillas ---------");
                                Console.WriteLine("                                                                              |- Restablecer todo ------ (R)");
                                Console.WriteLine("                                                                              |- Blanco ---------------- (B)");
                                Console.WriteLine("                                                                              |- Negro ----------------- (N)");
                                currentForegroundColor = Console.ForegroundColor;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("                                                                              |- Amarillo -------------- (A)");
                                Console.ForegroundColor = currentForegroundColor;
                                Console.WriteLine("                                                                              |- Azul ------------------ (Z)");
                                Console.WriteLine("                                                                              |- Verde ----------------- (E)");
                                Console.WriteLine("                                                                              |- Volver ---------------- (V)\n");
                                Console.WriteLine("                                                                        └───────────────────────────────────────┘\n");
                                Thread.Sleep(500);
                                Console.Clear();

                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;

                            case ConsoleKey.Z:
                                Console.Clear();
                                Console.WriteLine(@"
                        
                        
                        
                        
                        
                        
                        
                        
                                                            
                                                            
                                                            ╔────────────────────────────────────────────────────────────────╗
                                                            │                                                                │
                                                            │  ███████╗██╗   ██╗███████╗███╗   ██╗████████╗███████╗███████╗  │
                                                            │  ██╔════╝██║   ██║██╔════╝████╗  ██║╚══██╔══╝██╔════╝██╔════╝  │
                                                            │  █████╗  ██║   ██║█████╗  ██╔██╗ ██║   ██║   █████╗  ███████╗  │
                                                            │  ██╔══╝  ██║   ██║██╔══╝  ██║╚██╗██║   ██║   ██╔══╝  ╚════██║  │
                                                            │  ██║     ╚██████╔╝███████╗██║ ╚████║   ██║   ███████╗███████║  │
                                                            │  ╚═╝      ╚═════╝ ╚══════╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝  │
                                                            │                                                                │
                                                            ╚────────────────────────────────────────────────────────────────╝");
                                Console.WriteLine("                                                                        ┌───────────────────────────────────────┐\n");
                                Console.WriteLine("                                                                              --------- Plantillas ---------");
                                Console.WriteLine("                                                                              |- Restablecer todo ------ (R)");
                                Console.WriteLine("                                                                              |- Blanco ---------------- (B)");
                                Console.WriteLine("                                                                              |- Negro ----------------- (N)");
                                Console.WriteLine("                                                                              |- Amarillo -------------- (A)");
                                currentForegroundColor = Console.ForegroundColor;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("                                                                              |- Azul ------------------ (Z)");
                                Console.ForegroundColor = currentForegroundColor;
                                Console.WriteLine("                                                                              |- Verde ----------------- (E)");
                                Console.WriteLine("                                                                              |- Volver ---------------- (V)\n");
                                Console.WriteLine("                                                                        └───────────────────────────────────────┘\n");
                                Thread.Sleep(500);
                                Console.Clear();

                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;

                            case ConsoleKey.E:
                                Console.Clear();
                                Console.WriteLine(@"
                        
                        
                        
                        
                        
                        
                        
                        
                                                            
                                                            
                                                            ╔────────────────────────────────────────────────────────────────╗
                                                            │                                                                │
                                                            │  ███████╗██╗   ██╗███████╗███╗   ██╗████████╗███████╗███████╗  │
                                                            │  ██╔════╝██║   ██║██╔════╝████╗  ██║╚══██╔══╝██╔════╝██╔════╝  │
                                                            │  █████╗  ██║   ██║█████╗  ██╔██╗ ██║   ██║   █████╗  ███████╗  │
                                                            │  ██╔══╝  ██║   ██║██╔══╝  ██║╚██╗██║   ██║   ██╔══╝  ╚════██║  │
                                                            │  ██║     ╚██████╔╝███████╗██║ ╚████║   ██║   ███████╗███████║  │
                                                            │  ╚═╝      ╚═════╝ ╚══════╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝  │
                                                            │                                                                │
                                                            ╚────────────────────────────────────────────────────────────────╝");
                                Console.WriteLine("                                                                        ┌───────────────────────────────────────┐\n");
                                Console.WriteLine("                                                                              --------- Plantillas ---------");
                                Console.WriteLine("                                                                              |- Restablecer todo ------ (R)");
                                Console.WriteLine("                                                                              |- Blanco ---------------- (B)");
                                Console.WriteLine("                                                                              |- Negro ----------------- (N)");
                                Console.WriteLine("                                                                              |- Amarillo -------------- (A)");
                                Console.WriteLine("                                                                              |- Azul ------------------ (Z)");
                                currentForegroundColor = Console.ForegroundColor;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("                                                                              |- Verde ----------------- (E)");
                                Console.ForegroundColor = currentForegroundColor;
                                Console.WriteLine("                                                                              |- Volver ---------------- (V)\n");
                                Console.WriteLine("                                                                        └───────────────────────────────────────┘\n");
                                Thread.Sleep(500);
                                Console.Clear();

                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;

                            case ConsoleKey.V:
                                Console.Clear();
                                Console.WriteLine(@"
                        
                        
                        
                        
                        
                        
                        
                        
                                                            
                                                            
                                                            ╔────────────────────────────────────────────────────────────────╗
                                                            │                                                                │
                                                            │  ███████╗██╗   ██╗███████╗███╗   ██╗████████╗███████╗███████╗  │
                                                            │  ██╔════╝██║   ██║██╔════╝████╗  ██║╚══██╔══╝██╔════╝██╔════╝  │
                                                            │  █████╗  ██║   ██║█████╗  ██╔██╗ ██║   ██║   █████╗  ███████╗  │
                                                            │  ██╔══╝  ██║   ██║██╔══╝  ██║╚██╗██║   ██║   ██╔══╝  ╚════██║  │
                                                            │  ██║     ╚██████╔╝███████╗██║ ╚████║   ██║   ███████╗███████║  │
                                                            │  ╚═╝      ╚═════╝ ╚══════╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝  │
                                                            │                                                                │
                                                            ╚────────────────────────────────────────────────────────────────╝");
                                Console.WriteLine("                                                                        ┌───────────────────────────────────────┐\n");
                                Console.WriteLine("                                                                              --------- Plantillas ---------");
                                Console.WriteLine("                                                                              |- Restablecer todo ------ (R)");
                                Console.WriteLine("                                                                              |- Blanco ---------------- (B)");
                                Console.WriteLine("                                                                              |- Negro ----------------- (N)");
                                Console.WriteLine("                                                                              |- Amarillo -------------- (A)");
                                Console.WriteLine("                                                                              |- Azul ------------------ (Z)");
                                Console.WriteLine("                                                                              |- Verde ----------------- (E)");
                                currentForegroundColor = Console.ForegroundColor;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("                                                                              |- Volver ---------------- (V)\n");
                                Console.ForegroundColor = currentForegroundColor;
                                Console.WriteLine("                                                                        └───────────────────────────────────────┘\n");
                                Thread.Sleep(500);
                                Console.Clear();

                                fuenteFondo = false;
                                Console.Clear();
                                break;

                            default:
                                continue;
                        }
                    } while (fuenteFondo);
                    Console.ReadKey();
                    break;

                case ConsoleKey.M:
                    Console.Clear();
                    Console.WriteLine(@"
            
            
            
            
            
            
            
            
            
            
            
            
                                ╔──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╗
                                │                                                                                                                          │
                                │   ██████╗ ██████╗ ███╗   ██╗███████╗██╗ ██████╗ ██╗   ██╗██████╗  █████╗  ██████╗██╗ ██████╗ ███╗   ██╗███████╗███████╗  │
                                │  ██╔════╝██╔═══██╗████╗  ██║██╔════╝██║██╔════╝ ██║   ██║██╔══██╗██╔══██╗██╔════╝██║██╔═══██╗████╗  ██║██╔════╝██╔════╝  │
                                │  ██║     ██║   ██║██╔██╗ ██║█████╗  ██║██║  ███╗██║   ██║██████╔╝███████║██║     ██║██║   ██║██╔██╗ ██║█████╗  ███████╗  │
                                │  ██║     ██║   ██║██║╚██╗██║██╔══╝  ██║██║   ██║██║   ██║██╔══██╗██╔══██║██║     ██║██║   ██║██║╚██╗██║██╔══╝  ╚════██║  │
                                │  ╚██████╗╚██████╔╝██║ ╚████║██║     ██║╚██████╔╝╚██████╔╝██║  ██║██║  ██║╚██████╗██║╚██████╔╝██║ ╚████║███████╗███████║  │
                                │   ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝     ╚═╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝╚══════╝  │
                                │                                                                                                                          │
                                ╚──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                         ┌───────────────────────────────┐\n");
                    Console.WriteLine("                                                                             --------- Menu ---------");
                    Console.WriteLine("                                                                             |- Fuentes --------- (F)");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                             |- Musica ---------- (M)");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                             |- Volver ---------- (V)\n");
                    Console.WriteLine("                                                                         └───────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    bool musicSIONO = true;
                    Console.Clear();
                    do
                    {
                        Console.Clear();
                        Console.WriteLine(@"
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                                                                ╔───────────────────────────────────────────────────╗
                                                                │                                                   │
                                                                │  ███╗   ███╗██╗   ██╗███████╗██╗ ██████╗ █████╗   │
                                                                │  ████╗ ████║██║   ██║██╔════╝██║██╔════╝██╔══██╗  │
                                                                │  ██╔████╔██║██║   ██║███████╗██║██║     ███████║  │
                                                                │  ██║╚██╔╝██║██║   ██║╚════██║██║██║     ██╔══██║  │
                                                                │  ██║ ╚═╝ ██║╚██████╔╝███████║██║╚██████╗██║  ██║  │
                                                                │  ╚═╝     ╚═╝ ╚═════╝ ╚══════╝╚═╝ ╚═════╝╚═╝  ╚═╝  │
                                                                │                                                   │
                                                                ╚───────────────────────────────────────────────────╝");
                        Console.WriteLine("                                                                      ┌───────────────────────────────────────┐\n");
                        Console.WriteLine("                                                                           ----------- Menu -----------");
                        Console.WriteLine("                                                                           |- Iniciar Uno ---------- (U)");
                        Console.WriteLine("                                                                           |- Iniciar Dos ---------- (D)");
                        Console.WriteLine("                                                                           |- Clasico     ---------- (C)");
                        Console.WriteLine("                                                                           |- Detener -------------- (X)");
                        Console.WriteLine("                                                                           |- Volver --------------- (V)\n");
                        Console.WriteLine("                                                                      └───────────────────────────────────────┘\n");

                        key = Console.ReadKey(true).Key;

                        switch (key)
                        {
                            case ConsoleKey.U:
                                Console.Clear();
                                Console.WriteLine(@"
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                                                                ╔───────────────────────────────────────────────────╗
                                                                │                                                   │
                                                                │  ███╗   ███╗██╗   ██╗███████╗██╗ ██████╗ █████╗   │
                                                                │  ████╗ ████║██║   ██║██╔════╝██║██╔════╝██╔══██╗  │
                                                                │  ██╔████╔██║██║   ██║███████╗██║██║     ███████║  │
                                                                │  ██║╚██╔╝██║██║   ██║╚════██║██║██║     ██╔══██║  │
                                                                │  ██║ ╚═╝ ██║╚██████╔╝███████║██║╚██████╗██║  ██║  │
                                                                │  ╚═╝     ╚═╝ ╚═════╝ ╚══════╝╚═╝ ╚═════╝╚═╝  ╚═╝  │
                                                                │                                                   │
                                                                ╚───────────────────────────────────────────────────╝");
                                Console.WriteLine("                                                                      ┌───────────────────────────────────────┐\n");
                                Console.WriteLine("                                                                           ----------- Menu -----------");
                                currentForegroundColor = Console.ForegroundColor;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("                                                                           |- Iniciar Uno ---------- (U)");
                                Console.ForegroundColor = currentForegroundColor;
                                Console.WriteLine("                                                                           |- Iniciar Dos ---------- (D)");
                                Console.WriteLine("                                                                           |- Clasico     ---------- (C)");
                                Console.WriteLine("                                                                           |- Detener -------------- (X)");
                                Console.WriteLine("                                                                           |- Volver --------------- (V)\n");
                                Console.WriteLine("                                                                      └───────────────────────────────────────┘\n");

                                Thread.Sleep(500);

                                if (outputDevice != null && outputDevice.PlaybackState == PlaybackState.Playing)
                                {
                                    Console.SetCursorPosition(75, 21);
                                    Console.WriteLine("Ya esta reproduciendo una pista.");
                                    Console.ReadKey();
                                    Console.SetCursorPosition(75, 21);
                                    Console.WriteLine("╚───────────────────────────────────────────────────╝");
                                    break;
                                }

                                Console.SetCursorPosition(82, 21);
                                Console.WriteLine("Reproduciendo...");
                                audioFile = new AudioFileReader(filePath);
                                outputDevice = new WaveOutEvent();
                                outputDevice.Init(audioFile);
                                outputDevice.Play();
                                Console.ReadKey();
                                Console.SetCursorPosition(75, 21);
                                Console.WriteLine("╚───────────────────────────────────────────────────╝");
                                break;

                            case ConsoleKey.D:
                                Console.Clear();
                                Console.WriteLine(@"
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                                                                ╔───────────────────────────────────────────────────╗
                                                                │                                                   │
                                                                │  ███╗   ███╗██╗   ██╗███████╗██╗ ██████╗ █████╗   │
                                                                │  ████╗ ████║██║   ██║██╔════╝██║██╔════╝██╔══██╗  │
                                                                │  ██╔████╔██║██║   ██║███████╗██║██║     ███████║  │
                                                                │  ██║╚██╔╝██║██║   ██║╚════██║██║██║     ██╔══██║  │
                                                                │  ██║ ╚═╝ ██║╚██████╔╝███████║██║╚██████╗██║  ██║  │
                                                                │  ╚═╝     ╚═╝ ╚═════╝ ╚══════╝╚═╝ ╚═════╝╚═╝  ╚═╝  │
                                                                │                                                   │
                                                                ╚───────────────────────────────────────────────────╝");
                                Console.WriteLine("                                                                      ┌───────────────────────────────────────┐\n");
                                Console.WriteLine("                                                                           ----------- Menu -----------");
                                Console.WriteLine("                                                                           |- Iniciar Uno ---------- (U)");
                                currentForegroundColor = Console.ForegroundColor;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("                                                                           |- Iniciar Dos ---------- (D)");
                                Console.ForegroundColor = currentForegroundColor;
                                Console.WriteLine("                                                                           |- Clasico     ---------- (C)");
                                Console.WriteLine("                                                                           |- Detener -------------- (X)");
                                Console.WriteLine("                                                                           |- Volver --------------- (V)\n");
                                Console.WriteLine("                                                                      └───────────────────────────────────────┘\n");

                                Thread.Sleep(500);

                                if (outputDevice != null && outputDevice.PlaybackState == PlaybackState.Playing)
                                {
                                    Console.SetCursorPosition(75, 21);
                                    Console.WriteLine("Ya esta reproduciendo una pista.");
                                    Console.ReadKey();
                                    Console.SetCursorPosition(75, 21);
                                    Console.WriteLine("╚───────────────────────────────────────────────────╝");
                                    break;
                                }


                                Console.SetCursorPosition(82, 21);
                                Console.WriteLine("Reproduciendo...");
                                audioFile = new AudioFileReader(filePath1);
                                outputDevice = new WaveOutEvent();
                                outputDevice.Init(audioFile);
                                outputDevice.Play();
                                Console.ReadKey();
                                Console.SetCursorPosition(75, 21);
                                Console.WriteLine("╚───────────────────────────────────────────────────╝");
                                break;

                            case ConsoleKey.C:
                                Console.Clear();
                                Console.WriteLine(@"
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                                                                ╔───────────────────────────────────────────────────╗
                                                                │                                                   │
                                                                │  ███╗   ███╗██╗   ██╗███████╗██╗ ██████╗ █████╗   │
                                                                │  ████╗ ████║██║   ██║██╔════╝██║██╔════╝██╔══██╗  │
                                                                │  ██╔████╔██║██║   ██║███████╗██║██║     ███████║  │
                                                                │  ██║╚██╔╝██║██║   ██║╚════██║██║██║     ██╔══██║  │
                                                                │  ██║ ╚═╝ ██║╚██████╔╝███████║██║╚██████╗██║  ██║  │
                                                                │  ╚═╝     ╚═╝ ╚═════╝ ╚══════╝╚═╝ ╚═════╝╚═╝  ╚═╝  │
                                                                │                                                   │
                                                                ╚───────────────────────────────────────────────────╝");
                                Console.WriteLine("                                                                      ┌───────────────────────────────────────┐\n");
                                Console.WriteLine("                                                                           ----------- Menu -----------");
                                Console.WriteLine("                                                                           |- Iniciar Uno ---------- (U)");
                                Console.WriteLine("                                                                           |- Iniciar Dos ---------- (D)");
                                currentForegroundColor = Console.ForegroundColor;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("                                                                           |- Clasico     ---------- (C)");
                                Console.ForegroundColor = currentForegroundColor;
                                Console.WriteLine("                                                                           |- Detener -------------- (X)");
                                Console.WriteLine("                                                                           |- Volver --------------- (V)\n");
                                Console.WriteLine("                                                                      └───────────────────────────────────────┘\n");

                                Thread.Sleep(500);

                                if (outputDevice != null && outputDevice.PlaybackState == PlaybackState.Playing)
                                {
                                    Console.SetCursorPosition(75, 21);
                                    Console.WriteLine("Ya esta reproduciendo una pista.");
                                    Console.ReadKey();
                                    Console.SetCursorPosition(75, 21);
                                    Console.WriteLine("╚───────────────────────────────────────────────────╝");
                                    break;
                                }

                                Console.SetCursorPosition(82, 21);
                                Console.WriteLine("Reproduciendo...");
                                audioFile = new AudioFileReader(filePath2);
                                outputDevice = new WaveOutEvent();
                                outputDevice.Init(audioFile);
                                outputDevice.Play();
                                Console.ReadKey();
                                Console.SetCursorPosition(75, 21);
                                Console.WriteLine("╚───────────────────────────────────────────────────╝");
                                break;

                            case ConsoleKey.X:
                                Console.Clear();
                                Console.WriteLine(@"
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                                                                ╔───────────────────────────────────────────────────╗
                                                                │                                                   │
                                                                │  ███╗   ███╗██╗   ██╗███████╗██╗ ██████╗ █████╗   │
                                                                │  ████╗ ████║██║   ██║██╔════╝██║██╔════╝██╔══██╗  │
                                                                │  ██╔████╔██║██║   ██║███████╗██║██║     ███████║  │
                                                                │  ██║╚██╔╝██║██║   ██║╚════██║██║██║     ██╔══██║  │
                                                                │  ██║ ╚═╝ ██║╚██████╔╝███████║██║╚██████╗██║  ██║  │
                                                                │  ╚═╝     ╚═╝ ╚═════╝ ╚══════╝╚═╝ ╚═════╝╚═╝  ╚═╝  │
                                                                │                                                   │
                                                                ╚───────────────────────────────────────────────────╝");
                                Console.WriteLine("                                                                      ┌───────────────────────────────────────┐\n");
                                Console.WriteLine("                                                                           ----------- Menu -----------");
                                Console.WriteLine("                                                                           |- Iniciar Uno ---------- (U)");
                                Console.WriteLine("                                                                           |- Iniciar Dos ---------- (D)");
                                Console.WriteLine("                                                                           |- Clasico     ---------- (C)");
                                currentForegroundColor = Console.ForegroundColor;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("                                                                           |- Detener -------------- (X)");
                                Console.ForegroundColor = currentForegroundColor;
                                Console.WriteLine("                                                                           |- Volver --------------- (V)\n");
                                Console.WriteLine("                                                                      └───────────────────────────────────────┘\n");

                                Thread.Sleep(500);

                                Console.SetCursorPosition(84, 21);
                                Console.WriteLine("Deteniendo...");
                                outputDevice.Stop();
                                outputDevice.Dispose();
                                audioFile.Dispose();
                                Console.ReadKey();
                                Console.SetCursorPosition(75, 21);
                                Console.WriteLine("╚───────────────────────────────────────────────────╝");
                                break;

                            case ConsoleKey.V:
                                Console.Clear();
                                Console.WriteLine(@"
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                                                                ╔───────────────────────────────────────────────────╗
                                                                │                                                   │
                                                                │  ███╗   ███╗██╗   ██╗███████╗██╗ ██████╗ █████╗   │
                                                                │  ████╗ ████║██║   ██║██╔════╝██║██╔════╝██╔══██╗  │
                                                                │  ██╔████╔██║██║   ██║███████╗██║██║     ███████║  │
                                                                │  ██║╚██╔╝██║██║   ██║╚════██║██║██║     ██╔══██║  │
                                                                │  ██║ ╚═╝ ██║╚██████╔╝███████║██║╚██████╗██║  ██║  │
                                                                │  ╚═╝     ╚═╝ ╚═════╝ ╚══════╝╚═╝ ╚═════╝╚═╝  ╚═╝  │
                                                                │                                                   │
                                                                ╚───────────────────────────────────────────────────╝");
                                Console.WriteLine("                                                                      ┌───────────────────────────────────────┐\n");
                                Console.WriteLine("                                                                           ----------- Menu -----------");
                                Console.WriteLine("                                                                           |- Iniciar Uno ---------- (U)");
                                Console.WriteLine("                                                                           |- Iniciar Dos ---------- (D)");
                                Console.WriteLine("                                                                           |- Clasico     ---------- (C)");
                                Console.WriteLine("                                                                           |- Detener -------------- (X)");
                                currentForegroundColor = Console.ForegroundColor;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("                                                                           |- Volver --------------- (V)\n");
                                Console.ForegroundColor = currentForegroundColor;
                                Console.WriteLine("                                                                      └───────────────────────────────────────┘\n");

                                Thread.Sleep(500);
                                Console.Clear();

                                musicSIONO = false;
                                Console.Clear();
                                break;

                            default:
                                continue;
                        }

                    } while (musicSIONO);
                    break;

                case ConsoleKey.V:
                    Console.Clear();
                    Console.WriteLine(@"
            
            
            
            
            
            
            
            
            
            
            
            
                                ╔──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╗
                                │                                                                                                                          │
                                │   ██████╗ ██████╗ ███╗   ██╗███████╗██╗ ██████╗ ██╗   ██╗██████╗  █████╗  ██████╗██╗ ██████╗ ███╗   ██╗███████╗███████╗  │
                                │  ██╔════╝██╔═══██╗████╗  ██║██╔════╝██║██╔════╝ ██║   ██║██╔══██╗██╔══██╗██╔════╝██║██╔═══██╗████╗  ██║██╔════╝██╔════╝  │
                                │  ██║     ██║   ██║██╔██╗ ██║█████╗  ██║██║  ███╗██║   ██║██████╔╝███████║██║     ██║██║   ██║██╔██╗ ██║█████╗  ███████╗  │
                                │  ██║     ██║   ██║██║╚██╗██║██╔══╝  ██║██║   ██║██║   ██║██╔══██╗██╔══██║██║     ██║██║   ██║██║╚██╗██║██╔══╝  ╚════██║  │
                                │  ╚██████╗╚██████╔╝██║ ╚████║██║     ██║╚██████╔╝╚██████╔╝██║  ██║██║  ██║╚██████╗██║╚██████╔╝██║ ╚████║███████╗███████║  │
                                │   ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝     ╚═╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝╚══════╝  │
                                │                                                                                                                          │
                                ╚──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╝");
                    Console.WriteLine("                                                                         ┌───────────────────────────────┐\n");
                    Console.WriteLine("                                                                             --------- Menu ---------");
                    Console.WriteLine("                                                                             |- Fuentes --------- (F)");
                    Console.WriteLine("                                                                             |- Musica ---------- (M)");
                    currentForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                                             |- Volver ---------- (V)\n");
                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine("                                                                         └───────────────────────────────┘\n");
                    Thread.Sleep(500);
                    Console.Clear();

                    salirBubleConfiguracion = false;
                    Console.Clear();
                    break;

                default:
                    continue;
            }
        } while (salirBubleConfiguracion);
    }
    static void cronometroInternoVisto()//extras
    {
        Console.Clear();
        Console.WriteLine(@"
        
        
        
        
        
        
        
                                                ╔────────────────────────────────────────────────────────────────────────────────────────────╗
                                                │                                                                                            │
                                                │                  ██████╗ ██╗   ██╗██╗     ███████╗████████╗ █████╗                         │
                                                │                  ██╔══██╗██║   ██║██║     ██╔════╝╚══██╔══╝██╔══██╗                        │
                                                │                  ██████╔╝██║   ██║██║     █████╗     ██║   ███████║                        │
                                                │                  ██╔══██╗██║   ██║██║     ██╔══╝     ██║   ██╔══██║                        │
                                                │                  ██║  ██║╚██████╔╝███████╗███████╗   ██║   ██║  ██║                        │
                                                │                  ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚══════╝   ╚═╝   ╚═╝  ╚═╝                        │
                                                │                                                                                            │
                                                │  ███████╗███████╗████████╗██╗   ██╗██████╗ ██╗ █████╗ ███╗   ██╗████████╗███████╗███████╗  │
                                                │  ██╔════╝██╔════╝╚══██╔══╝██║   ██║██╔══██╗██║██╔══██╗████╗  ██║╚══██╔══╝██╔════╝██╔════╝  │
                                                │  █████╗  ███████╗   ██║   ██║   ██║██║  ██║██║███████║██╔██╗ ██║   ██║   █████╗  ███████╗  │
                                                │  ██╔══╝  ╚════██║   ██║   ██║   ██║██║  ██║██║██╔══██║██║╚██╗██║   ██║   ██╔══╝  ╚════██║  │
                                                │  ███████╗███████║   ██║   ╚██████╔╝██████╔╝██║██║  ██║██║ ╚████║   ██║   ███████╗███████║  │
                                                │  ╚══════╝╚══════╝   ╚═╝    ╚═════╝ ╚═════╝ ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝  │
                                                │                                                                                            │
                                                ╚────────────────────────────────────────────────────────────────────────────────────────────╝");
        Console.WriteLine("                                                                           ┌──────────────────────────────────┐\n");
        Console.WriteLine("                                                                                --------- Menu ---------");
        Console.WriteLine("                                                                                |- Ruleta ---------- (R)");
        Console.WriteLine("                                                                                |- Manejo Archivos - (M)");
        ConsoleColor currentForegroundColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("                                                                                |- Cronometro int -- (I)");
        Console.ResetColor();
        Console.ForegroundColor = currentForegroundColor;
        Console.WriteLine("                                                                                |- Tutorial -------- (T)");
        Console.WriteLine("                                                                                |- Configuraciones - (C)");
        Console.WriteLine("                                                                                |- Sugerencias ----- (S)");
        Console.WriteLine("                                                                                |- Salir ----------- (X)\n");
        Console.WriteLine("                                                                           └──────────────────────────────────┘\n");

        Thread.Sleep(500);
        Console.Clear();

        Stopwatch cronometro = new Stopwatch(); // esta parte crea y inicializa la clase Stopwatch que es utilizada para medir el tiempo
        bool cronometroBucleEntrar = true;

        Console.Clear();
        Console.WriteLine(@"
        
        
        
        
        
        
        
        
                                                
                                                
                                                
                                                
                                                
                                                ╔─────────────────────────────────────────────────────────────────────────────────────────────╗
                                                │                                                                                             │
                                                │   ██████╗██████╗  ██████╗ ███╗   ██╗ ██████╗ ███╗   ███╗███████╗████████╗██████╗  ██████╗   │
                                                │  ██╔════╝██╔══██╗██╔═══██╗████╗  ██║██╔═══██╗████╗ ████║██╔════╝╚══██╔══╝██╔══██╗██╔═══██╗  │
                                                │  ██║     ██████╔╝██║   ██║██╔██╗ ██║██║   ██║██╔████╔██║█████╗     ██║   ██████╔╝██║   ██║  │
                                                │  ██║     ██╔══██╗██║   ██║██║╚██╗██║██║   ██║██║╚██╔╝██║██╔══╝     ██║   ██╔══██╗██║   ██║  │
                                                │  ╚██████╗██║  ██║╚██████╔╝██║ ╚████║╚██████╔╝██║ ╚═╝ ██║███████╗   ██║   ██║  ██║╚██████╔╝  │
                                                │   ╚═════╝╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝   ╚═╝   ╚═╝  ╚═╝ ╚═════╝   │
                                                │                                                                                             │
                                                ╚─────────────────────────────────────────────────────────────────────────────────────────────╝");
        Console.WriteLine("                                                                             ┌──────────────────────────────────┐\n");
        Console.WriteLine("                                                                                   --------- Menu ---------");
        Console.WriteLine("                                                                                   |- Iniciar --------- (I)");
        Console.WriteLine("                                                                                   |- Detener --------- (D)");
        Console.WriteLine("                                                                                   |- Reiniciar ------- (R)");
        Console.WriteLine("                                                                                   |- Volver ---------- (V)\n");
        Console.WriteLine("                                                                             └──────────────────────────────────┘\n");

        //esta variables almacenan la posicion vertical y horizon tal del curso en la consola
        int cursorLeft = Console.CursorLeft;
        int cursorTop = Console.CursorTop;

        while (cronometroBucleEntrar)
        {
            if (cronometro.IsRunning)
            {
                TimeSpan tiempo = cronometro.Elapsed; //inicia 
                Console.SetCursorPosition(cursorLeft, cursorTop); //se coloca el curso en la posion ya alamcena
                Console.WriteLine($"                                                 ---------[ Tiempo transcurrido: {tiempo}      ");// el espacio en las lineas es para limpiar
            }

            if (Console.KeyAvailable) //comprueva si hay una tecla presiona o si se precio
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.I:
                        if (!cronometro.IsRunning)
                        {
                            cronometro.Start();
                        }
                        else
                        {
                            Console.SetCursorPosition(cursorLeft, cursorTop + 2);// mueve el curso a la posicion que ya se guardo y lo mueve dos lineas haci abajo
                            Console.WriteLine("                                                 ---------[ El cronómetro ya está en marcha.                ");
                        }
                        break;

                    case ConsoleKey.D:
                        if (cronometro.IsRunning)
                        {
                            cronometro.Stop();
                            Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                            Console.WriteLine($"                                                 ---------[ Cronómetro detenido en: {cronometro.Elapsed}   ");
                        }
                        else
                        {
                            Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                            Console.WriteLine("                                                 ---------[ El cronómetro no está en marcha.               ");
                        }
                        break;

                    case ConsoleKey.R:
                        cronometro.Reset();
                        Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                        Console.WriteLine("                                                 ---------[ Cronómetro reiniciado.                         ");
                        break;

                    case ConsoleKey.V:
                        cronometroBucleEntrar = false;
                        Console.Clear();
                        break;

                    default:
                        continue;
                }
            }
        }
    }
    static void sugerenciaBuzon()//extras
    {
        Console.Clear();
        Console.WriteLine(@"
        
        
        
        
        
        
        
                                                ╔────────────────────────────────────────────────────────────────────────────────────────────╗
                                                │                                                                                            │
                                                │                  ██████╗ ██╗   ██╗██╗     ███████╗████████╗ █████╗                         │
                                                │                  ██╔══██╗██║   ██║██║     ██╔════╝╚══██╔══╝██╔══██╗                        │
                                                │                  ██████╔╝██║   ██║██║     █████╗     ██║   ███████║                        │
                                                │                  ██╔══██╗██║   ██║██║     ██╔══╝     ██║   ██╔══██║                        │
                                                │                  ██║  ██║╚██████╔╝███████╗███████╗   ██║   ██║  ██║                        │
                                                │                  ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚══════╝   ╚═╝   ╚═╝  ╚═╝                        │
                                                │                                                                                            │
                                                │  ███████╗███████╗████████╗██╗   ██╗██████╗ ██╗ █████╗ ███╗   ██╗████████╗███████╗███████╗  │
                                                │  ██╔════╝██╔════╝╚══██╔══╝██║   ██║██╔══██╗██║██╔══██╗████╗  ██║╚══██╔══╝██╔════╝██╔════╝  │
                                                │  █████╗  ███████╗   ██║   ██║   ██║██║  ██║██║███████║██╔██╗ ██║   ██║   █████╗  ███████╗  │
                                                │  ██╔══╝  ╚════██║   ██║   ██║   ██║██║  ██║██║██╔══██║██║╚██╗██║   ██║   ██╔══╝  ╚════██║  │
                                                │  ███████╗███████║   ██║   ╚██████╔╝██████╔╝██║██║  ██║██║ ╚████║   ██║   ███████╗███████║  │
                                                │  ╚══════╝╚══════╝   ╚═╝    ╚═════╝ ╚═════╝ ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝  │
                                                │                                                                                            │
                                                ╚────────────────────────────────────────────────────────────────────────────────────────────╝");
        Console.WriteLine("                                                                           ┌──────────────────────────────────┐\n");
        Console.WriteLine("                                                                                --------- Menu ---------");
        Console.WriteLine("                                                                                |- Ruleta ---------- (R)");
        Console.WriteLine("                                                                                |- Manejo Archivos - (M)");
        Console.WriteLine("                                                                                |- Cronometro int -- (I)");
        Console.WriteLine("                                                                                |- Tutorial -------- (T)");
        Console.WriteLine("                                                                                |- Configuraciones - (C)");
        ConsoleColor currentForegroundColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("                                                                                |- Sugerencias ----- (S)");
        Console.ForegroundColor = currentForegroundColor;
        Console.WriteLine("                                                                                |- Salir ----------- (X)\n");
        Console.WriteLine("                                                                           └──────────────────────────────────┘\n");

        Thread.Sleep(500);
        Console.Clear();

        Console.CursorVisible = true;
        Console.Clear();
        DateTime fechaActual = DateTime.Now;

        Console.WriteLine(@"
        
        
        
        
        
        
        
                                                        ╔───────────────────────────────────────────────────────────────────────────────────╗
                                                        │                                                                                   │
                                                        │       █████╗  ██████╗ ██████╗ ███████╗ ██████╗  █████╗ ██████╗      █████╗        │
                                                        │      ██╔══██╗██╔════╝ ██╔══██╗██╔════╝██╔════╝ ██╔══██╗██╔══██╗    ██╔══██╗       │
                                                        │      ███████║██║  ███╗██████╔╝█████╗  ██║  ███╗███████║██████╔╝    ███████║       │
                                                        │      ██╔══██║██║   ██║██╔══██╗██╔══╝  ██║   ██║██╔══██║██╔══██╗    ██╔══██║       │
                                                        │      ██║  ██║╚██████╔╝██║  ██║███████╗╚██████╔╝██║  ██║██║  ██║    ██║  ██║       │
                                                        │      ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝    ╚═╝  ╚═╝       │
                                                        │  ███████╗██╗   ██╗ ██████╗ ███████╗██████╗ ███████╗███╗   ██╗ ██████╗██╗ █████╗   │
                                                        │  ██╔════╝██║   ██║██╔════╝ ██╔════╝██╔══██╗██╔════╝████╗  ██║██╔════╝██║██╔══██╗  │
                                                        │  ███████╗██║   ██║██║  ███╗█████╗  ██████╔╝█████╗  ██╔██╗ ██║██║     ██║███████║  │
                                                        │  ╚════██║██║   ██║██║   ██║██╔══╝  ██╔══██╗██╔══╝  ██║╚██╗██║██║     ██║██╔══██║  │
                                                        │  ███████║╚██████╔╝╚██████╔╝███████╗██║  ██║███████╗██║ ╚████║╚██████╗██║██║  ██║  │
                                                        │  ╚══════╝ ╚═════╝  ╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝╚═╝╚═╝  ╚═╝  │
                                                        │                                                                                   │
                                                        ╚───────────────────────────────────────────────────────────────────────────────────╝");
        Console.Write("                                                                      ---------[ Ingresa tu nombre: ");
        string nombre = limiteEscribir(16);

        Console.WriteLine("\n                                                                           ---------[ Ingresa la sugerencia ]---------");

        Console.SetCursorPosition(56, 27);
        string dato = limiteEscribir(85);

        string textoAAnadir = $"------------------------------------------------------------------------------------------{Environment.NewLine}{nombre} | Fecha: {fechaActual}{Environment.NewLine}{dato}{Environment.NewLine}------------------------------------------------------------------------------------------";
        File.AppendAllText(sugerenciaBuzonArchivo, textoAAnadir);
        barraCarga(80, 29);
        eliminarLineasVacias();
        Console.CursorVisible = false;
    }
    static void barraCarga(int lineaLado, int lineaAbajo)//extras
    {
        Console.CursorVisible = false;

        int derecha = 0;
        bool moverDerecha = true;

        while (moverDerecha)
        {
            if (derecha <= 7)
            {
                Thread.Sleep(100);

                Console.SetCursorPosition(lineaLado, lineaAbajo);
                Console.WriteLine("////////////////////////////");
                Console.SetCursorPosition(lineaLado + derecha, lineaAbajo);
                Console.WriteLine(@"\(^-^)/|-(: Cargando |");
                derecha++;
                Thread.Sleep(200);
            }
            else if (derecha > 7 && derecha <= 10)
            {
                Thread.Sleep(100);

                Console.SetCursorPosition(lineaLado, lineaAbajo);
                Console.WriteLine("/////////////////////");
                Console.SetCursorPosition(lineaLado + derecha, lineaAbajo);
                Console.WriteLine(@"\(^-^)/|-(: Listo |     ");

                moverDerecha = false;
                Console.ReadKey();
                Console.Beep();
                return;
            }
        }
    }
    static string limiteEscribir(int limiteCaracteres)//extras
    {
        string input = string.Empty; //la crea vacia
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true); //primero ejecuta lee el texto y despues lo muestra

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                break;
            }

            if (input.Length > 0 && keyInfo.Key == ConsoleKey.Backspace)
            {
                input = input.Substring(0, input.Length - 1);//Substring cre una nueva cadena que comienza desde el primer caracter que es 0 hasta el ultimo pero cuando se le resta 1 queda en el penultimo elimnado el ultimo
                Console.Write("\b \b"); //(\b) es la manera de mover el cursor haci atras
            }
            else if (input.Length < limiteCaracteres && keyInfo.Key != ConsoleKey.Backspace)
            {
                input += keyInfo.KeyChar; // agrega lo que estoy escribiendo, cada caracter
                Console.Write(keyInfo.KeyChar);
            }
        }

        return input;
    }
    static void rellenarListas(string facilitadorOProgramador)//extras
    {
        if (facilitadorOProgramador == "f")
        {
            File.Copy(copiaSeguridad, listaEstudianteFacilitador, true);
            Console.Clear();
            barraCarga(80, 25);
        }

        else if (facilitadorOProgramador == "p")
        {
            File.Copy(copiaSeguridad, listaEstudianteProgramador, true);
            Console.Clear();
            barraCarga(80, 25);
        }
    }
    static void mostrarProgramas()//extras
    {
        ConsoleKeyInfo key;
        do
        {
            Console.Clear();
            if (File.Exists(personasRuletaLista))
            {
                string[] lineasRuleta = File.ReadAllLines(personasRuletaLista);
                int filas = lineasRuleta.Length; // Obtener el número de líneas del archivo

                // Imprimir encabezado
                Console.WriteLine(@"                                    ╔────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╗
                                    │                                                                                                                            │
                                    │ ██████╗ ██████╗  ██████╗  ██████╗ ██████╗  █████╗ ███╗   ███╗ █████╗ ███████╗    ██╗  ██╗███████╗ ██████╗██╗  ██╗ ██████╗  │
                                    │ ██╔══██╗██╔══██╗██╔═══██╗██╔════╝ ██╔══██╗██╔══██╗████╗ ████║██╔══██╗██╔════╝    ██║  ██║██╔════╝██╔════╝██║  ██║██╔═══██╗ │
                                    │ ██████╔╝██████╔╝██║   ██║██║  ███╗██████╔╝███████║██╔████╔██║███████║███████╗    ███████║█████╗  ██║     ███████║██║   ██║ │
                                    │ ██╔═══╝ ██╔══██╗██║   ██║██║   ██║██╔══██╗██╔══██║██║╚██╔╝██║██╔══██║╚════██║    ██╔══██║██╔══╝  ██║     ██╔══██║██║   ██║ │
                                    │ ██║     ██║  ██║╚██████╔╝╚██████╔╝██║  ██║██║  ██║██║ ╚═╝ ██║██║  ██║███████║    ██║  ██║███████╗╚██████╗██║  ██║╚██████╔╝ │
                                    │ ╚═╝     ╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝    ╚═╝  ╚═╝╚══════╝ ╚═════╝╚═╝  ╚═╝ ╚═════╝  │
                                    │                                                                                                                            │
                                    ╚────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╝");

                // Imprimir contenido de la lista
                for (int i = 0; i < filas; i++)
                {
                    Console.WriteLine($"                                    {lineasRuleta[i]}");
                }
            }
            else
            {
                Console.WriteLine("                                    ---------[ Uno o ambos archivos no existen.");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("\n                                    ---------[ Salir (S)");
            key = Console.ReadKey(true);
        } while (key.Key != ConsoleKey.S);
    }
}