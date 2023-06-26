using registroCliente.Models;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Agregar un cliente
        AgregarCliente();

        // Consultar clientes
        ConsultarClientes();

        // Modificar un cliente
        ModificarCliente();

        Console.ReadLine();
    }

    public static void AgregarCliente()
    {
        Console.WriteLine("Agregar cliente");
        using (var context = new RegistroContext())
        {
            Cliente cliente = new Cliente()
            {
                Nombre = "John",
                Apellido = "Doe",
                Dirección = "123 Main St",
                Telefono = "555-1234",
                FechaNacimiento = new DateTime(1990, 1, 1),
                Estado = "Activo"
            };

            context.Clientes.Add(cliente);
            context.SaveChanges();

            Console.WriteLine("Cliente agregado con éxito. ID: " + cliente.Id);
        }
    }

    public static void ConsultarClientes()
    {
        Console.WriteLine("Consultar clientes");
        using (var context = new RegistroContext())
        {
            List<Cliente> clientes = context.Clientes.ToList();

            foreach (var cliente in clientes)
            {
                Console.WriteLine("ID: " + cliente.Id);
                Console.WriteLine("Nombre: " + cliente.Nombre);
                Console.WriteLine("Apellido: " + cliente.Apellido);
                Console.WriteLine("Dirección: " + cliente.Dirección);
                Console.WriteLine("Teléfono: " + cliente.Telefono);
                Console.WriteLine("Fecha de Nacimiento: " + cliente.FechaNacimiento);
                Console.WriteLine("Estado: " + cliente.Estado);
                Console.WriteLine();
            }
        }
    }

    public static void ModificarCliente()
    {
        Console.WriteLine("Modificar cliente");
        using (var context = new RegistroContext())
        {
            Console.WriteLine("Ingrese el ID del cliente a modificar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Cliente cliente = context.Clientes.Find(id);
            if (cliente != null)
            {
                Console.WriteLine("Ingrese el nuevo nombre del cliente: ");
                cliente.Nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el nuevo apellido del cliente: ");
                cliente.Apellido = Console.ReadLine();

                Console.WriteLine("Ingrese la nueva dirección del cliente: ");
                cliente.Dirección = Console.ReadLine();

                Console.WriteLine("Ingrese el nuevo teléfono del cliente: ");
                cliente.Telefono = Console.ReadLine();

                Console.WriteLine("Ingrese la nueva fecha de nacimiento del cliente (yyyy-MM-dd): ");
                cliente.FechaNacimiento = DateTime.Parse(Console.ReadLine());

                context.SaveChanges();
                Console.WriteLine("Cliente modificado con éxito.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
    }
}
