using System;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

class Program
{
    static void Main(string[] args)
    {
        string pdfPath = "LoginCard.pdf";
        string imagePath = @"C:\Users\XD24100BT\Downloads\LoginCard.jpg";

        string website = "http://xdt-server:8880/";
        string league = "Legend Test League";
        string ownerTeam = "Pritish Kulkarni & Team1";
        string loginId = "pritish@gmail.com";
        string password = "Team1@1234";

        string loginUrl = $"http://xdt-server:8880/Identity/Account/Login?ReturnUrl=%2F?username={loginId}&password={password}";

        var writer = new PdfWriter(pdfPath);
        var pdf = new PdfDocument(writer);
        var document = new Document(pdf);

        PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

        // ✅ Add Image FULL WIDTH (Card Background)
        var imageData = ImageDataFactory.Create(imagePath);
        var bgImage = new Image(imageData)
            .ScaleToFit(500, 300)
            .SetFixedPosition(50, 400); // X, Y position

        document.Add(bgImage);

        // ✅ Overlay Text (adjust positions as needed)

        document.Add(new Paragraph($"Website: {website}")
            .SetFont(font)
            .SetFontSize(10)
            .SetFixedPosition(70, 650, 400));

        document.Add(new Paragraph($"League: {league}")
            .SetFont(font)
            .SetFontSize(12)
            .SetFixedPosition(70, 630, 400));

        document.Add(new Paragraph($"Owner: {ownerTeam}")
            .SetFont(font)
            .SetFontSize(10)
            .SetFixedPosition(70, 610, 400));

        document.Add(new Paragraph($"ID: {loginId}")
            .SetFont(font)
            .SetFontSize(10)
            .SetFixedPosition(70, 590, 400));

        document.Add(new Paragraph($"Pass: {password}")
            .SetFont(font)
            .SetFontSize(10)
            .SetFixedPosition(70, 570, 400));

        // ✅ Clickable Login Button ON CARD
        var link = new Link("LOGIN", PdfAction.CreateURI(loginUrl));

        var button = new Paragraph(link)
            .SetFont(font)
            .SetFontSize(12)
            .SetFixedPosition(350, 550, 120);

        document.Add(button);

        document.Close();

        Console.WriteLine("✅ Card PDF Generated with Overlay!");
    }
}