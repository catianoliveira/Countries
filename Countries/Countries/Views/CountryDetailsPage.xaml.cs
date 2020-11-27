using Android.Media;
using Countries.Common.Models;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Countries.ViewModels;

namespace Countries.Views
{
    public partial class CountryDetailsPage : ContentPage
    {
        private List<CountryResponse> Countries;

        public CountryDetailsPage()
        {
            InitializeComponent();

        }
        public static readonly string DEST = $"{Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).AbsolutePath}.pdf";

       /// <summary>
       /// creates pdf
       /// </summary>
       /// <param name="dest"></param>
        private void CreatePdf(string dest)
        {
            //CountryResponse country = Countries[];

            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest,
                new WriterProperties().AddUAXmpMetadata().SetPdfVersion
                    (PdfVersion.PDF_1_7)));
            Document document = new Document(pdfDoc, PageSize.A4.Rotate());

            
            pdfDoc.SetTagged();

            
            pdfDoc.GetCatalog().SetViewerPreferences(new PdfViewerPreferences().SetDisplayDocTitle(true));
            pdfDoc.GetCatalog().SetLang(new PdfString("en-US"));
            PdfDocumentInfo info = pdfDoc.GetDocumentInfo();
            info.SetTitle($"'s Details");

            Paragraph p = new Paragraph();



            p.Add($"'s Details").SetFontSize(30);

            document.Add(p);

            p = new Paragraph("\n\n\n\n").SetFontSize(20);
            document.Add(p);

            List list = new List().SetFontSize(20);
            list.Add(new ListItem($"Capital: "));
            list.Add(new ListItem($"Region: "));
            list.Add(new ListItem($"Subregion: "));
            list.Add(new ListItem($"Population: "));
            list.Add(new ListItem($"Area: "));
            list.Add(new ListItem($"NativeName: "));
            list.Add(new ListItem($"Cioc: "));
            list.Add(new ListItem($"NumericCode: "));
            document.Add(list);

            document.Close();

        }


        private void OnButtonClicked(object sender, EventArgs e)
        {
            CreatePdf(DEST);
        }
    }
}
