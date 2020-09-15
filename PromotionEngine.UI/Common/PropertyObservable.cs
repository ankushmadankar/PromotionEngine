using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PromotionEngine.UI.Common
{
    public class PropertyObservable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
