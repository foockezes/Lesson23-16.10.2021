using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleApp.Models
{
    [Table("Clients")]
    public class Client
    {
        public int Id { get; set; }
        public string Login { get; set; }
    }
}
