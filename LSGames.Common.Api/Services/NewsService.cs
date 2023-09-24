using AutoMapper;
using LSGames.Common.Api.Models.ServiceModels;
using LSGames.Common.Api.Models.ServiceModels.News;
using LSGames.Common.Repository.Models;
using LSGames.Common.Repository.Repositories.News;

namespace LSGames.Common.Api.Services
{
    public class NewsService : INewsService
    {
        private readonly ILogger<NewsService> _logger;
        private readonly IMapper _mapper;
        private INewsRepository _newsRepository;
        private INewsTypeRepository _newsTypeRepository;
        private int _defaultRowPerPage = 10;

        public NewsService(
            ILogger<NewsService> logger,
            IMapper mapper,
            INewsRepository newsRepository,
            INewsTypeRepository newsTypeRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _newsRepository = newsRepository;
            _newsTypeRepository = newsTypeRepository;
        }

        /// <summary>
        /// 取得最新消息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetNewsResponseServiceModel> GetNewsList(GetPaginatorEntitiesRequestServiceModel request)
        {
            int page = request.Page ?? 1;
            int rowPerPage = request.RowPerPage ?? _defaultRowPerPage;
            int skip = (page - 1) * rowPerPage;

            var newsList = _mapper.Map<List<NewsServiceModel>>(
                await _newsRepository.GetNewsList(skip, rowPerPage));

            int totalNews = await _newsRepository.GetTotalNewsRows();

            return new GetNewsResponseServiceModel()
            {
                NewsList = newsList,
                TotalPages = (int) Math.Ceiling((double)totalNews / rowPerPage),
            };
        }

        /// <summary>
        /// 依據最新消息 PK 取得最新消息
        /// </summary>
        /// <param name="newsId">最新消息 PK</param>
        /// <returns></returns>
        public async Task<NewsServiceModel> GetNews(int newsId)
        {
            return _mapper.Map<NewsServiceModel>(
                await _newsRepository.GetNews(newsId));
        }

        /// <summary>
        /// 取得所有最新消息種類
        /// </summary>
        /// <returns></returns>
        public async Task<List<NewsTypeServiceModel>> GetNewsTypes()
        {
            var newsTypes = (await _newsTypeRepository.GetAsync()).ToList();
            newsTypes = newsTypes ?? new List<NewsType>();

            return _mapper.Map<List<NewsTypeServiceModel>>(
                newsTypes.ToList());
        }

        /// <summary>
        /// 新增消息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CreateNews(NewsServiceModel request)
        {
            request.CreatedAt = DateTime.UtcNow;
            request.UpdatedAt = DateTime.UtcNow;
            request.DeletedUserId = null;
            request.DeletedAt = null;
            var news = _mapper.Map<Repository.Models.News>(request);

            return await _newsRepository.CreateAsync(
                news);
        }

        /// <summary>
        /// 更新消息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> UpdateNews(NewsServiceModel request)
        {
            var news = await _newsRepository.GetNews(request.NewsId);
            news.NewsTypeId = request.NewsTypeId;
            news.NewsTitle = request.NewsTitle;
            news.NewsContent = request.NewsContent;
            news.UpdatedUserId = request.UpdatedUserId;
            news.UpdatedAt = DateTime.UtcNow;

            return await _newsRepository.UpdateAsync(news);
        }

        /// <summary>
        /// 刪除消息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> DeleteNews(NewsServiceModel request)
        {
            var news = await _newsRepository.GetNews(request.NewsId);
            news.DeletedUserId = request.DeletedUserId;
            news.DeletedAt = DateTime.UtcNow;

            return await _newsRepository.UpdateAsync(news);
        }
    }
}
