<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;

class Airline extends Model
{
    use HasFactory;

    public $timestamps = false;
    
    protected $fillable = [
        'id',
        'name',
    ];

    public function flight(): BelongsTo
    {
        return $this->belongsTo(Flight::class);
    }
}
