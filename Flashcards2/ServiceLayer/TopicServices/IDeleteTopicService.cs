namespace Flashcards2.ServiceLayer.TopicServices
{
    public interface IDeleteTopicService
    {
        /// <summary>
        /// Deletes Topic with given Id.
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns>
        /// <see cref="TopicDto"/> if topic is successfully removed; otherwise <see langword="null"/>.
        /// </returns>
        TopicDto DeleteTopic(int topicId);
    }
}