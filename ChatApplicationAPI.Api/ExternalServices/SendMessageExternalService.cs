namespace ChatApplicationAPI.Api.ExternalServices
{
    public class SendMessageExternalService
    {
        private readonly IWebHostEnvironment _env;

        public SendMessageExternalService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> AddGetPath(IFormFile file)
        {
            string path = Path.Combine(_env.WebRootPath, "paths", Guid.NewGuid() + file.FileName);

            using (var stream = File.Create(path))
            {
                await file.CopyToAsync(stream);
            }

            return path;
        }
    }
}
