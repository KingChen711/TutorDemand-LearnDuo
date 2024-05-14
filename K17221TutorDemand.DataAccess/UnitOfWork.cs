using K17221TutorDemand.DataAccess.Abstractions;
using Microsoft.Extensions.Configuration;

namespace K17221TutorDemand.DataAccess
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly TutorDemandDbContext _context;
        private readonly Lazy<IHubRepository> _hubRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IMessageRepository> _messageRepository;
        private readonly Lazy<IProfileRepository> _profileRepository;
        private readonly Lazy<IImagesRepository> _imagesRepository;
        private readonly Lazy<IPostRepository> _postRepository;

        public UnitOfWork(TutorDemandDbContext context, IConfiguration configuration)
        {
            _context = context;
            _hubRepository = new Lazy<IHubRepository>(() => new
                HubRepository(context));
            _userRepository = new Lazy<IUserRepository>(() => new
                UserRepository(context));
            _messageRepository = new Lazy<IMessageRepository>(() => new
                MessageRepository(context));
            _profileRepository = new Lazy<IProfileRepository>(() => new
                ProfileRepository(context));
            _imagesRepository = new Lazy<IImagesRepository>(() => new
                ImagesRepository(context, configuration));
            _postRepository = new Lazy<IPostRepository>(() => new
                PostRepository(context));
        }

        public IHubRepository Hub => _hubRepository.Value;
        public IUserRepository User => _userRepository.Value;
        public IMessageRepository Message => _messageRepository.Value;
        public IProfileRepository Profile => _profileRepository.Value;

        public IImagesRepository Images => _imagesRepository.Value;

        public IPostRepository Post => _postRepository.Value;

        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}