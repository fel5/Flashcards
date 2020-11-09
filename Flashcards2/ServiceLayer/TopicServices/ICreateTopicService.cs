using Flashcards2.DataLayer;

namespace Flashcards2.ServiceLayer
{
    public interface ICreateTopicService
    {
        /// <summary>
        /// Creates a new Topic.
        /// </summary>
        /// <param name="title"></param>
        /// <returns>
        /// <see cref="TopicDto"/> if Topic was successfully created;
        /// otherwise <see langword="null"/>
        /// </returns>
        Topic CreateTopic(string title);
    }
}