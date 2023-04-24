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


        var resp = CallApi(year, team, 1);
        var totalScoreGoals = 0;

        for (int i = 1; i <= resp.total_pages; i++)
        {
            resp = CallApi(year, team, i);

            foreach (var match in resp.data)
            {
                totalScoreGoals += int.Parse(match.team1goals);
            }
        }
        
        return totalScoreGoals;

    }

    private static Data CallApi(int year, string team, int page)
    {
        var parameters = new
        {
            yearParam = year,
            team1Param = team,
            pageParam = page
        };

        var client = new RestClient("https://jsonmock.hackerrank.com/api/football_matches");
        var request = new RestRequest($"?year={parameters.yearParam}&team1={parameters.team1Param}&page={parameters.pageParam}");
        var response = client.ExecuteGet(request);


        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        return JsonSerializer.Deserialize<Data>(response.Content, options);
    }



}