using Entidades;

namespace Entidades
{
    public class Cadete
    {
        int id;
        string nombre;
        string direccion;
        string telefono;


        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        // public int CantidadPedidos { get => cantidadPedidos; set => cantidadPedidos = value; }


        public Cadete(){}
        public Cadete(int id, string nombre, string direccion, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            // pedidos = new List<Pedido>();
        }

        // public void AgregarPedido(Pedido pedido){
        //     pedidos.Add(pedido);
        //     pedido.CambiarEstado(2);
        // }

        // public void QuitarPedido(Pedido pedido){
        //     pedidos.Remove(pedido);
        //     // this.cantidadPedidos--;
        // }

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

        public string MostrarInfo(){
            return "Id : "+ id + "- Nombre : " + nombre + "\n"; 
        }

        public Pedido BuscarPedido(int nroPedido){
            Pedido pedido = pedidos.First(ped => ped.Nro == nroPedido);
            if (pedido != null)
            {
                return pedido;            
            }
            else{
                return null;
            }
        }
    }
    
}