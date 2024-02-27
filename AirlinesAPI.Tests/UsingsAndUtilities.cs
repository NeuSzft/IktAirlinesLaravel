global using AirlinesAPI.Models;
global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using System.Net;
global using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text.Json.Serialization;

namespace AirlinesAPI.Tests;

public static class Utils {
    public class Response<T> where T : class {
        [JsonRequired, JsonPropertyName("data")]
        public T Data { get; set; } = null!;
    }

    public static readonly HttpClient Client;

    private static readonly bool PingFailed;

    static Utils() {
        string apiAddress = Environment.GetEnvironmentVariable("API_ADDRESS")!;

        try {
            using Ping ping = new();
            ping.Send(apiAddress, 5000);
        }
        catch {
            PingFailed = true;
        }

        Client = new() { BaseAddress = new($"http://{apiAddress}") };
    }

    public static async Task Initialize() {
        if (PingFailed)
            Assert.Inconclusive($"{Client.BaseAddress} is unreachable");
        Assert.AreEqual(HttpStatusCode.OK, (await Client.GetAsync("/api/testing/migrate-fresh")).StatusCode);
    }

    public static bool AreEqual<T>(this T model, T other) where T : IdModel {
        foreach (PropertyInfo info in typeof(T).GetProperties().Where(x => x.Name != "Id"))
            if (!info.GetValue(model)?.Equals(info.GetValue(other)) ?? true)
                return false;
        return true;
    }

    public static bool EqualsAny<T>(this T model, IEnumerable<T> others) where T : IdModel {
        foreach (T item in others)
            if (AreEqual(model, item))
                return true;
        return false;
    }
}
