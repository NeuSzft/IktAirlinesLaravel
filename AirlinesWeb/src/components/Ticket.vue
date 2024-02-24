<template>
    <div :id="flightId" class="card w-100" v-if="flight">
        <h4 class="card-header fw-bold">{{ flight.origin.name }} → {{ flight.destination.name }}</h4>
        <div class="card-body">
            <h5 class="card-title mb-3">{{ flight.airline.name }}</h5>
            <div class="row d-flex">
                <div class="col text-start">
                    <p class="card-text">Distance: <span class="distance fw-bold">{{ flight.distance }} km</span></p>
                    <p class="card-text">Price/km: <span class="fw-bold">{{ flight.huf_per_km }} HUF</span></p>
                    <p class="card-text">Adults: <span class="fw-bold">{{ adults }}</span></p>
                    <p class="card-text">Children: <span class="fw-bold">{{ children }}</span></p>
                </div>
            </div>
        </div>
        <p class="card-footer fw-bold mb-0" v-if="price > 0">Price: <span class="ticket-price">{{ price }}</span> HUF</p>
        <div class="card-footer mb-0 fw-bold d-flex gap-1 align-items-center" v-else>
            <p class="mb-1">Price: Free</p>
        </div>
    </div>
    <div v-else class="d-flex justify-content-center w-100">
        <div class="spinner-border" role="status">
            <span class="visually-hidden">Loading...</span>
        </div>
    </div>
</template>

<script>
import { http } from "@utils/http"

export default {
    props: {
        flightId: Number,
        adults: Number,
        children: Number
    },
    mounted() {
        this.getFlight()
    },
    data() {
        return {
            flight: null,
            price: 0,
        }
    },
    watch: {
        adults() {
            if (this.flight === null) return
            this.price = this.calculateCost()
        },
        children() {
            if (this.flight === null) return
            this.price = this.calculateCost()
        }
    },
    methods: {
        getFlight() {
            http.get(`/flights/${this.flightId}`)
                .then(response => {
                    this.flight = response.data.data
                    this.price = this.calculateCost()
                })
        },
        calculateCost() {
            let totalCost = 0;
            const flight = this.flight;

            let baseCostPerPassenger = flight.distance * flight.huf_per_km;
            let totalBaseCostAdult = baseCostPerPassenger * this.adults;
            let totalBaseCostChild = baseCostPerPassenger * this.children;

            let destinationPop = flight.destination.population;
            let vatAdult = totalBaseCostAdult * 0.27;
            let vatChild = totalBaseCostChild * 0.27;

            let keroseneTax = flight.distance * 0.10;
            let tourismTaxRate = destinationPop < 2000000 ? 0.05 : destinationPop < 10000000 ? 0.075 : 0.10;
            let tourismTaxAdult = totalBaseCostAdult * tourismTaxRate;
            let tourismTaxChild = totalBaseCostChild * tourismTaxRate;

            let flightCostAdult = totalBaseCostAdult + vatAdult + keroseneTax + tourismTaxAdult;
            let flightCostChild = totalBaseCostChild + vatChild + keroseneTax + tourismTaxChild;

            if (flight.passengerCount > 10) {
                flightCostAdult *= 0.90;
                flightCostChild *= 0.90;
            }

            totalCost += flightCostAdult + (flightCostChild * 0.8);
            return (this.adults + this.children > 0) ? Math.round(totalCost) : 0;
        }

    }
}
</script>
