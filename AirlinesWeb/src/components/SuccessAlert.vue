<template>
    <div class="alert alert-success position-fixed z-1 translate-middle top-25 start-50 w-75 fs-5 text-center" role="alert">
        <i class="bi bi-check-circle"></i>
        <span>
            Flight for
            <router-link :to="ticketLink" aria-current="page" class="alert-link d-inline fw-bold">{{ origin }} →{{ destination }}</router-link>
            has been booked!
        </span>
    </div>
</template>
  
<script>
export default {
    props: [
        'origin',
        'destination',
        'ticketLink'
    ]
}
</script>
  