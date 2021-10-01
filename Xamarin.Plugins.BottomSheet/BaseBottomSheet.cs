using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Xamarin.Plugins.BottomSheet
{
    public class BaseBottomSheet : Rg.Plugins.Popup.Pages.PopupPage
    {
        public static BindableProperty VerticalContentOptionsProperty =
           BindableProperty.Create(nameof(VerticalContentOptions),
               typeof(LayoutOptions), typeof(BaseBottomSheet), LayoutOptions.EndAndExpand);

        public LayoutOptions VerticalContentOptions
        {
            get => (LayoutOptions)GetValue(VerticalContentOptionsProperty);
            set => SetValue(VerticalContentOptionsProperty, value);
        }

        public static BindableProperty SheetContentProperty =
            BindableProperty.Create(nameof(SheetContent),
                typeof(View), typeof(BaseBottomSheet), propertyChanged: OnDismissableContentChanged);

        public View SheetContent
        {
            get => (View)GetValue(SheetContentProperty);
            set => SetValue(SheetContentProperty, value);
        }

        public static BindableProperty AnimationTranslationValueProperty =
            BindableProperty.Create(nameof(AnimationTranslationValue),
                typeof(double), typeof(BaseBottomSheet),
                propertyChanged: (view, oldval, newval) =>
                {
                    if (oldval == newval) return;
                    if (view is BaseBottomSheet page && newval is double val)
                        page.Animation = new BaseBottomSheetAnimation(val);
                });

        public double AnimationTranslationValue
        {
            get => (double)GetValue(AnimationTranslationValueProperty);
            set => SetValue(AnimationTranslationValueProperty, value);
        }

        public static BindableProperty IsPullToCloseEnabledProperty =
           BindableProperty.Create(nameof(IsPullToCloseEnabled),
               typeof(bool), typeof(BaseBottomSheet), true,
               propertyChanged: (view, oldval, newval) =>
               {
                   if (oldval == newval) return;
                   if (view is BaseBottomSheet page && page.Content is SwipeView swipeView)
                       if ((bool)newval)
                       {
                           var swipeItem = new SwipeItem()
                           {
                               BackgroundColor = Color.Transparent
                           };
                           swipeItem.Invoked += (args, e) => page.Pop();
                           var swipeItems = new SwipeItems() {
                                 swipeItem
                            };
                           swipeItems.Mode = SwipeMode.Execute;
                           swipeView.TopItems = swipeItems;
                       }
                       else
                       {
                           swipeView.TopItems?.Clear();
                       }
               });

        public bool IsPullToCloseEnabled
        {
            get => (bool)GetValue(IsPullToCloseEnabledProperty);
            set => SetValue(IsPullToCloseEnabledProperty, value);
        }

        private static void OnDismissableContentChanged(object bindable, object oldValue, object newValue)
        {
            BaseBottomSheet popop = (BaseBottomSheet)bindable;
            popop.Init();
            Console.WriteLine(newValue);
        }

        public BaseBottomSheet()
        {
            Animation = new BaseBottomSheetAnimation();
            IsAnimationEnabled = true;
            CloseWhenBackgroundIsClicked = true;
            SystemPaddingSides = PaddingSide.All;
            HasSystemPadding = true;
            HasKeyboardOffset = false;
        }

        public void Init()
        {
            var swipeItem = new SwipeItem()
            {
                BackgroundColor = Color.Transparent
            };
            swipeItem.Invoked += (args, e) => Pop();
            var swipeItems = new SwipeItems() {
                swipeItem
            };
            swipeItems.Mode = SwipeMode.Execute;

            Content = new SwipeView()
            {
                TopItems = swipeItems,
                BackgroundColor = Color.Transparent,
                Content = new ContentView()
                .Bind(ContentView.ContentProperty, SheetContentProperty.PropertyName, source: this)
            }.Bind(View.VerticalOptionsProperty, VerticalContentOptionsProperty.PropertyName, source: this);
        }

        public Size ScreenSize => new Size(
           DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density,
           DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density);

        public virtual void Pop()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.Navigation.PopPopupAsync();
            });
        }
    }
}
