<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;
use Illuminate\Database\Eloquent\Relations\HasMany;
use Illuminate\Database\Eloquent\Relations\HasOne;

class Flight extends Model
{
    use HasFactory;

    public $timestamps = false;

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

    public function airline(): BelongsTo
    {
        return $this->belongsTo(Airline::class, 'airline_id');
    }

    public function originCity(): BelongsTo
    {
        return $this->belongsTo(City::class, 'origin_id');
    }

    public function destinationCity(): BelongsTo
    {
        return $this->belongsTo(City::class, 'destination_id');
    }
}
