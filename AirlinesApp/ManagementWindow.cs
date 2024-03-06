using AirlinesAPI.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shell;

namespace AirportApp;

internal sealed class ManagementWindow : Window {
    public ManagementWindow() {
        RequestHelper helper = new("http://localhost:5000");

        TableTab<Airline> airlinesTab = new(
            "Airlines",
            new() {
                Get = () => helper.Get<Airline>("/api/airlines"),
                Post = (airline) => helper.Post("/api/airlines", airline),
                Put = (id, airline) => helper.Put($"/api/airlines/{id}", airline),
                Delete = (id) => helper.Delete($"/api/airlines/{id}"),
                NextId = () => helper.NextId("/api/next-id/airlines")
            },
            new DataGridTextColumn { Header = "Id", IsReadOnly = true, Binding = new Binding("Id") },
            new DataGridTextColumn { Header = "Name", Binding = new Binding("Name") }
        );

        TableTab<City> citiesTab = new(
            "Cities",
            new() {
                Get = () => helper.Get<City>("/api/cities"),
                Post = (city) => helper.Post("/api/cities", city),
                Put = (id, city) => helper.Put($"/api/cities/{id}", city),
                Delete = (id) => helper.Delete($"/api/cities/{id}"),
                NextId = () => helper.NextId("/api/next-id/cities")
            },
            new DataGridTextColumn { Header = "Id", IsReadOnly = true, Binding = new Binding("Id") },
            new DataGridTextColumn { Header = "Name", Binding = new Binding("Name") },
            new DataGridTextColumn { Header = "Population", Binding = new Binding("Population") }
        );

        CustomGridComboBoxColumn<Airline> airlineIdColumn = new(airlinesTab.Grid.ItemList) { Header = "Airline Id", SelectedValueBinding = new Binding("AirlineId") };
        CustomGridComboBoxColumn<City> originIdColumn = new(citiesTab.Grid.ItemList) { Header = "Origin City Id", SelectedValueBinding = new Binding("OriginId") };
        CustomGridComboBoxColumn<City> destinationIdColumn = new(citiesTab.Grid.ItemList) { Header = "Destination City Id", SelectedValueBinding = new Binding("DestinationId") };

        TableTab<Flight> flightsTab = new(
            "Flights",
            new() {
                Get = async () => (await helper.Get<FlightJoined>("/api/flights"))?.Select(x => x.ToFlight()),
                Post = (flight) => helper.Post("/api/flights", flight),
                Put = (id, flight) => helper.Put($"/api/flights/{id}", flight),
                Delete = (id) => helper.Delete($"/api/flights/{id}"),
                NextId = () => helper.NextId("/api/next-id/flights")
            },
            new DataGridTextColumn { Header = "Id", IsReadOnly = true, Binding = new Binding("Id") },
            airlineIdColumn,
            originIdColumn,
            destinationIdColumn,
            new DataGridTextColumn { Header = "Distance", Binding = new Binding("Distance") },
            new DataGridTextColumn { Header = "Flight Time (minutes)", Binding = new Binding("FlightTime") },
            new DataGridTextColumn { Header = "Ft/Km", Binding = new Binding("HufPerKm") }
        );

        airlinesTab.Grid.ItemList.CollectionChanged += (_, _) => airlineIdColumn.ItemsSource = airlinesTab.Grid.ItemIds;
        citiesTab.Grid.ItemList.CollectionChanged += (_, _) => {
            originIdColumn.ItemsSource = citiesTab.Grid.ItemIds;
            destinationIdColumn.ItemsSource = citiesTab.Grid.ItemIds;
        };

        HomeTab homeTab = new(helper, airlinesTab.FillDataGrids, citiesTab.FillDataGrids, flightsTab.FillDataGrids);

        TabControl content = new() { SelectedItem = homeTab };
        content.SelectionChanged += (_, _) => {
            foreach (Border border in content.Items.OfType<TabItem>().Select(x => x.Header).OfType<Border>()) {
                bool selected = border.Equals((content.SelectedItem as TabItem)?.Header);
                border.Background = selected ? Brushes.LightSkyBlue : Brushes.White;
                border.BorderBrush = selected ? Brushes.LightSkyBlue : Brushes.LightGray;
            }
        };

        content.Items.Add(homeTab);
        content.Items.Add(airlinesTab);
        content.Items.Add(citiesTab);
        content.Items.Add(flightsTab);

        Background = Brushes.Transparent;
        Width = MinWidth = 750;
        Height = MinHeight = 500;
        Content = content;
        Title = "Airlines Database Manager";

        Closed += (_, _) => helper.Dispose();

        foreach (IInputElement element in content.Items)
            WindowChrome.SetIsHitTestVisibleInChrome(element, true);

        WindowChrome.SetWindowChrome(this, new() {
            ResizeBorderThickness = new(4),
            GlassFrameThickness = new(0, 32, 0, 0),
            CaptionHeight = 32
        });
    }
}
