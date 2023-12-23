using sheff.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheff.ViewModels
{
    public class ViewModel_Service : ViewModel
    {
        private bool _isSelected;
        private string _description;
        private int? _costOfMeter;
        private int? _costOfSquareMeter;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public int? CostOfMeter
        {
            get { return _costOfMeter; }
            set
            {
                if (_costOfMeter != value)
                {
                    _costOfMeter = value;
                    OnPropertyChanged(nameof(CostOfMeter));
                }
            }
        }

        public int? CostOfSquareMeter
        {
            get { return _costOfSquareMeter; }
            set
            {
                if (_costOfSquareMeter != value)
                {
                    _costOfSquareMeter = value;
                    OnPropertyChanged(nameof(CostOfSquareMeter));
                }
            }
        }

        public int Cost => IsSelected ? (CostOfSquareMeter ?? 0) : (CostOfMeter ?? 0);
    }
}
