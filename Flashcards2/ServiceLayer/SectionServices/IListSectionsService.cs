using Flashcards2.DataLayer;
using System.Collections.Generic;
using System.Linq;

namespace Flashcards2.ServiceLayer
{
    public interface IListSectionsService
    {
        /// <summary>
        /// Lists all sections for the topic with the given <paramref name="topicId"/>.
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns><see cref="List{T}"/> of sections</returns>
        IList<SectionDto> ListSections(int topicId);
        /// <summary>
        /// Gets the section with the given <paramref name="sectionId"/>.
        /// </summary>
        /// <param name="sectionId"></param>
        /// <returns><see cref="SectionDto"/></returns>
        SectionDto GetSection(int sectionId);
    }
}