using System.Linq;
using Entidades;
using ManejoDatos;

namespace Entidades
{
    public class Cadeteria
    {

        public string Nombre {get; set;}
        public string Telefono {get; set;}
        public List<Cadete> Cadetes {get; set;}
        public List<Pedido> ListadoPedidos {get; set;}


        public Cadeteria(){

        }


        public Cadeteria(string nombre, string telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
            Cadetes = new List<Cadete>();
            ListadoPedidos = new List<Pedido>();
        }


        public string Mostrar(){
            return "Cadeteria "+ Nombre + "- Telefono : " + Telefono + "- Cantidad de cadetes : " + Cadetes.Count() + "\n"; 
        }   

        public Pedido CrearPedido(string obs, string nombreCliente, string DireccionCliente, string TelefonoCliente, string DatosReferenciaDireccion){

            Pedido pedido = new Pedido(obs,nombreCliente,DireccionCliente,TelefonoCliente,DatosReferenciaDireccion);
            ListadoPedidos.Add(pedido);
            return pedido;
        }


        public void AsignarCadeteAPedido(int nroPedido, int idCadete){
            Cadete cadete = BuscarCadetePorId(idCadete);
            if (cadete!=null)
            {
                Pedido pedido = BuscarPedido(nroPedido);
                if (pedido!=null)
                {
                    pedido.AsignarCadete(cadete);
                }
            }
        }

        public Cadete BuscarCadetePorId(int idCadete){
            Cadete cadete = Cadetes.FirstOrDefault(cad => cad.Id == idCadete);
            if (cadete!=null)
            {
                return cadete;            
            }
            else
            {
                return null;
            }
        }


        public void ConfirmarEntrega(Pedido pedido){
            if (pedido.cadete!=null)
            {
                pedido.CambiarEstado(3);                
            }
            else
            {
                Console.WriteLine("No existe el pedido o no hay cadete asignado al mismo");
            }
        }

        public void ReasignarPedido(int idCadete, int numeroPedido){
            Pedido pedido = BuscarPedido(numeroPedido);
            pedido.DesasignarCadete();
            pedido.AsignarCadete(BuscarCadetePorId(idCadete));
        }


        
        public void CambiarEstado(int estado, int numeroPedido){
            Pedido pedido = BuscarPedido(numeroPedido);

                if (pedido != null)
                {
                    if (estado == 4)
                    {
                        ListadoPedidos.Remove(pedido);
                    }
                    else if(estado == 3){
                        ConfirmarEntrega(pedido);
                    }
                    else{
                        pedido.CambiarEstado(estado);                
                    }
                }
                else
                {
                    Console.WriteLine("Pedido inexistente");
                }
        }

        public Pedido BuscarPedido(int nroPedido){
            Pedido pedido = ListadoPedidos.FirstOrDefault(ped => ped.Nro == nroPedido);
            if (pedido != null)
            {
                return pedido;            
            }
            else{
                return null;
            }
        }

        public double JornalACobrar(int idCadete){
            int jornal=0;
            Cadete cadete = BuscarCadetePorId(idCadete);
            foreach (var item in ListadoPedidos)
            {
                if (item.Estado==Estado.entregado && item.cadete==cadete)
                {
                    jornal+=500;
                }
            }
            return jornal;
        }
        
    }
}