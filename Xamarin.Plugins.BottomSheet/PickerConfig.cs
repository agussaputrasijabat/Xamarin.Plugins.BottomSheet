using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Xamarin.Plugins.BottomSheet
{
    public class PickerConfig : View
    {
        #region Event

        public event EventHandler SelectedIndexChanged;

        #endregion Event


        #region Fields

        private static readonly BindableProperty HasIconProperty = BindableProperty.Create(nameof(HasIcon),
            typeof(bool),
            typeof(BottomPicker), false);

        private static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource),
            typeof(List<PickerItem>), typeof(BottomPicker));

        private static readonly BindableProperty SortTypeProperty = BindableProperty.Create(nameof(SortType),
            typeof(SortType), typeof(BottomPicker), SortType.None);

        private static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string),
            typeof(BottomPicker), "");

        private static readonly BindableProperty TitleColorProperty = BindableProperty.Create(nameof(TitleColor),
            typeof(Color), typeof(BottomPicker), Color.Default);

        private static readonly BindableProperty TitleFontFamilyProperty = BindableProperty.Create(nameof(TitleFontFamily),
            typeof(string), typeof(BottomPicker), "Default");

        private static readonly BindableProperty TitleFontSizeProperty = BindableProperty.Create(nameof(TitleFontSize),
            typeof(double),
            typeof(BottomPicker), 16.0);

        private static readonly BindableProperty TitleImageProperty = BindableProperty.Create(nameof(TitleImageSource),
            typeof(string), typeof(BottomPicker), "");

        private static readonly BindableProperty SeparatorColorProperty = BindableProperty.Create(nameof(SeparatorColor),
           typeof(Color), typeof(BottomPicker), Color.LightGray);

        private static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(BottomPicker), Color.Default);

        private static readonly BindableProperty FontAttributesProperty =
            BindableProperty.Create(nameof(FontAttributes), typeof(FontAttributes), typeof(BottomPicker),
                FontAttributes.None);

        private static readonly BindableProperty CharacterSpacingProperty =
            BindableProperty.Create(nameof(CharacterSpacing), typeof(double), typeof(BottomPicker), 0.0);

        private static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(BottomPicker),
                16.0);

        private static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(BottomPicker), null);

        private static readonly BindableProperty SearchEnabledProperty =
            BindableProperty.Create(nameof(SearchEnabled), typeof(bool), typeof(BottomPicker), true);

        private static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(nameof(SelectedIndex),
            typeof(int), typeof(BottomPicker), -1);

        #endregion Fields

        #region Properties

        public bool HasIcon
        {
            get => (bool)GetValue(HasIconProperty);
            set => SetValue(HasIconProperty, value);
        }

        public List<PickerItem> ItemsSource
        {
            get => (List<PickerItem>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public SortType SortType
        {
            get => (SortType)GetValue(SortTypeProperty);
            set => SetValue(SortTypeProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public Color TitleColor
        {
            get => (Color)GetValue(TitleColorProperty);
            set => SetValue(TitleColorProperty, value);
        }

        public Color SeparatorColor
        {
            get => (Color)GetValue(SeparatorColorProperty);
            set => SetValue(SeparatorColorProperty, value);
        }

        public string TitleFontFamily
        {
            get => (string)GetValue(TitleFontFamilyProperty);
            set => SetValue(TitleFontFamilyProperty, value);
        }

        public double TitleFontSize
        {
            get => (double)GetValue(TitleFontSizeProperty);
            set => SetValue(TitleFontSizeProperty, value);
        }

        public string TitleImageSource
        {
            get => (string)GetValue(TitleImageProperty);
            set => SetValue(TitleImageProperty, value);
        }

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public FontAttributes FontAttributes
        {
            get => (FontAttributes)GetValue(FontAttributesProperty);
            set => SetValue(FontAttributesProperty, value);
        }

        public double CharacterSpacing
        {
            get => (double)GetValue(CharacterSpacingProperty);
            set => SetValue(CharacterSpacingProperty, value);
        }

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        public bool SearchEnabled
        {
            get => (bool)GetValue(SearchEnabledProperty);
            set => SetValue(SearchEnabledProperty, value);
        }

        public int SelectedIndex
        {
            get => (int)GetValue(SelectedIndexProperty);
            set => SetValue(SelectedIndexProperty, value);
        }

        #endregion Properties
    }
}
