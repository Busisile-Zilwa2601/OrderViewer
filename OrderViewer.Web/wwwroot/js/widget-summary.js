function getSummaryUrl() {
    const params = new URLSearchParams(new FormData(document.querySelector("form")));
    return `/OrderViewer/GetOrderSummary?${params.toString()}`;
}

async function updateOrderSummary() {
    try {
        const response = await fetch(getSummaryUrl());
        const data = await response.json();
        document.getElementById("order-count").innerText = data.count;
        document.getElementById("order-total").innerText = data.grandTotal.toFixed(2);
        return data;
    }
    catch (err)
    {
        console.error("Summary update failed", err)
    }
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