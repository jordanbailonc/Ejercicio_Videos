using Exercise_Videos.Models;
using System;
using System.Collections.Generic;
using System.Globalization;


namespace Exercise_Videos
{
    // Fase 1

    class User : Entity
    {
        // Encapsulation  
        private string userName;
        private string name;
        private string lastName;
        private string password;
        private DateTime registerDate;
        public List<Video> videos = new List<Video>();

        public User()
        {
           this.videos = new List<Video>();
        }
        public User(string userName, string name, string lastName, string password)
        {
            this.userName = userName;
            this.name = name;
            this.lastName = lastName;
            this.password = password;
            this.registerDate = DateTime.Now;
            this.videos = new List<Video>();
        }

        public override string ToString()
        {
            return $"UserName: {this.userName} - Name: {this.name} - LastName: {this.lastName}";
        }
        public string GuestInfo()
        {
            string gInfo = name + " " + lastName;
            return (gInfo);
        }
        public void verTusVideos()
        {
            Console.WriteLine("Tu selección de videos es: ");

            foreach (Video video in this.videos)
            {
                Console.WriteLine($"1. Título: {video.TITLE} \n 2. URL: {video.URL}");
            }
        }

        public string USERNAME 
        { 
            get { return this.userName; }
            set { this.userName = checkUserName(value); }
        }

        private string checkUserName(string userName)
        {
            while (string.IsNullOrEmpty(userName) || userName.Length < 4)
            {
                Console.WriteLine("Tienes que introducir un NOMBRE DE USUARIO Valido. Para poder registrarte. No puede estar vacio y Debe contener mínimo 4 carácteres");
                return null;
            }
            return userName;
        }

        public string NAME 
        { 
            get { return this.name; }
            set { this.name = checkName(value); }
        }

        private string checkName(string name)
        {
            while (string.IsNullOrEmpty(name) || name.Length < 3)
            {
                Console.WriteLine("Tienes que introducir un NOMBRE Valido. Para poder registrarte. No puede estar vacio");
                return null;
            }
            return name;
        }

        public string LASTNAME
        {
            get { return this.lastName;  }
            set { this.lastName = checkLastName(value);  }
        }
    

        private string checkLastName(string lastName)
        {
            while (string.IsNullOrEmpty(lastName) || lastName.Length < 5)
            {
                Console.WriteLine("Tienes que introducir un APELLIDO Valido. Para poder registrarte. No puede estar vacio");
                return null;
            }
            return lastName;
        }

        public string PASSWORD 
        {
            get { return this.password;  }
            set { this.password = checkPassword(value); }
        }

        public string checkPassword(string password)
        {
            while (string.IsNullOrEmpty(password) || password.Length < 10)
            {
                Console.WriteLine("Tienes que introducir una CONTRASEÑA correcta. Para poder registrarte. Debe contener mínimo 10 caracteres y deben ser alfanuméricos");
                return null;
            }
            return password;
        }

        public DateTime REGISTERDATE 
        { 
            get { return this.registerDate;  }
            set { this.registerDate = checkRegisterDate(value); }
        }

        public DateTime checkRegisterDate(DateTime registerDate) {

            return this.registerDate;
        }

        public List<Video> getVideos()
        {
            return videos;
        }

        public void setVideos(List<Video> videos)
        {
            this.videos = videos;
        }

        // Fase 2


        public Video createNewVideo( string url, string title )
        {

            Video newVideo = new Video(url, title);
            Console.WriteLine($" {this.NAME} HAS CREADO TU VIDEO {title} satisfactoriamente ");

            this.videos.Add(newVideo);

            Console.WriteLine("Has añadido un nuevo VIDEO a la lista de tus videos");

            int operationVideo;
            Console.WriteLine("Porfavor, escoge la opción que desees ejecutar en el video: 1: Play Video || 2: Pause Video || 3: Stop Video");

            try
            {
                operationVideo = int.Parse(Console.ReadLine());

            }
            catch(FormatException ex)
            {
                Console.WriteLine("No has introducido una opción numérica válida", ex);
                operationVideo = 0;
            }

            switch (operationVideo)
            {
                case 1:
                    newVideo.playVideo();
                    Console.WriteLine($"El Video {newVideo} se está reproduciendo");
                    break;
                case 2:
                    newVideo.pausaVideo();
                    Console.WriteLine($"El Video {newVideo} ha sido pausado");
                    break;
                case 3:
                    newVideo.stopVideo();
                    Console.WriteLine($"El Video {newVideo} ha sido parado completamente");
                    break;
                default:
                    Console.WriteLine("No has seleccionado ninguna opción");
                    break;
            }
            foreach (var item in this.videos)
            {
                Console.WriteLine($"Los videos de tu LISTA SON: {item}");
            }
            return newVideo;
        }

    }
}
