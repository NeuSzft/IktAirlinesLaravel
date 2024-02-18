<?php

namespace App\Http\Resources;

use Illuminate\Http\Request;
use Illuminate\Http\Resources\Json\JsonResource;

class FlightResource extends JsonResource
{
    /**
     * Transform the resource into an array.
     *
     * @return array<string, mixed>
     */
    public function toArray(Request $request): array
    {
        return [
            'id' => $this->id,
            'airline' => new AirlineResource($this->whenLoaded('airline')),
            'origin' => new CityResource($this->whenLoaded('originCity')),
            'destination' => new CityResource($this->whenLoaded('destinationCity')),
            'distance' => $this->distance,
            'flight_time' => $this->flight_time,
            'huf_per_km' => $this->huf_per_km,
        ];
    }
}
