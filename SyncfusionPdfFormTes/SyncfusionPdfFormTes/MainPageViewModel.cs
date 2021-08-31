using MvvmHelpers;
using Syncfusion.Pdf.Parsing;
using System.IO;
using System.Reflection;

namespace SyncfusionPdfFormTest
{
	public class MainPageViewModel : BaseViewModel
	{
		private Stream pdfStream;
		public Stream PdfStream
		{
			get => pdfStream;
			set => SetProperty(ref pdfStream, value);
		}

		public MainPageViewModel()
		{
			using var pdfFile = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SyncfusionPdfFormTest.Resources.TestPdf.pdf");
			var document = new PdfLoadedDocument(pdfFile);

			var form = document.Form;
			form.SetDefaultAppearance(false);

			if (form.Fields["totalHours"] is PdfLoadedTextBoxField totalField)
			{
				totalField.Text = "I changed it!";
			}

			pdfStream = new MemoryStream();
			document.Save(pdfStream);
		}
	}
}
