using System;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using PDFSample.iOS;
using Xamarin.Forms;
using Plugin.Messaging;
using PDFSample.Models;



[assembly: Dependency(typeof(iOSCreatePDF))]
namespace PDFSample.iOS
{
	public class iOSCreatePDF : ICreatePDF
	{
       
		
		public void CreatePDF(Form form)
		{

			string fileName = "PDFSample.pdf";

			try
			{
                var directory =  Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				if (!Directory.Exists(directory))
				{
					Directory.CreateDirectory(directory);
				}

				var path = Path.Combine(directory, fileName);

				var fs = new FileStream(path, FileMode.Create);

				Document document = new Document(PageSize.A4, 25, 25, 30, 30);	

				PdfWriter writer = PdfWriter.GetInstance(document, fs);

				document.Open();


				
                document.Add(new Paragraph("PDF Sample"));
                document.Add(new Paragraph("FirstName: "+ form.FirstName));
                document.Add(new Paragraph("LastName: " + form.LastName));
                document.Add(new Paragraph("Address: " + form.Address));

			
				document.Close();

				writer.Close();
	
				fs.Close();

				SendEmail(path);





			}
			catch (Exception e)
			{
				string message = e.Message;
				
			}

		}


		private void SendEmail(string path)
		{
            
			
			var emailMessenger = CrossMessaging.Current.EmailMessenger;
			var email = new EmailMessageBuilder()
			  .Subject("Subject line ")
			  .Body("Body of the email")
			  .WithAttachment(path,".pdf")
			  .Build();
            
			emailMessenger.SendEmail(email);

		}


		

	}
}

