using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using hotelsweb.Abstractions;

namespace hotelsweb.Pages.Review
{
    public class IndexModel : PageModel
    {
        readonly ITextAnalysisService _textAnalysisService;

        public IndexModel(ITextAnalysisService textAnalysisService) => _textAnalysisService = textAnalysisService;

        [BindProperty]
        public string SentimentEmoji { get; set; }
        [BindProperty]
        public string ReviewResponse { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            ReviewResponse = SentimentEmoji = string.Empty;

            var sentimentText = Request.Form["sentimentText"];
            var sentimentScore = await _textAnalysisService.GetSentiment(sentimentText);

            var response = GetResponse(sentimentScore);

            ReviewResponse = response.Response;
            SentimentEmoji = response.Emoji;

            return Page();
        }

        (string Emoji, string Response) GetResponse(double? sentimentScore)
        {
            switch (sentimentScore)
            {
                case double number when (number >= 0 && number < 0.4):
                    return (EmojiConstants.SadFaceEmoji, "We're sorry to hear that");
                case double number when (number >= 0.4 && number <= 0.6):
                    return (EmojiConstants.NeutralFaceEmoji, "Thank you");
                case double number when (number > 0.6):
                    return (EmojiConstants.HappyFaceEmoji, "Glad you enjoyed your stay");
                case null:
                    return (EmojiConstants.BlankFaceEmoji, "Sorry, we weren't able to understand your review");
                default:
                    return (string.Empty, string.Empty);
            }
        }
    }
}
