<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreFlightRequest;
use App\Http\Requests\UpdateFlightRequest;
use App\Http\Resources\FlightResource;
use App\Models\Flight;

class FlightController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $flights = Flight::with(['airline', 'originCity', 'destinationCity'])->get();
        return FlightResource::collection($flights);
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(StoreFlightRequest $request)
    {
        $data = $request->validated();
        $newFlight = Flight::create($data);
        $flight = Flight::with(['airline', 'originCity', 'destinationCity'])->findOrFail($newFlight->id);
        return response(new FlightResource($flight), 201);
    }

    /**
     * Display the specified resource.
     */
    public function show(int $id)
    {
        $flight = Flight::with(['airline', 'originCity', 'destinationCity'])->findOrFail($id);
        return new FlightResource($flight);
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(UpdateFlightRequest $request, string $id)
    {
        $flight = Flight::with(['airline', 'originCity', 'destinationCity'])->findOrFail($id);
        $data = $request->validated($request);
        $flight->update($data);
        return new FlightResource($flight);
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(int $id)
    {
        $flight = Flight::with(['airline', 'originCity', 'destinationCity'])->findOrFail($id);
        $flight->delete();
        return response()->noContent();
    }
}
