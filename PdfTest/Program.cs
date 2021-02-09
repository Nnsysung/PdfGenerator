using System;
using System.IO;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Layout;
using iText.Layout.Properties;
using iText.Layout.Renderer;

namespace iText.Samples.Sandbox.Events
{
    class Utility
    {
        internal static string GetPath()
        {
            var exportFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var exportFile = System.IO.Path.Combine(exportFolder, "Test1.pdf");
            return exportFile;
        }
    }
    public class TableHeader
    {
        internal static PdfFont use = PdfFontFactory.CreateFont(
        FontProgramFactory.CreateFont(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "helveticaneuecyrmedium/HelveticaNeueCyr-Light.otf")), PdfEncodings.WINANSI, true); 
        internal static PdfFont use2 = PdfFontFactory.CreateFont(
        FontProgramFactory.CreateFont(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "helveticaneuecyrmedium/HelveticaNeueCyr-Bold.otf")), PdfEncodings.WINANSI, true);
        internal static PdfFont helvetica = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
        internal static PdfFont helveticaBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        public static readonly String DEST = Utility.GetPath();

        public static void Main(String[] args)
        {
            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();

            new TableHeader().ManipulatePdf(DEST);
        }

        protected void ManipulatePdf(String dest)
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
            Document document = new Document(pdfDoc);
           // doc.SetMargins(2, 2, 2, 2);

            TableHeaderEventHandler handler = new TableHeaderEventHandler(document);
            pdfDoc.AddEventHandler(PdfDocumentEvent.END_PAGE, handler);

            // Calculate top margin to be sure that the table will fit the margin.
            float topMargin = 20 + handler.GetTableHeight();
            document.SetMargins(topMargin, 2, 2, 2);

            //table1
            Table table1 = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth();

            Cell Cell_ = new Cell(1, 2).SetBorder(Border.NO_BORDER).SetPadding(10f)
             .Add(new Paragraph("BILL TO\n").SetTextAlignment(TextAlignment.LEFT).SetFontColor(WebColors.GetRGBColor("grey")))
             .Add(new Paragraph("gj\n").SetTextAlignment(TextAlignment.LEFT))
             .Add(new Paragraph("gj gj\n").SetTextAlignment(TextAlignment.LEFT))
             .Add(new Paragraph("blablabla@gmail\n").SetTextAlignment(TextAlignment.LEFT).SetMargin(3f));
            table1.AddCell(Cell_);
            Cell ACell = new Cell().SetBorder(Border.NO_BORDER)
             .Add(new Paragraph("Invoice Number: 1\n").SetTextAlignment(TextAlignment.LEFT).SetFontColor(WebColors.GetRGBColor("grey")).SetMargin(2f))
             .Add(new Paragraph("Invoice Date:\n").SetTextAlignment(TextAlignment.LEFT).SetMargin(2f).SetPadding(2f))
             .Add(new Paragraph("Payment Due:\n").SetTextAlignment(TextAlignment.LEFT).SetMargin(2f).SetPadding(2f))
             .Add(new Paragraph("AmountDue:\n").SetTextAlignment(TextAlignment.LEFT).SetBackgroundColor(new DeviceRgb(245, 245, 245)).SetMarginRight(15).SetPadding(5));
            table1.AddCell(ACell);
            Paragraph newline2 = new Paragraph(new Text("\n"));


            //table2
            Table table2 = new Table(UnitValue.CreatePercentArray(4)).UseAllAvailableWidth();

            var Dcell11 = new Cell().SetTextAlignment(TextAlignment.LEFT).SetFontColor(ColorConstants.WHITE).SetBackgroundColor(new DeviceRgb(187, 12, 15)).Add(new Paragraph("Item")).SetBorder(Border.NO_BORDER).SetPaddingLeft(15);
            Cell Dcell12 = new Cell().SetTextAlignment(TextAlignment.RIGHT).SetFontColor(ColorConstants.WHITE).SetBackgroundColor(new DeviceRgb(187, 12, 15)).Add(new Paragraph("Quantity:")).SetBorder(Border.NO_BORDER);
            Cell Dcell13 = new Cell().SetTextAlignment(TextAlignment.RIGHT).SetFontColor(ColorConstants.WHITE).SetBackgroundColor(new DeviceRgb(187, 12, 15)).Add(new Paragraph("Price:")).SetBorder(Border.NO_BORDER);
            Cell Dcell14 = new Cell().SetTextAlignment(TextAlignment.RIGHT).SetFontColor(ColorConstants.WHITE).SetBackgroundColor(new DeviceRgb(187, 12, 15)).Add(new Paragraph("Amount:")).SetBorder(Border.NO_BORDER).SetPaddingRight(15);

            table2.AddHeaderCell(Dcell11);
            table2.AddHeaderCell(Dcell12);
            table2.AddHeaderCell(Dcell13);
            table2.AddHeaderCell(Dcell14);

            //table3
            Table table3 = new Table(UnitValue.CreatePercentArray(4)).UseAllAvailableWidth();
            Cell Ecell11 = new Cell().SetTextAlignment(TextAlignment.LEFT).SetBorder(Border.NO_BORDER).SetPaddingLeft(15)
                                     .Add(new Paragraph("bjbvv"))
                                     .Add(new Paragraph("rgar"));
            Cell Ecell12 = new Cell().SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("1")).SetBorder(Border.NO_BORDER).SetPaddingLeft(7);
            Cell Ecell13 = new Cell().SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("NGN20,000.00")).SetBorder(Border.NO_BORDER);
            Cell Ecell14 = new Cell().SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("NGN20,000.00")).SetBorder(Border.NO_BORDER).SetPaddingRight(15);


            table3.AddCell(Ecell11);
            table3.AddCell(Ecell12);
            table3.AddCell(Ecell13);
            table3.AddCell(Ecell14);

            Paragraph newline3 = new Paragraph(new Text("\n"));

            // LineSeparator lineSeparator2 = new LineSeparator(new SolidLine(1f)).SetMargin(0);
            //lineSeparator Two
            SolidLine line2 = new SolidLine(2f);
            line2.SetColor(new DeviceRgb(235, 235, 235));
            LineSeparator lineSeparator2 = new LineSeparator(line2);
            lineSeparator2.SetMarginTop(5);
            Paragraph newline7 = new Paragraph(new Text("\n"));

            //table4
            Table table4 = new Table(UnitValue.CreatePercentArray(4)).UseAllAvailableWidth();
            Cell Fcell10 = new Cell().SetBorder(Border.NO_BORDER);
            Cell Fcell01 = new Cell().SetBorder(Border.NO_BORDER);
            Cell Fcell11 = new Cell().SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER)
                                  .Add(new Paragraph("SubTotal"))
                                  .Add(new Paragraph("VAT 7.5%:"));
            Cell Fcell12 = new Cell().SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER).SetPaddingRight(15)
                             .Add(new Paragraph("NGN20,000.00"))
                             .Add(new Paragraph("NGN20,000.00"));
            table4.AddCell(Fcell10);
            table4.AddCell(Fcell01);
            table4.AddCell(Fcell11);
            table4.AddCell(Fcell12);
            Paragraph newline6 = new Paragraph(new Text("\n"));
            //lineSeparator Three
            SolidLine line3 = new SolidLine(1f);
            line3.SetColor(new DeviceRgb(235, 235, 235));
            LineSeparator lineSeparator3 = new LineSeparator(line3);
            lineSeparator3.SetWidth(UnitValue.CreatePercentValue(50));
            lineSeparator3.SetMarginTop(5).SetHorizontalAlignment(HorizontalAlignment.RIGHT);




            //table5
            Table table5 = new Table(UnitValue.CreatePercentArray(4)).SetFixedLayout().UseAllAvailableWidth().SetBorder(Border.NO_BORDER);
            Cell Gcell10 = new Cell().SetBorder(Border.NO_BORDER);
            Cell Gcell01 = new Cell().SetBorder(Border.NO_BORDER);
            Cell Gcell11 = new Cell().SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("Total")).SetBorder(Border.NO_BORDER);
            Cell Gcell12 = new Cell().SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("20,000.00")).SetBorder(Border.NO_BORDER).SetPaddingRight(15);
            table5.AddCell(Gcell10);
            table5.AddCell(Gcell01);
            table5.AddCell(Gcell11);
            table5.AddCell(Gcell12);
            Paragraph newline4 = new Paragraph(new Text("\n"));
            SolidLine line4 = new SolidLine(2f);
            line4.SetColor(new DeviceRgb(243, 243, 243));
            LineSeparator lineSeparator4 = new LineSeparator(line4);
            lineSeparator4.SetWidth(UnitValue.CreatePercentValue(50));
            lineSeparator4.SetMarginTop(5).SetHorizontalAlignment(HorizontalAlignment.RIGHT);
            Paragraph newline5 = new Paragraph(new Text("\n"));



            //table6
            Table table6 = new Table(UnitValue.CreatePercentArray(4)).SetFixedLayout().UseAllAvailableWidth().SetBorder(Border.NO_BORDER);
            Cell Hcell10 = new Cell().SetBorder(Border.NO_BORDER);
            Cell Hcell01 = new Cell().SetBorder(Border.NO_BORDER);
            Cell Hcell11 = new Cell().SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("Amount DUE:(NGN)")).SetBorder(Border.NO_BORDER);
            Cell Hcell12 = new Cell().SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("NGN20,000.00")).SetBorder(Border.NO_BORDER).SetPaddingRight(15);
            table6.AddCell(Hcell10);
            table6.AddCell(Hcell01);
            table6.AddCell(Hcell11);
            table6.AddCell(Hcell12);


            //Footer1

            Paragraph footerOne = new Paragraph(new Text("NOTES/TERMS\n")).SetFont(helveticaBold).SetFontSize(10).SetFontColor(ColorConstants.BLACK)
                .Add(new Paragraph(new Text("This invoice was automatically generated based on your subscribed station(s) on Epump\n")).SetFont(helvetica).SetFontSize(6).SetFontColor(ColorConstants.BLUE))
                .Add(new Paragraph(new Text("Account Details; Fuelmetrics Limited - Sterling Bank PLC - 0064817430\n")).SetFont(helvetica).SetFontSize(6).SetFontColor(ColorConstants.BLUE))
                .Add(new Paragraph(new Text("\n")));
            //footer2
            Paragraph footerTwo = new Paragraph(new Text("For direct Remittance of VAT\n")).SetFont(helveticaBold).SetFontSize(6).SetFontColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph(new Text("TIN: 17908005-0001\n").SetFont(helvetica).SetFontSize(6).SetFontColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER)))
                .Add(new Paragraph(new Text("VAT Number: ISV 100021222832\n").SetFont(helvetica).SetFontSize(6).SetFontColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER)))
                .Add(new Paragraph(new Text("\n")));
            //pdf.AddEventHandler(PdfDocumentInfo.)


            // int numberOfPages = pdf.GetNumberOfPages();
            // for (int i = 1; i <= numberOfPages;    i++)
            // {

            //Rectangle pageSize = pdf.GetPage(i).GetPageSize();

            // float x = pageSize.GetWidth() / 2;
            // float y = pageSize.GetTop() - 9;
           





           
            document.Add(table1);
            document.Add(newline2);
            document.Add(table2);
            document.Add(table3);
            document.Add(newline3);
            document.Add(lineSeparator2);
            document.Add(newline7);
            document.Add(table4);
            document.Add(newline6);
            document.Add(lineSeparator3);
            document.Add(newline4);
            document.Add(table5);
            document.Add(newline5);
            document.Add(lineSeparator4);
            document.Add(table6);
            document.Add(footerOne);
            document.Add(footerTwo);
            document.Close();
            //for (int i = 0; i < 50; i++)
            //{
            //    doc.Add(new Paragraph("Hello World!"));
            //}

            //doc.Add(new AreaBreak());
            //doc.Add(new Paragraph("Hello World!"));
            //doc.Add(new AreaBreak());
            //doc.Add(new Paragraph("Hello World!"));

            //doc.Close();
        }

        private class TableHeaderEventHandler : IEventHandler
        {
            private Table table;
            private float tableHeight;
            private Document doc;

            public TableHeaderEventHandler(Document doc)
            {
                this.doc = doc;
                InitTable();

                TableRenderer renderer = (TableRenderer)table.CreateRendererSubTree();
                renderer.SetParent(new DocumentRenderer(doc));

                // Simulate the positioning of the renderer to find out how much space the header table will occupy.
                LayoutResult result = renderer.Layout(new LayoutContext(new LayoutArea(0, PageSize.LETTER)));
                tableHeight = result.GetOccupiedArea().GetBBox().GetHeight();
            }

            public void HandleEvent(Event currentEvent)
            {
                Color magentaColor = new DeviceRgb(235, 237, 238);
                PdfDocumentEvent docEvent = (PdfDocumentEvent)currentEvent;
                PdfDocument pdfDoc = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();
                PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
                PageSize pageSize = pdfDoc.GetDefaultPageSize();
                float coordX = pageSize.GetX() + doc.GetLeftMargin();
                float coordY = pageSize.GetTop() - doc.GetTopMargin();
                float width = pageSize.GetWidth() - doc.GetRightMargin() - doc.GetLeftMargin();
                float height = GetTableHeight();
                Rectangle rect = new Rectangle(coordX, coordY, width, height);
                new Canvas(canvas.SetStrokeColor(magentaColor)
                .MoveTo(0, 700)
                .LineTo(806, 700).SetLineWidth(1f)
                .ClosePathStroke(), rect)
                    .Add(table)
                    .Close();
            }

            public float GetTableHeight()
            {
                return tableHeight;
            }

            private void InitTable()
            {
                Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                table = new Table(new float[] { 1, 1}).UseAllAvailableWidth();
                table.SetMarginBottom(30);
                table.SetMarginLeft(18);
                table.SetMarginRight(18);
                // table.AddCell(new Image(ImageDataFactory
                //       .Create(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "FMLogo.png")))
                //       .SetTextAlignment(TextAlignment.LEFT).SetHeight(90).SetWidth(130).SetFixedPosition(700, 500));
                // table.AddCell(new Paragraph().Add("INVOICE").SetTextAlignment(TextAlignment
                //         .LEFT).SetFont(helveticaBold).SetFontSize(30).Add("FuelMetrics").SetTextAlignment(TextAlignment
                //         .LEFT).SetFont(helveticaBold).Add("Nigeria").SetTextAlignment(TextAlignment
                //         .LEFT).SetFont(helvetica)

                //);
                var para = new Paragraph();

                para.Add(new Text("INVOICE\n").SetFont(use).SetFontSize(30));
                para.Add(new Text("Epump Monthly Subscription\n").SetFont(use).SetFontSize(10));
                para.Add(new Text("FuelMetrics\n").SetFont(use2).SetFontSize(10));                
                para.Add(new Text("252, Herbert Macaulay Way.Yaba\n").SetFont(use).SetFontSize(10));
                para.Add(new Text("Lagos").SetFont(use).SetFontSize(10));
                para.Add(new Text("Nigeria").SetFont(use).SetFontSize(10));
                para.Add(new Text("Mobile: 08033909676 , 08060716470\n").SetFont(use).SetFontSize(10));
                para.Add(new Text("www.epump.com.ng\n").SetFont(use).SetFontSize(10));

                var path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "FMLogo.png");
                var img = new Image(ImageDataFactory.Create(path)).SetMarginTop(5f);
                img.SetWidth(UnitValue.CreatePercentValue(50));
                table.AddCell(new Cell().Add(img)
                      .SetTextAlignment(TextAlignment.LEFT).SetBorder(Border.NO_BORDER)).SetMarginTop(1f);
                table.AddCell(new Cell().SetPadding(0).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).Add(para));

            }
            public Cell getCell(String text, TextAlignment alignment)
            {
                Cell cell = new Cell().Add(new Paragraph(text).SetFont(use).SetFontSize(30).Add(text));
                cell.SetPadding(0);
                cell.SetTextAlignment(alignment);
                cell.SetBorder(Border.NO_BORDER);
                return cell;
            }
        }

    }

}