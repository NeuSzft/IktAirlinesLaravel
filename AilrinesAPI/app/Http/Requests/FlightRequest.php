<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class FlightRequest extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     */
    public function authorize(): bool
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array<string, \Illuminate\Contracts\Validation\ValidationRule|array<mixed>|string>
     */
    public function rules(): array
    {
        return [
            'airline_id' => ['required', 'exists:airlines,id'],
            'origin_id' => ['required', 'exists:cities,id'],
            'destination_id' => ['required', 'exists:cities,id'],
            'distance' => ['required', 'integer', 'gt:0'],
            'flight_time' => ['required', 'integer', 'gt:0'],
            'huf_per_km' => ['required', 'integer', 'gte:0'],
        ];
    }
}
