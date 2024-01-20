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
        }


        public string Mostrar(){
            return "Cadeteria "+ Nombre + "- Telefono : " + Telefono + "- Cantidad de cadetes : " + Cadetes.Count() + "\n"; 
        }   

        public Pedido CrearPedido(string obs, string nombreCliente, string DireccionCliente, string TelefonoCliente, string DatosReferenciaDireccion){

            Pedido pedido = new Pedido(obs,nombreCliente,DireccionCliente,TelefonoCliente,DatosReferenciaDireccion);
            ListadoPedidos.Add(pedido);
            return pedido;
        }


        public void AsignarCadeteAPedido(Pedido pedido, int idCadete){
            Cadete cadete = BuscarCadetePorId(idCadete);
            if (cadete!=null)
            {
                           
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

        public Cadete BuscarCadetePorNroDePedido(int nroPedido){
        foreach (var cadete in Cadetes)
        {
            foreach (var pedido in cadete.Pedidos)
            {
                if (pedido != null && pedido.Nro == nroPedido)
                {
                    return cadete;
                }
            }
        }
        return null;
    }


        public void ConfirmarEntrega(int nroPedido){
            Cadete cadete = Cadetes.FirstOrDefault(cad => cad.BuscarPedido(nroPedido).Nro == nroPedido);
            Pedido pedido = cadete.BuscarPedido(nroPedido);
            pedido.CambiarEstado(3);
        }

        public void ReasignarPedido(int idCadete, int numeroPedido){
            Cadete cadeteAnterior = BuscarCadetePorNroDePedido(numeroPedido);
            Pedido aux = cadeteAnterior.BuscarPedido(numeroPedido); 
            AsignarPedidoACadete(aux,idCadete);
            cadeteAnterior.QuitarPedido(aux);
        }


        
        public void CambiarEstado(int estado, int numeroPedido){
            Cadete cadete = BuscarCadetePorNroDePedido(numeroPedido);
            if (cadete!=null)
            {                    
                Pedido pedido = cadete.BuscarPedido(numeroPedido);
                if (pedido != null)
                {
                    if (estado == 4)
                    {
                        cadete.QuitarPedido(pedido);
                    }
                    else{
                        pedido.CambiarEstado(estado);                
                    }
                }

            }

        }

        public Pedido BuscarPedido(int nroPedido){
            Pedido pedido = ListadoPedidos.First(ped => ped.Nro == nroPedido);
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