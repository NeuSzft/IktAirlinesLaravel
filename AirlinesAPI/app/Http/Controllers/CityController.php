<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreCityRequest;
use App\Http\Requests\UpdateCityRequest;
use App\Http\Resources\CityResource;
use App\Models\City;

class CityController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $cities = City::get();
        return CityResource::collection($cities);
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(StoreCityRequest $request)
    {
        $data = $request->validated();
        $city = City::create($data);
        return response(new CityResource($city), 201);
    }

    /**
     * Display the specified resource.
     */
    public function show(int $id)
    {
        $city = City::findOrFail($id);
        return new CityResource($city);
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(UpdateCityRequest $request, int $id)
    {
        $city = City::findOrFail($id);
        $data = $request->validated();
        $city->update($data);
        return new CityResource($city);
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(int $id)
    {
        $city = City::findOrFail($id);
        try {
            $city->delete();
            return response()->noContent();
        } catch (\Throwable $e) {
            return response($e->getMessage(), 405);
        }
    }
}
