
using Newtonsoft.Json;
using System.Net;
using Week16BitCoinApp;

BitCoinRate bitcoin = GetRates();

Console.WriteLine($"Current Bitcoin rate is: {bitcoin.bpi.EUR.rate_float} {bitcoin.bpi.EUR.code}");

static BitCoinRate GetRates()
{
    string url = "https://api.coindesk.com/v1/bpi/currentprice.json";

    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "GET";

    var webResponse = request.GetResponse();
    var webStream = webResponse.GetResponseStream();

    BitCoinRate bitcoinRate;

    using(var responseReader = new StreamReader(webStream))
    {
        var response = responseReader.ReadToEnd();
        bitcoinRate = JsonConvert.DeserializeObject<BitCoinRate>(response);
    }

    return bitcoinRate;
}