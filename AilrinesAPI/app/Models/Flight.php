<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Flight extends Model
{
    use HasFactory;

    protected $fillable = [
        'id',
        'airline_id',
        'origin_id',
        'destination_id',
        'distance',
        'flight_time',
        'huf_per_km',
    ];
}
