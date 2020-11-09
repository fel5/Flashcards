using Flashcards2.DataLayer;

namespace Flashcards2.ServiceLayer.SectionServices
{
    public interface IDeleteSectionService
    {
        /// <summary>
        /// Removes section with given Id.
        /// </summary>
        /// <param name="sectionId">The id of the section to remove.</param>
        /// <returns>
        /// <see langword="true"/> if section was successfully removed;
        /// otherwise <see langword="false"/>.
        /// </returns>
        bool DeleteSection(int sectionId);
    }
}