using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;

namespace hotelsweb.Services
{
    public class TextAnalysisService
    {
        readonly TextAnalyticsClient _textAnalyticsApiClient;

        public TextAnalysisService(TextAnalyticsClient textAnalyticsClient) => _textAnalyticsApiClient = textAnalyticsClient;

        public async Task<double?> GetSentiment(string text)
        {
            var sentimentDocument = new MultiLanguageBatchInput(new List<MultiLanguageInput> { { new MultiLanguageInput(id: "1", text: text) } });

            var sentimentResults = await _textAnalyticsApiClient.SentimentAsync(sentimentDocument).ConfigureAwait(false);

            if (sentimentResults?.Errors?.Any() ?? false)
            {
                var exceptionList = sentimentResults.Errors.Select(x => new Exception($"Id: {x.Id}, Message: {x.Message}"));
                throw new AggregateException(exceptionList);
            }

            var documentResult = sentimentResults?.Documents?.FirstOrDefault();

            return documentResult?.Score;
        }

        public async Task<Dictionary<string, double?>> GetSentiment(List<string> textList)
        {
            var textIdDictionary = new Dictionary<string, string>();
            var multiLanguageBatchInput = new MultiLanguageBatchInput(new List<MultiLanguageInput>());

            foreach (var text in textList)
            {
                var textGuidString = Guid.NewGuid().ToString();

                textIdDictionary.Add(textGuidString, text);

                multiLanguageBatchInput.Documents.Add(new MultiLanguageInput(id: textGuidString, text: text));
            }

            var sentimentResults = await _textAnalyticsApiClient.SentimentAsync(multiLanguageBatchInput).ConfigureAwait(false);

            if (sentimentResults?.Errors?.Any() ?? false)
            {
                var exceptionList = sentimentResults.Errors.Select(x => new Exception($"Id: {x.Id}, Message: {x.Message}"));
                throw new AggregateException(exceptionList);
            }

            var resultsDictionary = new Dictionary<string, double?>();

            foreach (var result in sentimentResults?.Documents)
                resultsDictionary.Add(textIdDictionary[result.Id], result?.Score);

            return resultsDictionary;
        }
    }
}
