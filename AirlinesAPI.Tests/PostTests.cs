namespace AirlinesAPI.Tests;

[TestClass]
public class PostTests {
    [TestInitialize]
    public async Task Initialize() => await Utils.Initialize();

    [TestMethod]
    [DataRow(11), DataRow(12), DataRow(13)]
    public async Task PostAirline(int nameId) {
        Airline airline = new() { Name = $"airline-{nameId}" };
        var response = await Utils.Client.PostAsJsonAsync("/api/airlines", airline);
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

        var airlines = await Utils.Client.GetFromJsonAsync<Utils.Response<IEnumerable<Airline>>>("/api/airlines");
        Assert.IsNotNull(airlines);
        Assert.IsTrue(airline.EqualsAny(airlines.Data));
    }

    [TestMethod]
    [DataRow(11), DataRow(12), DataRow(13)]
    public async Task PostCity(int nameId) {
        City city = new() { Name = $"city-{nameId}", Population = nameId * 1000 };
        var response = await Utils.Client.PostAsJsonAsync("/api/cities", city);
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

        var cities = await Utils.Client.GetFromJsonAsync<Utils.Response<IEnumerable<City>>>("/api/cities");
        Assert.IsNotNull(cities);
        Assert.IsTrue(city.EqualsAny(cities.Data));
    }

    [TestMethod]
    [DataRow(1), DataRow(2), DataRow(3)]
    public async Task PostFlight(int airlineId) {
        Flight flight = new() {
            AirlineId = airlineId,
            OriginId = airlineId * 2 - 1,
            DestinationId = airlineId * 2,
            Distance = airlineId * 400,
            FlightTime = airlineId * 50,
            HufPerKm = airlineId * 6
        };
        var response = await Utils.Client.PostAsJsonAsync("/api/flights", flight);
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

        var flights = await Utils.Client.GetFromJsonAsync<Utils.Response<IEnumerable<FlightJoined>>>("/api/flights");
        Assert.IsNotNull(flights);
        Assert.IsTrue(flight.EqualsAny(flights.Data.Select(x => x.ToFlight())));
    }

    [TestMethod]
    [DataRow(100), DataRow(200), DataRow(300)]
    public async Task PostInvalidFlight(int airlineId) {
        Flight flight = new() {
            AirlineId = airlineId,
            OriginId = airlineId * 2 - 1,
            DestinationId = airlineId * 2,
            Distance = airlineId * 300,
            FlightTime = airlineId * 30,
            HufPerKm = airlineId * 3
        };
        var response = await Utils.Client.PostAsJsonAsync("/api/flights", flight);
        Assert.AreEqual(HttpStatusCode.UnprocessableContent, response.StatusCode);
    }

    [TestMethod]
    [DataRow("/airline"), DataRow("/city"), DataRow("/flight")]
    public async Task PostWrongPath(string path) {
        var response = await Utils.Client.PostAsync(path, null);
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }
}
