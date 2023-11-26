using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

QuestPDF.Settings.License = LicenseType.Community;

Document
    .Create(container =>
{
    container.Page(page =>
    {
        page.Size(PageSizes.A4);
        page.Margin(2, Unit.Centimetre);
        page.PageColor(Colors.White);
        page.DefaultTextStyle(x => x.FontSize(20));

        page.Header()
            .AlignCenter()
            .Text("Musala Travel Guide!")
            .SemiBold().FontSize(30).FontColor(Colors.Blue.Medium);

        page.Content()
            .PaddingVertical(1, Unit.Centimetre)
            .Column(x =>
            {
                x.Spacing(20);
                x.Item().Text(Placeholders.LoremIpsum());
                x.Item().Image(Placeholders.Image(200, 100));
                x.Item()
                    .AlignCenter()
                    .Text(t =>
                    {
                        t.Hyperlink("Watch my Youtube Video!", "https://www.youtube.com/watch?v=A8cxj953Sus").SemiBold().FontSize(25).FontColor(Colors.Red.Medium);
                    });
                x.Item().Text("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua");
                x.Item().AlignRight().Text("King Vasilkovski!").ExtraBold().FontSize(25).FontColor(Colors.Red.Medium);
            });

        page.Footer()
            .AlignCenter()
            .Text(x =>
            {
                x.Span("Page ");
                x.CurrentPageNumber();
            });
    });
})
    .ShowInPreviewer();