using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using hotelsweb.Abstractions;
using hotelsweb.Services;
using System;
using Microsoft.Extensions.Logging;

namespace hotelsweb.Pages.Review
{
    public class IndexModel : PageModel
    {
        private readonly ReviewsService _reviewsService;
        private readonly ITextAnalysisService _textAnalysisService;
        private readonly ILogger _logger;

        public IndexModel(ITextAnalysisService textAnalysisService, 
            ReviewsService reviewsService,
            ILogger<IndexModel> logger)
        {
            _reviewsService = reviewsService;
            _textAnalysisService = textAnalysisService;
            _logger = logger;
        }

        public string SentimentEmoji { get; set; }
        public string ReviewResponse { get; set; }
        [BindProperty]
        public string ReviewText { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            await SubmitReview();
            await AnalyzeSentiment();
            return Page();
        }

        private async Task SubmitReview()
        {
            try
            {
                await _reviewsService.SubmitAsync(ReviewText);
            }
            catch(Exception ex)
            {
                _logger.LogWarning("Unable to submit review: " + ex.Message);
            }
        }

        private async Task AnalyzeSentiment()
        {
            ReviewResponse = SentimentEmoji = string.Empty;

            try
            {
                var sentimentScore = await _textAnalysisService.GetSentiment(ReviewText);

                var response = GetResponse(sentimentScore);

                ReviewResponse = response.Response;
                SentimentEmoji = response.Emoji;
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Unable to retrieve sentiment: " + ex.Message);
            }
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
