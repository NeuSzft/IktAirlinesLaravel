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
                'name' => 'airline-1',
            ],
            [
                'id' => 2,
                'name' => 'airline-2',
            ],
            [
                'id' => 3,
                'name' => 'airline-3',
            ],
            [
                'id' => 4,
                'name' => 'airline-4',
            ]
        ]);
    }
}
