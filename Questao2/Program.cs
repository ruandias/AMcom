using RestSharp;
using System.Text.Json;

public partial class Program
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
        int page = 1;

        int totalScoreGoals = 0;

        var resp1 = CallClient(year, team, page);

        foreach (var score in resp1.data)
        {
            totalScoreGoals += int.Parse(score.team1goals);
        }

        page = 2;

        var resp2 = CallClient(year, team, page);

        foreach (var score in resp2.data)
        {
            totalScoreGoals += int.Parse(score.team1goals);
        }

        page = 3;

        var resp3 = CallClient(year, team, page);

        foreach (var score in resp3.data)
        {
            totalScoreGoals += int.Parse(score.team1goals);
        }




        return totalScoreGoals;
    }

    private static Data CallClient(int year, string team, int page)
    {
        var client = new RestClient("https://jsonmock.hackerrank.com/api/football_matches");
        var request = new RestRequest($"?year={year}&team1={team}&page={page}");
        var response = client.ExecuteGet(request);

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        return JsonSerializer.Deserialize<Data>(response.Content, options);

    }


}