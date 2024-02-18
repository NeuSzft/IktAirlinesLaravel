<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class CitySeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        DB::table('cities')->insert([
            [
                'id' => 1,
                'name' => 'Tokyo',
                'population' => 13960000,
            ],
            [
                'id' => 2,
                'name' => 'New York',
                'population' => 8419000,
            ],
            [
                'id' => 3,
                'name' => 'Paris',
                'population' => 2148000,
            ],
            [
                'id' => 4,
                'name' => 'Moscow',
                'population' => 11920000,
            ],
            [
                'id' => 5,
                'name' => 'Beijing',
                'population' => 21540000,
            ],
            [
                'id' => 6,
                'name' => 'Sydney',
                'population' => 5312000,
            ],
            [
                'id' => 7,
                'name' => 'Rio de Janeiro',
                'population' => 6748000,
            ],
            [
                'id' => 8,
                'name' => 'Cairo',
                'population' => 10200000,
            ],
            [
                'id' => 9,
                'name' => 'Mumbai',
                'population' => 20411000,
            ],
            [
                'id' => 10,
                'name' => 'Los Angeles',
                'population' => 3971000,
            ],
            [
                'id' => 11,
                'name' => 'Shanghai',
                'population' => 26320000,
            ],
            [
                'id' => 12,
                'name' => 'Istanbul',
                'population' => 15460000,
            ],
            [
                'id' => 13,
                'name' => 'Karachi',
                'population' => 16000000,
            ],
            [
                'id' => 14,
                'name' => 'Seoul',
                'population' => 9776000,
            ],
            [
                'id' => 15,
                'name' => 'Lagos',
                'population' => 14000000,
            ],
            [
                'id' => 16,
                'name' => 'Jakarta',
                'population' => 10750000,
            ],
            [
                'id' => 17,
                'name' => 'São Paulo',
                'population' => 12300000,
            ],
            [
                'id' => 18,
                'name' => 'Mexico City',
                'population' => 9200000,
            ],
            [
                'id' => 19,
                'name' => 'Delhi',
                'population' => 19000000,
            ],
            [
                'id' => 20,
                'name' => 'Manila',
                'population' => 13900000,
            ],
            [
                'id' => 21,
                'name' => 'Toronto',
                'population' => 2930000,
            ],
            [
                'id' => 22,
                'name' => 'Berlin',
                'population' => 3645000,
            ],
            [
                'id' => 23,
                'name' => 'Madrid',
                'population' => 3265000,
            ],
            [
                'id' => 24,
                'name' => 'Bangkok',
                'population' => 10560000,
            ],
            [
                'id' => 25,
                'name' => 'Tehran',
                'population' => 8840000,
            ],
            [
                'id' => 26,
                'name' => 'Johannesburg',
                'population' => 9570000,
            ],
            [
                'id' => 27,
                'name' => 'Buenos Aires',
                'population' => 15100000,
            ],
            [
                'id' => 28,
                'name' => 'Taipei',
                'population' => 7870000,
            ],
            [
                'id' => 29,
                'name' => 'Lima',
                'population' => 10750000,
            ],
            [
                'id' => 30,
                'name' => 'Budapest',
                'population' => 1700000,
            ],
        ]);
    }
}
