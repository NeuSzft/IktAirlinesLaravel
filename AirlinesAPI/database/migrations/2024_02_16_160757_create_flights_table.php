<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('flights', function (Blueprint $table) {
            $table->id();
            $table->foreignId('airline_id')->constrained();
            $table->foreignId('origin_id')->constrained('cities', 'id');
            $table->foreignId('destination_id')->constrained('cities', 'id');
            $table->integer('distance');
            $table->integer('flight_time');
            $table->integer('huf_per_km');
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('flights');
    }
};
