function getSummaryUrl() {
    const params = new URLSearchParams(new FormData(document.querySelector("form")));
    console.log(`summary params ${params}`);
    return `/OrderViewer/GetOrderSummary?${params.toString()}`;
}

function updateOrderSummary() {
    fetch(getSummaryUrl())
        .then(res => res.json())
        .then(data => {
            document.getElementById("order-count").innerText = data.Count;
            document.getElementById("order-total").innerText = data.GrandTotal.toFixed(2);
        })
        .catch(err => console.error("Summary update failed", err));
}

// Trigger update on page load & form change
document.addEventListener("DOMContentLoaded", () => {
    updateOrderSummary();

    // Optionally re-fetch summary on any filter change
    const inputs = document.querySelectorAll("form input, form select");
    inputs.forEach(input => {
        input.addEventListener("change", updateOrderSummary);
    });
});