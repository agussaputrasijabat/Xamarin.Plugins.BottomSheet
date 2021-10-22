using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Xamarin.Plugins.BottomSheet
{
    public partial class PickerViewBottomSheet : BaseBottomSheet, INotifyPropertyChanged
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

        private PickerConfig _config;

        public delegate void SelectedItemChangedEventHandler(object sender, SelectedItemChangedEventArgs e);
        public event SelectedItemChangedEventHandler OnSelectedItemChanged;

        public PickerViewBottomSheet(PickerConfig config) : base()
        {
            InitializeComponent();
            Config = config;

            AnimationTranslationValue = ScreenSize.Height;
            VerticalContentOptions = LayoutOptions.EndAndExpand;

            BindingContext = this;
        }

        public PickerConfig Config
        {
            get => _config;
            set
            {
                _config = value;
                OnPropertyChanged();
            }
        }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            IsPullToCloseEnabled = !(e.VerticalOffset > 0);
        }

        void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection == null) return;

            PickerItem item = null;
            if (e.CurrentSelection.Any())
            {
                item = (PickerItem)e.CurrentSelection.First();
                collectionView.SelectedItem = null;
            }

            OnSelectedItemChanged?.Invoke(this, new SelectedItemChangedEventArgs(item));
            base.Pop();
        }

        // Invoked after an animation disappearing
        protected override void OnDisappearingAnimationEnd()
        {
            OnSelectedItemChanged?.Invoke(this, new SelectedItemChangedEventArgs(null));
            base.OnDisappearingAnimationEnd();
        }
    }
}
