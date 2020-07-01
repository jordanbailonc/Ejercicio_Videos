using Exercise_Videos.Models;
using System;
using System.Collections.Generic;


namespace Exercise_Videos
{
    // Fase 1

    class Video : Entity
    {
        // Encapsulation
        private string url;
        private string title;
        private List<String> tags = new List<string>();

        public Video()
        {
            tags = new List<string>();
        }
        public Video(string url, string title)
        {
            this.url = url;
            this.title = title;
            this.tags = new List<string>();
        }

        public override string ToString()
        {
            return $" Esta es la URL: {this.url} - Título: {this.title}";
        }

        public string URL 
        {
            get { return this.url;  }
            set { this.url = checkearUrl(value); }
        }
  
        private string checkearUrl(string url)
        {
            while (string.IsNullOrEmpty(url) || url.Length < 10)
            {
                Console.WriteLine("La UR. Intenta de Nuevo");
                return null;
            }
            return this.url = url;
        }

        public string TITLE 
        { 
            get { return this.title; }
            set { this.title = checkearTitulo(value); }
        }

        private string checkearTitulo( string title)
        {
            while (string.IsNullOrEmpty(title) || title.Length < 5)
            {
                Console.WriteLine("Introduce un título. Valida. Intenta de Nuevo");
                return null;
            }
            return this.title = title;
        }

        public List<string> getListTags()
        {
            return tags;
        }

        public void setListTags( List<string> tags)
        {
            this.tags = tags;
        }

        // Fase 2
        public void addNewTags(string tagi)
        {
            string newTag;

            Console.WriteLine("¿Deseas añadir tags a tu video si || no?");

            newTag = Console.ReadLine();


            while (newTag == "si")
            {
                Console.WriteLine("Introduce el nuevo tag que desees añadir");
                try
                {
                    newTag = Console.ReadLine();
                }
                catch (SystemException ex)
                {
                    Console.WriteLine("No has introducido una opción de tag válida", ex);
                    newTag = "programacion";
                }

                tags.Add(newTag);
            }

            tags.Add(tagi);


            foreach (var tag in tags)
            {
                Console.WriteLine($"La lista de TAGIS son: {tag}");
            }
        }

        public void playVideo()
        {

            MediaPlayer play = MediaPlayer.Play;

            Console.WriteLine($"El reproductor de video esta en modo: {play}");
        }


        public void pausaVideo()
        {
            MediaPlayer pause = MediaPlayer.Pause;
            Console.WriteLine($"El reproductor de video esta en modo: {pause}");
        }


        public void stopVideo()
        {
            MediaPlayer stop = MediaPlayer.Stop;
            Console.WriteLine($"El reproductor de video esta en modo: {stop}");
        }
    }
    enum MediaPlayer
    {
        Play, // 0
        Pause, // 1
        Stop // 2
    }
}
