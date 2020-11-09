using Flashcards2.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Flashcards2.ServiceLayer
{
    public class ListTopicsService : IListTopicsService
    {
        FlashcardsDbContext _dbContext;
        public ListTopicsService(FlashcardsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<Topic> ListTopics()
        {
            return _dbContext.Topics.ToList();
        }
    }
}
