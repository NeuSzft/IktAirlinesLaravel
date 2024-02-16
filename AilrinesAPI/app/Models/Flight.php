<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\HasMany;
use Illuminate\Database\Eloquent\Relations\HasOne;

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

    protected $casts = [
        'distance' => 'integer',
        'flight_time' => 'integer',
        'huf_per_km' => 'integer',
    ];

    public function cities(): HasMany
    {
        return $this->hasMany(City::class);
    }

    public function airline(): HasOne
    {
        return $this->hasOne(Airline::class);
    }
}
