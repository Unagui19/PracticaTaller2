using System.Runtime.CompilerServices;
using System.Linq;
using Entidades;
using ManejoDatos;
using System.Collections;

int repetir=1;
AccesoADatos data = new AccesoADatos();
Cadeteria cadeteria = data.GetCadeteria("ManejoDeDatos/Cadeteria.CSV");
List<Cadete> cadetes = data.GetCadetes("ManejoDeDatos/Cadetes.CSV");
cadeteria.Cadetes=cadetes;
while (repetir==1)
{
    Console.WriteLine("\t--------Bienvenido---------\n");
    Console.WriteLine("Seleccione la opcion deseada: \n");
    Console.WriteLine("1- Dar de alta el pedido");
    Console.WriteLine("2- Cambiar estado de pedido");
    Console.WriteLine("3- Reasignar pedido a otro cadete\n");
    Console.WriteLine("3- Mostrar listado de cadetes\n");
    int opcion;
    string z = Console.ReadLine();
    bool ingreso1 = int.TryParse(z, out opcion);

    while ( !ingreso1 || opcion < 1 || opcion >4 )
    {
        Console.WriteLine("\nIngreso una valor invalido. Vuelva a intentarlo:");
        z = Console.ReadLine();
        ingreso1 = int.TryParse(z, out opcion);
    }

    // Console.Clear();

    if (opcion==1)
    {
        Console.WriteLine("\tPedido:");
        Console.WriteLine("\n Nombre del cliente: ");
        string nombreCliente = Console.ReadLine();
        Console.WriteLine("\nDireccion: ");
        string direccionCliente = Console.ReadLine();
        Console.WriteLine("\nTelefono: ");
        string telCliente = Console.ReadLine();
        Console.WriteLine("\nDatos de referencia: ");
        string datosRefCliente = Console.ReadLine();
        Console.WriteLine("\nAlguna observacion?: ");
        string obsPedido = Console.ReadLine();

        Pedido pedido = cadeteria.CrearPedido(nombreCliente,direccionCliente,telCliente, datosRefCliente,obsPedido);
        Console.WriteLine("pedido: ");
        Console.WriteLine(pedido.Nro);
        Console.WriteLine(pedido.Cliente);
        //--------------DAR DE ALTA PEDIDO--------------
        Console.WriteLine("\n---Alta Pedido---\n");
        Console.WriteLine("Id de cadete a asignarle el pedido: ");
        int idCadete;
        string z2 = Console.ReadLine();
        bool ingreso2 = int.TryParse(z2, out idCadete);

        while ( !ingreso2 )
        {
            Console.WriteLine("\nIngreso una valor invalido. Vuelva a intentarlo:");
            z2 = Console.ReadLine();
            ingreso2 = int.TryParse(z2, out idCadete);
        } 
        cadeteria.AsignarPedidoACadete(pedido,idCadete);

        Console.WriteLine("Pedido agregado con exito");
    }
    //--------------CAMBIAR ESTADO--------------
    else if(opcion == 2){
        Console.WriteLine("\t-----Cambiar estado de pedido-----\n");
        Console.WriteLine("Numero de pedido al que se le quiere cambiar su estado: ");
        int pedidoCambioE;
        string e1 = Console.ReadLine();
        bool ingreso3 = int.TryParse(e1, out pedidoCambioE);

        while ( !ingreso3 )
        {
            Console.WriteLine("\nIngreso una valor invalido. Vuelva a intentarlo:");
            e1 = Console.ReadLine();
            ingreso3 = int.TryParse(e1, out pedidoCambioE);
        }
        Console.WriteLine("\n");
        Console.WriteLine("Cambiar estado del pedido a: \n");
        Console.WriteLine("1- Pendiente");
        Console.WriteLine("2- Asignado");
        Console.WriteLine("3- Entregado");
        Console.WriteLine("4- Cancelado\n");

        int estado;
        string e2 = Console.ReadLine();
        bool ingreso32 = int.TryParse(e2, out estado);

        while ( !ingreso32 || estado >4 || estado <1 )
        {
            Console.WriteLine("\nIngreso una valor invalido. Vuelva a intentarlo:");
            e2 = Console.ReadLine();
            ingreso32 = int.TryParse(e2, out estado);
        }

        cadeteria.CambiarEstado(estado,pedidoCambioE);

        Console.WriteLine("Cambio de estado exitoso");
    }
    
        //--------------REASIGNAR PEDIDO--------------

    else if(opcion == 3){
        Console.WriteLine("\t---Reasignar pedido---\n");


        Console.WriteLine("Numero de Pedido que se va a reasignar: ");
        int pedidoReasig;
        string n = Console.ReadLine();
        bool ingreso4 = int.TryParse(n, out pedidoReasig);

        while ( !ingreso4 )
        {
            Console.WriteLine("\nIngreso una valor invalido. Vuelva a intentarlo:");
            n = Console.ReadLine();
            ingreso4 = int.TryParse(n, out pedidoReasig);
        }

        Console.WriteLine("Id del cadete a quien se le va a asignar el pedio: ");
        int idCadete4;
        string n2 = Console.ReadLine();
        bool ingreso42 = int.TryParse(n2, out idCadete4);

        while ( !ingreso42 )
        {
            Console.WriteLine("\nIngreso una valor invalido. Vuelva a intentarlo:");
            n2 = Console.ReadLine();
            ingreso42 = int.TryParse(n2, out idCadete4);
        }
        cadeteria.ReasignarPedido(idCadete4,pedidoReasig);
        Console.WriteLine("Pedido reasigando con exito");
    }
    else{
        Console.WriteLine("\t---Listado de cadetes---\n");
        foreach (var item in cadetes)
        {
            item.MostrarInfo();
        }
    }
    Console.WriteLine("Limpio");
    Console.WriteLine("Desea realizar otra accion?\n");
    Console.WriteLine("1- si");
    Console.WriteLine("2- no\n");
    int accion;
    string a = Console.ReadLine();
    bool ingresoFinal = int.TryParse(a, out accion);

    while ( !ingresoFinal || accion >2 || accion <0 )
    {
        Console.WriteLine("\nIngreso una valor invalido. Vuelva a intentarlo:");
        a = Console.ReadLine();
        ingresoFinal = int.TryParse(a, out accion);
    }
    if (accion == 1 )
    {
        repetir=1;
    }
    else{
        repetir=2;
    }
}

//-------INFORME-----

int pedidosTot = 0;
Console.WriteLine("\n\t---INFORME---\n");
foreach (var cadete in cadetes)
{
    Console.WriteLine($"CADETE: {cadete.Nombre}\n");
    Console.WriteLine($"Cantidad de pedidos realizados: {cadete.Pedidos.Count()}\n");
    Console.WriteLine($"Monto ganado: {cadete.JornalACobrar()}\n");
    pedidosTot+=cadete.Pedidos.Count();
}
Console.WriteLine($"Cantidad de pedidos totales: {pedidosTot}\n");
Console.WriteLine($"Cantidad de cadetes: {cadeteria.Cadetes.Count()}\n");
float envPromedio = pedidosTot/cadeteria.Cadetes.Count();
Console.WriteLine($"\n\tCantidad de envios promedio por cadete: {envPromedio}");
// data.GenerarInforme(cadeteria);

