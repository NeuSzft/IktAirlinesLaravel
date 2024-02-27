<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class FlightSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        DB::table('flights')->insert([
            [
                'id' => 1,
                'airline_id' => 1,
                'origin_id' => 1,
                'destination_id' => 2,
                'distance' => 300,
                'flight_time' => 30,
                'huf_per_km' => 3,
            ],
            [
                'id' => 2,
                'airline_id' => 2,
                'origin_id' => 3,
                'destination_id' => 4,
                'distance' => 600,
                'flight_time' => 60,
                'huf_per_km' => 6,
            ],
            [
                'id' => 3,
                'airline_id' => 3,
                'origin_id' => 5,
                'destination_id' => 6,
                'distance' => 900,
                'flight_time' => 90,
                'huf_per_km' => 9,
            ]
        ]);
    }
}
