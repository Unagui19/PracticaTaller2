using System.Dynamic;
using Entidades;

namespace Entidades
{
    public enum Estado {pendiente = 1, asignado = 2, entregado = 3, cancelado = 4}
    public class Pedido
    {

        static int id=0;
        public int Nro { get ; set; }
        public string Obs { get ; set; }
        public Estado Estado { get ; set; }
        public Cliente Cliente { get ; set; }

        public Pedido(string obs, string nombreCliente, string DireccionCliente, string TelefonoCliente, string DatosReferenciaDireccion)
        {
            id++;
            Nro = id;
            Estado = Estado.pendiente;
            Cliente = new Cliente(nombreCliente, DireccionCliente, TelefonoCliente, DatosReferenciaDireccion);
        }

        public Pedido (){}

        public Pedido(string obs, Estado estado, Cliente cliente)
        {
            id++;
            Nro = id;
            Obs = obs;
            Estado = estado;
            Cliente = cliente;
        }

        public void verDireccionCliente(){
            Console.WriteLine("Direccion del cliente ",Cliente.Direccion);
        }

        public void verDatosCliente(){
            Console.WriteLine("Nombre del cliente ",Cliente.Nombre);
            Console.WriteLine("Direccion del cliente ",Cliente.Direccion);
            Console.WriteLine("Telefono del cliente ",Cliente.Telefono);
            Console.WriteLine("Datos de referencia de la direccion ",Cliente.DatosReferenciaDireccion);
        }

        public void CambiarEstado(int est){
            switch (est)
            {
                case 1: Estado=Estado.pendiente;
                break; 
                case 2: Estado = Estado.asignado;
                break ;
                case 3: Estado = Estado.pendiente;
                break ;
                default: Estado = Estado.cancelado;
                break;
            }
        }

        

    }
}