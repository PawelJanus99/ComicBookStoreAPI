﻿using ComicBookStoreAPI.Domain.Entities;
using ComicBookStoreAPI.Domain.Models;

namespace ComicBookStoreAPI.Domain.Interfaces.Services
{
    public interface IComicBookRatingBookService
    {
        List<RatingDto> GetAll(int comicBookId);
        RatingDto GetById(int comicBookId, int id);
    }
}