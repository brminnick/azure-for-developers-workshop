using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace hotelsweb.Pages.Sentiment
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string SentimentEmoji { get; set; }
        [BindProperty]
        public string SentimentText { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            SentimentEmoji = string.Empty;

            var sentimentText = Request.Form["sentimentText"];
            SentimentText = "Analyzing Text";

            var result = await TextAnalysisService.GetSentiment(sentimentText);

            SentimentText = sentimentText;
            SentimentEmoji = GetEmoji(result);

            return Page();
        }

        string GetEmoji(double? sentimentScore)
        {
            switch (sentimentScore)
            {
                case double number when (number >= 0 && number < 0.4):
                    return EmojiConstants.SadFaceEmoji;
                case double number when (number >= 0.4 && number <= 0.6):
                    return EmojiConstants.NeutralFaceEmoji;
                case double number when (number > 0.6):
                    return EmojiConstants.HappyFaceEmoji;
                case null:
                    return EmojiConstants.BlankFaceEmoji;
                default:
                    return string.Empty;
            }
        }
    }
}
