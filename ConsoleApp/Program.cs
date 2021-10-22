using EFCoreConsoleApp.Context;
using EFCoreConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var CreatNewClient = await CreateClientAsync(new Client() { Login = "Akajon" });
            if (!CreatNewClient)
            {
                Console.WriteLine("Client not created");
            }

            var allClients = await GetClientsInfo();
            if (allClients.Count == 0)
            {
                Console.WriteLine("No students found");
            }
            foreach (var item in allClients)
            {
                Console.WriteLine(item.Login);
            }

            var updateClient = await UpdateById(1002, "Halif");
            if (!updateClient)
            {
                Console.WriteLine("not updated");
            }

            var deleteClientById = await DeleteClient(1003);
            if (!deleteClientById)
            {
                Console.WriteLine("Not deleted");
            }


        }
        private static async Task<bool> CreateClientAsync(Client client)
        {
            using var ClientDbContext = new ClientDbContext();
            ClientDbContext.Clients.Add(client);

            var save = await ClientDbContext.SaveChangesAsync();

            return save > 0;
        }
        private static async Task<List<Client>> GetClientsInfo()
        {
            using var ClientDbContext = new ClientDbContext();
            var clients = await ClientDbContext.Clients.ToListAsync();
            return clients;
        }
        private static async Task<bool> UpdateById(int Id, string clientLogin)
        {
            using var ClientDbContext = new ClientDbContext();
            var clientId = await ClientDbContext.Clients.FindAsync(Id);
            if (clientId == null)
            {
                return false;
            }
            clientId.Login = clientLogin;

            var studentSaveResult = await ClientDbContext.SaveChangesAsync();
            return studentSaveResult > 0;
        }

        private static async Task<bool> DeleteClient(int Id)
        {
            using var ClientDbContext = new ClientDbContext();
            var clientId = await ClientDbContext.Clients.FindAsync(Id);
            if (clientId == null)
            {
                return false;
            }
            ClientDbContext.Remove(clientId);
            
            var studentSaveResult = await ClientDbContext.SaveChangesAsync();
            return studentSaveResult > 0;
        }
    }
}
