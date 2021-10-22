using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Xamarin.Plugins.BottomSheet
{
    public class PickerItem : INotifyPropertyChanged
    {
        private bool _isChecked;


        private string _itemText;
        private string _imageSource;

        private Color _textColor = Color.Default;
        private FontAttributes _fontAttributes = FontAttributes.None;
        private double _characterSpacing = 0;
        private double _fontSize = 14;
        private string _fontFamily = null;
        private object _itemKey;

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                OnPropertyChanged();
            }
        }

        public string ItemText
        {
            get => _itemText;
            set
            {
                _itemText = value;
                OnPropertyChanged();
            }
        }

        public object ItemKey
        {
            get => _itemKey;
            set
            {
                _itemKey = value;
                OnPropertyChanged();
            }
        }

        public string ImageSource
        {
            get => _imageSource;
            set
            {
                _imageSource = value;
                OnPropertyChanged();
            }
        }

        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                OnPropertyChanged();
            }
        }

        public FontAttributes FontAttributes
        {
            get => _fontAttributes;
            set
            {
                _fontAttributes = value;
                OnPropertyChanged();
            }
        }

        public double CharacterSpacing
        {
            get => _characterSpacing;
            set
            {
                _characterSpacing = value;
                OnPropertyChanged();
            }
        }

        public double FontSize
        {
            get => _fontSize;
            set
            {
                _fontSize = value;
                OnPropertyChanged();
            }
        }

        public string FontFamily
        {
            get => _fontFamily;
            set
            {
                _fontFamily = value;
                OnPropertyChanged();
            }
        }

        public PickerItem()
        {
        }

        public PickerItem(string name)
        {
            _itemText = name;
        }

        public PickerItem(object key, string name)
        {
            _itemText = name;
            _itemKey = key;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
