<template>
    <PageLayout>
        <SuccessAlert v-if="isPurchased" :origin="origin" :destination="destination" :ticketLink="ticketLink" />

        <div id="booking" class="container mt-5">
            <h1 class="text-center mb-4">Flight Booking</h1>
            <form id="bookingForm">
                <div class="row">
                    <div class="col-12 col-md-6 mb-3">
                        <label for="origin-city" class="form-label">Origin City</label>
                        <select class="form-select" id="origin-city" v-model="origin" required>
                            <option v-for="country of countriesOrigin" :key="country" :value="country">{{ country }}
                            </option>
                        </select>
                    </div>
                    <div class="col-12 col-md-6 mb-3">
                        <label for="destination-city" class="form-label">Destination City</label>
                        <select class="form-select" id="destination-city" v-model="destination" :disabled="origin === ''"
                            required>
                            <option v-for="country of countriesDestination" :key="country" :value="country">{{ country }}
                            </option>
                        </select>
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col-12 col-md-6 mb-3">
                        <label for="passengers" class="form-label">Number of adults</label>
                        <input type="number" class="form-control" id="passengers" v-model="adultsCount" min="0" required>
                    </div>
                    <div class="col-12 col-md-6 mb-3">
                        <label for="children" class="form-label">Number of children</label>
                        <input type="number" class="form-control" id="children" v-model="childrenCount" min="0" required>
                    </div>
                </div>
            </form>

            <div id="flight" class="container d-flex flex-wrap" v-if="destination !== null">
                <template v-for="route in routes.filter(x => x.final === destination)" :key="route.final">
                    <div class="w-100 d-flex flex-wrap border rounded my-3">
                        <div class="col-12 col-md d-flex flex-wrap gap-3 justify-content-center  tickets">
                            <Ticket v-for="id in route.flightIds" :key="id" :flightId="id" :adults="adultsCount"
                                :children="childrenCount" class="col-sm-12 col-lg" />
                        </div>
                        <div class="d-flex flex-column col-12 col-lg-2 mt-2 mt-lg-0 ms-lg-3 text-center">
                            <div class="col-12 mt-lg-3">
                                <p class="fs-3 ">{{ calculateCost(route) }} HUF</p>
                            </div>
                            <div class="col">
                                <button type="button" :id="route.flightIds" :key="route.flightIds"
                                    :disabled="adultsCount + childrenCount < 1" @click="buyTicket(route)"
                                    class="btn btn-outline-success w-100 h-100 fs-1 fw-bolder">
                                    <i class="bi bi-basket2-fill"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                </template>
            </div>
        </div>
    </PageLayout>
</template>
  
<script>
import { ref, toRaw } from 'vue'
import { http } from "@utils/http"
import PageLayout from '@layouts/PageLayout.vue'
import SuccessAlert from '@components/SuccessAlert.vue'
import Ticket from "@components/Ticket.vue"


