using Flashcards2.DataLayer;
using System.Collections.Generic;
using System.Linq;

namespace Flashcards2.ServiceLayer
{
    public interface IListTopicsService
    {
        /// <summary>
        /// Returns a <see cref="List{Topic}"/> of all topics.
        /// </summary>
        /// <returns><see cref="List{Topic}"/> of topics</returns>
        IList<Topic> ListTopics();
    }
}