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


        public Cadeteria(){

        }


        public Cadeteria(string nombre, string telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
            Cadetes = CargarCadetes();
        }

        public List<Cadete> CargarCadetes(){
            List<Cadete> cadetes = AccesoADatos.GetCadetes("Cadetes.CSV");
            return cadetes;
        }

        public Pedido CrearPedido(string obs, string nombreCliente, string DireccionCliente, string TelefonoCliente, string DatosReferenciaDireccion){

            Pedido pedido = new Pedido(obs,nombreCliente,DireccionCliente,TelefonoCliente,DatosReferenciaDireccion);
            return pedido;
        }


        public void AsignarPedidoACadete(Pedido pedido, int idCadete){
            Cadete cadete = BuscarCadetePorId(idCadete);
            cadete.AgregarPedido(pedido);
        }

        public Cadete BuscarCadetePorId(int idCadete){
            Cadete cadete = Cadetes.FirstOrDefault(cad => cad.Id == idCadete);
            return cadete;
        }
        public Cadete BuscarCadetePorNroDePedido(int nroPedido){
            Cadete cadete = Cadetes.FirstOrDefault(cad => cad.BuscarPedido(nroPedido).Nro == nroPedido);
            return cadete;
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

        public void CancelarPedido(Pedido pedido){
            Cadete cadete = BuscarCadetePorNroDePedido(pedido.Nro);
            pedido.CambiarEstado(2);
        }
        
        
    }
}