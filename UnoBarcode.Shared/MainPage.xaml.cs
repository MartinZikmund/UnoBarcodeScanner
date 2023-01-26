using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ZXing.Mobile;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UnoBarcode
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ScanClick(object sender, RoutedEventArgs e)
        {
#if __ANDROID__ || __IOS__ || WINDOWS_UWP
            var scanner = new MobileBarcodeScanner();
            var result = await scanner.Scan();
            BarcodeTextBlock.Text = result.Text ?? "No barcode";
#else
            BarcodeTextBlock.Text = "Barcode scanner not available on this device.";
#endif
        }
    }
}
