using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Plugins.BottomSheet
{
    public class BottomPicker
    {
        static TaskCompletionSource<PickerItem> PickerTaskCompletionSource { get; set; }

        public static async Task<PickerItem> DisplayPicker(PickerConfig config)
        {
            PickerTaskCompletionSource = new TaskCompletionSource<PickerItem>();

            PickerViewBottomSheet pickerView = new PickerViewBottomSheet(config);
            pickerView.OnSelectedItemChanged += PickerView_OnSelectedItemChanged;
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(pickerView);

            var result = await PickerTaskCompletionSource.Task;
            return result;
        }

        private static void PickerView_OnSelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            PickerTaskCompletionSource.TrySetResult(e.Item);
        }
    }

    public class SelectedItemChangedEventArgs : EventArgs
    {
        public PickerItem Item { get; set; }
        public SelectedItemChangedEventArgs(PickerItem item)
        {
            Item = item;
        }
    }
}
