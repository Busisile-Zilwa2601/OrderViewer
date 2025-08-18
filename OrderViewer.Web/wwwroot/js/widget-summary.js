function getSummaryUrl() {
    const params = new URLSearchParams(new FormData(document.querySelector("form")));
    console.log("summary params: ", params.toString());
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

    const form = document.querySelector("form");

    form.addEventListener("change", e => {
        if (e.target.matches("input, select")) {
            updateOrderSummary();
        }
    });

    form.addEventListener("click", e => {
        if (e.target.matches("a, input, select")) {
            const link = e.target.closest("a.page-link");
            if (!link) return;

            e.preventDefault();
            console.log("Clicked: ", link.dataset.page);

            // get current filters from form
            const formData = new FormData(form);
            const params = new URLSearchParams(formData);

            // overwrite PageNumber with the clicked one
            params.set("PageNumber", link.dataset.page);

            // fetch summary
            fetch(`/OrderViewer/GetOrderSummary?${params.toString()}`)
                .then(res => res.json())
                .then(data => {
                    document.getElementById("order-count").innerText = data.count;
                    document.getElementById("order-total").innerText = data.grandTotal.toFixed(2);
                });
        }
    });
});