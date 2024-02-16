<?php

use App\Http\Controllers\AirlineController;
use App\Http\Controllers\CityController;
use App\Http\Controllers\FlightController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider and all of them will
| be assigned to the "api" middleware group. Make something great!
|
*/

Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
    return $request->user();
});

Route::post('/airlines', [AirlineController::class, 'store'])->name('airlines.store');
Route::get('/airlines', [AirlineController::class, 'index'])->name('airlines.index');
Route::get('/airlines/{id}', [AirlineController::class, 'show'])->name('airlines.show');
Route::put('/airlines/{id}', [AirlineController::class, 'update'])->name('airlines.update');
Route::delete('/airlines/{id}', [AirlineController::class, 'destroy'])->name('airlines.destroy');

Route::post('/cities', [CityController::class, 'store'])->name('cities.store');
Route::get('/cities', [CityController::class, 'index'])->name('cities.index');
Route::get('/cities/{id}', [CityController::class, 'show'])->name('cities.show');
Route::put('/cities/{id}', [CityController::class, 'update'])->name('cities.update');
Route::delete('/cities/{id}', [CityController::class, 'destroy'])->name('cities.destroy');

Route::post('/flights', [FlightController::class, 'store'])->name('flights.store');
Route::get('/flights', [FlightController::class, 'index'])->name('flights.index');
Route::get('/flights/{id}', [FlightController::class, 'show'])->name('flights.show');
Route::put('/flights/{id}', [FlightController::class, 'update'])->name('flights.update');
Route::delete('/flights/{id}', [FlightController::class, 'destroy'])->name('flights.destroy');
