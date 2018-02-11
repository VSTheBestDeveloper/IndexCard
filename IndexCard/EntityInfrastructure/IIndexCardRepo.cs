using System.Collections.Generic;

namespace IndexCard.Entities
{
    public interface IIndexCardRepo
    {
        KeyValuePair<string, string> GetQuestionAnswer();
    }
}