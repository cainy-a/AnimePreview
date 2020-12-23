using System.Data;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;

namespace AnilistApi
{
	public class Client
	{
		public async Task<int> GetUserIdByUsername(string username)
		{
			var query         = "query ($username: String) { User (name: $username) { id } }";
			var request = new GraphQLRequest{Query = query, Variables = new {username = username}};
			var graphQlClient = new GraphQLHttpClient("https://graphql.anilist.co", new SystemTextJsonSerializer());

			var response = await graphQlClient.SendQueryAsync<UserIdResponse>(request);

			return response.Data.User.id;
		}
	}

	public class UserIdResponse
	{
		public UserId User { get; set; }
	}

	public class UserId
	{
		public int id { get; set; }
	}
}
