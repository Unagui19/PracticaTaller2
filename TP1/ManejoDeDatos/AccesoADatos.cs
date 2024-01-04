using Entidades;

namespace ManejoDatos
{
    public static class AccesoADatos
    {   
        public static List<Cadete> GetCadetes(string route){
            List<Cadete> cadetes = new List<Cadete>();
            
            var csv = new FileStream(route,FileMode.Open);
            var str = new StreamReader(csv);

            while (!str.EndOfStream)
            {
                string linea = str.ReadLine();      
                string[] fields = linea.Split(',');
                cadetes.Add(new Cadete(int.Parse(fields[0]), fields[1], fields[2],fields[3]));
            }
            csv.Close();
            return cadetes;
        }        

        public static Cadeteria GetCadeteria(string route){
            Cadeteria cadeteria = new Cadeteria();
            
            var csv = new FileStream(route,FileMode.Open);
            var str = new StreamReader(csv);

            while (!str.EndOfStream)
            {
                string linea = str.ReadLine();      
                string[] fields = linea.Split(',');
                Cadeteria cadeteria2 = new Cadeteria(fields[0],fields[1]);
                cadeteria=cadeteria2;
            }
            csv.Close();
            return cadeteria;
        }      
        public static void GenerarInforme(Cadeteria cadeteria)//genera un archivo .csv
        {
            FileStream fs = new FileStream("Informe.csv", FileMode.Create);
            using (StreamWriter writer = new StreamWriter(fs))
            {
                int i = 0, cantPedidosTotal = 0;
                double sumador = 0;
                // writer.WriteLine("Indice"+" "+"Nombre"+" "+"Extension");

                writer.WriteLine($"Cadeteria {cadeteria.Nombre} || telefono: {cadeteria.Telefono}\n");
                foreach (var item in cadeteria.Cadetes)
                {
                    writer.WriteLine($"{item.Id}; Nombre: {item.Nombre}; monto:{item.JornalACobrar()}; Cantidad de pedidos: {item.Pedidos.Count()}");
                    i++;
                    sumador += item.JornalACobrar();
                    cantPedidosTotal += item.Pedidos.Count();
                }

                writer.WriteLine("");
                writer.WriteLine("Monto total: " + sumador);

                writer.WriteLine("Promedio de pedidos por cadete: " + (cantPedidosTotal / cadeteria.Cadetes.Count()));
            }
        }  
    }
}