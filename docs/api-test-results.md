
# Test Run
### Run Summary

<p>
<strong>Overall Result:</strong> ✔️ Pass <br />
<strong>Pass Rate:</strong> 100% <br />
<strong>Run Duration:</strong> 43s 165ms <br />
<strong>Date:</strong> 2024-03-07 20:08:20 - 2024-03-07 20:09:03 <br />
<strong>Framework:</strong> .NETCoreApp,Version=v8.0 <br />
<strong>Total Tests:</strong> 81 <br />
</p>

<table>
<thead>
<tr>
<th>✔️ Passed</th>
<th>❌ Failed</th>
<th>⚠️ Skipped</th>
</tr>
</thead>
<tbody>
<tr>
<td>81</td>
<td>0</td>
<td>0</td>
</tr>
<tr>
<td>100%</td>
<td>0%</td>
<td>0%</td>
</tr>
</tbody>
</table>

### Result Sets
#### AirlinesAPI.Tests.dll - 100%
<details>
<summary>Full Results</summary>
<table>
<thead>
<tr>
<th>Result</th>
<th>Test</th>
<th>Duration</th>
</tr>
</thead>
<tr>
<td> ✔️ Passed </td>
<td>DeleteAirline (4)</td>
<td>613ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>DeleteCity (7)</td>
<td>619ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>DeleteCity (8)</td>
<td>607ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>DeleteFlight (1)</td>
<td>601ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>DeleteFlight (2)</td>
<td>605ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>DeleteFlight (3)</td>
<td>600ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>FailToDeleteAirline (1)</td>
<td>610ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>FailToDeleteAirline (2)</td>
<td>557ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>FailToDeleteAirline (3)</td>
<td>557ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>FailToDeleteCity (2)</td>
<td>559ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>FailToDeleteCity (3)</td>
<td>562ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>FailToDeleteCity (5)</td>
<td>553ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>DeleteNonExistentItems (/api/airlines/17)</td>
<td>493ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>DeleteNonExistentItems (/api/cities/17)</td>
<td>490ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>DeleteNonExistentItems (/api/flights/17)</td>
<td>499ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>DeleteWrongPath (/api/airline)</td>
<td>487ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>DeleteWrongPath (/api/city)</td>
<td>498ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>DeleteWrongPath (/api/flight)</td>
<td>485ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetAllAirlines</td>
<td>510ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetAirlineById (1)</td>
<td>511ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetAirlineById (2)</td>
<td>495ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetAirlineById (3)</td>
<td>508ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetAirlineById (4)</td>
<td>506ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetAllCities</td>
<td>528ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetCityById (2)</td>
<td>494ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetCityById (3)</td>
<td>502ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetCityById (5)</td>
<td>488ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetCityById (7)</td>
<td>502ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetAllFlights</td>
<td>495ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetFlightById (1)</td>
<td>515ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetFlightById (2)</td>
<td>496ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetFlightById (3)</td>
<td>506ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetNonExistentItems (/api/airlines/17)</td>
<td>488ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetNonExistentItems (/api/cities/17)</td>
<td>506ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetNonExistentItems (/api/flights/17)</td>
<td>490ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetNonExistentItems (/api/flights/17/joined)</td>
<td>492ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetWrongPath (/api/airline)</td>
<td>484ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetWrongPath (/api/city)</td>
<td>497ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>GetWrongPath (/api/flight)</td>
<td>508ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PostAirline (11)</td>
<td>577ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PostAirline (12)</td>
<td>563ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PostAirline (13)</td>
<td>564ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PostCity (11)</td>
<td>563ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PostCity (12)</td>
<td>568ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PostCity (13)</td>
<td>567ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PostFlight (1)</td>
<td>569ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PostFlight (2)</td>
<td>589ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PostFlight (3)</td>
<td>570ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PostInvalidFlight (100)</td>
<td>499ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PostInvalidFlight (200)</td>
<td>498ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PostInvalidFlight (300)</td>
<td>499ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PostWrongPath (/airline)</td>
<td>482ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PostWrongPath (/city)</td>
<td>504ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PostWrongPath (/flight)</td>
<td>490ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutAirline (1)</td>
<td>599ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutAirline (2)</td>
<td>563ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutAirline (3)</td>
<td>555ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutCity (2)</td>
<td>567ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutCity (4)</td>
<td>560ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutCity (6)</td>
<td>574ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutFlight (1)</td>
<td>573ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutFlight (2)</td>
<td>580ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutFlight (3)</td>
<td>591ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutInvalidFlight (1)</td>
<td>493ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutInvalidFlight (2)</td>
<td>494ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutInvalidFlight (3)</td>
<td>496ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutAirlineWithNonExistentId (100)</td>
<td>502ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutAirlineWithNonExistentId (200)</td>
<td>495ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutAirlineWithNonExistentId (300)</td>
<td>497ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutCityWithNonExistentId (100)</td>
<td>501ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutCityWithNonExistentId (200)</td>
<td>502ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutCityWithNonExistentId (300)</td>
<td>504ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutFlightWithNonExistentId (100)</td>
<td>502ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutFlightWithNonExistentId (200)</td>
<td>502ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutFlightWithNonExistentId (300)</td>
<td>495ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutFlightWithNonExistentForeignId (100)</td>
<td>494ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutFlightWithNonExistentForeignId (200)</td>
<td>500ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutFlightWithNonExistentForeignId (300)</td>
<td>493ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutNullItems (/api/airlines/1)</td>
<td>492ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutNullItems (/api/cities/2)</td>
<td>494ms</td>
</tr>
<tr>
<td> ✔️ Passed </td>
<td>PutNullItems (/api/flights/3)</td>
<td>486ms</td>
</tr>
</tbody>
</table>
</details>

### Run Messages
<details>
<summary>Informational</summary>
<pre><code>
</code></pre>
</details>

<details>
<summary>Warning</summary>
<pre><code>
</code></pre>
</details>

<details>
<summary>Error</summary>
<pre><code>
</code></pre>
</details>



----

[Created using Liquid Test Reports](https://github.com/kurtmkurtm/LiquidTestReports)