using Investor.Service.Interfaces;
using System;
using Investor.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Investor.Entity;
using AutoMapper;
using Investor.Repository.Interfaces;
using System.Linq;

namespace Investor.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ITagService _tagService;

        public PostService(IPostRepository postRepository, ITagService tagService)
        {
            _postRepository = postRepository;
            _tagService = tagService;
        }

        public async Task<Post> AddPostAsync(Post map)
        {
            if (map.Title == null)
            {
                map.Title = Guid.NewGuid().ToString();
            }
            map.ModifiedOn = DateTime.Now;
            map.CreatedOn = DateTime.Now;
            if (String.IsNullOrWhiteSpace(map.Image))
            {
                map.Image = $"no-img/no-img-{map.Category.Url}.png";
            }
            var response = await _postRepository.AddPostAsync(Mapper.Map<Post, PostEntity>(map));
            map.PostId = response.PostId;

            return map;
        }

        public async Task<IEnumerable<T>> GetAllPostsAsync<T>()
        {
            var posts = await _postRepository.GetAllPostsAsync();
            return posts.Select(Mapper.Map<PostEntity, T>);
        }

        public async Task<IEnumerable<PostPreview>> GetLatestPostsByCategoryUrlAsync(string categoryUrl, bool onMainPage = false, int limit = 10)
        {
            return (await _postRepository
                .GetLatestPostsByCategoryUrlAsync(categoryUrl, onMainPage, limit))
                .Select(Mapper.Map<PostEntity, PostPreview>);
        }

        public async Task<IEnumerable<PostPreview>> GetPagedLatestPostsByCategoryUrlAsync(string categoryUrl, int limit = 10, int page = 1)
        {
            return (await _postRepository
                .GetPagedLatestPostsByCategoryUrlAsync(categoryUrl, limit, page))
                .Select(Mapper.Map<PostEntity, PostPreview>);
        }

        public async Task<IEnumerable<PostPreview>> GetAllPostsByTagNameAsync(string tagName)
        {
            var posts = await _postRepository.GetAllPostsByTagNameAsync(tagName);
            return posts.Select(Mapper.Map<PostEntity, PostPreview>);
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return Mapper.Map<PostEntity, Post>(await _postRepository.GetPostByIdAsync(id));
        }

        public async Task<int> GetTotalNumberOfPostByTagAsync(string tag)
        {
            return await _postRepository.GetTotalNumberOfPostByTagAsync(tag);
        }

        public async Task<int> GetTotalNumberOfPostsByCategoryUrlAsync(string categoryUrl)
        {
            return await _postRepository.GetTotalNumberOfPostsByCategoryUrlAsync(categoryUrl);
        }

        public async Task<int> GetTotalNumberOfPostsAsync()
        {
            return await _postRepository.GetTotalNumberOfPostsAsync();
        }

        public async Task<IEnumerable<PostPreview>> GetLatestPostsAsync(int limit)
        {
            var posts = await _postRepository.GetLatestPostsAsync(limit);

            return posts.Select(Mapper.Map<PostEntity, PostPreview>);
        }

        public async Task<Post> UpdatePostAsync(Post post)
        {
            PostEntity newPost = Mapper.Map<Post, PostEntity>(post);
            newPost.CategoryId = newPost.Category.CategoryId;
            var result = await _postRepository.UpdatePostAsync(newPost);
            return Mapper.Map<PostEntity, Post>(result);
        }
        public async Task UpdatePostAsync(IEnumerable<Post> posts)
        {
            await _postRepository.UpdatePostAsync(posts.Select(Mapper.Map<Post, PostEntity>));
        }

        public async Task RemovePostAsync(int id)
        {
            await _postRepository.RemovePostAsync(id);
        }

        public async Task RemovePostAsync(IEnumerable<int> id)
        {
            await _postRepository.RemovePostAsync(id);
        }

        public async Task<IEnumerable<PostPreview>> GetPopularPostByCategoryUrlAsync(string categoryUrl, int limit)
        {
            var posts = await _postRepository.GetPopularPostByCategoryUrlAsync(categoryUrl, limit);
            return posts.Select(Mapper.Map<PostEntity, PostPreview>);
        }

        public async Task<IEnumerable<PostPreview>> GetImportantPostsAsync(int limit)
        {
            var posts = await _postRepository.GetImportantPostAsync(limit);
            var test = posts.Select(Mapper.Map<PostEntity, PostPreview>);
            return test;
        }

        public async Task AddTagToPostAsync(int postId, string tagName)
        {
            var postTags = await _postRepository.GetAllTagsByPostIdAsync(postId);
            var tag = await _tagService.GetTagByNameAsync(tagName) ?? await _tagService.AddTagAsync(new Tag { Name = tagName });
            if (!postTags.Select(s => s.Name).Contains(tagName))
            {
                await _postRepository.AddTagToPostAsync(postId, Mapper.Map<Tag, TagEntity>(tag));
            }
        }

        public async Task AddTagsToPostAsync(int postId, IEnumerable<string> tags)
        {
            if (tags != null)
            {
                var postTags = await _postRepository.GetAllTagsByPostIdAsync(postId);
                foreach(var t in tags)
                {
                    var tag = await _tagService.GetTagByNameAsync(t) ?? await _tagService.AddTagAsync(new Tag { Name = t });
                    if (!postTags.Select(s => s.Name).Contains(t))
                    {
                        await _postRepository.AddTagToPostAsync(postId, Mapper.Map<Tag, TagEntity>(tag));
                    }
                }
            }
        }

        public async Task<IEnumerable<Tag>> GetAllTagsByPostId(int id)
        {
            List<TagEntity> tags = await _postRepository.GetAllTagsByPostIdAsync(id);
            return tags.Select(Mapper.Map<TagEntity, Tag>);
        }
    }
}
