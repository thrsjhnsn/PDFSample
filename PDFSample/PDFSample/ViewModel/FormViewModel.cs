using System;
using PDFSample.Models;
using Xamarin.Forms;

namespace PDFSample.ModelViews
{
    public class FormViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }


        public FormViewModel()
        {
            this.FirstName = "Homer";
            this.LastName = "Simpson";
            this.Address = "742 Evergreen Terrace";
        }

        public void CreatePDF()
        {
            Form form = new Form()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Address = this.Address
            };

            DependencyService.Get<ICreatePDF>().CreatePDF(form);
        }
    }
}
