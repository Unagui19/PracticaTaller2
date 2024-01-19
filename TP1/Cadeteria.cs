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
            Cadetes = new List<Cadete>();
        }

        // public List<Cadete> CargarCadetes(){
        //     List<Cadete> cadetes = data.GetCadetes("ManejoDeDatos/Cadetes.CSV");
        //     return cadetes;
        // }

        public void Mostrar(){
            Console.WriteLine($"\n Cadeteria : {Nombre}\n");
            Console.WriteLine($"Telefono : {Telefono}\n");
            Console.WriteLine($"Cantidad de cadetes activos : {Cadetes.Count()}\n");
        }   

        public Pedido CrearPedido(string obs, string nombreCliente, string DireccionCliente, string TelefonoCliente, string DatosReferenciaDireccion){

            Pedido pedido = new Pedido(obs,nombreCliente,DireccionCliente,TelefonoCliente,DatosReferenciaDireccion);
            return pedido;
        }


        public void AsignarPedidoACadete(Pedido pedido, int idCadete){
            Cadete cadete = BuscarCadetePorId(idCadete);
            if (cadete!=null)
            {
                cadete.AgregarPedido(pedido);            
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
        
        Console.WriteLine("No se encontró ningún cadete con ese número de pedido.");
        return null;
    }
        // public Cadete BuscarCadetePorNroDePedido(int nroPedido){
        //     Cadete cadete= new Cadete();
        //     foreach (var aux in Cadetes)
        //     {
        //         foreach (var pedido in aux.Pedidos)
        //         {
        //             if (pedido!=null){
        //                 if(pedido.Nro==nroPedido){
        //                     cadete=aux;
        //                     break;
        //                 }
        //             } 
        //             else{
        //                 Console.WriteLine("No hay pedidos asignados");                        
        //             }
        //         }
        //     }
        //     return cadete;
        // }

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

        // public void CancelarPedido(int nroPedido){
        //     // Cadete cadete = BuscarCadetePorNroDePedido(nroPedido);
        //     Pedido pedido = cadete.BuscarPedido(nroPedido);
        //     EliminarPedido(pedido);
        // }
        // public void CancelarPedido(int nroPedido){ //es eliminar pedido
        //     Cadete cadete = BuscarCadetePorNroDePedido(nroPedido);
        //     Pedido pedido = cadete.BuscarPedido(nroPedido); 
        //     if(pedido!=null){
        //         cadete.QuitarPedido(pedido);
        //     }
        // }
        
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
                else
                {
                    Console.WriteLine("Pedido inexistente");
                }
            }
            else
            {
                Console.WriteLine("No existe cadete con ese pedido asignado");
            }
        }
        
    }
}