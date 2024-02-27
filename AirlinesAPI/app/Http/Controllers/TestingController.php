<?php

namespace App\Http\Controllers;

class TestingController extends Controller
{
    public function migrateFresh()
    {
        $res = shell_exec('php /www/artisan migrate:fresh --seed');
        return response(str_replace("\n", '<br>', $res), $res ? 200 : 500);
    }
}
