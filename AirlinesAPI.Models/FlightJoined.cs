using System;
using System.Text.Json.Serialization;

namespace AirlinesAPI.Models;

public sealed class FlightJoined : IdModel, IEquatable<FlightJoined> {
    [JsonPropertyName("airline"), JsonRequired]
    public Airline Airline { get; set; } = null!;

    [JsonPropertyName("origin"), JsonRequired]
    public City Origin { get; set; } = null!;

    [JsonPropertyName("destination"), JsonRequired]
    public City Destination { get; set; } = null!;

    [JsonPropertyName("distance"), JsonRequired]
    public int Distance { get; set; }

    [JsonPropertyName("flight_time"), JsonRequired]
    public int FlightTime { get; set; }

    [JsonPropertyName("huf_per_km"), JsonRequired]
    public int HufPerKm { get; set; }

    public bool Equals(FlightJoined? other) {
        return other is not null
            && Id == other.Id
            && Airline.Equals(other.Airline)
            && Origin.Equals(other.Origin)
            && Destination.Equals(other.Destination)
            && Distance   == other.Distance
            && FlightTime == other.FlightTime
            && HufPerKm   == other.HufPerKm;
    }

    public override string ToString() => $"from {Origin.Name} ({Origin.Id}) to {Destination.Name} ({Destination.Id}) ({Id})";

    public Flight ToFlight() {
        return new() {
            Id            = Id,
            AirlineId     = Airline.Id,
            OriginId      = Origin.Id,
            DestinationId = Destination.Id,
            Distance      = Distance,
            FlightTime    = FlightTime,
            HufPerKm      = HufPerKm,
        };
    }
}
