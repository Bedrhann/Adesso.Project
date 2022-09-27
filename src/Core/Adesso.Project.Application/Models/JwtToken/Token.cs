

namespace Adesso.Project.Application.Models.JwtToken
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime TokenLifeTime { get; set; }
    }
}
