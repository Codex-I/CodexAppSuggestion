using CodexAppSuggestion.Data.Model;
using MongoDB.Driver;
using System.Transactions;

namespace CodexAppSuggestion.Data
{
    public class Db
    {
	    	
		private const string ConnectionString = "mongodb://localhost:27017/";
        private const string DatabaseName = "App_Ideas";
        private const string UserCollection = "Users";
        private const string IdeaCollection = "Ideas";


        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        public Task CreateUser(User user)
        {
            var usersCollection = ConnectToMongo<User>(UserCollection);
            return usersCollection.InsertOneAsync(user);
        }
        public User GetUser(string email)
        {
            var usersCollection = ConnectToMongo<User>(UserCollection);
            var usersGotten = usersCollection.Find(u => u.Email == email);
            return usersGotten.FirstAsync().Result;
        }
        public Task UpdateUser(User user)
        {
            var usersCollection = ConnectToMongo<User>(UserCollection);
            var updateUser = Builders<User>.Filter.Eq("Id", user.Id);
            return usersCollection.ReplaceOneAsync(updateUser, user);
        }

        public List<User> FindAllUsers()
        {
            var usersCollection = ConnectToMongo<User>(UserCollection);
            var findAllUser = usersCollection.Find(_ => true);
            return findAllUser.ToList();
        }

        public Task CreateIdea(Idea idea)
        {
            var ideaCollection = ConnectToMongo<Idea>(IdeaCollection);
            return ideaCollection.InsertOneAsync(idea);
        }

        public Idea GetIdea(string id)
        {
            var ideaCollection = ConnectToMongo<Idea>(IdeaCollection);
            var ideaGotten = ideaCollection.Find(c => c.Id == id);
            return ideaGotten.FirstAsync().Result;
        }

        public List<Idea> GetListOfIdeas(string email)
        {
            var listOfIdeas = ConnectToMongo<Idea>(IdeaCollection);
            var result = listOfIdeas.Find(i => i.Email == email);
            return result.ToList();
        }

        public Task UpdateIdea(Idea idea)
        {
            var ideasCollection = ConnectToMongo<Idea>(IdeaCollection);
            var updateTask = Builders<Idea>.Filter.Eq("Id", idea.Id);
            return ideasCollection.ReplaceOneAsync(updateTask, idea);
        }


    }
		
    
}