export default {
    mounted() {
        this.getFlights()
    },
    data() {
        return {
            flights: [],
            countriesOrigin: [],
            countriesDestination: [],
            origin: '',
            destination: '',
            adultsCount: ref(0),
            childrenCount: ref(0),
            passengerCount: ref(0),
            price: ref(0),
            routes: new Array(),
            isPurchased: false,
            purchaseTimeout: null,
            ticketLink: 0
        }
    },
    watch: {
        adultsCount() {
            this.passengerCount = this.adultsCount + this.childrenCount
        },
        childrenCount() {
            this.passengerCount = this.adultsCount + this.childrenCount
        },
        origin() {
            this.destination = null
            this.filteredDestinations()
            this.isPurchased = false
        },
        destination(value) {
            this.destination = value
            this.isPurchased = false
        },
        isPurchased(value) {
            if (value) {
                this.purchaseTimeout = setTimeout(() => {
                    this.isPurchased = false
                    this.purchaseTimeout = null
                }, 5000)
            }
            else {
                if (this.purchaseTimeout) {
                    clearTimeout(this.purchaseTimeout)
                    this.purchaseTimeout = null
                }
            }
        },
    },
    methods: {
        filteredDestinations() {
            const destinations = new Array()
            const routes = new Array()

            for (const flight of this.flights) {
                if (flight.origin.name === this.origin) {
                    destinations.push(flight.destination.name)
                    routes.push({
                        origin: flight.origin.name,
                        final: flight.destination.name,
                        flightIds: [flight.id],
                        distances: [flight.distance],
                        flightTimes: [flight.flight_time]
                    })
                }
            }

            for (const flight1 of this.flights) {
                if (flight1.origin.name === this.origin) {
                    for (const flight2 of this.flights) {
                        if (flight1.destination.name === flight2.origin.name) {

                            destinations.push(flight2.destination.name)
                            routes.push({
                                origin: flight1.origin.name,
                                final: flight2.destination.name,
                                flightIds: [flight1.id, flight2.id],
                                distances: [flight1.distance, flight2.distance],
                                flightTimes: [flight1.flight_time, flight2.flight_time]
                            })

                            for (const flight3 of this.flights) {
                                if (flight2.destination.name === flight3.origin.name) {
                                    destinations.push(flight3.destination.name)
                                    routes.push({
                                        origin: flight1.origin.name,
                                        final: flight3.destination.name,
                                        flightIds: [flight1.id, flight2.id, flight3.id],
                                        distances: [flight1.distance, flight2.distance, flight3.distance],
                                        flightTimes: [flight1.flight_time, flight2.flight_time, flight3.flight_time]
                                    })
                                }
                            }
                        }
                    }
                }
            }


            const uniqueDestinations = [...new Set(destinations)].sort()
            this.countriesDestination = uniqueDestinations


            this.routes = this.destination ? routes.filter(route => route.final === this.destination) : routes
        },
        calculateCost(flights) {
            let totalCost = 0
            for (const id of toRaw(flights.flightIds)) {
                const flight = toRaw(this.flights.find(x => x.id === id))

                let baseCostPerPassenger = flight.distance * flight.huf_per_km

                let totalBaseCostAdult = baseCostPerPassenger * this.adultsCount
                let totalBaseCostChild = baseCostPerPassenger * this.childrenCount

                let destinationPop = flight.destination.population
                let tourismTaxRate = destinationPop < 2000000 ? 0.05 : destinationPop < 10000000 ? 0.075 : 0.10

                let vatAdult = totalBaseCostAdult * 0.27
                let vatChild = totalBaseCostChild * 0.27
                let keroseneTax = flight.distance * 0.10
                let tourismTaxAdult = totalBaseCostAdult * tourismTaxRate
                let tourismTaxChild = totalBaseCostChild * tourismTaxRate

                let flightCostAdult = totalBaseCostAdult + vatAdult + keroseneTax + tourismTaxAdult
                let flightCostChild = totalBaseCostChild + vatChild + keroseneTax + tourismTaxChild

                if (flight.passengerCount > 10) {
                    flightCostAdult *= 0.90
                    flightCostChild *= 0.90
                }

                totalCost += flightCostAdult + (flightCostChild * 0.8)
            }

            return (this.adultsCount + this.childrenCount > 0) ? Math.round(totalCost) : 0
        },
        getFlights() {
            http.get("/flights")
                .then(response => {
                    const data = response.data

                    const countriesOrigin = new Set()
                    const countriesDestination = new Set()

                    for (const flight of data.data) {
                        this.flights.push(flight)
                        countriesOrigin.add(flight.origin.name)
                        countriesDestination.add(flight.destination.name)
                    }

                    this.countriesOrigin = [...countriesOrigin].sort()
                    this.countriesDestination = [...countriesDestination].sort()
                })
        },
        buyTicket(value) {
            const route = toRaw(value)
            let savedRoutes = JSON.parse(localStorage.getItem('savedRoutes')) || []

            savedRoutes.push({
                route: route,
                children: this.childrenCount,
                adults: this.adultsCount,
                price: this.calculateCost(route),
                date: new Date().toDateString(),
                time: new Date().toLocaleTimeString(navigator.language, {
                    hour: 'numeric',
                    minute: 'numeric',
                    second: 'numeric'
                })
            })

            localStorage.setItem('savedRoutes', JSON.stringify(savedRoutes))
            this.isPurchased = true
            this.ticketLink = `/summary/#ticket-${savedRoutes.length - 1}`
        }
    },
    components: {
        Ticket,
        PageLayout,
        SuccessAlert
    }
}
</script>