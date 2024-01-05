using System.Reflection.Metadata;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CodexAppSuggestion.Data.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        //Property for image here
        public IFormFile ProfileImage { get; set; }
        public List<Idea>? Ideas { get; set; }



        public User()
        {
            
        }

        public User(string userName, string email, string password, IFormFile image )
        {
            
            UserName = userName;
            Email = email;
            Password = password;
            ProfileImage = image;

        }
    }
}
