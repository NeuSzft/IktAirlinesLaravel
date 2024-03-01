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
        return response(new AirlineResource($airline), 201);
    }

    /**
     * Display the specified resource.
     */
    public function show(int $id)
    {
        $airline = Airline::findOrFail($id);
        return new AirlineResource($airline);
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(UpdateAirlineRequest $request, int $id)
    {
        $airline = Airline::findOrFail($id);
        $data = $request->validated();
        $airline->update($data);
        return new AirlineResource($airline);
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(int $id)
    {
        $airline = Airline::findOrFail($id);
        try {
            $airline->delete();
            return response()->noContent();
        } catch (\Throwable) {
            return response('', 405);
        }
    }
}
