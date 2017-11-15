using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        public delegate void Progreso(int progreso);
        public delegate void esFin(string html);

        private string html;
        private Uri direccion;

        public event Progreso eventoProg;
        public event esFin eventoFin;

        public Descargador(Uri direccion)
        {
            this.direccion = direccion;
            this.html = "";
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                
                cliente.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.WebClientDownloadProgressChanged);
                cliente.DownloadStringCompleted += new DownloadStringCompletedEventHandler(this.WebClientDownloadCompleted);

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.eventoProg(e.ProgressPercentage);
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.html = e.Result;
            this.eventoFin(this.html);
        }
    }
}
