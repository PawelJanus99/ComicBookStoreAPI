﻿using ComicBookStoreAPI.Domain.Entities;
using ComicBookStoreAPI.Domain.Exceptions;
using ComicBookStoreAPI.Domain.Interfaces.DbContext;
using ComicBookStoreAPI.Domain.Interfaces.Repositories;

namespace ComicBookStoreAPI.Services
{
    public class RatingService
    {
        private readonly IRepository<ComicBook> _comicBookRepository;
        private readonly IApplicationDbContext _dbContext;

        public RatingService(IRepository<ComicBook> comicBookRepository, IApplicationDbContext dbContext)
        {
            _comicBookRepository = comicBookRepository;
            _dbContext = dbContext;
        }
        public Rating GetAll(int comicBookId)
        {
            var resoult = _dbContext.Rating.Where(r => r.ComicBook.Id == comicBookId).FirstOrDefault();

            if (resoult == null)
            {
                throw new DatabaseException($"The Rating entity for ComicBook Id: {comicBookId} was not found");
            }
            else
            {
                return resoult;
            }
        }
    }
}
