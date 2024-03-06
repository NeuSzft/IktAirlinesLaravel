<?php

namespace App\Http\Controllers;

use Illuminate\Support\Facades\DB;

class NextIdController extends Controller
{
    public function airlines()
    {
        $result = DB::select("SHOW TABLE STATUS LIKE 'airlines'");
        return $result[0]->Auto_increment;
    }

    public function cities()
    {
        $result = DB::select("SHOW TABLE STATUS LIKE 'cities'");
        return $result[0]->Auto_increment;
    }

    public function flights()
    {
        $result = DB::select("SHOW TABLE STATUS LIKE 'flights'");
        return $result[0]->Auto_increment;
    }
}
