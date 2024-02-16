<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class AirlineSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        DB::table('airlines')->insert([
            [
                'id' => 1,
                'name' => 'Delta Air Lines',
            ],
            [
                'id' => 2,
                'name' => 'American Airlines',
            ],
            [
                'id' => 3,
                'name' => 'United Airlines',
            ],
            [
                'id' => 4,
                'name' => 'Emirates',
            ],
            [
                'id' => 5,
                'name' => 'Southwest Airlines',
            ],
            [
                'id' => 6,
                'name' => 'China Southern Airlines',
            ],
            [
                'id' => 7,
                'name' => 'China Eastern Airlines',
            ],
            [
                'id' => 8,
                'name' => 'Air China',
            ],
            [
                'id' => 9,
                'name' => 'Air Canada',
            ],
            [
                'id' => 10,
                'name' => 'Qatar Airways',
            ],
        ]);
    }
}
