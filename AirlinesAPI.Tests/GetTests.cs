namespace AirlinesAPI.Tests;

[TestClass]
public class GetTests {
    [TestInitialize]
    public async Task Initialize() => await Utils.Initialize();

    [TestMethod]
    public async Task GetAllAirlines() {
        var airlines = await Utils.Client.GetFromJsonAsync<Utils.Response<Airline[]>>("/api/airlines");

        Assert.IsNotNull(airlines);
        Assert.AreEqual(4, airlines.Data.Length);
    }

    [TestMethod]
    [DataRow(1), DataRow(2), DataRow(3), DataRow(4)]
    public async Task GetAirlineById(int id) {
        var airline = await Utils.Client.GetFromJsonAsync<Utils.Response<Airline>>($"/api/airlines/{id}");

        Assert.IsNotNull(airline);
        Assert.AreEqual(new Airline {
            Id   = id,
            Name = $"airline-{id}"
        }, airline.Data);
    }

    [TestMethod]
    public async Task GetAllCities() {
        var cities = await Utils.Client.GetFromJsonAsync<Utils.Response<City[]>>("/api/cities");

        Assert.IsNotNull(cities);
        Assert.AreEqual(8, cities.Data.Length);
    }

    [TestMethod]
    [DataRow(2), DataRow(3), DataRow(5), DataRow(7)]
    public async Task GetCityById(int id) {
        var city = await Utils.Client.GetFromJsonAsync<Utils.Response<City>>($"/api/cities/{id}");

        Assert.IsNotNull(city);
        Assert.AreEqual(new City {
            Id         = id,
            Name       = $"city-{id}",
            Population = id * 1000
        }, city.Data);
    }

    [TestMethod]
    public async Task GetAllFlights() {
        var flights = await Utils.Client.GetFromJsonAsync<Utils.Response<FlightJoined[]>>("/api/flights");

        Assert.IsNotNull(flights);
        Assert.AreEqual(3, flights.Data.Length);
    }

    [TestMethod]
    [DataRow(1), DataRow(2), DataRow(3)]
    public async Task GetFlightById(int id) {
        var flight = await Utils.Client.GetFromJsonAsync<Utils.Response<FlightJoined>>($"/api/flights/{id}");

        Assert.IsNotNull(flight);
        Assert.AreEqual(new FlightJoined {
            Id = id,
            Airline = new() {
                Id   = id,
                Name = $"airline-{id}"
            },
            Origin = new() {
                Id         = id * 2 - 1,
                Name       = $"city-{id * 2 - 1}",
                Population = (id * 2 - 1) * 1000
            },
            Destination = new() {
                Id         = id * 2,
                Name       = $"city-{id * 2}",
                Population = (id * 2) * 1000
            },
            Distance   = id * 300,
            FlightTime = id * 30,
            HufPerKm   = id * 3,
        }, flight.Data);
    }

    [TestMethod]
    [DataRow("/api/airlines/17"), DataRow("/api/cities/17"), DataRow("/api/flights/17"), DataRow("/api/flights/17/joined")]
    public async Task GetNonExistentItems(string path) {
        var response = await Utils.Client.GetAsync(path);
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [TestMethod]
    [DataRow("/api/airline"), DataRow("/api/city"), DataRow("/api/flight")]
    public async Task GetWrongPath(string path) {
        var response = await Utils.Client.GetAsync(path);
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }
}
