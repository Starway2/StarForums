﻿namespace StarForums.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using StarForums.Data.Common.Repositories;
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> repository;

        public PostsService(IDeletableEntityRepository<Post> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<Post> query = this.repository.All();

            return query.To<T>().ToList();
        }

        public IEnumerable<T> GetByCategoryId<T>(int categoryId)
        {
            var posts = this.repository.All().Where(x => x.Category.Id == categoryId);

            return posts.To<T>().ToList();
        }

        public IEnumerable<T> GetByCategoryName<T>(string categoryName)
        {
            var posts = this.repository.All().Where(x => x.Category.Name.Replace(" ", "-") == categoryName.Replace(" ", "-"));

            return posts.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var post = this.repository.All().Where(x => x.Id == id);

            return post.To<T>().FirstOrDefault();
        }
    }
}
