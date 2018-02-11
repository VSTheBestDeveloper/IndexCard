using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IndexCard.Models;

namespace IndexCard.Entities
{
    public class IndexCardRepo : IIndexCardRepo
    {
        public KeyValuePair<string, string> GetQuestionAnswer()
        {
            using (var context = new MVCDBEntities())
            {
                Random rand = new Random();
                int toSkip = rand.Next(0, context.QnAs.Count<QnA>());
               
                var myQnA = context.QnAs.OrderBy(q => q.QnAId).Skip(toSkip).Take(1).First();
                var question = myQnA.Question;
                var answer = myQnA.Answer;
                return new KeyValuePair<string, string>(question, answer);
            }
        }
    }
}