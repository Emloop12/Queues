using System;

public class Nodo
{
    public string cliente;  // nombre del cliente
    public Nodo siguiente;  // referencia al siguiente nodo

    public Nodo(string cliente)
    {
        this.cliente = cliente;
        this.siguiente = null;
    }
}

public class Cola
{
    Nodo frente, final;

    public Cola()
    {
        frente = null;
        final = null;
    }

    public void Enqueue(string cliente)
    {
        Nodo nuevoNodo = new Nodo(cliente);  // crear un nuevo nodo con el nombre del cliente

        if (final == null)  // si la cola está vacía
        {
            frente = nuevoNodo;
            final = nuevoNodo;
        }
        else  // agregar el cliente al final de la cola
        {
            final.siguiente = nuevoNodo;
            final = nuevoNodo;
        }
    }

    public void Dequeue()
    {
        if (frente == null)  // si la cola está vacía
        {
            Console.WriteLine("La cola está vacía, no hay clientes para atender.");
            return;
        }
        else
        {
            Console.WriteLine($"Atendiendo a: {frente.cliente}");  // mostrar al cliente que está siendo atendido
            frente = frente.siguiente;  // eliminar al cliente de la cola
            if (frente == null)  // si la cola se queda vacía, reiniciar el final
            {
                final = null;
            }
        }
    }

    public void ImprimirCola()
    {
        if (frente == null)  // si la cola está vacía
        {
            Console.WriteLine("La cola está vacía.");
            return;
        }
        else
        {
            Nodo nodoActual = frente;
            Console.WriteLine("Estado actual de la cola:");
            while (nodoActual != null)
            {
                Console.WriteLine(nodoActual.cliente);
                nodoActual = nodoActual.siguiente;
            }
        }
    }
}

class Programa
{
    static void Main(string[] args)
    {
        bool estado = true;
        string respuesta;
        string nombreCliente;
        Cola colaAtencion = new Cola();  // crear la cola

        do
        {
            // Mostrar menú de opciones
            Console.WriteLine("\nSistema de atención al cliente:");
            Console.WriteLine("1. Agregar cliente a la cola");
            Console.WriteLine("2. Atender siguiente cliente");
            Console.WriteLine("3. Ver estado de la cola");
            Console.WriteLine("4. Salir");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    // Solicitar nombre del cliente y agregarlo a la cola
                    Console.WriteLine("Ingrese el nombre del cliente:");
                    nombreCliente = Console.ReadLine();
                    colaAtencion.Enqueue(nombreCliente);
                    break;

                case 2:
                    // Atender al siguiente cliente
                    colaAtencion.Dequeue();
                    break;

                case 3:
                    // Mostrar el estado actual de la cola
                    colaAtencion.ImprimirCola();
                    break;

                case 4:
                    // Salir del programa
                    estado = false;
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            // Preguntar si desea continuar
            if (estado)
            {
                Console.WriteLine("¿Deseas seguir con el programa? (s/n): ");
                respuesta = Console.ReadLine();
                if (respuesta.ToLower() == "n")
                {
                    estado = false;
                }
            }
        }
        while (estado);
    }
}
