using Entidades;

namespace Entidades
{
    public class Cadete
    {
        int id;
        string nombre;
        string direccion;
        string telefono;
        int cantidadPedidos;
        List<Pedido> pedidos;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int CantidadPedidos { get => cantidadPedidos; set => cantidadPedidos = value; }
        public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }

        public Cadete(){}
        public Cadete(int id, string nombre, string direccion, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            cantidadPedidos=0;
            pedidos = new List<Pedido>();
        }

        public void AgregarPedido(Pedido pedido){
            pedido.CambiarEstado(2);
            cantidadPedidos++;
        }

        public void QuitarPedido(Pedido pedido){
            pedidos.Remove(pedido);
        }

        public double JornalACobrar(){
            int jornal=0;
            foreach (var item in pedidos)
            {
                if (item.Estado==Estado.entregado)
                {
                    jornal+=500;
                }
            }
            return jornal;
        }


        public Pedido BuscarPedido(int nroPedido){
            Pedido pedido = pedidos.FirstOrDefault(ped => ped.Nro == nroPedido);
            return pedido;
        }
    }
    
}