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
        for ($i = 1; $i <= 8; $i++) {
            DB::table('cities')->insert([
                'id' => $i,
                'name' => 'city-' . $i,
                'population' => $i * 1000,
            ]);
        }
    }
}
