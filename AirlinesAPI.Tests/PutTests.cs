namespace AirlinesAPI.Tests;

[TestClass]
public class PutTests {
    [TestInitialize]
    public async Task Initialize() => await Utils.Initialize();

    [TestMethod]
    [DataRow(1), DataRow(2), DataRow(3)]
    public async Task PutAirline(int id) {
        Airline airline  = new() { Name = $"airline-{id}" };
        var     response = await Utils.Client.PutAsJsonAsync($"/api/airlines/{id}", airline);
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var fetched = await Utils.Client.GetFromJsonAsync<Utils.Response<Airline>>($"/api/airlines/{id}");
        Assert.IsNotNull(fetched);
        Assert.IsTrue(airline.AreEqual(fetched.Data));
    }

    [TestMethod]
    [DataRow(2), DataRow(4), DataRow(6)]
    public async Task PutCity(int id) {
        City city     = new() { Name = $"city-{id}", Population = id * 2000 };
        var  response = await Utils.Client.PutAsJsonAsync($"/api/cities/{id}", city);
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var fetched = await Utils.Client.GetFromJsonAsync<Utils.Response<City>>($"/api/cities/{id}");
        Assert.IsNotNull(fetched);
        Assert.IsTrue(city.AreEqual(fetched.Data));
    }

    [TestMethod]
    [DataRow(1), DataRow(2), DataRow(3)]
    public async Task PutFlight(int id) {
        Flight flight = new() {
            AirlineId     = id,
            OriginId      = id * 2 - 1,
            DestinationId = id * 2,
            Distance      = id * 400,
            FlightTime    = id * 50,
            HufPerKm      = id * 6
        };
        var response = await Utils.Client.PutAsJsonAsync($"/api/flights/{id}", flight);
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var fetched = await Utils.Client.GetFromJsonAsync<Utils.Response<FlightJoined>>($"/api/flights/{id}");
        Assert.IsNotNull(fetched);
        Assert.IsTrue(flight.AreEqual(fetched.Data.ToFlight()));
    }

    [TestMethod]
    [DataRow(1), DataRow(2), DataRow(3)]
    public async Task PutInvalidFlight(int id) {
        Flight flight = new() {
            AirlineId     = id,
            OriginId      = id * 3,
            DestinationId = id * 30,
            Distance      = id * 300,
            FlightTime    = id * 30,
            HufPerKm      = id * 3
        };
        var response = await Utils.Client.PutAsJsonAsync($"/api/flights/{id}", flight);
        Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
    }

    [TestMethod]
    [DataRow(100), DataRow(200), DataRow(300)]
    public async Task PutAirlineWithNonExistentId(int id) {
        Airline airline  = new() { Name = $"airline-{id}" };
        var     response = await Utils.Client.PutAsJsonAsync($"/api/airlines/{id}", airline);
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [TestMethod]
    [DataRow(100), DataRow(200), DataRow(300)]
    public async Task PutCityWithNonExistentId(int id) {
        City city     = new() { Name = $"city-{id}", Population = id * 2000 };
        var  response = await Utils.Client.PutAsJsonAsync($"/api/cities/{id}", city);
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [TestMethod]
    [DataRow(100), DataRow(200), DataRow(300)]
    public async Task PutFlightWithNonExistentId(int id) {
        Flight flight = new() {
            AirlineId     = id / 100,
            OriginId      = id / 100 * 2 - 1,
            DestinationId = id / 100 * 2,
            Distance      = id * 400,
            FlightTime    = id * 50,
            HufPerKm      = id * 6
        };
        var response = await Utils.Client.PutAsJsonAsync($"/api/flights/{id}", flight);
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [TestMethod]
    [DataRow(100), DataRow(200), DataRow(300)]
    public async Task PutFlightWithNonExistentForeignId(int id) {
        Flight flight = new() {
            AirlineId     = id,
            OriginId      = id * 2 - 1,
            DestinationId = id * 2,
            Distance      = id * 400,
            FlightTime    = id * 50,
            HufPerKm      = id * 6
        };
        var response = await Utils.Client.PutAsJsonAsync($"/api/flights/{id}", flight);
        Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
    }

    [TestMethod]
    [DataRow("/api/airlines/1"), DataRow("/api/cities/2"), DataRow("/api/flights/3")]
    public async Task PutNullItems(string path) {
        var response = await Utils.Client.PutAsync(path, null);
        Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
    }
}
