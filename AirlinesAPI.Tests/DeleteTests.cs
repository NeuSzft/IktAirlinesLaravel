namespace AirlinesAPI.Tests;

[TestClass]
public class DeleteTests {
    [TestInitialize]
    public async Task Initialize() => await Utils.Initialize();

    [TestMethod]
    [DataRow(4)]
    public async Task DeleteAirline(int id) {
        var response = await Utils.Client.DeleteAsync($"/api/airlines/{id}");
        Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);

        response = await Utils.Client.GetAsync($"/api/airlines/{id}");
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [TestMethod]
    [DataRow(7), DataRow(8)]
    public async Task DeleteCity(int id) {
        var response = await Utils.Client.DeleteAsync($"/api/cities/{id}");
        Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);

        response = await Utils.Client.GetAsync($"/api/cities/{id}");
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [TestMethod]
    [DataRow(1), DataRow(2), DataRow(3)]
    public async Task DeleteFlight(int id) {
        var response = await Utils.Client.DeleteAsync($"/api/flights/{id}");
        Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);

        response = await Utils.Client.GetAsync($"/api/flights/{id}");
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [TestMethod]
    [DataRow(1), DataRow(2), DataRow(3)]
    public async Task FailToDeleteAirline(int id) {
        var response = await Utils.Client.DeleteAsync($"/api/airlines/{id}");
        Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        response = await Utils.Client.GetAsync($"/api/airlines/{id}");
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [TestMethod]
    [DataRow(2), DataRow(3), DataRow(5)]
    public async Task FailToDeleteCity(int id) {
        var response = await Utils.Client.DeleteAsync($"/api/cities/{id}");
        Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);

        response = await Utils.Client.GetAsync($"/api/cities/{id}");
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [TestMethod]
    [DataRow("/api/airlines/17"), DataRow("/api/cities/17"), DataRow("/api/flights/17")]
    public async Task DeleteNonExistentItems(string path) {
        var response = await Utils.Client.DeleteAsync(path);
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [TestMethod]
    [DataRow("/api/airline"), DataRow("/api/city"), DataRow("/api/flight")]
    public async Task DeleteWrongPath(string path) {
        var response = await Utils.Client.DeleteAsync(path);
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }
}
