using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotelsweb.Abstractions
{
    public interface ITextAnalysisService
    {
        Task<double?> GetSentiment(string text);
        Task<Dictionary<string, double?>> GetSentiment(List<string> textList);
    }
}
