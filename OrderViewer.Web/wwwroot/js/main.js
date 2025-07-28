document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("filter-form");
    const resultsContainer = document.getElementById("results-container");

    function fetchFilteredOrders() {
        const formData = new FormData(form);
        const params = new URLSearchParams(formData).toString();

        fetch(`/OrderViewer/OrderViewerIndex?${params}`, {
            headers: {
                "X-Requested-With": "XMLHttpRequest"
            }
        })
            .then(res => res.text())
            .then(html => {
                resultsContainer.innerHTML = html;
            })
            .catch(err => console.error("Fetch error:", err));
    }

    // Submit on input or select change
    form.querySelectorAll("input, select").forEach(input => {
        input.addEventListener("change", fetchFilteredOrders);
    });

    // Submit on pagination link click
    document.addEventListener("click", function (e) {
        if (e.target.classList.contains("page-link")) {
            e.preventDefault();
            const page = e.target.getAttribute("data-page");
            const pageInput = document.createElement("input");
            pageInput.type = "hidden";
            pageInput.name = "PageNumber";
            pageInput.value = page;

            // Remove old PageNumber input
            form.querySelector("input[name=PageNumber]")?.remove();
            form.appendChild(pageInput);

            fetchFilteredOrders();
        }
    });
});