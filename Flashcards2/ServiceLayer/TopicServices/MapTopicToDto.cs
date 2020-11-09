using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Flashcards2.DataLayer;

namespace Flashcards2.ServiceLayer
{
    public static partial class Extensions
    {
        public static IQueryable<TopicDto> MapTopicToDto (this IQueryable<Topic> topics)
        {
            return topics.Select(p => p.MapTopicToDto());
        }

        public static TopicDto MapTopicToDto (this Topic topic)
        {
            return new TopicDto
            {
                TopicId = topic.TopicId,
                Title = topic.Title,

                CreatedAt = topic.CreatedAt,
                UpdatedAt = topic.UpdatedAt
            };
        }
    }
}
