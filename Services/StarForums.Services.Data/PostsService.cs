﻿namespace StarForums.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using StarForums.Data.Common.Repositories;
    using StarForums.Data.Models;
    using StarForums.Services.Mapping;
    using StarForums.Web.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> repository;

        public PostsService(IDeletableEntityRepository<Post> repository)
        {
            this.repository = repository;
        }

        public async Task<int> CreateAsync(CreatePostInputModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                CategoryId = model.CategoryId,
                Content = model.Content,
                UserId = model.UserId,
            };

            await this.repository.AddAsync(post);
            await this.repository.SaveChangesAsync();

            return post.Id;
        }

        public async Task DeleteAsync(int postId)
        {
            Post post = this.repository.All().Where(x => x.Id == postId).FirstOrDefault();

            this.repository.Delete(post);
            await this.repository.SaveChangesAsync();
        }

        public async Task EditAsync(int postId, string title, string content)
        {
            var post = this.repository.All().Where(x => x.Id == postId).FirstOrDefault();
            post.Content = content;
            post.Title = title;

            this.repository.Update(post);
            await this.repository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>() => this.repository.All().To<T>().ToList();

        public IEnumerable<T> GetByCategoryId<T>(int categoryId) => this.repository.All().Where(x => x.Category.Id == categoryId).To<T>().ToList();

        public IEnumerable<T> GetByCategoryName<T>(string categoryName)
        {
            return this.repository
                .All()
                .Where(x => x.Category.Name.Replace(" ", "-") == categoryName.Replace(" ", "-"))
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .ToList();
        }

        public T GetById<T>(int id) => this.repository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();

        public IEnumerable<T> GetByUserId<T>(string userId) => this.repository.All().Where(x => x.UserId == userId).To<T>().ToList();
    }
}
