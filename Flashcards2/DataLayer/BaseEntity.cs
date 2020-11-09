﻿using System;

namespace Flashcards2.DataLayer
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public void SetCreatedAt(DateTime createdAt) => CreatedAt = createdAt;
        public void SetUpdatedAt(DateTime updatedAt) => UpdatedAt = updatedAt;
    }
}
