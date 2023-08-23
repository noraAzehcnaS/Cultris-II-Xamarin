using Cultris_II.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cultris_II.Services
{
    public interface IDataService
    {
        bool Insert(Player player);
        bool Delete(Player player);
        Task<List<Player>> Read();
    }
    public class DataService
    {
        private static readonly IDataService dataService = DependencyService.Get<IDataService>();

        public static bool Insert(Player player) { return dataService.Insert(player);}

        public static bool Delete(Player player) { return dataService.Delete(player);}
        
        public static Task<List<Player>> Read() { return dataService.Read(); }

    }
}
