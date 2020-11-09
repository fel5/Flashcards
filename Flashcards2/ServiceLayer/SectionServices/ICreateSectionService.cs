using Flashcards2.BusinessLogic;
using Flashcards2.DataLayer;
using System.Collections.Immutable;

namespace Flashcards2.ServiceLayer
{
    public interface ICreateSectionService
    {
        IImmutableList<ValidationResult> Errors { get; }
        /// <summary>
        /// Creates new section.
        /// </summary>
        /// <param name="sectionTitle">Title of the section to create.</param>
        /// <param name="topicId">Id of the topic in which the section should be created.</param>
        /// <returns>
        /// <see cref="SectionDto"/> if section was created successfully;
        /// otherwise <see langword="null"/>.
        /// </returns>
        SectionDto CreateSection(string sectionTitle, int topicId);
    }
}