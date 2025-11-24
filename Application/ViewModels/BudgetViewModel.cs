using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class BudgetViewModel
    {
        public BudgetViewModel(Guid guid, decimal generalAmount, decimal availableAmount, string name)
        {
            Guid = guid;
            GeneralAmount = generalAmount;
            AvailableAmount = availableAmount;
            Name = name;
        }

        public Guid Guid { get; set; }
        public decimal GeneralAmount { get; set; }
        public decimal AvailableAmount { get; set; }
        public string Name { get; set; } = null!;
    }
}
