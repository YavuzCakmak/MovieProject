using AutoMapper;
using MicroGroup.Business.Services.Abstraction;
using MicroGroup.Model.Dto;
using MicroGroup.Model.Model.Movie;
using Microsoft.IdentityModel.Tokens;
using NCrontab;
using RestSharp;
using System.Text;
using System.Text.Json;

namespace MicroGroup.Business.Services.Concretion
{
    public class MovieScheduledService : IMovieScheduledService
    {
        public MovieScheduledService()
        {
            var schedule = CrontabSchedule.Parse("0 * * * *");

            var nextRun = schedule.GetNextOccurrence(DateTime.Now);
            var timer = new System.Threading.Timer(async _ =>
            {
                await GetMovieAndSave();
                nextRun = schedule.GetNextOccurrence(DateTime.Now);
            }, null, nextRun - DateTime.Now, TimeSpan.FromHours(1));
        }

        /// <summary>
        /// Scheduled
        /// </summary>
        /// <returns></returns>
        public async Task GetMovieAndSave()
        {
            var options = new RestClientOptions("https://api.themoviedb.org/3/discover/movie");
            var client = new RestClient(options);
            var request = new RestRequest("");


            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJlMGM1ZDdlMjVhMWFhMzU5ZWE2YzU3MDhiNGYzMDI2ZiIsInN1YiI6IjY0YjI5MWFkZTBjYTdmMDEyNTNjZTA4YSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.x2MNymfP0fwbghU-L6sdUBIjWUeLxDyR2KI-47rPXDg");

            var response = await client.GetAsync(request);
            if (response.IsSuccessful)
            {
                TheMovieDto theMovieDto = Newtonsoft.Json.JsonConvert.DeserializeObject<TheMovieDto>(response.Content.ToString());
                foreach (var content in theMovieDto.Results)
                {
                    var httpClient = new HttpClient();
                    var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44377/api/Movies/AddForScheduled");
                    httpRequestMessage.Headers.Add("Cookie", ".AspNetCore.Session=CfDJ8MiST4csqIFOoYL6rU7KFAUa03vRJmpGpTVK0cSg%2FHDefAgm2UP4fLQRKsNWpeMQ%2Fpb0IznfA9LcEkCwL0gWkbpE5liOaNiUurwb5MPbwBa1AQ8ObU5skOZyFR94SrJ2mteDb6CcLbXT%2B8dUOckDxDbuhRn2BTL6p8d41a5%2Biqpq");

                    var movieModel = new MovieModel
                    {
                        Name = content.original_title,
                        AverageScore = content.vote_average
                    };

                    var jsonContent = JsonSerializer.Serialize(movieModel);
                    var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    httpRequestMessage.Content = stringContent;

                    var responseMessage = await httpClient.SendAsync(httpRequestMessage);
                    responseMessage.EnsureSuccessStatusCode();
                    Console.WriteLine(await responseMessage.Content.ReadAsStringAsync());
                }
            }
        }
    }
}
