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
            'airline_id' => $this->airline_id,
            'origin_id' => $this->origin_id,
            'destination_id' => $this->destination_id,
            'distance' => $this->distance,
            'flight_time' => $this->flight_time,
            'huf_per_km' => $this->huf_per_km,
        ];
    }
}
