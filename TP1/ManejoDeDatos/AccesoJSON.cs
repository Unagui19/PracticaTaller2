using Entidades;
using ManejoDatos;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace EspacioAccesoData
{
    public class AccesoJson: AccesoADatos
    {
        public override Cadeteria GetCadeteria(string route)
        {

                string textoJson = File.ReadAllText(route);
                Cadeteria cadeteria = JsonSerializer.Deserialize<Cadeteria>(textoJson);
                return cadeteria;
        }

        public override List<Cadete> GetCadetes(string route)
        {
             string textoJson = File.ReadAllText(route);
                List<Cadete> nuevaLista = JsonSerializer.Deserialize<List<Cadete>>(textoJson);
                return nuevaLista;
        }
        // public void GenerarInforme(Cadeteria cadeteria)//genera un archivo .csv
        // {
        //     FileStream fs = new FileStream("Informe.csv", FileMode.Create);
        //     using (StreamWriter writer = new StreamWriter(fs))
        //     {
        //         int i = 0, cantPedidosTotal = 0;
        //         double sumador = 0;
        //         // writer.WriteLine("Indice"+" "+"Nombre"+" "+"Extension");

        //         writer.WriteLine($"Cadeteria {cadeteria.Nombre} || telefono: {cadeteria.Telefono}\n");
        //         foreach (var cadete in cadeteria.ListadoCadetes)
        //         {

        //             writer.WriteLine($"{cadete.Id}; Nombre: {cadete.Nombre}; monto:{cadeteria.jornalACobrar(cadete.Id)}; Cantidad de pedidos: {cadete.CantPedidos}");
        //             i++;
        //             sumador += cadeteria.jornalACobrar(cadete.Id);
        //             cantPedidosTotal += cadete.CantPedidos;
        //         }

        //         writer.WriteLine("");
        //         writer.WriteLine("Monto total: " + sumador);
        //         writer.WriteLine("Cantidad total de pedidos: " + cantPedidosTotal);

        //         writer.WriteLine("Promedio de pedidos por cadete: " + (cantPedidosTotal / cadeteria.ListadoCadetes.Count()));
        //     }
        // }
    }
}