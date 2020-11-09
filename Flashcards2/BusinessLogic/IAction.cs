using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Flashcards2.BusinessLogic
{
    public interface IAction<in TIn, out TOut>
    {
        IImmutableList<ValidationResult> Errors { get; }
        bool HasErrors { get; }
        TOut Action(TIn dto);
    }
}
