using Newtonsoft.Json;
using Questao2;
using RestSharp;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        int page = 0;
        int goals = 0;
        Score score = null;

        do
        {
            page++;

            string url = string.Format("https://jsonmock.hackerrank.com/api/football_matches?year={0}&team1={1}&page={2}", year, team, page);            

            score = FazRequisicaoGet(url);

            goals += score.data.Select(x => x.team1goals).Sum();            
        } while (page != score.total_pages);

        page = 0;
        do
        {
            page++;

            string url = string.Format("https://jsonmock.hackerrank.com/api/football_matches?year={0}&team2={1}&page={2}", year, team, page);

            score = FazRequisicaoGet(url);

            goals += score.data.Select(x => x.team2goals).Sum();            
        } while (page != score.total_pages);

        return goals;
    }

    public static Score FazRequisicaoGet(string url)
    {
        try
        {
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.Get(request);

            return JsonConvert.DeserializeObject<Score>(response.Content);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

}