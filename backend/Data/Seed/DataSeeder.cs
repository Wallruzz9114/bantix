using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Seed
{
    public class DataSeeder
    {
        public static async Task SeedData(AppDbContext context)
        {
            if (!context.Agents.Any())
            {
                var agents = new List<Agent>
                {
                    new Agent
                    {
                        FullName = "Bantix Payments",
                        DisplayName = "banxx",
                        BusinessId = "5682ce9",
                        Password = "Pa$$w0rd",
                        AgentNumber = "007",
                        PIN = "3498"
                    }
                };

                await context.Agents.AddRangeAsync(agents);
                await context.SaveChangesAsync();
            }
        }
    }
}