using Exercise_Videos.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Exercise_Videos
{
    // Main class
    class Program
    {
        static List<User> usersList = new List<User>();
        static int checkIndex;
        static bool isLoggedin = false;
        public static User userLogged;
        static void Main(string[] args)
        {
            createMenuOptions();
        }

            // FASE 3
        static void createMenuOptions()
        {
            int option;
            bool stop = false;

            while (stop == false)
            {
                Console.WriteLine("Bienvenido, ¿qué accion quieres realizar?: 1: Crea Nuevo Usuario || 2: Hacer Login || 3: Salir del Programa");
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("No has introducido un número válido", ex);
                    option = 0;
                }

                switch (option)
                {
                    case 1:
                        registerUser();
                        break;
                    case 2:
                        verifiedUser();
                        newVideo(checkIndex);
                        break;
                    case 3:
                        Console.WriteLine("Gracias por venir, nos vemos");
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("No has seleccionado ninguna opción correcta");
                        break;
                }
            }
        }

        private static void registerUser()
        {
            string userName;
            Console.WriteLine("Introduce el nombre de usuario");

            try
            {
                userName = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No has introducido un nombre de usuario valido", ex);
                userName = "Nombre usuario";
            }
           
            string name;
            Console.WriteLine("Introduce tu nombre");
            name = Console.ReadLine();

            string lastName;
            Console.WriteLine("Introduce el apellido");
            lastName = Console.ReadLine();

            string password;
            string verifiedPassword;
            do
            {
                Console.WriteLine("Escribe tu contraseña. Debe tener mínimo 10 caracteres (núm + letras)");
                password = Console.ReadLine();
                Console.WriteLine("Por favor, repite la contraseña");
                verifiedPassword = Console.ReadLine();
            }   while (password != verifiedPassword);

            User userCreated = new User();
            userCreated.USERNAME = userName;
            userCreated.NAME = name;
            userCreated.LASTNAME = lastName;
            userCreated.PASSWORD = password;
            DateTime localDate = DateTime.Now;
            String[] cultureNames = { "es-ES"};
            foreach (var cultureName in cultureNames) 
            {
                var culture = new CultureInfo(cultureName);
                Console.WriteLine("La fecha de creación del Usuario ES: {0}: {1}", cultureName, localDate.ToString(culture));

            }
        

            usersList.Add(userCreated);

            Console.WriteLine($"El usuario creado es {userCreated.USERNAME} - Nombre: {userCreated.NAME}.");

            foreach (var item in usersList)
            {
                Console.WriteLine($"La Lista de usuarios creados que hay es {item}");
            }
        }

        private static int verifiedUser()
        {
            string userIntro;
            string userPass;

            Console.WriteLine("Introduce tu username");
            userIntro = Console.ReadLine();

            Console.WriteLine("Introduce tu contraseña");
            userPass = Console.ReadLine();

            for (int i = 0; i < usersList.Count; i++)
            {
                User comparingU = usersList.ElementAt(i);
                if (comparingU.USERNAME == userIntro)
                {
                    Console.WriteLine("Coincide Username");
                    if (comparingU.PASSWORD == userPass)
                    {
                        Console.WriteLine("Coincide Password");
                        checkIndex = i;
                        isLoggedin = true;
                        userLogged = comparingU;
                        return checkIndex;
                    }
                }
            }
            return 0;
        }
        static void viewUserVideos()
        {
            if (isLoggedin)
            {
                int option;
         
                Console.WriteLine("¿Quieres ver videos? 1: Si || 2: NO");
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("El númerico introducido no es correcto", ex);
                    option = 0;
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Has escogido la opción de ver Videos");
                        showAllVideos();
                        break;
                    case 2:
                        Console.WriteLine("No quieres ver nada");
                        bool stop = true;
                        break;
                    default:
                        Console.WriteLine("No has seleccionado ninguna opción correcta");
                        break;
                }
            }
        }

    private static void newVideo(int index)
        {
            string url;
            string title;
            string tags;
            string answer;
 
            Console.WriteLine("Añade una URL al video");

            try
            {
                url = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No has introducido una URL valida", ex);
                url = "ejercicio_videos";
            }

            Console.WriteLine("Añade título a tu video");
            try
            {
                title = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No has introducido un título valido", ex);
                title = "ejercicio_videos 2";
            }

            Console.WriteLine("Añade las etiquetas a tu video");

            try
            {
                tags = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No has introducido una e valida", ex);
                tags = "tags";
            }
            User guardandoVideo;

            try
            {
                guardandoVideo = usersList.ElementAt(index);
                Console.WriteLine(guardandoVideo.GuestInfo());
            }
            catch (ArgumentOutOfRangeException outOfRange)
            {
                Console.WriteLine("Lo sentimos no hay ningún usuario con ese nombre. Deberías crear dicho usario", outOfRange.Message);
                guardandoVideo = usersList.ElementAt(0);

            }

            guardandoVideo.createNewVideo(url, title).addNewTags(tags);

            guardandoVideo.ToString();


            Console.WriteLine($"Has creado {guardandoVideo.NAME} tu Video {title} satisfactoriamente ");

            Console.WriteLine("tu video se ha añadido a Tu Lista de Videos");

            Console.WriteLine("¿Quieres ver todos los videos que tienes almacenados si || no?");

            answer = Console.ReadLine();

            // FASE 3 

            if(answer == "si")
            {
                Console.WriteLine("Tus videos Almacenados son:");
                guardandoVideo.verTusVideos();

                Console.WriteLine("¿Deseas seguir añadiendo videos  si || no?");
                string newAns;

                newAns = Console.ReadLine();
                if (newAns == "si")
                {
                    guardandoVideo.createNewVideo(url, title);
                }
                else
                {
                    Console.WriteLine("Iras a la sección general");
                    viewUserVideos();
                }
            }

        }

        static void showAllVideos()
        {
            foreach (var user in usersList)
            {
                Console.WriteLine(user.ToString());

                user.verTusVideos();
                Console.WriteLine("XXYOUTUBEXX");
            }
        }
    }
}
