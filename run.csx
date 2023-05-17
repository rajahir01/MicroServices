#r "Newtonsoft.Json"
using System;
using System.Net;
using Newtonsoft.Json;
using System.Text;

public static async Task Run(TimerInfo myTimer, ILogger log)
{
    var jsonString = await MakeStackOverflowExchangeRequest();
    var jsonb = JsonConvert.DeserializeObject<dynamic>(jsonString);
    var NewQuestionCount = jsonb.items.Count;

    await MakeSlackRequest($"You have {NewQuestionCount} questions on StackOverflow");
    log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
}
public static async Task<string> MakeStackOverflowExchangeRequest()
{
    //to calculate the number of seconds between the epoch time (January 1st, 1970 at midnight UTC) and the date and time 24 hours ago in UTC. The resulting value is stored in the variable ePochTime as an integer.
    var ePochTime = (Int32)(DateTime.UtcNow.AddDays(-365).Subtract(new DateTime(1970,1,1))).TotalSeconds;
    HttpClientHandler handler = new HttpClientHandler()
    {
        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
    };
            
    using (var client = new HttpClient(handler))
    {
        var response = await client.GetAsync($"https://api.stackexchange.com/2.3/search?fromdate={ePochTime}&order=desc&sort=activity&intitle=rcs&site=stackoverflow");

        var result = await response.Content.ReadAsStringAsync();

        return result;
    }
}

public static async Task<string> MakeSlackRequest(string message)
{
  using (var client = new HttpClient())
  {
    var requestData = new StringContent("{'text':'" + message + "'}", Encoding.UTF8, "application/json");

    var response = await client.PostAsync($"https://hooks.slack.com/services/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", requestData);

    var result = await response.Content.ReadAsStringAsync();

    return result;
  }
}
