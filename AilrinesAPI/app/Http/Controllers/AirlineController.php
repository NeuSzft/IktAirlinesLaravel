<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreAirlineRequest;
use App\Http\Requests\UpdateAirlineRequest;
use App\Http\Resources\AirlineResource;
use App\Models\Airline;

class AirlineController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $airlines = Airline::get();
        return AirlineResource::collection($airlines);
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(StoreAirlineRequest $request)
    {
        $data = $request->validated();
        $airline = Airline::create($data);
        return new AirlineResource($airline);
    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        $airline = Airline::findOrFail($id);
        return new AirlineResource($airline);
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(UpdateAirlineRequest $request, string $id)
    {
        $airline = Airline::findOrFail($id);
        $data = $request->validated();
        $airline->update($data);
        return new AirlineResource($airline);
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        $airline = Airline::findOrFail($id);
        $airline->delete();
        return response()->noContent();
    }
}
