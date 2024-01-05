using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace CodexAppSuggestion.Data.Model
{
    public class Idea
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? Title { get; set; }
        public string? IdeaDescription { get; set; }
        public string? Category { get; set; }
        public bool Status { get; set; } 
        public DateTime DateCompleted { get; set; }

    }
}
