using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.IO;
using Xamarin.Forms;

namespace Countries.Views
{
    public partial class CountryDetailsPage : ContentPage
    {
        public CountryDetailsPage()
        {
            InitializeComponent();
        }
        public static readonly string DEST = $"{Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).AbsolutePath}.pdf";

        public static void Main(string[] args)
        {
            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();
        }

        private void ManipulatePdf(string dest)
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest,
                new WriterProperties().AddUAXmpMetadata().SetPdfVersion
                    (PdfVersion.PDF_1_7)));
            Document document = new Document(pdfDoc, PageSize.A4.Rotate());

            //TAGGED PDF
            //Make document tagged
            pdfDoc.SetTagged();

            //PDF/UA
            //Set document metadata
            pdfDoc.GetCatalog().SetViewerPreferences(new PdfViewerPreferences().SetDisplayDocTitle(true));
            pdfDoc.GetCatalog().SetLang(new PdfString("en-US"));
            PdfDocumentInfo info = pdfDoc.GetDocumentInfo();
            //info.SetTitle($"{}'s Details");

            //Paragraph p = new Paragraph();



            //p.Add($"{}'s Details").SetFontSize(30);

            //document.Add(p);

            //p = new Paragraph("\n\n\n\n").SetFontSize(20);
            //document.Add(p);

            //List list = new List().SetFontSize(20);
            //list.Add(new ListItem($"Capital: {}"));
            //list.Add(new ListItem($"Region: {}"));
            //list.Add(new ListItem($"Subregion: {}"));
            //list.Add(new ListItem($"Population: {}"));
            //list.Add(new ListItem($"Area: {}"));
            //list.Add(new ListItem($"NativeName: {}"));
            //list.Add(new ListItem($"Cioc: {}"));
            //list.Add(new ListItem($"NumericCode: {}"));
           // document.Add(list);

            document.Close();
        }






        private void OnButtonClicked(object sender, EventArgs e)
        {

            ManipulatePdf(DEST);

        }

    }
}
