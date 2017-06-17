using Xamarin.Forms;
using System;
using PDFSample.ModelViews;

namespace PDFSample
{
    public partial class PDFSamplePage : ContentPage
    {
        FormViewModel vm;
        
        public PDFSamplePage()
        {
            InitializeComponent();

            BindingContext = vm = new FormViewModel();
        }

        public void ButtonClicked(object sender, EventArgs e)
        {
            vm.CreatePDF();
        }
    }
}
