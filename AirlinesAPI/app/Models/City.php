<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;

class City extends Model
{
    use HasFactory;

    public $timestamps = false;

    protected $fillable = [
        'id',
        'name',
        'population',
    ];

    protected $casts = [
        'population' => 'integer'
    ];

    public function flight(): BelongsTo
    {
        return $this->belongsTo(Flight::class);
    }
}
